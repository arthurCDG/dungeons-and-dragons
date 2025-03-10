using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class WeaponAttributes
{
    public required int MaximumDamage { get; set; }
    public required int MinimumDamage { get; set; }
    public required WeaponCategory Category { get; set; }
}
