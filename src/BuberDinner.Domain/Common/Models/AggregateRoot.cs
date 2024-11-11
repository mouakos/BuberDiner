using BuberDinner.Domain.Common.Models.Identities;

namespace BuberDinner.Domain.Common.Models
{
    public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
        where TId : AggregateRootId<TIdType>
    {
        public new AggregateRootId<TIdType> Id { get; protected set; } = default!;

        #region Protected constructors declaration

        protected AggregateRoot(TId id) : base(id)
        {
            Id = id;
        }

        protected AggregateRoot()
        {
        }

        #endregion
    }
}