using Shared.Core.EventHandlers;

namespace Shared.Core.Events
{
    public interface IEventAggregator
    {
        Task Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;

        Task Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent;
    }
}
