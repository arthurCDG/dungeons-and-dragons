using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCampaignPlayerRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignDalPlayerDal");

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                schema: "Players",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_CampaignId",
                schema: "Players",
                table: "Players",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Campaigns_CampaignId",
                schema: "Players",
                table: "Players",
                column: "CampaignId",
                principalSchema: "Campaigns",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Campaigns_CampaignId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_CampaignId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                schema: "Players",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "CampaignDalPlayerDal",
                columns: table => new
                {
                    CampaignsId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignDalPlayerDal", x => new { x.CampaignsId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_CampaignDalPlayerDal_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalSchema: "Campaigns",
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignDalPlayerDal_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalSchema: "Players",
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignDalPlayerDal_PlayersId",
                table: "CampaignDalPlayerDal",
                column: "PlayersId");
        }
    }
}
