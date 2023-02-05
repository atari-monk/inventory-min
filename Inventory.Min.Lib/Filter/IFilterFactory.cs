using System.Linq.Expressions;

namespace Inventory.Min.Lib;

public interface IFilterFactory<TEntity, TFilter>
{
    Expression<Func<TEntity, bool>>? GetFilter(TFilter filter);
}