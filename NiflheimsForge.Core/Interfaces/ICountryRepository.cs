using NiflheimsForge.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Core.Interfaces
{
    public interface ICountryRepository
    {
        Task<List<CountryDTO>> GetAllCountries();
    }
}
