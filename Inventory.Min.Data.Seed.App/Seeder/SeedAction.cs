namespace Inventory.Min.Data.Seed.App;

public class SeedAction<TContext, TEntity>
{
    public Func<TContext, TEntity, TEntity?>? GetDbEntity { get; init; }

    public Action<TContext, TEntity>? AddEntity { get; init; }

    public SeedAction(
        Func<TContext, TEntity, TEntity?> getDbEntity
        , Action<TContext, TEntity> addEntity)
    {
        this.GetDbEntity = getDbEntity;
        this.AddEntity = addEntity; 
    }
}