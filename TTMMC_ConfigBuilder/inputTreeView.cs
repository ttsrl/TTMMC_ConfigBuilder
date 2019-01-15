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
    public partial class inputTreeView : Form
    {

        private string _nmEditLbl;
        public Dictionary<string, List<DataAddressItem>> datasAddressToRead = new Dictionary<string, List<DataAddressItem>>();

        public inputTreeView()
        {
            InitializeComponent();
        }

        private void editTreeView_Load(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            var nodes = new List<TreeNode>();
            foreach (var it in datasAddressToRead)
            {
                var snodes = new List<TreeNode>();
                var c = 0;
                foreach (var dataIt in it.Value)
                {
                    var subnodes = new List<TreeNode>();
                    subnodes.Add(new TreeNode("Address: " + dataIt.Address));
                    subnodes.Add(new TreeNode("Description: " + dataIt.Description));
                    subnodes.Add(new TreeNode("DataType: " + dataIt.DataType.ToUpper()));
                    var node = new TreeNode(c.ToString(), subnodes.ToArray());
                    snodes.Add(node);
                    c++;
                }
                var nodeg = new TreeNode(it.Key, snodes.ToArray());
                nodes.Add(nodeg);
            }
            treeView1.Nodes.AddRange(nodes.ToArray());
            foreach (TreeNode tn in treeView1.Nodes)
            {
                if (tn.Level == 0)
                {
                    tn.Expand();
                }
            }
            treeView1.EndUpdate();
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var elm = e.Node;
            if (elm is TreeNode && !string.IsNullOrEmpty(e.Label))
            {
                if (elm.Level == 0)
                {
                    var exist = datasAddressToRead.ContainsKey(_nmEditLbl);
                    if (exist)
                    {
                        var it = datasAddressToRead[_nmEditLbl];
                        datasAddressToRead.Remove(_nmEditLbl);
                        datasAddressToRead.Add(e.Label, it);
                    }
                    else
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("Impossibile rinominare l' elemento", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var elm = ((TreeView)sender).SelectedNode;
            if (elm is TreeNode)
            {
                if (elm.Level == 1 || elm.Level == 2)
                {
                    e.CancelEdit = true;
                }
                else if (elm.Level == 0)
                {
                    _nmEditLbl = elm.Text;
                }
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var elm = e.Node;
            if (elm is TreeNode)
            {
                if (elm.Level == 0)
                {
                    var exist = datasAddressToRead.ContainsKey(elm.Text);
                    if (exist)
                    {
                        var frm = new inputTxt();
                        frm.LblTxt = "Nome:";
                        frm.Value = elm.Text;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            var it = datasAddressToRead[elm.Text];
                            datasAddressToRead.Remove(elm.Text);
                            datasAddressToRead.Add(frm.Value, it);
                            elm.Text = frm.Value;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Impossibile trovare l' elemento selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (elm.Level == 2)
                {
                    var exist = datasAddressToRead.ContainsKey(elm.Parent.Parent.Text);
                    if (exist)
                    {
                        var item = datasAddressToRead[elm.Parent.Parent.Text][int.Parse(elm.Parent.Text)];
                        var indx = elm.Parent.Nodes.IndexOf(elm);
                        if (indx == 0 || indx == 1)
                        {
                            var frm = new inputTxt();
                            frm.LblTxt = (indx == 0) ? "Indirizzo:" : "Descrizione:";
                            frm.Value = (indx == 0) ? item.Address : item.Description;
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                if (indx == 0)
                                {
                                    item.Address = frm.Value;
                                    elm.Text = "Address: " + frm.Value;
                                }
                                else
                                {
                                    item.Description = frm.Value;
                                    elm.Text = "Description: " + frm.Value;
                                }
                            }
                        }
                        else
                        {
                            var frm = new inputSelect();
                            frm.LblTxt = "Tipo:";
                            frm.Value = item.DataType.ToUpper();
                            frm.List = Enum.GetValues(typeof(DataTypes)).Cast<DataTypes>().Select(v => v.ToString()).ToList();
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                item.DataType = frm.Value;
                                elm.Text = "DataType: " + frm.Value;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Impossibile trovare l' elemento selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new inputTxt();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var nm = frm.Value;
                var exist = datasAddressToRead.ContainsKey(nm);
                if (!exist)
                {
                    var node = treeView1.Nodes.Add(frm.Value);
                    treeView1.SelectedNode = node;
                    datasAddressToRead.Add(nm, new List<DataAddressItem>());
                    button5_Click(sender, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Nome elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        datasAddressToRead.Remove(subitem.Parent.Text);
                        treeView1.Nodes.Remove(subitem.Parent);
                    }
                    else
                    {
                        var subItPar = subitem.Parent;
                        var it = datasAddressToRead[subItPar.Text];
                        it.RemoveAt(int.Parse(subitem.Text));
                        treeView1.Nodes.Remove(subitem);
                        //rename
                        for (var i = 0; i < subItPar.Nodes.Count; i++)
                        {
                            subItPar.Nodes[i].Text = i.ToString();
                        }
                    }
                }
                else //lvl 0
                {
                    datasAddressToRead.Remove(node.Text);
                    treeView1.Nodes.Remove(node);
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
                        node.Nodes[index].Nodes.Add("Address: " + frm.Address);
                        node.Nodes[index].Nodes[0].ToolTipText = frm.Address;
                        node.Nodes[index].Nodes.Add("Description: " + frm.Description);
                        node.Nodes[index].Nodes[1].ToolTipText = frm.Description;
                        node.Nodes[index].Nodes.Add("DataType: " + frm.DataType);
                        node.Nodes[index].Nodes[2].ToolTipText = frm.DataType;
                        treeView1.EndUpdate();
                        var itemList = datasAddressToRead[node.Text];
                        itemList.Add(new DataAddressItem(frm.Address, frm.Description, (DataTypes)(Enum.Parse(typeof(DataTypes), frm.DataType))));
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            object obj = treeView1.SelectedNode;
            if (obj != null)
            {
                treeView1_NodeMouseDoubleClick(obj, new TreeNodeMouseClickEventArgs(treeView1.SelectedNode, MouseButtons.Left, 2, 1, 1));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
