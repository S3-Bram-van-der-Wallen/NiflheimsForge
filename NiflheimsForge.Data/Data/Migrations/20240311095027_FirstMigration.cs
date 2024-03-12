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
                    { new Guid("13d87701-dc16-4f80-9a41-1aed886b0ed3"), "This is country number 1", "Country 1" },
                    { new Guid("39072d2b-1b3d-4d8e-bee4-2279f12e6667"), "This is country number 3", "Country 3" },
                    { new Guid("3a1fb89e-54cd-4a7f-b426-3a5a74709eeb"), "This is country number 5", "Country 5" },
                    { new Guid("77e1b3e4-5658-4c5b-94ed-9035f2bdd7a8"), "This is country number 6", "Country 6" },
                    { new Guid("9cc5363a-f913-4954-b5bd-b2a4b73dab64"), "This is country number 4", "Country 4" },
                    { new Guid("9db714ca-de11-4052-9604-641423353586"), "This is country number 2", "Country 2" }
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
