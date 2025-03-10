using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;
using System.Collections.Generic;

namespace dnd_domain.Items.Store;

public static class SpellsStore
{
    public static IReadOnlyCollection<Item> Items =>
    [
        BurningHands,
        MagicProjectile,
        SupremeRestoration
    ];

    public static readonly Spell BurningHands = new()
    {
        Name = "Mains brûlantes",
        Description = "Des gerbes de feu jaillissent de vos doigts, brûlant tout sur leur passage.",
        Level = 1,
        Type = ItemType.Spell,
        Attributes = new SpellAttributes
        {
            ManaCost = 3,
            Type = SpellType.Attack,
            MaximumDamage = 5,
            MinimumDamage = 1
        },
        IsUnique = true
    };

    public static readonly Spell MagicProjectile = new()
    {
        Name = "Projectile magique",
        Description = "De l'énergie brute projetée par votre main.",
        Level = 1,
        Type = ItemType.Spell,
        Attributes = new SpellAttributes
        {
            ManaCost = 2,
            Type = SpellType.Attack,
            MaximumDamage = 4,
            MinimumDamage = 0
        },
        IsUnique = true
    };

    public static readonly Spell SupremeRestoration = new()
    {
        Name = "Restauration suprême",
        Description = "Ramenez un Héros à la vie et redonnez lui 4 points de vie et 4 points de sort, si possible.",
        Explanation = "Placez vous à côté du Héros mort pour lancer le sort.",
        Level = 1,
        Type = ItemType.Spell,
        Attributes = new SpellAttributes
        {
            ManaCost = 4,
            IsMeleeSpellOnly = true,
            Type = SpellType.Revive
        },
        Effects =
        [
            new Effect { Type = EffectType.ReviveAnHeroWith4LifePointsAnd4ManaPoints }
        ],
        IsUnique = true
    };
}
