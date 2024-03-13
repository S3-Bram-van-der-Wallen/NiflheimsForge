using Microsoft.EntityFrameworkCore;
using NiflheimsForge.Core.Models;

namespace NiflheimsForge.Data;

public class NiflheimsForgeDBContext : DbContext
{
    public DbSet<Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=NiflheimsForge;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
    }
}
