using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Application.Common.Persistence;

public interface IMenuRepository
{
    Task AddSync(Menu menu);
}