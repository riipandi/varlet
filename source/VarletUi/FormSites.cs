using System;
using System.Windows.Forms;
using Variety;

namespace VarletUi
{
    public partial class FormSites : Form
    {
        public FormSites()
        {
            InitializeComponent();
        }

        private void lblSetting_Click(object sender, EventArgs e)
        {
            Hostfile.OpenWithEditor();
        }
    }
}

