using Matt.SharedKernel.Paginations;

namespace Matt.SharedKernel.Domain.Specifications.Interfaces;

public interface IGetListSpecification<TLEntity> : ISpecification<TLEntity>;

public interface IPaginatedGetListSpecification<TLEntity> : IGetListSpecification<TLEntity>, IPaginated;