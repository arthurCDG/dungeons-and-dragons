using dnd_domain.Sessions.Services;
using System;
using System.Threading.Tasks;

namespace dnd_infra.Sessions;

internal sealed class SessionsRepository : ISessionsRepository
{
    private readonly GlobalDbContext _context;

    public SessionsRepository(GlobalDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task CreateAsync()
    {
        SessionDal dal = new() { StartsAt = DateTime.Now };
        _context.Sessions.Add(dal);
        await _context.SaveChangesAsync();
    }
}
