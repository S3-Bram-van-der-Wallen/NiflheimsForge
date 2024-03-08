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
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1cfa60c5-dc48-4c46-93e6-8be1900143e2"), "This is country number 5", "Country 5" },
                    { new Guid("33e3046e-83f3-4e1d-bfda-07d565f192d4"), "This is country number 6", "Country 6" },
                    { new Guid("cf47d908-2b81-4060-8b54-2adc695929fd"), "This is country number 3", "Country 3" },
                    { new Guid("e7ecf0a1-c847-43e4-bce9-48caf8cbbd66"), "This is country number 1", "Country 1" },
                    { new Guid("f78962a9-cba1-4d4b-842f-2aa75817f178"), "This is country number 2", "Country 2" },
                    { new Guid("ffeb8f52-948a-4071-bba0-eb2d2a83eea6"), "This is country number 4", "Country 4" }
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
