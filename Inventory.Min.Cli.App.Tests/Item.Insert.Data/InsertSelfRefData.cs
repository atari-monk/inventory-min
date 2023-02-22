using dataUtil = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public static class InsertSelfRefData
{
  public static IEnumerable<object[]> InsertParent =>
      new List<object[]>
      {
            new object[]
            {
                0
                , dataUtil.GetItem()
                , dataUtil.GetInsCmd()
            }
      };

  public static IEnumerable<object[]> InsertSelfRef =>
      new List<object[]>
      {
            new object[]
            {
                1
                , dataUtil.GetItem((item) => item.Description = "test self ref")
                , dataUtil.GetInsCmd("-d", "test self ref", "-f", "parentId")
            }
      };
}
