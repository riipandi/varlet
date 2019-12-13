using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Variety;

namespace VarletCli.Handler
{
    [Command("restart", Description = "Restart Varlet services")]
    public class CmdRestartHandler
    {
        private void OnExecute(IConsole console)
        {
            ColorizeConsole.PrintlnInfo($"\n> Reloading services ...\n");
            Services.Reload(References.ServiceNameHttp);
            Task.Delay(TimeSpan.FromSeconds(3));
            Services.Reload(References.ServiceNameSmtp);
            Task.Delay(TimeSpan.FromSeconds(3));
            ColorizeConsole.PrintlnInfo($"\n> Services reloaded.\n");
        }
    }
}
