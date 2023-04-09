using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedChestTrapsAndAddOneTrapEffect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DecreaseHeroNearByLifePoints",
                schema: "Items",
                table: "ChestTrapEffects",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Items",
                table: "ChestTraps",
                columns: new[] { "Id", "Description", "Explanation", "ImageUrl", "Level", "Name" },
                values: new object[,]
                {
                    { 1, "Une brume qui rend la respiration difficile.", "Toutes les créatures vivantes situées dans la pièce perdent 1 point de vie. N'affecte pas les morts-vivants.", "", 1, "Brume étouffante" },
                    { 2, "Une intense chaleur vous encercle.", "Vous perdez 2 points de vie et le Héros le plus proche de vous perd 2 points de vie aussi.", "", 3, "Couverture de flammes" },
                    { 3, "Des forces invisibles contrôlent votre esprit.", "Vous vous déplacez près du Héros le plus proche et attaquez avec votre arme équipée.", "", 1, "Voix des damnés" },
                    { 4, "Vous êtes aveuglé par un flash de lumière intense.", "Vous passez votre prochain tour.", "", 1, "Lumière aveuglante" },
                    { 5, "Un pouvoir fantomatique.", "Vous ranimez le dernier monstre vaincu.", "", 1, "Appel de la tombe" },
                    { 6, "Un terrible sortilège est lancé.", "Choisissez de subir 5 points de dégâts ou de faire subir 3 points de dégâts à un autre Héros aléatoirement choisi.", "", 2, "Trahison brutale" },
                    { 7, "Vous avez pénétré dans un champ de faiblesse magique.", "Vous perdez 4 points de sort.", "", 3, "Perte de magie" }
                });

            migrationBuilder.InsertData(
                schema: "Items",
                table: "ChestTrapEffects",
                columns: new[] { "Id", "AttackRandomHeroNearBy", "ChestTrapId", "DecreaseAllCreaturesLifePoints", "DecreaseHeroLifePoints", "DecreaseHeroManaPoints", "DecreaseHeroNearByLifePoints", "DecreaseRandomMonsterLifePoints", "DoesNotAffectHeroes", "DoesNotAffectLivingCreatures", "DoesNotAffectMonsters", "DoesNotAffectUndeads", "IncreaseAllMonstersLifePoints", "Lose5LifePointsOrRandomHeroLoses3LifePoints", "MoveToRandomHero", "ReviveLastDeadMonster", "SkipNextTurn" },
                values: new object[,]
                {
                    { 1, null, 1, 1, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 2, null, 1, null, null, null, null, null, null, null, null, true, null, null, null, null, null },
                    { 3, null, 2, null, 2, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 4, null, 2, null, null, null, 2, null, null, null, null, null, null, null, null, null, null },
                    { 5, null, 3, null, null, null, null, null, null, null, null, null, null, null, true, null, null },
                    { 6, true, 3, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 7, null, 4, null, null, null, null, null, null, null, null, null, null, null, null, null, true },
                    { 8, null, 5, null, null, null, null, null, null, null, null, null, null, null, null, true, null },
                    { 9, null, 6, null, null, null, null, null, null, null, null, null, null, true, null, null, null },
                    { 10, null, 7, null, null, 4, null, null, null, null, null, null, null, null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTrapEffects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTrapEffects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTrapEffects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTrapEffects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTrapEffects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTrapEffects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTrapEffects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTrapEffects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTrapEffects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTrapEffects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTraps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTraps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTraps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTraps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTraps",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTraps",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ChestTraps",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "DecreaseHeroNearByLifePoints",
                schema: "Items",
                table: "ChestTrapEffects");
        }
    }
}
