using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Seeder;

internal static class ChestTrapsSeeder
{
    public static void SeedChestTraps(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChestTrapDal>().HasData(
            new ChestTrapDal
            {
                Id = 1,
                Name = "Brume étouffante",
                Description = "Une brume qui rend la respiration difficile.",
                Explanation = "Toutes les créatures vivantes situées dans la pièce perdent 1 point de vie. N'affecte pas les morts-vivants.",
                Level = 1,
                ImageUrl = ""
            },
            new ChestTrapDal
            {
                Id = 2,
                Name = "Couverture de flammes",
                Description = "Une intense chaleur vous encercle.",
                Explanation = "Vous perdez 2 points de vie et le Héros le plus proche de vous perd 2 points de vie aussi.",
                Level = 3,
                ImageUrl = ""
            },
            new ChestTrapDal
            {
                Id = 3,
                Name = "Voix des damnés",
                Description = "Des forces invisibles contrôlent votre esprit.",
                Explanation = "Vous vous déplacez près du Héros le plus proche et attaquez avec votre arme équipée.",
                Level = 1,
                ImageUrl = ""
            },
            new ChestTrapDal
            {
                Id = 4,
                Name = "Lumière aveuglante",
                Description = "Vous êtes aveuglé par un flash de lumière intense.",
                Explanation = "Vous passez votre prochain tour.",
                Level = 1,
                ImageUrl = ""
            },
            new ChestTrapDal
            {
                Id = 5,
                Name = "Appel de la tombe",
                Description = "Un pouvoir fantomatique.",
                Explanation = "Vous ranimez le dernier monstre vaincu.",
                Level = 1,
                ImageUrl = ""
            },
            new ChestTrapDal
            {
                Id = 6,
                Name = "Trahison brutale",
                Description = "Un terrible sortilège est lancé.",
                Explanation = "Choisissez de subir 5 points de dégâts ou de faire subir 3 points de dégâts à un autre Héros aléatoirement choisi.",
                Level = 2,
                ImageUrl = ""
            },
            new ChestTrapDal
            {
                Id = 7,
                Name = "Perte de magie",
                Description = "Vous avez pénétré dans un champ de faiblesse magique.",
                Explanation = "Vous perdez 4 points de sort.",
                Level = 3,
                ImageUrl = ""
            }
        );

        modelBuilder.Entity<ChestTrapEffectDal>().HasData(
            // Brume étouffante
            new ChestTrapEffectDal { Id = 1, ChestTrapId = 1, DecreaseAllCreaturesLifePoints = 1 },
            new ChestTrapEffectDal { Id = 2, ChestTrapId = 1, DoesNotAffectUndeads = true },
            // Couverture de flammes
            new ChestTrapEffectDal { Id = 3, ChestTrapId = 2, DecreaseHeroLifePoints = 2 },
            new ChestTrapEffectDal { Id = 4, ChestTrapId = 2, DecreaseHeroNearByLifePoints = 2 },
            // Voix des damnés
            new ChestTrapEffectDal { Id = 5, ChestTrapId = 3, MoveToRandomHero = true },
            new ChestTrapEffectDal { Id = 6, ChestTrapId = 3, AttackRandomHeroNearBy = true },
            // Lumière aveuglante
            new ChestTrapEffectDal { Id = 7, ChestTrapId = 4, SkipNextTurn = true },
            // Appel de la tombe
            new ChestTrapEffectDal { Id = 8, ChestTrapId = 5, ReviveLastDeadMonster = true },
            // Trahison brutale
            new ChestTrapEffectDal { Id = 9, ChestTrapId = 6, Lose5LifePointsOrRandomHeroLoses3LifePoints = true },
            // Perte de magie
            new ChestTrapEffectDal { Id = 10, ChestTrapId = 7, DecreaseHeroManaPoints = 4 }
        );
    }
}
