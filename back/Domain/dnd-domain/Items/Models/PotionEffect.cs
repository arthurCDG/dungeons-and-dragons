using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class PotionEffect
{
    public int Id { get; set; }
    public int PotionId { get; set; }
    public PotionEffectType Effect { get; set; }
}
