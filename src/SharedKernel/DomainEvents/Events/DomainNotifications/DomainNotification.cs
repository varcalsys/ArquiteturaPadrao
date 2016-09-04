using System;
using SharedKernel.DomainEvents.Contracts;

namespace SharedKernel.DomainEvents.Events.DomainNotifications
{
    public class DomainNotification: IDomainEvent
    {
        public DateTime DateOcurred { get; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            DateOcurred = DateTime.Now;
            Key = key;
            Value = value;
        }

    }
}
