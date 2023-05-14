using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class WeaponEffect
{
    public int Id { get; set; }
    public int WeaponId { get; set; }
    public WeaponEffectType Effect { get; set; }
}
