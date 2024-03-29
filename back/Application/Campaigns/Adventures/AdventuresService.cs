﻿using dnd_domain.Campaigns.Adventures;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Adventures;

internal sealed class AdventuresService : IAdventuresService
{
    private readonly IAdventuresRepository _adventuresRepository;

    public AdventuresService(IAdventuresRepository adventuresRepository)
    {
        _adventuresRepository = adventuresRepository ?? throw new System.ArgumentNullException(nameof(adventuresRepository));
    }

    public Task<Adventure> GetByIdAsync(int id)
        => _adventuresRepository.GetByIdAsync(id);

    public Task<Adventure> StartAsync(int campaignId, AdventureType adventureType)
        => _adventuresRepository.StartAsync(campaignId, adventureType);
}
