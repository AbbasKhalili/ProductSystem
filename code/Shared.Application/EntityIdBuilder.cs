namespace Shared.Application
{
    public interface IEntityIdBuilder<out T>
    {
        T Build(long id);
        T Build(Guid id);
    }

    public class EntityIdBuilder<T> : IEntityIdBuilder<T>
    {
        public T Build(long id)
        {
            var instance = Activator.CreateInstance(typeof(T), id);
            return (T)instance;
        }

        public T Build(Guid id)
        {
            var instance = Activator.CreateInstance(typeof(T), id);
            return (T)instance;
        }
    }
}
