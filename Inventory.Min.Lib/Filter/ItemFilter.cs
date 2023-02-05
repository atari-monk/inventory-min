using System.Linq.Expressions;
using Inventory.Min.Data;

namespace Inventory.Min.Lib;

public class ItemFilter 
    : IFilterFactory<Item, ItemFilterArgs>
{
    private ItemFilterArgs? filterArgs;

    private ItemFilterArgs FilterArgs
    {
        get
        {
            ArgumentNullException.ThrowIfNull(filterArgs);
            return filterArgs;
        }
    }

    public Expression<Func<Item, bool>>? GetFilter(
        ItemFilterArgs filterArgs)
    {
        SetFilter(filterArgs);
        if (FilterArgs.Id.HasValue) 
            return GetFilterById();
        if (FilterArgs.PurchaseDate.HasValue) 
            return GetFilterByPurchaseDate();
        return item => true;
    }

    private void SetFilter(ItemFilterArgs filterArgs)
    {
        this.filterArgs = filterArgs;
    }

    private Expression<Func<Item, bool>> GetFilterById()
    {
        var id = FilterArgs.Id!.Value;
        return item => item.Id == id
            || (item.ParentId.HasValue && item.ParentId == id);
    }    

    private Expression<Func<Item, bool>> GetFilterByPurchaseDate()
    {
        return item => item.PurchaseDate!.Value.Date.Equals(
            FilterArgs.PurchaseDate!.Value.Date);
    }
}