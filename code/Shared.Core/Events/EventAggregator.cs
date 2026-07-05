using Shared.Core.EventHandlers;
using System.Collections.Concurrent;

namespace Shared.Core.Events
{
    public class EventAggregator : IEventAggregator
    {
        private readonly ConcurrentBag<object> _subscriberList;
        public EventAggregator()
        {
            _subscriberList ??= [];
        }
        public async Task Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            _subscriberList.Add(eventHandler);
            await Task.FromResult(0);
        }

        public async Task Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent
        {
            var handlers = _subscriberList.OfType<IEventHandler<TEvent>>().ToList();

            foreach (var handler in handlers)
                await handler.Handle(eventToPublish);
        }
    }
}
