using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Persistence;

public interface IUserRepository
{
    #region Public methods declaration

    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);

    #endregion
}