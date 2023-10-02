using IdentityProj.EmailSender.Models.Configuration;
using IdentityProj.EmailSender.Services;

namespace IdentityProj.EmailSender.Installers;

public static class Installer
{
    public static void InstallServices(this IServiceCollection services, IConfiguration configuration)
    {
        var emailSettings = new EmailSettings();
        configuration.Bind(nameof(EmailSettings), emailSettings);
        services.AddSingleton(emailSettings);
        
        services.AddScoped<EmailSenderService>();
    }
}