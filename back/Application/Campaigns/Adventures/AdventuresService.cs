using dnd_domain.Campaigns.Adventures;
using dnd_domain.Campaigns.Models;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Adventures;

internal sealed class AdventuresService : IAdventuresService
{
    private readonly IAdventuresRepository _adventuresRepository;

    public AdventuresService(IAdventuresRepository adventuresRepository)
    {
        _adventuresRepository = adventuresRepository ?? throw new System.ArgumentNullException(nameof(adventuresRepository));
    }

    public Task<Adventure> StartAsync(int campaignId, int id)
        => _adventuresRepository.StartAsync(campaignId, id);
}
