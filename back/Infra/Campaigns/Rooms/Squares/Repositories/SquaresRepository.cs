using dnd_domain.Campaigns.Rooms.Squares.Repositories;
using dnd_domain.Players.Models;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace dnd_infra.Campaigns.Rooms.Squares.Repositories;

internal sealed class SquaresRepository : ISquaresRepository
{
    private readonly GlobalDbContext _context;

    public SquaresRepository(GlobalDbContext globalDbContext)
    {
        _context = globalDbContext ?? throw new System.ArgumentNullException(nameof(globalDbContext));
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
