using dnd_domain.Players.Enums;
using dnd_infra.Campaigns.Rooms;
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
        RoomDal startingRoom = rooms.Single(r => r.IsStartRoom == true);
        List<int> startingSquareIds = startingRoom.Squares.Where(s => s.IsHeroStartingSquare == true).Select(s => s.Id).ToList();

        await SeedHeroesAsync(campaignId, artefacts, spells, weapons, startingSquareIds);
        await SeedMonstersAsync(campaignId, artefacts, spells, weapons, rooms);
    }

    private async Task SeedHeroesAsync(int campaignId, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons, List<int> startingSquareIds)
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
                SquareId = startingSquareIds[0],
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
                SquareId = startingSquareIds[1],
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
                SquareId = startingSquareIds[2],
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
                SquareId = startingSquareIds[3],
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

    private async Task SeedMonstersAsync(int campaignId, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons, List<RoomDal> rooms)
    {
        List<int> monsterSquareIds = rooms.SelectMany(r => r.Squares.Where(s => s.IsMonsterStartingSquare == true)).Select(s => s.Id).ToList();

        List<MonsterDal> monsters = new()
        {
            new MonsterDal
            {
                CampaignId = campaignId,
                Name = "Gobelours",
                Type = MonsterType.BugBear,
                ImageUrl = "",
                LifePoints = 7,
                ManaPoints = 0,
                FootSteps = 4,
                Shield = 2,
                SquareId = monsterSquareIds[0],
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Masse brutale").Id,
                        IsEquiped = true
                    }
                }
            },
            new MonsterDal
            {
                CampaignId = campaignId,
                Name = "Gnoll",
                Type = MonsterType.Gnoll,
                ImageUrl = "",
                LifePoints = 6,
                ManaPoints = 0,
                FootSteps = 3,
                Shield = 2,
                SquareId = monsterSquareIds[1],
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Hâche de guerre émoussée").Id,
                        IsEquiped = true
                    },
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Arbalète d'embuscade").Id
                    }
                }
            },
            new MonsterDal
            {
                CampaignId = campaignId,
                Name = "Gobelin",
                Type = MonsterType.Goblin,
                ImageUrl = "",
                LifePoints = 4,
                ManaPoints = 0,
                FootSteps = 5,
                Shield = 1,
                SquareId = monsterSquareIds[2],
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
