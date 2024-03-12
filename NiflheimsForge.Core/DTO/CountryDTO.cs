using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Core.DTO;

public class CountryDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public CountryDTO(Guid? id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public CountryDTO(string name, string description) : this(null, name, description)
    {
    }
}
