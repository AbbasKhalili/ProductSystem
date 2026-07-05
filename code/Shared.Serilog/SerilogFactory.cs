using Serilog;
using Serilog.Core;
using Serilog.Enrichers.Span;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;

namespace Shared.Serilog
{
    public static class SerilogFactory
    {
        public static Logger CreateLogger(string appName)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrEmpty(environment)) environment = "UnKnown";

            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.WithProperty("App", appName)
                .Enrich.WithProperty("Environment", environment)
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails(new DestructuringOptionsBuilder().WithDefaultDestructurers())
                .Enrich.WithSpan()
                .Destructure.ToMaximumDepth(2)
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Hosting.Diagnostics", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.AspNetCore.Localization.RequestLocalizationMiddleware", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery", LogEventLevel.Error);

            if (environment.Equals("development", StringComparison.CurrentCultureIgnoreCase))
            {
                loggerConfiguration.WriteTo.Console();
            }
            loggerConfiguration.WriteTo.File($"./logs/file.log", rollingInterval: RollingInterval.Day,
                            rollOnFileSizeLimit: true);

            return loggerConfiguration.CreateLogger();
        }
    }
}
