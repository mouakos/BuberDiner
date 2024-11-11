using Ardalis.SmartEnum;

namespace BuberDinner.Domain.DinnerAggregate.Enums
{
    public sealed class ReservationStatus(string name, int value) : SmartEnum<ReservationStatus>(name, value)
    {
        #region Public fields declaration

        public static readonly ReservationStatus Cancelled = new(nameof(Cancelled), 3);
        public static readonly ReservationStatus PendingGuestApproval = new(nameof(PendingGuestApproval), 1);
        public static readonly ReservationStatus Reserved = new(nameof(Reserved), 2);

        #endregion
    }
}