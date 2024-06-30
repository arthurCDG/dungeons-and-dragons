using dnd_domain.Items.Enums;
using dnd_domain.Items.Services;
using dnd_infra.Items.DALs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Seeder;

internal sealed class ItemsSeederService : IItemsSeederService
{
    private readonly GlobalDbContext _context;

    public ItemsSeederService(GlobalDbContext globalDbContext)
    {
        _context = globalDbContext ?? throw new ArgumentNullException(nameof(globalDbContext));
    }

    public async Task SeedAsync()
    {
        await SeedArtifactsAsync();
        await SeedChestTrapsAsync();
        await SeedPotionsAsync();
        await SeedWeaponsAsync();
        await SeedSpellsAsync();
    }

    private async Task SeedArtifactsAsync()
    {
        List<ArtifactDal> artifacts =
        [
            new ArtifactDal
            {
                Name = "Amulette de Yondalla",
                Description = "Couverte de symboles magiques.",
                Explanation = "Quand vous ouvrez un coffre, vous pouvez garder l'objet trouvé, ou vous en défausser et en choisir un autre.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.CanDiscardChestItemToPickAnotherOne, Amount = 1 },
                ]
            },
            new ArtifactDal
            {
                Name = "Fortune de Yondalla",
                Description = "Des runes de protection sont serties dans sa pierre.",
                Explanation = "Quand vous ouvrez un coffre, vous avez le choix entre 4 objets. Choisissez en deux que vous gardez. Par ailleurs, les pièges ne vous infligent pas de dégât. Après avoir fait votre choix, lancez le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 3,
                Effects =
                [
                    new EffectDal { Type = EffectType.DiscardAfterUsage, Probability = 40 },
                    new EffectDal { Type = EffectType.PicksTwoOutOfFourChestItems },
                    new EffectDal { Type = EffectType.NotAffectedByTrapsWhilePickingChestItems }
                ]
            },
            new ArtifactDal
            {
                Name = "Anneau des ombres",
                Description = "Passez cet anneau à votre doigt pour disparaître dans les ténèbres du donjon.",
                Explanation = "Déplacez vous où vous le désirez dans la pièce sans être détecté. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.DiscardAfterUsage, Probability = 40 },
                    new EffectDal { Type = EffectType.IsUndetectableInNextRound },
                ]
            },
            new ArtifactDal
            {
                Name = "Cape en peau d'écorce",
                Description = "Composée de l'écorce des arbres magiques de Arnholm, cette cape légère vous protège.",
                Explanation = "Portez cette cape pour ne pas subir de dégâts lors d'une attaque ou d'un événement. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.DiscardAfterUsage, Probability = 40 },
                    new EffectDal { Type = EffectType.DismissAllAttacks },
                ]
            },
            new ArtifactDal
            {
                Name = "Bouclier du chaos",
                Description = "Forgé dans un moment de rage par les nains, ce bouclier agit de manière imprévisible.",
                Explanation = "Redirigez les dégâts que vous devez subir sur les points de vie d'un autre héros. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 2,
                Effects =
                [
                    new EffectDal { Type = EffectType.DiscardAfterUsage, Probability = 40 },
                    new EffectDal { Type = EffectType.AttackReflectsBackToAttacker },
                ]
            },
            new ArtifactDal
            {
                Name = "Amulette d'Olidammara",
                Description = "Elle renferme la sagesse de nombreux anciens.",
                Explanation = "Permet au porteur de chercher des pièges dans la salle.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.CanCastTrapFinderDie }
                ]
            },
            new ArtifactDal
            {
                Name = "Orbe de vision lucide",
                Description = "Il appartenait autrefois à de sages seigneurs à qui il offrait ses dons de vision.",
                Explanation = "Révelez tous les pièges dans la pièce. L'artefact disparaît après son utilisation.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.DiscardAfterUsage },
                    new EffectDal { Type = EffectType.RevealRoomTraps }
                ]
            },
            new ArtifactDal
            {
                Name = "Bouclier miroir elfe",
                Description = "Découvert au fond d'une fontaine elfe, il réfléchit l'image de tout ce qu'il voit.",
                Explanation = "L'attaquant subit les dégâts du jet de dé à votre place. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 3,
                Effects =
                [
                    new EffectDal { Type = EffectType.DiscardAfterUsage, Probability = 40 },
                    new EffectDal { Type = EffectType.AttackReflectsBackToAttacker },
                ]
            },
            new ArtifactDal
            {
                Name = "Cape de Boccob",
                Description = "Les enchantements tissés dans cette cape permettent d'absorber les attaques physiques.",
                Explanation = "Augmente la classe d'armure de 1 pour ce tour. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.DiscardAfterUsage, Probability = 40 },
                    new EffectDal { Type = EffectType.IncreaseShield, Amount = 1 },
                ]
            },
            new ArtifactDal
            {
                Name = "Cor de l'invocateur",
                Description = "Soufflez fort pour appeler de l'aide.",
                Explanation = "Déplacez n'importe quel héros sur une case près de vous. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.DiscardAfterUsage, Probability = 40 },
                    new EffectDal { Type = EffectType.CanInvokeHeroNearBy, Amount = 1 },
                ]
            }
        ];

        _context.Artifacts.AddRange(artifacts);
        await _context.SaveChangesAsync();
    }

    private async Task SeedChestTrapsAsync()
    {
        List<ChestTrapDal> chestTraps =
        [
            new ChestTrapDal
            {
                Name = "Brume étouffante",
                Description = "Une brume qui rend la respiration difficile.",
                Explanation = "Toutes les créatures vivantes situées dans la pièce perdent 1 point de vie. N'affecte pas les morts-vivants.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.DoesNotAffectUndeads },
                    new EffectDal { Type = EffectType.DecreaseAllPlayersLifePoints, Amount = 1 },
                ]               
            },
            new ChestTrapDal
            {
                Name = "Couverture de flammes",
                Description = "Une intense chaleur vous encercle.",
                Explanation = "Vous perdez 2 points de vie et le Héros le plus proche de vous perd 2 points de vie aussi.",
                Level = 3,
                Effects =
                [
                    new EffectDal { Type = EffectType.DecreaseHeroLifePoints, Amount = 2 },
                    new EffectDal { Type = EffectType.DecreaseHeroNearByLifePoints, Amount = 2 },
                ]
            },
            new ChestTrapDal
            {
                Name = "Voix des damnés",
                Description = "Des forces invisibles contrôlent votre esprit.",
                Explanation = "Vous vous déplacez près du Héros le plus proche et attaquez avec votre arme équipée.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.MoveToRandomHero },
                    new EffectDal { Type = EffectType.AttackRandomHeroNearBy },
                ]
            },
            new ChestTrapDal
            {
                Name = "Lumière aveuglante",
                Description = "Vous êtes aveuglé par un flash de lumière intense.",
                Explanation = "Vous passez votre prochain tour.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.SkipNextTurn },
                ]
            },
            new ChestTrapDal
            {
                Name = "Appel de la tombe",
                Description = "Un pouvoir fantomatique.",
                Explanation = "Vous ranimez le dernier monstre vaincu.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.ReviveLastDeadMonster },
                ]
            },
            new ChestTrapDal
            {
                Name = "Trahison brutale",
                Description = "Un terrible sortilège est lancé.",
                Explanation = "Choisissez de subir 5 points de dégâts ou de faire subir 3 points de dégâts à un autre Héros aléatoirement choisi.",
                Level = 2,
                Effects =
                [
                    new EffectDal { Type = EffectType.Lose5LifePointsOrRandomHeroLoses3LifePoints },
                ]
            },
            new ChestTrapDal
            {
                Name = "Perte de magie",
                Description = "Vous avez pénétré dans un champ de faiblesse magique.",
                Explanation = "Vous perdez 4 points de sort.",
                Level = 3,
                Effects =
                [
                    new EffectDal { Type = EffectType.DecreaseHeroManaPoints, Amount = 4 },
                ]
            }
        ];

        _context.ChestTraps.AddRange(chestTraps);
        await _context.SaveChangesAsync();
    }

    private async Task SeedPotionsAsync()
    {
        List<PotionDal> potions =
        [
            new PotionDal
            {
                Name = "Potion de faiblesse",
                Description = "Buvez cette potion pour affaiblir un monstre.",
                Explanation = "Réduisez la classe d'armure d'un monstre de 2 jusqu'au début du prochain tour du Maître du Donjon.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.DecreaseMonsterShieldUntilNextDMTurn, Amount = 2 },
                ]
            },
            new PotionDal
            {
                Name = "Potion de soins importants",
                Description = "Buvez cette potion pour raviver vos forces.",
                Explanation = "Récupérez un maximum de 5 points de vie.",
                Level = 3,
                Effects =
                [
                    new EffectDal { Type = EffectType.IncreaseHeroLifePoints, Amount = 5 },
                ]
            },
            new PotionDal
            {
                Name = "Potion de soins légers",
                Description = "Buvez cette potion pour raviver vos forces.",
                Explanation = "Récupérez un maximum de 3 points de vie.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.IncreaseHeroLifePoints, Amount = 3 },
                ]
            },
            new PotionDal
            {
                Name = "Potion de soins modérés",
                Description = "Buvez cette potion pour raviver vos forces.",
                Explanation = "Récupérez un maximum de 4 points de vie.",
                Level = 2,
                Effects =
                [
                    new EffectDal { Type = EffectType.IncreaseHeroLifePoints, Amount = 4 },
                ]
            },
            new PotionDal
            {
                Name = "Potion de cercle de guérison",
                Description = "Buvez cette potion pour former un cercle de guérison autour de tous les Héros.",
                Explanation = "Faites récupérer un maximum de 2 points de vie à chaque Héros.",
                Level = 3,
                Effects =
                [
                    new EffectDal { Type = EffectType.IncreaseAllHeroesLifePoints, Amount = 2 },
                ]
            },
            new PotionDal
            {
                Name = "Potion de restauration suprême",
                Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
                Explanation = "Récupérez un maximum de 5 points de mana.",
                Level = 3,
                Effects =
                [
                    new EffectDal { Type = EffectType.IncreaseManaPoints, Amount = 5 },
                ]
            },
            new PotionDal
            {
                Name = "Potion de restauration partielle",
                Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
                Explanation = "Récupérez un maximum de 3 points de mana.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.IncreaseManaPoints, Amount = 3 },
                ]
            },
            new PotionDal
            {
                Name = "Potion de restauration",
                Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
                Explanation = "Récupérez un maximum de 4 points de mana.",
                Level = 2,
                ImageUrl = "",
                Effects =
                [
                    new EffectDal { Type = EffectType.IncreaseManaPoints, Amount = 4 },
                ]
            },
            new PotionDal
            {
                Name = "Potion d'ombre fumigène",
                Description = "Buvez cette potion pour matérialiser un nuage épais autour de tous les monstres de la pièce.",
                Explanation = "Chaque héros présent dans la pièce peut effectuer un déplacement gratuit immédiatement.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.IncreaseAllHeroesFootSteps, Amount = 1 },
                ]
            },
            new PotionDal
            {
                Name = "Potion de résurrection suprême",
                Description = "Ramenez un Héros à la vie et redonnez lui 4 points de vie et 4 points de sort, si possible.",
                Explanation = "Vous devez être à côté du Héros mort pour utiliser cette potion.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.ReviveHeroWith4LPAnd4MP },
                ]
            },
            new PotionDal
            {
                Name = "Potion de faiblesse suprême",
                Description = "Buvez cette potion pour affaiblir les monstres.",
                Explanation = "Réduisez de 2 la classe d'armure de tous les monstres situés dans la pièce jusqu'au début du prochain tour du Maître du Donjon.",
                Level = 3,
                Effects =
                [
                    new EffectDal { Type = EffectType.DecreaseAllMonstersShieldsUntilNextDMTurn, Amount = 2 },
                ]
            },
            new PotionDal
            {
                Name = "Potion de main impérieuse",
                Description = "Buvez cette potion pour appeler de l'aide.",
                Explanation = "Déplacez n'importe quel monstre à l'endroit de votre choix, dans la pièce où il se trouve.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.MoveMonsterToChosenSquare },
                ]
            },
            new PotionDal
            {
                Name = "Potion d'attaque soudaine",
                Description = "Buvez cette potion pour accroître la force de tous les Héros pendant un tour.",
                Explanation = "Infligez 2 points de dégâts à n'importe quel monstre dans la pièce.",
                Level = 2,
                Effects =
                [
                    new EffectDal { Type = EffectType.DecreaseMonsterLifePoints, Amount = 2 },
                ]
            },
            new PotionDal
            {
                Name = "Potion de montée d'adrénaline",
                Description = "Buvez cette potion pour accélérer vos réactions.",
                Explanation = "Vous attaquez immédiatement, même si ce n'est pas votre tour.",
                Level = 2,
                Effects =
                [
                    new EffectDal { Type = EffectType.HeroCanAttackImmediatly },
                ]
            },
            new PotionDal
            {
                Name = "Potion de la sagesse d'Olidammara",
                Description = "Buvez cette potion quand un piège se déclenche.",
                Explanation = "Le piège n'a aucun effet.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.HeroCanDismissTrapEffect },
                ]
            },
            new PotionDal
            {
                Name = "Potion de bénédiction de Kord",
                Description = "Buvez cette potion pour bénir l'une de vos armes.",
                Explanation = "Double la puissance de l'arme choisie lors de sa prochaine attaque.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.DoubleWeaponStrengthForNextAttack },
                ]
            },
            new PotionDal
            {
                Name = "Potion d'introspection",
                Description = "Buvez cette potion pour revenir en arrière dans le temps.",
                Explanation = "Relancez le dernier dé joué.",
                Level = 3,
                Effects =
                [
                    new EffectDal { Type = EffectType.RelaunchAttack },
                ]
            },
            new PotionDal
            {
                Name = "Potion de fou rire",
                Description = "Buvez cette potion pour provoquer la chute d'un monstre situé dans la pièce.",
                Explanation = "Le monstre passe son prochain tour.",
                Level = 1,
                Effects =
                [
                    new EffectDal { Type = EffectType.DismissesNextTurnOfMonster },
                ]
                
            },
            new PotionDal
            {
                Name = "Potion d'arrêt du temps",
                Description = "Buvez cette potion pour arrêter le temps pour vos ennemis.",
                Explanation = "Tous les monstres situés dans la pièce passent leur prochain tour.",
                Level = 2,
                Effects =
                [
                    new EffectDal { Type = EffectType.DismissesNextTurnOfAllMonsters },
                ]
            }
        ];

        _context.Potions.AddRange(potions);
        await _context.SaveChangesAsync();
    }

    // Yellow die: 0-1
    // Orange die : 1-2
    // Red die : 0-3
    // Violet die : 2-4
    // Star die : 33%
    // Dismiss traps : 66%
    // Reveal traps : 66%
    // Undead : 0-2
    private async Task SeedWeaponsAsync()
    {
        List<WeaponDal> weapons =
        [
            new WeaponDal
            {
                Name = "Arc long composite",
                Description = "Fabriqué à l'aide de deux matériaux légers, mais particulièrement résistants, cet arc est très flexible et extrêmement puissant.",
                Explanation = "",
                Level = 2,
                Type = WeaponType.RangedWeapon,
                MaximumDamage = 4,
                MinimumDamage = 1
            },
            new WeaponDal
            {
                Name = "Arc court des anciens",
                Description = "Fabriqué avec le bois d'if le plus vieux de la Forêt des elfes anciens.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Type = WeaponType.RangedWeapon,
                MaximumDamage = 2,
                MinimumDamage = 0,
                Effects =
                [
                    new EffectDal { Type = EffectType.IncreaseManaPoints, Amount = 1, Probability = 33 }
                ]
            },
            new WeaponDal
            {
                Name = "Epée large",
                Description = "Une lame puissante et légère, bien équilibrée, parfaite pour le combat au corps à corps.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Type = WeaponType.HeavyMeleeWeapon,
                MaximumDamage = 2,
                MinimumDamage = 1
            },
            new WeaponDal
            {
                Name = "Arbalète de la foi",
                Description = "Enchantée par les runes de Pélor, ses carreaux ne manquent jamais leur cible.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Type = WeaponType.RangedWeapon,
                MaximumDamage = 2,
                MinimumDamage = 0,
                Effects =
                [
                    new EffectDal { Type = EffectType.IncreaseManaPoints, Amount = 1, Probability = 33 }
                ]
            },
            new WeaponDal
            {
                Name = "Dague de lancer équilibrée",
                Description = "Bien équilibrée pour plus de précision.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Type = WeaponType.RangedWeapon,
                MaximumDamage = 2,
                MinimumDamage = 0
            },
            new WeaponDal
            {
                Name = "Masse brutale",
                Description = "Lourde, puissante, mais imprécise.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Type = WeaponType.HeavyMeleeWeapon,
                MaximumDamage = 5,
                MinimumDamage = 0
            },
            new WeaponDal
            {
                Name = "Hâche de guerre émoussée",
                Description = "Parfaite pour le combat rapproché.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Type = WeaponType.MediumMeleeWeapon,
                MaximumDamage = 5,
                MinimumDamage = 1
            },
            new WeaponDal
            {
                Name = "Arbalète d'embuscade",
                Description = "Mobile et particulièrement utile dans les tunnels étroits.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Type = WeaponType.RangedWeapon,
                MaximumDamage = 4,
                MinimumDamage = 0
            },
            new WeaponDal
            {
                Name = "Fléau d'armes fangeux",
                Description = "Usée par le temps, elle cause encore beaucoup de dommages à son adversaire.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Type = WeaponType.LightMeleeWeapon,
                MaximumDamage = 4,
                MinimumDamage = 1
            },
        ];

        _context.Weapons.AddRange(weapons);
        await _context.SaveChangesAsync();

        WeaponSuperAttackDal superAttackDal = new()
        {
            WeaponId = weapons.Where(w => w.Name == "Dague de lancer équilibrée").Select(w => w.Id).Single(),
            MaximumDamage = 4,
            MinimumDamage = 1,
            Effects =
            [
                new EffectDal { Type = EffectType.DiscardAfterUsage, Probability = 33 }
            ]
        };

        _context.Add(superAttackDal);
        await _context.SaveChangesAsync();
    }

    private async Task SeedSpellsAsync()
    {
        List<SpellDal> spells =
        [
            new SpellDal
            {
                Name = "Restauration suprême",
                Description = "Ramenez un Héros à la vie et redonnez lui 4 points de vie et 4 points de sort, si possible.",
                Explanation = "Placez vous à côté du Héros mort pour lancer le sort.",
                Level = 1,
                ImageUrl = "",
                ManaCost = 4,
                IsMeleeSpellOnly = true,
                Type = SpellType.Revive,
                Effects =
                [
                    new EffectDal { Type = EffectType.ReviveAnHeroWith4LifePointsAnd4ManaPoints }
                ]
            },
            new SpellDal
            {
                Name = "Mains brûlantes",
                Description = "Des gerbes de feu jaillissent de vos doigts, brûlant tout sur leur passage.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                ManaCost = 3,
                Type = SpellType.Revive,
                MaximumDamage = 5,
                MinimumDamage = 1
            },
            new SpellDal
            {
                Name = "Projectile magique",
                Description = "De l'énergie brute projetée par votre main.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                ManaCost = 2,
                Type = SpellType.Attack,
                MaximumDamage = 4,
                MinimumDamage = 0
            }
        ];

        _context.Spells.AddRange(spells);
        await _context.SaveChangesAsync();
    }
}
