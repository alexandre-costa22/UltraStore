using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraStore.Migrations
{
    public partial class ConfigureGamePlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developer_Franchise_FranchiseId",
                table: "Developer");

            migrationBuilder.DropForeignKey(
                name: "FK_Developer_Publisher_PublisherId",
                table: "Developer");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Developer_DeveloperId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Franchise_FranchiseId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Nota_NotaId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Publisher_PublisherId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Client_ClienteId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_Nota_Seller_VendedorId",
                table: "Nota");

            migrationBuilder.DropForeignKey(
                name: "FK_Publisher_Franchise_FranchiseId",
                table: "Publisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seller",
                table: "Seller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Publisher_FranchiseId",
                table: "Publisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nota",
                table: "Nota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Franchise",
                table: "Franchise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Developer",
                table: "Developer");

            migrationBuilder.DropIndex(
                name: "IX_Developer_FranchiseId",
                table: "Developer");

            migrationBuilder.DropIndex(
                name: "IX_Developer_PublisherId",
                table: "Developer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Client",
                table: "Client");

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
                name: "BirthDate",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "FoundationDate",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "ValorVenda",
                table: "Nota");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Franchise",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "FirstTitleLaunch",
                table: "Franchise");

            migrationBuilder.DropColumn(
                name: "FoundationDate",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "FranchiseId",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Developer");

            migrationBuilder.DropColumn(
                name: "AmoutSpent",
                table: "Client");

            migrationBuilder.RenameTable(
                name: "Seller",
                newName: "Sellers");

            migrationBuilder.RenameTable(
                name: "Publisher",
                newName: "Publishers");

            migrationBuilder.RenameTable(
                name: "Nota",
                newName: "Notas");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameTable(
                name: "Franchise",
                newName: "Franchises");

            migrationBuilder.RenameTable(
                name: "Developer",
                newName: "Developers");

            migrationBuilder.RenameTable(
                name: "Client",
                newName: "Clients");

            migrationBuilder.RenameColumn(
                name: "VendedorId",
                table: "Notas",
                newName: "SellerId");

            migrationBuilder.RenameColumn(
                name: "DataEmissao",
                table: "Notas",
                newName: "PurchaseDate");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Notas",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Nota_VendedorId",
                table: "Notas",
                newName: "IX_Notas_SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Nota_ClienteId",
                table: "Notas",
                newName: "IX_Notas_ClientId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Games",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_Game_PublisherId",
                table: "Games",
                newName: "IX_Games_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_NotaId",
                table: "Games",
                newName: "IX_Games_NotaId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_FranchiseId",
                table: "Games",
                newName: "IX_Games_FranchiseId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_DeveloperId",
                table: "Games",
                newName: "IX_Games_DeveloperId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sellers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Notas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Games",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "FranchiseId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Franchises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notas",
                table: "Notas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Franchises",
                table: "Franchises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Developers",
                table: "Developers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GamePlatform",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatform", x => new { x.GameId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_GamePlatform_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlatform_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlatform_PlatformId",
                table: "GamePlatform",
                column: "PlatformId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Franchises_FranchiseId",
                table: "Games",
                column: "FranchiseId",
                principalTable: "Franchises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Notas_NotaId",
                table: "Games",
                column: "NotaId",
                principalTable: "Notas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Publishers_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Clients_ClientId",
                table: "Notas",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Sellers_SellerId",
                table: "Notas",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Franchises_FranchiseId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Notas_NotaId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Publishers_PublisherId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Clients_ClientId",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Sellers_SellerId",
                table: "Notas");

            migrationBuilder.DropTable(
                name: "GamePlatform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Publishers",
                table: "Publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notas",
                table: "Notas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Franchises",
                table: "Franchises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Developers",
                table: "Developers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Clients");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "Seller");

            migrationBuilder.RenameTable(
                name: "Publishers",
                newName: "Publisher");

            migrationBuilder.RenameTable(
                name: "Notas",
                newName: "Nota");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameTable(
                name: "Franchises",
                newName: "Franchise");

            migrationBuilder.RenameTable(
                name: "Developers",
                newName: "Developer");

            migrationBuilder.RenameTable(
                name: "Clients",
                newName: "Client");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Nota",
                newName: "VendedorId");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "Nota",
                newName: "DataEmissao");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Nota",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_SellerId",
                table: "Nota",
                newName: "IX_Nota_VendedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_ClientId",
                table: "Nota",
                newName: "IX_Nota_ClienteId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Game",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PublisherId",
                table: "Game",
                newName: "IX_Game_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_NotaId",
                table: "Game",
                newName: "IX_Game_NotaId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_FranchiseId",
                table: "Game",
                newName: "IX_Game_FranchiseId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_DeveloperId",
                table: "Game",
                newName: "IX_Game_DeveloperId");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Seller",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Seller",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Publisher",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundationDate",
                table: "Publisher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FranchiseId",
                table: "Publisher",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ValorVenda",
                table: "Nota",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Game",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "FranchiseId",
                table: "Game",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Game",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Franchise",
                table: "Game",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Franchise",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "FirstTitleLaunch",
                table: "Franchise",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Developer",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "FoundationDate",
                table: "Developer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FranchiseId",
                table: "Developer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Developer",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Client",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "AmoutSpent",
                table: "Client",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seller",
                table: "Seller",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Publisher",
                table: "Publisher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nota",
                table: "Nota",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Franchise",
                table: "Franchise",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Developer",
                table: "Developer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Client",
                table: "Client",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_FranchiseId",
                table: "Publisher",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Developer_FranchiseId",
                table: "Developer",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Developer_PublisherId",
                table: "Developer",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developer_Franchise_FranchiseId",
                table: "Developer",
                column: "FranchiseId",
                principalTable: "Franchise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Developer_Publisher_PublisherId",
                table: "Developer",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Developer_DeveloperId",
                table: "Game",
                column: "DeveloperId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Franchise_FranchiseId",
                table: "Game",
                column: "FranchiseId",
                principalTable: "Franchise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Nota_NotaId",
                table: "Game",
                column: "NotaId",
                principalTable: "Nota",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Publisher_PublisherId",
                table: "Game",
                column: "PublisherId",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Client_ClienteId",
                table: "Nota",
                column: "ClienteId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nota_Seller_VendedorId",
                table: "Nota",
                column: "VendedorId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publisher_Franchise_FranchiseId",
                table: "Publisher",
                column: "FranchiseId",
                principalTable: "Franchise",
                principalColumn: "Id");
        }
    }
}
