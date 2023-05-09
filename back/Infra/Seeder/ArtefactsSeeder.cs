//using dnd_domain.Items.Enums;
//using dnd_infra.Items.DALs;
//using Microsoft.EntityFrameworkCore;

//namespace dnd_infra.Seeder;

//internal static class ModelBuilderExtensions
//{
//    public static void SeedArtefacts(this ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<ArtefactDal>().HasData(
//            new ArtefactDal
//            {
//                Id = 1,
//                Name = "Amulette de Yondalla",
//                Description = "Couverte de symboles magiques.",
//                Explanation = "Quand vous ouvrez un coffre, vous pouvez garder l'objet trouvé, ou vous en défausser et en choisir un autre.",
//                Level = 1,
//                ImageUrl = "",
//                DiscardAfterUsage = false,
//                CastDieToDiscardAfterUsage = false
//            },
//            new ArtefactDal
//            {
//                Id = 2,
//                Name = "Fortune de Yondalla",
//                Description = "Des runes de protection sont serties dans sa pierre.",
//                Explanation = "Quand vous ouvrez un coffre, vous avez le choix entre 4 objets. Choisissez en deux que vous gardez. Par ailleurs, les pièges ne vous infligent pas de dégât. Après avoir fait votre choix, lancez le dé de hasard pour savoir si vous gardez ou non l'artefact.",
//                Level = 3,
//                ImageUrl = "",
//                DiscardAfterUsage = false,
//                CastDieToDiscardAfterUsage = true
//            },
//            new ArtefactDal
//            {
//                Id = 3,
//                Name = "Anneau des ombres",
//                Description = "Passez cet anneau à votre doigt pour disparaître dans les ténèbres du donjon.",
//                Explanation = "Déplacez vous où vous le désirez dans la pièce sans être détecté. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
//                Level = 1,
//                ImageUrl = "",
//                DiscardAfterUsage = false,
//                CastDieToDiscardAfterUsage = true
//            },
//            new ArtefactDal
//            {
//                Id = 4,
//                Name = "Cape en peau d'écorce",
//                Description = "Composée de l'écorce des arbres magiques de Arnholm, cette cape légère vous protège.",
//                Explanation = "Portez cette cape pour ne pas subir de dégâts lors d'une attaque ou d'un événement. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
//                Level = 1,
//                ImageUrl = "",
//                DiscardAfterUsage = false,
//                CastDieToDiscardAfterUsage = true
//            },
//            new ArtefactDal
//            {
//                Id = 5,
//                Name = "Bouclier du chaos",
//                Description = "Forgé dans un moment de rage par les nains, ce bouclier agit de manière imprévisible.",
//                Explanation = "Redirigez les dégâts que vous devez subir sur les points de vie d'un autre héros. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
//                Level = 2,
//                ImageUrl = "",
//                DiscardAfterUsage = false,
//                CastDieToDiscardAfterUsage = true
//            },
//            new ArtefactDal
//            {
//                Id = 6,
//                Name = "Amulette d'Olidammara",
//                Description = "Elle renferme la sagesse de nombreux anciens.",
//                Explanation = "Permet au porteur de chercher des pièges dans la salle.",
//                Level = 1,
//                ImageUrl = "",
//                DiscardAfterUsage = false,
//                CastDieToDiscardAfterUsage = false
//            },
//            new ArtefactDal
//            {
//                Id = 7,
//                Name = "Orbe de vision lucide",
//                Description = "Il appartenait autrefois à de sages seigneurs à qui il offrait ses dons de vision.",
//                Explanation = "Révelez tous les pièges dans la pièce. L'artefact disparaît après son utilisation.",
//                Level = 1,
//                ImageUrl = "",
//                DiscardAfterUsage = true,
//                CastDieToDiscardAfterUsage = false
//            },
//            new ArtefactDal
//            {
//                Id = 8,
//                Name = "Bouclier miroir elfe",
//                Description = "Découvert au fond d'une fontaine elfe, il réfléchit l'image de tout ce qu'il voit.",
//                Explanation = "L'attaquant subit les dégâts du jet de dé à votre place. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
//                Level = 3,
//                ImageUrl = "",
//                DiscardAfterUsage = false,
//                CastDieToDiscardAfterUsage = true
//            },
//            new ArtefactDal
//            {
//                Id = 9,
//                Name = "Cape de Boccob",
//                Description = "Les enchantements tissés dans cette cape permettent d'absorber les attaques physiques.",
//                Explanation = "Augmente la classe d'armure de 1 pour ce tour. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
//                Level = 1,
//                ImageUrl = "",
//                DiscardAfterUsage = false,
//                CastDieToDiscardAfterUsage = true
//            },
//            new ArtefactDal
//            {
//                Id = 10,
//                Name = "Cor de l'invocateur",
//                Description = "Soufflez fort pour appeler de l'aide.",
//                Explanation = "Déplacez n'importe quel héros sur une case près de vous. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
//                Level = 1,
//                ImageUrl = "",
//                DiscardAfterUsage = false,
//                CastDieToDiscardAfterUsage = true
//            }
//        );

//        modelBuilder.Entity<ArtefactEffectDal>().HasData(
//            // Amulette de Yondalla
//            new ArtefactEffectDal { Id = 1, ArtefactId = 1, Effect = ArtefactEffectType.CanDiscardChestItemToPickAnotherOneOneTime },
//            // Fortune de Yondalla
//            new ArtefactEffectDal { Id = 2, ArtefactId = 2, Effect = ArtefactEffectType.PicksTwoOutOfFourChestItems },
//            new ArtefactEffectDal { Id = 3, ArtefactId = 2, Effect = ArtefactEffectType.NotAffectedByTrapsWhilePickingChestItems },
//            // Anneau des ombres
//            new ArtefactEffectDal { Id = 4, ArtefactId = 3, Effect = ArtefactEffectType.IsUndetectableInNextRound },
//            // Cape en peau d'écorce
//            new ArtefactEffectDal { Id = 5, ArtefactId = 4, Effect = ArtefactEffectType.DismissAllAttacks },
//            // Bouclier du chaos
//            new ArtefactEffectDal { Id = 6, ArtefactId = 5, Effect = ArtefactEffectType.AttackReflectsBackToAttacker },
//            // Amulette d'Olidammara
//            new ArtefactEffectDal { Id = 7, ArtefactId = 6, Effect = ArtefactEffectType.CanCastTrapFinderDie },
//            // Orbre de vision lucide
//            new ArtefactEffectDal { Id = 8, ArtefactId = 7, Effect = ArtefactEffectType.RevealRoomTraps },
//            // Bouclier miroir elfe
//            new ArtefactEffectDal { Id = 9, ArtefactId = 8, Effect = ArtefactEffectType.AttackReflectsBackToAttacker },
//            // Cape de Boccob
//            new ArtefactEffectDal { Id = 10, ArtefactId = 9, Effect = ArtefactEffectType.IncreaseHeroShieldBy1 },
//            // Cor de l'invocateur
//            new ArtefactEffectDal { Id = 11, ArtefactId = 10, Effect = ArtefactEffectType.CanInvokeHeroNearBy }
//        );
//    }
//}
