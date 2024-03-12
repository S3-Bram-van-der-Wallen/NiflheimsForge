using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Core.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace NiflheimsForge.Controllers;

[ApiController]
[Route("api")]
public class CountryController
{
    private readonly CountryService _countryService;

    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("countries")]
    public async Task<ActionResult<List<Country>>> GetAllCountries()
    {
        return await _countryService.GetAllCountries();
    }

    [HttpGet("countries/{countryId}")]
    public async Task<ActionResult<Country>> GetCountryBy(Guid countryId)
    {
        return await _countryService.GetCountryBy(countryId);
    }

    [HttpPost("countries")]
    public async Task<bool> CreateCountry(Country country)
    {
        return await _countryService.CreateCountry(new Country(
            country.Name,
            country.Description));
    }

    [HttpDelete("countries/{countryId}")]
    public async Task<bool> DeleteCountry(Guid countryId)
    {
        return await _countryService.DeleteCountry(countryId);
    }
}
