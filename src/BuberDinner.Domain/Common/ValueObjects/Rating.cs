using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        #region Private constructors declaration

        // ReSharper disable once UnusedMember.Local
        private Rating() { }

        private Rating(int value)
        {
            Value = value;
        }

        #endregion

        #region Public properties declaration

        public int Value { get; }

        #endregion

        #region Public methods declaration

        public static Rating Create(int value)
        {
            return new Rating(value);
        }

        /// <inheritdoc />
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        #endregion
    }
}