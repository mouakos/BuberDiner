using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        #region Private constructors declaration

        private MenuItem(
            MenuItemId menuItemId,
            string name,
            string description)
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        // ReSharper disable once UnusedMember.Local
        private MenuItem() { }

        #endregion

        #region Public properties declaration

        public string Description { get; private set; } = null!;
        public string Name { get; private set; } = null!;

        #endregion

        #region Public methods declaration

        public static MenuItem Create(
            string name,
            string description
        )
        {
            return new MenuItem(
                MenuItemId.CreateUnique(),
                name,
                description
            );
        }

        #endregion
    }
}