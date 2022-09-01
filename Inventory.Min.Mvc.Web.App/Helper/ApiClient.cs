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
}
