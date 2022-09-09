namespace Inventory.Min.Mvc.Web.App;

public class InventoryApi
    : ApiClient
{
    protected override string ApiHttpsEndPoint => "https://localhost:5024";  
    protected override string ApiHttpEndPoint => "http://localhost:5023";
}