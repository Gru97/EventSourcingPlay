using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public interface IEventStore
    {
        Task<List<DomainEvent>> GetEventOfStream(string streamId);

        Task Append(string streamId, IEnumerable<DomainEvent> @events);

    }

    
}
