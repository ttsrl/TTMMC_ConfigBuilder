using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class editVPN : Form
    {
        public List<string> Objects { get; set; }
        public List<VpnItem> List { get; set; }

        public editVPN()
        {
            InitializeComponent();
        }

        private void inputVPN_Load(object sender, EventArgs e)
        {
            if (List != null && List.Count > 0)
                reloadList();
            else
                List = new List<VpnItem>();
        }

        private void btt_ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btt_add_Click(object sender, EventArgs e)
        {
            var frm = new inputVPN();
            if (Objects != null && Objects.Count > 0)
            {
                var cl = Objects.Clone().ToList();
                foreach (var it in List.Select(l => l.ReferenceName))
                {
                    cl.Remove(it);
                }
                frm.Items = cl;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                List.Add(new VpnItem(frm.ReferenceName, frm.Value));
                reloadList();
            }
        }

        private void btt_edit_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                var listIt = List.Where(i => i.ReferenceName == item.ToString()).FirstOrDefault();
                var frm = new inputTxt();
                frm.LblTxt = "Value: ";
                frm.Value = listIt.Ip;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (listIt != null)
                        listIt.Ip = frm.Value;
                }
            }
        }

        private void btt_delete_Click(object sender, EventArgs e)
        {
            var item = listBox1.SelectedItem;
            if (item != null)
            {
                var listIt = List.Where(i => i.ReferenceName == item.ToString()).FirstOrDefault();
                if (listIt != null)
                {
                    List.Remove(listIt);
                    reloadList();
                }
            }
        }

        private void reloadList()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(List.Select(it => it.ReferenceName).ToArray());
        }

    }
}
