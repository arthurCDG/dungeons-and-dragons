using dnd_domain.Items.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal sealed class WeaponSuperAttackDal
{
    public int Id { get; set; }
    public int WeaponId { get; set; }
    public required int MaximumDamage { get; set; }
    public required int MinimumDamage { get; set; }

    [Comment("This property defines how many times per turn can someone use a superAttack")]
    public int MaxSuperAttackCount { get; set; } = 1;

    public List<EffectDal> Effects { get; set; } = new();

    public WeaponSuperAttack ToDomain()
        => new()
        {
            Id = Id,
            WeaponId = WeaponId,
            MaximumDamage = MaximumDamage,
            MinimumDamage = MinimumDamage,
            Effects = Effects.ConvertAll(e => e.ToDomain()),
            MaxSuperAttackCount = MaxSuperAttackCount
        };
}
