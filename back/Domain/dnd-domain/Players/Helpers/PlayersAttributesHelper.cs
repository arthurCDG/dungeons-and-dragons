﻿using dnd_domain.Players.Models;

namespace dnd_domain.Players.Helpers;

public static class PlayersAttributesHelper
{
    public static PlayerMaxAttributes WarriorLevel1MaxAttributes
    {
        get => new()
        {
            MaxLifePoints = 8,
            MaxManaPoints = 0,
            MaxShield = 2,
            MaxFootSteps = 4,
            MaxAttackCount = 1,
            MaxHealCount = 0,
            MaxChestSearchCount = 1,
            MaxTrapSearchCount = 0
        };
    }

    public static PlayerMaxAttributes RogueLevel1MaxAttributes
    {
        get => new()
        {
            MaxLifePoints = 5,
            MaxManaPoints = 0,
            MaxShield = 2,
            MaxFootSteps = 6,
            MaxAttackCount = 1,
            MaxHealCount = 0,
            MaxChestSearchCount = 2,
            MaxTrapSearchCount = 1
        };
    }

    public static PlayerMaxAttributes ClericLevel1MaxAttributes
    {
        get => new()
        {
            MaxLifePoints = 5,
            MaxManaPoints = 5,
            MaxShield = 2,
            MaxFootSteps = 5,
            MaxAttackCount = 1,
            MaxHealCount = 1,
            MaxChestSearchCount = 1,
            MaxTrapSearchCount = 0
        };
    }

    public static PlayerMaxAttributes WizardLevel1MaxAttributes
    {
        get => new()
        {
            MaxLifePoints = 5,
            MaxManaPoints = 5,
            MaxShield = 2,
            MaxFootSteps = 5,
            MaxAttackCount = 1,
            MaxHealCount = 1,
            MaxChestSearchCount = 1,
            MaxTrapSearchCount = 0
        };
    }
}
