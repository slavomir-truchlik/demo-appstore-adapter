using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

RegisterServices(builder);

ConfigurePipeline(builder);

static void RegisterServices(WebApplicationBuilder builder)
{
    var services = builder.Services;

    services.AddHttpLogging(httpLogging =>
    {
        httpLogging.LoggingFields = HttpLoggingFields.All;
    });

    services.AddHealthChecks();

    services.AddControllers();
}

static void ConfigurePipeline(WebApplicationBuilder builder)
{
    var app = builder.Build();

    app.UseHttpLogging();

    app.MapHealthChecks("/healthcheck");

    app.MapControllers();

    app.Run();
}