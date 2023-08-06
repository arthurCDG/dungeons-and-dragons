using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class AddChestsToSquares : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasLockedChest",
                schema: "Campaigns",
                table: "Squares",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasOpenedChest",
                schema: "Campaigns",
                table: "Squares",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPillar",
                schema: "Campaigns",
                table: "Squares",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasLockedChest",
                schema: "Campaigns",
                table: "Squares");

            migrationBuilder.DropColumn(
                name: "HasOpenedChest",
                schema: "Campaigns",
                table: "Squares");

            migrationBuilder.DropColumn(
                name: "HasPillar",
                schema: "Campaigns",
                table: "Squares");
        }
    }
}
