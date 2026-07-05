using System.Text;

namespace Shared.Core
{
    public interface IUniqueIdGenerator
    {
        long GetLongId();
        string GetStringId();
        T GetObjectId<T>();
        string GetStringId(int len);
    }
    public class UniqueIdGenerator : IUniqueIdGenerator
    {
        public long GetLongId()
        {
            return Math.Abs(GetStringId().GetHashCode());
        }

        public string GetStringId()
        {
            return GetStringId(15);
        }

        public T GetObjectId<T>()
        {
            var instance = Activator.CreateInstance(typeof(T), GetLongId());
            return (T)instance;
        }

        public string GetStringId(int len)
        {
            var builder = new StringBuilder();
            Enumerable
                .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(len)
                .ToList().ForEach(e => builder.Append(e));
            return builder.ToString();
        }
    }
}
