using System.Linq.Expressions;
using EFCore.Helper;

namespace Inventory.Min.Data;

public interface IUnitRepo 
    : IEFRepositoryAsync<Unit>
{
	IEnumerable<Unit> GetUnit(
        Expression<Func<Unit, bool>>? filter);
}