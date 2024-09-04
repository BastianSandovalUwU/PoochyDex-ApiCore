using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoochyDexApi.Migrations
{
    /// <inheritdoc />
    public partial class releaseDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReleaseDate_VideoGames_VideoGamesId",
                table: "ReleaseDate");

            migrationBuilder.DropIndex(
                name: "IX_ReleaseDate_VideoGamesId",
                table: "ReleaseDate");

            migrationBuilder.DropColumn(
                name: "VideoGamesId",
                table: "ReleaseDate");

            migrationBuilder.AddColumn<int>(
                name: "VideoGameId",
                table: "ReleaseDate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDate_VideoGameId",
                table: "ReleaseDate",
                column: "VideoGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReleaseDate_VideoGames_VideoGameId",
                table: "ReleaseDate",
                column: "VideoGameId",
                principalTable: "VideoGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReleaseDate_VideoGames_VideoGameId",
                table: "ReleaseDate");

            migrationBuilder.DropIndex(
                name: "IX_ReleaseDate_VideoGameId",
                table: "ReleaseDate");

            migrationBuilder.DropColumn(
                name: "VideoGameId",
                table: "ReleaseDate");

            migrationBuilder.AddColumn<int>(
                name: "VideoGamesId",
                table: "ReleaseDate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseDate_VideoGamesId",
                table: "ReleaseDate",
                column: "VideoGamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReleaseDate_VideoGames_VideoGamesId",
                table: "ReleaseDate",
                column: "VideoGamesId",
                principalTable: "VideoGames",
                principalColumn: "Id");
        }
    }
}
