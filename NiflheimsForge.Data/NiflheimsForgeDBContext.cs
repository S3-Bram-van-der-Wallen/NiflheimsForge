using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Data.Models;
using System;

namespace NiflheimsForge.Data;

public class NiflheimsForgeDBContext : DbContext
{
    public DbSet<Models.Action> Actions { get; set; }
    public DbSet<ActionReference> ActionsReferences { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Damage> Damages { get; set; }
    public DbSet<DamageTypeReference> DamageTypeReferences { get; set; }
    public DbSet<Dc> Dcs { get; set; }
    public DbSet<LegendaryAction> legendaryActions { get; set; }
    public DbSet<Monster> Monsters { get; set; }
    public DbSet<Proficiencies> Proficiencies { get; set; }
    public DbSet<ProficiencyReference> ProficiencyReferences { get; set; }
    public DbSet<Senses> Senses { get; set; }
    public DbSet<SpecialAbility> SpecialAbilities { get; set; }
    public DbSet<Speed> Speeds { get; set; }
    public DbSet<Usage> Usages { get; set; }


    private readonly IConfiguration _configuration;

    public NiflheimsForgeDBContext(DbContextOptions<NiflheimsForgeDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>()
            .HasOne(c => c.Country)
            .WithMany(c => c.Cities)
            .HasForeignKey(c => c.CountryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


    base.OnModelCreating(modelBuilder);
    }
}