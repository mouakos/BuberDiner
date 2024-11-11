using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository(BuberDinnerDbContext dbContext) : IMenuRepository
{
    public async Task AddAsync(Menu menu)
    {
        dbContext.Add(menu);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(MenuId menuId)
    {
        return await dbContext.Menus.AnyAsync(menu => menu.Id == menuId);
    }

    public async Task<Menu?> GetByIdAsync(MenuId menuId)
    {
        return await dbContext.Menus.FirstOrDefaultAsync(menu => menu.Id == menuId);
    }

    public async Task<List<Menu>> ListAsync(HostId hostId)
    {
        return await dbContext.Menus.Where(menu => menu.HostId == hostId).ToListAsync();
    }

    public async Task UpdateAsync(Menu menu)
    {
        dbContext.Menus.Update(menu);
        await dbContext.SaveChangesAsync();
    }
}