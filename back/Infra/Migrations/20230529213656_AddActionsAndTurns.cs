using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class AddActionsAndTurns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GameFlow");

            migrationBuilder.AddColumn<int>(
                name: "MaxAttackCount",
                schema: "Players",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxChestSearchCount",
                schema: "Players",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxFootStepsCount",
                schema: "Players",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxHealCount",
                schema: "Players",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxTrapSearchCount",
                schema: "Players",
                table: "Monsters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxAttackCount",
                schema: "Players",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxChestSearchCount",
                schema: "Players",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxFootStepsCount",
                schema: "Players",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxHealCount",
                schema: "Players",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxTrapSearchCount",
                schema: "Players",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Actions",
                schema: "GameFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RemainingFootSteps = table.Column<int>(type: "int", nullable: false),
                    RemainingAttacks = table.Column<int>(type: "int", nullable: false),
                    RemainingHeals = table.Column<int>(type: "int", nullable: false),
                    RemainingChestSearch = table.Column<int>(type: "int", nullable: false),
                    RemainingTrapSearch = table.Column<int>(type: "int", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: true),
                    MonsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalSchema: "Players",
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actions_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "Players",
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrentPlayers",
                schema: "GameFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: true),
                    MonsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentPlayers_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Campaigns",
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentPlayers_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalSchema: "Players",
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentPlayers_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "Players",
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TurnOrders",
                schema: "GameFlow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: true),
                    MonsterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurnOrders_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalSchema: "Players",
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TurnOrders_Monsters_MonsterId",
                        column: x => x.MonsterId,
                        principalSchema: "Players",
                        principalTable: "Monsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_HeroId",
                schema: "GameFlow",
                table: "Actions",
                column: "HeroId",
                unique: true,
                filter: "[HeroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_MonsterId",
                schema: "GameFlow",
                table: "Actions",
                column: "MonsterId",
                unique: true,
                filter: "[MonsterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentPlayers_CampaignId",
                schema: "GameFlow",
                table: "CurrentPlayers",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentPlayers_HeroId",
                schema: "GameFlow",
                table: "CurrentPlayers",
                column: "HeroId",
                unique: true,
                filter: "[HeroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentPlayers_MonsterId",
                schema: "GameFlow",
                table: "CurrentPlayers",
                column: "MonsterId",
                unique: true,
                filter: "[MonsterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TurnOrders_HeroId",
                schema: "GameFlow",
                table: "TurnOrders",
                column: "HeroId",
                unique: true,
                filter: "[HeroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TurnOrders_MonsterId",
                schema: "GameFlow",
                table: "TurnOrders",
                column: "MonsterId",
                unique: true,
                filter: "[MonsterId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions",
                schema: "GameFlow");

            migrationBuilder.DropTable(
                name: "CurrentPlayers",
                schema: "GameFlow");

            migrationBuilder.DropTable(
                name: "TurnOrders",
                schema: "GameFlow");

            migrationBuilder.DropColumn(
                name: "MaxAttackCount",
                schema: "Players",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "MaxChestSearchCount",
                schema: "Players",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "MaxFootStepsCount",
                schema: "Players",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "MaxHealCount",
                schema: "Players",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "MaxTrapSearchCount",
                schema: "Players",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "MaxAttackCount",
                schema: "Players",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "MaxChestSearchCount",
                schema: "Players",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "MaxFootStepsCount",
                schema: "Players",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "MaxHealCount",
                schema: "Players",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "MaxTrapSearchCount",
                schema: "Players",
                table: "Heroes");
        }
    }
}
