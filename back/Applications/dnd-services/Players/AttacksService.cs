using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using System;
using System.Threading.Tasks;

namespace dnd_services.Players;

internal sealed class AttacksService : IAttacksService
{
    private readonly IHeroesRepository _heroesRepository;
    private readonly IMonstersRepository _monstersRepository;

    public AttacksService(IHeroesRepository heroesRepository, IMonstersRepository monstersRepository)
    {
        _heroesRepository = heroesRepository ?? throw new ArgumentNullException(nameof(heroesRepository));
        _monstersRepository = monstersRepository ?? throw new ArgumentNullException(nameof(monstersRepository));
    }

    public Task<Hero> AttackHeroAsync(int heroId, AttackPayload payload)
        => _heroesRepository.AttackAsync(heroId, payload);

    public Task<Monster> AttackMonsterAsync(int monsterId, AttackPayload payload)
        => _monstersRepository.AttackAsync(monsterId, payload);
}
