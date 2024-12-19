using Matt.ResultObject;
using Matt.SharedKernel.Domain.Interfaces;
using MediatR;

namespace Matt.SharedKernel.Application.Mediators.Commands;

public abstract class CommandHandlerBase<TCommand, TResult>(
    IUnitOfWork unitOfWork
) : RequestHandlerBase, IRequestHandler<TCommand, Result<TResult>>
    where TCommand : ICommandRequest<TResult>
    where TResult : class
{
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    public abstract Task<Result<TResult>> Handle(TCommand command, CancellationToken cancellationToken);
}

public abstract class CommandHandlerBase<TCommand>(IUnitOfWork unitOfWork)
    : RequestHandlerBase, IRequestHandler<TCommand, Result> where TCommand : ICommandRequest
{
    protected IUnitOfWork UnitOfWork { get; } = unitOfWork;
    public abstract Task<Result> Handle(TCommand command, CancellationToken cancellationToken);
}