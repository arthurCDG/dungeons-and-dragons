using dnd_domain.Items.Models;

namespace dnd_domain.Items.Services;
internal interface IChestItemsService
{
    Task<StoredItem> GetAsync();
}