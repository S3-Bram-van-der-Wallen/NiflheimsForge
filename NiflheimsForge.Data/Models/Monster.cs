using NiflheimsForge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Monster
    {
        public int Id { get; set; }

        [JsonPropertyName("index")]
        public string Index { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("size")]
        public string Size { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("alignment")]
        public string Alignment { get; set; }

        [JsonPropertyName("armor_class")]
        public List<ArmorClass> ArmorClass { get; set; }

        [JsonPropertyName("hit_points")]
        public int HitPoints { get; set; }

        [JsonPropertyName("hit_dice")]
        public string HitDice { get; set; }

        [JsonPropertyName("hit_points_roll")]
        public string HitPointsRoll { get; set; }

        [JsonPropertyName("speed")]
        public Speed Speed { get; set; }

        [JsonPropertyName("strength")]
        public int Strength { get; set; }

        [JsonPropertyName("dexterity")]
        public int Dexterity { get; set; }

        [JsonPropertyName("constitution")]
        public int Constitution { get; set; }

        [JsonPropertyName("intelligence")]
        public int Intelligence { get; set; }

        [JsonPropertyName("wisdom")]
        public int Wisdom { get; set; }

        [JsonPropertyName("charisma")]
        public int Charisma { get; set; }

        [JsonPropertyName("proficiencies")]
        public List<Proficiencies> Proficiencies { get; set; }

        [JsonPropertyName("damage_vulnerabilities")]
        public List<string> DamageVulnerabilities { get; set; }

        [JsonPropertyName("damage_resistances")]
        public List<string> DamageResistances { get; set; }

        [JsonPropertyName("damage_immunities")]
        public List<string> DamageImmunities { get; set; }

        [JsonPropertyName("condition_immunities")]
        public List<ProficiencyReference> ConditionImmunities { get; set; }

        [JsonPropertyName("senses")]
        public Senses Senses { get; set; }

        [JsonPropertyName("languages")]
        public string Languages { get; set; }

        [JsonPropertyName("challenge_rating")]
        public double ChallengeRating { get; set; }

        [JsonPropertyName("proficiency_bonus")]
        public int ProficiencyBonus { get; set; }

        [JsonPropertyName("xp")]
        public int Xp { get; set; }

        [JsonPropertyName("special_abilities")]
        public List<SpecialAbility> SpecialAbilities { get; set; }

        [JsonPropertyName("actions")]
        public List<Action> Actions { get; set; }

        [JsonPropertyName("legendary_actions")]
        public List<LegendaryAction> LegendaryActions { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
