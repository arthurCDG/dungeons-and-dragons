using System.Collections.Generic;

namespace dnd_domain.Items.Models;

public class WeaponSuperAttack
{
    public List<Effect> Effects { get; set; } = [];
    public required int MaximumDamage { get; set; }
    public int MaxSuperAttackCount { get; set; } = 1;
    public required int MinimumDamage { get; set; }
}
