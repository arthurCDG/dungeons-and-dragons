using dnd_domain.Items.Enums;

namespace dnd_infra.Items.DALs;

internal sealed class SpellEffectDal
{
    public int Id { get; set; }
    public int SpellId { get; set; }
    public SpellEffectType Effect { get; set; }
}
