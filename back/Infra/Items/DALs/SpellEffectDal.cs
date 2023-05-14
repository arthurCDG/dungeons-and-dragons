using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;

namespace dnd_infra.Items.DALs;

internal sealed class SpellEffectDal
{
    public int Id { get; set; }
    public int SpellId { get; set; }
    public SpellEffectType Effect { get; set; }

    public SpellEffect ToDomain()
        => new()
        {
            Id = Id,
            SpellId = SpellId,
            Effect = Effect
        };
}
