using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects
{
    public class GuestId(Guid value) : AggregateRootId<Guid>(value)
    {
        #region Public methods declaration

        public static GuestId Create(Guid guid)
        {
            return new GuestId(guid);
        }

        public static GuestId CreateUnique()
        {
            return new GuestId(Guid.NewGuid());
        }

        #endregion
    }
}