using dnd_domain.Campaigns.Adventures;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Adventures;

internal sealed class AdventuresService(IAdventuresRepository adventuresRepository) : IAdventuresService
{
    private readonly IAdventuresRepository _adventuresRepository = adventuresRepository;

    public Task<Adventure> GetByIdAsync(int id)
        => _adventuresRepository.GetByIdAsync(id);

    public Task<Adventure> StartAsync(int campaignId, AdventureType adventureType)
        => _adventuresRepository.StartAsync(campaignId, adventureType);
}
