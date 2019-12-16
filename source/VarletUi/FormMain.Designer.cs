namespace VarletUi
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(VarletUi.FormMain));
            this.btnServices = new System.Windows.Forms.Button();
            this.btnTerminal = new System.Windows.Forms.Button();
            this.cmbPhpVersion = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDnsLogFile = new System.Windows.Forms.Label();
            this.lblDnsHostFile = new System.Windows.Forms.Label();
            this.pictStatusDnsResolver = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMailhogLog = new System.Windows.Forms.Label();
            this.lblMailhogOpen = new System.Windows.Forms.Label();
            this.lblApacaheLog = new System.Windows.Forms.Label();
            this.lblApacheConfig = new System.Windows.Forms.Label();
            this.pictMailhogStatus = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictApacheStatus = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPhpIni = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSitesManager = new System.Windows.Forms.Label();
            this.lblSetting = new System.Windows.Forms.Label();
            this.lblAbout = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictStatusDnsResolver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictMailhogStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictApacheStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            this.btnServices.Enabled = false;
            this.btnServices.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnServices.Location = new System.Drawing.Point(31, 413);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(211, 42);
            this.btnServices.TabIndex = 0;
            this.btnServices.Text = "Services Not Installed";
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            this.btnTerminal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnTerminal.Location = new System.Drawing.Point(262, 413);
            this.btnTerminal.Name = "btnTerminal";
            this.btnTerminal.Size = new System.Drawing.Size(211, 42);
            this.btnTerminal.TabIndex = 1;
            this.btnTerminal.Text = "&Terminal";
            this.btnTerminal.UseVisualStyleBackColor = true;
            this.btnTerminal.Click += new System.EventHandler(this.btnTerminal_Click);
            this.cmbPhpVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhpVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.cmbPhpVersion.FormattingEnabled = true;
            this.cmbPhpVersion.Location = new System.Drawing.Point(243, 140);
            this.cmbPhpVersion.Name = "cmbPhpVersion";
            this.cmbPhpVersion.Size = new System.Drawing.Size(152, 25);
            this.cmbPhpVersion.TabIndex = 2;
            this.groupBox1.Controls.Add(this.lblDnsLogFile);
            this.groupBox1.Controls.Add(this.lblDnsHostFile);
            this.groupBox1.Controls.Add(this.pictStatusDnsResolver);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblMailhogLog);
            this.groupBox1.Controls.Add(this.lblMailhogOpen);
            this.groupBox1.Controls.Add(this.lblApacaheLog);
            this.groupBox1.Controls.Add(this.lblApacheConfig);
            this.groupBox1.Controls.Add(this.pictMailhogStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.pictApacheStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.groupBox1.Location = new System.Drawing.Point(31, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 198);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services Status";
            this.lblDnsLogFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDnsLogFile.Enabled = false;
            this.lblDnsLogFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblDnsLogFile.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDnsLogFile.Location = new System.Drawing.Point(334, 92);
            this.lblDnsLogFile.Name = "lblDnsLogFile";
            this.lblDnsLogFile.Size = new System.Drawing.Size(73, 23);
            this.lblDnsLogFile.TabIndex = 17;
            this.lblDnsLogFile.Text = "Log File";
            this.lblDnsLogFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDnsLogFile.Click += new System.EventHandler(this.lblDnsLogFile_Click);
            this.lblDnsHostFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDnsHostFile.Enabled = false;
            this.lblDnsHostFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblDnsHostFile.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDnsHostFile.Location = new System.Drawing.Point(231, 92);
            this.lblDnsHostFile.Name = "lblDnsHostFile";
            this.lblDnsHostFile.Size = new System.Drawing.Size(94, 23);
            this.lblDnsHostFile.TabIndex = 16;
            this.lblDnsHostFile.Text = "Host File";
            this.lblDnsHostFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDnsHostFile.Click += new System.EventHandler(this.lblDnsHostFile_Click);
            this.pictStatusDnsResolver.BackColor = System.Drawing.Color.DarkGray;
            this.pictStatusDnsResolver.Location = new System.Drawing.Point(180, 92);
            this.pictStatusDnsResolver.Name = "pictStatusDnsResolver";
            this.pictStatusDnsResolver.Size = new System.Drawing.Size(31, 23);
            this.pictStatusDnsResolver.TabIndex = 15;
            this.pictStatusDnsResolver.TabStop = false;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label6.Location = new System.Drawing.Point(24, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "DNS Resolver";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMailhogLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMailhogLog.Enabled = false;
            this.lblMailhogLog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblMailhogLog.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblMailhogLog.Location = new System.Drawing.Point(334, 136);
            this.lblMailhogLog.Name = "lblMailhogLog";
            this.lblMailhogLog.Size = new System.Drawing.Size(73, 23);
            this.lblMailhogLog.TabIndex = 13;
            this.lblMailhogLog.Text = "Log File";
            this.lblMailhogLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMailhogLog.Click += new System.EventHandler(this.lblMailhogLog_Click);
            this.lblMailhogOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMailhogOpen.Enabled = false;
            this.lblMailhogOpen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblMailhogOpen.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblMailhogOpen.Location = new System.Drawing.Point(231, 136);
            this.lblMailhogOpen.Name = "lblMailhogOpen";
            this.lblMailhogOpen.Size = new System.Drawing.Size(94, 23);
            this.lblMailhogOpen.TabIndex = 12;
            this.lblMailhogOpen.Text = "Open";
            this.lblMailhogOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMailhogOpen.Click += new System.EventHandler(this.lblMailhogOpen_Click);
            this.lblApacaheLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblApacaheLog.Enabled = false;
            this.lblApacaheLog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblApacaheLog.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblApacaheLog.Location = new System.Drawing.Point(334, 48);
            this.lblApacaheLog.Name = "lblApacaheLog";
            this.lblApacaheLog.Size = new System.Drawing.Size(73, 23);
            this.lblApacaheLog.TabIndex = 11;
            this.lblApacaheLog.Text = "Log File";
            this.lblApacaheLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblApacaheLog.Click += new System.EventHandler(this.lblApacaheLog_Click);
            this.lblApacheConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblApacheConfig.Enabled = false;
            this.lblApacheConfig.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblApacheConfig.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblApacheConfig.Location = new System.Drawing.Point(231, 48);
            this.lblApacheConfig.Name = "lblApacheConfig";
            this.lblApacheConfig.Size = new System.Drawing.Size(94, 23);
            this.lblApacheConfig.TabIndex = 10;
            this.lblApacheConfig.Text = "Config";
            this.lblApacheConfig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblApacheConfig.Click += new System.EventHandler(this.lblApacheConfig_Click);
            this.pictMailhogStatus.BackColor = System.Drawing.Color.DarkGray;
            this.pictMailhogStatus.Location = new System.Drawing.Point(180, 136);
            this.pictMailhogStatus.Name = "pictMailhogStatus";
            this.pictMailhogStatus.Size = new System.Drawing.Size(31, 23);
            this.pictMailhogStatus.TabIndex = 9;
            this.pictMailhogStatus.TabStop = false;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label4.Location = new System.Drawing.Point(24, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mailhog SMTP";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pictApacheStatus.BackColor = System.Drawing.Color.DarkGray;
            this.pictApacheStatus.Location = new System.Drawing.Point(180, 48);
            this.pictApacheStatus.Name = "pictApacheStatus";
            this.pictApacheStatus.Size = new System.Drawing.Size(31, 23);
            this.pictApacheStatus.TabIndex = 7;
            this.pictApacheStatus.TabStop = false;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label3.Location = new System.Drawing.Point(24, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "HTTP Server";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(31, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select PHP Version";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPhpIni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPhpIni.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblPhpIni.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPhpIni.Location = new System.Drawing.Point(416, 140);
            this.lblPhpIni.Name = "lblPhpIni";
            this.lblPhpIni.Size = new System.Drawing.Size(57, 23);
            this.lblPhpIni.TabIndex = 5;
            this.lblPhpIni.Text = "php.ini";
            this.lblPhpIni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPhpIni.Click += new System.EventHandler(this.lblPhpIni_Click);
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image) (resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.lblSitesManager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSitesManager.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblSitesManager.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSitesManager.Location = new System.Drawing.Point(362, 27);
            this.lblSitesManager.Name = "lblSitesManager";
            this.lblSitesManager.Size = new System.Drawing.Size(111, 23);
            this.lblSitesManager.TabIndex = 7;
            this.lblSitesManager.Text = "Site &Manager";
            this.lblSitesManager.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSitesManager.Click += new System.EventHandler(this.lblSitesManager_Click);
            this.lblSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetting.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblSetting.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSetting.Location = new System.Drawing.Point(362, 62);
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.Size = new System.Drawing.Size(111, 23);
            this.lblSetting.TabIndex = 8;
            this.lblSetting.Text = "&Preferences";
            this.lblSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSetting.Click += new System.EventHandler(this.lblSetting_Click);
            this.lblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAbout.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F,
                ((System.Drawing.FontStyle) ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))),
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblAbout.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblAbout.Location = new System.Drawing.Point(234, 23);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(33, 23);
            this.lblAbout.TabIndex = 9;
            this.lblAbout.Text = "?";
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 483);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.lblSetting);
            this.Controls.Add(this.lblSitesManager);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblPhpIni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbPhpVersion);
            this.Controls.Add(this.btnTerminal);
            this.Controls.Add(this.btnServices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictStatusDnsResolver)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictMailhogStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictApacheStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPhpVersion;
        private System.Windows.Forms.Button btnTerminal;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMailhogLog;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblSetting;
        private System.Windows.Forms.Label lblSitesManager;
        private System.Windows.Forms.Label lblMailhogOpen;
        private System.Windows.Forms.Label lblApacaheLog;
        private System.Windows.Forms.Label lblApacheConfig;
        private System.Windows.Forms.PictureBox pictMailhogStatus;
        private System.Windows.Forms.PictureBox pictApacheStatus;
        private System.Windows.Forms.Label lblPhpIni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictStatusDnsResolver;
        private System.Windows.Forms.Label lblDnsHostFile;
        private System.Windows.Forms.Label lblDnsLogFile;
    }
}
