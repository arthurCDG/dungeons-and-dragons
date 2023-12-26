using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Services;

public interface IPlayersService
{
    Task<List<Player>> GetAsync(int campaignId);
    Task<Player> GetByIdAsync(int id);
    Task<Player> AttackAsync(int id, AttackPayload attackPayload);
    Task<Player> UpdateAsync(int id, PlayerPayload playerPayload);
}