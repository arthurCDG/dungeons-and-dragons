using dnd_domain.Items.Models;
using System.Threading.Tasks;

namespace dnd_domain.Items.Repositories;

public interface IChestItemsRepository
{
    Task<StoredItem> GetAsync();
}