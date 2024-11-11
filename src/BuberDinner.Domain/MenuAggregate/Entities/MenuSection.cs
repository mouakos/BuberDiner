using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        #region Private fields declaration

        private readonly List<MenuItem> m_Items = [];

        #endregion

        #region Private constructors declaration

        private MenuSection(
            MenuSectionId menuSectionId,
            string name,
            string description,
            List<MenuItem> items)
            : base(menuSectionId)
        {
            Name = name;
            Description = description;
            m_Items = items;
        }

        // ReSharper disable once UnusedMember.Local
        private MenuSection() { }

        #endregion

        #region Public properties declaration

        public IReadOnlyList<MenuItem> Items => m_Items.AsReadOnly();

        public string Description { get; private set; } = null!;
        public string Name { get; private set; } = null!;

        #endregion

        #region Public methods declaration

        public static MenuSection Create(
            string name,
            string description,
            List<MenuItem>? items)
        {
            return new MenuSection(
                MenuSectionId.CreateUnique(),
                name,
                description,
                items ?? []
            );
        }

        #endregion
    }
}