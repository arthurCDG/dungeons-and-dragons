using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class Effect
{
    public int Probability { get; set; } = 100;
    public required EffectType Type { get; set; }

    public int? Amount { get; set; }
}
