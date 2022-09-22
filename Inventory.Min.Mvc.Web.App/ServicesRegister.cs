using Inventory.Min.Mvc.Web.App.Controllers;

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
        builder.Services.AddOptions();
        builder.Services.Configure<MyApi>(builder.Configuration.GetSection("MyApi"));
        builder.Services.AddScoped<IApiClient, InventoryApi>();
        builder.Services.AddScoped<IMediator, InventoryMediator>();
    }
}