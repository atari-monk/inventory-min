using dataUtil = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public static class InsertForeignKeysData
{
  public static IEnumerable<object[]> InsertForeignKeys =>
      new List<object[]>
      {
            new object[]
            {
                0
                , dataUtil.GetItem((item) => item.CategoryId = 1)
                , dataUtil.GetInsCmd("-c", "1")
            }
            ,
            new object[]
            {
                1
                , dataUtil.GetItem((item) => item.CurrencyId = 1)
                , dataUtil.GetInsCmd("--currencyId", "1")
            }
            ,
            new object[]
            {
                2
                , dataUtil.GetItem((item) => item.LengthUnitId = 1)
                , dataUtil.GetInsCmd("--lengthUnitId", "1")
            }
            ,
            new object[]
            {
                3
                , dataUtil.GetItem((item) => item.VolumeUnitId = 4)
                , dataUtil.GetInsCmd("--volumeUnitId", "4")
            }
            ,
            new object[]
            {
                4
                , dataUtil.GetItem((item) => item.TagId = 1)
                , dataUtil.GetInsCmd("-z", "1")
            }
            ,
            new object[]
            {
                5
                , dataUtil.GetItem((item) => item.StateId = 1)
                , dataUtil.GetInsCmd("-g", "1")
            }
            ,
            new object[]
            {
                6
                , dataUtil.GetItem((item) => item.MassUnitId = 5)
                , dataUtil.GetInsCmd("-x", "5")
            }
      };
}