//using dnd_domain.Dice;
//using dnd_domain.Items.Enums;
//using dnd_domain.Players.Enums;
//using dnd_infra.Dice;
//using dnd_infra.Items.DALs;
//using dnd_infra.Players.DALs;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;

//namespace dnd_infra.Seeder;

//internal static class DiceWeaponsSpellsAndMonstersSeeder
//{

//    /* POSSIBLE HELP to add see scripts
//     * DOCUMENTATION TO SEED SPELLS, WEAPONS AND OTHER DEPENDANT ENTITIES FROM DICE
//     * https://stackoverflow.com/questions/50862525/seed-entity-with-owned-property
//     * Try with OwnsOne before HasData ....
//     * **/

//    public static void SeedDiceWeaponsSpellsAndMonsters(this ModelBuilder modelBuilder)
//    {
//        ///*  --- DICE --- **/

//        //List<DieDal> dice = new()
//        //{
//        //    // First Yellow die
//        //    new DieDal { Id = 1, Type = DieType.YellowDie },
//        //    // Orange die
//        //    new DieDal { Id = 2, Type = DieType.OrangeDie },
//        //    // Red die
//        //    new DieDal { Id = 3, Type = DieType.RedDie },
//        //    // Purple die
//        //    new DieDal { Id = 4, Type = DieType.PurpleDie },
//        //    // Star die
//        //    new DieDal { Id = 5, Type = DieType.StarDie },
//        //    // Reveal traps die
//        //    new DieDal { Id = 6, Type = DieType.RevealTrapsDie },
//        //    // Dismiss traps die
//        //    new DieDal { Id = 7, Type = DieType.DismissTrapsDie },
//        //    // Turn undeads die
//        //    new DieDal { Id = 8, Type = DieType.TurnUndeadDie },
//        //     // Second Yellow die
//        //    new DieDal { Id = 9, Type = DieType.YellowDie },
//        //};

//        //modelBuilder.Entity<DieDal>().HasData(dice);

