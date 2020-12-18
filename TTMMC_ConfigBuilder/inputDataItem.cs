using System;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputDataItem : Form
    {

        public bool DataRead { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }
        public string Format { get; set; }
        public string Unit { get; set; }
        public bool IgnoreRealtime { get; set; }
        public bool IgnoreInLogs { get; set; }

        public inputDataItem()
        {
            InitializeComponent();
            Format = DataItemFormat.Empty.ToString();
        }

        private void inputDataItem_Load(object sender, EventArgs e)
        {
            textBox1.Text = Address;
            textBox2.Text = Description;
            textBox3.Text = Format;
            textBox4.Text = Unit;
            if (!DataRead)
            {
                checkBox3.Checked = checkBox3.Enabled = false;
                checkBox4.Checked = checkBox3.Enabled = false;
            }
            else
            {
                checkBox3.Checked = IgnoreRealtime;
                checkBox4.Checked = IgnoreInLogs;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Description = textBox1.Text;
                Address = textBox2.Text;
                Format = textBox3.Text;
                Unit = textBox4.Text;
                IgnoreRealtime = checkBox3.Checked;
                IgnoreInLogs = checkBox4.Checked;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Insert all required datas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new inputDataItemFormat();
            frm.Format = textBox3.Text;
            if (frm.ShowDialog() == DialogResult.OK)
                textBox3.Text = frm.Format;
        }

    }
}
