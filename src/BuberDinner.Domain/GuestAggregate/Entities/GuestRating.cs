using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using ErrorOr;

namespace BuberDinner.Domain.GuestAggregate.Entities
{
    public class GuestRating : Entity<GuestRatingId>
    {
        #region Private constructors declaration

        // ReSharper disable once UnusedMember.Local
        private GuestRating() { }

        private GuestRating(DinnerId dinnerId, HostId hostId, Rating rating)
            : base(GuestRatingId.CreateUnique())
        {
            DinnerId = dinnerId;
            HostId = hostId;
            Rating = rating;
        }

        #endregion

        #region Public properties declaration

        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }
        public DinnerId DinnerId { get; private set; } = null!;
        public HostId HostId { get; private set; } = null!;
        public Rating Rating { get; private set; } = null!;

        #endregion

        #region Public methods declaration

        public static ErrorOr<GuestRating> Create(DinnerId dinnerId, HostId hostId, int rating)
        {
            Rating ratingValueObject = Rating.Create(rating);

            return new GuestRating(dinnerId, hostId, ratingValueObject);
        }

        #endregion
    }
}