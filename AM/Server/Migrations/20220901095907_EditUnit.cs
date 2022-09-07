using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Server.Migrations
{
    public partial class EditUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Device",
                table: "UnitInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "UnitInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "UnitInfo",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UnitInfo",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Device",
                table: "UnitInfo");

            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "UnitInfo");

            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "UnitInfo");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "UnitInfo");
        }
    }
}
