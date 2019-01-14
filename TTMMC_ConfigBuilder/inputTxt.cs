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
            label1.Text = LblTxt ?? "Nome:";
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
            {
                MessageBox.Show("Inserisci tutti i dati richiesti", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
