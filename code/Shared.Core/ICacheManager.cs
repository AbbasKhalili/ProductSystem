namespace Shared.Core
{
    public interface ICacheManager
    {
        Task<T> Get<T>(string key);
        Task<T> Get<T>((string Key, TimeSpan Time) keyTime, Func<Task<T>> acquire);
        Task Set(string key, object data, int cacheTime);


        Task Set((string Key, TimeSpan Time) keyTime, object data);
        Task<bool> IsSet(string key);
        Task Remove(string key);
    }
}
