using DIHelper.Unity;
using Unity;

namespace Inventory.Min.Config.CliApp;

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
        Container.RegisterType<ICommand, IdentitySeedCommand>();
    }
}