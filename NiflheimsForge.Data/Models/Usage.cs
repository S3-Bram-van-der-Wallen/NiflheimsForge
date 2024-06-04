using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Usage
    {
        public string Type { get; set; }
        public int Times { get; set; }
        public List<string> RestTypes { get; set; }
        public string Dice { get; set; }
        public int MinValue { get; set; }
    }
}
