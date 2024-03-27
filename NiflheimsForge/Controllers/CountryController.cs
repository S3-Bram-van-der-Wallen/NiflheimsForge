using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Data;

namespace NiflheimsForge.Controllers
{
    [Route("api")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly NiflheimsForgeDBContext _context;

        public CountryController(NiflheimsForgeDBContext context)
        {
            _context = context;
        }

        // GET: api/countries
        [HttpGet("countries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/countries/5
        [HttpGet("countries/{id}")]
        public async Task<ActionResult<Country>> GetCountryBy(Guid? id)
        {
            Country country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("countries/{id}")]
        public async Task<IActionResult> UpdateCountry(string id, Country country)
        {
            Guid guid = Guid.Parse(id);
            if (guid != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(guid))
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

        // POST: api/countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("countries")]
        public async Task<ActionResult<Country>> CreateCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/countries/5
        [HttpDelete("countries/{id}")]
        public async Task<IActionResult> DeleteCountry(Guid? id)
        {
            Country country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(Guid? id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
