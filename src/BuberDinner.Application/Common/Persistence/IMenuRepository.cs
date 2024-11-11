using BuberDinner.Domain.MenuAggregate;

namespace BuberDinner.Application.Common.Persistence
{
    public interface IMenuRepository
    {
        #region Public methods declaration

        Task AddSync(Menu menu);

        #endregion
    }
}