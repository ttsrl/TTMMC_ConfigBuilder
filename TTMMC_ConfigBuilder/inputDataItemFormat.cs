using System;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputDataItemFormat : Form
    {
        private DataItemFormat dataItemFormat = DataItemFormat.Empty;

        private string format;
        public string Format { get => format; set { format = value; loadFormat(format); } }

        public inputDataItemFormat()
        {
            InitializeComponent();
            format = dataItemFormat.ToString();
            label1.Text = format;
            comboBox1.Items.AddRange(Enum.GetNames(typeof(DataItemFormat.Divisors)));
            comboBox2.Items.AddRange(Enum.GetNames(typeof(DataItemFormat.Divisors)));
        }

        private void loadFormat(string f)
        {
            dataItemFormat = DataItemFormat.Parse(f);
            numericUpDown1.Value = dataItemFormat.Digits;
            numericUpDown2.Value = dataItemFormat.Decimals;
            comboBox2.SelectedIndex = (int)dataItemFormat.ThousandsDivisor;
            comboBox1.SelectedIndex = (int)dataItemFormat.DecimalsDivisor;
            checkBox1.Checked = dataItemFormat.FillZero;
            checkBox2.Checked = dataItemFormat.IsEmpty;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataItemFormat.Digits = Convert.ToInt32(numericUpDown1.Value);
            label1.Text = dataItemFormat.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            dataItemFormat.Decimals = Convert.ToInt32(numericUpDown2.Value);
            numericUpDown2.Value = dataItemFormat.Decimals;
            label1.Text = dataItemFormat.ToString();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var en = (DataItemFormat.Divisors)Enum.Parse(typeof(DataItemFormat.Divisors), comboBox1.SelectedItem.ToString());
            dataItemFormat.DecimalsDivisor = en;
            comboBox2.SelectedIndex = (int)dataItemFormat.ThousandsDivisor;
            label1.Text = dataItemFormat.ToString();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            var en = (DataItemFormat.Divisors)Enum.Parse(typeof(DataItemFormat.Divisors), comboBox2.SelectedItem.ToString());
            dataItemFormat.ThousandsDivisor = en;
            comboBox1.SelectedIndex = (int)dataItemFormat.DecimalsDivisor;
            label1.Text = dataItemFormat.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dataItemFormat.FillZero = checkBox1.Checked;
            label1.Text = dataItemFormat.ToString();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dataItemFormat.IsEmpty = checkBox2.Checked;
            label1.Text = dataItemFormat.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            format = dataItemFormat.ToString();
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
