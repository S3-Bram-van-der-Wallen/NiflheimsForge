using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NiflheimsForge.Data.Data.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1e735a52-dc10-4ccb-b390-7cd791111a82"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6d63fc05-f890-43de-98ea-3ca6104cf006"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9401773d-f874-4de0-a88d-296afc7c77aa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("dd0a2bda-6ad7-411c-b988-228006ce992d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("efbf6d9c-f001-4844-8b60-8b2e64ba19ee"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f9f21a1d-dffa-49ba-9f45-8655c6ed19f1"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("36d91f89-38cb-490b-9452-1237f5ad3ba0"), "This is country number 4", "Country 4" },
                    { new Guid("4fb9cc4e-cb7d-423b-aea3-da5624b0f1dc"), "This is country number 5", "Country 5" },
                    { new Guid("a74fa8b8-513e-4846-a820-0f7a36134a50"), "This is country number 6", "Country 6" },
                    { new Guid("b8a07c44-988d-4f43-919e-d35711bbb9e4"), "This is country number 1", "Country 1" },
                    { new Guid("d96131a0-c431-4e36-9e51-0e99f04f6116"), "This is country number 3", "Country 3" },
                    { new Guid("f7f3dd96-2482-4f52-9a8c-44f23059289d"), "This is country number 2", "Country 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("36d91f89-38cb-490b-9452-1237f5ad3ba0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4fb9cc4e-cb7d-423b-aea3-da5624b0f1dc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a74fa8b8-513e-4846-a820-0f7a36134a50"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b8a07c44-988d-4f43-919e-d35711bbb9e4"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d96131a0-c431-4e36-9e51-0e99f04f6116"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f7f3dd96-2482-4f52-9a8c-44f23059289d"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1e735a52-dc10-4ccb-b390-7cd791111a82"), "This is country number 1", "Country 1" },
                    { new Guid("6d63fc05-f890-43de-98ea-3ca6104cf006"), "This is country number 3", "Country 3" },
                    { new Guid("9401773d-f874-4de0-a88d-296afc7c77aa"), "This is country number 5", "Country 5" },
                    { new Guid("dd0a2bda-6ad7-411c-b988-228006ce992d"), "This is country number 6", "Country 6" },
                    { new Guid("efbf6d9c-f001-4844-8b60-8b2e64ba19ee"), "This is country number 2", "Country 2" },
                    { new Guid("f9f21a1d-dffa-49ba-9f45-8655c6ed19f1"), "This is country number 4", "Country 4" }
                });
        }
    }
}
