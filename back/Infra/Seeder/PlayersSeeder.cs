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

    public async Task SeedPlayersAsync(int adventureId)
    {
        List<ArtefactDal> artefacts = await _context.Artefacts.ToListAsync();
        List<SpellDal> spells = await _context.Spells.ToListAsync();
        List<WeaponDal> weapons = await _context.Weapons.ToListAsync();

        List<RoomDal> rooms = await _context.Rooms.Where(r => r.AdventureId == adventureId).ToListAsync();
        List<SquareDal> squares = rooms.SelectMany(r => r.Squares).ToList();

        await SeedHeroesAsync(adventureId, artefacts, spells, weapons, squares);
        await SeedMonstersAsync(adventureId, artefacts, spells, weapons, squares);
    }

    private async Task SeedHeroesAsync(int adventureId, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons, List<SquareDal> squares)
    {
        List<PlayerDal> heroes = new()
        {
            new PlayerDal
            {
                AdventureId = adventureId,
                Profile = new()
                {
                    FirstName = "Regdar",
                    ImageUrl = "",
                    Race = HeroRace.Human,
                    Class = HeroClass.Warrior,
                    Gender = PlayerGender.Male
                },
                MaxAttributes = new()
                {
                    MaxLifePoints = 8,
                    MaxManaPoints = 0,
                    MaxShield = 2,
                    MaxFootSteps = 4,
                    MaxAttackCount = 1,
                    MaxHealCount = 0,
                    MaxChestSearchCount = 1,
                    MaxTrapSearchCount = 0
                },
                SquareId = squares.Single(s => s.Position.X == 1 && s.Position.Y == 21).Id,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Epée large").Id,
                        IsEquiped = true
                    }
                },
                UserId = 0 // TODO should come from payload
            },
            new PlayerDal
            {
                AdventureId = adventureId,
                Profile = new PlayerProfileDal() {
                    FirstName = "Lidda",
                    ImageUrl = "",
                    Race = HeroRace.Halfling,
                    Class = HeroClass.Rogue,
                    Gender = PlayerGender.Female
                },
                MaxAttributes = new()
                {
                    MaxLifePoints = 5,
                    MaxManaPoints = 0,
                    MaxShield = 2,
                    MaxFootSteps = 6,
                    MaxAttackCount = 1,
                    MaxHealCount = 0,
                    MaxChestSearchCount = 2,
                    MaxTrapSearchCount = 1
                },
                SquareId = squares.Single(s => s.Position.X == 1 && s.Position.Y == 20).Id,
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
                },
                UserId = 0 // TODO should come from payload
            },
            new PlayerDal
            {
                AdventureId = adventureId,
                Profile = new PlayerProfileDal() {
                    FirstName = "Jozan",
                    ImageUrl = "",
                    Race = HeroRace.Human,
                    Class = HeroClass.Cleric,
                    Gender = PlayerGender.Male
                },
                MaxAttributes = new()
                {
                    MaxLifePoints = 5,
                    MaxManaPoints = 5,
                    MaxShield = 2,
                    MaxFootSteps = 5,
                    MaxAttackCount = 1,
                    MaxHealCount = 1,
                    MaxChestSearchCount = 1,
                    MaxTrapSearchCount = 0
                },
                SquareId = squares.Single(s => s.Position.X == 1 && s.Position.Y == 19).Id,
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
                },
                UserId = 0 // TODO should come from payload
            },
            new PlayerDal
            {
                AdventureId = adventureId,
                Profile = new PlayerProfileDal() {
                    FirstName = "Mialye",
                    ImageUrl = "",
                    Race = HeroRace.Elf,
                    Class = HeroClass.Wizard,
                    Gender = PlayerGender.Female
                },
                MaxAttributes = new()
                {
                    MaxLifePoints = 5,
                    MaxManaPoints = 5,
                    MaxShield = 2,
                    MaxFootSteps = 5,
                    MaxAttackCount = 1,
                    MaxHealCount = 1,
                    MaxChestSearchCount = 1,
                    MaxTrapSearchCount = 0,
                },
                SquareId = squares.Single(s => s.Position.X == 1 && s.Position.Y == 18).Id,
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
                },
                UserId = 0 // TODO should come from payload
            }
        };

        _context.Players.AddRange(heroes);
        await _context.SaveChangesAsync();
    }

    private async Task SeedMonstersAsync(int adventureId, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons, List<SquareDal> squares)
    {
        List<PlayerDal> monsters = new()
        {
            new PlayerDal
            {
                AdventureId = adventureId,
                Profile = new PlayerProfileDal() {
                    FirstName = "Zoc",
                    MonsterType = MonsterType.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male
                },
                MaxAttributes = new()
                {
                    MaxLifePoints = 4,
                    MaxManaPoints = 0,
                    MaxFootSteps = 5,
                    MaxShield = 1,
                    MaxAttackCount = 1,
                    MaxHealCount = 0,
                    MaxChestSearchCount = 0,
                    MaxTrapSearchCount = 0,
                },
                SquareId = squares.Single(s => s.Position.X == 10 && s.Position.Y == 19).Id,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                },
                UserId = 0 // TODO should come from payload
            },
            new PlayerDal
            {
                AdventureId = adventureId,
                Profile = new PlayerProfileDal() {
                    FirstName = "Slusb",
                    MonsterType = MonsterType.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male
                },
                MaxAttributes = new()
                {
                    MaxLifePoints = 4,
                    MaxManaPoints = 0,
                    MaxFootSteps = 5,
                    MaxShield = 1,
                    MaxAttackCount = 1,
                    MaxHealCount = 0,
                    MaxChestSearchCount = 0,
                    MaxTrapSearchCount = 0,
                },
                SquareId = squares.Single(s => s.Position.X == 8 && s.Position.Y == 2).Id,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                },
                UserId = 0 // TODO should come from payload
            },
            new PlayerDal
            {
                AdventureId = adventureId,
                Profile = new PlayerProfileDal() {
                    FirstName = "Klezz",
                    MonsterType = MonsterType.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male
                },
                MaxAttributes = new()
                {
                    MaxLifePoints = 4,
                    MaxManaPoints = 0,
                    MaxFootSteps = 5,
                    MaxShield = 1,
                    MaxAttackCount = 1,
                    MaxHealCount = 0,
                    MaxChestSearchCount = 0,
                    MaxTrapSearchCount = 0,
                },
                SquareId = squares.Single(s => s.Position.X == 11 && s.Position.Y == 4).Id,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                },
                UserId = 0 // TODO should come from payload
            },
            new PlayerDal
            {
                AdventureId = adventureId,
                Profile = new PlayerProfileDal() {
                    FirstName = "Guburk",
                    MonsterType = MonsterType.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male
                },
                MaxAttributes = new()
                {
                    MaxLifePoints = 4,
                    MaxManaPoints = 0,
                    MaxFootSteps = 5,
                    MaxShield = 1,
                    MaxAttackCount = 1,
                    MaxHealCount = 0,
                    MaxChestSearchCount = 0,
                    MaxTrapSearchCount = 0,
                },
                SquareId = squares.Single(s => s.Position.X == 6 && s.Position.Y == 13).Id,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                },
                UserId = 0 // TODO should come from payload
            },
            new PlayerDal
            {
                AdventureId = adventureId,
                Profile = new PlayerProfileDal() {
                    FirstName = "Praq",
                    MonsterType = MonsterType.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male
                },
                MaxAttributes = new()
                {
                    MaxLifePoints = 4,
                    MaxManaPoints = 0,
                    MaxFootSteps = 5,
                    MaxShield = 1,
                    MaxAttackCount = 1,
                    MaxHealCount = 0,
                    MaxChestSearchCount = 0,
                    MaxTrapSearchCount = 0,
                },
                SquareId = squares.Single(s => s.Position.X == 7 && s.Position.Y == 16).Id,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                },
                UserId = 0 // TODO should come from payload
            },
            new PlayerDal
            {
                AdventureId = adventureId,
                Profile = new PlayerProfileDal() {
                    FirstName = "Cukx",
                    MonsterType = MonsterType.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male
                },
                MaxAttributes = new()
                {
                    MaxLifePoints = 4,
                    MaxManaPoints = 0,
                    MaxFootSteps = 5,
                    MaxShield = 1,
                    MaxAttackCount = 1,
                    MaxHealCount = 0,
                    MaxChestSearchCount = 0,
                    MaxTrapSearchCount = 0,
                },
                SquareId = squares.Single(s => s.Position.X == 2 && s.Position.Y == 17).Id,
                StoredItems = new()
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                },
                UserId = 0 // TODO should come from payload
            }
        };

        _context.AddRange(monsters);
        await _context.SaveChangesAsync();
    }
}
