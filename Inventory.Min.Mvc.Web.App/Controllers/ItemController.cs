using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory.Min.Mvc.Web.App.Models;
using System.Diagnostics;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public class ItemController
    : Controller
{
    private readonly IApiClient api;
    private readonly IMediator mediator;
    private readonly ItemSmallVM emptyItem = new ItemSmallVM { Id = 0, Name = ""};

    public ItemController(
        IApiClient api,
        IMediator mediator)
    {
        this.api = api;
        this.mediator = mediator;
    }

    public async Task<IActionResult> Items()
    {
        return View(await mediator.Items(api));
    }

    public async Task<IActionResult> Related(int? id)
    {
        return View(await mediator.Related(api, id));
    }

    public async Task<IActionResult> ItemsMega()
    {
        var client = api.GetClinet();
        var fullModel = new ItemsFullVM();
        fullModel.Items = await api.GetItemsAsync(client);
        fullModel.Categories = await api.GetCategoriesAsync(client);
        fullModel.Currencies = await api.GetCurrenciesAsync(client);
        fullModel.States = await api.GetStatesAsync(client);
        fullModel.Tags = await api.GetTagsAsync(client);
        fullModel.Units = await api.GetUnitsAsync(client);
        return View(fullModel);
    }

    public async Task<IActionResult> RelatedMega(int? id)
    {
        var client = api.GetClinet();
        var model = new RelatedItemsVM();
        model.Items = await api.GetRelatedItemsAsync(client, id);
        model.Lexicon = await api.GetLexicinsAsync(client);
        return View(model);
    }

    public async Task<IActionResult> Details(int? id)
    {
        var client = api.GetClinet();
        var item = await api.GetItemAsync(client, id);
        var lexicons = await api.GetLexicinsAsync(client);
        if (id == null || item == null || lexicons == null)
        {
            return NotFound();
        }
        var model = new ItemDetailVM{ Item = item, Lexicon = lexicons };
        return View(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = new ItemCreateVM();
        model.Item = new ItemVM();
        var client = api.GetClinet();
        model.Lexicon = await api.GetLexicinsAsync(client);
        model.Items = await api.GetSmallItemsAsync(client);
        model.Items.Insert(0, emptyItem);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ItemFullVM itemContext)
    {
        if (ModelState.IsValid == false)
            return View(itemContext.Item);
        if(itemContext.Item?.ParentId == 0) 
            itemContext.Item.ParentId = null;
        var client = api.GetClinet();
        await api.CreateItemAsync(client, itemContext.Item!);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var client = api.GetClinet();
        var item = await api.GetItemAsync(client, id);
        if (item == null)
        {
            return NotFound();
        }
        var model = new ItemEditVM();
        model.Item = item;
        model.Lexicon = await api.GetLexicinsAsync(client);
        model.Items = await api.GetSmallItemsAsync(client);
        model.Items.Insert(0, emptyItem);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id
        , [Bind("Id,Name,Description,InitialCount,CurrentCount,CategoryId,PurchaseDate,CurrencyId,PurchasePrice,SellPrice,ImagePath,LengthUnitId,Length,Heigth,Depth,Diameter,VolumeUnitId,Volume,Mass,MassUnitId,TagId,StateId,ParentId")]
            ItemVM item)
    {
        if (id != item?.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                if(item.ParentId == 0) 
                    item.ParentId = null;
                var client = api.GetClinet();
                await api.UpdateItemAsync(client, item);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await ItemVMExists(item.Id) == false)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(item);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var client = api.GetClinet();
        var item = await api.GetItemAsync(client, id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = api.GetClinet();
        var item = await api.GetItemAsync(client, id);
        if (item != null)
        {
            await api.DeleteItemAsync(client, item.Id.ToString());
        }
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> ItemVMExists(int id)
    {
        var client = api.GetClinet();
        var item = await api.GetItemAsync(client, id);
        if (item == null)
        {
            return false;
        }
        return true;
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