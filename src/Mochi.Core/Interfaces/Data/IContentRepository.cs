namespace Mochi.Core.Interfaces.Data;

public partial interface IContentRepository
{
    Task<PageContent> GetPageBySlugAsync(string slug);
}
