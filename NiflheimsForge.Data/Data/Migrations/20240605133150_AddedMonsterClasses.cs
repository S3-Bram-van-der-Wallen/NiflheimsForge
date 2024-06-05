using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NiflheimsForge.Data.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMonsterClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryMonster");

            migrationBuilder.DropTable(
                name: "MonsterActions");

            migrationBuilder.RenameColumn(
                name: "Speed",
                table: "Monsters",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "ArmorClass",
                table: "Monsters",
                newName: "SpeedId");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Monsters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DamageImmunities",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DamageResistances",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DamageVulnerabilities",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HitPointsRoll",
                table: "Monsters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SensesId",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArmorClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmorClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmorClass_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DamageTypeReference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageTypeReference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProficiencyReference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProficiencyReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProficiencyReference_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Senses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Blindsight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Darkvision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassivePerception = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Walk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Swim = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Times = table.Column<int>(type: "int", nullable: false),
                    RestTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DcTypeId = table.Column<int>(type: "int", nullable: false),
                    DcValue = table.Column<int>(type: "int", nullable: false),
                    SuccessType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dc_DamageTypeReference_DcTypeId",
                        column: x => x.DcTypeId,
                        principalTable: "DamageTypeReference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proficiencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    ProficiencyId = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proficiencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proficiencies_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proficiencies_ProficiencyReference_ProficiencyId",
                        column: x => x.ProficiencyId,
                        principalTable: "ProficiencyReference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialAbility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsageId = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialAbility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialAbility_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialAbility_Usage_UsageId",
                        column: x => x.UsageId,
                        principalTable: "Usage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttackBonus = table.Column<int>(type: "int", nullable: false),
                    DcId = table.Column<int>(type: "int", nullable: false),
                    UsageId = table.Column<int>(type: "int", nullable: false),
                    MultiattackType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Action_Dc_DcId",
                        column: x => x.DcId,
                        principalTable: "Dc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Action_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Action_Usage_UsageId",
                        column: x => x.UsageId,
                        principalTable: "Usage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegendaryAction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DcId = table.Column<int>(type: "int", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegendaryAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegendaryAction_Dc_DcId",
                        column: x => x.DcId,
                        principalTable: "Dc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegendaryAction_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActionReference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionReference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionReference_Action_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Action",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Damage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DamageTypeId = table.Column<int>(type: "int", nullable: false),
                    DamageDice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: true),
                    LegendaryActionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Damage_Action_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Action",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Damage_DamageTypeReference_DamageTypeId",
                        column: x => x.DamageTypeId,
                        principalTable: "DamageTypeReference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Damage_LegendaryAction_LegendaryActionId",
                        column: x => x.LegendaryActionId,
                        principalTable: "LegendaryAction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_CountryId",
                table: "Monsters",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_SensesId",
                table: "Monsters",
                column: "SensesId");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_SpeedId",
                table: "Monsters",
                column: "SpeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_DcId",
                table: "Action",
                column: "DcId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_MonsterId",
                table: "Action",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_UsageId",
                table: "Action",
                column: "UsageId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionReference_ActionId",
                table: "ActionReference",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmorClass_MonsterId",
                table: "ArmorClass",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_ActionId",
                table: "Damage",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_DamageTypeId",
                table: "Damage",
                column: "DamageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Damage_LegendaryActionId",
                table: "Damage",
                column: "LegendaryActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Dc_DcTypeId",
                table: "Dc",
                column: "DcTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LegendaryAction_DcId",
                table: "LegendaryAction",
                column: "DcId");

            migrationBuilder.CreateIndex(
                name: "IX_LegendaryAction_MonsterId",
                table: "LegendaryAction",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Proficiencies_MonsterId",
                table: "Proficiencies",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Proficiencies_ProficiencyId",
                table: "Proficiencies",
                column: "ProficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProficiencyReference_MonsterId",
                table: "ProficiencyReference",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialAbility_MonsterId",
                table: "SpecialAbility",
                column: "MonsterId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialAbility_UsageId",
                table: "SpecialAbility",
                column: "UsageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Countries_CountryId",
                table: "Monsters",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Senses_SensesId",
                table: "Monsters",
                column: "SensesId",
                principalTable: "Senses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Speed_SpeedId",
                table: "Monsters",
                column: "SpeedId",
                principalTable: "Speed",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Countries_CountryId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Senses_SensesId",
                table: "Monsters");

            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Speed_SpeedId",
                table: "Monsters");

            migrationBuilder.DropTable(
                name: "ActionReference");

            migrationBuilder.DropTable(
                name: "ArmorClass");

            migrationBuilder.DropTable(
                name: "Damage");

            migrationBuilder.DropTable(
                name: "Proficiencies");

            migrationBuilder.DropTable(
                name: "Senses");

            migrationBuilder.DropTable(
                name: "SpecialAbility");

            migrationBuilder.DropTable(
                name: "Speed");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "LegendaryAction");

            migrationBuilder.DropTable(
                name: "ProficiencyReference");

            migrationBuilder.DropTable(
                name: "Usage");

            migrationBuilder.DropTable(
                name: "Dc");

            migrationBuilder.DropTable(
                name: "DamageTypeReference");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_CountryId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_SensesId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_SpeedId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "DamageImmunities",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "DamageResistances",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "DamageVulnerabilities",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "HitPointsRoll",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "SensesId",
                table: "Monsters");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Monsters",
                newName: "Speed");

            migrationBuilder.RenameColumn(
                name: "SpeedId",
                table: "Monsters",
                newName: "ArmorClass");

            migrationBuilder.CreateTable(
                name: "CountryMonster",
                columns: table => new
                {
                    CountriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonstersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMonster", x => new { x.CountriesId, x.MonstersId });
                    table.ForeignKey(
                        name: "FK_CountryMonster_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryMonster_Monsters_MonstersId",
                        column: x => x.MonstersId,
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonsterActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonsterId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonsterActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonsterActions_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalTable: "Monsters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryMonster_MonstersId",
                table: "CountryMonster",
                column: "MonstersId");

            migrationBuilder.CreateIndex(
                name: "IX_MonsterActions_MonsterId",
                table: "MonsterActions",
                column: "MonsterId");
        }
    }
}
