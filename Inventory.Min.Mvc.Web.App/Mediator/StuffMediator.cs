using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public class StuffMediator
    : InventoryMediator
{
    public async override Task<ItemCreateVM> Create(IApiClient api)
    {
        var model = new ItemCreateVM();
        model.Item = new ItemVM();
        var client = api.GetClinet();
        model.Lexicon = await api.GetLexicinsAsync(client);
        model.Items = await api.GetSmallItemsAsync(client, 3);
        model.Items.Insert(0, EmptyItem);
        return model;
    }

    public async override Task<ItemEditVM> Edit(IApiClient api, HttpClient client, ItemVM item)
    {
        var model = new ItemEditVM();
        model.Item = item;
        model.Lexicon = await api.GetLexicinsAsync(client);
        model.Items = await api.GetSmallItemsAsync(client, 3);
        model.Items.Insert(0, EmptyItem);
        return model;
    }

    public async override Task<ItemsFullVM> Items(IApiClient api)
    {
        var client = api.GetClinet();
        var fullModel = new ItemsFullVM();
        fullModel.Items = await api.GetRootItemsInOneCategoryAsync(client, 3);
        fullModel.Categories = await api.GetCategoriesAsync(client);
        fullModel.Currencies = await api.GetCurrenciesAsync(client);
        fullModel.States = await api.GetStatesAsync(client);
        fullModel.Tags = await api.GetTagsAsync(client);
        fullModel.Units = await api.GetUnitsAsync(client);
        return fullModel;
    }
}