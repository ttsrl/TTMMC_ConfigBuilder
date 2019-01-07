using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class name : Form
    {
        public string NameTxt;

        public name()
        {
            InitializeComponent();
        }

        private void name_Load(object sender, EventArgs e)
        {
            textBox1.Text = NameTxt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameTxt = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
