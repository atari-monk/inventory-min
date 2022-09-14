using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory.Min.Mvc.Web.App.Models;
using System.Diagnostics;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public class ItemsController
    : Controller
{
    private readonly IApiClient api;

    public ItemsController(IApiClient api)
    {
        this.api = api;
    }

    // GET: Items
    public async Task<IActionResult> Index()
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

    // GET: Items/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        var client = api.GetClinet();
        var item = await api.GetItemAsync(client, id);
        var lexicons = await api.GetLexicinsAsync(client);
        if (id == null || item == null || lexicons == null)
        {
            return NotFound();
        }
        var fullItem = new ItemFullVM{ Item = item, Lexicons = lexicons };
        return View(fullItem);
    }

    // GET: Items/Create
    public async Task<IActionResult> Create()
    {
        var model = new ItemCreateVM();
        model.Item = new ItemVM();
        var client = api.GetClinet();
        model.Lexicon = await api.GetLexicinsAsync(client);
        model.Items = await api.GetSmallItemsAsync(client);
        return View(model);
    }

    // POST: Items/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ItemFullVM itemContext)
    {
        // if (ModelState.IsValid == false)
        //     return View(itemVM);
        // var client = api.GetClinet();
        // await api.CreateItemAsync(client, itemVM);
        // return RedirectToAction(nameof(Index));

        if (ModelState.IsValid == false)
            return View(itemContext.Item);
        var client = api.GetClinet();
        await api.CreateItemAsync(client, itemContext.Item!);
        return RedirectToAction(nameof(Index));
    }

    // GET: Items/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        // if (id == null)
        // {
        //     return NotFound();
        // }
        // var client = api.GetClinet();
        // var item = await api.GetItemAsync(client, id);
        // if (item == null)
        // {
        //     return NotFound();
        // }
        // return View(item);

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
        return View(model);
    }

    // POST: Items/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

    // GET: Items/Delete/5
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

    // POST: Items/Delete/5
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