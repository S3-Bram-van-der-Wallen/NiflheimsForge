using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiflheimsForge.Core.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NiflheimsForge.Data;

public class NiflheimsForgeDBContext : DbContext
{
    public DbSet<Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer("Server=tcp:niflheims-forge-server.database.windows.net,1433;Initial Catalog=NiflheimsForgeDB;Persist Security Info=False;User ID=NiflheimsForgeAdmin;Password=Kv4&9^UMXptXpW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Country[] countriesToSeed = new Country[6];

        for (int i = 1; i <= 6; i++)
        {
            countriesToSeed[i - 1] = new Country
            {
                Id = Guid.NewGuid(),
                Name = $"Country {i}",
                Description = $"This is country number {i}"
            };
        }
        modelBuilder.Entity<Country>().HasData(countriesToSeed);
    }
}
