using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects
{
    public sealed class MenuReviewId(Guid value) : AggregateRootId<Guid>(value)
    {
        #region Public methods declaration

        public static MenuReviewId Create(Guid guid)
        {
            return new MenuReviewId(guid);
        }

        public static MenuReviewId CreateUnique()
        {
            return new MenuReviewId(Guid.NewGuid());
        }

        /// <inheritdoc />
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        #endregion
    }
}