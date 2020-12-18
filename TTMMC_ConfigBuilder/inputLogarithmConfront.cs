using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputLogarithmConfront : Form
    {
        public List<DataGroup> Datas { get; set; }

        private LogarithmConfront item;
        public LogarithmConfront Item { get => item; set => item = value; }

        public inputLogarithmConfront()
        {
            InitializeComponent();
        }        
        
        private void inputLogarithmItem_Load(object sender, EventArgs e)
        {
            foreach (var t in Enum.GetNames(typeof(LogarithmAritmeticOperator)))
            {
                comboBox1.Items.Add(t);
            }
            if (item != null)
            {
                comboBox1.SelectedItem = Enum.GetName(typeof(LogarithmAritmeticOperator), item.Operator);
                label1.Text = (item.Var1 == null) ? "null" : item.Var1.ToString();
                label2.Text = (item.Var2 == null) ? "null" : item.Var2.ToString();
            }
            else
                DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(item.Var1 == null || item.Var2 == null || string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Please insert all field requested.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            item.Operator = (LogarithmAritmeticOperator)Enum.Parse(typeof(LogarithmAritmeticOperator), comboBox1.Text);
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new inputLogarithmVar();
            f.Datas = Datas;
            f.Var = (item.Var1 == null) ? new ConfrontVar() : (ConfrontVar)item.Var1.Clone();
            if (f.ShowDialog() == DialogResult.OK)
            {
                item.Var1 = f.Var;
                label1.Text = f.Var.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new inputLogarithmVar();
            f.Datas = Datas;
            f.Var = (item.Var2 == null) ? new ConfrontVar() : (ConfrontVar)item.Var2.Clone();
            if (f.ShowDialog() == DialogResult.OK)
            {
                item.Var2 = f.Var;
                label2.Text = f.Var.ToString();
            }
        }

    }
}
