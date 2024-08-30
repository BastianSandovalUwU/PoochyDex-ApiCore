using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoochyDexApi.Migrations
{
    /// <inheritdoc />
    public partial class Ajustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Generation_GenerationId",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "Generation",
                table: "VideoGames");

            migrationBuilder.RenameColumn(
                name: "GenerationId",
                table: "VideoGames",
                newName: "generationId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoGames_GenerationId",
                table: "VideoGames",
                newName: "IX_VideoGames_generationId");

            migrationBuilder.AlterColumn<int>(
                name: "generationId",
                table: "VideoGames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Pokemon",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_generationId",
                table: "Pokemon",
                column: "generationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pokemon_Generation_generationId",
                table: "Pokemon",
                column: "generationId",
                principalTable: "Generation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Generation_generationId",
                table: "VideoGames",
                column: "generationId",
                principalTable: "Generation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pokemon_Generation_generationId",
                table: "Pokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Generation_generationId",
                table: "VideoGames");

            migrationBuilder.DropIndex(
                name: "IX_Pokemon_generationId",
                table: "Pokemon");

            migrationBuilder.RenameColumn(
                name: "generationId",
                table: "VideoGames",
                newName: "GenerationId");

            migrationBuilder.RenameIndex(
                name: "IX_VideoGames_generationId",
                table: "VideoGames",
                newName: "IX_VideoGames_GenerationId");

            migrationBuilder.AlterColumn<int>(
                name: "GenerationId",
                table: "VideoGames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Generation",
                table: "VideoGames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageURL",
                table: "Pokemon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Generation_GenerationId",
                table: "VideoGames",
                column: "GenerationId",
                principalTable: "Generation",
                principalColumn: "Id");
        }
    }
}
