using AutoMapper;
using CRUDCommandHelper;
using Inventory.Min.Data;
using Serilog;

namespace Inventory.Min.Lib;

public class ItemUpdateCommand
    : UpdateCommand<IInventoryUnitOfWork, Item, ItemUpdateArgs, ItemUpdate>
{
    public ItemUpdateCommand(
        IInventoryUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override Item GetById(int id) =>
        UnitOfWork.Item.GetById(id) ?? new Item();
}