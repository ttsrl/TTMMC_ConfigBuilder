using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static TTMMC_ConfigBuilder.inputList.iLAction;

namespace TTMMC_ConfigBuilder
{
    public partial class inputList : Form
    {
        public List<string> List { get; set; }
        public List<iLAction> Actions { get; set; }

        public inputList()
        {
            InitializeComponent();
            Actions = new List<iLAction>();
        }

        private void editList_Load(object sender, EventArgs e)
        {
            reloadListbox1();
        }

        private void btt_edit_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem?.ToString();
            if (curItem == null)
                return;
            var index = listBox1.Items.IndexOf(curItem);
            if (index < 0)
                return;
            var inputTxt = new inputTxt();
            inputTxt.Value = curItem;
            inputTxt.Text = "Edit Object";
            if (inputTxt.ShowDialog() == DialogResult.OK)
            {
                if (List[index] == inputTxt.Value)
                    return;
                if (string.IsNullOrEmpty(inputTxt.Value))
                {
                    MessageBox.Show("Element not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (List.Contains(inputTxt.Value))
                {
                    MessageBox.Show("Element with this name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List[index] = inputTxt.Value;
                reloadListbox1();
                Actions.Add(new iLAction { OldElement = curItem, Action = iLActions.Edit, NewElement = inputTxt.Value });
            }
        }

        private void btt_delete_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem?.ToString();
            if (curItem == null)
                return;
            List.Remove(curItem);
            reloadListbox1();
            Actions.Add(new iLAction { OldElement = curItem, Action = iLActions.Delete });
        }

        private void btt_add_Click(object sender, EventArgs e)
        {
            var frm = new inputTxt();
            frm.Text = "Add Object";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(frm.Value))
                {
                    MessageBox.Show("Element not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (List.Contains(frm.Value))
                {
                    MessageBox.Show("Element with this name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                List.Add(frm.Value);
                reloadListbox1();
                Actions.Add(new iLAction { Action = iLActions.Add, NewElement = frm.Value });
            }
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void reloadListbox1()
        {
            listBox1.ClearSelected();
            listBox1.Items.Clear();
            if (List == null || List.Count == 0)
                return;
            listBox1.Items.AddRange(List.ToArray());
        }

        public class iLAction
        {
            public enum iLActions { Add, Edit, Delete }
            public string OldElement { get; set; }
            public iLActions Action { get; set; }
            public string NewElement { get; set; }
        }
    }
}
