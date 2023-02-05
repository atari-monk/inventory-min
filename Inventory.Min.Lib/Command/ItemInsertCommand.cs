using AutoMapper;
using CRUDCommandHelper;
using Inventory.Min.Data;
using Serilog;

namespace Inventory.Min.Lib;

public class ItemInsertCommand
    : InsertCommand<IInventoryUnitOfWork, Item, ItemInsertArgs>
{
    public ItemInsertCommand(
        IInventoryUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override void InsertEntity(Item entity) =>
        UnitOfWork.Item.Insert(entity);
}