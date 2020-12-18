using System;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputTxt : Form
    {
        public string Value;
        public string LblTxt;

        public inputTxt()
        {
            InitializeComponent();
        }

        private void name_Load(object sender, EventArgs e)
        {
            label1.Text = LblTxt ?? "Name:";
            textBox1.Text = Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Value = textBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Insert all data request.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
