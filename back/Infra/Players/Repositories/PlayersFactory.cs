using dnd_domain.Campaigns.Adventures;
using dnd_domain.Players.Enums;
using dnd_domain.Players.Payloads;
using dnd_infra.Campaigns;
using dnd_infra.Campaigns.Adventures;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
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

    /// <summary>
    /// TODO ref this method to forge custom players in the future with all payload properties.
    /// </summary>
    public async Task<PlayerDal> ForgePlayerAsync(int userId, PlayerCreationPayload payload)
    {
        List<ArtifactDal> artifacts = await _context.Artifacts.ToListAsync();
        List<SpellDal> spells = await _context.Spells.ToListAsync();
        List<WeaponDal> weapons = await _context.Weapons.ToListAsync();

        return payload.Class switch
        {
            Class.Warrior => ForgeWarrior(userId, payload, weapons),
            Class.Rogue => ForgeRogue(userId, payload, artifacts, weapons),
            Class.Cleric => ForgeCleric(userId, payload, spells, weapons),
            Class.Wizard => ForgeWizard(userId, payload, spells, weapons),
            _ => throw new InvalidOperationException($"Unknown player class: {payload.Class}.")
        };
    }

    public async Task ForgeMonstersFromAdventureAsync(int campaignId, int adventureId)
    {
        CampaignDal campaign = await _context.Campaigns
            .Include(c => c.Players)
            .Include(c => c.Adventures)
                .ThenInclude(a => a.Rooms)
                    .ThenInclude(r => r.Squares)
                        .ThenInclude(s => s.Position)
            .FirstAsync(c => c.Id == campaignId);

        int dungeonMasterId = campaign.DungeonMasterId
            ?? campaign.Players.FirstOrDefault()?.UserId
            ?? throw new InvalidProgramException("No dungeon master nor player found in campaign.");

        AdventureDal adventure = campaign.Adventures.Single(a => a.Id == adventureId);
        List<SquareDal> squares = adventure.Rooms.SelectMany(r => r.Squares).ToList();

        List<WeaponDal> weapons = await _context.Weapons.ToListAsync();
        List<PlayerDal> monsters = new();

        switch (adventure.Type)
        {
            case AdventureType.GoblinBandits:
                monsters = ForgeGoblinBanditsAdventureMonsters(dungeonMasterId, weapons, squares);
                break;
            default:
                throw new InvalidOperationException($"Unknown adventure type: {adventure.Type}.");
        }

        campaign.Players.AddRange(monsters);
        await _context.SaveChangesAsync();
    }

    private static PlayerDal ForgeWarrior(int userId, PlayerCreationPayload payload, List<WeaponDal> weapons)
        => new()
        {
            Profile = new PlayerProfileDal
            {
                Name = payload.Name,
                ImageUrl = "",
                Species = payload.Species,
                Class = payload.Class,
                Gender = payload.Gender,
                Role = PlayerRole.Hero
            },
            MaxAttributes = new PlayerMaxAttributesDal
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
            StoredItems = new List<StoredItemDal>
            {
                new StoredItemDal
                {
                    WeaponId = weapons.Single(w => w.Name == "Epée large").Id,
                    IsEquiped = true
                }
            },
            UserId = userId
        };

    private static PlayerDal ForgeRogue(int userId, PlayerCreationPayload payload, List<ArtifactDal> artifacts, List<WeaponDal> weapons)
        => new()
        {
            Profile = new PlayerProfileDal
            {
                Name = payload.Name,
                ImageUrl = "",
                Species = payload.Species,
                Class = payload.Class,
                Gender = payload.Gender,
                Role = PlayerRole.Hero
            },
            MaxAttributes = new PlayerMaxAttributesDal
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
            StoredItems = new List<StoredItemDal>
            {
                new StoredItemDal
                {
                    WeaponId = weapons.Single(w => w.Name == "Dague de lancer équilibrée").Id,
                    IsEquiped = true
                },
                new StoredItemDal
                {
                    ArtifactId = artifacts.Single(a => a.Name == "Amulette de Yondalla").Id,
                    IsEquiped = true
                }
            },
            UserId = userId
        };

    private static PlayerDal ForgeCleric(int userId, PlayerCreationPayload payload, List<SpellDal> spells, List<WeaponDal> weapons)
        => new()
        {
            Profile = new PlayerProfileDal
            {
                Name = payload.Name,
                ImageUrl = "",
                Species = payload.Species,
                Class = payload.Class,
                Gender = payload.Gender,
                Role = PlayerRole.Hero
            },
            MaxAttributes = new PlayerMaxAttributesDal
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
            StoredItems = new List<StoredItemDal>
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
            UserId = userId
        };

    private static PlayerDal ForgeWizard(int userId, PlayerCreationPayload payload, List<SpellDal> spells, List<WeaponDal> weapons)
        => new()
        {
            Profile = new PlayerProfileDal
            {
                Name = payload.Name,
                ImageUrl = "",
                Species = payload.Species,
                Class = payload.Class,
                Gender = payload.Gender,
                Role = PlayerRole.Hero
            },
            MaxAttributes = new PlayerMaxAttributesDal
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
            StoredItems = new List<StoredItemDal>
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
            UserId = userId
        };

    private static List<PlayerDal> ForgeGoblinBanditsAdventureMonsters(int dungeonMasterId, List<WeaponDal> weapons, List<SquareDal> squares)
        => new()
        {
            new PlayerDal
            {
                UserId = dungeonMasterId,
                Profile = new PlayerProfileDal
                {
                    Name = "Zoc",
                    Species = Species.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male,
                    Role = PlayerRole.Monster,
                    Class = Class.Thief
                },
                MaxAttributes = new PlayerMaxAttributesDal
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
                StoredItems = new List<StoredItemDal>
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
                UserId = dungeonMasterId,
                Profile = new PlayerProfileDal
                {
                    Name = "Slusb",
                    Species = Species.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male,
                    Role = PlayerRole.Monster,
                    Class = Class.Thief
                },
                MaxAttributes = new PlayerMaxAttributesDal
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
                StoredItems = new List<StoredItemDal>
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
                UserId = dungeonMasterId,
                Profile = new PlayerProfileDal
                {
                    Name = "Klezz",
                    Species = Species.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male,
                    Role = PlayerRole.Monster,
                    Class = Class.Thief
                },
                MaxAttributes = new PlayerMaxAttributesDal
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
                StoredItems = new List<StoredItemDal>
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
                UserId = dungeonMasterId,
                Profile = new PlayerProfileDal
                {
                    Name = "Guburk",
                    Species = Species.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male,               
                    Role = PlayerRole.Monster,
                    Class = Class.Thief
                },
                MaxAttributes = new PlayerMaxAttributesDal
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
                StoredItems = new List<StoredItemDal>
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
                UserId = dungeonMasterId,
                Profile = new PlayerProfileDal
                {
                    Name = "Praq",
                    Species = Species.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male,
                    Role = PlayerRole.Monster,
                    Class = Class.Thief
                },
                MaxAttributes = new PlayerMaxAttributesDal
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
                StoredItems = new List<StoredItemDal>
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
                UserId = dungeonMasterId,
                Profile = new PlayerProfileDal
                {
                    Name = "Cukx",
                    Species = Species.Goblin,
                    ImageUrl = "",
                    Gender = PlayerGender.Male,
                    Role = PlayerRole.Monster,
                    Class = Class.Thief
                },
                MaxAttributes = new PlayerMaxAttributesDal
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
                StoredItems = new List<StoredItemDal>
                {
                    new StoredItemDal
                    {
                        WeaponId = weapons.Single(w => w.Name == "Fléau d'armes fangeux").Id,
                        IsEquiped = true
                    }
                }
            }
        };
}
