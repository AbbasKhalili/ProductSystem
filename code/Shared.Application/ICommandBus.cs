
using Shared.Core;

namespace Shared.Application
{
    public interface ICommandBus
    {
        /// <summary>
        /// Dispatch method use for transactional command handler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        Task Dispatch<T>(T command) where T : ICommand;
    }
}
