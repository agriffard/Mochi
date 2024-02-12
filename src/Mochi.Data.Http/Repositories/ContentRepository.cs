namespace Mochi.Data.Repositories;

public partial class ContentRepository : IContentRepository
{
    public ContentRepository(ILogger<ContentRepository> logger)
    {
    }

    public string GetById(string permalink)
    {
        // HttpClient calling https://localhost:7010/Api/Content/Page?slug=permalink
        return ""; // Call api to get content by id
    }
}
