using NiflheimsForge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string Index { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Alignment { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public string HitDice { get; set; }
        public string Speed { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public string Languages { get; set; }
        public double ChallengeRating { get; set; }
        public int ProficiencyBonus { get; set; }
        public int Xp { get; set; }
        public string Image { get; set; }
        public List<Country> Countries { get; } = [];
        public List<MonsterAction> MonsterActions { get; } = [];
    }
}
