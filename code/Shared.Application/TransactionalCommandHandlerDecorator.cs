using Shared.Core;

namespace Shared.Application
{
    public class TransactionalCommandHandlerDecorator<T>(
        IUnitOfWork unitOfWork,
        ICommandHandler<T> commandHandler,
        ILoggerService loggerService) : ICommandHandler<T> where T : ICommand
    {
        public async Task Handle(T command)
        {
            try
            {
                await commandHandler.Handle(command);
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                loggerService.Error(ex);
                throw;
            }
        }
    }
}
