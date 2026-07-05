using Shared.Core;

namespace Shared.Domain
{
    public abstract class EntityBase<T> : IEntityBase
    {
        public T Id { get; protected set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public override bool Equals(object obj)
        {
            if (!(obj is EntityBase<T> entity)) return false;

            return Id.Equals(entity.Id);
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder().Append(Id).ToHashCode();
        }
    }
}
