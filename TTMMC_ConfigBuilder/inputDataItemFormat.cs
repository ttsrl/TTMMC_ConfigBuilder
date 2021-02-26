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
            comboBox2.SelectedIndex = (int)dataItemFormat.ThousandsDivisor;
            comboBox1.SelectedIndex = (int)dataItemFormat.DecimalsDivisor;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Checked = true;
        }

        private void loadFormat(string f)
        {
            dataItemFormat = DataItemFormat.Parse(f);
            if (!dataItemFormat.IsEmpty)
            {
                numericUpDown1.ValueChanged -= numericUpDown1_ValueChanged;
                numericUpDown1.Value = dataItemFormat.Digits;
                numericUpDown2.ValueChanged -= numericUpDown2_ValueChanged;
                numericUpDown2.Value = dataItemFormat.Decimals;
                comboBox2.SelectedIndex = (int)dataItemFormat.ThousandsDivisor;
                comboBox1.SelectedIndex = (int)dataItemFormat.DecimalsDivisor;
                checkBox1.Checked = dataItemFormat.FillZero;
                numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
                numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            }
            checkBox2.Checked = dataItemFormat.IsEmpty;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataItemFormat = new DataItemFormat(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value))
            { DecimalsDivisor = dataItemFormat.DecimalsDivisor, ThousandsDivisor = dataItemFormat.ThousandsDivisor, FillZero = dataItemFormat.FillZero, IsEmpty = dataItemFormat.IsEmpty };
            label1.Text = dataItemFormat.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            dataItemFormat = new DataItemFormat(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value))
            { DecimalsDivisor = dataItemFormat.DecimalsDivisor, ThousandsDivisor = dataItemFormat.ThousandsDivisor, FillZero = dataItemFormat.FillZero, IsEmpty = dataItemFormat.IsEmpty };
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
            if (checkBox2.Checked)
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                checkBox1.Enabled = false;
            }
            else
            {
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                checkBox1.Enabled = true;
            }
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
