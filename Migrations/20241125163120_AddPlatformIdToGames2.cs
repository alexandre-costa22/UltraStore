using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltraStore.Migrations
{
    public partial class AddPlatformIdToGames2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Platforms_PlatformsId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "PlatformsId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Platforms_PlatformsId",
                table: "Games",
                column: "PlatformsId",
                principalTable: "Platforms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Platforms_PlatformsId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "PlatformsId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PlatformId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Platforms_PlatformsId",
                table: "Games",
                column: "PlatformsId",
                principalTable: "Platforms",
                principalColumn: "Id");
        }
    }
}
