using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityProj.EmailSender.Data;

public static class DependencyInjection
{
    public static void AddEmailSenderDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EmailSenderDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}