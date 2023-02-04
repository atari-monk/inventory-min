using EFCore.Helper;

namespace Inventory.Min.Data;

public interface IInventoryUnitOfWork 
	: IUnitOfWorkAsync
{
	IItemRepo ItemSync { get; }
	IItemRepoAsync Item { get; }
    ICategoryRepo Category { get; }
    ICurrencyRepo Currency { get; }
    IStateRepo State { get; }
    ITagRepo Tag { get; }
    IUnitRepo Unit { get; }
}