using dnd_domain.Items.Models;
using dnd_domain.Items.Repositories;
using System;
using System.Threading.Tasks;

namespace dnd_domain.Items.Services;

internal class ChestItemsService : IChestItemsService
{
    private readonly IChestItemsRepository _chestItemsRepository;

    public ChestItemsService(IChestItemsRepository chestItemsRepository)
    {
        _chestItemsRepository = chestItemsRepository ?? throw new ArgumentNullException(nameof(chestItemsRepository));
    }

    public Task<StoredItem> GetAsync()
        => _chestItemsRepository.GetAsync();
}
