using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Services;

internal sealed class MonstersService : IMonstersService
{
    private readonly IMonstersRepository _monstersRepository;

    public MonstersService(IMonstersRepository monstersRepository)
    {
        _monstersRepository = monstersRepository ?? throw new ArgumentNullException(nameof(monstersRepository));
    }

    public Task<List<Monster>> GetAsync(int campaignId)
        => _monstersRepository.GetAsync(campaignId);
}
