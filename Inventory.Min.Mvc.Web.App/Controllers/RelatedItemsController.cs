using Microsoft.AspNetCore.Mvc;
using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public class RelatedItemsController
    : Controller
{
    private readonly IApiClient api;

    public RelatedItemsController(IApiClient api)
    {
        this.api = api;
    }

    public async Task<IActionResult> Related(int? id)
    {
        var client = api.GetClinet();
        var model = new RelatedItemsVM();
        model.Items = await api.GetRelatedItemsAsync(client, id);
        model.Lexicon = await api.GetLexicinsAsync(client);
        return View(model);
    }
}