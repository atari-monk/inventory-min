using CommandDotNet;

namespace Inventory.Min.Data.Seed.App;

[Command("seed")]
public class AppCommands
{
    [DefaultCommand()]
    public async Task SeedDb()
    {
        Console.WriteLine("Seed InventoryDb");
        var seeder = new InventoryDbSeeder();
        await seeder.Seed();
    }
}