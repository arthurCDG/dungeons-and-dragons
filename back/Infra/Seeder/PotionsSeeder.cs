using dnd_domain.Items.Enums;
using dnd_infra.Items.DALs;
using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Seeder;

internal static class PotionsSeeder
{
    public static void SeedPotions(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PotionDal>().HasData(
            new PotionDal
            {
                Id = 1,
                Name = "Potion de faiblesse",
                Description = "Buvez cette potion pour affaiblir un monstre.",
                Explanation = "Réduisez la classe d'armure d'un monstre de 2 jusqu'au début du prochain tour du Maître du Donjon.",
                Level = 1,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 2,
                Name = "Potion de soins importants",
                Description = "Buvez cette potion pour raviver vos forces.",
                Explanation = "Récupérez un maximum de 5 points de vie.",
                Level = 3,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 3,
                Name = "Potion de soins légers",
                Description = "Buvez cette potion pour raviver vos forces.",
                Explanation = "Récupérez un maximum de 3 points de vie.",
                Level = 1,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 4,
                Name = "Potion de soins modérés",
                Description = "Buvez cette potion pour raviver vos forces.",
                Explanation = "Récupérez un maximum de 4 points de vie.",
                Level = 2,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 5,
                Name = "Potion de cercle de guérison",
                Description = "Buvez cette potion pour former un cercle de guérison autour de tous les Héros.",
                Explanation = "Faites récupérer un maximum de 2 points de vie à chaque Héros.",
                Level = 3,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 6,
                Name = "Potion de restauration suprême",
                Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
                Explanation = "Récupérez un maximum de 5 points de mana.",
                Level = 3,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 7,
                Name = "Potion de restauration partielle",
                Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
                Explanation = "Récupérez un maximum de 3 points de mana.",
                Level = 1,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 8,
                Name = "Potion de restauration",
                Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
                Explanation = "Récupérez un maximum de 4 points de mana.",
                Level = 2,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 9,
                Name = "Potion d'ombre fumigène",
                Description = "Buvez cette potion pour matérialiser un nuage épais autour de tous les monstres de la pièce.",
                Explanation = "Chaque héros présent dans la pièce peut effectuer un déplacement gratuit immédiatement.",
                Level = 1,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 10,
                Name = "Potion de restauration suprême",
                Description = "Ramenez un Héros à la vie et redonnez lui 4 points de vie et 4 points de sort, si possible.",
                Explanation = "Vous devez être à côté du Héros mort pour utiliser cette potion.",
                Level = 1,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 11,
                Name = "Potion de faiblesse suprême",
                Description = "Buvez cette potion pour affaiblir les monstres.",
                Explanation = "Réduisez de 2 la classe d'armure de tous les monstres situés dans la pièce jusqu'au début du prochain tour du Maître du Donjon.",
                Level = 3,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 12,
                Name = "Potion de main impérieuse",
                Description = "Buvez cette potion pour appeler de l'aide.",
                Explanation = "Déplacez n'importe quel monstre à l'endroit de votre choix, dans la pièce où il se trouve.",
                Level = 1,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 13,
                Name = "Potion d'attaque soudaine",
                Description = "Buvez cette potion pour accroître la force de tous les Héros pendant un tour.",
                Explanation = "Infligez 2 points de dégâts à n'importe quel monstre dans la pièce.",
                Level = 2,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 14,
                Name = "Potion de montée d'adrénaline",
                Description = "Buvez cette potion pour accélérer vos réactions.",
                Explanation = "Vous attaquez immédiatement, même si ce n'est pas votre tour.",
                Level = 2,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 15,
                Name = "Potion de la sagesse d'Olidammara",
                Description = "Buvez cette potion quand un piège se déclenche.",
                Explanation = "Le piège n'a aucun effet.",
                Level = 1,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 16,
                Name = "Potion de bénédiction de Kord",
                Description = "Buvez cette potion pour bénir l'une de vos armes.",
                Explanation = "Double la puissance de l'arme choisie lors de sa prochaine attaque.",
                Level = 1,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 17,
                Name = "Potion d'introspection",
                Description = "Buvez cette potion pour revenir en arrière dans le temps.",
                Explanation = "Relancez le dernier dé joué.",
                Level = 3,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 18,
                Name = "Potion de fou rire",
                Description = "Buvez cette potion pour provoquer la chute d'un monstre situé dans la pièce.",
                Explanation = "Le monstre passe son prochain tour.",
                Level = 1,
                ImageUrl = ""
            },
            new PotionDal
            {
                Id = 19,
                Name = "Potion d'arrêt du temps",
                Description = "Buvez cette potion pour arrêter le temps pour vos ennemis.",
                Explanation = "Tous les monstres situés dans la pièce passent leur prochain tour.",
                Level = 2,
                ImageUrl = ""
            }
        );

        modelBuilder.Entity<PotionEffectDal>().HasData(
            // Potion de faiblesse
            new PotionEffectDal { Id = 1, PotionId = 1, Effect = PotionEffect.DecreaseMonsterShieldUntilNextDMTurnBy2 },
            // Potion de soins importants
            new PotionEffectDal { Id = 2, PotionId = 2, Effect = PotionEffect.IncreaseHeroLifePointsBy5 },
            // Potion de soins légers
            new PotionEffectDal { Id = 3, PotionId = 3, Effect = PotionEffect.IncreaseHeroLifePointsBy3 },
            // Potion de soins modérés
            new PotionEffectDal { Id = 4, PotionId = 4, Effect = PotionEffect.IncreaseHeroLifePointsBy4 },
            // Potion de cercle de guérison
            new PotionEffectDal { Id = 5, PotionId = 5, Effect = PotionEffect.IncreaseAllHeroesLifePointsBy2 },
            // Potion de restauration suprême
            new PotionEffectDal { Id = 6, PotionId = 6, Effect = PotionEffect.IncreaseHeroManaPointsBy5 },
            // Potion de restauration partielle
            new PotionEffectDal { Id = 7, PotionId = 7, Effect = PotionEffect.IncreaseHeroManaPointsBy3 },
            // Potion de restauration
            new PotionEffectDal { Id = 8, PotionId = 8, Effect = PotionEffect.IncreaseHeroManaPointsBy4 },
            // Potion d'ombre fumigène
            new PotionEffectDal { Id = 9, PotionId = 9, Effect = PotionEffect.IncreaseAllHeroesFootStepsBy1 },
            // Potion de restauration suprême
            new PotionEffectDal { Id = 10, PotionId = 10, Effect = PotionEffect.ReviveHeroWith4LPAnd4MP },
            // Potion de faiblesse suprême
            new PotionEffectDal { Id = 11, PotionId = 11, Effect = PotionEffect.DecreaseAllMonstersShieldsUntilNextDMTurnBy2 },
            // Potion de main impérieuse
            new PotionEffectDal { Id = 12, PotionId = 12, Effect = PotionEffect.MoveMonsterToChosenSquare },
            // Potion d'attaque soudaine
            new PotionEffectDal { Id = 13, PotionId = 13, Effect = PotionEffect.DecreaseMonsterLifePointsBy2 },
            // Potion de montée d'adrénaline
            new PotionEffectDal { Id = 14, PotionId = 14, Effect = PotionEffect.HeroCanAttackImmediatly },
            // Potion de la sagesse d'Olidammara
            new PotionEffectDal { Id = 15, PotionId = 15, Effect = PotionEffect.HeroCanDismissTrapEffect },
            // Potion de bénédiction de Kord
            new PotionEffectDal { Id = 16, PotionId = 16, Effect = PotionEffect.DoubleWeaponStrengthForNextAttack },
            // Potion d'introspection
            new PotionEffectDal { Id = 17, PotionId = 17, Effect = PotionEffect.RerollLastCastDie },
            // Potion de fou rire
            new PotionEffectDal { Id = 18, PotionId = 18, Effect = PotionEffect.DismissesNextTurnOfMonster },
            // Potion d'arrêt du temps
            new PotionEffectDal { Id = 19, PotionId = 19, Effect = PotionEffect.DismissesNextTurnOfAllMonsters }
        );
    }
}
