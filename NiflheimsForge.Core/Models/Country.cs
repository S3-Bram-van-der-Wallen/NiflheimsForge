using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiflheimsForge.Core.Models;

public class Country
{
    [Key]
    public Guid? Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100000)]
    public string Description { get; set; } = string.Empty;
}
