using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.GuestAggregate.ValueObjects
{
    public class GuestRatingId : ValueObject
    {
        private GuestRatingId(Guid value)
        {
            Value = value;
        }

        public static GuestRatingId CreateUnique()
        {
            return new GuestRatingId(Guid.NewGuid());
        }

        public Guid Value { get; }

        public static GuestRatingId Create(Guid value)
        {
            return new GuestRatingId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}