namespace Mochi.Core.Entities;

public partial class MenuContentItem
{
    public MenuContentItem()
    {
    }

    //public string Id { get; set; }
    public string Title { get; set; }
    //public string Name { get; set; }
    public string Url { get; set; }
    //public DateTime? CreatedUtc { get; set; }
    public List<MenuContentItem> Items { get; set; }

}
