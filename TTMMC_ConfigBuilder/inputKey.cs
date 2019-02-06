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
    public partial class inputKey : Form
    {
        public enum Modality
        {
            Normal,
            ReferenceKey,
            NotMapped
        }

        public string Value { get; set; }
        public Modality KeyModality { get; set; }

        public inputKey()
        {
            InitializeComponent();
        }

        private void inputKey_Load(object sender, EventArgs e)
        {
            KeyModality = Modality.Normal;
            textBox1.Text = Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" )
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

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked && checkBox1.Checked)
                checkBox2.Checked = false;
            KeyModality = (checkBox1.Checked) ? Modality.NotMapped : Modality.Normal;
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
                checkBox1.Checked = false;
            KeyModality = (checkBox2.Checked) ? Modality.ReferenceKey : Modality.Normal;
        }
    }
}
