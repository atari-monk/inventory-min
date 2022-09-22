using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public interface IMediator
{
    Task<ItemsFullVM> Items(IApiClient api);
    Task<RelatedItemsVM> Related(IApiClient api, int? parentId);
}