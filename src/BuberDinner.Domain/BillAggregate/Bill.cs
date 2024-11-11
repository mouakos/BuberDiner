using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.BillAggregate
{
    public class Bill : AggregateRoot<BillId>
    {
        #region Private constructors declaration

        // ReSharper disable once UnusedMember.Local
        private Bill() { }

        private Bill(
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime)
            : base(BillId.CreateUnique())
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
        public DinnerId DinnerId { get; private set; } = null!;
        public GuestId GuestId { get; private set; } = null!;
        public HostId HostId { get; private set; } = null!;
        public Price Price { get; private set; } = null!;
        public DateTime UpdatedDateTime { get; private set; }

        #endregion

        #region Public methods declaration

        public static Bill Create(
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime)
        {
            return new Bill(
                dinnerId,
                guestId,
                hostId,
                price,
                createdDateTime,
                updatedDateTime);
        }

        #endregion
    }
}