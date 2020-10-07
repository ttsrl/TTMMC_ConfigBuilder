using System;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputDataItem : Form
    {
        public bool DataRead { get; set; }
        public bool ReferenceKeyAlreadyPresent { get; set; }
        public bool FinishKeyAlreadyPresent { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }
        public string Format { get; set; }
        public string Unit { get; set; }
        public bool IsReferenceKey { get; set; }
        public bool IsFinishKey { get; set; }
        public bool Ignore { get; set; }

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
            checkBox2.Checked = IsFinishKey;
            if (!DataRead)
            {
                checkBox1.Checked = checkBox1.Enabled = false;
                checkBox3.Checked = checkBox3.Enabled = false;
            }
            else
            {
                checkBox1.Checked = IsReferenceKey;
                checkBox3.Checked = Ignore;
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
                IsReferenceKey = checkBox1.Checked;
                IsFinishKey = checkBox2.Checked;
                Ignore = checkBox3.Checked;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ReferenceKeyAlreadyPresent && checkBox1.Checked)
            {
                if (MessageBox.Show("Reference key already present in other data item of the same type. Overwrite?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    checkBox1.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (FinishKeyAlreadyPresent && checkBox2.Checked)
            {
                if (MessageBox.Show("Finish key already present in other data item of the same type. Overwrite?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    checkBox2.Checked = false;
            }
        }
    }
}
