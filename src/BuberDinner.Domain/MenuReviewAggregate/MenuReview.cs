using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate
{
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

        // ReSharper disable once UnusedMember.Local
        private MenuReview() { }

        #endregion

        #region Public properties declaration

        public string Comment { get; private set; } = null!;
        public DinnerId DinnerId { get; private set; } = null!;
        public GuestId GuestId { get; private set; } = null!;
        public HostId HostId { get; private set; } = null!;
        public MenuId MenuId { get; private set; } = null!;
        public Rating Rating { get; private set; } = null!;

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
            Rating ratingValueObject = Rating.Create(rating);
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
}