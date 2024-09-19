using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoochyDexApi.Migrations
{
    /// <inheritdoc />
    public partial class AddHomeSpritesPokemonRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PokemonId",
                table: "HomeSprites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeSprites_PokemonId",
                table: "HomeSprites",
                column: "PokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_HomeSprites_Pokemon_PokemonId",
                table: "HomeSprites",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HomeSprites_Pokemon_PokemonId",
                table: "HomeSprites");

            migrationBuilder.DropIndex(
                name: "IX_HomeSprites_PokemonId",
                table: "HomeSprites");

            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "HomeSprites");
        }
    }
}
