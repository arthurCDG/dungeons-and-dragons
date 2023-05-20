using dnd_domain.Campaigns.Models;
using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Campaigns.Rooms.Squares.Repositories;

public interface ISquaresRepository
{
    Task<List<Square>> GetAsync(int campaignId);
    Task<Player?> GetSquarePlayerIfAnyAsync(int squareId);
}