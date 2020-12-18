using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputLogarithmVar : Form
    {

        public List<DataGroup> Datas { get; set; }

        private ConfrontVar var;
        public ConfrontVar Var { get => var; set => var = value; }

        public inputLogarithmVar()
        {
            InitializeComponent();
        }

        private void inputConfrontVar_Load(object sender, EventArgs e)
        {
            if(Datas != null)
                comboBox2.Items.AddRange(Datas.Select(d => d.Name).ToArray());

            if (var != null)
            {
                if (var.Type == ConfrontVarType.DataItem)
                {
                    comboBox1.SelectedItem = "DataItem";
                    if (comboBox2.Items.Count > 0)
                        comboBox2.SelectedItem = var.GetDataGroup();
                    comboBox3.SelectedItem = var.GetDataItem();
                    comboBox2.Enabled = true;
                    comboBox3.Enabled = true;
                }
                else if (var.Type == ConfrontVarType.Value)
                {
                    comboBox1.SelectedItem = "Value";
                    textBox1.Text = var.Value;
                    textBox1.Enabled = true;
                }
                else
                    comboBox1.SelectedItem = "LastDataItemRecValue";
            }
            else
                DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool val = false;
                Regex regex = new Regex("^[0-9]+$");
                bool hasOnlyNumb = regex.IsMatch(textBox1.Text);
                if (comboBox1.SelectedItem.ToString() == "Value" && hasOnlyNumb)
                    val = true;
                else if (comboBox1.SelectedItem.ToString() == "DataItem" && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
                    val = true;
                else if (comboBox1.SelectedItem.ToString() == "LastDataItemRecValue")
                    val = true;

                if (val)
                {
                    if (comboBox1.SelectedItem.ToString() == "DataItem")
                        var = new ConfrontVar() { Value = comboBox2.Text + "[" + comboBox3.Text + "]", Type = ConfrontVarType.DataItem };
                    else if (comboBox1.SelectedItem.ToString() == "Value")
                        var = new ConfrontVar() { Value = textBox1.Text, Type = ConfrontVarType.Value };
                    else
                        var = new ConfrontVar() { Type = ConfrontVarType.LastDataItemRecValue };
                    DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Please compile all necessary field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { MessageBox.Show("Error when compiling the structure.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()))
                return;
            if(comboBox1.SelectedItem.ToString() == "DataItem")
            {
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                textBox1.Text = "0";
                textBox1.Enabled = false;
                comboBox2.Focus();
            }
            else if (comboBox1.SelectedItem.ToString() == "Value")
            {
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox3.Items.Clear();
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else if (comboBox1.SelectedItem.ToString() == "LastDataItemRecValue")
            {
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox3.Items.Clear();
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                textBox1.Text = "0";
                textBox1.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            if (string.IsNullOrEmpty(comboBox2.SelectedItem.ToString()))
                return;
            var items = Datas.GetDataGroup(comboBox2.SelectedItem.ToString()).Items;
            foreach(var it in items)
            {
                comboBox3.Items.Add(items.IndexOf(it));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
