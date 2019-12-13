using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Variety
{
    public static class References
    {
        private static string AppRegistryPath { get; }
        public const string ServiceNameHttp = "VarletHttpd";
        public const string ServiceNameSmtp = "VarletMailhog";

        public static string AppConfigFile => AppRootPath + @"\varlet.ini";
        public static string AppLogFile => AppRootPath + @"\varlet.log";
        public static string WwwDirectory => !string.IsNullOrEmpty(Config.Get("App", "DocumentRoot")) ?
            Config.Get("App", "DocumentRoot") : Config.DefaultDocumentRoot;

        static References()
        {
            AppRegistryPath = @"HKLM\Software\Aris Ripandi\Varlet";
        }

        public static string AppNameSpace
        {
            get
            {
                var appNameSpace = "VarletUi";
                var appExeName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly()?.Location);
                if (appExeName == "varlet.exe") appNameSpace = "VarletCli";

                return appNameSpace;
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

        public static string AppRootPath
        {
            get {
                var appExeName = Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly()?.Location);
                var rootDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var appPath = rootDir;

                if (appExeName == "varlet.exe") appPath = Directory.GetParent(rootDir).ToString();

                return appPath;
            }
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

        public static string GetParent(string path)
        {
            var directoryInfo =  Directory.GetParent(path);
            return directoryInfo.FullName;
        }
    }
}
