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
        public enum KeyAttribute
        {
            NotMapped,
            ReferenceKey,
            FinishKey
        }
        public bool Read { get; set; }
        public string Value { get; set; }
        public List<KeyAttribute> Attributes { get; set; }

        public inputKey()
        {
            InitializeComponent();
        }

        private void inputKey_Load(object sender, EventArgs e)
        {
            if (!Read)
            {
                checkBox2.Enabled = false;
            }
            Attributes = (Attributes == null) ? new List<KeyAttribute>() : Attributes;
            checkBox1.Checked = Attributes.Contains(KeyAttribute.NotMapped);
            checkBox2.Checked = Attributes.Contains(KeyAttribute.ReferenceKey);
            checkBox3.Checked = Attributes.Contains(KeyAttribute.FinishKey);
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
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
                
            if (checkBox1.Checked)
            {
                Attributes.Clear();
                Attributes.Add(KeyAttribute.NotMapped);
            }
            else
            {
                Attributes.Remove(KeyAttribute.NotMapped);
            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
                checkBox1.Checked = false;

            if (checkBox2.Checked)
            {
                if (!Attributes.Contains(KeyAttribute.ReferenceKey))
                {
                    Attributes.Add(KeyAttribute.ReferenceKey);
                }
            }
            else
            {
                Attributes.Remove(KeyAttribute.ReferenceKey);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox3.Checked)
                checkBox1.Checked = false;

            if (checkBox3.Checked)
            {
                if (!Attributes.Contains(KeyAttribute.FinishKey))
                {
                    Attributes.Add(KeyAttribute.FinishKey);
                }
            }
            else
            {
                Attributes.Remove(KeyAttribute.FinishKey);
            }
        }
    }
}
