using Mochi.Core.Entities;
namespace Mochi.Core.Interfaces.Data;

public partial interface IReportingRepository
{
    List<XY<string, int>> SelectByRange(ReportingType reportingType, RangeType range);
    int SelectCount(ReportingType reportingType, string filter);
}
