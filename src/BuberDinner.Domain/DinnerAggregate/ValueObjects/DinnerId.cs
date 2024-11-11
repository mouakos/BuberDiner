using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects
{
    public sealed class DinnerId(Guid value) : AggregateRootId<Guid>(value)
    {
        #region Public methods declaration

        public static DinnerId Create(Guid guid)
        {
            return new DinnerId(guid);
        }

        public static DinnerId CreateUnique()
        {
            return new DinnerId(Guid.NewGuid());
        }

        /// <inheritdoc />
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        #endregion
    }
}