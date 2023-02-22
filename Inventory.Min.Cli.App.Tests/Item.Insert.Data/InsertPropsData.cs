using dataUtil = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public static class InsertPropsData
{
  public static IEnumerable<object[]> InsertProps =>
      new List<object[]>
      {
            new object[]
            {
                0
                , dataUtil.GetItem()
                , dataUtil.GetInsCmd()
            }
            ,
            new object[]
            {
                1
                , dataUtil.GetItem((item) => item.Description = dataUtil.Description)
                , dataUtil.GetInsCmd("-d", dataUtil.Description)
            }
            ,
            new object[]
            {
                2
                , dataUtil.GetItem((item) => item.PurchaseDate = new DateTime(2022, 7, 30))
                , dataUtil.GetInsCmd("-p", "30.07.2022")
            }
            ,
            new object[]
            {
                3
                , dataUtil.GetItem((item) => item.PurchasePrice = 10)
                , dataUtil.GetInsCmd("-r", "10")
            }
            ,
            new object[]
            {
                4
                , dataUtil.GetItem((item) => item.SellPrice = 5)
                , dataUtil.GetInsCmd("-s", "5")
            }
            ,
            new object[]
            {
                5
                , dataUtil.GetItem((item) => item.ImagePath =
                    @"C:\atari-monk\Image\Inventory")
                , dataUtil.GetInsCmd("-i", @"C:\atari-monk\Image\Inventory")
            }
            ,
            new object[]
            {
                6
                , dataUtil.GetItem((item) => item.Length = 99)
                , dataUtil.GetInsCmd("-l", "99")
            }
            ,
            new object[]
            {
                7
                , dataUtil.GetItem((item) => item.Heigth = 56)
                , dataUtil.GetInsCmd("-e", "56")
            }
            ,
            new object[]
            {
                8
                , dataUtil.GetItem((item) => item.Depth = 44)
                , dataUtil.GetInsCmd("-t", "44")
            }
            ,
            new object[]
            {
                9
                , dataUtil.GetItem((item) => item.Diameter = 66)
                , dataUtil.GetInsCmd("-a", "66")
            }
            ,
            new object[]
            {
                10
                , dataUtil.GetItem((item) => item.Volume = 116)
                , dataUtil.GetInsCmd("-v", "116")
            }
            ,
            new object[]
            {
                11
                , dataUtil.GetItem((item) => item.InitialCount = 66)
                , dataUtil.GetInsCmd("-q", "66")
            }
            ,
             new object[]
            {
                12
                , dataUtil.GetItem((item) => item.CurrentCount = 62)
                , dataUtil.GetInsCmd("--currentCount", "62")
            }
            ,
            new object[]
            {
                13
                , dataUtil.GetItem((item) => item.Mass = 400)
                , dataUtil.GetInsCmd("-m", "400")
            }
      };
}
