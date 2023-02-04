using CommandDotNet.Helper;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using DIHelper.Unity;
using Unity;

namespace Inventory.Min.Data.Seed.App;

public class CommandCliSuite 
    : UnityDependencySuite
{
    public CommandCliSuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterCommands() => 
        RegisterSet<AppCommandSet>();

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<CommandCli>>();
}