using System.Reflection;
using IdentityProj.Extensions;
using IdentityProj.Middlewares;
using IdentityProj.PostgreSQL;
using IdentityProj.Services;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostingContext, services, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration));

builder.Services.AddControllers();

builder.Services.AddServices();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddConfigurations(builder.Configuration);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

/*builder.Services.AddIdentityServer()
// For development, use a real signing credential in production
    // .AddInMemoryApiResources(Config.GetApiResources()) // Define your API resources
    // .AddInMemoryClients(Config.GetClients()) // Define your client applications
    .AddInMemoryClients(Configs.GetClients())
    .AddDeveloperSigningCredential();
// .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer",
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

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

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();