using dnd_domain.Campaigns.Models;
using dnd_domain.Campaigns.Rooms.Squares.Repositories;
using dnd_domain.Players.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Rooms.Squares;

internal sealed class SquaresService : ISquaresService
{
    private readonly ISquaresRepository _squaresRepository;

    public SquaresService(ISquaresRepository squaresRepository)
    {
        _squaresRepository = squaresRepository ?? throw new ArgumentNullException(nameof(squaresRepository));
    }

    public Task<List<Square>> GetAsync(int campaignId)
        => _squaresRepository.GetAsync(campaignId);
    public Task<Player?> GetSquarePlayerIfAnyAsync(int squareId)
        => _squaresRepository.GetSquarePlayerIfAnyAsync(squareId);
}
