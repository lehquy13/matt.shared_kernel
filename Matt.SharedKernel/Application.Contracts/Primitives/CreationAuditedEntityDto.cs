﻿using Matt.SharedKernel.Auditing;

namespace Matt.SharedKernel.Application.Contracts.Primitives;

public abstract class CreationAuditedEntityDto<TId>
    : EntityDto<TId>, ICreationAuditedObject
    where TId : notnull
{
    public DateTime CreationTime { get; set; }

    public string? CreatorId { get; set; }

    protected CreationAuditedEntityDto(TId id) : base(id) => CreationTime = DateTime.Now.ToLocalTime();

    protected CreationAuditedEntityDto() => CreationTime = DateTime.Now.ToLocalTime();
}