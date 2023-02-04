using System.Linq.Expressions;
using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Min.Data;

public class CategoryRepo<TContext>
    : EFRepositoryAsync<Category, TContext>
        , ICategoryRepo
            where TContext : DbContext
{
    public CategoryRepo(TContext context)
        : base(context)
    {
    }

    public IEnumerable<Category> GetCategory(
        Expression<Func<Category, bool>>? filter)
    {
        return Get(
            filter
            , orderBy: (categories) => categories
                .OrderBy((category) => category.Id)
            , includeProperties: 
                  $"{nameof(Category.Parent)}");
    }
}