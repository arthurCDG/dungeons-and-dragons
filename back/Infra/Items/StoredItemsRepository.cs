using dnd_domain.Items.Models;
using dnd_domain.Items.Repositories;
using dnd_domain.Items.Store;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Items;

internal class StoredItemsRepository(GlobalDbContext context) : IStoredItemsRepository
{
    private readonly GlobalDbContext _context = context;

    private readonly Random _random = new();

    public async Task<StoredItem> GetAsync(int playerId)
    {
        PlayerDal player = await _context.Players.FirstAsync(p => p.Id == playerId);
        if (player.CampaignId == null)
        {
            throw new InvalidOperationException("Unable to retrieve an item for this player as he is not attached to any campaign.");
        }
        int campaignId = player.CampaignId.Value;

        List<PlayerDal> players = await _context.Players.Include(p => p.StoredItems)
                                                        .Where(p => p.CampaignId == campaignId)
                                                        .ToListAsync();

        HashSet<string> storedItemIds = players.SelectMany(p => p.StoredItems)
                                               .Select(si => si.ItemId)
                                               .ToHashSet();

        List<Item> availableItems = ItemsStore.GetAvailableItems(storedItemIds);

        int randomIndex = _random.Next(availableItems.Count);

        StoredItemDal storedItemDal = new()
        {
            PlayerId = playerId,
            ItemId = availableItems[randomIndex].Id
        };

        _context.StoredItems.Add(storedItemDal);
        await _context.SaveChangesAsync();

        return storedItemDal.ToDomain();
    }
}
