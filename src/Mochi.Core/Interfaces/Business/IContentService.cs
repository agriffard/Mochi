namespace Mochi.Core.Interfaces.Business;

public partial interface IContentService
{
    Task<PageContent> GetPageBySlugAsync(string slug);
}
