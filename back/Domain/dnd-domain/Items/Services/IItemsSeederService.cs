using System.Threading.Tasks;

namespace dnd_domain.Items.Services;

public interface IItemsSeederService
{
    Task SeedAsync();
}