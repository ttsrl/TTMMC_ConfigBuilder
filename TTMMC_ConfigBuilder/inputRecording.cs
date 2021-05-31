using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputRecording : Form
    {
        public List<DataGroup> Datas { get; set; }

        private RecordingDetails recording;
        public RecordingDetails Recording { get => recording; set => recording = value; }

        public inputRecording()
        {
            InitializeComponent();
        }

        private void inputRecording_Load(object sender, EventArgs e)
        {
            if (recording == null)
                DialogResult = DialogResult.Cancel;
            numericUpDown1.Value = recording.CheckTime;
            numericUpDown2.Value = recording.ConfrontsValidationCounter;
            radioButton2.Checked = recording.Type == RecordingDetails.RecordingType.Confront;
            numericUpDown3.Value = recording.ContinuousTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            recording.CheckTime = Convert.ToInt32(numericUpDown1.Value);
            recording.ConfrontsValidationCounter = Convert.ToInt32(numericUpDown2.Value);
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new inputLogarithmConfront();
            frm.Datas = Datas;
            frm.Item = (recording.RecordingConfront == null) ? new LogarithmConfront() : (LogarithmConfront)recording.RecordingConfront.Clone();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                recording.RecordingConfront = frm.Item;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new inputLogarithmConfront();
            frm.Datas = Datas;
            frm.Item = (recording.FinishConfront == null) ? new LogarithmConfront() : (LogarithmConfront)recording.FinishConfront.Clone();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                recording.FinishConfront = frm.Item;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                recording.Type = RecordingDetails.RecordingType.Continuous;
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            else
            {
                recording.Type = RecordingDetails.RecordingType.Confront;
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }

        }
    }
}
