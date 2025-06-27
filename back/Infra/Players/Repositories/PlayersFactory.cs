using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnd_domain.Campaigns.Adventures;
using dnd_domain.Items.Store;
using dnd_domain.Players.Enums;
using dnd_domain.Players.Payloads;
using dnd_infra.Campaigns;
using dnd_infra.Campaigns.Adventures;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
using dnd_infra.Items;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Players.Repositories;

internal sealed class PlayersFactory(GlobalDbContext context)
{
    /// <summary>
    /// TODO ref this method to forge custom players in the future with all payload properties.
    /// </summary>
    public static PlayerDal ForgePlayer(int userId, PlayerCreationPayload payload)
    {
        return payload.Class switch
        {
            Class.Warrior => ForgeWarrior(userId, payload),
            Class.Rogue => ForgeRogue(userId, payload),
            Class.Cleric => ForgeCleric(userId, payload),
            Class.Wizard => ForgeWizard(userId, payload),
            _ => throw new InvalidOperationException($"Unknown player class: {payload.Class}.")
        };
    }

    public async Task ForgeMonstersFromAdventureAsync(int campaignId, int adventureId)
    {
        CampaignDal campaign = await context.Campaigns
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

        List<PlayerDal> monsters = adventure.Type switch
        {
            AdventureType.GoblinBandits => ForgeGoblinBanditsAdventureMonsters(dungeonMasterId, squares),
            _ => throw new InvalidOperationException($"Unknown adventure type: {adventure.Type}."),
        };

        campaign.Players.AddRange(monsters);
        await context.SaveChangesAsync();
    }

    private static PlayerDal ForgeWarrior(int userId, PlayerCreationPayload payload)
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
            Attributes = new PlayerAttributesDal(),
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
            StoredItems =
            [
                new StoredItemDal
                {
                    ItemId = WeaponsStore.LargeSword.Id,
                    IsEquiped = true
                }
            ],
            UserId = userId
        };

    private static PlayerDal ForgeRogue(int userId, PlayerCreationPayload payload)
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
            Attributes = new PlayerAttributesDal(),
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
            StoredItems =
            [
                new StoredItemDal
                {
                    ItemId = WeaponsStore.BalancedThrowingDagger.Id,
                    IsEquiped = true
                },
                new StoredItemDal
                {
                    ItemId = ArtifactsStore.AmuletOfYondalla.Id,
                    IsEquiped = true
                }
            ],
            UserId = userId
        };

    private static PlayerDal ForgeCleric(int userId, PlayerCreationPayload payload)
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
            Attributes = new PlayerAttributesDal(),
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
            StoredItems =
            [
                new StoredItemDal
                {
                    ItemId = WeaponsStore.CrossbowOfFaith.Id,
                    IsEquiped = true
                },
                new StoredItemDal
                {
                    ItemId = SpellsStore.SupremeRestoration.Id,
                    IsEquiped = true
                }
            ],
            UserId = userId
        };

    private static PlayerDal ForgeWizard(int userId, PlayerCreationPayload payload)
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
            Attributes = new PlayerAttributesDal(),
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
            StoredItems =
            [
                new StoredItemDal
                {
                    ItemId = WeaponsStore.AncientShortBow.Id,
                    IsEquiped = true
                },
                new StoredItemDal
                {
                    ItemId = SpellsStore.MagicProjectile.Id,
                    IsEquiped = true
                }
            ],
            UserId = userId
        };

    private static List<PlayerDal> ForgeGoblinBanditsAdventureMonsters(int dungeonMasterId, List<SquareDal> squares)
        =>
        [
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
                Attributes = new PlayerAttributesDal(),
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
                StoredItems =
                [
                    new StoredItemDal
                    {
                        ItemId = WeaponsStore.MuddyScourge.Id,
                        IsEquiped = true
                    }
                ]
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
                Attributes = new PlayerAttributesDal(),
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
                StoredItems =
                [
                    new StoredItemDal
                    {
                        ItemId = WeaponsStore.MuddyScourge.Id,
                        IsEquiped = true
                    }
                ]
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
                Attributes = new PlayerAttributesDal(),
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
                StoredItems =
                [
                    new StoredItemDal
                    {
                        ItemId = WeaponsStore.MuddyScourge.Id,
                        IsEquiped = true
                    }
                ]
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
                Attributes = new PlayerAttributesDal(),
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
                StoredItems =
                [
                    new StoredItemDal
                    {
                        ItemId = WeaponsStore.MuddyScourge.Id,
                        IsEquiped = true
                    }
                ]
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
                Attributes = new PlayerAttributesDal(),
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
                StoredItems =
                [
                    new StoredItemDal
                    {
                        ItemId = WeaponsStore.MuddyScourge.Id,
                        IsEquiped = true
                    }
                ]
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
                Attributes = new PlayerAttributesDal(),
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
                StoredItems =
                [
                    new StoredItemDal
                    {
                        ItemId = WeaponsStore.MuddyScourge.Id,
                        IsEquiped = true
                    }
                ]
            }
        ];
}
