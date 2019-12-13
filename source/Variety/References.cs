using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Variety
{
    public static class References
    {
        private static string AppRegistryPath { get; }
        private const string AppConfigFileName = "varlet.ini";
        public const string ServiceNameHttp = "VarletHttpd";
        public const string ServiceNameSmtp = "VarletMailhog";
        public static string WwwDirectory => !string.IsNullOrEmpty(Config.Get("App", "DocumentRoot")) ?
            Config.Get("App", "DocumentRoot") : Config.DefaultDocumentRoot;

        static References()
        {
            AppRegistryPath = @"HKLM\Software\Aris Ripandi\Varlet";
        }

        public static string AppConfigFile
        {
            get {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return path + @"\" + AppConfigFileName;
            }
        }

        public static string AppLogFile
        {
            get {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                return path + @"\varlet.log";
            }
        }

        public static string AppVersionSemantic
        {
            get {
                var asm = Assembly.GetExecutingAssembly();
                var fvi = FileVersionInfo.GetVersionInfo(asm.Location);
                return $"{fvi.ProductMajorPart}.{fvi.ProductMinorPart}.{fvi.ProductBuildPart}";
            }
        }

        public static string AppBuildNumber
        {
            get {
                var asm = Assembly.GetExecutingAssembly();
                var fvi = FileVersionInfo.GetVersionInfo(asm.Location);
                return $"{fvi.ProductPrivatePart}";
            }
        }

        public static string AppRootPath(string path)
        {
            var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!string.IsNullOrEmpty(path))  {
                return appPath + path;
            }
            return appPath;
        }

        public static string ProgramFilesDir(string path)
        {
            if( 8 == IntPtr.Size  || (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))  {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            if (string.IsNullOrEmpty(path)) {
                return Environment.GetEnvironmentVariable("ProgramFiles") + path;
            } else {
                return Environment.GetEnvironmentVariable("ProgramFiles");
            }
        }

        public static string GetEmbeddedResourceContent(string resourceName)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            if (stream == null) return null;
            var source = new StreamReader(stream);
            var fileContent = source.ReadToEnd();
            source.Dispose();
            stream.Dispose();
            return fileContent;
        }
    }
}
