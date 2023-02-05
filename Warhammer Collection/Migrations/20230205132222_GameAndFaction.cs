using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarhammerCollection.Migrations
{
    /// <inheritdoc />
    public partial class GameAndFaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "faction",
                table: "Mini",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "game",
                table: "Mini",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "faction",
                table: "Mini");

            migrationBuilder.DropColumn(
                name: "game",
                table: "Mini");
        }
    }
}