//        //modelBuilder.Entity<DieValueDal>().HasData(
//        //    // First Yellow die
//        //    new DieValueDal { Id = 1, DieId = 1, Value = 0, ImageUrl = "" },
//        //    new DieValueDal { Id = 2, DieId = 1, Value = 0, ImageUrl = "" },
//        //    new DieValueDal { Id = 3, DieId = 1, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 4, DieId = 1, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 5, DieId = 1, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 6, DieId = 1, Value = 1, ImageUrl = "" },
//        //    // First Orange die
//        //    new DieValueDal { Id = 7, DieId = 2, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 8, DieId = 2, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 9, DieId = 2, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 10, DieId = 2, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 11, DieId = 2, Value = 2, ImageUrl = "" },
//        //    new DieValueDal { Id = 12, DieId = 2, Value = 2, ImageUrl = "" },
//        //    // Red die
//        //    new DieValueDal { Id = 13, DieId = 3, Value = 0, ImageUrl = "" },
//        //    new DieValueDal { Id = 14, DieId = 3, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 15, DieId = 3, Value = 2, ImageUrl = "" },
//        //    new DieValueDal { Id = 16, DieId = 3, Value = 2, ImageUrl = "" },
//        //    new DieValueDal { Id = 17, DieId = 3, Value = 2, ImageUrl = "" },
//        //    new DieValueDal { Id = 18, DieId = 3, Value = 3, ImageUrl = "" },
//        //    // Purple die
//        //    new DieValueDal { Id = 19, DieId = 4, Value = 2, ImageUrl = "" },
//        //    new DieValueDal { Id = 20, DieId = 4, Value = 2, ImageUrl = "" },
//        //    new DieValueDal { Id = 21, DieId = 4, Value = 2, ImageUrl = "" },
//        //    new DieValueDal { Id = 22, DieId = 4, Value = 2, ImageUrl = "" },
//        //    new DieValueDal { Id = 23, DieId = 4, Value = 3, ImageUrl = "" },
//        //    new DieValueDal { Id = 24, DieId = 4, Value = 3, ImageUrl = "" },
//        //    // Star die
//        //    new DieValueDal { Id = 25, DieId = 5, SpecialValue = SpecialValue.Empty, ImageUrl = "" },
//        //    new DieValueDal { Id = 26, DieId = 5, SpecialValue = SpecialValue.Empty, ImageUrl = "" },
//        //    new DieValueDal { Id = 27, DieId = 5, SpecialValue = SpecialValue.Empty, ImageUrl = "" },
//        //    new DieValueDal { Id = 28, DieId = 5, SpecialValue = SpecialValue.Star, ImageUrl = "" },
//        //    new DieValueDal { Id = 29, DieId = 5, SpecialValue = SpecialValue.Star, ImageUrl = "" },
//        //    new DieValueDal { Id = 30, DieId = 5, SpecialValue = SpecialValue.Star, ImageUrl = "" },
//        //    // Reveal traps die
//        //    new DieValueDal { Id = 31, DieId = 6, SpecialValue = SpecialValue.Empty, ImageUrl = "" },
//        //    new DieValueDal { Id = 32, DieId = 6, SpecialValue = SpecialValue.Empty, ImageUrl = "" },
//        //    new DieValueDal { Id = 33, DieId = 6, SpecialValue = SpecialValue.OneEye, ImageUrl = "" },
//        //    new DieValueDal { Id = 34, DieId = 6, SpecialValue = SpecialValue.OneEye, ImageUrl = "" },
//        //    new DieValueDal { Id = 35, DieId = 6, SpecialValue = SpecialValue.TwoEyes, ImageUrl = "" },
//        //    new DieValueDal { Id = 36, DieId = 6, SpecialValue = SpecialValue.Hand, ImageUrl = "" },
//        //    // Dismiss traps die
//        //    new DieValueDal { Id = 37, DieId = 7, SpecialValue = SpecialValue.Trap, ImageUrl = "" },
//        //    new DieValueDal { Id = 38, DieId = 7, SpecialValue = SpecialValue.Trap, ImageUrl = "" },
//        //    new DieValueDal { Id = 39, DieId = 7, SpecialValue = SpecialValue.Trap, ImageUrl = "" },
//        //    new DieValueDal { Id = 40, DieId = 7, SpecialValue = SpecialValue.Trap, ImageUrl = "" },
//        //    new DieValueDal { Id = 41, DieId = 7, SpecialValue = SpecialValue.Trap, ImageUrl = "" },
//        //    new DieValueDal { Id = 42, DieId = 7, SpecialValue = SpecialValue.TrapExploded, ImageUrl = "" },
//        //    // Turn undeads trap
//        //    new DieValueDal { Id = 43, DieId = 8, SpecialValue = SpecialValue.Empty, ImageUrl = "" },
//        //    new DieValueDal { Id = 44, DieId = 8, SpecialValue = SpecialValue.Empty, ImageUrl = "" },
//        //    new DieValueDal { Id = 45, DieId = 8, SpecialValue = SpecialValue.Empty, ImageUrl = "" },
//        //    new DieValueDal { Id = 46, DieId = 8, SpecialValue = SpecialValue.OneSkullHead, ImageUrl = "" },
//        //    new DieValueDal { Id = 47, DieId = 8, SpecialValue = SpecialValue.TwoSkullHeads, ImageUrl = "" },
//        //    new DieValueDal { Id = 48, DieId = 8, SpecialValue = SpecialValue.ThreeSkullHeads, ImageUrl = "" },
//        //    // Second Yellow die
//        //    new DieValueDal { Id = 49, DieId = 9, Value = 0, ImageUrl = "" },
//        //    new DieValueDal { Id = 50, DieId = 9, Value = 0, ImageUrl = "" },
//        //    new DieValueDal { Id = 51, DieId = 9, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 52, DieId = 9, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 53, DieId = 9, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 54, DieId = 9, Value = 1, ImageUrl = "" },
//        //    // Second Orange die
//        //    new DieValueDal { Id = 55, DieId = 10, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 56, DieId = 10, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 57, DieId = 10, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 58, DieId = 10, Value = 1, ImageUrl = "" },
//        //    new DieValueDal { Id = 59, DieId = 10, Value = 2, ImageUrl = "" },
//        //    new DieValueDal { Id = 60, DieId = 10, Value = 2, ImageUrl = "" }
//        //);

