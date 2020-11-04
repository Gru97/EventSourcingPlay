namespace Framework.Domain
{
    public interface IEventSourceRepository<T, TKey> where T : AggregateRoot<TKey>
    {
        T GetById(TKey id);
        void AppendEvents(T aggregate);
        string GetStreamName(TKey id);
    }

    public class EventSourceRepository<T, TKey> : IEventSourceRepository<T, TKey> where T: AggregateRoot<TKey>
    {
        private readonly IEventStore _eventStore;
        private readonly IAggregateFactory _aggregateFactory;

        public EventSourceRepository(IEventStore eventStore, IAggregateFactory aggregateFactory)
        {
            _eventStore = eventStore;
            _aggregateFactory = aggregateFactory;
        }

        public T GetById(TKey id)
        {
            var events=_eventStore.GetEventOfStream(GetStreamName(id)).Result;
            var aggregate = _aggregateFactory.Reconstruct<T>(events);
            return aggregate;
        }

        public void AppendEvents(T aggregate)
        {
            var events = aggregate.GetUncommittedEvents();
            _eventStore.Append(GetStreamName(aggregate.Id) ,events);
        }

        public string GetStreamName(TKey id) => $"{typeof(T).Name}-{id}";
    }
}