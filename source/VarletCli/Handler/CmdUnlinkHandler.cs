using McMaster.Extensions.CommandLineUtils;
using Variety;

namespace VarletCli.Handler
{
    [Command("unlink", Description = "Remove a virtualhost")]
    public class CmdUnlinkHandler
    {
        private void OnExecute(IConsole console)
        {
            console.WriteLine($"\nThis is unlink command\n");
        }
    }
}
