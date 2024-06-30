using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal abstract class ItemDal
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public required string Explanation { get; set; }
    public string? ImageUrl { get; set; }
    public required int Level { get; set; }
    public required string Name { get; set; }

    public List<EffectDal> Effects { get; set; } = new();
}
