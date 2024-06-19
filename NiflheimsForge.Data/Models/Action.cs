using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Action
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("attack_bonus")]
        public int AttackBonus { get; set; }

        [JsonPropertyName("damage")]
        public List<Damage> Damage { get; set; }

        [JsonPropertyName("dc")]
        public Dc Dc { get; set; }

        [JsonPropertyName("usage")]
        public Usage Usage { get; set; }

        [JsonPropertyName("actions")]
        public List<ActionReference> Actions { get; set; }

        [JsonPropertyName("multiattack_type")]
        public string MultiattackType { get; set; }
    }
}
