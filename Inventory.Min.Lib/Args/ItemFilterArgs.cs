using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using ModelHelper;

namespace Inventory.Min.Lib;

public class ItemFilterArgs
    : Model
    , IArgumentModel
{
    [Option(
        shortName: 'i'
        , longName: "Id")
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? Id { get; set; }

    [Option(shortName: 't', longName: "table"
        , Description = "Basic, Medium, Size, Verbose")]
    public string? Table { get; set; }

    [Option(
        shortName: 'p'
        , longName: "purchaseDate")]
    public DateTime? PurchaseDate { get; set; }

    [Option(
        shortName: 'c'
        , longName: "categoryId")]
    public int? CategoryId { get; set; }
}