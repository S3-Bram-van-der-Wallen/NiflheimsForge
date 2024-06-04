using NiflheimsForge.Data.Models;

namespace NiflheimsForge.DTOs
{
    public class MonsterResponseDTO
    {
        public int Count { get; set; }
        public IEnumerable<MonsterDTO> Results { get; set; }
    }
}
