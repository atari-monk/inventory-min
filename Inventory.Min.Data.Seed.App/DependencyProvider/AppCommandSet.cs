using DIHelper.Unity;
using Unity;

namespace Inventory.Min.Data.Seed.App;

public class AppCommandSet
    : UnityDependencySet
{
    public AppCommandSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        RegisterReadCommands();
    }

    private void RegisterReadCommands()
    {
    }
}