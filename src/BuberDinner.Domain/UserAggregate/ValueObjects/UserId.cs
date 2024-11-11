using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.UserAggregate.ValueObjects
{
    public class UserId(Guid value) : AggregateRootId<Guid>(value)
    {
        #region Public methods declaration

        public static UserId Create(Guid guid)
        {
            return new UserId(guid);
        }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        #endregion
    }
}