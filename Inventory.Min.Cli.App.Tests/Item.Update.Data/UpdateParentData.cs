using Inventory.Min.Data;
using dataUtil = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class UpdateParentData
{
  public static IEnumerable<object[]> Insert01 =>
      new List<object[]>
      {
            new object[] { 0, dataUtil.GetInsCmd() }
            , new object[] { 1, dataUtil.GetInsCmd() }
      };

  public static IEnumerable<object[]> Update01 =>
      new List<object[]>
      {
            new object[] { 0, nameof(Item.ParentId), dataUtil.GetUpdCmd("-f", "parentid") }
            , new object[] { 1, nameof(Item.ParentId), dataUtil.GetUpdCmd("--parentId", "parentid") }
      };
}