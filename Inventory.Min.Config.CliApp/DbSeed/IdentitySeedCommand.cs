using Inventory.Min.Mvc.Web.App;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Min.Config.CliApp;

public class IdentitySeedCommand
    : ICommand
{
    public async Task ExecuteAsync()
    {
        var builder = WebApplication.CreateBuilder();
        var identityConfig = new IdentityConfig(builder);
        identityConfig.RegisterServices();
        var host = builder.Build();
        using (var scope = host.Services.CreateScope())
        {
            await DbInitializer.Initialize(scope.ServiceProvider);
        }
    }
}