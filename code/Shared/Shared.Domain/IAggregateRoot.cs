using Shared.Core.Events;

namespace Shared.Domain
{
    public interface IAggregateRoot
    {
        IEventPublisher Publisher { get; set; }
    }
}
