using CommandDotNet.Unity.Helper;
using DIHelper.Unity;
using Unity;

namespace Inventory.Min.Data.Seed.App;

public class ReplCliSuite 
    : UnityDependencySuite
{
    public ReplCliSuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterCommands() => 
        RegisterSet<AppCommandSet>();

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<ReplCli>>();
}