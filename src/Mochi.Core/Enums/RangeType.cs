namespace Mochi.Core.Enums;

public enum RangeType
{
    AllTime = 0,

    /// <summary>
    /// Fitler by year
    /// </summary>
    Yearly = 1,

    /// <summary>
    /// Filter by quarter
    /// </summary>
    Quarter = 2,

    /// <summary>
    /// Filter by month
    /// </summary>
    Monthly = 3,

    /// <summary>
    /// Filter by week
    /// </summary>
    Weekly = 4,

    /// <summary>
    /// Filter by day
    /// </summary>
    Daily = 5,

    /// <summary>
    /// Filter by day of week
    /// </summary>
    DayOfWeek = 6,

    /// <summary>
    /// Filter by hour
    /// </summary>
    Hourly = 7,
}
