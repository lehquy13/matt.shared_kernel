namespace Matt.SharedKernel.Domain.Primitives.Abstractions;

public interface IEntity;

public interface IEntity<TId> : IEntity where TId : notnull
{
    TId Id { get; }
}