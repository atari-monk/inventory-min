using CommandDotNet;

namespace Inventory.Min.Config.CliApp;

[Command("app")]
public class AppCommands
{
    [DefaultCommand()]
    public void AppInfo()
    {
        Console.WriteLine("App template :)");
    }
}