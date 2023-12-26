using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Players;

public interface IAvailablePlayersService
{
    Task<List<Player>> GetAsync();
    Task MarkAsAvailableAsync(int playerId);
    Task MarkAsUnavailableAsync(int playerId);
}