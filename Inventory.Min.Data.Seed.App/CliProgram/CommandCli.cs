using CommandDotNet;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Inventory.Min.Data.Seed.App;

public class CommandCli 
    : AppProgUnity<CommandCli>
{
    [Subcommand]
    public AppCommands? AppCommands { get; set; }

    public CommandCli(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }
}