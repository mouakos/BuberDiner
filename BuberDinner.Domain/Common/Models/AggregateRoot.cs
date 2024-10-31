namespace BuberDinner.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
{
    #region Protected constructors declaration

    protected AggregateRoot(TId id) : base(id)
    {
        Id = id;
    }

    #endregion
}