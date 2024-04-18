namespace Mochi.Core.Interfaces.Business;

public partial interface IContentService
{
    string GetBySlug(string slug);
    Task<PageContent> GetPageBySlugAsync(string slug);
}
