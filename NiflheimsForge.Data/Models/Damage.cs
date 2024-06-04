using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Damage
    {
        public DamageTypeReference DamageType { get; set; }
        public string DamageDice { get; set; }
    }
}
