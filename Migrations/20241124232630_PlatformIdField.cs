using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraStore.Migrations
{
    public partial class PlatformIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Clients_ClientId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_ClientId",
                table: "Notas");

            migrationBuilder.AddColumn<int>(
                name: "ClientsId",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Platform",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ClientsId",
                table: "Notas",
                column: "ClientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Clients_ClientsId",
                table: "Notas",
                column: "ClientsId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Clients_ClientsId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_ClientsId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "ClientsId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ClientId",
                table: "Notas",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Clients_ClientId",
                table: "Notas",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
