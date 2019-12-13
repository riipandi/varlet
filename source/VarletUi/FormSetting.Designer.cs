using System.ComponentModel;

namespace VarletUi
{
    partial class FormSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblUpdateCheck = new System.Windows.Forms.Label();
            this.chkUpdateCheck = new System.Windows.Forms.CheckBox();
            this.btnChooseDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVhostExtension = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocumentRoot = new System.Windows.Forms.TextBox();
            this.chkRunVarletStartup = new System.Windows.Forms.CheckBox();
            this.chkServicesAuto = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkEnableMailhog = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPortMailhog = new System.Windows.Forms.TextBox();
            this.checkEnableHttps = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPortHttps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPortHttp = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(406, 325);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblUpdateCheck);
            this.tabPage1.Controls.Add(this.chkUpdateCheck);
            this.tabPage1.Controls.Add(this.btnChooseDir);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtVhostExtension);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtDocumentRoot);
            this.tabPage1.Controls.Add(this.chkRunVarletStartup);
            this.tabPage1.Controls.Add(this.chkServicesAuto);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(398, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblUpdateCheck
            // 
            this.lblUpdateCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUpdateCheck.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblUpdateCheck.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUpdateCheck.Location = new System.Drawing.Point(300, 95);
            this.lblUpdateCheck.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUpdateCheck.Name = "lblUpdateCheck";
            this.lblUpdateCheck.Size = new System.Drawing.Size(61, 23);
            this.lblUpdateCheck.TabIndex = 17;
            this.lblUpdateCheck.Text = "check";
            this.lblUpdateCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUpdateCheck.Visible = false;
            // 
            // chkUpdateCheck
            // 
            this.chkUpdateCheck.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.chkUpdateCheck.Location = new System.Drawing.Point(26, 95);
            this.chkUpdateCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkUpdateCheck.Name = "chkUpdateCheck";
            this.chkUpdateCheck.Size = new System.Drawing.Size(266, 24);
            this.chkUpdateCheck.TabIndex = 16;
            this.chkUpdateCheck.Text = "Check for updates automatically";
            this.chkUpdateCheck.UseVisualStyleBackColor = true;
            this.chkUpdateCheck.Visible = false;
            // 
            // btnChooseDir
            // 
            this.btnChooseDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnChooseDir.Location = new System.Drawing.Point(326, 180);
            this.btnChooseDir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnChooseDir.Name = "btnChooseDir";
            this.btnChooseDir.Size = new System.Drawing.Size(35, 25);
            this.btnChooseDir.TabIndex = 15;
            this.btnChooseDir.Text = "...";
            this.btnChooseDir.UseVisualStyleBackColor = true;
            this.btnChooseDir.Click += new System.EventHandler(this.btnChooseDir_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(26, 234);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Default Virtual Host Extension";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVhostExtension
            // 
            this.txtVhostExtension.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtVhostExtension.Location = new System.Drawing.Point(266, 234);
            this.txtVhostExtension.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtVhostExtension.Name = "txtVhostExtension";
            this.txtVhostExtension.Size = new System.Drawing.Size(94, 25);
            this.txtVhostExtension.TabIndex = 13;
            this.txtVhostExtension.Text = ".test";
            this.txtVhostExtension.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(24, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Document Root";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDocumentRoot
            // 
            this.txtDocumentRoot.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtDocumentRoot.Location = new System.Drawing.Point(26, 178);
            this.txtDocumentRoot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDocumentRoot.Name = "txtDocumentRoot";
            this.txtDocumentRoot.ReadOnly = true;
            this.txtDocumentRoot.Size = new System.Drawing.Size(334, 25);
            this.txtDocumentRoot.TabIndex = 11;
            this.txtDocumentRoot.Text = "C:\\Varlet\\www";
            // 
            // chkRunVarletStartup
            // 
            this.chkRunVarletStartup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.chkRunVarletStartup.Location = new System.Drawing.Point(26, 60);
            this.chkRunVarletStartup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkRunVarletStartup.Name = "chkRunVarletStartup";
            this.chkRunVarletStartup.Size = new System.Drawing.Size(266, 24);
            this.chkRunVarletStartup.TabIndex = 10;
            this.chkRunVarletStartup.Text = "Run VarletUi when Windows start";
            this.chkRunVarletStartup.UseVisualStyleBackColor = true;
            this.chkRunVarletStartup.CheckedChanged += new System.EventHandler(this.chkRunVarletStartup_CheckedChanged);
            // 
            // chkServicesAuto
            // 
            this.chkServicesAuto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.chkServicesAuto.Location = new System.Drawing.Point(26, 25);
            this.chkServicesAuto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkServicesAuto.Name = "chkServicesAuto";
            this.chkServicesAuto.Size = new System.Drawing.Size(266, 24);
            this.chkServicesAuto.TabIndex = 9;
            this.chkServicesAuto.Text = "Run services automatically";
            this.chkServicesAuto.UseVisualStyleBackColor = true;
            this.chkServicesAuto.CheckedChanged += new System.EventHandler(this.chkServicesAuto_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkEnableMailhog);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtPortMailhog);
            this.tabPage2.Controls.Add(this.checkEnableHttps);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtPortHttps);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtPortHttp);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage2.Size = new System.Drawing.Size(398, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Services Port";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkEnableMailhog
            // 
            this.checkEnableMailhog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.checkEnableMailhog.Location = new System.Drawing.Point(262, 114);
            this.checkEnableMailhog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkEnableMailhog.Name = "checkEnableMailhog";
            this.checkEnableMailhog.Size = new System.Drawing.Size(94, 24);
            this.checkEnableMailhog.TabIndex = 22;
            this.checkEnableMailhog.Text = "Enable";
            this.checkEnableMailhog.UseVisualStyleBackColor = true;
            this.checkEnableMailhog.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label5.Location = new System.Drawing.Point(29, 115);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 23);
            this.label5.TabIndex = 21;
            this.label5.Text = "Mailhog SMTP";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // txtPortMailhog
            // 
            this.txtPortMailhog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPortMailhog.Location = new System.Drawing.Point(163, 113);
            this.txtPortMailhog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPortMailhog.Name = "txtPortMailhog";
            this.txtPortMailhog.Size = new System.Drawing.Size(82, 25);
            this.txtPortMailhog.TabIndex = 20;
            this.txtPortMailhog.Text = "8025";
            this.txtPortMailhog.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPortMailhog.Visible = false;
            // 
            // checkEnableHttps
            // 
            this.checkEnableHttps.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.checkEnableHttps.Location = new System.Drawing.Point(262, 72);
            this.checkEnableHttps.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkEnableHttps.Name = "checkEnableHttps";
            this.checkEnableHttps.Size = new System.Drawing.Size(94, 24);
            this.checkEnableHttps.TabIndex = 19;
            this.checkEnableHttps.Text = "Enable";
            this.checkEnableHttps.UseVisualStyleBackColor = true;
            this.checkEnableHttps.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(29, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "HTTPS Port";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPortHttps
            // 
            this.txtPortHttps.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPortHttps.Location = new System.Drawing.Point(163, 70);
            this.txtPortHttps.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPortHttps.Name = "txtPortHttps";
            this.txtPortHttps.Size = new System.Drawing.Size(82, 25);
            this.txtPortHttps.TabIndex = 17;
            this.txtPortHttps.Text = "443";
            this.txtPortHttps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(29, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "HTTP Port";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPortHttp
            // 
            this.txtPortHttp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.txtPortHttp.Location = new System.Drawing.Point(163, 28);
            this.txtPortHttp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPortHttp.Name = "txtPortHttp";
            this.txtPortHttp.Size = new System.Drawing.Size(82, 25);
            this.txtPortHttp.TabIndex = 15;
            this.txtPortHttp.Text = "80";
            this.txtPortHttp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 325);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChooseDir;
        private System.Windows.Forms.TextBox txtVhostExtension;
        private System.Windows.Forms.TextBox txtDocumentRoot;
        private System.Windows.Forms.Label lblUpdateCheck;
        private System.Windows.Forms.CheckBox chkUpdateCheck;
        private System.Windows.Forms.CheckBox chkRunVarletStartup;
        private System.Windows.Forms.CheckBox chkServicesAuto;
        private System.Windows.Forms.CheckBox checkEnableMailhog;
        private System.Windows.Forms.TextBox txtPortMailhog;
        private System.Windows.Forms.CheckBox checkEnableHttps;
        private System.Windows.Forms.TextBox txtPortHttps;
        private System.Windows.Forms.TextBox txtPortHttp;
    }
}
