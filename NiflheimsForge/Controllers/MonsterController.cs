using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using NiflheimsForge.Data.Models;
using NiflheimsForge.Data.Repositories;
using NiflheimsForge.DTOs;

namespace NiflheimsForge.Controllers;

[ApiController]
public class MonsterController : ControllerBase
{
    private readonly MonsterRepository _monsterRepository;
    private readonly HttpClient _httpClient;
    public MonsterController(MonsterRepository monsterRepository, HttpClient httpClient)
    {
        _monsterRepository = monsterRepository;
        _httpClient = httpClient;
    }

    [HttpGet("monsters")]
    public async Task<ActionResult<IEnumerable<MonsterDTO>>> GetMonstersAsync([FromQuery] MonsterFilterDTO filter)
    {
        IEnumerable<MonsterDTO> filteredMonsters = Enumerable.Empty<MonsterDTO>();

        if (!filter.CR.HasValue)
        {
            var response = await _httpClient.GetAsync("https://www.dnd5eapi.co/api/monsters/");
            var monsterData = await response.Content.ReadFromJsonAsync<MonsterResponseDTO>();

            filteredMonsters = monsterData.Results.AsEnumerable();

            if (!string.IsNullOrEmpty(filter.MonsterName))
            {
                filteredMonsters = filteredMonsters.Where(m => m.Name.Contains(filter.MonsterName, StringComparison.OrdinalIgnoreCase));
            }
        } else
        {
            var response = await _httpClient.GetAsync($"https://www.dnd5eapi.co/api/monsters?challenge_rating={filter.CR}");
            var monsterData = await response.Content.ReadFromJsonAsync<MonsterResponseDTO>();
            filteredMonsters = monsterData.Results.AsEnumerable();
        }

        return Ok(filteredMonsters);
    }

    [HttpGet("monsters/{index}")]
    public async Task<ActionResult<Monster>> GetMonsterAsyncBy(string index)
    {
        var response = await _httpClient.GetAsync($"https://www.dnd5eapi.co/api/monsters/{index}");
        var monsterData = await response.Content.ReadFromJsonAsync<Monster>();

        return Ok(monsterData);
    }
}
