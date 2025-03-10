using dnd_domain.Items.Models;
using System.Threading.Tasks;

namespace dnd_domain.Items.Repositories;

public interface IStoredItemsRepository
{
    Task<StoredItem> GetAsync(int playerId);
}
