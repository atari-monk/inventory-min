using System.Linq.Expressions;
using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Min.Data;

public class TagRepo<TContext>
    : EFRepositoryAsync<Tag, TContext>
        , ITagRepo
            where TContext : DbContext
{
    public TagRepo(TContext context)
        : base(context)
    {
    }

    public IEnumerable<Tag> GetTag(
        Expression<Func<Tag, bool>>? filter)
    {
        return Get(
            filter
            , orderBy: (tags) => tags
                .OrderBy((tag) => tag.Id));
    }
}
