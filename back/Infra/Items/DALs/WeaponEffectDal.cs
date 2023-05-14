using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;

namespace dnd_infra.Items.DALs;

internal sealed class WeaponEffectDal
{
    public int Id { get; set; }
    public int WeaponId { get; set; }
    public WeaponEffectType Effect { get; set; }

    public WeaponEffect ToDomain()
        => new()
        {
            Id = Id,
            WeaponId = WeaponId,
            Effect = Effect
        };
}
