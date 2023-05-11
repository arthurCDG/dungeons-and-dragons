using dnd_domain.Dice;
using dnd_domain.Items.Enums;
using dnd_infra.Dice;
using dnd_infra.Items.DALs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_infra.Seeder;

internal sealed class ItemsSeeder
{
    private readonly GlobalDbContext _context;

    public ItemsSeeder(GlobalDbContext globalDbContext)
    {
        _context = globalDbContext ?? throw new ArgumentNullException(nameof(globalDbContext));
    }

    public async Task SeedItemsAsync(int sessionId)
    {
        await SeedArtefactsAsync(sessionId);
        await SeedChestTrapsAsync(sessionId);
        await SeedPotionsAsync(sessionId);
        await SeedSpellsAsync(sessionId);
        await SeedWeaponsAsync(sessionId);
    }

    private async Task SeedArtefactsAsync(int sessionId)
    {
        var toto = sessionId;

        List<ArtefactDal> artefacts = new()
        {
            new ArtefactDal
            {
                SessionId = sessionId,
                Name = "Amulette de Yondalla",
                Description = "Couverte de symboles magiques.",
                Explanation = "Quand vous ouvrez un coffre, vous pouvez garder l'objet trouvé, ou vous en défausser et en choisir un autre.",
                Level = 1,
                ImageUrl = "",
                DiscardAfterUsage = false,
                CastDieToDiscardAfterUsage = false,
                Effects = new()
                {
                    new ArtefactEffectDal { Effect = ArtefactEffectType.CanDiscardChestItemToPickAnotherOneOneTime }
                }
            },
            new ArtefactDal
            {
                SessionId = sessionId,
                Name = "Fortune de Yondalla",
                Description = "Des runes de protection sont serties dans sa pierre.",
                Explanation = "Quand vous ouvrez un coffre, vous avez le choix entre 4 objets. Choisissez en deux que vous gardez. Par ailleurs, les pièges ne vous infligent pas de dégât. Après avoir fait votre choix, lancez le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 3,
                ImageUrl = "",
                DiscardAfterUsage = false,
                CastDieToDiscardAfterUsage = true,
                Effects = new()
                {
                    new ArtefactEffectDal { Effect = ArtefactEffectType.PicksTwoOutOfFourChestItems },
                    new ArtefactEffectDal { Effect = ArtefactEffectType.NotAffectedByTrapsWhilePickingChestItems }
                }
            },
            new ArtefactDal
            {
                SessionId = sessionId,
                Name = "Anneau des ombres",
                Description = "Passez cet anneau à votre doigt pour disparaître dans les ténèbres du donjon.",
                Explanation = "Déplacez vous où vous le désirez dans la pièce sans être détecté. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 1,
                ImageUrl = "",
                DiscardAfterUsage = false,
                CastDieToDiscardAfterUsage = true,
                Effects = new()
                {
                    new ArtefactEffectDal { Effect = ArtefactEffectType.IsUndetectableInNextRound }
                }
            },
            new ArtefactDal
            {
                SessionId = sessionId,
                Name = "Cape en peau d'écorce",
                Description = "Composée de l'écorce des arbres magiques de Arnholm, cette cape légère vous protège.",
                Explanation = "Portez cette cape pour ne pas subir de dégâts lors d'une attaque ou d'un événement. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 1,
                ImageUrl = "",
                DiscardAfterUsage = false,
                CastDieToDiscardAfterUsage = true,
                Effects = new()
                {
                    new ArtefactEffectDal { Effect = ArtefactEffectType.DismissAllAttacks }
                }
            },
            new ArtefactDal
            {
                SessionId = sessionId,
                Name = "Bouclier du chaos",
                Description = "Forgé dans un moment de rage par les nains, ce bouclier agit de manière imprévisible.",
                Explanation = "Redirigez les dégâts que vous devez subir sur les points de vie d'un autre héros. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 2,
                ImageUrl = "",
                DiscardAfterUsage = false,
                CastDieToDiscardAfterUsage = true,
                Effects = new()
                {
                    new ArtefactEffectDal { Effect = ArtefactEffectType.AttackReflectsBackToAttacker }
                }
            },
            new ArtefactDal
            {
                SessionId = sessionId,
                Name = "Amulette d'Olidammara",
                Description = "Elle renferme la sagesse de nombreux anciens.",
                Explanation = "Permet au porteur de chercher des pièges dans la salle.",
                Level = 1,
                ImageUrl = "",
                DiscardAfterUsage = false,
                CastDieToDiscardAfterUsage = false,
                Effects = new()
                {
                    new ArtefactEffectDal { Effect = ArtefactEffectType.CanCastTrapFinderDie }
                }
            },
            new ArtefactDal
            {
                SessionId = sessionId,
                Name = "Orbe de vision lucide",
                Description = "Il appartenait autrefois à de sages seigneurs à qui il offrait ses dons de vision.",
                Explanation = "Révelez tous les pièges dans la pièce. L'artefact disparaît après son utilisation.",
                Level = 1,
                ImageUrl = "",
                DiscardAfterUsage = true,
                CastDieToDiscardAfterUsage = false,
                Effects = new()
                {
                    new ArtefactEffectDal { Effect = ArtefactEffectType.RevealRoomTraps }
                }
            },
            new ArtefactDal
            {
                SessionId = sessionId,
                Name = "Bouclier miroir elfe",
                Description = "Découvert au fond d'une fontaine elfe, il réfléchit l'image de tout ce qu'il voit.",
                Explanation = "L'attaquant subit les dégâts du jet de dé à votre place. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 3,
                ImageUrl = "",
                DiscardAfterUsage = false,
                CastDieToDiscardAfterUsage = true,
                Effects = new()
                {
                    new ArtefactEffectDal { Effect = ArtefactEffectType.AttackReflectsBackToAttacker }
                }
            },
            new ArtefactDal
            {
                SessionId = sessionId,
                Name = "Cape de Boccob",
                Description = "Les enchantements tissés dans cette cape permettent d'absorber les attaques physiques.",
                Explanation = "Augmente la classe d'armure de 1 pour ce tour. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 1,
                ImageUrl = "",
                DiscardAfterUsage = false,
                CastDieToDiscardAfterUsage = true,
                Effects = new()
                {
                    new ArtefactEffectDal { Effect = ArtefactEffectType.IncreaseHeroShieldBy1 }
                }
            },
            new ArtefactDal
            {
                SessionId = sessionId,
                Name = "Cor de l'invocateur",
                Description = "Soufflez fort pour appeler de l'aide.",
                Explanation = "Déplacez n'importe quel héros sur une case près de vous. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
                Level = 1,
                ImageUrl = "",
                DiscardAfterUsage = false,
                CastDieToDiscardAfterUsage = true,
                Effects = new()
                {
                    new ArtefactEffectDal { Effect = ArtefactEffectType.CanInvokeHeroNearBy }
                }
            }
        };

        _context.Artefacts.AddRange(artefacts);
        await _context.SaveChangesAsync();
    }

