using Inventory.Min.Data;
using dataUtil = Inventory.Min.Cli.App.Tests.ItemTests.DataUtil;

namespace Inventory.Min.Cli.App.Tests.ItemTests;

public class UpdateData
{
  private const string ImgRoot = @"C:\atari-monk\Image\Inventory";
  private const string Img1 = @"\img1.png";
  private const string Img2 = @"\img2.png";

  public static IEnumerable<object[]> Insert01 =>
      new List<object[]>
      {
            new object[] { 0, dataUtil.GetInsCmd() }
      };

  public static IEnumerable<object[]> Update01 =>
      new List<object[]>
      {
              new object[] { 0, nameof(Item.Name), dataUtil.GetItem((item) => item.Name = dataUtil.NameUpd), dataUtil.GetUpdCmd("-n", dataUtil.NameUpd) }
            , new object[] { 1, nameof(Item.Name), dataUtil.GetItem((item) => item.Name = dataUtil.Name) , dataUtil.GetUpdCmd("--name", dataUtil.Name) }
            , new object[] { 2, nameof(Item.Description), dataUtil.GetItem((item) => item.Description = dataUtil.Description), dataUtil.GetUpdCmd("-d", dataUtil.Description) }
            , new object[] { 3, nameof(Item.Description), dataUtil.GetItem((item) => item.Description = dataUtil.DescriptionUpd), dataUtil.GetUpdCmd("--desc", dataUtil.DescriptionUpd) }
            , new object[] { 4, nameof(Item.InitialCount), dataUtil.GetItem((item) => item.InitialCount = 10), dataUtil.GetUpdCmd("-q", "10") }
            , new object[] { 5, nameof(Item.InitialCount), dataUtil.GetItem((item) => item.InitialCount = 20), dataUtil.GetUpdCmd("--initialCount", "20") }
            , new object[] { 6, nameof(Item.CurrentCount), dataUtil.GetItem((item) => item.CurrentCount = 40), dataUtil.GetUpdCmd("--currentCount", "40") }
            , new object[] { 7, nameof(Item.CurrentCount), dataUtil.GetItem((item) => item.CurrentCount = 33), dataUtil.GetUpdCmd("--currentCount", "33") }
            , new object[] { 8, nameof(Item.PurchaseDate), dataUtil.GetItem((item) => item.PurchaseDate = new DateTime(2022, 8, 18, 17, 16, 0)), dataUtil.GetUpdCmd("-p", "18.08.2022 17:16") }
            , new object[] { 9, nameof(Item.PurchaseDate), dataUtil.GetItem((item) => item.PurchaseDate = new DateTime(2022, 8, 18, 18, 0, 0)), dataUtil.GetUpdCmd("-p", "18.08.2022 18:00") }
            , new object[] { 10, nameof(Item.PurchasePrice), dataUtil.GetItem((item) => item.PurchasePrice = 33.3m), dataUtil.GetUpdCmd("-r", "33.3") }
            , new object[] { 11, nameof(Item.PurchasePrice), dataUtil.GetItem((item) => item.PurchasePrice = 99.6m), dataUtil.GetUpdCmd("--purchasePrice", "99.6") }
            , new object[] { 12, nameof(Item.SellPrice), dataUtil.GetItem((item) => item.SellPrice = 15.7m), dataUtil.GetUpdCmd("-s", "15.7") }
            , new object[] { 13, nameof(Item.SellPrice), dataUtil.GetItem((item) => item.SellPrice = 78.1m), dataUtil.GetUpdCmd("--sellPrice", "78.1") }
            , new object[] { 14, nameof(Item.ImagePath), dataUtil.GetItem((item) => item.ImagePath = ImgRoot + Img1), dataUtil.GetUpdCmd("-i", ImgRoot + Img1) }
            , new object[] { 15, nameof(Item.ImagePath), dataUtil.GetItem((item) => item.ImagePath = ImgRoot + Img2), dataUtil.GetUpdCmd("--imagePath", ImgRoot + Img2) }
            , new object[] { 16, nameof(Item.Length), dataUtil.GetItem((item) => item.Length = 66.6), dataUtil.GetUpdCmd("-l", "66.6") }
            , new object[] { 17, nameof(Item.Length), dataUtil.GetItem((item) => item.Length = 23.4), dataUtil.GetUpdCmd("--length", "23.4") }
            , new object[] { 18, nameof(Item.Heigth), dataUtil.GetItem((item) => item.Heigth = 78.3), dataUtil.GetUpdCmd("-e", "78.3") }
            , new object[] { 19, nameof(Item.Heigth), dataUtil.GetItem((item) => item.Heigth = 45.2), dataUtil.GetUpdCmd("--heigth", "45.2") }
            , new object[] { 20, nameof(Item.Depth), dataUtil.GetItem((item) => item.Depth = 13.6), dataUtil.GetUpdCmd("-t", "13.6") }
            , new object[] { 21, nameof(Item.Depth), dataUtil.GetItem((item) => item.Depth = 17.3), dataUtil.GetUpdCmd("--depth", "17.3") }
            , new object[] { 22, nameof(Item.Diameter), dataUtil.GetItem((item) => item.Diameter = 167.3), dataUtil.GetUpdCmd("-a", "167.3") }
            , new object[] { 23, nameof(Item.Diameter), dataUtil.GetItem((item) => item.Diameter = 222.2), dataUtil.GetUpdCmd("--diameter", "222.2") }
            , new object[] { 24, nameof(Item.Volume), dataUtil.GetItem((item) => item.Volume = 31.7), dataUtil.GetUpdCmd("-v", "31.7") }
            , new object[] { 25, nameof(Item.Volume), dataUtil.GetItem((item) => item.Volume = 41.3), dataUtil.GetUpdCmd("--volume", "41.3") }
            , new object[] { 26, nameof(Item.Mass), dataUtil.GetItem((item) => item.Mass = 222.9), dataUtil.GetUpdCmd("-m", "222.9") }
            , new object[] { 27, nameof(Item.Mass), dataUtil.GetItem((item) => item.Mass = 453.2), dataUtil.GetUpdCmd("--mass", "453.2") }
            , new object[] { 28, nameof(Item.CategoryId), dataUtil.GetItem((item) => item.CategoryId = 1), dataUtil.GetUpdCmd("-c", "1") }
            , new object[] { 29, nameof(Item.CategoryId), dataUtil.GetItem((item) => item.CategoryId = 2), dataUtil.GetUpdCmd("--categoryId", "2") }
            , new object[] { 30, nameof(Item.CurrencyId), dataUtil.GetItem((item) => item.CurrencyId = 1), dataUtil.GetUpdCmd("-u", "1") }
            , new object[] { 31, nameof(Item.CurrencyId), dataUtil.GetItem((item) => item.CurrencyId = 2), dataUtil.GetUpdCmd("--currencyId", "2") }
            , new object[] { 32, nameof(Item.LengthUnitId), dataUtil.GetItem((item) => item.LengthUnitId = 1), dataUtil.GetUpdCmd("--lengthUnitId", "1") }
            , new object[] { 33, nameof(Item.LengthUnitId), dataUtil.GetItem((item) => item.LengthUnitId = 2), dataUtil.GetUpdCmd("--lengthUnitId", "2") }
            , new object[] { 34, nameof(Item.VolumeUnitId), dataUtil.GetItem((item) => item.VolumeUnitId = 1), dataUtil.GetUpdCmd("--volumeUnitId", "1") }
            , new object[] { 35, nameof(Item.VolumeUnitId), dataUtil.GetItem((item) => item.VolumeUnitId = 2), dataUtil.GetUpdCmd("--volumeUnitId", "2") }
            , new object[] { 36, nameof(Item.MassUnitId), dataUtil.GetItem((item) => item.MassUnitId = 1), dataUtil.GetUpdCmd("-x", "1") }
            , new object[] { 37, nameof(Item.MassUnitId), dataUtil.GetItem((item) => item.MassUnitId = 2), dataUtil.GetUpdCmd("--massUnitId", "2") }
            , new object[] { 38, nameof(Item.TagId), dataUtil.GetItem((item) => item.TagId = 1), dataUtil.GetUpdCmd("-z", "1") }
            , new object[] { 39, nameof(Item.TagId), dataUtil.GetItem((item) => item.TagId = 2), dataUtil.GetUpdCmd("--tagId", "2") }
            , new object[] { 40, nameof(Item.StateId), dataUtil.GetItem((item) => item.StateId = 1), dataUtil.GetUpdCmd("-g", "1") }
            , new object[] { 41, nameof(Item.StateId), dataUtil.GetItem((item) => item.StateId = 2), dataUtil.GetUpdCmd("--stateId", "2") }
      };
}