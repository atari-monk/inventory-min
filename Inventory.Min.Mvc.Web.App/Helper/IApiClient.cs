using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App;

public interface IApiClient
{
    HttpClient GetClinet(bool ishttps = true);
    Task<Uri> CreateItemAsync(HttpClient client, ItemVM item);
}