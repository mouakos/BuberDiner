namespace BuberDinner.Domain.Common.Models
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasDomainEvents
        where TId : ValueObject
    {
        #region Private fields declaration

        private readonly List<IDomainEvent> m_DomainEvents = new();

        #endregion

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

        public IReadOnlyList<IDomainEvent> DomainEvents => m_DomainEvents.AsReadOnly();

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

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            m_DomainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            m_DomainEvents.Clear();
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