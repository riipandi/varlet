using System;
using System.Diagnostics;
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
            ColorizeConsole.PrintlnInfo($"\n> Stopping services ...");
            StopService(References.ServiceNameHttp);
            StopService(References.ServiceNameSmtp);
            ColorizeConsole.PrintlnSuccess($"\n> Services stopped.\n");
        }

        private static void StopService(string serviceName)
        {
            try {
                if (!Services.IsInstalled(serviceName))  {
                    ColorizeConsole.PrintlnError($"\n> Service {serviceName} not installed!\n");
                    return;
                }
                if (!Services.IsRunning(serviceName))  {
                    ColorizeConsole.PrintlnWarning($"\n> Service {serviceName} not running!\n");
                    return;
                }
                var proc = new Process {StartInfo =
                {
                    FileName = "net.exe",
                    Arguments = "stop " + serviceName,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Verb = "runas"
                }};
                proc.Start();
                Task.Delay(TimeSpan.FromSeconds(3));
            } catch (FormatException) {}
        }
    }
}
