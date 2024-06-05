using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Proficiencies
    {
        public int Id { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }

        [JsonPropertyName("proficiency")]
        public ProficiencyReference Proficiency { get; set; }
    }
}
