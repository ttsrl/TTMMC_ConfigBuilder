using System;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputDataItem : Form
    {
        private bool relt = true;
        private bool logs = true;

        public DataGroupMode DataMode { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }
        public string Format { get; set; }
        public string Unit { get; set; }
        public bool Realtime { get => relt; set => relt = value; }
        public bool Logs { get => logs; set => logs = value; }
        public string Type { get; set; }

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
            comboBox1.Items.AddRange(Enum.GetNames(typeof(DataType)));
            comboBox1.SelectedIndex = 0;
            if (DataMode == DataGroupMode.Write)
            {
                checkBox3.Checked = checkBox3.Enabled = false;
                checkBox4.Checked = checkBox4.Enabled = false;
            }
            else
            {
                checkBox3.Checked = Realtime;
                checkBox4.Checked = Logs;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                Address = textBox1.Text;
                Description = textBox2.Text;
                Format = textBox3.Text;
                Unit = textBox4.Text;
                Realtime = checkBox3.Checked;
                Logs = checkBox4.Checked;
                Type = comboBox1.Text;
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
