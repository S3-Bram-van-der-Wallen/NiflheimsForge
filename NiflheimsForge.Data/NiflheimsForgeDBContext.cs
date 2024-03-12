using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NiflheimsForge.Core.Models;
using System;

namespace NiflheimsForge.Data;

public class NiflheimsForgeDBContext : DbContext
{
    public DbSet<Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=NiflheimsForge;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        Country[] countriesToSeed = new Country[6];

        for (int i = 1; i <= 6; i++)
        {
            countriesToSeed[i - 1] = new Country
            (
                Guid.NewGuid(),
                $"Country {i}",
                $"This is country number {i}"
            );
        }
        modelBuilder.Entity<Country>().HasData(countriesToSeed);
    }
}
