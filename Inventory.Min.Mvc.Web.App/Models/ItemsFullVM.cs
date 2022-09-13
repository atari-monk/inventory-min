namespace Inventory.Min.Mvc.Web.App.Models;

public class ItemsFullVM
{
    public List<CategoryVM>? Categories { get; set; }
    public List<CurrencyVM>? Currencies { get; set; }
    public List<StateVM>? States { get; set; }
    public List<TagVM>? Tags { get; set; }
    public List<UnitVM>? Units { get; set; }
    public List<ItemVM>? Items { get; set; }
}