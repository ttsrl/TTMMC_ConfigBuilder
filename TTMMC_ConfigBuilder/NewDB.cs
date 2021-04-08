using System;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class newDB : Form
    {
        public string ConnName;
        public string IP;
        public string DB;
        public string Username;
        public string Password;
        public bool RequestSecurityInfo;

        public newDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                ConnName = textBox5.Text;
                IP = textBox1.Text;
                DB = textBox2.Text;
                Username = textBox3.Text;
                Password = textBox4.Text;
                RequestSecurityInfo = checkBox1.Checked;
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Inserisci tutti i dati richiesti", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
