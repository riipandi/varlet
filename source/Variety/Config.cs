using System;
using System.Globalization;
using System.IO;
using IniParser;
using IniParser.Model;

namespace Variety
{
    public static class Config
    {
        public static readonly string DefaultDocumentRoot = References.AppRootPath(@"\www");

        public static void Initialize()
        {
            var data = new IniData();

            data["App"]["LastUpdateCheck"] = DateTime.Now.ToString(CultureInfo.CurrentCulture);
            data["App"]["CloseMinimizeToTray"] = true.ToString();
            data["App"]["SelectedPhpVersion"] = "php-7.3-ts";
            data["App"]["DocumentRoot"] = DefaultDocumentRoot;
            data["App"]["DefaultPortHttp"] = "80";
            data["App"]["DefaultPortHttps"] = "443";
            data["App"]["VhostExtension"] = ".test";

            File.WriteAllText(References.AppConfigFile, data.ToString());
        }

        public static string Get(string section, string key)
        {
            var parser = new FileIniDataParser();
            var cfg = parser.ReadFile(References.AppConfigFile);

            return cfg[section][key];
        }

        public static void Set(string section, string key, string value)
        {
            var parser = new FileIniDataParser();
            var data = parser.ReadFile(References.AppConfigFile);
            data[section][key] = value;
            parser.WriteFile(References.AppConfigFile, data);
        }
    }
}
