using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NiflheimsForge.Data.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("451a6442-8251-4390-8cbf-e983dea9dbff"), "This is country number 1", "Country 1" },
                    { new Guid("51ddd4bc-8ee1-41e2-a067-8f285cebb291"), "This is country number 6", "Country 6" },
                    { new Guid("7da807f5-8dfa-4ed2-88ff-b5342496a60d"), "This is country number 4", "Country 4" },
                    { new Guid("964dbef7-5792-481d-8c52-73f5426230a5"), "This is country number 2", "Country 2" },
                    { new Guid("a2985416-d868-4c48-a5c3-5260d859295f"), "This is country number 3", "Country 3" },
                    { new Guid("a8a94071-ea2d-4efc-98af-04458fd15e86"), "This is country number 5", "Country 5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
