using System;
using System.Reflection;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
        }

        private void info_Load(object sender, EventArgs e)
        {
            label3.Text = "v: " + Assembly.GetEntryAssembly().GetName().Version.ToString();
        }
    }
}
