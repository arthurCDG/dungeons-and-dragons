using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class AddWallsAndDisabledModForSquares : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsMonsterStartingSquare",
                schema: "Campaigns",
                table: "Squares",
                newName: "IsDisabled");

            migrationBuilder.RenameColumn(
                name: "IsHeroStartingSquare",
                schema: "Campaigns",
                table: "Squares",
                newName: "HasTopWall");

            migrationBuilder.AddColumn<bool>(
                name: "HasBottomWall",
                schema: "Campaigns",
                table: "Squares",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasLeftWall",
                schema: "Campaigns",
                table: "Squares",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasRightWall",
                schema: "Campaigns",
                table: "Squares",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasBottomWall",
                schema: "Campaigns",
                table: "Squares");

            migrationBuilder.DropColumn(
                name: "HasLeftWall",
                schema: "Campaigns",
                table: "Squares");

            migrationBuilder.DropColumn(
                name: "HasRightWall",
                schema: "Campaigns",
                table: "Squares");

            migrationBuilder.RenameColumn(
                name: "IsDisabled",
                schema: "Campaigns",
                table: "Squares",
                newName: "IsMonsterStartingSquare");

            migrationBuilder.RenameColumn(
                name: "HasTopWall",
                schema: "Campaigns",
                table: "Squares",
                newName: "IsHeroStartingSquare");
        }
    }
}
