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
                ColorizeConsole.PrintlnError($"\n> VirtualHost already exists!\n");
                return;
            }

            ColorizeConsole.PrintlnInfo($"\n> Creating virtualhost ...");
            VirtualHost.CreateCert(givenDomain);
            VirtualHost.CreateVhost(givenDomain, dirPath.Replace("\\", "/"));
            if (DnsHostfile.IsNotExists(givenDomain)) DnsHostfile.AddRecord(givenDomain);

            // TODO: services restart command still not working
            // ColorizeConsole.PrintlnInfo($"\n> Reloading services ...");
            // Services.Reload(References.ServiceNameHttp);
            // Task.Delay(TimeSpan.FromSeconds(5));

            ColorizeConsole.PrintlnSuccess($"\n> Virtualhost has been created, please restart Varlet services in VarletUi!");
            ColorizeConsole.PrintlnWarning($"> Your site will be available at: http://{givenDomain} and https://{givenDomain}\n");
        }
    }
}
