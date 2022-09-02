using Inventory.Min.Mvc.Web.App.Models;

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

    public async Task<Uri> CreateItemAsync(HttpClient client, ItemVM item)
    {
        var response = await client.PostAsJsonAsync(
            "api/items", item);
        response.EnsureSuccessStatusCode();

        // return URI of the created resource.
        return response.Headers.Location!;
    }
}