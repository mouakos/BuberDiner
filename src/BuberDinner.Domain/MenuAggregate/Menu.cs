using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.Entities;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    #region Private fields declaration

    private readonly List<DinnerId> m_DinnerIds = new();
    private readonly List<MenuReviewId> m_ReviewIds = new();
    private readonly List<MenuSection> m_Sections = new();

    #endregion

    #region Private constructors declaration

    private Menu(
        MenuId menuId,
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        List<MenuSection> sections)
        : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        m_Sections = sections;
    }

    #endregion

    #region Public properties declaration

    public AverageRating AverageRating { get; }
    public DateTime CreatedDateTime { get; }
    public string Description { get; }
    public IReadOnlyList<DinnerId> DinnerIds => m_DinnerIds.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyList<MenuReviewId> ReviewIds => m_ReviewIds.AsReadOnly();
    public IReadOnlyList<MenuSection> Sections => m_Sections.AsReadOnly();
    public string Name { get; }
    public DateTime UpdatedDateTime { get; }

    #endregion

    #region Public methods declaration

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        List<MenuSection> sections)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            AverageRating.Create(),
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow,
            sections);
    }

    #endregion
}