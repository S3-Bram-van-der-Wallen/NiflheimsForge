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

namespace NiflheimsForge.Data;

public class NiflheimsForgeDBContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    private readonly string _connectionString;

    public NiflheimsForgeDBContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlServer(_connectionString);

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
