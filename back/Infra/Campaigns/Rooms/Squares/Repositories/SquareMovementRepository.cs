using dnd_domain.Fields.Models;
using dnd_domain.Players.Repositories;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace dnd_infra.Campaigns.Rooms.Squares.Repositories;

internal sealed class SquareMovementRepository : ISquareMovementRepository
{
    private GlobalDbContext _context { get; }

    public SquareMovementRepository(GlobalDbContext globalDbContext)
    {
        _context = globalDbContext ?? throw new ArgumentNullException(nameof(globalDbContext));
    }

    public async Task MoveToSquareAsync(int heroId, MovementRequestPayload movementRequest)
    {
        HeroDal dal = await _context.Heroes.FirstAsync(h => h.Id == heroId);
        dal.SquareId = movementRequest.SquareId;
        await _context.SaveChangesAsync();
    }
}
