using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuId(Guid value) : AggregateRootId<Guid>(value)
    {
        #region Public methods declaration

        public static MenuId Create(Guid guid)
        {
            return new MenuId(guid);
        }

        public static MenuId CreateUnique()
        {
            return new MenuId(Guid.NewGuid());
        }

        #endregion
    }
}