using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCampaignsAndPlayersModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Adventures_AdventureId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropTable(
                name: "UserCampaignAssociationDal");

            migrationBuilder.DropIndex(
                name: "IX_Players_AdventureId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "NickName",
                schema: "Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AdventureId",
                schema: "Players",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Campaigns",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Users",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "Users",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Level",
                schema: "Campaigns",
                table: "Campaigns",
                newName: "Type");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignDalPlayerDal");

            migrationBuilder.RenameColumn(
                name: "Password",
                schema: "Users",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Users",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "Campaigns",
                table: "Campaigns",
                newName: "Level");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                schema: "Users",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdventureId",
                schema: "Players",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Campaigns",
                table: "Campaigns",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserCampaignAssociationDal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignDalId = table.Column<int>(type: "int", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCampaignAssociationDal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCampaignAssociationDal_Campaigns_CampaignDalId",
                        column: x => x.CampaignDalId,
                        principalSchema: "Campaigns",
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCampaignAssociationDal_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Campaigns",
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCampaignAssociationDal_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Users",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_AdventureId",
                schema: "Players",
                table: "Players",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignAssociationDal_CampaignDalId",
                table: "UserCampaignAssociationDal",
                column: "CampaignDalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignAssociationDal_CampaignId",
                table: "UserCampaignAssociationDal",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignAssociationDal_UserId",
                table: "UserCampaignAssociationDal",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Adventures_AdventureId",
                schema: "Players",
                table: "Players",
                column: "AdventureId",
                principalSchema: "Campaigns",
                principalTable: "Adventures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
