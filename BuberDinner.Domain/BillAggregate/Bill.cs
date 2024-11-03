using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.BillAggregate;

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