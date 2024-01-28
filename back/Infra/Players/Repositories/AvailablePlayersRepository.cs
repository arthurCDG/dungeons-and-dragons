using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Players.Repositories;

internal sealed class AvailablePlayersRepository : IAvailablePlayersRepository
{
    private readonly GlobalDbContext _context;

    public AvailablePlayersRepository(GlobalDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task<List<Player>> GetAsync()
        => _context.Players.Where(p => p.IsAvailable)
                           .Include(p => p.Profile)
                           .Include(p => p.MaxAttributes)
                           .Select(ap => ap.ToDomain())
                           .ToListAsync();

    public async Task MarkAsAvailableAsync(int playerId)
    {
        PlayerDal player = await _context.Players.SingleAsync(p => p.Id == playerId);
        
        player.IsAvailable = true;

        await _context.SaveChangesAsync();
    }

    public async Task MarkAsUnavailableAsync(int playerId)
    {
        PlayerDal player = await _context.Players.SingleAsync(p => p.Id == playerId);
        
        player.IsAvailable = false;

        await _context.SaveChangesAsync();
    }
}
