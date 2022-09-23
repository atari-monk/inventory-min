using System.Net;
using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App;

public interface IApiClient
{
    HttpClient GetClinet(bool ishttps = true);
    Task<List<ItemVM>> GetItemsInOneCategoryAsync(HttpClient client, int categoryId);
    Task<List<ItemVM>> GetRootItemsInOneCategoryAsync(HttpClient client, int categoryId);
    Task<List<ItemVM>> GetItemsExcludingOneStateAsync(HttpClient client, int stateId);
    Task<List<ItemVM>> GetRelatedItemsExcludingOneStateAsync(HttpClient client, int? parentId, int stateId);
    Task<List<ItemVM>> GetItemsAsync(HttpClient client);
    Task<List<ItemVM>> GetRelatedItemsAsync(HttpClient client, int? parentId);
    Task<List<ItemSmallVM>> GetSmallItemsAsync(HttpClient client);
    Task<ItemVM> GetItemAsync(HttpClient client, int? id);
    Task<Uri> CreateItemAsync(HttpClient client, ItemVM item);
    Task<ItemVM> UpdateItemAsync(HttpClient client, ItemVM item);
    Task<HttpStatusCode> DeleteItemAsync(HttpClient client, string id);

    Task<List<CategoryVM>> GetCategoriesAsync(HttpClient client);
    Task<List<CurrencyVM>> GetCurrenciesAsync(HttpClient client);
    Task<List<StateVM>> GetStatesAsync(HttpClient client);
    Task<List<TagVM>> GetTagsAsync(HttpClient client);
    Task<List<UnitVM>> GetUnitsAsync(HttpClient client);
    Task<LexiconVM> GetLexicinsAsync(HttpClient client);
}