using System.Linq.Expressions;
using EFCore.Helper;

namespace Inventory.Min.Data;

public interface ITagRepo 
    : IEFRepositoryAsync<Tag>
{
	IEnumerable<Tag> GetTag(
        Expression<Func<Tag, bool>>? filter);
}