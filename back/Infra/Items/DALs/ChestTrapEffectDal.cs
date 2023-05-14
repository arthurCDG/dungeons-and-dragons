using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;

namespace dnd_infra.Items.DALs;

internal sealed class ChestTrapEffectDal
{
    public int Id { get; set; }
    public int ChestTrapId { get; set; }
    public ChestTrapEffectType Effect { get; set; }

    public ChestTrapEffect ToDomain()
        => new()
        {
            Id = Id,
            ChestTrapId = ChestTrapId,
            Effect = Effect
        };
}
