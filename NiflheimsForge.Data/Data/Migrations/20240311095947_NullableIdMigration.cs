using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NiflheimsForge.Data.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullableIdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("13d87701-dc16-4f80-9a41-1aed886b0ed3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("39072d2b-1b3d-4d8e-bee4-2279f12e6667"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3a1fb89e-54cd-4a7f-b426-3a5a74709eeb"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("77e1b3e4-5658-4c5b-94ed-9035f2bdd7a8"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9cc5363a-f913-4954-b5bd-b2a4b73dab64"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9db714ca-de11-4052-9604-641423353586"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("13d87701-dc16-4f80-9a41-1aed886b0ed3"), "This is country number 1", "Country 1" },
                    { new Guid("39072d2b-1b3d-4d8e-bee4-2279f12e6667"), "This is country number 3", "Country 3" },
                    { new Guid("3a1fb89e-54cd-4a7f-b426-3a5a74709eeb"), "This is country number 5", "Country 5" },
                    { new Guid("77e1b3e4-5658-4c5b-94ed-9035f2bdd7a8"), "This is country number 6", "Country 6" },
                    { new Guid("9cc5363a-f913-4954-b5bd-b2a4b73dab64"), "This is country number 4", "Country 4" },
                    { new Guid("9db714ca-de11-4052-9604-641423353586"), "This is country number 2", "Country 2" }
                });
        }
    }
}
