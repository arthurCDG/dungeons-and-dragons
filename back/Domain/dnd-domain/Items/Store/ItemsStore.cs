using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;
using System.Collections.Generic;
using System.Linq;

namespace dnd_domain.Items.Store;

public static class ItemsStore
{
    public static List<Item> GetAvailableItems(HashSet<string> itemIds)
    {
        return Items.Where(i => !i.IsUnique || !itemIds.Contains(i.Id))
                    .ToList();
    }

    private static IReadOnlyCollection<Item> Items =>
    [
        .. ArtifactsStore.Items,
        .. _chestTraps,
        .. _potions,
        .. SpellsStore.Items,
        .. WeaponsStore.Items
    ];

    private static readonly IReadOnlyCollection<ChestTrap> _chestTraps =
    [
        new ChestTrap
        {
            Name = "Brume étouffante",
            Description = "Une brume qui rend la respiration difficile.",
            Explanation = "Toutes les créatures vivantes situées dans la pièce perdent 1 point de vie. N'affecte pas les morts-vivants.",
            Level = 1,
            Type = ItemType.None,
            Effects =
            [
                new Effect { Type = EffectType.DoesNotAffectUndeads },
                new Effect { Type = EffectType.DecreaseAllPlayersLifePoints, Amount = 1 },
            ]
        },
        new ChestTrap
        {
            Name = "Couverture de flammes",
            Description = "Une intense chaleur vous encercle.",
            Explanation = "Vous perdez 2 points de vie et le Héros le plus proche de vous perd 2 points de vie aussi.",
            Level = 3,
            Type = ItemType.None,
            Effects =
            [
                new Effect { Type = EffectType.DecreaseHeroLifePoints, Amount = 2 },
                new Effect { Type = EffectType.DecreaseHeroNearByLifePoints, Amount = 2 },
            ]
        },
        new ChestTrap
        {
            Name = "Voix des damnés",
            Description = "Des forces invisibles contrôlent votre esprit.",
            Explanation = "Vous vous déplacez près du Héros le plus proche et attaquez avec votre arme équipée.",
            Level = 1,
            Type = ItemType.None,
            Effects =
            [
                new Effect { Type = EffectType.MoveToRandomHero },
                new Effect { Type = EffectType.AttackRandomHeroNearBy },
            ]
        },
        new ChestTrap
        {
            Name = "Lumière aveuglante",
            Description = "Vous êtes aveuglé par un flash de lumière intense.",
            Explanation = "Vous passez votre prochain tour.",
            Level = 1,
            Type = ItemType.None,
            Effects =
            [
                new Effect { Type = EffectType.SkipNextTurn },
            ]
        },
        new ChestTrap
        {
            Name = "Appel de la tombe",
            Description = "Un pouvoir fantomatique.",
            Explanation = "Vous ranimez le dernier monstre vaincu.",
            Level = 1,
            Type = ItemType.None,
            Effects =
            [
                new Effect { Type = EffectType.ReviveLastDeadMonster },
            ]
        },
        new ChestTrap
        {
            Name = "Trahison brutale",
            Description = "Un terrible sortilège est lancé.",
            Explanation = "Choisissez de subir 5 points de dégâts ou de faire subir 3 points de dégâts à un autre Héros aléatoirement choisi.",
            Level = 2,
            Type = ItemType.None,
            Effects =
            [
                new Effect { Type = EffectType.Lose5LifePointsOrRandomHeroLoses3LifePoints },
            ]
        },
        new ChestTrap
        {
            Name = "Perte de magie",
            Description = "Vous avez pénétré dans un champ de faiblesse magique.",
            Explanation = "Vous perdez 4 points de sort.",
            Level = 3,
            Type = ItemType.None,
            Effects =
            [
                new Effect { Type = EffectType.DecreaseHeroManaPoints, Amount = 4 },
            ]
        }
    ];

