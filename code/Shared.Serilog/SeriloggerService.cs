using Serilog;
using Shared.Core;

namespace Shared.Serilog
{
    public class SeriloggerService : ILoggerService
    {
        public void Information(string message)
        {
            Log.Information(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Error(Exception exception)
        {
            Log.Error(exception, "Error");
        }

        public void Error(Exception exception, string message)
        {
            Log.Error(exception, message);
        }

        public void Error(Exception exception, string message, params object[] param)
        {
            Log.Error(exception, message, param);
        }
    }
}
