using Refit;

namespace Mochi.Data.Http.ApiClients;

public interface IContentApiClient
{
    [Get("/api/v1/contents/pages/{slug}")]
    Task<PageContent> GetPageBySlugAsync(string slug);
}
