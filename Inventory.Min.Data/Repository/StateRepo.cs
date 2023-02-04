using System.Linq.Expressions;
using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Min.Data;

public class StateRepo<TContext>
    : EFRepositoryAsync<State, TContext>
        , IStateRepo
            where TContext : DbContext
{
    public StateRepo(TContext context)
        : base(context)
    {
    }

    public IEnumerable<State> GetState(
        Expression<Func<State, bool>>? filter)
    {
        return Get(
            filter
            , orderBy: (states) => states
                .OrderBy((state) => state.Id));
    }
}