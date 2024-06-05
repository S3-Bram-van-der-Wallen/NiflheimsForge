using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class LegendaryAction
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("dc")]
        public Dc Dc { get; set; }

        [JsonPropertyName("damage")]
        public List<Damage> Damage { get; set; }
    }
}
