using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    #region Private constructors declaration

    private MenuReview(
        Rating rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
        : base(MenuReviewId.CreateUnique())
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
    }

    #endregion

    #region Public properties declaration

    public Rating Rating { get; private set; }
    public string Comment { get; private set; }
    public HostId HostId { get; private set; }
    public MenuId MenuId { get; private set; }
    public GuestId GuestId { get; private set; }
    public DinnerId DinnerId { get; private set; }

    #endregion

    #region Public methods declaration

    public static MenuReview Create(
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId)
    {
        var ratingValueObject = Rating.Create(rating);
        return new MenuReview(
            ratingValueObject,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId
        );
    }

    #endregion
}