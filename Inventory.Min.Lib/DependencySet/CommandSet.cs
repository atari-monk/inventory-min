using CRUDCommandHelper;
using DIHelper.Unity;
using Unity;

namespace Inventory.Min.Lib;

public class CommandSet 
    : UnityDependencySet
{
    public CommandSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        RegisterRead();
        Container
            .RegisterSingleton<IInsertCommand<ItemInsertArgs>, ItemInsertCommand>()
            .RegisterSingleton<IUpdateCommand<ItemUpdateArgs>, ItemUpdateCommand>()
            .RegisterSingleton<IDeleteCommand<DeleteArgs>, ItemDeleteCommand>();
    }

    protected virtual void RegisterRead()
    {
        Container
            .RegisterSingleton<IReadCommand<ItemFilterArgs>, ItemReadCommand>();
    }
}