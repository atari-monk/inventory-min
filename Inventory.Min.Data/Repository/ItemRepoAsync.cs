using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Min.Data;

public class ItemRepoAsync<TContext>
    : EFRepositoryAsync<Item, TContext>
        , IItemRepoAsync
            where TContext : DbContext
{
    private readonly Func<IQueryable<Item>, IOrderedQueryable<Item>>? defaultOrderBy;
    private readonly string defaultInclude;
    private readonly QueryData defaultQuery;
    
    public ItemRepoAsync(TContext context)
        : base(context)
    {
        defaultOrderBy
            = (items) => items.OrderBy((item) => item.Id)
                .ThenBy((item) => item.PurchaseDate);
        defaultInclude
            = $"{nameof(Item.Category)},{nameof(Item.State)},{nameof(Item.Parent)}";
        defaultQuery = new QueryData(
            (item) => true
            , defaultOrderBy
            , defaultInclude);
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await GetAsync(
            defaultQuery.Filter
            , defaultQuery.OrderBy
            , defaultQuery.IncludeProperties);
    }

    public async Task<IEnumerable<Item>> GetItemsAsync(QueryData queryData)
    {
        return await GetAsync(
            queryData.Filter
            , queryData.OrderBy
            , queryData.IncludeProperties);
    }

    public async Task<IEnumerable<Item>> GetItemsInOneCategoryAsync(int categoryId)
    {
        var queryData = new QueryData(
            (item) => item.CategoryId == categoryId
            , defaultOrderBy
            , defaultInclude);
        return await GetAsync(
            queryData.Filter
            , queryData.OrderBy
            , queryData.IncludeProperties);
    }
    
    public async Task<IEnumerable<Item>> GetItemsExcludingOneStateAsync(int stateId)
    {
          var queryData = new QueryData(
            (item) => item.StateId != stateId
            , defaultOrderBy
            , defaultInclude);
        return await GetAsync(
            queryData.Filter
            , queryData.OrderBy
            , queryData.IncludeProperties);
    }

    public async Task<IEnumerable<Item>> GetRelatedItemsExcludingOneStateAsync(int parentId, int stateId)
    {
          var queryData = new QueryData(
            (item) => 
                (item.Id == parentId || item.ParentId == parentId)
                && item.StateId != stateId
            , defaultOrderBy
            , defaultInclude);
        return await GetAsync(
            queryData.Filter
            , queryData.OrderBy
            , queryData.IncludeProperties);
    }

    public async Task<IEnumerable<Item>> GetRootItemsOfOneCategory(int categoryId)
    {
          var queryData = new QueryData(
            (item) => 
                item.ParentId == null
                && item.CategoryId == categoryId
            , defaultOrderBy
            , defaultInclude);
        return await GetAsync(
            queryData.Filter
            , queryData.OrderBy
            , queryData.IncludeProperties);
    }
}