using ModelHelper;

namespace Inventory.Min.Data;

public class ItemUpdate
    : ModelAUpdate
    , IUpdatable<Item>
{
    public int? InitialCount { get; set; }
    public int? CurrentCount { get; set; }
    public int? CategoryId { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public int? CurrencyId { get; set; }
    public decimal? PurchasePrice { get; set; }
    public decimal? SellPrice { get; set; }
    public string? ImagePath { get; set; }
    public int? LengthUnitId { get; set; }
    public double? Length { get; set; }
    public double? Heigth { get; set; }
    public double? Depth { get; set; }
    public double? Diameter { get; set; }
    public int? VolumeUnitId { get; set; }
    public double? Volume { get; set; }
    public double? Mass { get; set; }
    public int? MassUnitId { get; set; }
    public int? TagId { get; set; }
    public int? StateId { get; set; }
    public int? ParentId { get; set; }

    public void Update(Item model)
    {
        base.Update(model);

        if (CategoryId.HasValue
            && CategoryId.Value != model.CategoryId)
            model.CategoryId = CategoryId.Value;

        if (CurrencyId.HasValue
            && CurrencyId.Value != model.CurrencyId)
            model.CurrencyId = CurrencyId.Value;

        if (LengthUnitId.HasValue
            && LengthUnitId.Value != model.LengthUnitId)
            model.LengthUnitId = LengthUnitId.Value;

        if (VolumeUnitId.HasValue
            && VolumeUnitId.Value != model.VolumeUnitId)
            model.VolumeUnitId = VolumeUnitId.Value;

        if (TagId.HasValue
            && TagId.Value != model.TagId)
            model.TagId = TagId.Value;

        if (StateId.HasValue
            && StateId.Value != model.StateId)
            model.StateId = StateId.Value;

        if (ParentId.HasValue
            && ParentId.Value != model.ParentId)
            model.ParentId = ParentId.Value;

        if (Mass.HasValue
           && Mass.Value != model.Mass)
            model.Mass = Mass.Value;

        if (MassUnitId.HasValue
           && MassUnitId.Value != model.MassUnitId)
            model.MassUnitId = MassUnitId.Value;

        if (InitialCount.HasValue
        && InitialCount.Value != model.InitialCount)
            model.InitialCount = InitialCount.Value;
        
        if (CurrentCount.HasValue
        && CurrentCount.Value != model.CurrentCount)
            model.CurrentCount = CurrentCount.Value;

        if (PurchaseDate.HasValue
        && PurchaseDate.Value != model.PurchaseDate)
            model.PurchaseDate = PurchaseDate.Value;

        if (PurchasePrice.HasValue
        && PurchasePrice.Value != model.PurchasePrice)
            model.PurchasePrice = PurchasePrice.Value;

        if (SellPrice.HasValue
        && SellPrice.Value != model.SellPrice)
            model.SellPrice = SellPrice.Value;

        if (string.IsNullOrWhiteSpace(ImagePath) == false
        && ImagePath.Trim() != model.ImagePath?.Trim())
        {
            model.ImagePath = ImagePath;
        }

        if (Length.HasValue
        && Length.Value != model.Length)
            model.Length = Length.Value;

        if (Heigth.HasValue
        && Heigth.Value != model.Heigth)
            model.Heigth = Heigth.Value;

        if (Depth.HasValue
        && Depth.Value != model.Depth)
            model.Depth = Depth.Value;

        if (Diameter.HasValue
        && Diameter.Value != model.Diameter)
            model.Diameter = Diameter.Value;

        if (VolumeUnitId.HasValue
        && VolumeUnitId.Value != model.VolumeUnitId)
            model.VolumeUnitId = VolumeUnitId.Value;

        if (Volume.HasValue
        && Volume.Value != model.Volume)
            model.Volume = Volume.Value;

        if (Mass.HasValue
        && Mass.Value != model.Mass)
            model.Mass = Mass.Value;

        if (MassUnitId.HasValue
        && MassUnitId.Value != model.MassUnitId)
            model.MassUnitId = MassUnitId.Value;

        if (TagId.HasValue
        && TagId.Value != model.TagId)
            model.TagId = TagId.Value;

        if (StateId.HasValue
        && StateId.Value != model.StateId)
            model.StateId = StateId.Value;

        if (ParentId.HasValue
        && ParentId.Value != model.ParentId)
            model.ParentId = ParentId.Value;
    }
}