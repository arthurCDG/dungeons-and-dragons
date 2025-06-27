using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;
using System.Collections.Generic;

namespace dnd_domain.Items.Store;

public static class WeaponsStore
{
    public static IReadOnlyCollection<Weapon> Items =>
    [
        AmbushCrossbow,
        AncientShortBow,
        BalancedThrowingDagger,
        BrutalSledgeHammer,
        CompositeLongBow,
        CrossbowOfFaith,
        LargeSword,
        MuddyScourge
    ];

    public static readonly Weapon AmbushCrossbow = new()
    {
        Name = "Arbalète d'embuscade",
        Description = "Mobile et particulièrement utile dans les tunnels étroits.",
        Level = 1,
        Type = ItemType.Weapon,
        Attributes = new WeaponAttributes
        {
            Category = WeaponCategory.RangedWeapon,
            MaximumDamage = 4,
            MinimumDamage = 0
        }
    };


    public static readonly Weapon AncientShortBow = new()
    {
        Name = "Arc court des anciens",
        Description = "Fabriqué avec le bois d'if le plus vieux de la Forêt des elfes anciens.",
        Level = 1,
        Type = ItemType.Weapon,
        Attributes = new WeaponAttributes
        {
            Category = WeaponCategory.RangedWeapon,
            MaximumDamage = 2,
            MinimumDamage = 0
        },
        Effects =
        [
            new Effect { Type = EffectType.IncreaseManaPoints, Amount = 1, Probability = 33 }
        ],
        IsUnique = true
    };

    public static readonly Weapon BalancedThrowingDagger = new()
    {
        Name = "Dague de lancer équilibrée",
        Description = "Bien équilibrée pour plus de précision.",
        Level = 1,
        Type = ItemType.Weapon,
        Attributes = new WeaponAttributes
        {
            Category = WeaponCategory.RangedWeapon,
            MaximumDamage = 2,
            MinimumDamage = 0
        },
        SuperAttack = new WeaponSuperAttack
        {
            MaximumDamage = 4,
            MinimumDamage = 1,
            Effects =
                [
                    new Effect { Type = EffectType.DiscardAfterUsage, Probability = 33 }
                ]
        },
        IsUnique = true
    };

    public static readonly Weapon BrutalSledgeHammer = new()
    {
        Name = "Masse brutale",
        Description = "Lourde, puissante, mais imprécise.",
        Level = 1,
        Type = ItemType.Weapon,
        Attributes = new WeaponAttributes
        {
            Category = WeaponCategory.HeavyMeleeWeapon,
            MaximumDamage = 5,
            MinimumDamage = 0
        }
    };

    public static readonly Weapon CompositeLongBow = new()
    {
        Name = "Arc long composite",
        Description = "Fabriqué à l'aide de deux matériaux légers, mais particulièrement résistants, cet arc est très flexible et extrêmement puissant.",
        Level = 2,
        Type = ItemType.Weapon,
        Attributes = new WeaponAttributes
        {
            Category = WeaponCategory.RangedWeapon,
            MaximumDamage = 4,
            MinimumDamage = 1
        },
        IsUnique = true
    };

    public static readonly Weapon CrossbowOfFaith = new()
    {
        Name = "Arbalète de la foi",
        Description = "Enchantée par les runes de Pélor, ses carreaux ne manquent jamais leur cible.",
        Level = 1,
        Type = ItemType.Weapon,
        Attributes = new WeaponAttributes
        {
            Category = WeaponCategory.RangedWeapon,
            MaximumDamage = 2,
            MinimumDamage = 0
        },
        Effects =
        [
            new Effect { Type = EffectType.IncreaseManaPoints, Amount = 1, Probability = 33 }
        ],
        IsUnique = true
    };

    public static readonly Weapon DullWarAxe = new()
    {
        Name = "Hâche de guerre émoussée",
        Description = "Parfaite pour le combat rapproché.",
        Level = 1,
        Type = ItemType.Weapon,
        Attributes = new WeaponAttributes
        {
            Category = WeaponCategory.MediumMeleeWeapon,
            MaximumDamage = 5,
            MinimumDamage = 1
        }
    };

    public static readonly Weapon LargeSword = new()
    {
        Name = "Epée large",
        Description = "Une lame puissante et légère, bien équilibrée, parfaite pour le combat au corps à corps.",
        Level = 1,
        Type = ItemType.Weapon,
        Attributes = new WeaponAttributes
        {
            Category = WeaponCategory.HeavyMeleeWeapon,
            MaximumDamage = 2,
            MinimumDamage = 1
        },
        IsUnique = true
    };

    public static readonly Weapon MuddyScourge = new()
    {
        Name = "Fléau d'armes fangeux",
        Description = "Usée par le temps, elle cause encore beaucoup de dommages à son adversaire.",
        Level = 1,
        Type = ItemType.Weapon,
        Attributes = new WeaponAttributes
        {
            Category = WeaponCategory.LightMeleeWeapon,
            MaximumDamage = 4,
            MinimumDamage = 1
        }
    };
}
