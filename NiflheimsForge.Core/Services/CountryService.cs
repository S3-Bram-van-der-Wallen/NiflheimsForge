using NiflheimsForge.Core.Interfaces;
using NiflheimsForge.Core.Models;
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
        List<Country> countryDTOs = await _countryRepository.GetAllCountries();
        return countryDTOs.Select(countryDTO => new Country
        (
            countryDTO.Id ?? Guid.Empty,
            countryDTO.Name,
            countryDTO.Description
        )).ToList();
    }

    public async Task<Country> GetCountryBy(Guid countryId)
    {
        Country countryDTO = await _countryRepository.GetCountryBy(countryId);
        return new Country(
            countryDTO.Name,
            countryDTO.Description
            );
    }

    public async Task<bool> CreateCountry(Country countryToCreate)
    {
        return await _countryRepository.CreateCountry(new Country(
            countryToCreate.Name,
            countryToCreate.Description));
    }

    public async Task<bool> DeleteCountry(Guid id)
    {
        return await _countryRepository.DeleteCountry(id);
    }
}
