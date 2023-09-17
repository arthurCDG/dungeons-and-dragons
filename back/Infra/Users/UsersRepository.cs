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
    public Task<List<User>> GetAsync()
        => _dbContext.Users.Select(u => u.ToDomain()).ToListAsync();

    public Task<User> GetByIdAsync(int id)
        => _dbContext.Users.Where(u => u.Id == id).Select(u => u.ToDomain()).SingleAsync();

    public async Task<User> CreateAsync(UserPayload userPayload)
    {
        UserDal user = new()
        {
            Name = userPayload.UserName,
            Password = userPayload.Password, // TODO add encrypted password logic
            PictureUrl = userPayload.PictureUrl
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return user.ToDomain();
    }

    public async Task<User?> GetFromLoginPayloadAsync(LoginPayload loginPayload)
    {
        UserDal? user = await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Name.ToLower() == loginPayload.UserName.ToLower() && u.Password == loginPayload.Password);

        return user?.ToDomain();
    }
}
