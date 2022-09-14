namespace Inventory.Min.Mvc.Web.App.Models;

public class ItemCreateVM
{
    public LexiconVM? Lexicon { get; set; }
    public List<ItemSmallVM>? Items { get; set; }
    public ItemVM? Item { get; set; }
}