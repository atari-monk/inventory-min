using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public class DefaultMediator
    : Mediator
{
    protected readonly ItemSmallVM EmptyItem = 
        new ItemSmallVM { Id = 0, Name = ""};

    public async override Task<ItemCreateVM> Create(IApiClient api)
    {
        var model = new ItemCreateVM();
        model.Item = new ItemVM();
        var client = api.GetClinet();
        model.Lexicon = await api.GetLexicinsAsync(client);
        model.Items = await api.GetSmallItemsAsync(client);
        model.Items.Insert(0, EmptyItem);
        return model;
    }

    public async override Task<ItemEditVM> Edit(IApiClient api, HttpClient client, ItemVM item)
    {
        var model = new ItemEditVM();
        model.Item = item;
        model.Lexicon = await api.GetLexicinsAsync(client);
        model.Items = await api.GetSmallItemsAsync(client);
        model.Items.Insert(0, EmptyItem);
        return model;
    }

    public async override Task<ItemsFullVM> Items(IApiClient api)
    {
        var client = api.GetClinet();
        var fullModel = new ItemsFullVM();
        fullModel.Items = await api.GetItemsAsync(client);
        fullModel.Categories = await api.GetCategoriesAsync(client);
        fullModel.Currencies = await api.GetCurrenciesAsync(client);
        fullModel.States = await api.GetStatesAsync(client);
        fullModel.Tags = await api.GetTagsAsync(client);
        fullModel.Units = await api.GetUnitsAsync(client);
        return fullModel;
    }

    public async override Task<RelatedItemsVM> Related(IApiClient api, int? parentId)
    {
        var client = api.GetClinet();
        var model = new RelatedItemsVM();
        model.Items = await api.GetRelatedItemsAsync(client, parentId);
        model.Lexicon = await api.GetLexicinsAsync(client);
        return model;
    }
}