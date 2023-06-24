using dnd_domain.Campaigns.Enums;
using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;
using dnd_infra.Campaigns.Rooms;
using dnd_infra.Campaigns.Rooms.Squares.DALs;
using dnd_infra.Items.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Players.Repositories;

internal sealed class PlayersFactory
{
    private readonly GlobalDbContext _context;

    public PlayersFactory(GlobalDbContext globalDbContext)
    {
        _context = globalDbContext ?? throw new ArgumentNullException(nameof(globalDbContext));
    }

    public async Task<PlayerDal> ForgePlayerAsync(PlayerCreationPayload payload)
    {
        List<ArtefactDal> artefacts = await _context.Artefacts.ToListAsync();
        List<SpellDal> spells = await _context.Spells.ToListAsync();
        List<WeaponDal> weapons = await _context.Weapons.ToListAsync();

        return payload.PlayerType switch
        {
            PlayerType.Regdar => ForgeRegdar(payload, artefacts, spells, weapons),
            PlayerType.Lidda => ForgeLidda(payload, artefacts, spells, weapons),
            PlayerType.Jozian => ForgeJozian(payload, artefacts, spells, weapons),
            PlayerType.Mialye => ForgeMialye(payload, artefacts, spells, weapons),
            PlayerType.Custom => ForgeCustomPlayer(payload, artefacts, spells, weapons), // TODO
            _ => throw new InvalidOperationException($"Unknown player type: {payload.PlayerType}.")
        };
    }

    public async Task ForgeMonstersFromAdventureAsync(int adventureId, AdventureType adventureType)
    {
        List<WeaponDal> weapons = await _context.Weapons.ToListAsync();
        List<RoomDal> rooms = await _context.Rooms.Where(r => r.AdventureId == adventureId).ToListAsync();
        List<SquareDal> squares = rooms.SelectMany(r => r.Squares).ToList();

        switch (adventureType)
        {
            case AdventureType.GoblinBandits:
                await SeedGoblinBanditsAdventureMonstersAsync(weapons, squares);
                break;
            default:
                throw new InvalidOperationException($"Unknown adventure type: {adventureType}.");
        }
    }

    private static PlayerDal ForgeRegdar(PlayerCreationPayload payload, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons)
        => new()
        {
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
            StoredItems = new()
            {
                new StoredItemDal
                {
                    WeaponId = weapons.Single(w => w.Name == "Epée large").Id,
                    IsEquiped = true
                }
            },
            UserId = payload.UserId
        };

    private static PlayerDal ForgeLidda(PlayerCreationPayload payload, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons)
        => new()
        {
            Profile = new PlayerProfileDal()
            {
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
            UserId = payload.UserId
        };

    private static PlayerDal ForgeJozian(PlayerCreationPayload payload, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons)
        => new()
        {
            Profile = new PlayerProfileDal()
            {
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
            UserId = payload.UserId
        };

    private static PlayerDal ForgeMialye(PlayerCreationPayload payload, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons)
        => new()
        {
            Profile = new PlayerProfileDal()
            {
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
            UserId = payload.UserId
        };

    private PlayerDal ForgeCustomPlayer(PlayerCreationPayload payload, List<ArtefactDal> artefacts, List<SpellDal> spells, List<WeaponDal> weapons)
    {
        throw new NotImplementedException($"Custom player creation is not yet implemented. Soon to be released.");
    }

    private async Task SeedGoblinBanditsAdventureMonstersAsync(List<WeaponDal> weapons, List<SquareDal> squares)
    {
        List<PlayerDal> monsters = new()
        {
            new PlayerDal
            {
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
                }
            },
            new PlayerDal
            {
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
                }
            },
            new PlayerDal
            {
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
                }
            },
            new PlayerDal
            {
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
                }
            },
            new PlayerDal
            {
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
                }
            },
            new PlayerDal
            {
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
                }
            }
        };

        _context.AddRange(monsters);
        await _context.SaveChangesAsync();
    }
}
