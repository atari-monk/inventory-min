using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using ModelHelper;

namespace Inventory.Min.Lib;

public class DeleteArgs 
    : Model
    , IArgumentModel
    , IId
{
    [Operand(
        "id")
        , Required
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int Id { get; set; }
}