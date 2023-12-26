using dnd_domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Users;

internal sealed class AvailableUsersRepository : IAvailableUsersRepository
{
    private readonly GlobalDbContext _context;

    public AvailableUsersRepository(GlobalDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task<List<User>> GetAsync()
        => _context.Users.Where(p => p.IsAvailable)
                           .Select(ap => ap.ToDomain())
                           .ToListAsync();

    public async Task MarkAsAvailableAsync(int userId)
    {
        UserDal User = await _context.Users.SingleAsync(p => p.Id == userId);

        User.IsAvailable = true;

        await _context.SaveChangesAsync();
    }

    public async Task MarkAsUnavailableAsync(int userId)
    {
        UserDal User = await _context.Users.SingleAsync(p => p.Id == userId);

        User.IsAvailable = false;

        await _context.SaveChangesAsync();
    }
}
