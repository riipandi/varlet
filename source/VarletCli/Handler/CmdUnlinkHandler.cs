using System;
using System.IO;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Variety;

namespace VarletCli.Handler
{
    [Command("unlink", Description = "Remove a virtualhost")]
    public class CmdUnlinkHandler
    {
        [Option("-d", Description = "Specify the domain name")]
        private string Domain { get; }

        private void OnExecute(IConsole console)
        {
            var dirPath = Environment.CurrentDirectory;
            var dirName = Path.GetFileName(dirPath);
            var defaultExtension = Config.Get("App", "VhostExtension");
            var givenDomain = dirName.ToLower() + defaultExtension;

            if (Domain != null) givenDomain = Domain;

            // TODO: fix domain tld validator
            if (!Utilities.IsValidDomainName(givenDomain))  {
                ColorizeConsole.PrintlnError($"\n> Please specify a valid domain name!\n");
                return;
            }

            var vhostFile = VirtualHost.ApacheVhostDir + @"\" + givenDomain + ".conf";
            if (!File.Exists(vhostFile))  {
                ColorizeConsole.PrintlnWarning($"\n> VirtualHost doesn't exists!\n");
                return;
            }

            ColorizeConsole.PrintlnInfo($"\n> Removing virtualhost ...");
            File.Delete(vhostFile);
            if (!DnsHostfile.IsNotExists(givenDomain)) DnsHostfile.DeleteRecord(givenDomain);
            if (!Hostfile.IsNotExists(givenDomain)) Hostfile.DeleteRecord(givenDomain);

            ColorizeConsole.PrintlnInfo($"\n> Reloading services ...");
            Services.Reload(References.ServiceNameHttp);
            Task.Delay(TimeSpan.FromSeconds(5));

            ColorizeConsole.PrintlnSuccess($"\n> Your site has been removed.\n");
        }
    }
}
