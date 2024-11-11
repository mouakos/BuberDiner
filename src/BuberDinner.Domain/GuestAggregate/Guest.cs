using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.Entities;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.GuestAggregate
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        #region Private fields declaration

        private readonly List<BillId> m_BillIds = new();
        private readonly List<MenuReviewId> m_MenuReviewIds = new();
        private readonly List<DinnerId> m_PastDinnerIds = new();
        private readonly List<DinnerId> m_PendingDinnerIds = new();
        private readonly List<GuestRating> m_Ratings = new();
        private readonly List<DinnerId> m_UpcomingDinnerIds = new();

        #endregion

        #region Private constructors declaration

        // ReSharper disable once UnusedMember.Local
        private Guest() { }

        private Guest(
            string firstName,
            string lastName,
            Uri profileImage,
            UserId userId,
            GuestRating? guestRating = null,
            GuestId? guestId = null)
            : base(GuestId.CreateUnique())
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            UserId = userId;
        }

        #endregion

        #region Public properties declaration

        public IReadOnlyList<BillId> BillIds => m_BillIds.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public IReadOnlyList<MenuReviewId> MenuReviewIds => m_MenuReviewIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds => m_PastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds => m_PendingDinnerIds.AsReadOnly();
        public IReadOnlyList<GuestRating> Ratings => m_Ratings.AsReadOnly();
        public IReadOnlyList<DinnerId> UpcomingDinnerIds => m_UpcomingDinnerIds.AsReadOnly();
        public DateTime UpdatedDateTime { get; private set; }
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public Uri ProfileImage { get; private set; } = null!;
        public UserId UserId { get; private set; } = null!;

        #endregion

        #region Public methods declaration

        public static Guest Create(
            string firstName, string lastName, Uri profileImage, UserId userId
        )
        {
            return new Guest(
                firstName, lastName, profileImage, userId);
        }

        #endregion
    }
}