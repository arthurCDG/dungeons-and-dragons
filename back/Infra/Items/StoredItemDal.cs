﻿using dnd_domain.Items.Models;
using dnd_domain.Items.Store;

namespace dnd_infra.Items;

internal sealed class StoredItemDal
{
    public int Id { get; set; }
    public bool IsEquiped { get; set; } = false;
    public required string ItemId { get; set; }
    public int PlayerId { get; set; }

    public StoredItem ToDomain()
        => new()
        {
            Id = Id,
            IsEquiped = IsEquiped,
            Item = ItemsStore.GetItem(ItemId),
            PlayerId = PlayerId
        };
}
