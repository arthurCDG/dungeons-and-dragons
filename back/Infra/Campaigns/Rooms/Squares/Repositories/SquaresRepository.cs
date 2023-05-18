using dnd_domain.Campaigns.Models;
using dnd_domain.Campaigns.Rooms.Squares.Repositories;
using dnd_domain.Players.Models;
using dnd_infra.Campaigns.Rooms.Squares.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Campaigns.Rooms.Squares.Repositories;

internal sealed class SquaresRepository : ISquaresRepository
{
    private readonly GlobalDbContext _context;

    public SquaresRepository(GlobalDbContext globalDbContext)
    {
        _context = globalDbContext ?? throw new System.ArgumentNullException(nameof(globalDbContext));
    }

    public async Task<List<Square>> GetAsync(int campaignId)
    {
        List<SquareDal> squares = await _context.Rooms.Where(r => r.CampaignId == campaignId).SelectMany(r => r.Squares).ToListAsync();
        return squares.ConvertAll(s => s.ToDomain());
    }

    public async Task<Player?> GetSquarePlayerIfAnyAsync(int squareId)
    {
        HeroDal? heroDal = await _context.Heroes.FirstOrDefaultAsync(h => h.SquareId == squareId);

        if (heroDal is not null)
        {
            return heroDal.ToDomain();
        }

        MonsterDal? monsterDal = await _context.Monsters.FirstOrDefaultAsync(m => m.SquareId == squareId);

        if (monsterDal is not null)
        {
            return monsterDal.ToDomain();
        }

        return null;
    }
}
