namespace Shared.Core.EventHandlers
{
    public interface IEventHandler<in T>
    {
        Task Handle(T happen);
    }
}
