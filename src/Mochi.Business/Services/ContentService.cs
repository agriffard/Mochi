namespace Mochi.Business.Services;

public partial class ContentService : IContentService
{
    private readonly IContentRepository _repository;

    public ContentService(IContentRepository sampleRepository)
    {
        _repository = sampleRepository;
    }

    public string GetBySlug(string slug)
    {
        return _repository.GetBySlug(slug);
    }

    public async Task<PageContent> GetPageBySlugAsync(string slug)
    {
        return await _repository.GetPageBySlugAsync(slug);
    }
}
