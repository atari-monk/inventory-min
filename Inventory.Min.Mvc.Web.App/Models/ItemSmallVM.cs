using System.ComponentModel.DataAnnotations;
using ModelHelper;

namespace Inventory.Min.Mvc.Web.App.Models;

public class ItemSmallVM
    : Model
{
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMax)]
    public string? Name { get; set; }

    public int? CategoryId { get; set; }

    public string? IdName => string.Format("{0}->{1}", Id, Name);
}