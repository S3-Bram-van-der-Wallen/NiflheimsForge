using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Action
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int AttackBonus { get; set; }
        public List<Damage> Damage { get; set; }
        public Dc Dc { get; set; }
        public Usage Usage { get; set; }
        public List<ActionReference> Actions { get; set; }
        public string MultiattackType { get; set; }
    }
}
