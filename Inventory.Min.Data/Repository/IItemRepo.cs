using System.Linq.Expressions;
using EFCore.Helper;

namespace Inventory.Min.Data;

public interface IItemRepo 
    : IRepository<Item>
{
	IEnumerable<Item> GetItem(
        Expression<Func<Item, bool>>? filter);
}