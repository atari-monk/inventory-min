namespace Inventory.Min.Mvc.Web.App;

public interface IApiClient
{
    HttpClient GetClinet(bool ishttps = true);
}
