namespace Inventory.Min.Data.Seed.App;

public class InventoryDbSeeder
    : DbSeeder
{
    protected override Dictionary<string, object> CreateData()
    {
        return new Dictionary<string, object>()
        {
              { Category + "1", new Category { Name = "Container" } }
            , { Category + "2", new Category { Name = "Food" } }
            , { Currency + "1", new Currency { Name = "PLN" } }
            , { Currency + "2", new Currency { Name = "EUR" } }
            , { Currency + "3", new Currency { Name = "USD" } }
            , { Unit + "1", new Unit { Name = "cm", Description = "Centimetre" } }
            , { Unit + "2", new Unit { Name = "l", Description = "Litre" } }
            , { Unit + "3", new Unit { Name = "g", Description = "Gram" } }
            , { Unit + "4", new Unit { Name = "kg", Description = "Kilogram" } }
            , { Tag + "1", new Tag { Name = "Preserves" } }
            , { State + "1", new State { Name = "In storage" } }
            , { State + "2", new State { Name = "In use" } }
            , { State + "3", new State { Name = "Depleted" } }
        };
    }

    public virtual async Task Seed()
    {
        try
        {
            SeedCategory(Category + "1");
            SeedCategory(Category + "2");
            SeedCurrency(Currency + "1");
            SeedCurrency(Currency + "2");
            SeedCurrency(Currency + "3");
            SeedUnit(Unit + "1");
            SeedUnit(Unit + "2");
            SeedUnit(Unit + "3");
            SeedUnit(Unit + "4");
            SeedTag(Tag + "1");
            SeedState(State + "1");
            SeedState(State + "2");
            SeedState(State + "3");
            await Context.SaveChangesAsync();
        }
        finally
        {
            await Context.DisposeAsync();
        }
    }
}