using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraStore.Migrations
{
    public partial class UltraStoreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Notas_NotaId",
                table: "Games");

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
                name: "Country",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "NotaId",
                table: "Games",
                newName: "ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_NotaId",
                table: "Games",
                newName: "IX_Games_ReceiptId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sellers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Sellers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Sellers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Sellers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Publishers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Publishers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Publishers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ComercialEmail",
                table: "Publishers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundationDate",
                table: "Publishers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Platforms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Platforms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Generation",
                table: "Platforms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Platforms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Platforms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Notas",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Notas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsMultiplayer",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Franchises",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Franchises",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstTitleReleaseDate",
                table: "Franchises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTitleReleaseDate",
                table: "Franchises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Developers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperType",
                table: "Developers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundationDate",
                table: "Developers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Developers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Clients",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ClientId",
                table: "Notas",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Notas_ReceiptId",
                table: "Games",
                column: "ReceiptId",
                principalTable: "Notas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Clients_ClientId",
                table: "Notas",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Notas_ReceiptId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Clients_ClientId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_ClientId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "ComercialEmail",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "FoundationDate",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "Generation",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "IsMultiplayer",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Franchises");

            migrationBuilder.DropColumn(
                name: "FirstTitleReleaseDate",
                table: "Franchises");

            migrationBuilder.DropColumn(
                name: "LastTitleReleaseDate",
                table: "Franchises");

            migrationBuilder.DropColumn(
                name: "DeveloperType",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "FoundationDate",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "ReceiptId",
                table: "Games",
                newName: "NotaId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_ReceiptId",
                table: "Games",
                newName: "IX_Games_NotaId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Platforms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "ClientsId",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Franchises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ClientsId",
                table: "Notas",
                column: "ClientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Notas_NotaId",
                table: "Games",
                column: "NotaId",
                principalTable: "Notas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Clients_ClientsId",
                table: "Notas",
                column: "ClientsId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
