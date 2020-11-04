using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Domain
{
    public interface IAggregateRoot
    {
        public void Apply(dynamic @event);
        public IReadOnlyList<DomainEvent> GetUncommittedEvents();

    }
    public abstract class AggregateRoot<T>: Entity<T> , IAggregateRoot
    {
        private List<DomainEvent> _uncommittedEvents;
        protected AggregateRoot()
        {
            this._uncommittedEvents = new List<DomainEvent>();
        }
        public IReadOnlyList<DomainEvent> GetUncommittedEvents() => _uncommittedEvents.AsReadOnly();

        public void ApplyAndAddToUncommitedEvents(DomainEvent @event)
        {
            _uncommittedEvents.Add(@event);
            Apply(@event);
        }
        public abstract void Apply(dynamic @event);
    
    }

}
