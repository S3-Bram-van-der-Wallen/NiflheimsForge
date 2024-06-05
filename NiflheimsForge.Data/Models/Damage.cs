using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Damage
    {
        [JsonPropertyName("damage_type")]
        public DamageTypeReference DamageType { get; set; }

        [JsonPropertyName("damage_dice")]
        public string DamageDice { get; set; }
    }
}
