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
    public partial class inputGroup : Form
    {
        public string GroupName { get; set; }
        public DataGroupMode Mode { get; set; }


        public inputGroup()
        {
            InitializeComponent();
        }

        private void inputGroup_Load(object sender, EventArgs e)
        {
            textBox1.Text = GroupName;
            comboBox1.SelectedIndex = (int)Mode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && comboBox1.Text != "")
            {
                GroupName = textBox1.Text;
                Mode = (DataGroupMode)comboBox1.SelectedIndex;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Insert all required datas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
