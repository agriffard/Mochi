namespace Mochi.Business;

/// <summary>
/// Provides extensions methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddTransient<IReportingService, ReportingService>();
    }
}
