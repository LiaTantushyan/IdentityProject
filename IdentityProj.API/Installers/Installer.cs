namespace IdentityProj.Installers;

public static class Installer
{
    public static void InstallServices(this IServiceCollection services, IConfiguration configuration)
    {
        SwaggerInstaller.Install(services, configuration);

        TokenInstaller.Install(services, configuration);
    }
}