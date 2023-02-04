using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Min.Data;

public class InventoryUnitOfWork<TContext>
    : UnitOfWorkAsync
        , IInventoryUnitOfWork
    where TContext : DbContext
{
    private readonly IItemRepo itemSync;
    private readonly IItemRepoAsync item;
    private readonly ICategoryRepo category;
    private readonly ICurrencyRepo currency;
    private readonly IStateRepo state;
    private readonly ITagRepo tag;
    private readonly IUnitRepo unit;

    public IItemRepo ItemSync => itemSync;
    public IItemRepoAsync Item => item;
    public ICategoryRepo Category => category;
    public ICurrencyRepo Currency => currency;
    public IStateRepo State => state;
    public ITagRepo Tag => tag;
    public IUnitRepo Unit => unit;

    public InventoryUnitOfWork(
        TContext context
        , IItemRepo itemSync
        , IItemRepoAsync item
        , ICategoryRepo category
        , ICurrencyRepo currency
        , IStateRepo state
        , ITagRepo tag
        , IUnitRepo unit)
            : base(context)
    {
        this.itemSync = itemSync;
        this.item = item;
        this.category = category;
        this.currency = currency;
        this.state = state;
        this.tag = tag;
        this.unit = unit;
        ArgumentNullException.ThrowIfNull(this.itemSync);
        ArgumentNullException.ThrowIfNull(this.item);
        ArgumentNullException.ThrowIfNull(this.category);
        ArgumentNullException.ThrowIfNull(this.currency);
        ArgumentNullException.ThrowIfNull(this.state);
        ArgumentNullException.ThrowIfNull(this.tag);
        ArgumentNullException.ThrowIfNull(this.unit);
    }
}