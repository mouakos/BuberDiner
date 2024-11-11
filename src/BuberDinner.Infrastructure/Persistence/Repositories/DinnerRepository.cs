using BuberDinner.Application.Common.Persistence;
using System.Data;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class DinnerRepository(BuberDinnerDbContext dbContext) : IDinnerRepository
{
    public async Task AddAsync(Dinner dinner)
    {
        await dbContext.AddAsync(dinner);

        await dbContext.SaveChangesAsync();
    }

    public async Task<List<Dinner>> ListAsync(HostId hostId)
    {
        return await dbContext.Dinners.Where(dinner => dinner.HostId == hostId).ToListAsync();
    }
}