﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NiflheimsForge.Core.Models;
using System;

namespace NiflheimsForge.Data
{
    public class NiflheimsForgeDBContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        private readonly IConfiguration _configuration;

        public NiflheimsForgeDBContext(DbContextOptions<NiflheimsForgeDBContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
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
}
