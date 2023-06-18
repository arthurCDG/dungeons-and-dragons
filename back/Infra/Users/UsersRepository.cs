using dnd_domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Users;

internal sealed class UsersRepository : IUsersRepository
{
    private readonly GlobalDbContext _dbContext;

    public UsersRepository(GlobalDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new System.ArgumentNullException(nameof(dbContext));
    }

    public Task<List<User>> GetAsync(HashSet<int> userIds)
        => _dbContext.Users.Where(u => userIds.Contains(u.Id)).Select(u => u.ToDomain()).ToListAsync();
}
