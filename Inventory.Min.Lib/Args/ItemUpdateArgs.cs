using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using DotNetExtension;
using Inventory.Min.Data;
using ModelHelper;

namespace Inventory.Min.Lib;

[AtLeastOneProperty(
	nameof(Item.Name)
    , nameof(Item.Description)
	, nameof(Item.InitialCount)
	, nameof(Item.CurrentCount)
	, nameof(Item.CategoryId)
	, nameof(Item.PurchaseDate)
	, nameof(Item.CurrencyId)
	, nameof(Item.PurchasePrice)
	, nameof(Item.SellPrice)
	, nameof(Item.ImagePath)
	, nameof(Item.LengthUnitId)
	, nameof(Item.Length)
	, nameof(Item.Heigth)
	, nameof(Item.Depth)
	, nameof(Item.Diameter)
	, nameof(Item.VolumeUnitId)
	, nameof(Item.Volume)
	, nameof(Item.Mass)
	, nameof(Item.MassUnitId)
	, nameof(Item.TagId)
	, nameof(Item.StateId)
	, nameof(Item.ParentId)
    , ErrorMessage = UpdateError)]
public class ItemUpdateArgs
    : Model
        , IArgumentModel
        , IId
{
    private const string UpdateError = 
        "You must supply Name or Description or InitialCount"
        + " or CurrentCount"
		+ "or CategoryId or PurchaseDate or CurrencyId"
		+ "or PurchasePrice or ImagePath or LengthUnitId"
		+ "or Length or Heigth or Depth"
		+ "or Diameter or VolumeUnitId or Volume"
		+ "or Mass or MassUnitId or TagId"
		+ "or StateId or ParentId";
		
    [Operand("id")
        , Required
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int Id { get; set; }

    [Option('n', "name")
        , MaxLength(NameMax)]
    public string? Name { get; set; }

    [Option( 'd', "desc")
        , MaxLength(DescriptionMax)]
    public string? Description { get; set; }
	
	[Option('q', "initialCount")
        , Range(CountMin, CountMax, ErrorMessage = CountError)]
    public int? InitialCount { get; set; }
	
    [Option("currentCount")
        , Range(CountMin, CountMax, ErrorMessage = CountError)]
    public int? CurrentCount { get; set; }

	[Option('c', "categoryId")
		, Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? CategoryId { get; set; }
	
	[Option('p', "purchaseDate"
		, Description = DateOnlyFormat)]
    public DateTime? PurchaseDate { get; set; }
	
	[Option('u', "currencyId")
		, Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? CurrencyId { get; set; }
	
	[Option('r', "purchasePrice")]
    public decimal? PurchasePrice { get; set; }
	
	[Option('s', "sellPrice")]
    public decimal? SellPrice { get; set; }
	
	[Option('i', "imagePath")]
    public string? ImagePath { get; set; }
	
	[Option("lengthUnitId")
		, Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? LengthUnitId { get; set; }
	
	[Option('l', "length")
		, Range(LengthMin, LengthMax, ErrorMessage = LengthError)]
    public double? Length { get; set; }
	
	[Option('e', "heigth")
		, Range(LengthMin, LengthMax, ErrorMessage = LengthError)]
    public double? Heigth { get; set; }
	
	[Option('t', "depth")
		, Range(LengthMin, LengthMax, ErrorMessage = LengthError)]
    public double? Depth { get; set; }
	
	[Option('a', "diameter")
		, Range(LengthMin, LengthMax, ErrorMessage = LengthError)]
    public double? Diameter { get; set; }
	
	[Option("volumeUnitId")
		, Range(IdMin, IdMax, ErrorMessage = IdError)]
    public double? VolumeUnitId { get; set; }
	
	[Option('v', "volume")
		, Range(LengthMin, LengthMax, ErrorMessage = LengthError)]
    public double? Volume { get; set; }
	
	[Option('m', "mass")
		, Range(LengthMin, LengthMax, ErrorMessage = LengthError)]
    public double? Mass { get; set; }
	
	[Option('x', "massUnitId")
		, Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? MassUnitId { get; set; }
	
	[Option('z', "tagId")
		, Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? TagId { get; set; }
	
	[Option('g', "stateId")
		, Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? StateId { get; set; }
	
	[Option('f', "parentId")
		, Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? ParentId { get; set; }
}