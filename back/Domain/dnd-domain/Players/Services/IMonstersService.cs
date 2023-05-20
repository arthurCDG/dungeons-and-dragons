using dnd_domain.Players.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dnd_domain.Players.Services;

public interface IMonstersService
{
    Task<List<Monster>> GetAsync(int campaignId);
}