using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class PotionsAndSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Potions",
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
                    table.PrimaryKey("PK_Potions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PotionEffects",
                schema: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PotionId = table.Column<int>(type: "int", nullable: false),
                    AffectsAllHeroes = table.Column<bool>(type: "bit", nullable: false),
                    AffectsAllMonsters = table.Column<bool>(type: "bit", nullable: false),
                    IncreaseLifePoints = table.Column<int>(type: "int", nullable: true),
                    IncreaseManaPoints = table.Column<int>(type: "int", nullable: true),
                    DecreaseMonsterLifePoints = table.Column<int>(type: "int", nullable: true),
                    DecreaseMonsterShieldUntilNextDMTurn = table.Column<int>(type: "int", nullable: true),
                    IncreaseFootSteps = table.Column<int>(type: "int", nullable: true),
                    ReviveHeroWith4LPAnd4MP = table.Column<bool>(type: "bit", nullable: true),
                    RequiresHeroToBeNearBy = table.Column<bool>(type: "bit", nullable: true),
                    MoveMonsterToChosenSquare = table.Column<bool>(type: "bit", nullable: true),
                    CanAttackImmediatly = table.Column<bool>(type: "bit", nullable: true),
                    CanDismissTrapEffect = table.Column<bool>(type: "bit", nullable: true),
                    DoublesWeaponStrength = table.Column<bool>(type: "bit", nullable: true),
                    DismissesNextTurnOfMonster = table.Column<bool>(type: "bit", nullable: true),
                    RerollLastCastDie = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PotionEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PotionEffects_Potions_PotionId",
                        column: x => x.PotionId,
                        principalSchema: "Items",
                        principalTable: "Potions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Items",
                table: "Potions",
                columns: new[] { "Id", "Description", "Explanation", "ImageUrl", "Level", "Name" },
                values: new object[,]
                {
                    { 1, "Buvez cette potion pour affaiblir un monstre.", "Réduisez la classe d'armure d'un monstre de 2 jusqu'au début du prochain tour du Maître du Donjon.", "", 1, "Potion de faiblesse" },
                    { 2, "Buvez cette potion pour raviver vos forces.", "Récupérez un maximum de 5 points de vie.", "", 3, "Potion de soins importants" },
                    { 3, "Buvez cette potion pour raviver vos forces.", "Récupérez un maximum de 3 points de vie.", "", 1, "Potion de soins légers" },
                    { 4, "Buvez cette potion pour raviver vos forces.", "Récupérez un maximum de 4 points de vie.", "", 2, "Potion de soins modérés" },
                    { 5, "Buvez cette potion pour former un cercle de guérison autour de tous les Héros.", "Faites récupérer un maximum de 2 points de vie à chaque Héros.", "", 3, "Potion de cercle de guérison" },
                    { 6, "Buvez cette potion pour raviver vos pouvoirs magiques.", "Récupérez un maximum de 5 points de mana.", "", 3, "Potion de restauration suprême" },
                    { 7, "Buvez cette potion pour raviver vos pouvoirs magiques.", "Récupérez un maximum de 3 points de mana.", "", 1, "Potion de restauration partielle" },
                    { 8, "Buvez cette potion pour raviver vos pouvoirs magiques.", "Récupérez un maximum de 4 points de mana.", "", 2, "Potion de restauration" },
                    { 9, "Buvez cette potion pour matérialiser un nuage épais autour de tous les monstres de la pièce.", "Chaque héros présent dans la pièce peut effectuer un déplacement gratuit immédiatement.", "", 1, "Potion d'ombre fumigène" },
                    { 10, "Ramenez un Héros à la vie et redonnez lui 4 points de vie et 4 points de sort, si possible.", "Vous devez être à côté du Héros mort pour utiliser cette potion.", "", 1, "Potion de restauration suprême" },
                    { 11, "Buvez cette potion pour affaiblir les monstres.", "Réduisez de 2 la classe d'armure de tous les monstres situés dans la pièce jusqu'au début du prochain tour du Maître du Donjon.", "", 3, "Potion de faiblesse suprême" },
                    { 12, "Buvez cette potion pour appeler de l'aide.", "Déplacez n'importe quel monstre à l'endroit de votre choix, dans la pièce où il se trouve.", "", 1, "Potion de main impérieuse" },
                    { 13, "Buvez cette potion pour accroître la force de tous les Héros pendant un tour.", "Infligez 2 points de dégâts à n'importe quel monstre dans la pièce.", "", 2, "Potion d'attaque soudaine" },
                    { 14, "Buvez cette potion pour accélérer vos réactions.", "Vous attaquez immédiatement, même si ce n'est pas votre tour.", "", 2, "Potion de montée d'adrénaline" },
                    { 15, "Buvez cette potion quand un piège se déclenche.", "Le piège n'a aucun effet.", "", 1, "Potion de la sagesse d'Olidammara" },
                    { 16, "Buvez cette potion pour bénir l'une de vos armes.", "Double la puissance de l'arme choisie lors de sa prochaine attaque.", "", 1, "Potion de bénédiction de Kord" },
                    { 17, "Buvez cette potion pour revenir en arrière dans le temps.", "Relancez le dernier dé joué.", "", 3, "Potion d'introspection" },
                    { 18, "Buvez cette potion pour provoquer la chute d'un monstre situé dans la pièce.", "Le monstre passe son prochain tour.", "", 1, "Potion de fou rire" },
                    { 19, "Buvez cette potion pour arrêter le temps pour vos ennemis.", "Tous les monstres situés dans la pièce passent leur prochain tour.", "", 2, "Potion d'arrêt du temps" }
                });

            migrationBuilder.InsertData(
                schema: "Items",
                table: "PotionEffects",
                columns: new[] { "Id", "AffectsAllHeroes", "AffectsAllMonsters", "CanAttackImmediatly", "CanDismissTrapEffect", "DecreaseMonsterLifePoints", "DecreaseMonsterShieldUntilNextDMTurn", "DismissesNextTurnOfMonster", "DoublesWeaponStrength", "IncreaseFootSteps", "IncreaseLifePoints", "IncreaseManaPoints", "MoveMonsterToChosenSquare", "PotionId", "RequiresHeroToBeNearBy", "RerollLastCastDie", "ReviveHeroWith4LPAnd4MP" },
                values: new object[,]
                {
                    { 1, false, false, null, null, null, 2, null, null, null, null, null, null, 1, null, null, null },
                    { 2, false, false, null, null, null, null, null, null, null, 5, null, null, 2, null, null, null },
                    { 3, false, false, null, null, null, null, null, null, null, 3, null, null, 3, null, null, null },
                    { 4, false, false, null, null, null, null, null, null, null, 4, null, null, 4, null, null, null },
                    { 5, true, false, null, null, null, null, null, null, null, 2, null, null, 5, null, null, null },
                    { 6, false, false, null, null, null, null, null, null, null, null, 5, null, 6, null, null, null },
                    { 7, false, false, null, null, null, null, null, null, null, null, 3, null, 7, null, null, null },
                    { 8, false, false, null, null, null, null, null, null, null, null, 4, null, 8, null, null, null },
                    { 9, true, false, null, null, null, null, null, null, 1, null, null, null, 9, null, null, null },
                    { 10, false, false, null, null, null, null, null, null, null, null, null, null, 10, null, null, true },
                    { 11, false, true, null, null, null, 2, null, null, null, null, null, null, 11, null, null, null },
                    { 12, false, false, null, null, null, null, null, null, null, null, null, true, 12, null, null, null },
                    { 13, false, false, null, null, 2, null, null, null, null, null, null, null, 13, null, null, null },
                    { 14, false, false, true, null, null, null, null, null, null, null, null, null, 14, null, null, null },
                    { 15, false, false, null, true, null, null, null, null, null, null, null, null, 15, null, null, null },
                    { 16, false, false, null, null, null, null, null, true, null, null, null, null, 16, null, null, null },
                    { 17, false, false, null, null, null, null, null, null, null, null, null, null, 17, null, true, null },
                    { 18, false, false, null, null, null, null, true, null, null, null, null, null, 18, null, null, null },
                    { 19, false, true, null, null, null, null, true, null, null, null, null, null, 19, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PotionEffects_PotionId",
                schema: "Items",
                table: "PotionEffects",
                column: "PotionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PotionEffects",
                schema: "Items");

            migrationBuilder.DropTable(
                name: "Potions",
                schema: "Items");
        }
    }
}
