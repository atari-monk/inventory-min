using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Inventory.Min.Mvc.Web.App.Models;
using Newtonsoft.Json;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public class HomeController
    : Controller
{
    private readonly IApiClient api;
    private readonly ILogger<HomeController> logger;

    public HomeController(ILogger<HomeController> logger)
    {
        this.logger = logger;
        this.api = new InventoryApi();
    }

    public async Task<IActionResult> Index()
    {
        var items = new List<ItemVM>();
        var client = api.GetClinet();
        var res = await client.GetAsync("api/items");
        if(res.IsSuccessStatusCode)
        {
            var result = res.Content.ReadAsStringAsync().Result;
            items = JsonConvert.DeserializeObject<List<ItemVM>>(result);
        }
        return View(items);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}