namespace Mochi.Core.Entities;

public partial class MenuContent
{
    public MenuContent()
    {
    }

    //public string Id { get; set; }
    public string Title { get; set; }
    public string Alias { get; set; }
    //public DateTime? CreatedUtc { get; set; }
    public List<MenuContentItem> Items { get; set; }

}
