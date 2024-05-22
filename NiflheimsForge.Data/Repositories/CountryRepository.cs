using Microsoft.EntityFrameworkCore;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly NiflheimsForgeDBContext _context;

        public CountryRepository(NiflheimsForgeDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await _context.Countries
                .Select(c => new Country
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                }).ToListAsync();
        }
    }
}
