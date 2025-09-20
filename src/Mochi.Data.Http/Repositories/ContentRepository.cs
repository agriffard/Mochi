using System.Net.Http.Json;
using Mochi.Data.Http.ApiClients;

namespace Mochi.Data.Repositories;

public partial class ContentRepository : IContentRepository
{
    private readonly IContentApiClient _contentApiClient;

    public ContentRepository(IContentApiClient contentApiClient)
    {
        _contentApiClient = contentApiClient;
    }

    public async Task<PageContent> GetPageBySlugAsync(string slug)
    {
        // Using Refit client to get content by slug
        var result = await _contentApiClient.GetPageBySlugAsync(slug);
        return result;
    }
}