    private async Task SeedChestTrapsAsync(int sessionId)
    {
        List<ChestTrapDal> chestTraps = new()
        {
            new ChestTrapDal
            {
                SessionId = sessionId,
                Name = "Brume étouffante",
                Description = "Une brume qui rend la respiration difficile.",
                Explanation = "Toutes les créatures vivantes situées dans la pièce perdent 1 point de vie. N'affecte pas les morts-vivants.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new ChestTrapEffectDal { Effect = ChestTrapEffectType.DecreaseAllCreaturesLifePointsBy1 },
                    new ChestTrapEffectDal { Effect = ChestTrapEffectType.DoesNotAffectUndeads }
                }
            },
            new ChestTrapDal
            {
                SessionId = sessionId,
                Name = "Couverture de flammes",
                Description = "Une intense chaleur vous encercle.",
                Explanation = "Vous perdez 2 points de vie et le Héros le plus proche de vous perd 2 points de vie aussi.",
                Level = 3,
                ImageUrl = "",
                Effects = new()
                {
                    new ChestTrapEffectDal { Effect = ChestTrapEffectType.DecreaseHeroLifePointsBy2 },
                    new ChestTrapEffectDal { Effect = ChestTrapEffectType.DecreaseHeroNearByLifePointsBy2 }
                }
            },
            new ChestTrapDal
            {
                SessionId = sessionId,
                Name = "Voix des damnés",
                Description = "Des forces invisibles contrôlent votre esprit.",
                Explanation = "Vous vous déplacez près du Héros le plus proche et attaquez avec votre arme équipée.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new ChestTrapEffectDal { Effect = ChestTrapEffectType.MoveToRandomHero },
                    new ChestTrapEffectDal { Effect = ChestTrapEffectType.AttackRandomHeroNearBy }
                }
            },
            new ChestTrapDal
            {
                SessionId = sessionId,
                Name = "Lumière aveuglante",
                Description = "Vous êtes aveuglé par un flash de lumière intense.",
                Explanation = "Vous passez votre prochain tour.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new ChestTrapEffectDal { Effect = ChestTrapEffectType.SkipNextTurn }
                }
            },
            new ChestTrapDal
            {
                SessionId = sessionId,
                Name = "Appel de la tombe",
                Description = "Un pouvoir fantomatique.",
                Explanation = "Vous ranimez le dernier monstre vaincu.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                     new ChestTrapEffectDal { Effect = ChestTrapEffectType.ReviveLastDeadMonster }
                }
            },
            new ChestTrapDal
            {
                SessionId = sessionId,
                Name = "Trahison brutale",
                Description = "Un terrible sortilège est lancé.",
                Explanation = "Choisissez de subir 5 points de dégâts ou de faire subir 3 points de dégâts à un autre Héros aléatoirement choisi.",
                Level = 2,
                ImageUrl = "",
                Effects = new()
                {
                    new ChestTrapEffectDal { Effect = ChestTrapEffectType.Lose5LifePointsOrRandomHeroLoses3LifePoints }
                }
            },
            new ChestTrapDal
            {
                SessionId = sessionId,
                Name = "Perte de magie",
                Description = "Vous avez pénétré dans un champ de faiblesse magique.",
                Explanation = "Vous perdez 4 points de sort.",
                Level = 3,
                ImageUrl = "",
                Effects = new()
                {
                    new ChestTrapEffectDal { Effect = ChestTrapEffectType.DecreaseHeroManaPointsBy4 }
                }
            }
        };

        _context.ChestTraps.AddRange(chestTraps);
        await _context.SaveChangesAsync();
    }

    private async Task SeedPotionsAsync(int sessionId)
    {
        List<PotionDal> potions = new()
        {
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de faiblesse",
                Description = "Buvez cette potion pour affaiblir un monstre.",
                Explanation = "Réduisez la classe d'armure d'un monstre de 2 jusqu'au début du prochain tour du Maître du Donjon.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.DecreaseMonsterShieldUntilNextDMTurnBy2 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de soins importants",
                Description = "Buvez cette potion pour raviver vos forces.",
                Explanation = "Récupérez un maximum de 5 points de vie.",
                Level = 3,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.IncreaseHeroLifePointsBy5 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de soins légers",
                Description = "Buvez cette potion pour raviver vos forces.",
                Explanation = "Récupérez un maximum de 3 points de vie.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.IncreaseHeroLifePointsBy3 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de soins modérés",
                Description = "Buvez cette potion pour raviver vos forces.",
                Explanation = "Récupérez un maximum de 4 points de vie.",
                Level = 2,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.IncreaseHeroLifePointsBy4 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de cercle de guérison",
                Description = "Buvez cette potion pour former un cercle de guérison autour de tous les Héros.",
                Explanation = "Faites récupérer un maximum de 2 points de vie à chaque Héros.",
                Level = 3,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.IncreaseAllHeroesLifePointsBy2 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de restauration suprême",
                Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
                Explanation = "Récupérez un maximum de 5 points de mana.",
                Level = 3,
                ImageUrl = "",
                Effects= new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.IncreaseHeroManaPointsBy5 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de restauration partielle",
                Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
                Explanation = "Récupérez un maximum de 3 points de mana.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.IncreaseHeroManaPointsBy3 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de restauration",
                Description = "Buvez cette potion pour raviver vos pouvoirs magiques.",
                Explanation = "Récupérez un maximum de 4 points de mana.",
                Level = 2,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.IncreaseHeroManaPointsBy4 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion d'ombre fumigène",
                Description = "Buvez cette potion pour matérialiser un nuage épais autour de tous les monstres de la pièce.",
                Explanation = "Chaque héros présent dans la pièce peut effectuer un déplacement gratuit immédiatement.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.IncreaseAllHeroesFootStepsBy1 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de restauration suprême",
                Description = "Ramenez un Héros à la vie et redonnez lui 4 points de vie et 4 points de sort, si possible.",
                Explanation = "Vous devez être à côté du Héros mort pour utiliser cette potion.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.ReviveHeroWith4LPAnd4MP }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de faiblesse suprême",
                Description = "Buvez cette potion pour affaiblir les monstres.",
                Explanation = "Réduisez de 2 la classe d'armure de tous les monstres situés dans la pièce jusqu'au début du prochain tour du Maître du Donjon.",
                Level = 3,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.DecreaseAllMonstersShieldsUntilNextDMTurnBy2 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de main impérieuse",
                Description = "Buvez cette potion pour appeler de l'aide.",
                Explanation = "Déplacez n'importe quel monstre à l'endroit de votre choix, dans la pièce où il se trouve.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.MoveMonsterToChosenSquare }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion d'attaque soudaine",
                Description = "Buvez cette potion pour accroître la force de tous les Héros pendant un tour.",
                Explanation = "Infligez 2 points de dégâts à n'importe quel monstre dans la pièce.",
                Level = 2,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.DecreaseMonsterLifePointsBy2 }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de montée d'adrénaline",
                Description = "Buvez cette potion pour accélérer vos réactions.",
                Explanation = "Vous attaquez immédiatement, même si ce n'est pas votre tour.",
                Level = 2,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.HeroCanAttackImmediatly }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de la sagesse d'Olidammara",
                Description = "Buvez cette potion quand un piège se déclenche.",
                Explanation = "Le piège n'a aucun effet.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.HeroCanDismissTrapEffect }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de bénédiction de Kord",
                Description = "Buvez cette potion pour bénir l'une de vos armes.",
                Explanation = "Double la puissance de l'arme choisie lors de sa prochaine attaque.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.DoubleWeaponStrengthForNextAttack }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion d'introspection",
                Description = "Buvez cette potion pour revenir en arrière dans le temps.",
                Explanation = "Relancez le dernier dé joué.",
                Level = 3,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.RerollLastCastDie }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion de fou rire",
                Description = "Buvez cette potion pour provoquer la chute d'un monstre situé dans la pièce.",
                Explanation = "Le monstre passe son prochain tour.",
                Level = 1,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.DismissesNextTurnOfMonster }
                }
            },
            new PotionDal
            {
                SessionId = sessionId,
                Name = "Potion d'arrêt du temps",
                Description = "Buvez cette potion pour arrêter le temps pour vos ennemis.",
                Explanation = "Tous les monstres situés dans la pièce passent leur prochain tour.",
                Level = 2,
                ImageUrl = "",
                Effects = new()
                {
                    new PotionEffectDal { Effect = PotionEffectType.DismissesNextTurnOfAllMonsters }
                }
            }
        };

        _context.Potions.AddRange(potions);
        await _context.SaveChangesAsync();
    }

    private async Task SeedSpellsAsync(int sessionId)
    {
        List<WeaponDal> weapons = new()
        {
            new WeaponDal
            {
                SessionId = sessionId,
                Name = "Arc long composite",
                Description = "Fabriqué à l'aide de deux matériaux légers, mais particulièrement résistants, cet arc est très flexible et extrêmement puissant.",
                Explanation = "",
                Level = 2,
                ImageUrl = "",
                Dice = new()
                {
                    new DieAssociationDal() { DieType = DieType.YellowDie },
                    new DieAssociationDal() { DieType = DieType.YellowDie },
                    new DieAssociationDal() { DieType = DieType.OrangeDie }
                }
            },
            new WeaponDal
            {
                SessionId = sessionId,
                Name = "Arc court des anciens",
                Description = "Fabriqué avec le bois d'if le plus vieux de la Forêt des elfes anciens.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Dice = new()
                {
                    new DieAssociationDal() { DieType = DieType.YellowDie },
                    new DieAssociationDal() { DieType = DieType.YellowDie },
                    new DieAssociationDal() { DieType = DieType.StarDie }
                },
                StarDieEffect = StarDieEffectType.IncreaseHeroManaPointsBy1
            },
            new WeaponDal
            {
                SessionId = sessionId,
                Name = "Epée large",
                Description = "Une lame puissante et légère, bien équilibrée, parfaite pour le combat au corps à corps.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Dice = new()
                {
                    new DieAssociationDal() { DieType = DieType.OrangeDie }
                }
            },
            new WeaponDal
            {
                SessionId = sessionId,
                Name = "Arbalète de la foi",
                Description = "Enchantée par les runes de Pélor, ses carreaux ne manquent jamais leur cible.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Dice = new()
                {
                    new DieAssociationDal() { DieType = DieType.YellowDie },
                    new DieAssociationDal() { DieType = DieType.YellowDie },
                    new DieAssociationDal() { DieType = DieType.StarDie }
                },
                StarDieEffect = StarDieEffectType.IncreaseHeroManaPointsBy1
            },
            new WeaponDal
            {
                SessionId = sessionId,
                Name = "Dague de lancer équilibrée",
                Description = "Bien équilibrée pour plus de précision.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                Dice = new()
                {
                    new DieAssociationDal() { DieType = DieType.YellowDie },
                    new DieAssociationDal() { DieType = DieType.YellowDie }
                },
                SuperAttack = new()
                {
                    Type = WeaponSuperAttackType.CastDice,
                    LosesWeaponIfStarDieReturnsStar = true,
                    Dice = new()
                    {
                    new DieAssociationDal() { DieType = DieType.OrangeDie },
                    new DieAssociationDal() { DieType = DieType.OrangeDie },
                    new DieAssociationDal() { DieType = DieType.StarDie }
                    }
                }
            }
        };

        _context.Weapons.AddRange(weapons);
        await _context.SaveChangesAsync();
    }

    private async Task SeedWeaponsAsync(int sessionId)
    {
        List<SpellDal> spells = new()
        {
            new SpellDal
            {
                SessionId = sessionId,
                Name = "Restauration suprême",
                Description = "Ramenez un Héros à la vie et redonnez lui 4 points de vie et 4 points de sort, si possible.",
                Explanation = "Placez vous à côté du Héros mort pour lancer le sort.",
                Level = 1,
                ImageUrl = "",
                ManaCost = 4,
                IsMeleeSpell = true,
                IsDistantSpell = false,
                Type = SpellType.Revive,
                Effects = new()
                {
                    new SpellEffectDal { Effect = SpellEffectType.ReviveAnHeroWith4LifePointsAnd4ManaPoints }
                }
            },
            new SpellDal
            {
                SessionId = sessionId,
                Name = "Mains brûlantes",
                Description = "Des gerbes de feu jaillissent de vos doigts, brûlant tout sur leur passage.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                ManaCost = 3,
                IsMeleeSpell = true,
                IsDistantSpell = true,
                Type = SpellType.Revive,
                Dice = new()
                {
                    new DieAssociationDal() { DieType = DieType.OrangeDie },
                    new DieAssociationDal() { DieType = DieType.RedDie }
                }
            },
            new SpellDal
            {
                SessionId = sessionId,
                Name = "Projectile magique",
                Description = "De l'énergie brute projetée par votre main.",
                Explanation = "",
                Level = 1,
                ImageUrl = "",
                ManaCost = 2,
                IsMeleeSpell = false,
                IsDistantSpell = true,
                Type = SpellType.Attack,
                Dice = new()
                {
                    new DieAssociationDal() { DieType = DieType.YellowDie },
                    new DieAssociationDal() { DieType = DieType.RedDie }
                }
            }
        };

        _context.Spells.AddRange(spells);
        await _context.SaveChangesAsync();
    }
}
