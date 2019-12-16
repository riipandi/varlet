using System;
using System.Diagnostics;
using System.IO;
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

        public static string GetFullPath(string fileName)
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

        // public static string GetActiveNic()
        // {
        //     // do something
        // }

        // public static void SetDnsResolver(string activeNic, string primaryDns = "dhcp", string secondaryDns = null)
        // {
        //     // do something
        // }
    }
}
