using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Bill;

public class Bill : AggregateRoot<BillId>
{
    #region Private constructors declaration

    private Bill(
        BillId billId,
        DinnerId dinnerId,
        HostId hostId,
        Price price,
        GuestId guestId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(billId)
    {
        DinnerId = dinnerId;
        HostId = hostId;
        Price = price;
        GuestId = guestId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    #endregion

    #region Public properties declaration

    public DateTime CreatedDateTime { get; private set; }
    public DinnerId DinnerId { get; private set; }
    public GuestId GuestId { get; private set; }
    public HostId HostId { get; private set; }
    public Price Price { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    #endregion

    #region Public methods declaration

    public static Bill Create(
        DinnerId dinnerId,
        HostId hostId,
        Price price,
        GuestId guestId)
    {
        return new Bill(
            BillId.CreateUnique(),
            dinnerId,
            hostId,
            price,
            guestId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    #endregion
}