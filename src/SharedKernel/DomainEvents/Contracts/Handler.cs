using System;
using System.Collections.Generic;

namespace SharedKernel.DomainEvents.Contracts
{
    public abstract class Handler<T>: IDisposable where T: IDomainEvent
    {
        public abstract void Handle(T args);

        public virtual IEnumerable<T> Notify()
        {
            return null;
        }

        public virtual bool HasNotification()
        {
            return false;
        }

        public abstract void Dispose();
    }
}
