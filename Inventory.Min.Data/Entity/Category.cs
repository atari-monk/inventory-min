using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelHelper;

namespace Inventory.Min.Data;

public class Category
    : Model
	, IModelA
{
	public int Id { get; set; }
		
	[Required]
	[MaxLength(NameMax)]
	public string? Name { get; set; }

	[MaxLength(DescriptionMax)]
	public string? Description { get; set; }

	[ForeignKey(nameof(Category))]
	public int? ParentId { get; set; }

	public Category? Parent { get; set; }

	public IEnumerable<Category>? Children { get; set; }
}