using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Core.DTOs;
using NiflheimsForge.Data;

namespace NiflheimsForge.Controllers;

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
    public async Task<ActionResult<IEnumerable<CountryDTO>>> GetCountriesAsync()
    {
        return await _context.Countries.Select(c => new CountryDTO
        (
        c.Id,
        c.Name,
        c.Description
        )).ToListAsync();
    }

    // GET: api/countries/5
    [HttpGet("countries/{id}")]
    public async Task<ActionResult<CountryDTO>> GetCountryBy(Guid? id)
    {
        var country = await _context.Countries.FindAsync(id);   

        if (country == null)
        {
            return NotFound();
        }

        var countryDTO = new CountryDTO(
            country.Id,
            country.Name,
            country.Description);

        return countryDTO;
    }

    // PUT: api/countries/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("countries/{id}")]
    public async Task<IActionResult> UpdateCountry(Guid id, CountryDTO countryDTO)
    {
        if (id != countryDTO.Id)
        {
            return BadRequest();
        }

        var country = new Country
        {
            Id = countryDTO.Id,
            Name = countryDTO.Name,
            Description = countryDTO.Description
        };

        _context.Entry(country).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryExists(id))
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

    [HttpPost("countries")]
    public async Task<ActionResult<CreateCountryDTO>> CreateCountryAsync(CreateCountryDTO countryDTO)
    {
        var country = new Country
        {
            Name = countryDTO.Name,
            Description = countryDTO.Description
        };

        _context.Countries.Add(country);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCountryBy", new { id = country.Id }, country);
    }

    // DELETE: api/countries/5
    [HttpDelete("countries/{id}")]
    public async Task<IActionResult> DeleteCountry(Guid? id)
    {
        var country = await _context.Countries.FindAsync(id);
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
