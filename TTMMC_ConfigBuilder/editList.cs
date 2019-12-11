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
    public partial class editList : Form
    {
        public List<string> List { get; set; }
        public Type TypeList { get; set; }

        public editList()
        {
            InitializeComponent();
        }

        private void editList_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(List.ToArray());
        }

        private void btt_rename_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem?.ToString();
            if (curItem == null)
                return;
            var index = listBox1.Items.IndexOf(curItem);
            if (index < 0)
                return;
            var inputTxt = new inputTxt();
            inputTxt.Value = curItem;
            if (inputTxt.ShowDialog() == DialogResult.OK)
            {
                if (TypeList == typeof(FileConfigProtocol))
                {
                    var prot = Form1.file_.Protocols.Where(p => p.Name == curItem).FirstOrDefault();
                    if (prot == null)
                        return;
                    prot.Name = inputTxt.Value;
                    List[index] = inputTxt.Value;
                    listBox1.Items[listBox1.SelectedIndex] = inputTxt.Value;
                }
                else if(TypeList == typeof(FileConfigGroup))
                {
                    var prot = Form1.file_.Groups.Where(p => p.Name == curItem).FirstOrDefault();
                    if (prot == null)
                        return;
                    prot.Name = inputTxt.Value;
                    List[index] = inputTxt.Value;
                    listBox1.Items[listBox1.SelectedIndex] = inputTxt.Value;
                }
                else if (TypeList == typeof(FileConfigMachineType))
                {
                    var prot = Form1.file_.MachineTypes.Where(p => p.Name == curItem).FirstOrDefault();
                    if (prot == null)
                        return;
                    prot.Name = inputTxt.Value;
                    List[index] = inputTxt.Value;
                    listBox1.Items[listBox1.SelectedIndex] = inputTxt.Value;
                }
            }
        }

        private void btt_remove_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem?.ToString();
            if (curItem == null)
                return;
            if (TypeList == typeof(FileConfigProtocol))
            {
                var res = Form1.file_.RemoveProtocol(curItem);
                if (!res)
                    return;
                List.Remove(curItem);
                listBox1.Items.Remove(curItem);
            }
            else if (TypeList == typeof(FileConfigGroup))
            {
                var res = Form1.file_.RemoveGroup(curItem);
                if (!res)
                    return;
                List.Remove(curItem);
                listBox1.Items.Remove(curItem);
            }
            else if (TypeList == typeof(FileConfigMachineType))
            {
                var res = Form1.file_.RemoveMachineType(curItem);
                if (!res)
                    return;
                List.Remove(curItem);
                listBox1.Items.Remove(curItem);
            }
        }

        private void btt_add_Click(object sender, EventArgs e)
        {
            var frm = new inputTxt();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (TypeList == typeof(FileConfigProtocol))
                {
                    Form1.file_.AddProtocol(frm.Value);
                }
                else if (TypeList == typeof(FileConfigGroup))
                {
                    Form1.file_.AddGroup(frm.Value);
                }
                else if (TypeList == typeof(FileConfigMachineType))
                {
                    Form1.file_.AddMachineType(frm.Value);
                }
            }
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

    }
}
