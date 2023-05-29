using dnd_domain.Players.Enums;
using dnd_infra.Campaigns.Rooms;
using dnd_infra.Campaigns.Rooms.Squares.DALs;
using dnd_infra.Items.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Seeder;

internal sealed class PlayersSeeder
{
    private readonly GlobalDbContext _context;

    public PlayersSeeder(GlobalDbContext globalDbContext)
    {
        _context = globalDbContext ?? throw new ArgumentNullException(nameof(globalDbContext));
    }

    public async Task SeedPlayersAsync(int campaignId)
    {
        List<ArtefactDal> artefacts = await _context.Artefacts.Where(a => a.CampaignId == campaignId).ToListAsync();
        List<SpellDal> spells = await _context.Spells.Where(s => s.CampaignId == campaignId).ToListAsync();
        List<WeaponDal> weapons = await _context.Weapons.Where(w => w.CampaignId == campaignId).ToListAsync();

        List<RoomDal> rooms = await _context.Rooms.Where(r => r.CampaignId == campaignId).ToListAsync();
        List<SquareDal> squares = rooms.SelectMany(r => r.Squares).ToList();

        await SeedHeroesAsync(campaignId, artefacts, spells, weapons, squares);
        await SeedMonstersAsync(campaignId, artefacts, spells, weapons, squares);
    }

