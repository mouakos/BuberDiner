using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities
{
    public class Reservation : Entity<ReservationId>
    {
        #region Private constructors declaration

        private Reservation() { }

        private Reservation(
            GuestId guestId,
            int guestCount,
            DateTime? arrivalDateTime,
            BillId? billId,
            ReservationStatus status) : base(ReservationId.CreateUnique())
        {
            GuestId = guestId;
            GuestCount = guestCount;
            ArrivalDateTime = arrivalDateTime;
            BillId = billId;
            Status = status;
        }

        #endregion

        #region Public properties declaration

        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        public DateTime? ArrivalDateTime { get; private set; }
        public BillId? BillId { get; private set; }

        public int GuestCount { get; private set; }
        public GuestId GuestId { get; private set; } = null!;
        public ReservationStatus Status { get; private set; } = null!;

        #endregion

        #region Public methods declaration

        public static Reservation Create(
            GuestId guestId,
            int guestCount,
            ReservationStatus status,
            BillId? billId = null,
            DateTime? arrivalDateTime = null
        )
        {
            return new Reservation(
                guestId,
                guestCount,
                arrivalDateTime,
                billId,
                status);
        }

        #endregion
    }
}