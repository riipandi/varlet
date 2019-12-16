using System;
using System.IO;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;
using Variety;

namespace VarletCli.Handler
{
    [Command("link", Description = "Create virtualhost from any directory")]
    public class CmdLinkHandler
    {
        [Option("-d", Description = "Assign a domain name to the virtual host")]
        private string Domain { get; }

        private void OnExecute(IConsole console)
        {
            // dirPath.Replace("\\", "/")
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
            if (File.Exists(vhostFile))  {
                ColorizeConsole.PrintlnWarning($"\n> VirtualHost already exists!\n");
                return;
            }

            ColorizeConsole.PrintlnInfo($"\n> Creating virtualhost ...");
            VirtualHost.CreateCert(givenDomain);
            VirtualHost.CreateVhost(givenDomain, dirPath);
            if (DnsHostfile.IsNotExists(givenDomain)) DnsHostfile.AddRecord(givenDomain);

            ColorizeConsole.PrintlnInfo($"\n> Reloading services ...");
            Services.Reload(References.ServiceNameHttp);
            Task.Delay(TimeSpan.FromSeconds(5));

            ColorizeConsole.PrintlnSuccess($"\n> Your site available at: http://{givenDomain}\n");
        }
    }
}
