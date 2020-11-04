using System;
using System.Collections.Generic;

namespace Framework.Domain
{
    public interface IAggregateFactory
    {
        T Reconstruct<T>(List<DomainEvent> events) where T : IAggregateRoot;

    }
    public class AggregateFactory:IAggregateFactory
    {
        public T Reconstruct<T>(List<DomainEvent> events) where T : IAggregateRoot
        {
            var aggregate =(T) Activator.CreateInstance(typeof(T), true);
            foreach (var @event in events)
            {
                aggregate.Apply(@event);
            }

            return aggregate;
        }
    }
}