using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventStore.ClientAPI;
using Framework.Domain;
using Newtonsoft.Json;

namespace Framework.Persistence.ES
{
    internal static class EventDataFactory
        {
            public static EventData ToEventDate(DomainEvent @event)
            {
                var data = JsonConvert.SerializeObject(@event);
                return new EventData(
                    eventId: @event.Id,
                    type: @event.GetType().Name,
                    isJson: true,
                    data: Encoding.UTF8.GetBytes(data),
                    metadata: new byte[] { }
                );
            }

            public static List<EventData> ToEventDate(IEnumerable<DomainEvent> @events) =>
                @events.Select(ToEventDate).ToList();
        }
    
}
