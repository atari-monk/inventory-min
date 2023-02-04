using System.Linq.Expressions;
using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Min.Data;

public class UnitRepo<TContext>
    : EFRepositoryAsync<Unit, TContext>
        , IUnitRepo
            where TContext : DbContext
{
    public UnitRepo(TContext context)
        : base(context)
    {
    }

    public IEnumerable<Unit> GetUnit(
        Expression<Func<Unit, bool>>? filter)
    {
        return Get(
            filter
            , orderBy: (items) => items
                .OrderBy((item) => item.Id));
    }
}