using System;

namespace SharedKernel.DomainEvents.Contracts
{
    public interface IDomainEvent
    {
        DateTime DateOcurred { get; }
    }
}
