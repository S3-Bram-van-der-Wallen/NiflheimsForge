using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class LegendaryAction
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public Dc Dc { get; set; }
        public List<Damage> Damage { get; set; }
    }
}
