using System.Net.Http.Json;

namespace Mochi.Data.Repositories;

public partial class ContentRepository : IContentRepository
{
    public HttpClient _client { get; }

    public ContentRepository(HttpClient client)//ILogger<ContentRepository> logger)
    {
        _client = client;
    }

    public string GetBySlug(string slug)
    {
        // HttpClient calling https://localhost:7010/Api/Content/Pages/{slug}
        return "";
    }

    public async Task<PageContent> GetPageBySlugAsync(string slug)
    {
        // Todo : Handle exception
        var result = await _client.GetFromJsonAsync<PageContent>($"https://localhost:7010/Api/Content/Pages/{slug}");

        return result; // Call api to get content by id
    }
}
