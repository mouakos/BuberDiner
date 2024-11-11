using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuItemId(Guid value) : AggregateRootId<Guid>(value)
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

        /// <inheritdoc />
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        #endregion
    }
}