using McMaster.Extensions.CommandLineUtils;
using Variety;

namespace VarletCli.Handler
{
    [Command("start", Description = "Start Varlet services")]
    public class CmdStartHandler
    {
        private void OnExecute(IConsole console)
        {
            console.WriteLine($"\nThis is start command\n");
        }
    }
}