    private static readonly IReadOnlyCollection<Item> _potions =
    [
        new Potion
        {
            Name = "Potion de faiblesse",
            Description = "Buvez cette potion pour affaiblir un monstre.",
            Explanation = "Réduisez la classe d'armure d'un monstre de 2 jusqu'au début du prochain tour du Maître du Donjon.",
            Level = 1,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.DecreaseMonsterShieldUntilNextDMTurn, Amount = 2 },
            ]
        },
        new Potion
        {
            Name = "Potion de soins importants",
            Description = "Buvez cette potion pour raviver vos forces.",
            Explanation = "Récupérez un maximum de 5 points de vie.",
            Level = 3,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.IncreaseHeroLifePoints, Amount = 5 },
            ]
        },
        new Potion
        {
            Name = "Potion de soins légers",
            Description = "Buvez cette potion pour raviver vos forces.",
            Explanation = "Récupérez un maximum de 3 points de vie.",
            Level = 1,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.IncreaseHeroLifePoints, Amount = 3 },
            ]
        },
        new Potion
        {
            Name = "Potion de soins modérés",
            Description = "Buvez cette potion pour raviver vos forces.",
            Explanation = "Récupérez un maximum de 4 points de vie.",
            Level = 2,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.IncreaseHeroLifePoints, Amount = 4 },
            ]
        },
        new Potion
        {
            Name = "Potion de cercle de guérison",
            Description = "Buvez cette potion pour former un cercle de guérison autour de tous les Héros.",
            Explanation = "Faites récupérer un maximum de 2 points de vie à chaque Héros.",
            Level = 3,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.IncreaseAllHeroesLifePoints, Amount = 2 },
            ]
        },
        new Potion
        {
            Name = "Potion de restauration suprême",
            Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
            Explanation = "Récupérez un maximum de 5 points de mana.",
            Level = 3,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.IncreaseManaPoints, Amount = 5 },
            ]
        },
        new Potion
        {
            Name = "Potion de restauration partielle",
            Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
            Explanation = "Récupérez un maximum de 3 points de mana.",
            Level = 1,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.IncreaseManaPoints, Amount = 3 },
            ]
        },
        new Potion
        {
            Name = "Potion de restauration",
            Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
            Explanation = "Récupérez un maximum de 4 points de mana.",
            Level = 2,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.IncreaseManaPoints, Amount = 4 },
            ]
        },
        new Potion
        {
            Name = "Potion d'ombre fumigène",
            Description = "Buvez cette potion pour matérialiser un nuage épais autour de tous les monstres de la pièce.",
            Explanation = "Chaque héros présent dans la pièce peut effectuer un déplacement gratuit immédiatement.",
            Level = 1,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.IncreaseAllHeroesFootSteps, Amount = 1 },
            ]
        },
        new Potion
        {
            Name = "Potion de résurrection suprême",
            Description = "Ramenez un Héros à la vie et redonnez lui 4 points de vie et 4 points de sort, si possible.",
            Explanation = "Vous devez être à côté du Héros mort pour utiliser cette potion.",
            Level = 1,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.ReviveHeroWith4LPAnd4MP },
            ]
        },
        new Potion
        {
            Name = "Potion de faiblesse suprême",
            Description = "Buvez cette potion pour affaiblir les monstres.",
            Explanation = "Réduisez de 2 la classe d'armure de tous les monstres situés dans la pièce jusqu'au début du prochain tour du Maître du Donjon.",
            Level = 3,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.DecreaseAllMonstersShieldsUntilNextDMTurn, Amount = 2 },
            ]
        },
        new Potion
        {
            Name = "Potion de main impérieuse",
            Description = "Buvez cette potion pour appeler de l'aide.",
            Explanation = "Déplacez n'importe quel monstre à l'endroit de votre choix, dans la pièce où il se trouve.",
            Level = 1,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.MoveMonsterToChosenSquare },
            ]
        },
        new Potion
        {
            Name = "Potion d'attaque soudaine",
            Description = "Buvez cette potion pour accroître la force de tous les Héros pendant un tour.",
            Explanation = "Infligez 2 points de dégâts à n'importe quel monstre dans la pièce.",
            Level = 2,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.DecreaseMonsterLifePoints, Amount = 2 },
            ]
        },
        new Potion
        {
            Name = "Potion de montée d'adrénaline",
            Description = "Buvez cette potion pour accélérer vos réactions.",
            Explanation = "Vous attaquez immédiatement, même si ce n'est pas votre tour.",
            Level = 2,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.HeroCanAttackImmediatly },
            ]
        },
        new Potion
        {
            Name = "Potion de la sagesse d'Olidammara",
            Description = "Buvez cette potion quand un piège se déclenche.",
            Explanation = "Le piège n'a aucun effet.",
            Level = 1,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.HeroCanDismissTrapEffect },
            ]
        },
        new Potion
        {
            Name = "Potion de bénédiction de Kord",
            Description = "Buvez cette potion pour bénir l'une de vos armes.",
            Explanation = "Double la puissance de l'arme choisie lors de sa prochaine attaque.",
            Level = 1,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.DoubleWeaponStrengthForNextAttack },
            ]
        },
        new Potion
        {
            Name = "Potion d'introspection",
            Description = "Buvez cette potion pour revenir en arrière dans le temps.",
            Explanation = "Relancez le dernier dé joué.",
            Level = 3,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.RelaunchAttack },
            ]
        },
        new Potion
        {
            Name = "Potion de fou rire",
            Description = "Buvez cette potion pour provoquer la chute d'un monstre situé dans la pièce.",
            Explanation = "Le monstre passe son prochain tour.",
            Level = 1,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.DismissesNextTurnOfMonster },
            ]

        },
        new Potion
        {
            Name = "Potion d'arrêt du temps",
            Description = "Buvez cette potion pour arrêter le temps pour vos ennemis.",
            Explanation = "Tous les monstres situés dans la pièce passent leur prochain tour.",
            Level = 2,
            Type = ItemType.Potion,
            Effects =
            [
                new Effect { Type = EffectType.DismissesNextTurnOfAllMonsters },
            ]
        }
    ];
}
