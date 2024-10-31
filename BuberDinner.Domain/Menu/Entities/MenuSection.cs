using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    #region Private fields declaration

    private readonly List<MenuItem> m_MenuItems = new();

    #endregion

    #region Private constructors declaration

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description)
        : base(menuSectionId)
    {
        Name = name;
        Description = description;
    }

    #endregion

    #region Public properties declaration

    public string Description { get; }

    public IReadOnlyList<MenuItem> MenuItems => m_MenuItems.AsReadOnly();
    public string Name { get; }

    #endregion

    #region Public methods declaration

    public static MenuSection Create(
        string name,
        string description
    )
    {
        return new MenuSection(
            MenuSectionId.CreateUnique(),
            name,
            description
        );
    }

    #endregion
}