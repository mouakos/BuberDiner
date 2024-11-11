using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects
{
    public class GuestRatingId(Guid value) : AggregateRootId<Guid>(value)
    {
        #region Public methods declaration

        public static GuestRatingId Create(Guid value)
        {
            return new GuestRatingId(value);
        }

        public static GuestRatingId CreateUnique()
        {
            return new GuestRatingId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        #endregion
    }
}