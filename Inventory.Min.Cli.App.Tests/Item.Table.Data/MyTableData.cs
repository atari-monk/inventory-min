using Inventory.Min.Data;
using dataUtil = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class MyTableData
{
  public static IEnumerable<object[]> Insert01 =>
      new List<object[]>
      {
            new object[]
            {
                0
                , dataUtil.GetItem((item) => item.Description = dataUtil.Description)
                , dataUtil.GetInsCmd("-d", dataUtil.Description)
            }
      };

  public static IEnumerable<object[]> Read01 =>
      new List<object[]>
      {
            new object[]
            {
                0
                , dataUtil.GetReadCmd()
                , $"{{idcolleft}}{nameof(Item.Id)}{{idcolright}}|     {nameof(Item.Name)}     |     Description     | Category | CategoryId |\r\n"
                + $" {{id}} | {dataUtil.Name} | {dataUtil.Description} |          |            |\r\n"
            }
      };
}