using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

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

    #endregion

    #region Public properties declaration

    public string Description { get; }
    public string Name { get; }

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