using System.Linq.Expressions;
using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Min.Data;

public class CurrencyRepo<TContext>
    : EFRepositoryAsync<Currency, TContext>
        , ICurrencyRepo
            where TContext : DbContext
{
    public CurrencyRepo(TContext context)
        : base(context)
    {
    }

    public IEnumerable<Currency> GetCurrency(
        Expression<Func<Currency, bool>>? filter)
    {
        return Get(
            filter
            , orderBy: (currencies) => currencies
                .OrderBy((item) => item.Id));
    }
}