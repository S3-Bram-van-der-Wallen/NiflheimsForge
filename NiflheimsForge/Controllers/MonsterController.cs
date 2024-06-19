using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NiflheimsForge.Data.Models;
using NiflheimsForge.Data.Repositories;
using NiflheimsForge.DTOs;
using System.Net.Http.Json;

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
        }
        else
        {
            filteredMonsters = await GetMonstersByCR(filter.CR.Value);
        }

        filteredMonsters = SortMonsters(filteredMonsters, filter.SortOrder);

        return Ok(filteredMonsters);
    }

    private async Task<IEnumerable<MonsterDTO>> GetMonstersByCR(int cr)
    {
        var response = await _httpClient.GetAsync($"https://www.dnd5eapi.co/api/monsters?challenge_rating={cr}");
        var monsterData = await response.Content.ReadFromJsonAsync<MonsterResponseDTO>();
        return monsterData.Results.AsEnumerable();
    }

    private IEnumerable<MonsterDTO> SortMonsters(IEnumerable<MonsterDTO> monsters, string sortDirection)
    {
        if (sortDirection.Equals("asc", StringComparison.OrdinalIgnoreCase))
        {
            monsters = monsters.OrderBy(m => m.Name);
        }
        else 
        {
            monsters = monsters.OrderByDescending(m => m.Name);
        }

        return monsters;
    }

    [HttpGet("monsters/{index}")]
    public async Task<ActionResult<Monster>> GetMonsterAsyncBy(string index)
    {
        var response = await _httpClient.GetAsync($"https://www.dnd5eapi.co/api/monsters/{index}");
        var monsterData = await response.Content.ReadFromJsonAsync<Monster>();

        return Ok(monsterData);
    }
}
