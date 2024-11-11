using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.HostAggregate.ValueObjects
{
    public sealed class HostId(Guid value) : AggregateRootId<Guid>(value)
    {
        #region Public methods declaration

        public static HostId Create(Guid guid)
        {
            return new HostId(guid);
        }

        public static HostId CreateUnique()
        {
            return new HostId(Guid.NewGuid());
        }

        /// <inheritdoc />
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        #endregion
    }
}