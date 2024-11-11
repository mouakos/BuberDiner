using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects
{
    public class ReservationId(Guid value) : EntityId<Guid>(value)
    {
        #region Public methods declaration

        public static ReservationId Create(Guid value)
        {
            return new ReservationId(value);
        }

        public static ReservationId CreateUnique()
        {
            return new ReservationId(Guid.NewGuid());
        }

        #endregion
    }
}