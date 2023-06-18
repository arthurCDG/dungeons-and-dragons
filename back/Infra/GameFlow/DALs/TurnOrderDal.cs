using dnd_domain.GameFlow.Models;

namespace dnd_infra.GameFlow.DALs;

internal sealed class TurnOrderDal
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int Order { get; set; }

    public TurnOrder ToDomain()
        => new()
        {
            Id = Id,
            PlayerId = PlayerId,
            Order = Order
        };
}
