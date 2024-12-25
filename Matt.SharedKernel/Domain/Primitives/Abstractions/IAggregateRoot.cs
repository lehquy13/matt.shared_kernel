using Matt.SharedKernel.Domain.Interfaces;

namespace Matt.SharedKernel.Domain.Primitives.Abstractions;

public interface IAggregateRoot : IEntity, IHasDomainEvents;

public interface IAggregateRoot<TId> : IEntity<TId>, IAggregateRoot where TId : notnull;