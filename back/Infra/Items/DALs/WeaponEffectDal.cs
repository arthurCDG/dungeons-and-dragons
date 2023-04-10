using dnd_domain.Items.Enums;

namespace dnd_infra.Items.DALs;

internal sealed class WeaponEffectDal
{
    public int Id { get; set; }
    public int WeaponId { get; set; }
    public WeaponEffect Effect { get; set; }
}
