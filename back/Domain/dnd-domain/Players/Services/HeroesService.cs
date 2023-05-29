using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Services;

internal sealed class HeroesService : IHeroesService
{
    private readonly IHeroesRepository _heroesRepository;

    public HeroesService(IHeroesRepository heroesRepository)
    {
        _heroesRepository = heroesRepository ?? throw new ArgumentNullException(nameof(heroesRepository));
    }

    public Task<List<Hero>> GetAsync(int campaignId)
        => _heroesRepository.GetAsync(campaignId);

    public Task<Hero> GetByIdAsync(int id)
    => _heroesRepository.GetByIdAsync(id);

    public Task<Hero> AttackAsync(int id, AttackPayload attack)
        => _heroesRepository.AttackAsync(id, attack);

    public Task<Hero> UpdateAsync(int id, PlayerPayload heroPayload)
        => _heroesRepository.UpdateAsync(id, heroPayload);
}
