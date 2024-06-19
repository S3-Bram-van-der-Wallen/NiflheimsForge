using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NiflheimsForge.Core.Models;
using NiflheimsForge.Data;
using NiflheimsForge.Data.Repositories;

namespace NiflheimsForge.XUnitTests
{
    public class InMemoryCountryControllerTest
    {
        private NiflheimsForgeDBContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<NiflheimsForgeDBContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            return new NiflheimsForgeDBContext(options);
        }

        [Fact]
        public async Task GetAllCountries()
        {
            using (var context = CreateInMemoryContext())
            {
                context.AddRange(
                    new Country { Id = Guid.NewGuid(), Name = "Country1", Description = "This is Country1" },
                    new Country { Id = Guid.NewGuid(), Name = "Country2", Description = "This is Country2" });

                context.SaveChanges();
            }

            var countryRepository = new CountryRepository(CreateInMemoryContext());

            var countries = await countryRepository.GetCountries();

            Assert.Equal(2, countries.Count());
        }
    }
}
