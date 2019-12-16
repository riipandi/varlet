using System;
using System.Diagnostics;
using System.IO;

namespace Variety
{
    public static class DnsHostfile
    {
        public static string HostsFileName => References.AppRootPath + @"\pkg\acrylic\AcrylicHosts.txt";
        private static StreamReader _hReader;
        private static StreamWriter _hWriter;

        public static void OpenWithEditor(string editor = "notepad.exe")
        {
            try {
                var proc = new Process {StartInfo =
                {
                    FileName = editor,
                    Arguments = HostsFileName,
                    UseShellExecute = true,
                    Verb = "runas"
                }};
                proc.Start();
            } catch (FormatException) {}
        }

        public static void AddRecord(string domain, string ipAddr = "127.0.0.1", string comment = "VarletHost")
        {
            _hWriter = new StreamWriter(HostsFileName, true);
            _hWriter.WriteLine(ipAddr + "\t\t" + domain + "\t\t# " + comment);
            _hWriter.Close();
        }

        public static void DeleteRecord(string domain, string ipAddr = "127.0.0.1", string comment = "VarletHost")
        {
            var hostsFileContents = "";
            var found = false;

            using (_hReader = new StreamReader(HostsFileName))
            {
                hostsFileContents = _hReader.ReadToEnd();
                _hReader.Close();
            }

            var lines = hostsFileContents.Split('\n');

            for (var i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > 0 && lines[i][0] == '#') continue;
                if (!lines[i].Contains(domain)) continue;
                lines[i] = "";
                found = true;
                break;
            }

            if (!found)  return;

            using (_hWriter = new StreamWriter(HostsFileName, false))
            {
                foreach (var line in lines)
                {
                    if (line.Length <= 0) continue;
                    _hWriter.Write(line);
                    _hWriter.Write('\n');
                }
                _hWriter.Close();
            }
        }

        public static bool IsNotExists(string domain)
        {
            var isExist = true;
            using (var sr = File.OpenText(HostsFileName))  {
                if (sr.ReadToEnd().Contains(domain)) isExist = false;
            }
            return isExist;
        }
    }
}
