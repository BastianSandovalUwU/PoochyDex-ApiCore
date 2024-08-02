using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoochyDexApi.Migrations
{
    /// <inheritdoc />
    public partial class migracion6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Generation_GenerationId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_GenerationId",
                table: "Games");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Games_GenerationId",
                table: "Games",
                column: "GenerationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Generation_GenerationId",
                table: "Games",
                column: "GenerationId",
                principalTable: "Generation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
