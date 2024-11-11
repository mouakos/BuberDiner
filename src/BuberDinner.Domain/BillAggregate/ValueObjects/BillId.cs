using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.BillAggregate.ValueObjects
{
    public sealed class BillId(Guid value) : AggregateRootId<Guid>(value)
    {
        #region Public methods declaration

        public static BillId Create(Guid guid)
        {
            return new BillId(guid);
        }

        public static BillId CreateUnique()
        {
            return new BillId(Guid.NewGuid());
        }

        #endregion
    }
}