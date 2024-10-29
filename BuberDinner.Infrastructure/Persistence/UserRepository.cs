using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();

    /// <inheritdoc />
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Task.FromResult(Users.FirstOrDefault(user => user.Email == email));
    }

    /// <inheritdoc />
    public async Task AddAsync(User user)
    {
        await Task.Run(() => Users.Add(user));
    }
}