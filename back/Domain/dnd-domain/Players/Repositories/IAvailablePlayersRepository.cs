using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Repositories;

public interface IAvailablePlayersRepository
{
    Task<List<Player>> GetAsync();
    Task MarkAsAvailableAsync(int playerId);
    Task MarkAsUnavailableAsync(int playerId);
}