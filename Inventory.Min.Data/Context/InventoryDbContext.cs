using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Min.Data;

public class InventoryDbContext
    : DbContextDbConfig
{
    public DbSet<Category>? Category { get; set; }
	public DbSet<Currency>? Currency { get; set; }
	public DbSet<Item>? Item { get; set; }
	public DbSet<State>? State { get; set; }
	public DbSet<Tag>? Tag { get; set; }
	public DbSet<Unit>? Unit { get; set; }

    public InventoryDbContext()
        : base()
    {
    }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
    {
    }

    protected InventoryDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void SeedData(ModelBuilder builder)
    {
    }    
}