using OrchardCore.Seo.Models;

namespace Mochi.Controllers;

[ApiController]
[Produces("application/json")]
//[Authorize(AuthenticationSchemes = "Api"), IgnoreAntiforgeryToken]
[Route("api/[controller]")]
public class ContentController : Controller
{
    private readonly IAuthorizationService _authorizationService;
    private readonly IContentManager _contentManager;
    private readonly IOrchardHelper _orchardHelper;
    private readonly ISession _session;
    private readonly ILogger<ContentController> _logger;

    public ContentController(IAuthorizationService authorizationService, IContentManager contentManager, IOrchardHelper orchardHelper, ISession session, ILogger<ContentController> logger)
    {
        _authorizationService = authorizationService;
        _contentManager = contentManager;
        _orchardHelper = orchardHelper;
        _session = session;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetById(string id)
    {
        var contentItem = await _contentManager.GetAsync(id);

        if (contentItem == null)
        {
            return NotFound();
        }

        return new ObjectResult(contentItem);
    }

    [HttpGet("menus/{alias}")]
    public async Task<IActionResult> GetMenuByAlias(string alias)
    {
        var result = new MenuContent();
        var menu = await _orchardHelper.GetContentItemByAliasAsync(alias);

        if (menu == null)
        {
            return NotFound();
        }

        //result.Id = contentItem.ContentItemId;
        result.Title = menu.DisplayText;
        result.Alias = menu.As<AliasPart>().Alias;
        //result.CreatedUtc = menu.CreatedUtc;

        var items = GetMenuItems(menu);
        result.Items = items;

        return new ObjectResult(result);
    }

    //[HttpGet("pages/{id}")]
    //public async Task<IActionResult> GetPageById(string id)
    //{
    //    var result = new PageContent();
    //    var contentItem = await _contentManager.GetAsync(id);

    //    if (contentItem == null)
    //    {
    //        return NotFound();
    //    }

    //var result = GetPageFromContentItem(contentItem);

    //    return new ObjectResult(result);
    //}

    [HttpGet("pages/{slug}")]
    public async Task<IActionResult> GetPageBySlug(string slug)
    {
        var contentItem = await _orchardHelper.GetContentItemBySlugAsync(slug);

        if (contentItem == null)
        {
            return NotFound();
        }

        var result = GetPageFromContentItem(contentItem);

        return new ObjectResult(result);
    }

    [HttpGet("pages")]
    public async Task<IActionResult> GetPages()
    {
        var result = new List<PageContent>();
        var query = _session.Query<ContentItem, ContentItemIndex>();
        query = query.With<ContentItemIndex>(x => x.ContentType == "Page");
        query = query.With<ContentItemIndex>(x => x.Published);
        query = query.OrderByDescending(x => x.PublishedUtc);
        var contentItems = await query.ListAsync(); //.Skip(pager.GetStartIndex()).Take(pager.PageSize).ListAsync();

        foreach (var contentItem in contentItems)
        {
            result.Add(GetPageFromContentItem(contentItem));
        }

        return new ObjectResult(result);
    }

    //[HttpPost]
    ////[Authorize]
    //public async Task<IActionResult> AddContent(ContentItem contentItem)
    //{
    //    //if (!await _authorizationService.AuthorizeAsync(User, Permissions.DemoAPIAccess))
    //    //{
    //    //    return this.ChallengeOrForbid("Api");
    //    //}

    //    await _contentManager.CreateAsync(contentItem);

    //    return new ObjectResult(contentItem);
    //}

    private List<MenuContentItem> GetMenuItems(ContentItem contentItem)
    {
        var result = new List<MenuContentItem>();
        if (contentItem.As<MenuItemsListPart>() != null)
        {
            foreach (var menuItem in contentItem.As<MenuItemsListPart>().MenuItems)
            {
                var item = new MenuContentItem();
                item.Title = menuItem.DisplayText;
                //item.Name = menuItem.As<LinkMenuItemPart>().Name;
                item.Url = menuItem.As<LinkMenuItemPart>().Url; // Remove "~" from url?
                //item.CreatedUtc = menuItem.CreatedUtc;

                // Get items recursively
                item.Items = GetMenuItems(menuItem);

                result.Add(item);
            }
        }
        return result;
    }

    private static PageContent GetPageFromContentItem(ContentItem contentItem)
    {
        var result = new PageContent();
        result.Id = contentItem.ContentItemId;
        result.Title = contentItem.DisplayText; //contentItem.As<TitlePart>().Title;
        result.Permalink = contentItem.As<AutoroutePart>().Path;
        result.Html = contentItem.As<HtmlBodyPart>().Html;
        result.CreatedUtc = contentItem.CreatedUtc;

        if (contentItem.As<SeoMetaPart>() != null)
        {
            result.MetaDescription = contentItem.As<SeoMetaPart>().MetaDescription;
        }

        return result;
    }
}
