using dnd_domain.Items.Models;
using System.Threading.Tasks;

namespace dnd_domain.Items.Services;

public interface IChestItemsService
{
    Task<StoredItem> GetAsync(int playerId);
}