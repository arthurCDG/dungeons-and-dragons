using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dnd_infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedArtefacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Items",
                table: "Artefacts",
                columns: new[] { "Id", "CastDieToDiscardAfterUsage", "Description", "DiscardAfterUsage", "Explanation", "ImageUrl", "Level", "Name" },
                values: new object[,]
                {
                    { 1, false, "Couverte de symboles magiques.", false, "Quand vous ouvrez un coffre, vous pouvez garder l'objet trouvé, ou vous en défausser et en choisir un autre.", "", 1, "Amulette de Yondalla" },
                    { 2, true, "Des runes de protection sont serties dans sa pierre.", false, "Quand vous ouvrez un coffre, vous avez le choix entre 4 objets. Choisissez en deux que vous gardez. Par ailleurs, les pièges ne vous infligent pas de dégât. Après avoir fait votre choix, lancez le dé de hasard pour savoir si vous gardez ou non l'artefact.", "", 3, "Fortune de Yondalla" },
                    { 3, true, "Passez cet anneau à votre doigt pour disparaître dans les ténèbres du donjon.", false, "Déplacez vous où vous le désirez dans la pièce sans être détecté. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.", "", 1, "Anneau des ombres" },
                    { 4, true, "Composée de l'écorce des arbres magiques de Arnholm, cette cape légère vous protège.", false, "Portez cette cape pour ne pas subir de dégâts lors d'une attaque ou d'un événement. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.", "", 1, "Cape en peau d'écorce" },
                    { 5, true, "Forgé dans un moment de rage par les nains, ce bouclier agit de manière imprévisible.", false, "Redirigez les dégâts que vous devez subir sur les points de vie d'un autre héros. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.", "", 2, "Bouclier du chaos" },
                    { 6, false, "Elle renferme la sagesse de nombreux anciens.", false, "Permet au porteur de chercher des pièges dans la salle.", "", 1, "Amulette d'Olidammara" },
                    { 7, false, "Il appartenait autrefois à de sages seigneurs à qui il offrait ses dons de vision.", true, "Révelez tous les pièges dans la pièce. L'artefact disparaît après son utilisation.", "", 1, "Orbe de vision lucide" },
                    { 8, true, "Découvert au fond d'une fontaine elfe, il réfléchit l'image de tout ce qu'il voit.", false, "L'attaquant subit les dégâts du jet de dé à votre place. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.", "", 3, "Bouclier miroir elfe" },
                    { 9, true, "Les enchantements tissés dans cette cape permettent d'absorber les attaques physiques.", false, "Augmente la classe d'armure de 1 pour ce tour. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.", "", 1, "Cape de Boccob" },
                    { 10, true, "Soufflez fort pour appeler de l'aide.", false, "Déplacez n'importe quel héros sur une case près de vous. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.", "", 1, "Cor de l'invocateur" }
                });

            migrationBuilder.InsertData(
                schema: "Items",
                table: "ArtefactEffects",
                columns: new[] { "Id", "ArtefactId", "CanCastTrapFinderDie", "CanDiscardChestItemToPickAnotherOneOneTime", "CanDiscardChestItemToPickAnotherOneThreeTimes", "CanDiscardChestItemToPickAnotherOneTwoTimes", "CanInvokeHeroNearBy", "DismissAllAttacks", "FootStepsDecrease", "FootStepsIncrease", "IsUndetectableInNextRound", "LifeDecrease", "LifeIncrease", "ManaDecrease", "ManaIncrease", "NotAffectedByTraps", "NotAffectedByTrapsWhilePickingChestItems", "PicksTwoOutOfFourChestItems", "ReflectsBackToAnotherHero", "ReflectsBackToAttacker", "ReflectsBackToRandomTarget", "RerollDice", "RevealRoomTraps", "ShieldDecrease", "ShieldIncrease", "StorageDecrease", "StorageIncrease" },
                values: new object[,]
                {
                    { 1, 1, null, true, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 2, 2, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, null, null, null, null, null, null, null, null, null },
                    { 3, 2, null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, null, null, null, null, null, null, null, null, null, null },
                    { 4, 3, null, null, null, null, null, null, null, null, true, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 5, 4, null, null, null, null, null, true, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 6, 5, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, null, null, null, null, null, null, null },
                    { 7, 6, true, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 8, 7, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, null, null, null, null },
                    { 9, 8, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, true, null, null, null, null, null, null, null },
                    { 10, 9, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 1, null, null },
                    { 11, 10, null, null, null, null, true, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "ArtefactEffects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "Artefacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "Artefacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "Artefacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "Artefacts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "Artefacts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "Artefacts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "Artefacts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "Artefacts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "Artefacts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Items",
                table: "Artefacts",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