//        /*  --- WEAPONS --- **/

//        modelBuilder.Entity<WeaponDal>().HasData(
//            new WeaponDal
//            {
//                Id = 1,
//                Name = "Arc long composite",
//                Description = "Fabriqué à l'aide de deux matériaux légers, mais particulièrement résistants, cet arc est très flexible et extrêmement puissant.",
//                Explanation = "",
//                Level = 2,
//                ImageUrl = "",
//                Dice = new() // 2 yellow dice & 1 orange die
//                {
//                    new DieAssociationDal() { Id = 1, DieId = 1, WeaponId = 1 },
//                    new DieAssociationDal() { Id = 2, DieId = 2, WeaponId = 1 },
//                    new DieAssociationDal() { Id = 3, DieId = 9, WeaponId = 1 },
//                }
//            },
//            new WeaponDal
//            {
//                Id = 2,
//                Name = "Arc court des anciens",
//                Description = "Fabriqué avec le bois d'if le plus vieux de la Forêt des elfes anciens.",
//                Explanation = "",
//                Level = 1,
//                ImageUrl = "",
//                Dice = new() // 2 yellow dice & 1 star die
//                {
//                    new DieAssociationDal() { Id = 4, DieId = 1, WeaponId = 2 },
//                    new DieAssociationDal() { Id = 5, DieId = 5, WeaponId = 2 },
//                    new DieAssociationDal() { Id = 6, DieId = 9, WeaponId = 2 },
//                },
//                StarDieEffect = StarDieEffectType.IncreaseHeroManaPointsBy1
//            },
//            new WeaponDal
//            {
//                Id = 3,
//                Name = "Epée large",
//                Description = "Une lame puissante et légère, bien équilibrée, parfaite pour le combat au corps à corps.",
//                Explanation = "",
//                Level = 1,
//                ImageUrl = "",
//                Dice = new() // 1 orange die
//                {
//                    new DieAssociationDal() { Id = 7, DieId = 2, WeaponId = 3 },
//                }
//            },
//            new WeaponDal
//            {
//                Id = 4,
//                Name = "Arbalète de la foi",
//                Description = "Enchantée par les runes de Pélor, ses carreaux ne manquent jamais leur cible.",
//                Explanation = "",
//                Level = 1,
//                ImageUrl = "",
//                Dice = new() // 2 yellow dice & 1 star die
//                {
//                    new DieAssociationDal() { Id = 8, DieId = 1, WeaponId = 4 },
//                    new DieAssociationDal() { Id = 9, DieId = 5, WeaponId = 4 },
//                    new DieAssociationDal() { Id = 10, DieId = 9, WeaponId = 4 },
//                },
//                StarDieEffect = StarDieEffectType.IncreaseHeroManaPointsBy1
//            },
//            new WeaponDal
//            {
//                Id = 5,
//                Name = "Dague de lancer équilibrée",
//                Description = "Bien équilibrée pour plus de précision.",
//                Explanation = "",
//                Level = 1,
//                ImageUrl = "",
//                Dice = new() // 2 yellow dice
//                {
//                    new DieAssociationDal() { Id = 11, DieId = 1, WeaponId = 4 },
//                    new DieAssociationDal() { Id = 12, DieId = 9, WeaponId = 4 },
//                }
//            }
//        );

