using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AM.Server.Migrations
{
    public partial class units : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameFamilyMalek = table.Column<string>(type: "text", nullable: false),
                    NumberUnit = table.Column<string>(type: "text", nullable: false),
                    NumberParking = table.Column<string>(type: "text", nullable: false),
                    isResidence = table.Column<bool>(type: "boolean", nullable: false),
                    MalekIsThere = table.Column<bool>(type: "boolean", nullable: false),
                    NameFamilyMostajer = table.Column<string>(type: "text", nullable: false),
                    MobileMalek = table.Column<string>(type: "text", nullable: false),
                    MobileMostajer = table.Column<string>(type: "text", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitInfo");
        }
    }
}
