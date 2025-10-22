using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nimbus2025model.Context;
using Nimbus2025model.Dtos;
using Nimbus2025model.Entities;
using Nimbus2025model.Migrations;

namespace Nimbus2025Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly Nimbus2025Context _context;

        public AirportsController(Nimbus2025Context context)
        {
            _context = context;
        }

        // GET: api/Airports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirportDto>>> GetAirports()
        {
            return await _context.Airports
                .Include(a => a.Cities)
                .Select(a => new AirportDto
                {
                    Name = a.Name,
                    Code = a.Code
                })
                .ToListAsync();
        }

        // GET: api/AirportsWithCities
        [HttpGet]
        [Route("WithCities")]
        public async Task<ActionResult<IEnumerable<AirportDto>>> GetAirportsWithCities()
        {
            return await _context.Airports
                .Include(a => a.Cities)
                .Select(a => new AirportDto
                {
                    Name = a.Name,
                    Code = a.Code,
                    Cities = a.Cities!.Select(c => c.Name).ToList()
                })
                .ToListAsync();
        }

        // GET: api/Airports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirportDto>> GetAirport(int id)
        {
            var airport = await _context.Airports
                .Include(a => a.Cities)
                .Where(a => a.Id == id)
                .Select(a => new AirportDto
                {
                    Name = a.Name,
                    Code = a.Code,
                    Cities = a.Cities!.Select(c => c.Name).ToList()
                })
                .FirstAsync();

            if (airport == null)
            {
                return NotFound();
            }

            return airport;
        }

        // PUT: api/Airports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirport(int id, Airport airport)
        {
            if (id != airport.Id)
            {
                return BadRequest();
            }

            _context.Entry(airport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportExists(id))
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

        // POST: api/Airports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Airport>> PostAirport(Airport airport)
        {
            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirport", new { id = airport.Id }, airport);
        }

        // DELETE: api/Airports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            var airport = await _context.Airports.FindAsync(id);
            if (airport == null)
            {
                return NotFound();
            }

            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AirportExists(int id)
        {
            return _context.Airports.Any(e => e.Id == id);
        }
    }
}
