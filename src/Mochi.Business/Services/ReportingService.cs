namespace Mochi.Business.Services;

public partial class ReportingService : IReportingService
{
    private readonly IReportingRepository _repository;

    public ReportingService(IReportingRepository sampleRepository)
    {
        _repository = sampleRepository;
    }

    public List<XY<string, int>> GetByRange(ReportingType reportingType, RangeType range)
    {
        return _repository.SelectByRange(reportingType, range);
    }

    public int GetCount(ReportingType reportingType, string filter)
    {
        return _repository.SelectCount(reportingType, filter);
    }
}
