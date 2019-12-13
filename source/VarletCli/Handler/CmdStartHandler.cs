using System;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Variety;

namespace VarletCli.Handler
{
    [Command("start", Description = "Start Varlet services")]
    public class CmdStartHandler
    {
        private void OnExecute(IConsole console)
        {
            ColorizeConsole.PrintlnInfo($"\n> Starting services ...\n");
            Services.Start(References.ServiceNameHttp);
            Task.Delay(TimeSpan.FromSeconds(3));
            Services.Start(References.ServiceNameSmtp);
            Task.Delay(TimeSpan.FromSeconds(3));
            ColorizeConsole.PrintlnInfo($"\n> Services started.\n");
        }
    }
}
