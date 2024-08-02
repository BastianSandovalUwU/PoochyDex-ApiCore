using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoochyDexApi.Migrations
{
    /// <inheritdoc />
    public partial class migracion5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Generation_GenerationId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "GenerationId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Generation_GenerationId",
                table: "Games",
                column: "GenerationId",
                principalTable: "Generation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Generation_GenerationId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "GenerationId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Generation_GenerationId",
                table: "Games",
                column: "GenerationId",
                principalTable: "Generation",
                principalColumn: "Id");
        }
    }
}
