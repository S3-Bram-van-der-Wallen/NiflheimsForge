using NiflheimsForge.Core.DTOs;
using NiflheimsForge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiflheimsForge.Data;
using Microsoft.EntityFrameworkCore;

namespace NiflheimsForge.Core.Services;

public class CountryService
{
    private readonly NiflheimsForgeDBContext _context;

    public CountryService(NiflheimsForgeDBContext context)
    {
        _context = context;
    }
    public async Task<List<CountryDTO>> GetCountries()
    {
        return await _context.Countries
            .Select(c => new CountryDTO
            (
            c.Id,
            c.Name,
            c.Description
            )).ToListAsync();
    }
}
