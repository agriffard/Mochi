namespace Mochi.Business.Services;

public partial class ContentService : IContentService
{
    private readonly IContentRepository _repository;

    public ContentService(IContentRepository sampleRepository)
    {
        _repository = sampleRepository;
    }

    public string GetById(string id)
    {
        return _repository.GetById(id);
    }
}
