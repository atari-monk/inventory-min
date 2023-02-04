using System.Linq.Expressions;
using EFCore.Helper;

namespace Inventory.Min.Data;

public interface ICurrencyRepo 
    : IEFRepositoryAsync<Currency>
{
	IEnumerable<Currency> GetCurrency(
        Expression<Func<Currency, bool>>? filter);
}