using dnd_domain.Players.Models;

namespace dnd_services.Campaigns.Rooms.Squares;

public interface ISquaresService
{
    Task<Player?> GetSquarePlayerIfAnyAsync(int squareId);
}