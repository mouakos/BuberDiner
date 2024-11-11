namespace BuberDinner.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
        where TId : ValueObject
    {
        #region Protected constructors declaration

        protected Entity(TId id)
        {
            Id = id;
        }

        protected Entity()
        {
        }

        #endregion

        #region Public properties declaration

        public TId Id { get; protected set; } = default!;

        #endregion

        #region Public methods declaration

        public static bool operator ==(Entity<TId> left, Entity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Entity<TId> left, Entity<TId> right)
        {
            return !Equals(left, right);
        }

        /// <inheritdoc />
        public bool Equals(Entity<TId>? other)
        {
            return Equals((object?)other);
        }

        public override bool Equals(object? obj)
        {
            return obj is Entity<TId> entity && Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}