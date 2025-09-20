using Mochi.Data.Http.ApiClients;
using Refit;

namespace Mochi.Data.Http;

/// <summary>
/// Provides extensions methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddDataHttpRepositories(this IServiceCollection services)
    {
        // Register Refit client
        services.AddRefitClient<IContentApiClient>()
            .ConfigureHttpClient(client =>
            {
                // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
                // The service name "api" matches the name defined in the AppHost Program.cs
                // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
                client.BaseAddress = new("https+http://api");
            });

        // Register the repository
        services.AddTransient<IContentRepository, ContentRepository>();
    }
}
