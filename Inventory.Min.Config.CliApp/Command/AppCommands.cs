using CommandDotNet;

namespace Inventory.Min.Config.CliApp;

[Command("seed")]
public class AppCommands
{
    private readonly ICommand seedCmd;

    public AppCommands(ICommand seedCmd)
    {
        this.seedCmd = seedCmd;
    }

    [DefaultCommand()]
    public void AppInfoAsync()
    {
        Console.WriteLine("Seed Identity db");
        seedCmd.ExecuteAsync();
    }
}