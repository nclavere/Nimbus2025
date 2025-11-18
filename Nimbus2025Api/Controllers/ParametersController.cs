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
    public class ParametersController : ControllerBase
    {
        private readonly Nimbus2025Context _context;

        public ParametersController(Nimbus2025Context context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        [Route("Companies")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetCompanies()
        {
            return await _context.Companies
                .Select(c => new ItemDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        // GET: api/Cities
        [HttpGet]
        [Route("Cities")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetCities()
        {
            return await _context.Cities
                 .Select(c => new ItemDto
                 {
                     Id = c.Id,
                     Name = c.Name
                 })
                .ToListAsync();
        }

    }
}
