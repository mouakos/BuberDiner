using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId, Guid>
    {
        #region Private fields declaration

        private readonly List<DinnerId> m_DinnerIds = new();
        private readonly List<MenuReviewId> m_MenuReviewIds = new();
        private readonly List<MenuSection> m_Sections = new();

        #endregion

        #region Private constructors declaration

        // ReSharper disable once UnusedMember.Local
        private Menu() { }

        private Menu(
            HostId hostId,
            string name,
            string description,
            AverageRating averageRating,
            List<MenuSection> sections)
            : base(MenuId.CreateUnique())
        {
            HostId = hostId;
            Name = name;
            Description = description;
            AverageRating = averageRating;
            m_Sections = sections;
        }

        #endregion

        #region Public properties declaration

        public AverageRating AverageRating { get; private set; } = null!;
        public DateTime CreatedDateTime { get; private set; }
        public string Description { get; private set; } = null!;
        public IReadOnlyList<DinnerId> DinnerIds => m_DinnerIds.AsReadOnly();
        public HostId HostId { get; private set; } = null!;
        public IReadOnlyList<MenuReviewId> MenuReviewIds => m_MenuReviewIds.AsReadOnly();
        public string Name { get; private set; } = null!;
        public IReadOnlyList<MenuSection> Sections => m_Sections.AsReadOnly();
        public DateTime UpdatedDateTime { get; private set; }

        #endregion

        #region Public methods declaration

        public static Menu Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection>? sections = null)
        {
            return new Menu(
                hostId,
                name,
                description,
                AverageRating.Create(),
                sections ?? new List<MenuSection>());
        }

        #endregion
    }
}