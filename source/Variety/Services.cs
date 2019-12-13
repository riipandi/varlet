using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Variety
{
    internal static class Services
    {
        public static bool IsInstalled(string serviceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(serviceName));
        }

        public static bool IsRunning(string serviceName)
        {
            var sc = new ServiceController {ServiceName = serviceName};
            return sc.Status == ServiceControllerStatus.Running;
        }

        public static void Start(string serviceName)
        {
            var service = new ServiceController(serviceName);
            try {
                if (IsRunning(serviceName)) return;
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(30000));
            } catch (FormatException) {}
        }

        public static void Stop(string serviceName)
        {
            var service = new ServiceController(serviceName);
            try {
                if (!IsRunning(serviceName)) return;
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(30000));
            } catch (FormatException) {}
        }

        public static void ChangeStartMode(string serviceName, string mode)
        {
            try {
                var proc = new Process {StartInfo =
                {
                    FileName = "sc.exe",
                    Arguments = "config "+serviceName+" start=" + mode,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Verb = "runas"
                }};
                proc.Start();
            } catch (FormatException) {}
        }

        public static int GetStartupType(string serviceName)
        {
            var key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + serviceName);
            if (key == null) return 0;
            var startMode = Convert.ToInt32(key.GetValue("Start"));
            key.Close();
            return startMode;
        }

        public static void Reload(string serviceName)
        {
            try {
                if (!IsRunning(serviceName)) return;
                Stop(serviceName);
                Task.Delay(TimeSpan.FromSeconds(3));
                Start(serviceName);
            } catch (FormatException) {}
        }
    }
}
