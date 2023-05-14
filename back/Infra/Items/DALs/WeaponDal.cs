using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;
using dnd_infra.Dice;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal sealed class WeaponDal : ItemDal
{
    public WeaponType WeaponType { get; set; } = new();
    public List<DieAssociationDal> Dice { get; set; } = new();
    public List<WeaponEffectDal> Effects { get; set; } = new();

    public WeaponSuperAttackDal? SuperAttack { get; set; }
    public bool? CanRerollOneDie { get; set; }
    public StarDieEffectType? StarDieEffect { get; set; }

    public Weapon ToDomain()
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            Description = Description,
            Explanation = Explanation,
            ImageUrl = ImageUrl,
            Level = Level,
            Name = Name,
            StarDieEffect = StarDieEffect,
            CanRerollOneDie = CanRerollOneDie,
            WeaponType = WeaponType,
            SuperAttack = SuperAttack?.ToDomain(),
            Dice = Dice.Select(d => d.ToDomain()).ToList(),
            Effects = Effects.Select(e => e.ToDomain()).ToList()
        };
}
