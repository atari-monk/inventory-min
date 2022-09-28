using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public abstract class Mediator 
    : IMediator
{
    public abstract Task<ItemsFullVM> Items(IApiClient api);

    public abstract Task<RelatedItemsVM> Related(IApiClient api, int? parentId);
}
