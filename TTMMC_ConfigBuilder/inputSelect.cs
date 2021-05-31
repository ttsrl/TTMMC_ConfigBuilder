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
    public partial class inputSelect : Form
    {
        public string Value;
        public string LblTxt;
        public List<string> List;

        public inputSelect()
        {
            InitializeComponent();
        }

        private void inputSelect_Load(object sender, EventArgs e)
        {
            label1.Text = LblTxt ?? "Nome:";
            if (List != null && List.Count > 0)
            {
                foreach (var it in List)
                {
                    comboBox1.Items.Add(it);
                }
            }

            if (!comboBox1.Items.Contains("--"))
                comboBox1.Items.Insert(0, "--");

            if (comboBox1.Items.Count > 1 && Value != null)
                comboBox1.SelectedItem = Value;
            else
                comboBox1.SelectedItem = "--";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox1.Text != "--")
            {
                Value = comboBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Insert all data requested.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
