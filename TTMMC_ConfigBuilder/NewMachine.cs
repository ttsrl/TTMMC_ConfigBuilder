using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static TTMMC_ConfigBuilder.Form1;

namespace TTMMC_ConfigBuilder
{
    public partial class newMachine : Form
    {

        public Machine Machine;

        private List<DataGroup> datas;
        private RecordingDetails recordingDetails;

        public newMachine()
        {
            InitializeComponent();
        }

        private void newMachine_Load(object sender, EventArgs e)
        {
            if (file_ is FileConfig)
            {
                foreach (var t in Enum.GetNames(typeof(MachineType)))
                {
                    comboBox1.Items.Add(t);
                }

                comboBox2.Items.AddRange(file_.Protocols.ToArray());
                comboBox4.Items.AddRange(file_.Groups.ToArray());
                comboBox5.Items.AddRange(Enum.GetNames(typeof(ReadMode)));
                comboBox5.Items.RemoveAt(0);
                lblId.Text = (file_.Machines.Count + 1).ToString();

                Machine = new Machine();
                datas = new List<DataGroup>();
                recordingDetails = new RecordingDetails();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Insert all data request", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBox3.Text == "--" && (comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == ""))
            {
                MessageBox.Show("Insert all data request", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox5.Text == "Null" && comboBox3.Text == "--")
            {
                MessageBox.Show("Insert all data request", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox3.SelectedItem.ToString() != "--")
            {
                Machine = new Machine
                {
                    Id = file_.Machines.Count + 1,
                    ReferenceName = textBox1.Text,
                    Description = textBox2.Text,
                    Type = (MachineType)Enum.Parse(typeof(MachineType), comboBox1.SelectedItem.ToString()),
                    Group = file_.GetGroup(comboBox4.SelectedItem.ToString()),
                    Protocol = "",
                    Address = "",
                    Port = "",
                    RootPath = "",
                    ShareEngine = file_.GetMachine(comboBox3.Text).Id,
                    OnlineDataItem = textBox8.Text,
                    Image = (textBox5.Text == "") ? null : textBox5.Text,
                    Icon = (textBox6.Text == "") ? null : textBox6.Text,
                    CallRealtimeDatasReadInterval = Convert.ToInt32(numericUpDown2.Value),
                    ReadMode = ReadMode.Null,
                    ReadingContinuousInterval = Convert.ToInt32(numericUpDown1.Value),
                    Datas = datas,
                    RecordingDetails = recordingDetails
                };
            }
            else
            {
                Machine = new Machine
                {
                    Id = file_.Machines.Count + 1,
                    ReferenceName = textBox1.Text,
                    Description = textBox2.Text,
                    Type = (MachineType)Enum.Parse(typeof(MachineType), comboBox1.SelectedItem.ToString()),
                    Group = file_.GetGroup(comboBox4.SelectedItem.ToString()),
                    Protocol = file_.GetProtocol(comboBox2.SelectedItem.ToString()),
                    Address = textBox3.Text,
                    Port = textBox4.Text,
                    RootPath = textBox7.Text,
                    ShareEngine = -1,
                    OnlineDataItem = "",
                    Image = (textBox5.Text == "") ? null : textBox5.Text,
                    Icon = (textBox6.Text == "") ? null : textBox6.Text,
                    CallRealtimeDatasReadInterval = Convert.ToInt32(numericUpDown2.Value),
                    ReadMode = (ReadMode)Enum.Parse(typeof(ReadMode), comboBox5.SelectedItem.ToString()),
                    ReadingContinuousInterval = Convert.ToInt32(numericUpDown1.Value),
                    Datas = datas,
                    RecordingDetails = recordingDetails
                };
            }
            DialogResult = DialogResult.OK;

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
                if (nm == "addDatas")
                {
                    var cloneDataRead = datas.Clone().ToList();
                    frmTreview.Datas = cloneDataRead;
                    if (frmTreview.ShowDialog() == DialogResult.OK)
                        datas = frmTreview.Datas;
                }
            }
        }

        private void addRecording_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var nm = ((LinkLabel)sender).Name ?? "";
            if (!string.IsNullOrEmpty(nm))
            {
                var frmTreview = new inputTreeView();
                if (nm == "addRecording")
                {
                    var obj = (RecordingDetails)recordingDetails.Clone();
                    var frmR = new inputRecording();
                    frmR.Recording = obj;
                    frmR.Datas = datas;
                    if (frmR.ShowDialog() == DialogResult.OK)
                        recordingDetails = frmR.Recording;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var share = comboBox3.SelectedItem.ToString() != "--";
            if (share)
            {
                comboBox2.SelectedItem = null;
                comboBox2.Enabled = false;
                textBox3.Text = "";
                textBox3.Enabled = false;
                textBox4.Text = "";
                textBox4.Enabled = false;
                textBox7.Text = "";
                textBox7.Enabled = false;
                comboBox5.SelectedIndex = -1;
                comboBox5.Enabled = false;
            }
            else
            {
                comboBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox7.Enabled = true;
                comboBox5.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                return;
            var ty = (MachineType)Enum.Parse(typeof(MachineType), comboBox1.SelectedItem.ToString());
            comboBox3.Items.Clear();
            comboBox3.Items.Add("--");
            comboBox3.Items.AddRange(file_.Machines.Where(m => m.Type == ty && m.ShareEngine == -1).Select(m => m.ReferenceName).ToArray());
            comboBox3.SelectedItem = "--";
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem.ToString() == "Continuous")
                numericUpDown1.Enabled = true;
            else
            {
                numericUpDown1.Enabled = false;
                numericUpDown1.Value = 1000;
            }
        }
    }
}
