using McMaster.Extensions.CommandLineUtils;
using Variety;

namespace VarletCli.Handler
{
    [Command("list", Description = "List all virtualhosts")]
    public class CmdListHandler
    {
        private void OnExecute(IConsole console)
        {
            console.WriteLine($"\nThis is list command\n");
        }
    }
}
