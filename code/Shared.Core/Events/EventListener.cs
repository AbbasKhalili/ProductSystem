using Shared.Core.EventHandlers;

namespace Shared.Core.Events
{
    public class EventListener(IEventAggregator eventAggregator) : IEventListener
    {
        private readonly IEventAggregator _eventAggregator = eventAggregator;

        public async Task Subscribe<T>(IEventHandler<T> eventHandler) where T : IDomainEvent
        {
            await _eventAggregator.Subscribe<T>(eventHandler);
        }
    }
}
