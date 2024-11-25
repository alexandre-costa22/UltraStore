using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraStore.Migrations
{
    public partial class AddPlatformIdToGames5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundedYear",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Developers",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Developers",
                newName: "Location");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundedYear",
                table: "Developers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
