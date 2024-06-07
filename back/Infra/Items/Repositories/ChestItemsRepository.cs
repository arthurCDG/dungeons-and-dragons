//using dnd_domain.Items.Models;
//using dnd_domain.Items.Repositories;
//using dnd_infra.Items.DALs;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace dnd_infra.Items.Repositories;

//internal class ChestItemsRepository : IChestItemsRepository
//{
//    private readonly GlobalDbContext _context;

//    public ChestItemsRepository(GlobalDbContext context)
//    {
//        _context = context ?? throw new ArgumentNullException(nameof(context));
//    }

//    public async Task<StoredItem> GetAsync()
//    {
//        List<StoredItemDal> lootableItems = await _context.StoredItems.ToListAsync();

//        int randomIndex = GetRandomIndex(lootableItems.Count);

//        StoredItemDal lootedItem = lootableItems[randomIndex];

//        if (lootedItem is ArtifactDal)
//        {
//            return new Artifact()
//            {
//                Id = lootedItem.Id,
//                Name = lootedItem.Name,
//                Description = lootedItem.Description,
//                Explanation = lootedItem.Explanation,
//                HeroId = lootedItem.HeroId,
//                ImageUrl = lootedItem.ImageUrl,
//                IsEquiped = lootedItem.IsEquiped,
//                Level = lootedItem.Level,
//                CastDieToDiscardAfterUsage = (lootedItem as ArtifactDal)?.CastDieToDiscardAfterUsage,
//                DiscardAfterUsage = (lootedItem as ArtifactDal)?.DiscardAfterUsage,
//                Effects = (lootedItem as ArtifactDal)?.Effects
//            };
//        }

//        return new StoredItem()
//        {
//            Id = lootedItem.Id,
//            Name = lootedItem.Name,
//            Description = lootedItem.Description,
//            Explanation = lootedItem.Explanation,
//            HeroId = lootedItem.HeroId,
//            ImageUrl = lootedItem.ImageUrl,
//            IsEquiped = lootedItem.IsEquiped,
//            Level = lootedItem.Level
//        };
//    }

//    private static int GetRandomIndex(int numberOfStoredItems)
//    {
//        var random = new Random();
//        return random.Next(0, numberOfStoredItems);
//    }
//}
