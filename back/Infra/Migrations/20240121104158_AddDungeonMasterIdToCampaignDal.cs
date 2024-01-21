using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations;

public partial class AddDungeonMasterIdToCampaignDal : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            name: "DungeonMasterId",
            schema: "Campaigns",
            table: "Campaigns",
            type: "int",
            nullable: true);

        migrationBuilder.CreateIndex(
            name: "IX_Campaigns_DungeonMasterId",
            schema: "Campaigns",
            table: "Campaigns",
            column: "DungeonMasterId");

        migrationBuilder.AddForeignKey(
            name: "FK_Campaigns_Users_DungeonMasterId",
            schema: "Campaigns",
            table: "Campaigns",
            column: "DungeonMasterId",
            principalSchema: "Users",
            principalTable: "Users",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }
}
