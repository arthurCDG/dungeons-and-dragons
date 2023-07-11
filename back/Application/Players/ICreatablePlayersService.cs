using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_application.Players;

public interface ICreatablePlayersService
{
    Task<List<CreatablePlayer>> GetAsync(int userId);
}