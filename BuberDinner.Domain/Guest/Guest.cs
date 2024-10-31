using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
    #region Private fields declaration

    private readonly List<BillId> m_BillIds = new();
    private readonly List<MenuReviewId> m_MenuReviewIds = new();
    private readonly List<DinnerId> m_PastDinnerIds = new();
    private readonly List<DinnerId> m_PendingDinnerIds = new();
    private readonly List<Rating> m_Ratings = new();
    private readonly List<DinnerId> m_UpcomingDinnerIds = new();

    #endregion

    #region Private constructors declaration

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profilImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfilImage = profilImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    #endregion

    #region Public properties declaration

    public IReadOnlyList<BillId> BillIds => m_BillIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => m_MenuReviewIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => m_PastDinnerIds.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => m_PendingDinnerIds.AsReadOnly();
    public IReadOnlyList<Rating> Ratings => m_Ratings.AsReadOnly();
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => m_UpcomingDinnerIds.AsReadOnly();
    public AverageRating AverageRating { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string ProfilImage { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public UserId UserId { get; private set; }

    #endregion

    #region Public methods declaration

    public static Guest Create(
        string firstName,
        string lastName,
        string profilImage,
        AverageRating averageRating,
        UserId userId
    )
    {
        return new Guest(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profilImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    #endregion
}