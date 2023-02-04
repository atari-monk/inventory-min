using System.Linq.Expressions;
using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Min.Data;

public class ItemRepo<TContext>
    : EFRepository<Item, TContext>
    , IItemRepo
    where TContext : DbContext
{
    public ItemRepo(TContext context)
        : base(context)
    {
    }

    public IEnumerable<Item> GetItem(
        Expression<Func<Item, bool>>? filter)
    {
        return Get(
            filter
            , orderBy: (items) => items
                .OrderBy((item) => item.PurchaseDate)
                .ThenBy((item) => item.PurchasePrice)
            , includeProperties: 
                  $"{nameof(Item.Category)},{nameof(Item.State)},"
                + $"{nameof(Item.Parent)}");
    }
}
