using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Variety;

namespace VarletCli.Handler
{
    [Command("stop", Description = "Stop Varlet services")]
    public class CmdStopHandler
    {
        private void OnExecute(IConsole console)
        {
            ColorizeConsole.PrintlnInfo($"\n> Stopping services ...\n");
            Services.Reload(References.ServiceNameHttp);
            Task.Delay(TimeSpan.FromSeconds(3));
            Services.Reload(References.ServiceNameSmtp);
            Task.Delay(TimeSpan.FromSeconds(3));
            ColorizeConsole.PrintlnInfo($"\n> Services stopped.\n");
        }
    }
}
