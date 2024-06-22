namespace ProjectTemplate.Api.Helper.Extensions;

public static class AppSettingsEnvironmentSetup
{
    public static IHostBuilder UseAppSettingsEnvironment(this IHostBuilder host)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        host.ConfigureAppConfiguration(builder => {
            builder.AddJsonFile("appsettings.json", false, true);
            builder.AddJsonFile($"appsettings.{env}.json", false, true);
            builder.AddEnvironmentVariables();
        });

        return host;
    }
}
