﻿using NiflheimsForge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Monster
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Alignment { get; set; }
        public List<ArmorClass> ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string HitDice { get; set; }
        public string HitPointsRoll { get; set; }
        public Speed Speed { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public List<Proficiencies> Proficiencies { get; set; }
        public List<string> DamageVulnerabilities { get; set; }
        public List<string> DamageResistances { get; set; }
        public List<string> DamageImmunities { get; set; }
        public List<string> ConditionImmunities { get; set; }
        public Senses Senses { get; set; }
        public string Languages { get; set; }
        public int ChallengeRating { get; set; }
        public int ProficiencyBonus { get; set; }
        public int Xp { get; set; }
        public List<SpecialAbility> SpecialAbilities { get; set; }
        public List<Action> Actions { get; set; }
        public List<LegendaryAction> LegendaryActions { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
    }
}
