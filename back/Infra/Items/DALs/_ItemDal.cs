using dnd_domain.Items.Enums;

namespace dnd_infra.Items.DALs;

public abstract class ItemDal
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Level { get; set; }

    public bool? DiscardAfterUsage { get; set; }
    public bool? CastDieToDiscardAfterUsage { get; set; }
    public StarDieEffectType? StarDieEffect { get; set; }
}
