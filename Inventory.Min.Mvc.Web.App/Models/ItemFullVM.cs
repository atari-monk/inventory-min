using ModelHelper;

namespace Inventory.Min.Mvc.Web.App.Models;

public class ItemFullVM
    : Model
{
    public List<CategoryVM>? Categories { get; set; }
    public List<ItemVM>? Items { get; set; }
}