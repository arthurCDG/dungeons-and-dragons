using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Campaigns.Adventures.Rooms.Squares;

public interface ISquaresRepository
{
    Task<List<Square>> GetAsync(int campaignId);
    Task<Square> GetByIdAsync(int id);
    Task<Player?> GetSquarePlayerIfAnyAsync(int id);
    Task PlaceHeroesOnSquaresAsync(int campaignId);
}