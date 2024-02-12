namespace Mochi.Core.Interfaces.Business;

public partial interface IReportingService
{
    List<XY<string, int>> GetByRange(ReportingType reportingType, RangeType range);
    int GetCount(ReportingType reportingType, string filter);
}
