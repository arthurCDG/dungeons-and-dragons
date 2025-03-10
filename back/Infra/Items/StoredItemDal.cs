using dnd_domain.Items.Models;

namespace dnd_infra.Items;

internal sealed class StoredItemDal
{
    public int Id { get; set; }
    public bool IsEquiped { get; set; } = false;
    public required Item Item { get; set; }
    public int PlayerId { get; set; }

    public StoredItem ToDomain()
        => new()
        {
            Id = Id,
            IsEquiped = IsEquiped,
            Item = Item,
            PlayerId = PlayerId
        };
}
