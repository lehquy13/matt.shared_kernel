using IScoped = Matt.SharedKernel.DependencyInjections.IScoped;

namespace Matt.SharedKernel.Domain.Interfaces;

public interface IUnitOfWork : IScoped
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}