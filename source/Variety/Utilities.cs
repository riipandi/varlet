using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Variety
{
    public static class Utilities
    {
        public static void OpenWithNotepad(string file, bool runas = false)
        {
            try {
                var proc = new Process {StartInfo =
                {
                    FileName = "notepad.exe",
                    Arguments = file,
                    UseShellExecute = true
                }};
                if (runas == true) proc.StartInfo.Verb = "runas";
                proc.Start();
            } catch (FormatException) {}
        }

        public static void ReplaceStringInFile(string filename, string search, string replace)
        {
            var sr = new StreamReader(filename);
            var rows = Regex.Split(sr.ReadToEnd(), "\r\n");
            sr.Close();

            var sw = new StreamWriter(filename);
            for (var i = 0; i < rows.Length; i++)
            {
                if (rows[i].Contains(search))
                {
                    rows[i] = rows[i].Replace(search, replace);
                }
                sw.WriteLine(rows[i]);
            }
            sw.Close();
        }

        public static bool IsValidDomainName(string name)
        {
            try  {
                return StringComparer.OrdinalIgnoreCase.Equals(new Uri("http://" + name).Host, name);
            } catch (UriFormatException)  {
                return false;
            }
        }

        public static bool IsExistsOnPath(string fileName)
        {
            return GetFullPath(fileName) != null;
        }

        private static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }

            return null;
        }

        private static NetworkInterface GetActiveNic()
        {
            var nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
                a => a.OperationalStatus == OperationalStatus.Up &&
                     (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                     a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));

            return nic;
        }

        public static void SetDnsResolver(string dnsString)
        {
            string[] dns = { dnsString };
            var currentInterface = GetActiveNic();
            if (currentInterface == null) return;

            var objMc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var objMoc = objMc.GetInstances();
            foreach (var o in objMoc)
            {
                var objMo = (ManagementObject) o;
                if (!(bool) objMo["IPEnabled"]) continue;
                if (!objMo["Description"].ToString().Equals(currentInterface.Description)) continue;
                var objdns = objMo.GetMethodParameters("SetDNSServerSearchOrder");
                if (objdns == null) continue;
                objdns["DNSServerSearchOrder"] = dns;
                objMo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
            }
        }

        public static void UnsetDnsResolver()
        {
            var currentInterface = GetActiveNic();
            if (currentInterface == null) return;

            var objMc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var objMoc = objMc.GetInstances();
            foreach (var o in objMoc)
            {
                var objMo = (ManagementObject) o;
                if (!(bool) objMo["IPEnabled"]) continue;
                if (!objMo["Description"].ToString().Equals(currentInterface.Description)) continue;
                var objdns = objMo.GetMethodParameters("SetDNSServerSearchOrder");
                if (objdns == null) continue;
                objdns["DNSServerSearchOrder"] = null;
                objMo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
            }
        }
    }
}
