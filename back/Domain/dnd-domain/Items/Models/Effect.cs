using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class Effect
{
    public required int Id { get; set; }
    public required int ItemId { get; set; }
    public int Probability { get; set; } = 100;
    public required EffectType Type { get; set; }

    public int? Amount { get; set; }
}
