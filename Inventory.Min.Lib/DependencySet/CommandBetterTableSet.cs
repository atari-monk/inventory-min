using CRUDCommandHelper;
using Unity;

namespace Inventory.Min.Lib;

public class CommandBetterTableSet
    : CommandSet
{
    public CommandBetterTableSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterRead()
    {
        Container
            .RegisterSingleton<IReadCommand<ItemFilterArgs>, ItemReadBetterTableCommand>();
    }
}