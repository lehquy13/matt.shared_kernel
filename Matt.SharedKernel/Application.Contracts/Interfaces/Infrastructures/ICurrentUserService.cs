using Matt.SharedKernel.Results;

namespace Matt.SharedKernel.Application.Contracts.Interfaces.Infrastructures;

public interface ICurrentUserService
{
    Guid UserId { get; }
    List<string> Permissions { get; }
    List<string> Roles { get; }
    Result Authenticated();
    string Email { get; }
    string? FullName { get; }
    string? Tenant { get; }
    bool IsAuthenticated { get; }
}