using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Core.Services;
using NiflheimsForge.Core.DTO;

namespace NiflheimsForge.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController
{
    private readonly CountryService _countryService;

    public CountryController(CountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Country>>> GetCountriesAsync()
    {
        return await _countryService.GetAllCountries();
    }
}
