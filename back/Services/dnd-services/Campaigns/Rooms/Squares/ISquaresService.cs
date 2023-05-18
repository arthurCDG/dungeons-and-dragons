using dnd_domain.Campaigns.Models;
using dnd_domain.Players.Models;

namespace dnd_services.Campaigns.Rooms.Squares;

public interface ISquaresService
{
    Task<List<Square>> GetAsync(int campaignId);
    Task<Player?> GetSquarePlayerIfAnyAsync(int squareId);
}