namespace Inventory.Min.Data.Seed.App;

public abstract class DbSeeder
{
    protected const string Category = nameof(Item.Category);
    protected const string Currency = nameof(Item.Currency);
    protected const string Unit = "Unit";
    protected const string Tag = nameof(Item.Tag);
    protected const string State = nameof(Item.State);
    protected readonly InventoryDbContext Context;
    private readonly Dictionary<string, object> data;
    private readonly Dictionary<string, object> actions;

    public DbSeeder()
    {
        Context = new InventoryDbContext();
        data = CreateData();
        actions = CreateActions();
    }

    protected abstract Dictionary<string, object> CreateData();

    protected virtual Dictionary<string, object> CreateActions()
    {
        return new Dictionary<string, object>()
        {
            {
                Category
                , new SeedAction<InventoryDbContext, Category>(
                    (context, entity) => { return context.Category?.FirstOrDefault(c => c.Name == entity.Name); }
                    , (context, entity) => context.Category?.Add(entity))
            }
            , {
                Currency
                , new SeedAction<InventoryDbContext, Currency>(
                    (context, entity) => { return context.Currency?.FirstOrDefault(c => c.Name == entity.Name); }
                    , (context, entity) => context.Currency?.Add(entity))
            }
            , {
                Unit
                , new SeedAction<InventoryDbContext, Unit>(
                    (context, entity) => { return context.Unit?.FirstOrDefault(c => c.Name == entity.Name); }
                    , (context, entity) => context.Unit?.Add(entity))
            }
            , {
                Tag
                , new SeedAction<InventoryDbContext, Tag>(
                    (context, entity) => { return context.Tag?.FirstOrDefault(c => c.Name == entity.Name); }
                    , (context, entity) => context.Tag?.Add(entity))
            }
            , {
                State
                , new SeedAction<InventoryDbContext, State>(
                    (context, entity) => { return context.State?.FirstOrDefault(c => c.Name == entity.Name); }
                    , (context, entity) => context.State?.Add(entity))
            }
        };
    }

    private TType GetData<TType>(string key)
    {
        return (TType)data[key];
    }

    private TType GetAction<TType>(string key)
    {
        return (TType)actions[key];
    }

    private void SeedEntity<TContext, TEntity>(
        TContext context
        , string key
        , SeedAction<TContext, TEntity> actions)
    {
        var entity = GetData<TEntity>(key);
        var entityDb = actions.GetDbEntity!.Invoke(context, entity);
        if (entityDb == null)
        {
            actions.AddEntity!(context, entity);
        }
    }

    protected void SeedCategory(string key)
    {
        SeedEntity<InventoryDbContext, Category>(
            Context
            , key
            , GetAction<SeedAction<InventoryDbContext, Category>>(Category));
    }

    protected void SeedCurrency(string key)
    {
        SeedEntity<InventoryDbContext, Currency>(
            Context
            , key
            , GetAction<SeedAction<InventoryDbContext, Currency>>(Currency));
    }

    protected void SeedUnit(string key)
    {
        SeedEntity<InventoryDbContext, Unit>(
            Context
            , key
            , GetAction<SeedAction<InventoryDbContext, Unit>>(Unit));
    }

    protected void SeedTag(string key)
    {
        SeedEntity<InventoryDbContext, Tag>(
            Context
            , key
            , GetAction<SeedAction<InventoryDbContext, Tag>>(Tag));
    }

    protected void SeedState(string key)
    {
        SeedEntity<InventoryDbContext, State>(
            Context
            , key
            , GetAction<SeedAction<InventoryDbContext, State>>(State));
    }

    protected string GetKey(string type, int i)
    {
        if(i < 1)
            throw new ArgumentException("i must be equal or greater than 1");
        return type + i;
    }
}