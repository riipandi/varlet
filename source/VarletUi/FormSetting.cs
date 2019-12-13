using System;
using System.ServiceProcess;
using System.Windows.Forms;
using Microsoft.Win32;
using Variety;

namespace VarletUi
{
    public partial class FormSetting : Form
    {
        private const string RegistryStartupPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public FormSetting()
        {
            InitializeComponent();
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            txtDocumentRoot.Text = Config.Get("App", "DocumentRoot");
            txtVhostExtension.Text = Config.Get("App", "VhostExtension");
            txtPortHttp.Text  = Config.Get("App", "DefaultPortHttp");
            txtPortHttps.Text  = Config.Get("App", "DefaultPortHttps");

            // Run services automatically?
            var startModeHttp = Services.GetStartupType(References.ServiceNameHttp);
            var startModeSmtp = Services.GetStartupType(References.ServiceNameSmtp);
            if ((startModeHttp == 2) || (startModeSmtp == 2)) chkServicesAuto.Checked = true;

            // Run Varlet at startup?
            var key = Registry.CurrentUser.OpenSubKey(RegistryStartupPath);
            if (key?.GetValue("Varlet") == null) return;
            chkRunVarletStartup.Checked = true;
            key.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Save configuration to file
            Config.Set("App", "DocumentRoot", txtDocumentRoot.Text);
            Config.Set("App", "DefaultPortHttp", txtPortHttp.Text);
            Config.Set("App", "DefaultPortHttps", txtPortHttps.Text);
            Config.Set("App", "VhostExtension", txtVhostExtension.Text);

            MessageBox.Show("You need to restart services to apply changes!");
            (new FormMain()).Refresh();
        }

        private void btnChooseDir_Click(object sender, EventArgs e)
        {
            using (var fd = new FolderBrowserDialog()) {
                if (fd.ShowDialog(this)== DialogResult.OK) {
                    txtDocumentRoot.Text = fd.SelectedPath;
                }
            }
        }

        private void chkRunVarletStartup_CheckedChanged(object sender, EventArgs e)
        {
            var key = Registry.CurrentUser.OpenSubKey(RegistryStartupPath, true);
            if (key == null) return;
            if (chkRunVarletStartup.Checked)  {
                key.SetValue("Varlet", Application.ExecutablePath + " /minimized");
            } else  {
                key.DeleteValue("Varlet");
            }
            key.Close();
        }

        private void chkServicesAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkServicesAuto.Checked)
            {
                if (Services.IsInstalled(References.ServiceNameHttp))
                    Services.ChangeStartMode(References.ServiceNameHttp, "auto");

                if (Services.IsInstalled(References.ServiceNameSmtp))
                    Services.ChangeStartMode(References.ServiceNameSmtp, "auto");
            } else  {
                if (Services.IsInstalled(References.ServiceNameHttp))
                {
                    if (Services.IsInstalled(References.ServiceNameHttp))
                        Services.ChangeStartMode(References.ServiceNameHttp, "demand");

                    if (Services.IsInstalled(References.ServiceNameSmtp))
                        Services.ChangeStartMode(References.ServiceNameSmtp, "demand");
                }
            }
        }
    }
}
