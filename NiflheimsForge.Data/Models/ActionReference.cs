using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{

    public class ActionReference
    {
        public int Id { get; set; }
        [JsonPropertyName("action_name")]
        public string ActionName { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
