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
    public partial class inputVPN : Form
    {
        public List<string> Items { get; set; }

        public string ReferenceName { get; set; }
        public string Value { get; set; }

        public inputVPN()
        {
            InitializeComponent();
        }

        private void inputVPN_Load(object sender, EventArgs e)
        {
            if (Items != null && Items.Count > 0)
            {
                comboBox1.Items.AddRange(Items.ToArray());
                comboBox1.SelectedIndex = 0;
            }
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(textBox1.Text))
            {
                ReferenceName = comboBox1.Text;
                Value = textBox1.Text;
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Insert all request datas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
