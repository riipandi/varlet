using System;
using System.Diagnostics;
using System.IO;

namespace Variety
{
    public static class VirtualHost
    {
        private static readonly string ApacheConfDir = References.AppRootPath(@"\pkg\httpd\conf");
        public static readonly string ApacheVhostDir = References.AppRootPath(@"\pkg\httpd\conf\vhost");
        private static readonly string VhostTemplate = References.GetEmbeddedResourceContent("VarletUi.vhost.tpl.conf");
        private static readonly string SslCertDir = References.AppRootPath(@"\pkg\httpd\conf\certs");

        public static void SetDefaultVhost()
        {
            var defaultVhostFile = ApacheConfDir + @"\vhost\00-default.conf";
            if (File.Exists(defaultVhostFile)) File.Delete(defaultVhostFile);
            var fs1 = new FileStream(defaultVhostFile, FileMode.Create, FileAccess.Write);
            new StreamWriter(fs1).Write("");
            fs1.Close();

            File.WriteAllText(defaultVhostFile, VhostTemplate);
            Utilities.ReplaceStringInFile(defaultVhostFile, "<<SITENAME>>", "localhost");
            Utilities.ReplaceStringInFile(defaultVhostFile, "<<SITEROOT>>", Config.Get("App", "DocumentRoot").Replace("\\", "/"));
            Utilities.ReplaceStringInFile(defaultVhostFile, "<<DOCROOT>>", Config.Get("App", "DocumentRoot").Replace("\\", "/"));
            Utilities.ReplaceStringInFile(defaultVhostFile, "<<PORT_HTTP>>", Config.Get("App", "DefaultPortHttp"));
            Utilities.ReplaceStringInFile(defaultVhostFile, "<<PORT_HTTPS>>", Config.Get("App", "DefaultPortHttps"));

            // Don't forget to change default port
            var cfgPortsFile = ApacheConfDir + @"\ports.conf";
            if (File.Exists(cfgPortsFile)) File.Delete(cfgPortsFile);
            var fs2 = new FileStream(cfgPortsFile, FileMode.Create, FileAccess.Write);
            new StreamWriter(fs2).Write("");
            fs2.Close();
            var portHttp = Config.Get("App", "DefaultPortHttp");
            var portHttps = Config.Get("App", "DefaultPortHttps");
            var cfgPorts = "Listen "+portHttp+"\n<IfModule ssl_module>\n\tListen "+portHttps+"\n</IfModule>";
            File.WriteAllText(cfgPortsFile, cfgPorts);
        }

        public static void CreateVhost(string domain, string sitepath, bool auto = false)
        {
            var vhostFile = ApacheVhostDir + @"\" + domain + @".conf";
            if (auto)  {
                vhostFile = ApacheVhostDir + @"\auto." + domain + @".conf";
            }

            var docroot = sitepath;
            if (Directory.Exists(sitepath + @"\public"))  {
                docroot = sitepath + @"\public";
            } else if (Directory.Exists(sitepath + @"\www"))  {
                docroot = sitepath + @"\www";
            } else if (Directory.Exists(sitepath + @"\htdocs"))  {
                docroot = sitepath + @"\htdocs";
            } else if (Directory.Exists(sitepath + @"\public_html"))  {
                docroot = sitepath + @"\public_html";
            }

            if (File.Exists(vhostFile)) return;
            File.WriteAllText(vhostFile, VhostTemplate);
            Utilities.ReplaceStringInFile(vhostFile, "<<SITENAME>>", domain);
            Utilities.ReplaceStringInFile(vhostFile, "<<SITEROOT>>", sitepath.Replace("\\", "/"));
            Utilities.ReplaceStringInFile(vhostFile, "<<DOCROOT>>", docroot.Replace("\\", "/"));
            Utilities.ReplaceStringInFile(vhostFile, "<<PORT_HTTP>>", Config.Get("App", "DefaultPortHttp"));
            Utilities.ReplaceStringInFile(vhostFile, "<<PORT_HTTPS>>", Config.Get("App", "DefaultPortHttps"));
        }

        public static void CreateCert(string domain, bool wildcard = false, bool force = false)
        {
            if (!Directory.Exists(SslCertDir)) Directory.CreateDirectory(SslCertDir);

            if (wildcard) domain = domain + " *." + domain;
            var keyFile = SslCertDir + @"\" + domain + ".key";
            var crtFile = SslCertDir + @"\" + domain + ".pem";

            if (force)  {
                if (File.Exists(keyFile)) File.Delete(keyFile);
                if (File.Exists(keyFile)) File.Delete(crtFile);
            }

            try {
                if (File.Exists(keyFile) || File.Exists(crtFile)) return;
                var proc = new Process {StartInfo =
                {
                    FileName = References.AppRootPath(@"\utils\mkcert.exe"),
                    Arguments = "-key-file "+keyFile+" -cert-file "+crtFile+" " + domain,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }};
                proc.Start();
            } catch (FormatException) {}
        }
    }
}
