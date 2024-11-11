using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository(BuberDinnerDbContext dbContext) : IMenuRepository
    {
        #region Public methods declaration

        /// <inheritdoc />
        public async Task AddSync(Menu menu)
        {
            await Task.CompletedTask;
            dbContext.Add(menu);
            await dbContext.SaveChangesAsync();
        }

        #endregion
    }
}