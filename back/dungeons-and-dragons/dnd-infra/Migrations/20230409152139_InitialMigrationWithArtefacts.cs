using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationWithArtefacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Items");

            migrationBuilder.CreateTable(
                name: "Artefacts",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscardAfterUsage = table.Column<bool>(type: "bit", nullable: true),
                    CastDieToDiscardAfterUsage = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artefacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtefactEffects",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtefactId = table.Column<int>(type: "int", nullable: false),
                    LifeIncrease = table.Column<int>(type: "int", nullable: true),
                    LifeDecrease = table.Column<int>(type: "int", nullable: true),
                    ManaIncrease = table.Column<int>(type: "int", nullable: true),
                    ManaDecrease = table.Column<int>(type: "int", nullable: true),
                    ShieldIncrease = table.Column<int>(type: "int", nullable: true),
                    ShieldDecrease = table.Column<int>(type: "int", nullable: true),
                    StorageIncrease = table.Column<int>(type: "int", nullable: true),
                    StorageDecrease = table.Column<int>(type: "int", nullable: true),
                    FootStepsIncrease = table.Column<int>(type: "int", nullable: true),
                    FootStepsDecrease = table.Column<int>(type: "int", nullable: true),
                    RerollDice = table.Column<bool>(type: "bit", nullable: true),
                    RevealRoomTraps = table.Column<bool>(type: "bit", nullable: true),
                    NotAffectedByTraps = table.Column<bool>(type: "bit", nullable: true),
                    ReflectsBackToAttacker = table.Column<bool>(type: "bit", nullable: true),
                    ReflectsBackToAnotherHero = table.Column<bool>(type: "bit", nullable: true),
                    ReflectsBackToRandomTarget = table.Column<bool>(type: "bit", nullable: true),
                    CanInvokeHeroNearBy = table.Column<bool>(type: "bit", nullable: true),
                    CanCastTrapFinderDie = table.Column<bool>(type: "bit", nullable: true),
                    DismissAllAttacks = table.Column<bool>(type: "bit", nullable: true),
                    IsUndetectableInNextRound = table.Column<bool>(type: "bit", nullable: true),
                    PicksTwoOutOfFourChestItems = table.Column<bool>(type: "bit", nullable: true),
                    CanDiscardChestItemToPickAnotherOneOneTime = table.Column<bool>(type: "bit", nullable: true),
                    CanDiscardChestItemToPickAnotherOneTwoTimes = table.Column<bool>(type: "bit", nullable: true),
                    CanDiscardChestItemToPickAnotherOneThreeTimes = table.Column<bool>(type: "bit", nullable: true),
                    NotAffectedByTrapsWhilePickingChestItems = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtefactEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtefactEffects_Artefacts_ArtefactId",
                        column: x => x.ArtefactId,
                        principalSchema: "Items",
                        principalTable: "Artefacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtefactEffects_ArtefactId",
                schema: "Items",
                table: "ArtefactEffects",
                column: "ArtefactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtefactEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Artefacts",
                schema: "Items");
        }
    }
}
