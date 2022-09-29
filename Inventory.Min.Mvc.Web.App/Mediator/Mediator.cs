using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public abstract class Mediator 
    : IMediator
{
    public abstract Task<ItemsFullVM> Items(IApiClient api);

    public abstract Task<RelatedItemsVM> Related(IApiClient api, int? parentId);

    public abstract Task<ItemCreateVM> Create(IApiClient api);
    public abstract Task<ItemEditVM> Edit(IApiClient api, HttpClient client, ItemVM item);
}