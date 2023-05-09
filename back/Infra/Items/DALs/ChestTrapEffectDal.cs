using dnd_domain.Items.Enums;

namespace dnd_infra.Items.DALs;

internal sealed class ChestTrapEffectDal
{
    public int Id { get; set; }
    public int ChestTrapId { get; set; }
    public ChestTrapEffectType Effect { get; set; }
}
