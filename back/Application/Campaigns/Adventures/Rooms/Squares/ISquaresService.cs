using dnd_domain.Campaigns.Adventures.Rooms.Squares;
using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Adventures.Rooms.Squares;

public interface ISquaresService
{
    Task<List<Square>> GetAsync(int campaignId);
    Task<Player?> GetSquarePlayerIfAnyAsync(int squareId);
    Task PlaceHeroesOnSquaresAsync(int campaignId);
}