using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using ModelHelper;

namespace Inventory.Min.Lib;

public class ItemInsertArgs 
    : Model
    , IArgumentModel
{
    [Operand(nameof(Name))
        , Required
        , MaxLength(NameMax)]
	public string? Name { get; set; }

    [Option('d', "desc")
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
	public int? VolumeUnitId { get; set; }

    [Option('v', "volume")
        , Range(LengthMin, LengthMax, ErrorMessage = LengthError)]
	public double? Volume { get; set; }

    [Option('z', "tagId")
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
	public int? TagId { get; set; }

    [Option('g', "stateId")
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
	public int? StateId { get; set; }

    [Option('f', "parentId")
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
	public int? ParentId { get; set; }

    [Option('m', "mass")
        , Range(LengthMin, LengthMax, ErrorMessage = LengthError)]
	public double? Mass { get; set; }

    [Option('x', "massUnitId")
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
	public int? MassUnitId { get; set; }
}