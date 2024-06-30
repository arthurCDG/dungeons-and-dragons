using System.Collections.Generic;

namespace dnd_domain.Items.Models;

public class WeaponSuperAttack
{
    public int Id { get; set; }
    public int WeaponId { get; set; }
    public required int MaximumDamage { get; set; }
    public required int MinimumDamage { get; set; }

    public int MaxSuperAttackCount { get; set; } = 1;

    public List<Effect> Effects { get; set; } = new();
}
