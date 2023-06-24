using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;
using dnd_infra.Dice;
using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal sealed class WeaponDal : ItemDal
{
    public WeaponType Type { get; set; } = new();
    public List<DieAssociationDal> Dice { get; set; } = new();
    public List<WeaponEffectDal> Effects { get; set; } = new();

    public WeaponSuperAttackDal? SuperAttack { get; set; }
    public bool? CanRerollOneDie { get; set; }

    public Weapon ToDomain()
        => new()
        {
            Id = Id,
            Description = Description,
            Explanation = Explanation,
            ImageUrl = ImageUrl,
            Level = Level,
            Name = Name,
            StarDieEffect = StarDieEffect,
            CanRerollOneDie = CanRerollOneDie,
            Type = Type,
            SuperAttack = SuperAttack?.ToDomain(),
            Dice = Dice.ConvertAll(d => d.ToDomain()),
            Effects = Effects.ConvertAll(e => e.ToDomain())
        };
}
