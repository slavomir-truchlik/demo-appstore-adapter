var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services);

// Configure the HTTP request pipeline.
var app = builder.Build();
Configure(app);

app.Run();

static void ConfigureServices(IServiceCollection services) 
{
    services.AddControllers();
    services.AddHealthChecks();
}

static void Configure(WebApplication app) 
{
    app.UseAuthorization();

    app.MapControllers();

    app.MapHealthChecks("/healthcheck");
}