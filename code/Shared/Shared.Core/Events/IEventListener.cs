using Shared.Core.EventHandlers;

namespace Shared.Core.Events
{
    public interface IEventListener
    {
        Task Subscribe<T>(IEventHandler<T> handler) where T : IDomainEvent;
    }
}
