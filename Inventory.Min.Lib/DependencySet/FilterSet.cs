using DIHelper.Unity;
using Inventory.Min.Data;
using Unity;

namespace Inventory.Min.Lib;

public class FilterSet 
    : UnityDependencySet
{
    public FilterSet(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterSingleton<
                IFilterFactory<Item, ItemFilterArgs>
                , ItemFilter>();
    }
}