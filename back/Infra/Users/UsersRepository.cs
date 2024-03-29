﻿using dnd_domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dnd_infra.Users;

internal sealed class UsersRepository : IUsersRepository
{
    private readonly GlobalDbContext _dbContext;

    public UsersRepository(GlobalDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }
    public Task<List<User>> GetAsync()
        => _dbContext.Users.Select(u => u.ToDomain()).ToListAsync();

    public Task<User> GetByIdAsync(int id)
        => _dbContext.Users.Where(u => u.Id == id).Select(u => u.ToDomain()).SingleAsync();

    public async Task<User> CreateAsync(UserPayload userPayload)
    {
        CreatePasswordHash(userPayload.Password, out byte[] passwordHash, out byte[] passwordSalt);

        UserDal user = new()
        {
            Name = userPayload.UserName,
            Password = userPayload.Password,
            PictureUrl = userPayload.PictureUrl,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return user.ToDomain();
    }

    public async Task<User?> GetFromLoginPayloadAsync(LoginPayload loginPayload)
    {
        UserDal? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Name.Equals(loginPayload.UserName, StringComparison.CurrentCultureIgnoreCase) &&
                                                                        u.Password == loginPayload.Password);
        return user?.ToDomain();
    }

    public Task<bool> UserNameExistsAsync(string userName)
        => _dbContext.Users.AnyAsync(u => u.Name == userName);

    public async Task<bool> PasswordExistsAsync(string userName)
    {
        UserDal user = await _dbContext.Users.FirstAsync(u => u.Name == userName);
        return PasswordHashMatches(userName, user.PasswordHash, user.PasswordSalt);
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private static bool PasswordHashMatches(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
}
