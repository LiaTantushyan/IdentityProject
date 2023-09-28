using System.Reflection;
using IdentityProj.Infrastructure;
using IdentityProj.Infrastructure.Seed;
using IdentityProj.Installers;
using IdentityProj.Middlewares;
using IdentityProj.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseSerilog((hostingContext, _, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration));

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddControllers();

builder.Services.AddServices();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.InstallServices(builder.Configuration);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

Log.Information("Application Starting Up");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionHandler>();

app.MapControllers();

app.SeedAsync(app.Services).Run();