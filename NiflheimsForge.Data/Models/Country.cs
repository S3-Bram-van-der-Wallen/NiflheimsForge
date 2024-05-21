using NiflheimsForge.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace NiflheimsForge.Core.Models;

public class Country
{
    public Guid? Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100000)]
    public string Description { get; set; } = string.Empty;

    public ICollection<City> Cities { get; } = new List<City>();
    public List<Monster> Monsters { get; } = [];
}
