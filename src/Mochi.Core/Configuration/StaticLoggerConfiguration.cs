namespace Mochi.Core.Configuration;

public class StaticLoggerConfiguration
{
    private static ILoggerFactory LoggerFactory { get; set; } = new LoggerFactory();
    public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
    public static ILogger CreateLogger(string categoryName) => LoggerFactory.CreateLogger(categoryName);

    public static void SetStaticLoggerFactory(ILoggerFactory loggerFactory)
    {
        LoggerFactory = loggerFactory;
    }
}
