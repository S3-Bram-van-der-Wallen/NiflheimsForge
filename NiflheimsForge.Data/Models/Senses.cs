using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Senses
    {
        public int Id { get; set; }

        [JsonPropertyName("blindsight")]
        public string Blindsight { get; set; }

        [JsonPropertyName("darkvision")]
        public string Darkvision { get; set; }

        [JsonPropertyName("passive_perception")]
        public int PassivePerception { get; set; }
    }
}
