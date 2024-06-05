using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Speed
    {
        public int Id { get; set; }

        [JsonPropertyName("walk")]
        public string Walk { get; set; }

        [JsonPropertyName("fly")]
        public string Fly { get; set; }

        [JsonPropertyName("swim")]
        public string Swim { get; set; }
    }
}
