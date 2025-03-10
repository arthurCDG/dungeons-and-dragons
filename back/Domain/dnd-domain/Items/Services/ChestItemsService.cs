using dnd_domain.Items.Models;
using dnd_domain.Items.Repositories;
using System.Threading.Tasks;

namespace dnd_domain.Items.Services;

internal sealed class ChestItemsService(IStoredItemsRepository storedItemsRepository) : IChestItemsService
{
    private readonly IStoredItemsRepository _storedItemsRepository = storedItemsRepository;

    public Task<StoredItem> GetAsync(int playerId) => _storedItemsRepository.GetAsync(playerId);
}
