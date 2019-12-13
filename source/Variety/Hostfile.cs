using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Variety
{
    public static class Hostfile
    {
        private static readonly string HostsFileName = Environment.SystemDirectory + @"\drivers\etc\hosts";
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

        public static void Reset()
        {
            const string HostFileOriginalText = @"# Copyright (c) 1993-2009 Microsoft Corp.
#
#   RESET BY: Varlet (c) 2019 Aris Ripandi
#
# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
#
# This file contains the mappings of IP addresses to host names. Each
# entry should be kept on an individual line. The IP address should
# be placed in the first column followed by the corresponding host name.
# The IP address and the host name should be separated by at least one
# space.
#
# Additionally, comments (such as these) may be inserted on individual
# lines or following the machine name denoted by a '#' symbol.
#
# For example:
#
#      102.54.94.97     rhino.acme.com          # source server
#       38.25.63.10     x.acme.com              # x client host
# localhost name resolution is handled within DNS itself.
#	127.0.0.1       localhost
#	::1             localhost
";
            _hWriter = new StreamWriter(HostsFileName, false);
            _hWriter.Write(HostFileOriginalText);
            _hWriter.Close();
        }
    }
}
