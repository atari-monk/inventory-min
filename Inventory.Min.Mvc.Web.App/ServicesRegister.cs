namespace Inventory.Min.Mvc.Web.App;

public class ServicesRegister
{
    private readonly WebApplicationBuilder builder;

    public ServicesRegister(WebApplicationBuilder builder)
    {
        this.builder = builder;
    }

    public void RegisterServices()
    {
        builder.Services.AddScoped<IApiClient, InventoryApi>();
    }
}