namespace Mochi.Core.Entities;

public partial class PageContent
{
    public PageContent()
    {
    }

    public string Id { get; set; }
    public string Permalink { get; set; }
    public string Title { get; set; }
    public string Html { get; set; }
    public string MetaDescription { get; set; }
    public DateTime? CreatedUtc { get; set; }
}