    private async Task SeedHeroesAsync(int campaignId, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons, List<SquareDal> squares)
    {
        List<HeroDal> heroes = new()
        {
            new HeroDal
            {
                CampaignId = campaignId,
                Name = "Regdar",
                ImageUrl = "",
                Race = HeroRace.Human,
                Class = HeroClass.Warrior,
                LifePoints = 8,
                ManaPoints = 0,
                Shield = 2,
                FootSteps = 4,
                SquareId = squares.Single(s => s.Position.X == 1 && s.Position.Y == 21).Id,
                MaxAttackCount = 1,
                MaxHealCount = 0,
                MaxFootStepsCount = 4,
                MaxChestSearchCount = 1,
                MaxTrapSearchCount = 0,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Epée large").Id,
                        IsEquiped = true
                    }
                }
            },
            new HeroDal
            {
                CampaignId = campaignId,
                Name = "Lidda",
                ImageUrl = "",
                Race = HeroRace.Halfling,
                Class = HeroClass.Rogue,
                LifePoints = 5,
                ManaPoints = 0,
                Shield = 2,
                FootSteps = 6,
                SquareId = squares.Single(s => s.Position.X == 1 && s.Position.Y == 20).Id,
                MaxAttackCount = 1,
                MaxHealCount = 0,
                MaxFootStepsCount = 6,
                MaxChestSearchCount = 1,
                MaxTrapSearchCount = 1,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Dague de lancer équilibrée").Id,
                        IsEquiped = true
                    },
                    new StoredItemDal
                    {
                        ArtefactId = artefacts.Single(a => a.Name == "Amulette de Yondalla").Id,
                        IsEquiped = true
                    }
                }
            },
            new HeroDal
            {
                CampaignId = campaignId,
                Name = "Jozan",
                ImageUrl = "",
                Race = HeroRace.Human,
                Class = HeroClass.Cleric,
                LifePoints = 5,
                ManaPoints = 5,
                Shield = 2,
                FootSteps = 5,
                SquareId = squares.Single(s => s.Position.X == 1 && s.Position.Y == 19).Id,
                MaxAttackCount = 1,
                MaxHealCount = 1,
                MaxFootStepsCount = 5,
                MaxChestSearchCount = 1,
                MaxTrapSearchCount = 0,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Arbalète de la foi").Id,
                        IsEquiped = true
                    },
                    new StoredItemDal
                    {
                        SpellId = spells.Single(a => a.Name == "Restauration suprême").Id,
                        IsEquiped = true
                    }
                }
            },
            new HeroDal
            {
                CampaignId = campaignId,
                Name = "Mialye",
                ImageUrl = "",
                Race = HeroRace.Elf,
                Class = HeroClass.Wizard,
                LifePoints = 5,
                ManaPoints = 5,
                Shield = 2,
                FootSteps = 5,
                SquareId = squares.Single(s => s.Position.X == 1 && s.Position.Y == 18).Id,
                MaxAttackCount = 1,
                MaxHealCount = 1,
                MaxFootStepsCount = 5,
                MaxChestSearchCount = 1,
                MaxTrapSearchCount = 0,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Arc court des anciens").Id,
                        IsEquiped = true
                    },
                    new StoredItemDal
                    {
                        SpellId = spells.Single(a => a.Name == "Projectile magique").Id,
                        IsEquiped = true
                    }
                }
            }
        };

        _context.Heroes.AddRange(heroes);
        await _context.SaveChangesAsync();
    }

    private async Task SeedMonstersAsync(int campaignId, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons, List<SquareDal> squares)
    {
        List<MonsterDal> monsters = new()
        {
            new MonsterDal
            {
                CampaignId = campaignId,
                Name = "Zoc",
                Type = MonsterType.Goblin,
                ImageUrl = "",
                LifePoints = 4,
                ManaPoints = 0,
                FootSteps = 5,
                Shield = 1,
                SquareId = squares.Single(s => s.Position.X == 10 && s.Position.Y == 19).Id,
                MaxAttackCount = 1,
                MaxHealCount = 0,
                MaxFootStepsCount = 5,
                MaxChestSearchCount = 0,
                MaxTrapSearchCount = 0,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                }
            },
            new MonsterDal
            {
                CampaignId = campaignId,
                Name = "Slusb",
                Type = MonsterType.Goblin,
                ImageUrl = "",
                LifePoints = 4,
                ManaPoints = 0,
                FootSteps = 5,
                Shield = 1,
                SquareId = squares.Single(s => s.Position.X == 8 && s.Position.Y == 2).Id,
                MaxAttackCount = 1,
                MaxHealCount = 0,
                MaxFootStepsCount = 5,
                MaxChestSearchCount = 0,
                MaxTrapSearchCount = 0,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                }
            },
            new MonsterDal
            {
                CampaignId = campaignId,
                Name = "Klezz",
                Type = MonsterType.Goblin,
                ImageUrl = "",
                LifePoints = 4,
                ManaPoints = 0,
                FootSteps = 5,
                Shield = 1,
                SquareId = squares.Single(s => s.Position.X == 11 && s.Position.Y == 4).Id,
                MaxAttackCount = 1,
                MaxHealCount = 0,
                MaxFootStepsCount = 5,
                MaxChestSearchCount = 0,
                MaxTrapSearchCount = 0,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                }
            },
            new MonsterDal
            {
                CampaignId = campaignId,
                Name = "Guburk",
                Type = MonsterType.Goblin,
                ImageUrl = "",
                LifePoints = 4,
                ManaPoints = 0,
                FootSteps = 5,
                Shield = 1,
                SquareId = squares.Single(s => s.Position.X == 6 && s.Position.Y == 13).Id,
                MaxAttackCount = 1,
                MaxHealCount = 0,
                MaxFootStepsCount = 5,
                MaxChestSearchCount = 0,
                MaxTrapSearchCount = 0,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                }
            },
            new MonsterDal
            {
                CampaignId = campaignId,
                Name = "Praq",
                Type = MonsterType.Goblin,
                ImageUrl = "",
                LifePoints = 4,
                ManaPoints = 0,
                FootSteps = 5,
                Shield = 1,
                SquareId = squares.Single(s => s.Position.X == 7 && s.Position.Y == 16).Id,
                MaxAttackCount = 1,
                MaxHealCount = 0,
                MaxFootStepsCount = 5,
                MaxChestSearchCount = 0,
                MaxTrapSearchCount = 0,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                }
            },
            new MonsterDal
            {
                CampaignId = campaignId,
                Name = "Cukx",
                Type = MonsterType.Goblin,
                ImageUrl = "",
                LifePoints = 4,
                ManaPoints = 0,
                FootSteps = 5,
                Shield = 1,
                SquareId = squares.Single(s => s.Position.X == 2 && s.Position.Y == 17).Id,
                MaxAttackCount = 1,
                MaxHealCount = 0,
                MaxFootStepsCount = 5,
                MaxChestSearchCount = 0,
                MaxTrapSearchCount = 0,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                }
            }
        };

        _context.AddRange(monsters);
        await _context.SaveChangesAsync();
    }
}
