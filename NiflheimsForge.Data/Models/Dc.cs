using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Data.Models
{
    public class Dc
    {
        public DamageTypeReference DcType { get; set; }
        public int DcValue { get; set; }
        public string SuccessType { get; set; }
    }
}
