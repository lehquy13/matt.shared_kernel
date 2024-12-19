using FluentValidation;
using MediatR;

namespace Matt.SharedKernel.Application.Validations;

public class ValidationBehavior<TRequest, TResponse>(
    IValidator<TRequest>? validator = null) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (validator == null)
        {
            return await next();
        }

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors.ToList();

        var errorMessages =
            errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(e => e.ErrorMessage).ToList()
                );

        throw new ValidationException(errorMessages);
    }
}