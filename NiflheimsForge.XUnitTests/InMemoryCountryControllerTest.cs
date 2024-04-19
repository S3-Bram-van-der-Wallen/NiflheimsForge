using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Data;

namespace NiflheimsForge.XUnitTests
{
    public class InMemoryCountryControllerTest
    {
        private readonly DbContextOptions<NiflheimsForgeDBContext> _contextOptions;

        public InMemoryCountryControllerTest()
        {
            _contextOptions = new DbContextOptionsBuilder<NiflheimsForgeDBContext>()
                .UseInMemoryDatabase("CountryControllerTest")
                .ConfigureWarnings(c => c.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            using var context = new NiflheimsForgeDBContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(
                new Country { Id = Guid.NewGuid(), Name = "Country1", Description = "This is Country1" },
                new Country { Id = Guid.NewGuid(), Name = "Country1", Description = "This is Country1" });

            context.SaveChanges();
        }
    }
}
