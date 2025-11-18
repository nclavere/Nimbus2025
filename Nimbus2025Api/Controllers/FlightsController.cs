using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nimbus2025model.Context;
using Nimbus2025model.Entities;
using Nimbus2025Transverse.Dtos;

namespace Nimbus2025Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly Nimbus2025Context _context;

        public FlightsController(Nimbus2025Context context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightDto>>> GetFlights()
        {
            return await _context.Flights
               .Include(f => f.Cities)
               .Include(f => f.Company)
               .Include(f => f.AirportFrom)
               .Include(f => f.AirportTo)
               .Select(a => new FlightDto
               {
                   Id = a.Id,
                   IsOpen = a.IsOpen,
                   Departure = a.Departure,
                   Arrival = a.Arrival,
                   CompagnyName = a.Company!.Name,
                   AirportFrom = new AirportDto
                   {
                       Id = a.AirportFrom!.Id,
                       Name = a.AirportFrom!.Name,
                       Code = a.AirportFrom!.Code
                   },
                   AirportTo = new AirportDto
                   {
                       Id = a.AirportTo!.Id,
                       Name = a.AirportTo!.Name,
                       Code = a.AirportTo!.Code
                   },
                   Cities = a.Cities!.Select(c => c.Name).ToList()
               })
               .ToListAsync();
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDto>> GetFlight(int id)
        {
            var flight = await _context.Flights
               .Include(f => f.Cities)
               .Include(f => f.Company)
               .Include(f => f.AirportFrom)
               .Include(f => f.AirportTo)
               .Where(a => a.Id == id)
               .Select(a => new FlightDto
               {
                   Id = a.Id,
                   IsOpen = a.IsOpen,
                   Departure = a.Departure,
                   Arrival = a.Arrival,
                   CompagnyName = a.Company!.Name,
                   AirportFrom = new AirportDto
                   {
                       Id = a.AirportFrom!.Id,
                       Name = a.AirportFrom!.Name,
                       Code = a.AirportFrom!.Code
                   },
                   AirportTo = new AirportDto
                   {
                       Id = a.AirportTo!.Id,
                       Name = a.AirportTo!.Name,
                       Code = a.AirportTo!.Code
                   },
                   Cities = a.Cities!.Select(c => c.Name).ToList()
               })
               .FirstAsync();

            if (flight == null)
            {
                return NotFound();
            }

            return flight;
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest();
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlight", new { id = flight.Id }, flight);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.Id == id);
        }
    }
}
