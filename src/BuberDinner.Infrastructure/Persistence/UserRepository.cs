using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.UserAggregate;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    #region Private fields declaration

    private static readonly List<User> Users = new();

    #endregion

    #region Public methods declaration

    /// <inheritdoc />
    public async Task AddAsync(User user)
    {
        await Task.Run(() => Users.Add(user));
    }

    /// <inheritdoc />
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Task.FromResult(Users.FirstOrDefault(user => user.Email == email));
    }

    #endregion
}