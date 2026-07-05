namespace Shared.Core.Events
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IEventAggregator _eventAggregator;

        public EventPublisher(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;
        }

        public async Task Publish<T>(T @event) where T : IEvent
        {
            await _eventAggregator.Publish<T>(@event);
        }
    }
}
