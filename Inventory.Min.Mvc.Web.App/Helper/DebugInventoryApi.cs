namespace Inventory.Min.Mvc.Web.App;

public class DebugInventoryApi
    : ApiClient
{
    protected override string ApiHttpsEndPoint => "https://localhost:7276";  
    protected override string ApiHttpEndPoint => "http://localhost:5084"; 
}