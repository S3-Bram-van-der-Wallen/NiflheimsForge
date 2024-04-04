using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Core.DTOs
{
    public class CreateCountryDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public CreateCountryDTO(string name, string description) 
        {
            Name = name;
            Description = description;
        }
    }
}
