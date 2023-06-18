using System.Collections.Generic;

namespace dnd_domain.Items.Models;

public class Potion : Item
{
    public List<PotionEffect> Effects { get; set; } = new();
}
