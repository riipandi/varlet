using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Variety;
using static System.Drawing.Color;

namespace VarletUi
{
    public partial class FormMain : Form
    {
        private static bool RunMinimized { get; set; }

        public FormMain(string parameter = "normal")
        {
            InitializeComponent();
            if (!File.Exists(References.AppConfigFile)) Config.Initialize();
            if (parameter != "/minimized") return;
            RunMinimized = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ListAvailablePhp();
            CheckServiceStatus();
            Text = "Varlet v" + References.AppVersionSemantic + " build " +References.AppBuildNumber;
            if (RunMinimized) {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                BeginInvoke(new MethodInvoker(Close));
                RunMinimized = false;
            }
            Activate();
            Focus();

            // TODO: revert if already fixed
            lblSitesManager.Text = "Host File";

            // TODO: make it work
            Config.Set("App", "LastUpdateCheck", DateTime.Now.ToString(CultureInfo.CurrentCulture));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason.Equals(CloseReason.UserClosing)) {
                base.OnFormClosing(e);
                e.Cancel = true;
                (new TrayContext()).ShowTrayIconNotification();
                Hide();
            } else {
                Utilities.UnsetDnsResolver();
                Application.ExitThread();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            (new TrayContext()).ExitApplication();
        }

        private void CheckServiceStatus() {
            if (Services.IsInstalled(References.ServiceNameHttp)) {
                pictApacheStatus.BackColor = Red;
                lblApacheConfig.Enabled = true;
                lblApacaheLog.Enabled = true;
                lblPhpIni.Enabled = true;
                btnServices.Enabled = true;
                btnServices.Text = "Start Services";
                if (Services.IsRunning(References.ServiceNameHttp)) {
                    btnServices.Text = "Stop Services";
                    pictApacheStatus.BackColor = Green;
                    cmbPhpVersion.Enabled = false;
                    lblApacheConfig.Enabled = false;
                    lblPhpIni.Enabled = false;
                    if (Services.IsInstalled(References.ServiceNameDnsResolver))
                        Utilities.SetDnsResolver("127.0.0.1");
                }
            }

            if (Services.IsInstalled(References.ServiceNameDnsResolver)) {
                pictStatusDnsResolver.BackColor = Red;
                lblDnsHostFile.Enabled = true;
                lblDnsLogFile.Enabled = true;
                if (Services.IsRunning(References.ServiceNameDnsResolver)) pictStatusDnsResolver.BackColor = Green;
            }

            if (Services.IsInstalled(References.ServiceNameSmtp)) {
                pictMailhogStatus.BackColor = Red;
                lblMailhogOpen.Enabled = false;
                lblMailhogLog.Enabled = true;
                btnServices.Enabled = true;
                btnServices.Text = "Start Services";
                if (Services.IsRunning(References.ServiceNameSmtp)) {
                    btnServices.Text = "Stop Services";
                    pictMailhogStatus.BackColor = Green;
                    lblMailhogOpen.Enabled = true;
                    lblMailhogLog.Enabled = true;
                }
            }

            if (btnServices.Text == "Start Services") Utilities.UnsetDnsResolver();
        }

        public void lblSetting_Click(object sender, EventArgs e)
        {
            new FormSetting().ShowDialog();
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            Process.Start("https://varlet.dev/");
        }

        private void lblMailhogOpen_Click(object sender, EventArgs e)
        {
            Process.Start("http://localhost:8025");
        }

        private void lblPhpIni_Click(object sender, EventArgs e)
        {
            var file = References.AppRootPath + @"\pkg\php\"+cmbPhpVersion.Text+@"\php.ini";
            if (!File.Exists(file))  {
                MessageBox.Show("File "+file+" not found!");
            } else  {
                Utilities.OpenWithNotepad(file);
            }
        }

        private void lblApacheConfig_Click(object sender, EventArgs e)
        {
            var path = References.AppRootPath + @"\pkg\httpd\conf";
            if (!Directory.Exists(path)) return;
            var proc = new Process {StartInfo = {
                FileName = "explorer.exe",  Arguments = path,  UseShellExecute = false
            }};
            proc.Start();
        }

        private void lblApacaheLog_Click(object sender, EventArgs e)
        {
            var file = References.AppRootPath + @"\tmp\httpd_error.log";
            if (!File.Exists(file))  {
                MessageBox.Show("File "+file+" not found!");
            } else  {
                Utilities.OpenWithNotepad(file);
            }
        }

