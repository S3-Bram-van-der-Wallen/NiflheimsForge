using NiflheimsForge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetCountries();
    }
}
