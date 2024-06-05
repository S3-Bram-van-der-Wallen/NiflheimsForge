using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Usage
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("times")]
        public int Times { get; set; }

        [JsonPropertyName("rest_types")]
        public List<string> RestTypes { get; set; }

        [JsonPropertyName("dice")]
        public string Dice { get; set; }

        [JsonPropertyName("min_value")]
        public int MinValue { get; set; }
    }
}