        private void lblMailhogLog_Click(object sender, EventArgs e)
        {
            var file = References.AppRootPath + @"\tmp\mailhogservice.err.log";
            if (!File.Exists(file))  {
                MessageBox.Show("File "+file+" not found!");
            } else  {
                Utilities.OpenWithNotepad(file);
            }
        }

        public void lblSitesManager_Click(object sender, EventArgs e)
        {
            // new FormSites().ShowDialog();
            Hostfile.OpenWithEditor();
        }

        private void ListAvailablePhp()
        {
            var pkgPhp = References.AppRootPath + @"\pkg\php";
            if (!Directory.Exists(pkgPhp)) return;
            foreach (var t in Directory.GetDirectories(pkgPhp))  {
                cmbPhpVersion.Items.Add(Path.GetFileName(t));
            }
            cmbPhpVersion.SelectedIndex = !string.IsNullOrEmpty(Config.Get("App", "SelectedPhpVersion")) ?
                cmbPhpVersion.FindStringExact(Config.Get("App", "SelectedPhpVersion")) : 0;
        }

        public void btnTerminal_Click(object sender, EventArgs e)
        {
            var wwwDirectory = Config.Get("App", "DocumentRoot");
            if (!Directory.Exists(wwwDirectory)) wwwDirectory = References.AppRootPath;

            try {
                var terminalApp = "pwsh.exe";
                var terminalArg = "-NoLogo -WorkingDirectory \"" + wwwDirectory + "\"";
                if (!Utilities.IsExistsOnPath(terminalApp)) {
                    terminalApp = "cmd.exe";
                    terminalArg = "/k \"cd /d " + wwwDirectory + "\"";
                }

                var proc = new Process {StartInfo = {
                    FileName = terminalApp,
                    Arguments = terminalArg,
                    UseShellExecute = false
                }};
                proc.Start();
            } catch (FormatException) {}
        }

        public void btnServices_Click(object sender, EventArgs e)
        {
            if (!File.Exists(References.AppRootPath + @"\pkg\httpd\conf\httpd.conf")) {
                MessageBox.Show("Apache configuration file not found!");
                return;
            }

            btnServices.Enabled = false;
            switch (btnServices.Text)
            {
                case "Stop Services":
                    StoppingServices();
                    Refresh();
                    break;
                case "Start Services":
                    ChangePhpVersion();
                    AutoGenerateVhost();
                    StartingServices();
                    Refresh();
                    break;
            }
        }

