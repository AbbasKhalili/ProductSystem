using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using ProductManagement.Bootstrap;
using ProductManagement.Persistance.Mappings;
using ProductManagement.Presentation;
using ProductManagement.Security;
using Serilog;
using Shared.Core;
using Shared.Serilog;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

const string appName = "ProductManagement.Service";
Log.Logger = SerilogFactory.CreateLogger(appName);
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

    builder.Services.RegisterLocalization();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddAuthorization();
    builder.Services.AddHttpClient();
    builder.Services.AddSerilog();

    if (builder.Environment.IsProduction())
        builder.Configuration.AddEnvironmentVariables();

    //builder.Services.RegisterSwagger(appName);
    builder.Services.AddOpenApi();

    builder.AddCORS();

    builder.Services.AddSingleton<IUserResolver, UserResolver>();

    builder.AddAuthenticationByJwtToken();


    builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(ConnectionStrings.SectionName));
    var connectionString = builder.Configuration[$"{ConnectionStrings.SectionName}:DefaultConnection"];
    var readonlyConnectionString = builder.Configuration[$"{ConnectionStrings.SectionName}:ReadOnlyConnection"];
    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
        builder.AddModule(connectionString, readonlyConnectionString, typeof(ProductMapping).Assembly));

    builder.Host.UseSerilog();

    builder.Services.AddHealthChecks();





    var app = builder.Build();

    

    var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
    app.UseRequestLocalization(locOptions.Value);
    app.UseCors(RegisterCORSExtensions.CORSName);
    app.UseRouting();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandlerMiddleware();
        app.UseHsts();
    }

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference("/scalar", a =>
        {
            
        });

        //app.UseSwagger();

        

        //app.MapScalarUI("v1"); // This maps /scalar endpoint using the v1 OpenAPI doc

        //app.UseSwagger();
        //app.UseSwaggerUI(c =>
        //{
        //    c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"{appName} - V1");
        //    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        //});
    }

    app.MapHealthChecks("/health/live");

    app.MapHealthChecks("/health/ready",
        new HealthCheckOptions
        {
            Predicate = x => x.Tags.Contains("ready")
        });

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host of {App} terminated unexpectedly", appName);
    throw;
}
finally
{
    Log.Information("Shutting down web host for {App}", appName);
    Log.CloseAndFlush();
}
