namespace Mochi.Data.Http;

/// <summary>
/// Provides extensions methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddDataHttpRepositories(this IServiceCollection services)
    {
        services.AddTransient<IContentRepository, ContentRepository>();
    }
}
