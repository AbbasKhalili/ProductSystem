namespace Shared.Core
{
    public interface IServiceLocator
    {
        T GetInstance<T>() where T : class;
        object GetInstance(Type serviceType);
    }
}
