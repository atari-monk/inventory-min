namespace Inventory.Min.Mvc.Web.App;

public class InventoryApi
{
    public HttpClient Initial()
    {
        var client = new HttpClient();
        //http://localhost:5084
        client.BaseAddress = new Uri("https://localhost:7276");
        return client;
    }
}