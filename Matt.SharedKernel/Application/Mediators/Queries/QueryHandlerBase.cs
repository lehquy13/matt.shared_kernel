using Matt.ResultObject;
using MediatR;

namespace Matt.SharedKernel.Application.Mediators.Queries;

public abstract class QueryHandlerBase<TQuery, TResult> : RequestHandlerBase, IRequestHandler<TQuery, Result<TResult>>
    where TQuery : IQueryRequest<TResult> where TResult : class
{
    public abstract Task<Result<TResult>> Handle(TQuery getAllUserQuery, CancellationToken cancellationToken);
}

public abstract class QueryHandlerBase<TQuery> : RequestHandlerBase, IRequestHandler<TQuery, Result>
    where TQuery : IQueryRequest
{
    public abstract Task<Result> Handle(TQuery query, CancellationToken cancellationToken);
}