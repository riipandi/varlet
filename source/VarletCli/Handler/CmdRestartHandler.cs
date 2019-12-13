using McMaster.Extensions.CommandLineUtils;
using Variety;

namespace VarletCli.Handler
{
    [Command("restart", Description = "Restart Varlet services")]
    public class CmdRestartHandler
    {
        private void OnExecute(IConsole console)
        {
            console.WriteLine($"\nThis is restart command\n");
        }
    }
}