        private static void AutoGenerateVhost()
        {
            // Remove old vhost
            var files = (new DirectoryInfo(VirtualHost.ApacheVhostDir)).GetFiles("auto.*.conf");
            foreach(var file in files ) {
                var domain = file.Name.Replace("auto.", "").Replace(".conf", "");
                if (!DnsHostfile.IsNotExists(domain)) DnsHostfile.DeleteRecord(domain);
                File.Delete(file.FullName);
            }

            // Generate auto virtualhost
            var wwwDir = Config.Get("App", "DocumentRoot");
            if (!Directory.Exists(wwwDir)) return;
            foreach (var dir in Directory.GetDirectories(wwwDir))
            {
                var dirName = Path.GetFileName(dir);
                var dirPath = wwwDir + @"\" + dirName;
                var domain = dirName + Config.Get("App", "VhostExtension");
                VirtualHost.CreateCert(domain);
                VirtualHost.CreateVhost(domain, dirPath, true);
                if (DnsHostfile.IsNotExists(domain)) DnsHostfile.AddRecord(domain);
            }
            VirtualHost.SetDefaultVhost();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        private void StartingServices()
        {
            if (Services.IsInstalled(References.ServiceNameHttp)) {
                while (!Services.IsRunning(References.ServiceNameHttp))  {
                    btnServices.Text = "Starting Services";
                    Services.Start(References.ServiceNameHttp);
                    if (Services.IsRunning(References.ServiceNameHttp)) {
                        pictApacheStatus.BackColor = Color.Green;
                        btnServices.Text = "Stop Services";
                        cmbPhpVersion.Enabled = false;
                        lblApacheConfig.Enabled = false;
                        lblPhpIni.Enabled = false;
                        CheckServiceStatus();
                        break;
                    }
                }
            }

            if (Services.IsInstalled(References.ServiceNameDnsResolver)) {
                while (!Services.IsRunning(References.ServiceNameDnsResolver))  {
                    btnServices.Text = "Starting Services";
                    Services.Start(References.ServiceNameDnsResolver);
                    if (Services.IsRunning(References.ServiceNameDnsResolver)) {
                        pictStatusDnsResolver.BackColor = Color.Green;
                        btnServices.Text = "Stop Services";
                        lblDnsHostFile.Enabled = false;
                        lblDnsLogFile.Enabled = false;
                        CheckServiceStatus();
                        break;
                    }
                }
            }

            if (Services.IsInstalled(References.ServiceNameSmtp)) {
                while (!Services.IsRunning(References.ServiceNameSmtp))  {
                    btnServices.Text = "Starting Services";
                    Services.Start(References.ServiceNameSmtp);
                    if (Services.IsRunning(References.ServiceNameSmtp)) {
                        pictMailhogStatus.BackColor = Color.Green;
                        lblMailhogOpen.Enabled = true;
                        lblMailhogLog.Enabled = true;
                        btnServices.Text = "Stop Services";
                        CheckServiceStatus();
                        break;
                    }
                }
            }
        }

        private void StoppingServices()
        {
            if (Services.IsInstalled(References.ServiceNameHttp)) {
                while (Services.IsRunning(References.ServiceNameHttp))  {
                    btnServices.Text = "Stopping Services";
                    Services.Stop(References.ServiceNameHttp);
                    if (!Services.IsRunning(References.ServiceNameHttp)) {
                        pictApacheStatus.BackColor = Color.Red;
                        btnServices.Text = "Start Services";
                        cmbPhpVersion.Enabled = true;
                        lblApacheConfig.Enabled = true;
                        lblPhpIni.Enabled = true;
                        CheckServiceStatus();
                        break;
                    }
                }
            }

            if (Services.IsInstalled(References.ServiceNameDnsResolver)) {
                while (Services.IsRunning(References.ServiceNameDnsResolver))  {
                    btnServices.Text = "Stopping Services";
                    Services.Stop(References.ServiceNameDnsResolver);
                    if (!Services.IsRunning(References.ServiceNameDnsResolver)) {
                        pictStatusDnsResolver.BackColor = Color.Red;
                        btnServices.Text = "Start Services";
                        CheckServiceStatus();
                        break;
                    }
                }
            }

            if (Services.IsInstalled(References.ServiceNameSmtp)) {
                while (Services.IsRunning(References.ServiceNameSmtp))  {
                    btnServices.Text = "Stopping Services";
                    Services.Stop(References.ServiceNameSmtp);
                    if (!Services.IsRunning(References.ServiceNameSmtp)) {
                        pictMailhogStatus.BackColor = Color.Red;
                        lblMailhogOpen.Enabled = false;
                        lblMailhogLog.Enabled = false;
                        btnServices.Text = "Start Services";
                        CheckServiceStatus();
                        break;
                    }
                }
            }
        }

        private void ChangePhpVersion()
        {
            var cfgApache = References.AppRootPath + @"\pkg\httpd\conf\httpd.conf";

            const string keyword = "PHPVERSION";
            var oldVersion = Config.Get("App", "SelectedPhpVersion");
            var newVersion = cmbPhpVersion.Text;

            var sr = new StreamReader(cfgApache);
            string currentLine;
            var foundText = false;

            do  {
                currentLine = sr.ReadLine();
                if(currentLine != null)  {
                    foundText = currentLine.Contains(keyword);
                }
            }  while(currentLine != null && !foundText);

            if (foundText)
            {
                var result = currentLine.Substring(currentLine.IndexOf(keyword) + keyword.Length);
                oldVersion = result;
                sr.Close();
            }

            // Update PHP Version on Apache Configuration
            Utilities.ReplaceStringInFile(cfgApache, oldVersion, " \"" + newVersion + "\"");

            // Update PHP Version on Composer
            var phpExe = References.AppRootPath + @"\pkg\php\"+newVersion+@"\php.exe";
            var composerPhar = References.AppRootPath + @"\utils\composer.phar";
            var content = "@echo off\n\""+phpExe+"\" \""+composerPhar+"\" %*";
            File.WriteAllText(References.AppRootPath + @"\utils\composer.bat", content);
            Config.Set("App", "SelectedPhpVersion", cmbPhpVersion.Text);
        }

        // cirina
        private void lblDnsHostFile_Click(object sender, EventArgs e)
        {
            if (!File.Exists(DnsHostfile.HostsFileName))  {
                MessageBox.Show("File " + DnsHostfile.HostsFileName + " not found!");
            } else  {
                DnsHostfile.OpenWithEditor();
            }
        }

        private void lblDnsLogFile_Click(object sender, EventArgs e)
        {
            var file = References.AppRootPath + @"\tmp\AcrylicDNSHitLog.txt";
            if (!File.Exists(file))  {
                MessageBox.Show("File "+file+" not found!");
            } else  {
                Utilities.OpenWithNotepad(file);
            }
        }
    }
}
