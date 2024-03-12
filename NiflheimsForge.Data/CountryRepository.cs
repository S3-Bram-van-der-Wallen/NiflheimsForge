using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NiflheimsForge.Core.DTO;
using NiflheimsForge.Core.Interfaces;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Data;

namespace NiflheimsForge.Repository;

public class CountryRepository : ICountryRepository
{
    public async Task<List<CountryDTO>> GetAllCountries()
    {
        using (NiflheimsForgeDBContext db = new NiflheimsForgeDBContext())
        {
            List<CountryDTO> countries = await db.Countries
                .Select(country => new CountryDTO
                (
                    country.Id,
                    country.Name,
                    country.Description
                ))
                .ToListAsync();

            return countries;
        }
    }

    public async Task<CountryDTO> GetCountryBy(Guid countryId)
    {
        using (NiflheimsForgeDBContext db = new NiflheimsForgeDBContext())
        {
            return await db.Countries.FirstOrDefaultAsync(country => country.Id == countryId);
        }
    }

    public async Task<bool> CreateCountry(CountryDTO countryToCreate)
    {
        using (NiflheimsForgeDBContext db = new NiflheimsForgeDBContext())
        {
            try
            {
                await db.Countries.AddAsync(countryToCreate);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public async Task<bool> UpdateCountryAsync(CountryDTO countryToUpdate)
    {
        using (NiflheimsForgeDBContext db = new NiflheimsForgeDBContext())
        {
            try
            {
                db.Countries.Update(countryToUpdate);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public async Task<bool> DeleteCountry(Guid countryId)
    {
        using (NiflheimsForgeDBContext db = new NiflheimsForgeDBContext())
        {
            try
            {
                CountryDTO countryToDelete = await GetCountryBy(countryId);
                if (countryToDelete == null)
                {
                    return false; // Country not found
                }

                db.Remove(countryToDelete);
                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
