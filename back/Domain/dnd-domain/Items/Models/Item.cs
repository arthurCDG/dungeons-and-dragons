using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public abstract class Item
{
    public int Id { get; set; }
    public int AdventureId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Level { get; set; }

    public bool? DiscardAfterUsage { get; set; }
    public bool? CastDieToDiscardAfterUsage { get; set; }
    public StarDieEffectType? StarDieEffectType { get; set; }
}
