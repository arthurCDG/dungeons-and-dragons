using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class ChestTraps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChestTraps",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChestTraps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChestTrapEffects",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChestTrapId = table.Column<int>(type: "int", nullable: false),
                    DecreaseAllCreaturesLifePoints = table.Column<int>(type: "int", nullable: true),
                    IncreaseAllMonstersLifePoints = table.Column<int>(type: "int", nullable: true),
                    DecreaseHeroLifePoints = table.Column<int>(type: "int", nullable: true),
                    DecreaseRandomMonsterLifePoints = table.Column<int>(type: "int", nullable: true),
                    DecreaseHeroManaPoints = table.Column<int>(type: "int", nullable: true),
                    Lose5LifePointsOrRandomHeroLoses3LifePoints = table.Column<bool>(type: "bit", nullable: true),
                    ReviveLastDeadMonster = table.Column<bool>(type: "bit", nullable: true),
                    SkipNextTurn = table.Column<bool>(type: "bit", nullable: true),
                    AttackRandomHeroNearBy = table.Column<bool>(type: "bit", nullable: true),
                    MoveToRandomHero = table.Column<bool>(type: "bit", nullable: true),
                    DoesNotAffectLivingCreatures = table.Column<bool>(type: "bit", nullable: true),
                    DoesNotAffectUndeads = table.Column<bool>(type: "bit", nullable: true),
                    DoesNotAffectHeroes = table.Column<bool>(type: "bit", nullable: true),
                    DoesNotAffectMonsters = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChestTrapEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChestTrapEffects_ChestTraps_ChestTrapId",
                        column: x => x.ChestTrapId,
                        principalSchema: "Items",
                        principalTable: "ChestTraps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChestTrapEffects_ChestTrapId",
                schema: "Items",
                table: "ChestTrapEffects",
                column: "ChestTrapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChestTrapEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "ChestTraps",
                schema: "Items");
        }
    }
}
