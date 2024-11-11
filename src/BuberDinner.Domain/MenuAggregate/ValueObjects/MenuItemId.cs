using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuItemId(Guid value) : EntityId<Guid>(value)
    {
        #region Public methods declaration

        public static MenuItemId Create(Guid guid)
        {
            return new MenuItemId(guid);
        }

        public static MenuItemId CreateUnique()
        {
            return new MenuItemId(Guid.NewGuid());
        }

        #endregion
    }
}