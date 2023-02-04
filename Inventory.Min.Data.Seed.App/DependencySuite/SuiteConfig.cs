using CommandDotNet.Helper;
using Config.Wrapper;
using DIHelper;
using Unity;

namespace Inventory.Min.Data.Seed.App;

public class SuiteConfig
{
    private readonly IConfigReader configReader;

    public SuiteConfig(
        IConfigReader configReader
    )
    {
        this.configReader = configReader;
    }

    public IDependencySuite GetSuite(IUnityContainer unity)
    {
        var settings = configReader.GetConfigSection<CommandDotNetSettings>(nameof(CommandDotNetSettings));
        ArgumentNullException.ThrowIfNull(settings);
        if(settings.UseRepl)
            return new ReplCliSuite(unity);
        else
            return new CommandCliSuite(unity);
    }
}