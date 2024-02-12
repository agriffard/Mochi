namespace Mochi.Data;

/// <summary>
/// Provides extensions methods for <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static void AddDataRepositories(this IServiceCollection services)
    {
        services.AddTransient<IReportingRepository, ReportingRepository>();
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConfigurationConstants.DefaultConnectionStringName);
        services.AddDbContext<MochiContext>(options => options
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .UseSqlServer(connectionString));
    }
}
