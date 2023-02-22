using CommandDotNet;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Inventory.Min.Cli.App;

public class ReplProgram 
    : AppProgUnity<ReplProgram>
{
    [Subcommand]
    public ItemCommands? LogCommands { get; set; }

    public ReplProgram(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }
}