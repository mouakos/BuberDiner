using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    #region Private fields declaration

    private readonly List<DinnerId> m_DinnerIds = new();
    private readonly List<MenuReviewId> m_MenuReviewIds = new();
    private readonly List<MenuSection> m_MenuSections = new();

    #endregion

    #region Private constructors declaration

    private Menu(
        MenuId menuId,
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    #endregion

    #region Public properties declaration

    public AverageRating AverageRating { get; }
    public DateTime CreatedDateTime { get; }
    public string Description { get; }
    public IReadOnlyList<DinnerId> DinnerIds => m_DinnerIds.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyList<MenuReviewId> MenuReviewIds => m_MenuReviewIds.AsReadOnly();
    public IReadOnlyList<MenuSection> MenuSections => m_MenuSections.AsReadOnly();
    public string Name { get; }
    public DateTime UpdatedDateTime { get; }

    #endregion

    #region Public methods declaration

    public static Menu Create(string name,
        string description,
        AverageRating averageRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            averageRating,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    #endregion
}