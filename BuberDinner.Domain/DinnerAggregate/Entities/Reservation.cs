using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.Enums;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;

public class Reservation : Entity<ReservationId>
{
    #region Private constructors declaration

    private Reservation(ReservationId reservationId, int guestCount,
        ReservationStatus reservationStatus,
        GuestId guestId, BillId billId,
        DateTime? arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    #endregion

    #region Public properties declaration

    public DateTime? ArrivalDateTime { get; private set; }
    public BillId BillId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public int GuestCount { get; private set; }
    public GuestId GuestId { get; private set; }
    public ReservationStatus ReservationStatus { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    #endregion

    #region Public methods declaration

    public static Reservation Create(int guestCount,
        ReservationStatus reservationStatus,
        GuestId guestId, BillId billId,
        DateTime? arrivalDateTime)
    {
        return new Reservation(ReservationId.CreateUnique(), guestCount,
            reservationStatus,
            guestId,
            billId,
            arrivalDateTime,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    #endregion
}