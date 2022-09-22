using System.Net;
using Inventory.Min.Mvc.Web.App.Models;
using Newtonsoft.Json;

namespace Inventory.Min.Mvc.Web.App;

public abstract class ApiClient
    : IApiClient
{
    protected abstract string ApiHttpsEndPoint { get; }
    protected abstract string ApiHttpEndPoint { get; }

    public HttpClient GetClinet(bool ishttps = true)
    {
        var client = new HttpClient();
        var endPoint = ishttps ? ApiHttpsEndPoint : ApiHttpEndPoint;
        client.BaseAddress = new Uri(endPoint);
        return client;
    }

    public async Task<List<ItemVM>> GetItemsInOneCategoryAsync(HttpClient client, int categoryId)
    {
        var items = new List<ItemVM>();
        var response = await client.GetAsync($"api/items/category/{categoryId}");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            items = JsonConvert.DeserializeObject<List<ItemVM>>(result);
        }
        SetParentNames(items!);
        return items!;
    }

    public async Task<List<ItemVM>> GetItemsExcludingOneStateAsync(HttpClient client, int stateId)
    {
        var items = new List<ItemVM>();
        var response = await client.GetAsync($"api/items/state/{stateId}");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            items = JsonConvert.DeserializeObject<List<ItemVM>>(result);
        }
        SetParentNames(items!);
        return items!;
    }

    public async Task<List<ItemVM>> GetItemsAsync(HttpClient client)
    {
        var items = new List<ItemVM>();
        var response = await client.GetAsync("api/items");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            items = JsonConvert.DeserializeObject<List<ItemVM>>(result);
        }
        SetParentNames(items!);
        return items!;
    }

    public async Task<List<ItemVM>> GetRelatedItemsAsync(HttpClient client, int? parentId)
    {
        var items = await GetItemsAsync(client);
        var relatedItems = new List<ItemVM>();
        var parent = items.FirstOrDefault(i => i.Id == parentId);
        if (parent == null)
        {
            return relatedItems;
        }
        relatedItems.Add(parent);
        var lvl1 = GetRelated(parentId, items);
        foreach (var item in lvl1)
        {
            relatedItems.Add(item);
            var lvl2 = GetRelated(item.Id, items);
            relatedItems.AddRange(lvl2);
        }
        return relatedItems;
    }

    private static List<ItemVM> GetRelated(int? parentId, List<ItemVM> items)
    {
        var related = new List<ItemVM>();
        foreach (var item in items)
        {
            if (item.ParentId == parentId)
                related.Add(item);
        }
        return related;
    }

    public async Task<List<ItemVM>> GetRelatedItemsExcludingOneStateAsync(HttpClient client, int? parentId, int stateId)
    {
        var items = new List<ItemVM>();
        var response = await client.GetAsync($"api/items/relatedExcludingOneState/{parentId}/{stateId}");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            items = JsonConvert.DeserializeObject<List<ItemVM>>(result);
        }
        SetParentNames(items!);
        return items!;
    }

    public async Task<List<ItemSmallVM>> GetSmallItemsAsync(HttpClient client)
    {
        List<ItemSmallVM> items = new();
        var response = await client.GetAsync("api/items");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            items = JsonConvert.DeserializeObject<List<ItemSmallVM>>(result) ?? items;
        }
        return items.Where(i => i.CategoryId == 4)?.ToList() ?? items;
    }

    private void SetParentNames(List<ItemVM> items)
    {
        foreach (var item in items)
        {
            var parent = items.FirstOrDefault(p => p.Id == item.ParentId);
            item.ParentName = parent?.Name;
        }
    }

    public async Task<LexiconVM> GetLexicinsAsync(HttpClient client)
    {
        var item = new LexiconVM();
        item.Categories = await GetCategoriesAsync(client);
        item.Currencies = await GetCurrenciesAsync(client);
        item.States = await GetStatesAsync(client);
        item.Tags = await GetTagsAsync(client);
        item.Units = await GetUnitsAsync(client);
        return item;
    }

    public async Task<ItemSmallVM> GetSmallItemAsync(HttpClient client, int? id)
    {
        ItemSmallVM? itemVM = default;
        var item = await client.GetAsync("api/items/" + id);
        if(item.IsSuccessStatusCode)
        {
            var result = item.Content.ReadAsStringAsync().Result;
            itemVM = JsonConvert.DeserializeObject<ItemSmallVM>(result);
        }
        return itemVM!;
    }

    public async Task<ItemVM> GetItemAsync(HttpClient client, int? id)
    {
        ItemVM? itemVM = default;
        var item = await client.GetAsync("api/items/" + id);
        if(item.IsSuccessStatusCode)
        {
            var result = item.Content.ReadAsStringAsync().Result;
            itemVM = JsonConvert.DeserializeObject<ItemVM>(result);
            if (itemVM?.ParentId != null)
            {
                var parent = await GetSmallItemAsync(client, itemVM.ParentId);
                itemVM.ParentName = parent.Name;
            }
        }
        return itemVM!;
    }

    public async Task<Uri> CreateItemAsync(HttpClient client, ItemVM item)
    {
        var response = await client.PostAsJsonAsync(
            "api/items", item);
        response.EnsureSuccessStatusCode();

        // return URI of the created resource.
        return response.Headers.Location!;
    }

    public async Task<ItemVM> UpdateItemAsync(HttpClient client, ItemVM item)
    {
        var response = await client.PutAsJsonAsync(
            $"api/items/{item.Id}", item);
        response.EnsureSuccessStatusCode();

        // Deserialize the updated item from the response body.
        item = await response.Content.ReadAsAsync<ItemVM>();
        return item;
    }

    public async Task<HttpStatusCode> DeleteItemAsync(HttpClient client, string id)
    {
        var response = await client.DeleteAsync($"api/items/{id}");
        return response.StatusCode;
    }

    public async Task<List<CategoryVM>> GetCategoriesAsync(HttpClient client)
    {
        var categories = new List<CategoryVM>();
        var response = await client.GetAsync("api/categories");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            categories = JsonConvert.DeserializeObject<List<CategoryVM>>(result);
        }
        return categories!;
    }

    public async Task<List<CurrencyVM>> GetCurrenciesAsync(HttpClient client)
    {
        var currencies = new List<CurrencyVM>();
        var response = await client.GetAsync("api/currencies");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            currencies = JsonConvert.DeserializeObject<List<CurrencyVM>>(result);
        }
        return currencies!;
    }

    public async Task<List<StateVM>> GetStatesAsync(HttpClient client)
    {
        var states = new List<StateVM>();
        var response = await client.GetAsync("api/states");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            states = JsonConvert.DeserializeObject<List<StateVM>>(result);
        }
        return states!;
    }

    public async Task<List<TagVM>> GetTagsAsync(HttpClient client)
    {
        var tags = new List<TagVM>();
        var response = await client.GetAsync("api/tags");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            tags = JsonConvert.DeserializeObject<List<TagVM>>(result);
        }
        return tags!;
    }

    public async Task<List<UnitVM>> GetUnitsAsync(HttpClient client)
    {
        var units = new List<UnitVM>();
        var response = await client.GetAsync("api/units");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            units = JsonConvert.DeserializeObject<List<UnitVM>>(result);
        }
        return units!;
    }
}