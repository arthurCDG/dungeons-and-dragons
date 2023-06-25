using dnd_domain.Campaigns.Models;
using dnd_domain.Fields.Models;
using dnd_domain.Players.Repositories;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace dnd_infra.Campaigns.Adventures.Rooms.Squares.Repositories;

internal sealed class SquareMovementRepository : ISquareMovementRepository
{
    private GlobalDbContext _context { get; }

    public SquareMovementRepository(GlobalDbContext globalDbContext)
    {
        _context = globalDbContext ?? throw new ArgumentNullException(nameof(globalDbContext));
    }

    public async Task<Movement> MoveToSquareAsync(MovementRequestPayload movementRequest)
    {
        PlayerDal playerDal = await _context.Players.FirstAsync(h => h.Id == movementRequest.PlayerId);
        int formerSquareId = (int)playerDal.SquareId!; // TODO - validation in service before
        playerDal.SquareId = movementRequest.SquareId;
        await _context.SaveChangesAsync();

        return new Movement { PlayerId = playerDal.Id, FormerSquareId = formerSquareId, NewSquareId = (int)playerDal.SquareId };
    }
}
