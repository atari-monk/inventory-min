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
        var fullModel = new ItemFullVM();
        fullModel.Items = await api.GetItemsAsync(client);
        fullModel.Categories = await api.GetCategoriesAsync(client);
        fullModel.Currencies = await api.GetCurrenciesAsync(client);
        fullModel.States = await api.GetStatesAsync(client);
        return View(fullModel);
    }

    // GET: Items/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        var client = api.GetClinet();
        var item = await api.GetItemAsync(client, id);
        if (id == null || item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    // GET: Items/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Items/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description")] ItemVM itemVM)
    {
        if (ModelState.IsValid == false)
            return View(itemVM);
        var client = api.GetClinet();
        await api.CreateItemAsync(client, itemVM);
        return RedirectToAction(nameof(Index));
    }

    // GET: Items/Edit/5
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
        return View(item);
    }

    // POST: Items/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] ItemVM itemVM)
    {
        if (id != itemVM.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var client = api.GetClinet();
                await api.UpdateItemAsync(client, itemVM);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await ItemVMExists(itemVM.Id) == false)
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
        return View(itemVM);
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