using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static TTMMC_ConfigBuilder.Form1;

namespace TTMMC_ConfigBuilder
{
    public partial class NewMachineDataItem : Form
    {

        public string Description;
        public string Address;
        public string DataType;

        public NewMachineDataItem()
        {
            InitializeComponent();
        }

        private void NewMachineDataItem_Load(object sender, EventArgs e)
        {
            textBox1.Text = Description;
            textBox2.Text = Address;
            comboBox1.DataSource = Enum.GetValues(typeof(DataTypes)).Cast<DataTypes>().Select(v => v.ToString()).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "")
            {
                Description = textBox1.Text;
                Address = textBox2.Text;
                DataType = comboBox1.Text;
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
