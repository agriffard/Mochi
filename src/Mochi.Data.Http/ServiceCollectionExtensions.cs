using System.Net.Http;

namespace Mochi.Data.Http;

/// <summary>
/// Provides extensions methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddDataHttpRepositories(this IServiceCollection services)
    {
        //services.AddHttpClient("OCClient", ctx => { ctx.BaseAddress = new Uri("https://localhost:7010/"); });

        services.AddHttpClient<ContentRepository>(client =>
        {
            // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
            // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
            client.BaseAddress = new("https+http://apiservice");
        });

        services.AddTransient<IContentRepository>(ctx =>
        {
            var clientFactory = ctx.GetRequiredService<IHttpClientFactory>();
            var httpClient = clientFactory.CreateClient("ApiClient");

            return new ContentRepository(httpClient);
        });

        services.AddTransient<IContentRepository, ContentRepository>();
    }
}
