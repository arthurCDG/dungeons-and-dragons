using dnd_domain.Players.Enums;
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

    public async Task SeedPlayersAsync(int sessionId)
    {
        List<ArtefactDal> artefacts = await _context.Artefacts.Where(a => a.SessionId == sessionId).ToListAsync();
        List<SpellDal> spells = await _context.Spells.Where(a => a.SessionId == sessionId).ToListAsync();
        List<WeaponDal> weapons = await _context.Weapons.Where(a => a.SessionId == sessionId).ToListAsync();

        await SeedHeroesAsync(sessionId, artefacts, spells, weapons);
        await SeedMonstersAsync(sessionId, artefacts, spells, weapons);
    }

    private async Task SeedHeroesAsync(int sessionId, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons)
    {
        List<HeroDal> heroes = new()
        {
            new HeroDal
            {
                SessionId = sessionId,
                Name = "Regdar",
                ImageUrl = "",
                Race = HeroRace.Human,
                Class = HeroClass.Warrior,
                LifePoints = 8,
                ManaPoints = 0,
                Shield = 2,
                FootSteps = 4,
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
                SessionId = sessionId,
                Name = "Lidda",
                ImageUrl = "",
                Race = HeroRace.Halfling,
                Class = HeroClass.Rogue,
                LifePoints = 5,
                ManaPoints = 0,
                Shield = 2,
                FootSteps = 6,
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
                SessionId = sessionId,
                Name = "Jozan",
                ImageUrl = "",
                Race = HeroRace.Human,
                Class = HeroClass.Cleric,
                LifePoints = 5,
                ManaPoints = 5,
                Shield = 2,
                FootSteps = 5,
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
                SessionId = sessionId,
                Name = "Mialye",
                ImageUrl = "",
                Race = HeroRace.Elf,
                Class = HeroClass.Wizard,
                LifePoints = 5,
                ManaPoints = 5,
                Shield = 2,
                FootSteps = 5,
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

    private async Task SeedMonstersAsync(int sessionId, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons)
    {
        List<MonsterDal> monsters = new()
        {
            new MonsterDal
            {
                SessionId = sessionId,
                Name = "Gobelours",
                Type = MonsterType.BugBear,
                ImageUrl = "",
                LifePoints = 7,
                ManaPoints = 0,
                FootSteps = 4,
                Shield = 2,
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
                SessionId = sessionId,
                Name = "Gnoll",
                Type = MonsterType.Gnoll,
                ImageUrl = "",
                LifePoints = 6,
                ManaPoints = 0,
                FootSteps = 3,
                Shield = 2,
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
                SessionId = sessionId,
                Name = "Gobelin",
                Type = MonsterType.Goblin,
                ImageUrl = "",
                LifePoints = 4,
                ManaPoints = 0,
                FootSteps = 5,
                Shield = 1,
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

        _context.Monsters.AddRange(monsters);
        await _context.SaveChangesAsync();
    }
}
