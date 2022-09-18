using Microsoft.Extensions.Options;

namespace Inventory.Min.Mvc.Web.App;

public class InventoryApi
    : ApiClient
{
    private readonly IOptions<MyApi> config;

    public InventoryApi(IOptions<MyApi> config)
    {
        this.config = config;
    }

    protected override string ApiHttpsEndPoint
    {
        get
        {
            var url = config.Value.Endpoints!.Https!.Url;
            ArgumentNullException.ThrowIfNull(url);
            return url;
        }
    }

    protected override string ApiHttpEndPoint
    {
        get
        {
            var url = config.Value.Endpoints!.Http!.Url;
            ArgumentNullException.ThrowIfNull(url);
            return url;
        }
    }
}