using dnd_domain.Players.Models;

namespace dnd_domain.Campaigns.Rooms.Squares.Repositories;

public interface ISquaresRepository
{
    Task<Player?> GetSquarePlayerIfAnyAsync(int squareId);
}