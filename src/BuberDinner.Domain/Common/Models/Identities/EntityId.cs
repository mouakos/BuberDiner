namespace BuberDinner.Domain.Common.Models.Identities
{
    public abstract class EntityId<TId>(TId value) : ValueObject
    {
        #region Public properties declaration

        public TId Value { get; } = value;

        #endregion

        #region Public methods declaration

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value!;
        }

        public override string? ToString()
        {
            return Value?.ToString() ?? base.ToString();
        }

        #endregion
    }
}