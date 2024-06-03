using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Data;

namespace NiflheimsForge.Controllers;

[Route("api")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly NiflheimsForgeDBContext _context;

    public CityController(NiflheimsForgeDBContext context)
    {
        _context = context;
    }

    // GET: api/cities
    [HttpGet("cities")]
    public async Task<ActionResult<IEnumerable<City>>> GetCities()
    {
        return await _context.Cities.ToListAsync();
    }

    // GET: api/cities/5
    [HttpGet("cities/{id}")]
    public async Task<ActionResult<City>> GetCity(Guid? id)
    {
        var city = await _context.Cities.FindAsync(id);

        if (city == null)
        {
            return NotFound();
        }

        return city;
    }

    // PUT: api/cities/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("cities/{id}")]
    public async Task<IActionResult> PutCity(Guid? id, City city)
    {
        if (id != city.Id)
        {
            return BadRequest();
        }

        _context.Entry(city).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CityExists(id))
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

    // POST: api/cities
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("cities")]
    public async Task<ActionResult<City>> PostCity(City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCity", new { id = city.Id }, city);
    }

    // DELETE: api/cities/5
    [HttpDelete("cities/{id}")]
    public async Task<IActionResult> DeleteCity(Guid? id)
    {
        var city = await _context.Cities.FindAsync(id);
        if (city == null)
        {
            return NotFound();
        }

        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CityExists(Guid? id)
    {
        return _context.Cities.Any(e => e.Id == id);
    }
}
