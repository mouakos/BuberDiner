using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Application.Common.Persistence
{
    public interface IMenuRepository
    {
        #region Public methods declaration

        Task UpdateAsync(Menu menu);
        Task AddAsync(Menu menu);
        Task<Menu?> GetByIdAsync(MenuId menuId);
        Task<bool> ExistsAsync(MenuId menuId);
        Task<List<Menu>> ListAsync(HostId hostId);

        #endregion
    }
}