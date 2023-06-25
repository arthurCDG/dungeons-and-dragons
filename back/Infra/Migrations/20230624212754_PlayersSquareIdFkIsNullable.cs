using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class PlayersSquareIdFkIsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_SquareId",
                schema: "Players",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "SquareId",
                schema: "Players",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Players_SquareId",
                schema: "Players",
                table: "Players",
                column: "SquareId",
                unique: true,
                filter: "[SquareId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_SquareId",
                schema: "Players",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "SquareId",
                schema: "Players",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_SquareId",
                schema: "Players",
                table: "Players",
                column: "SquareId",
                unique: true);
        }
    }
}
