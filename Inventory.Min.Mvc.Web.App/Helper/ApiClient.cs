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

    public async Task<List<ItemVM>> GetItemsAsync(HttpClient client)
    {
        var items = new List<ItemVM>();
        var response = await client.GetAsync("api/items");
        if(response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            items = JsonConvert.DeserializeObject<List<ItemVM>>(result);
        }
        return items!;
    }

    public async Task<ItemVM> GetItemAsync(HttpClient client, int? id)
    {
        ItemVM? itemVM = default;
        var item = await client.GetAsync("api/items/" + id);
        if(item.IsSuccessStatusCode)
        {
            var result = item.Content.ReadAsStringAsync().Result;
            itemVM = JsonConvert.DeserializeObject<ItemVM>(result);
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
}