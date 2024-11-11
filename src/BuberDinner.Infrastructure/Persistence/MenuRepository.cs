using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{
    private static readonly List<Menu> Menus = [];

    /// <inheritdoc />
    public async Task AddSync(Menu menu)
    {
        await Task.CompletedTask;
        Menus.Add(menu);
    }
}