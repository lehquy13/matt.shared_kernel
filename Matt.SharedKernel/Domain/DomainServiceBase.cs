using Matt.SharedKernel.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Matt.SharedKernel.Domain;

public abstract class DomainServiceBase(ILogger<DomainServiceBase> logger) : IDomainService
{
    protected readonly ILogger<DomainServiceBase> Logger = logger;
}