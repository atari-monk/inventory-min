namespace Inventory.Min.Mvc.Web.App.Models;

public class RelatedItemsVM
{
    public LexiconVM? Lexicon { get; set; }
    public List<ItemVM>? Items { get; set; }
}