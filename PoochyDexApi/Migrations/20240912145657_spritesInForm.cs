using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoochyDexApi.Migrations
{
    /// <inheritdoc />
    public partial class spritesInForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Pokemon_PokemonId",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "HomeUrlSpritre",
                table: "HomeSprites",
                newName: "HomeUrlSprite");

            migrationBuilder.RenameColumn(
                name: "HomeUrlShinySpritre",
                table: "HomeSprites",
                newName: "HomeUrlShinySprite");

            migrationBuilder.AddColumn<int>(
                name: "HomeSpriteId",
                table: "FormData",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FormData_HomeSpriteId",
                table: "FormData",
                column: "HomeSpriteId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormData_HomeSprites_HomeSpriteId",
                table: "FormData",
                column: "HomeSpriteId",
                principalTable: "HomeSprites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Pokemon_PokemonId",
                table: "Forms",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormData_HomeSprites_HomeSpriteId",
                table: "FormData");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Pokemon_PokemonId",
                table: "Forms");

            migrationBuilder.DropIndex(
                name: "IX_FormData_HomeSpriteId",
                table: "FormData");

            migrationBuilder.DropColumn(
                name: "HomeSpriteId",
                table: "FormData");

            migrationBuilder.RenameColumn(
                name: "HomeUrlSprite",
                table: "HomeSprites",
                newName: "HomeUrlSpritre");

            migrationBuilder.RenameColumn(
                name: "HomeUrlShinySprite",
                table: "HomeSprites",
                newName: "HomeUrlShinySpritre");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Pokemon_PokemonId",
                table: "Forms",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
