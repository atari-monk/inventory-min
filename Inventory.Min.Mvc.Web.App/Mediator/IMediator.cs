using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public interface IMediator
{
    Task<ItemsFullVM> Items(IApiClient api);
    Task<RelatedItemsVM> Related(IApiClient api, int? parentId);
    Task<ItemCreateVM> Create(IApiClient api);
    Task<ItemEditVM> Edit(IApiClient api, HttpClient client, ItemVM item);
}