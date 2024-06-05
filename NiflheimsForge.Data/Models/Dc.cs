using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Dc
    {
        public int Id { get; set; }
        [JsonPropertyName("dc_type")]
        public DamageTypeReference DcType { get; set; }

        [JsonPropertyName("dc_value")]
        public int DcValue { get; set; }

        [JsonPropertyName("success_type")]
        public string SuccessType { get; set; }
    }
}
