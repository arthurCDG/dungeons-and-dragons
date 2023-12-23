using dnd_domain.Campaigns.Adventures.Rooms.Squares;
using dnd_domain.Players.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Adventures.Rooms.Squares;

internal sealed class SquaresService : ISquaresService
{
    private readonly ISquaresRepository _squaresRepository;

    public SquaresService(ISquaresRepository squaresRepository)
    {
        _squaresRepository = squaresRepository ?? throw new ArgumentNullException(nameof(squaresRepository));
    }

    public Task<List<Square>> GetAsync(int campaignId)
        => _squaresRepository.GetAsync(campaignId);

    public Task<Square> GetByIdAsync(int id)
         => _squaresRepository.GetByIdAsync(id);

    public Task<Player?> GetSquarePlayerIfAnyAsync(int id)
        => _squaresRepository.GetSquarePlayerIfAnyAsync(id);

    public Task PlaceHeroesOnSquaresAsync(int campaignId)
        => _squaresRepository.PlaceHeroesOnSquaresAsync(campaignId);
}
