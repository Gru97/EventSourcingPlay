using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public class InMemoryEventStore : IEventStore
    {
        private readonly Dictionary<string, List<DomainEvent>> _events = new Dictionary<string, List<DomainEvent>>();
        public Task Append(string streamId, IEnumerable<DomainEvent> events)
        {
            if (_events.ContainsKey(streamId))
                _events[streamId].AddRange(events);

            _events.Add(streamId, events.ToList()); 
            return Task.CompletedTask;
            
        }

        public Task<List<DomainEvent>> GetEventOfStream(string streamId)
        {
            return Task.FromResult(_events[streamId]);
        }
    }
}
