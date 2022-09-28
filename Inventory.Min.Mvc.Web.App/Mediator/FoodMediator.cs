using Inventory.Min.Mvc.Web.App.Models;

namespace Inventory.Min.Mvc.Web.App.Controllers;

public class FoodMediator
    : Mediator
{
    public async override Task<ItemsFullVM> Items(IApiClient api)
    {
        var client = api.GetClinet();
        var fullModel = new ItemsFullVM();
        fullModel.Items = await api.GetRootItemsInOneCategoryAsync(client, 4);
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
        model.Items = await api.GetRelatedItemsExcludingOneStateAsync(client, parentId, 3);
        model.Lexicon = await api.GetLexicinsAsync(client);
        return model;
    }
}