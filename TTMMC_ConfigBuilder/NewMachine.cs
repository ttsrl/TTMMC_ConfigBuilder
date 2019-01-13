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
    public partial class NewMachine : Form
    {
        public string MachineName;
        public string Description;
        public FileConfigMachineType Type;
        public FileConfigProtocol Protocol;
        public string Address;
        public string Port;
        public string Image;
        public Dictionary<string, List<DataAddressToReadItem>> DatasAddressToRead;

        public NewMachine()
        {
            InitializeComponent();
        }

        private void NewMachine_Load(object sender, EventArgs e)
        {
            foreach (var t in Form1.file_.MachineTypes)
            {
                comboBox1.Items.Add(t.Name);
            }

            foreach (var p in Form1.file_.Protocols)
            {
                comboBox2.Items.Add(p.Name);
            }

            DatasAddressToRead = new Dictionary<string, List<DataAddressToReadItem>>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && comboBox2.Text != "")
            {
                MachineName = textBox1.Text;
                Description = textBox2.Text;
                Type = Form1.file_.GetMachineType(comboBox1.SelectedItem.ToString());
                Protocol = Form1.file_.GetProtocol(comboBox2.SelectedItem.ToString());
                Address = textBox3.Text;
                Port = textBox4.Text;
                Image = (textBox5.Text == "") ? null : textBox5.Text;
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

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new name();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var nm = frm.NameTxt;
                var exist = DatasAddressToRead.ContainsKey(nm);
                if (!exist)
                {
                    var node = treeView1.Nodes.Add(frm.NameTxt);
                    treeView1.SelectedNode = node;
                    DatasAddressToRead.Add(nm, new List<DataAddressToReadItem>());
                    button5_Click(sender, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Nome elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node != null)
            {
                if (node.Level == 0)
                {
                    var frm = new NewMachineDataItem();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        treeView1.BeginUpdate();
                        var index = node.Nodes.Count;
                        node.Nodes.Add(index.ToString());
                        node.Nodes[index].Nodes.Add("Description: " + frm.Description);
                        node.Nodes[index].Nodes[0].ToolTipText = frm.Description;
                        node.Nodes[index].Nodes.Add("Address: " + frm.Address);
                        node.Nodes[index].Nodes[1].ToolTipText = frm.Address;
                        treeView1.EndUpdate();
                        var itemList = DatasAddressToRead[node.Text];
                        itemList.Add(new DataAddressToReadItem { Address = frm.Address, Description = frm.Description });
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node != null)
            {
                var lvl = node.Level;
                if (lvl == 2 | lvl == 1)
                {
                    var subitem = (lvl == 2) ? node.Parent : node;
                    if (subitem.Parent.Nodes.Count == 1)
                    {
                        DatasAddressToRead.Remove(subitem.Parent.Text);
                        treeView1.Nodes.Remove(subitem.Parent);
                    }
                    else
                    {
                        var subItPar = subitem.Parent;
                        var it = DatasAddressToRead[subItPar.Text];
                        it.RemoveAt(int.Parse(subitem.Text));
                        treeView1.Nodes.Remove(subitem);
                        //rename
                        for(var i = 0; i < subItPar.Nodes.Count; i++)
                        {
                            subItPar.Nodes[i].Text = i.ToString();
                        }
                    }
                }
                else //lvl 0
                {
                    DatasAddressToRead.Remove(node.Text);
                    treeView1.Nodes.Remove(node);
                }
            }
        }
    }
}
