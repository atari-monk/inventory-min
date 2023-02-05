using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Inventory.Min.Data;
using Serilog;

namespace Inventory.Min.Lib;

public class ItemReadCommand
    : ReadCommand<IInventoryUnitOfWork, Item, ItemFilterArgs>
{
    private readonly IFilterFactory<Item, ItemFilterArgs> filterFactory;

    public ItemReadCommand(
        IInventoryUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<Item> textProvider
        , IFilterFactory<Item, ItemFilterArgs> filterFactory)
            : base(unitOfWork, output, log, textProvider)
    {
        this.filterFactory = filterFactory;
    }

    protected override List<Item> Get(ItemFilterArgs model)
    {
        return UnitOfWork.ItemSync.GetItem(
            filterFactory.GetFilter(model)).ToList();
    }
}