using System.Linq.Expressions;
using EFCore.Helper;

namespace Inventory.Min.Data;

public interface ICategoryRepo 
    : IEFRepositoryAsync<Category>
{
    IEnumerable<Category> GetCategory(
        Expression<Func<Category, bool>>? filter);
}