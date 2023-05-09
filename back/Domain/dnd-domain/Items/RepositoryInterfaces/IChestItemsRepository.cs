using dnd_domain.Items.Models;

namespace dnd_domain.Items.Repositories;

public interface IChestItemsRepository
{
    Task<StoredItem> GetAsync();
}