//        modelBuilder.Entity<WeaponSuperAttackDal>().HasData(
//            // Dague de lancer équilibrée
//            new WeaponSuperAttackDal
//            {
//                Id = 1,
//                WeaponId = 5,
//                Type = WeaponSuperAttackType.CastDice,
//                LosesWeaponIfStarDieReturnsStar = true,
//                Dice = new() // 2 orange dice & 1 star die
//                {
//                    new DieAssociationDal() { Id = 13, DieId = 2, WeaponId = 5 },
//                    new DieAssociationDal() { Id = 14, DieId = 5, WeaponId = 5 },
//                    new DieAssociationDal() { Id = 15, DieId = 10, WeaponId = 5 },
//                }
//            }
//        );

//        /*  --- SPELLS --- **/

//        modelBuilder.Entity<SpellDal>().HasData(
//            new SpellDal
//            {
//                Id = 1,
//                Name = "Restauration suprême",
//                Description = "Ramenez un Héros à la vie et redonnez lui 4 points de vie et 4 points de sort, si possible.",
//                Explanation = "Placez vous à côté du Héros mort pour lancer le sort.",
//                Level = 1,
//                ImageUrl = "",
//                ManaCost = 4,
//                IsMeleeSpell = true,
//                IsDistantSpell = false,
//                Type = SpellType.Revive
//            },
//            new SpellDal
//            {
//                Id = 2,
//                Name = "Mains brûlantes",
//                Description = "Des gerbes de feu jaillissent de vos doigts, brûlant tout sur leur passage.",
//                Explanation = "",
//                Level = 1,
//                ImageUrl = "",
//                ManaCost = 3,
//                IsMeleeSpell = true,
//                IsDistantSpell = true,
//                Type = SpellType.Revive,
//                Dice = new() // 1 orange die & 1 red die
//                {
//                    new DieAssociationDal() { Id = 16, DieId = 2, SpellId = 2 },
//                    new DieAssociationDal() { Id = 17, DieId = 3, SpellId = 2 },
//                }
//            },
//            new SpellDal
//            {
//                Id = 3,
//                Name = "Projectile magique",
//                Description = "De l'énergie brute projetée par votre main.",
//                Explanation = "",
//                Level = 1,
//                ImageUrl = "",
//                ManaCost = 2,
//                IsMeleeSpell = false,
//                IsDistantSpell = true,
//                Type = SpellType.Attack,
//                Dice = new() // 1 yellow die & 1 red die
//                {
//                    new DieAssociationDal() { Id = 18, DieId = 1, SpellId = 3 },
//                    new DieAssociationDal() { Id = 19, DieId = 3, SpellId = 3 },
//                }
//            }
//        );

//        modelBuilder.Entity<SpellEffectDal>().HasData(
//            // Restauration suprême
//            new SpellEffectDal { Id = 1, SpellId = 1, Effect = SpellEffectType.ReviveAnHeroWith4LifePointsAnd4ManaPoints }
//        );

//        /*  --- MONSTERS --- **/

//        modelBuilder.Entity<MonsterDal>().HasData(
//            new MonsterDal
//            {
//                Id = 1,
//                Name = "Gobelours",
//                Type = MonsterType.BugBear,
//                ImageUrl = "",
//                LifePoints = 7,
//                ManaPoints = 0,
//                FootSteps = 4,
//                Shield = 2,
//                MeleeAttackDice = dice.Where(d => d.Id == 1 || d.Id == 3 ||  d.Id == 9).ToList()
//            },
//            new MonsterDal
//            {
//                Id = 2,
//                Name = "Gnoll",
//                Type = MonsterType.Gnoll,
//                ImageUrl = "",
//                LifePoints = 6,
//                ManaPoints = 0,
//                FootSteps = 3,
//                Shield = 2,
//                MeleeAttackDice = dice.Where(d => d.Id == 1 || d.Id == 4).ToList(),
//                RangeAttackDice = dice.Where(d => d.Id == 1 || d.Id == 3).ToList()
//            }
//        );
//    }
//}
