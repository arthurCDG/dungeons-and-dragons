using dnd_domain.Campaigns.Rooms.Squares.Repositories;
using dnd_domain.Players.Models;

namespace dnd_services.Campaigns.Rooms.Squares;

internal sealed class SquaresService : ISquaresService
{
    private readonly ISquaresRepository _squaresRepository;

    public SquaresService(ISquaresRepository squaresRepository)
    {
        _squaresRepository = squaresRepository ?? throw new ArgumentNullException(nameof(squaresRepository));
    }

    public Task<Player?> GetSquarePlayerIfAnyAsync(int squareId)
        => _squaresRepository.GetSquarePlayerIfAnyAsync(squareId);
}
