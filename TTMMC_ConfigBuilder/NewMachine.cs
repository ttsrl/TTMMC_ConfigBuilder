using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TTMMC_ConfigBuilder.Form1;

namespace TTMMC_ConfigBuilder
{
    public partial class NewMachine : Form
    {
        private string _nmEditLbl;
        private string _nmEditLbl1;

        public string MachineName;
        public string Description;
        public MachineType Type;
        public FileConfigProtocol Protocol;
        public FileConfigGroup Group;
        public string Address;
        public string Port;
        public string Image;
        public string Icon_;
        public int MinRefTime;
        public int ModalityLogCheck;
        public int ValueModalityLogCheck;
        public Dictionary<string, List<DataAddressItem>> DatasAddressToRead;
        public Dictionary<string, List<DataAddressItem>> DatasAddressToWrite;

        public NewMachine()
        {
            InitializeComponent();
        }

        private void NewMachine_Load(object sender, EventArgs e)
        {
            if (file_ is FileConfig)
            {
                foreach (var t in Enum.GetNames(typeof(MachineType)))
                {
                    comboBox1.Items.Add(t);
                }

                foreach (var p in Form1.file_.Protocols)
                {
                    comboBox2.Items.Add(p.Name);
                }

                foreach (var g in Form1.file_.Groups)
                {
                    comboBox4.Items.Add(g.Name);
                }

                lblId.Text = (file_.Machines.Count + 1).ToString();

                DatasAddressToRead = new Dictionary<string, List<DataAddressItem>>();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                MachineName = textBox1.Text;
                Description = textBox2.Text;
                Type = (MachineType)Enum.Parse(typeof(MachineType), comboBox1.SelectedItem.ToString());
                Protocol = Form1.file_.GetProtocol(comboBox2.SelectedItem.ToString());
                Group = Form1.file_.GetGroup(comboBox4.SelectedItem.ToString());
                Address = textBox3.Text;
                Port = textBox4.Text;
                Image = (textBox5.Text == "") ? null : textBox5.Text;
                Icon_ = (textBox6.Text == "") ? null : textBox6.Text;
                MinRefTime = Convert.ToInt32(numericUpDown2.Value);
                ModalityLogCheck = comboBox3.SelectedIndex;
                ValueModalityLogCheck = Convert.ToInt32(numericUpDown1.Value);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Inserisci tutti i dati richiesti", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void editDatasWrite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var nm = ((LinkLabel)sender).Name ?? "";
            if (!string.IsNullOrEmpty(nm))
            {
                var frmTreview = new inputTreeView();
                if (nm == "addDatasRead")
                {
                    //copia
                    var newDatasToRead = new Dictionary<string, List<DataAddressItem>>();
                    frmTreview.datasAddress = newDatasToRead;
                    if (frmTreview.ShowDialog() == DialogResult.OK)
                    {
                        DatasAddressToRead = frmTreview.datasAddress;
                    }
                }
                else if (nm == "addDatasWrite")
                {
                    //copia
                    var newDatasToWrite = new Dictionary<string, List<DataAddressItem>>();
                    frmTreview.datasAddress = newDatasToWrite;
                    if (frmTreview.ShowDialog() == DialogResult.OK)
                    {
                        DatasAddressToWrite = frmTreview.datasAddress;
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var txt = comboBox3.SelectedItem.ToString();
            if(txt == "Key > 0 Ogni X Volte" || txt == "Key > Prec. Ogni X Volte")
            {
                numericUpDown1.Enabled = true;
            }
            else
            {
                numericUpDown1.Enabled = false;
                numericUpDown1.Value = 1;
            }
        }
    }
}
