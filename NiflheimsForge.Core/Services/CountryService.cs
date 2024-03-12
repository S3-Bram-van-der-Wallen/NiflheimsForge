using NiflheimsForge.Core.Interfaces;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Core.Services;

public class CountryService
{
    private readonly ICountryRepository _countryRepository;

    public CountryService(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<List<Country>> GetAllCountries()
    {
        List<CountryDTO> countryDTOs = await _countryRepository.GetAllCountries();
        List<Country> countries = countryDTOs.Select(countryDTO => new Country
        {
            Id = countryDTO.Id ?? Guid.Empty,
            Name = countryDTO.Name,
            Description = countryDTO.Description
        }).ToList();

        return countries;
    }
}
