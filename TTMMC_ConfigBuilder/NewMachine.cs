using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Protocol;
        public string Group;
        public string Address;
        public string Port;
        public string Image;
        public string Icon_;
        public int MinRefTime;
        public int ModalityLogCheck;
        public int ValueModalityLogCheck;
        public List<DataGroup> DatasRead;
        public List<DataGroup> DatasWrite;

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

                comboBox2.Items.AddRange(file_.Protocols.ToArray());
                comboBox4.Items.AddRange(file_.Groups.ToArray());
                lblId.Text = (file_.Machines.Count + 1).ToString();

                DatasRead = new List<DataGroup>();
                DatasWrite = new List<DataGroup>();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "")
            {
                MachineName = textBox1.Text;
                Description = textBox2.Text;
                Type = (MachineType)Enum.Parse(typeof(MachineType), comboBox1.SelectedItem.ToString());
                Protocol = file_.GetProtocol(comboBox2.SelectedItem.ToString());
                Group = file_.GetGroup(comboBox4.SelectedItem.ToString());
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
                MessageBox.Show("Insert all data request", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void editDatas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var nm = ((LinkLabel)sender).Name ?? "";
            if (!string.IsNullOrEmpty(nm))
            {
                var frmTreview = new inputTreeView();
                if (nm == "addDatasRead")
                {
                    var cloneDataRead = DatasRead.Clone().ToList();
                    frmTreview.DataRead = true;
                    frmTreview.datas = cloneDataRead;
                    if (frmTreview.ShowDialog() == DialogResult.OK)
                        DatasRead = frmTreview.datas;
                }
                else if (nm == "addDatasWrite")
                {
                    var cloneDataWrite = DatasWrite.Clone().ToList();
                    frmTreview.DataRead = false;
                    frmTreview.datas = cloneDataWrite;
                    if (frmTreview.ShowDialog() == DialogResult.OK)
                        DatasWrite = frmTreview.datas;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var txt = comboBox3.SelectedItem.ToString();
            if(txt == "KeyGreater0EveryXTimes" || txt == "KeyGreaterLastEveryXTimes")
                numericUpDown1.Enabled = true;
            else
            {
                numericUpDown1.Enabled = false;
                numericUpDown1.Value = 1;
            }
        }
    }
}
