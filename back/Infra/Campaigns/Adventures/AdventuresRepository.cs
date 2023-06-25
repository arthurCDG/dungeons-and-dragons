using dnd_domain.Campaigns.Adventures;
using dnd_domain.Campaigns.Models;
using dnd_domain.Campaigns.Rooms.Squares.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Campaigns.Adventures;

internal sealed class AdventuresRepository : IAdventuresRepository
{
    private readonly GlobalDbContext _context;
    private readonly ISquaresRepository _squaresRepository;

    public AdventuresRepository(GlobalDbContext context, ISquaresRepository squaresRepository)
    {
        _context = context ?? throw new System.ArgumentNullException(nameof(context));
        _squaresRepository = squaresRepository ?? throw new System.ArgumentNullException(nameof(squaresRepository));
    }

    public Task<Adventure> GetByIdAsync(int id)
        => _context.Adventures
            .Include(a => a.Rooms)
                .ThenInclude(r => r.Squares)
                    .ThenInclude(s => s.Position)
            .Include(a => a.Rooms)
                .ThenInclude(r => r.Squares)
                    .ThenInclude(s => s.Trap)
            .Where(a => a.Id == id)
            .Select(a => a.ToDomain())
            .SingleAsync();

    public async Task<Adventure> StartAsync(int campaignId, int id)
    {
        await _squaresRepository.PlaceHeroesOnSquaresAsync(campaignId);

        return await _context.Adventures
            .Include(a => a.Rooms)
                .ThenInclude(r => r.Squares)
                    .ThenInclude(s => s.Position)
            .Include(a => a.Rooms)
                .ThenInclude(r => r.Squares)
                    .ThenInclude(s => s.Trap)
            .Where(a => a.Id == id)
            .Select(a => a.ToDomain())
            .SingleAsync();
    }
}
