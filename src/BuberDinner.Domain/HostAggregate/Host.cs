using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate
{
    public sealed class Host : AggregateRoot<HostId, Guid>
    {
        #region Private fields declaration

        private readonly List<DinnerId> m_DinnerIds = new();
        private readonly List<MenuId> m_MenuIds = new();

        #endregion

        #region Private constructors declaration

        // ReSharper disable once UnusedMember.Local
        private Host() { }

        private Host(
            string firstName,
            string lastName,
            Uri profileImage,
            UserId userId,
            AverageRating averageRating)
            : base(HostId.CreateUnique())
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            UserId = userId;
            AverageRating = averageRating;
        }

        #endregion

        #region Public properties declaration

        public IReadOnlyList<DinnerId> DinnerIds => m_DinnerIds.AsReadOnly();
        public IReadOnlyList<MenuId> MenuIds => m_MenuIds.AsReadOnly();
        public AverageRating AverageRating { get; private set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public Uri ProfileImage { get; private set; } = null!;
        public UserId UserId { get; private set; } = null!;

        #endregion

        #region Public methods declaration

        public static Host Create(
            string firstName,
            string lastName,
            Uri profileImage,
            UserId userId
        )
        {
            return new Host(
                firstName,
                lastName,
                profileImage,
                userId,
                AverageRating.Create()
            );
        }

        #endregion
    }
}