using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Framework.Domain;

namespace Framework.Persistence.ES
{
    public class EventStoreDb:IEventStore
    {
        private readonly IEventStoreConnection _connection;

        public EventStoreDb(IEventStoreConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<DomainEvent>> GetEventOfStream(string streamId)
        {
            var resolvedEvents= await EventStreamReader.Read(_connection, streamId, 0, 200);
            return DomainEventFactory.ToDomainEvent(resolvedEvents);
        }

        public async Task Append(string streamId, IEnumerable<DomainEvent> events)
        {
            var eventData = EventDataFactory.ToEventDate(@events);
            var result = await _connection.AppendToStreamAsync(streamId,ExpectedVersion.Any,eventData);
        }
    }
}
