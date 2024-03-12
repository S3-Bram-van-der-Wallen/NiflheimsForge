using NiflheimsForge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Core.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountries();
        Task<Country> GetCountryBy(Guid countryId);
        Task<bool> CreateCountry(Country countryToCreate);
        Task<bool> DeleteCountry(Guid id);
    }
}
