using System.Net;
using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App;

public interface IApiClient
{
    HttpClient GetClinet(bool ishttps = true);
    Task<List<ItemVM>> GetItemsAsync(HttpClient client);
    Task<ItemVM> GetItemAsync(HttpClient client, int? id);
    Task<Uri> CreateItemAsync(HttpClient client, ItemVM item);
    Task<ItemVM> UpdateItemAsync(HttpClient client, ItemVM item);
    Task<HttpStatusCode> DeleteItemAsync(HttpClient client, string id);

    Task<List<CategoryVM>> GetCategoriesAsync(HttpClient client);
    Task<List<CurrencyVM>> GetCurrenciesAsync(HttpClient client);
}