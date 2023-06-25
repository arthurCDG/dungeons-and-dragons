using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTurnOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdventureId",
                schema: "GameFlow",
                table: "TurnOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TurnOrders_AdventureId",
                schema: "GameFlow",
                table: "TurnOrders",
                column: "AdventureId");

            migrationBuilder.AddForeignKey(
                name: "FK_TurnOrders_Adventures_AdventureId",
                schema: "GameFlow",
                table: "TurnOrders",
                column: "AdventureId",
                principalSchema: "Campaigns",
                principalTable: "Adventures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TurnOrders_Adventures_AdventureId",
                schema: "GameFlow",
                table: "TurnOrders");

            migrationBuilder.DropIndex(
                name: "IX_TurnOrders_AdventureId",
                schema: "GameFlow",
                table: "TurnOrders");

            migrationBuilder.DropColumn(
                name: "AdventureId",
                schema: "GameFlow",
                table: "TurnOrders");
        }
    }
}
