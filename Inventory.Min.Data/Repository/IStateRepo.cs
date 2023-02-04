using System.Linq.Expressions;
using EFCore.Helper;

namespace Inventory.Min.Data;

public interface IStateRepo 
    : IEFRepositoryAsync<State>
{
	IEnumerable<State> GetState(
        Expression<Func<State, bool>>? filter);
}