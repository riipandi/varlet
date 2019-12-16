using System;
using System.Diagnostics;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Variety;

namespace VarletCli.Handler
{
    [Command("reload", Description = "Reload Varlet services")]
    public class CmdRestartHandler
    {
        private void OnExecute(IConsole console)
        {
            ColorizeConsole.PrintlnInfo($"\n> Reloading services ...");
            ReloadService(References.ServiceNameHttp);
            ReloadService(References.ServiceNameSmtp);
            ColorizeConsole.PrintlnInfo($"\n> Services reloaded.\n");
        }

        private static void ReloadService(string serviceName)
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
                    Arguments = "start " + serviceName,
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
