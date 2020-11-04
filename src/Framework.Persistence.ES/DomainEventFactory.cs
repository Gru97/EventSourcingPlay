using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using Framework.Domain;
using Newtonsoft.Json;

namespace Framework.Persistence.ES
{
    internal static class DomainEventFactory
    {
        public static DomainEvent ToDomainEvent(ResolvedEvent @event)
        {
            var type = @event.Event.EventType;
            var body = Encoding.UTF8.GetString(@event.Event.Data);
            var domainEvent = (DomainEvent) JsonConvert.DeserializeObject(body, Type.GetType(type));
            return domainEvent;
        }

        public static List<DomainEvent> ToDomainEvent(List<ResolvedEvent> @events) =>
            @events.Select(ToDomainEvent).ToList();
    }
}