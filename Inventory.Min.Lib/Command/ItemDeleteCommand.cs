using CLIHelper;
using CRUDCommandHelper;
using Inventory.Min.Data;
using Serilog;

namespace Inventory.Min.Lib;

public class ItemDeleteCommand
    : DeleteCommand<IInventoryUnitOfWork, Item, DeleteArgs>
{
    public ItemDeleteCommand(
        IInventoryUnitOfWork unitOfWork
        , ILogger log
        , IInput input) 
            : base(unitOfWork, log, input)
    {
    }

    protected override void DeleteEntity(Item entity) => 
        UnitOfWork.Item.Delete(entity);

    protected override Item GetById(int id) =>
        UnitOfWork.Item.GetById(id) ?? new Item();
}