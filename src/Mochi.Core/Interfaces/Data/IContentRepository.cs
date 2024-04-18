namespace Mochi.Core.Interfaces.Data;

public partial interface IContentRepository
{
    string GetBySlug(string slug);
    Task<PageContent> GetPageBySlugAsync(string slug);
}
