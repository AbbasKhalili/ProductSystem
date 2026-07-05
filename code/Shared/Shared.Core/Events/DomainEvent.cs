namespace Shared.Core.Events
{
    public class DomainEvent : IDomainEvent
    {
        public Guid EventId { get; }
        public DateTime CreateDateTime { get; }

        public DomainEvent()
        {
            EventId = Guid.NewGuid();
            CreateDateTime = DateTime.UtcNow;
        }
    }
}
