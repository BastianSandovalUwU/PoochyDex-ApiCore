using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoochyDexApi.Migrations
{
    /// <inheritdoc />
    public partial class inicial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Pokemon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type2",
                table: "Pokemon",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Pokemon");

            migrationBuilder.DropColumn(
                name: "Type2",
                table: "Pokemon");
        }
    }
}
