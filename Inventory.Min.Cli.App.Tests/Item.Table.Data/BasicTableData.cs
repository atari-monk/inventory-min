using System.Globalization;
using Inventory.Min.BetterTable;
using Inventory.Min.Data;
using ModelHelper;
using dataUtil = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class BasicTableData
    : MyTableData
{
  public new static IEnumerable<object[]> Insert01 =>
      new List<object[]>
      {
            new object[]
            {
                0
                , dataUtil.GetItem(
                    (item) => item.Description = dataUtil.Description)
                , dataUtil.GetInsCmd("-d", dataUtil.Description)
            }
      };

  public new static IEnumerable<object[]> Read01 =>
      new List<object[]>
      {
            new object[]
            {
                0
                , dataUtil.GetReadCmd("-t", ItemTablesTest.BasicTest.ToString())
                ,    "┌──────────────┬─────────────────────┐\r\n│"
                +   $" \u001b[38;2;255;255;255m    {nameof(Item.Name)}    \u001b[0m │"
                +   $" \u001b[38;2;255;255;255m    {nameof(Item.Description)}    [0m │"
                +    "\r\n"
                +    "├──────────────┼─────────────────────┤\r\n│"
                +   $" \u001b[38;2;255;255;255m{dataUtil.Name}\u001b[0m │"
                +   $" \u001b[38;2;255;255;255m{dataUtil.Description}[0m │"
                +    "\r\n"
                +    "└──────────────┴─────────────────────┘\r\n"
            }
      };

  private static object GetPrice(decimal purchasePrice)
  {
    return purchasePrice.ToString(Model.MoneyFormat, CultureInfo.GetCultureInfo(Model.PolishCulture));
  }
}