namespace Shared.Core
{
    public interface IGuidGenerator
    {
        Guid New();
        Guid Empty();
        Guid Parse(string guid);
    }
    public class GuidGenerator : IGuidGenerator
    {
        public Guid New()
        {
            return Guid.NewGuid();
        }
        public Guid Empty()
        {
            return Guid.Empty;
        }

        public Guid Parse(string guid)
        {
            Guid.TryParse(guid, out var result);
            return result;
        }
    }
}
