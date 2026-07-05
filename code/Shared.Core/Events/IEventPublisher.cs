namespace Shared.Core.Events
{
    public interface IEventPublisher
    {
        Task Publish<T>(T domainEvent) where T : IEvent;
    }
}
