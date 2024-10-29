using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Persistence;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
}