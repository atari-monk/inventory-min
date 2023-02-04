using System.Linq.Expressions;

namespace Inventory.Min.Data;

public record QueryData(
    Expression<Func<Item, bool>>? Filter
    , Func<IQueryable<Item>, IOrderedQueryable<Item>>? OrderBy
    , string IncludeProperties);
