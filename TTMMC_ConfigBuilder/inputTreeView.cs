using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class inputTreeView : Form
    {

        private string _nmEditLbl;
        public List<DataGroup> Datas = new List<DataGroup>();

        public inputTreeView()
        {
            InitializeComponent();
        }

        private void editTreeView_Load(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            //load nodes
            var nodesR = new List<TreeNode>();
            var nodesW = new List<TreeNode>();
            var nodesRW = new List<TreeNode>();
            foreach (var it in Datas)
            {
                var snodes = new List<TreeNode>();
                var c = 0;
                foreach (var dataIt in it.Items)
                {
                    var subnodes = new List<TreeNode>();
                    subnodes.Add(new TreeNode("Address: " + dataIt.Address));
                    subnodes.Add(new TreeNode("Description: " + dataIt.Description));
                    subnodes.Add(new TreeNode("Format: " + dataIt.Format));
                    subnodes.Add(new TreeNode("Unit: " + dataIt.Unit));
                    subnodes.Add(new TreeNode("IgnoreRealtime: " + dataIt.IgnoreRealtime.ToString()));
                    subnodes.Add(new TreeNode("IgnoreInLogs: " + dataIt.IgnoreInLogs.ToString()));
                    var node = new TreeNode(c.ToString(), subnodes.ToArray());
                    node.ForeColor = defineColor(dataIt);
                    snodes.Add(node);
                    c++;
                }
                var nodeg = new TreeNode(it.Name, snodes.ToArray());
                if (it.Mode == DataGroupMode.Read)
                    nodesR.Add(nodeg);
                else if (it.Mode == DataGroupMode.Write)
                    nodesW.Add(nodeg);
                else if (it.Mode == DataGroupMode.ReadAndWrite)
                    nodesRW.Add(nodeg);
                //nodeg.ForeColor = defineColor(it);
            }
            var nodeR = new TreeNode("READ", nodesR.ToArray());
            var nodeW = new TreeNode("WRITE", nodesRW.ToArray());
            var nodeRW = new TreeNode("READ/WRITE", nodesW.ToArray());
            treeView1.Nodes.Add(nodeR);
            treeView1.Nodes.Add(nodeW);
            treeView1.Nodes.Add(nodeRW);
            foreach (TreeNode tn in treeView1.Nodes)
            {
                if (tn.Level == 0)
                {
                    tn.Expand();
                }
            }
            treeView1.EndUpdate();
        }

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var elm = ((TreeView)sender).SelectedNode;
            if (elm is TreeNode)
            {
                if (elm.Level == 2 || elm.Level == 3)
                {
                    e.CancelEdit = true;
                }
                else if (elm.Level == 1)
                {
                    _nmEditLbl = elm.Text;
                }
            }
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.CancelEdit = true;
            var elm = e.Node;
            if (elm is TreeNode && !string.IsNullOrEmpty(e.Label))
            {
                if (elm.Level == 1)
                {
                    var existOld = Datas.ContainsDataGroup(_nmEditLbl);
                    if (existOld)
                    {
                        var existk = Datas.ContainsDataGroup(e.Label);
                        var index = treeView1.Nodes.IndexOf(elm);
                        if (!existk || Datas.ElementAt(index).Name == e.Label)
                        {
                            var it = existOld ? Datas.GetDataGroup(_nmEditLbl) : null;
                            if(it != null)
                            {
                                it.Name = e.Label;
                                elm.Text = e.Label;
                            }
                        }
                        else
                            MessageBox.Show("Nome elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("Oggetto non trovato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var elm = e.Node;
            if (elm is TreeNode)
            {
                if (elm.Level == 1)
                {
                    var existOld = Datas.ContainsDataGroup(elm.Text);
                    if (existOld)
                    {
                        var frm = new inputTxt();
                        frm.Value = elm.Text;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            var it = existOld ? Datas.GetDataGroup(elm.Text) : null;
                            if (it != null)
                            {
                                it.Name = frm.Value;
                                elm.Text = frm.Value;
                            }
                        }
                    }
                    else
                        MessageBox.Show("Impossibile trovare l' elemento selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (elm.Level == 3)
                {
                    var exist = Datas.ContainsDataGroup(elm.Parent.Parent.Text);
                    if (exist)
                    {
                        var datag = Datas.GetDataGroup(elm.Parent.Parent.Text);
                        var item = datag.Items[int.Parse(elm.Parent.Text)];
                        var indx = elm.Parent.Nodes.IndexOf(elm);
                        if (indx == 0)
                        {
                            var frm = new inputTxt();
                            frm.LblTxt = "Address:";
                            frm.Value = item.Address;
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                item.Address = frm.Value;
                                elm.Text = "Address: " + item.Address;
                            }
                        }
                        else if (indx == 1)
                        {
                            var frm = new inputTxt();
                            frm.LblTxt = "Description:";
                            frm.Value = item.Description;
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                item.Description = frm.Value;
                                elm.Text = "Description: " + item.Description;
                            }
                        }
                        else if (indx == 2)
                        {
                            var frm = new inputDataItemFormat();
                            frm.Format = item.Format;
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                item.Format = frm.Format;
                                elm.Text = "Format: " + item.Format;
                            }
                        }
                        else if (indx == 3)
                        {
                            var frm = new inputTxt();
                            frm.LblTxt = "Unit:";
                            frm.Value = item.Unit;
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                item.Unit = frm.Value;
                                elm.Text = "Unit: " + item.Unit;
                            }
                        }
                        else if (indx == 4)
                        {
                            var frm = new inputSelect();
                            frm.List = Enum.GetNames(typeof(DataType)).ToList();
                            frm.LblTxt = "Type:";
                            frm.Value = Enum.GetName(typeof(DataType), item.Type);
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                item.Type = (DataType)Enum.Parse(typeof(DataType), frm.Value);
                                elm.Text = "Type: " + item.Unit;
                            }
                        }
                        else if (indx == 5)
                        {
                            bool inv = !item.IgnoreRealtime;
                            item.IgnoreRealtime = inv;
                            elm.Text = "IgnoreRealtime: " + item.IgnoreRealtime.ToString();
                        }
                        else if (indx == 6)
                        {
                            bool inv = !item.IgnoreInLogs;
                            item.IgnoreInLogs = inv;
                            elm.Text = "IgnoreInLogs: " + item.IgnoreInLogs.ToString();
                        }
                        elm.Parent.Parent.ForeColor = defineColor(item);
                    }
                    else
                        MessageBox.Show("Impossibile trovare l' elemento selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void addGroup_Click(object sender, EventArgs e)
        {
            treeView1.SelectedNode = null;
            var frm = new inputGroup();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var exist = Datas.ContainsDataGroup(frm.GroupName);
                if (!exist)
                {
                    var nodeM = (frm.Mode == DataGroupMode.Read) ? treeView1.Nodes[0] : ((frm.Mode == DataGroupMode.Write) ? treeView1.Nodes[1] : treeView1.Nodes[2]);
                    var node = nodeM.Nodes.Add(frm.GroupName);
                    treeView1.SelectedNode = node;
                    Datas.Add(new DataGroup { Name = frm.GroupName, Mode = frm.Mode });
                    addData_Click(sender, new EventArgs());
                }
                else
                    MessageBox.Show("Nome elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void addData_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node != null)
            {
                if (node.Level == 1)
                {
                    var group = Datas.GetDataGroup(node.Text);
                    var frm = new inputDataItem();
                    frm.DataRead = group.Mode == DataGroupMode.Read || group.Mode == DataGroupMode.ReadAndWrite;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        treeView1.BeginUpdate();
                        var index = node.Nodes.Count;
                        node.Nodes.Add(index.ToString());
                        node.Nodes[index].Nodes.Add("Address: " + frm.Address);
                        node.Nodes[index].Nodes[0].ToolTipText = frm.Address;
                        node.Nodes[index].Nodes.Add("Description: " + frm.Description);
                        node.Nodes[index].Nodes[1].ToolTipText = frm.Description;
                        node.Nodes[index].Nodes.Add("Format: " + frm.Format);
                        node.Nodes[index].Nodes[2].ToolTipText = frm.Format;
                        node.Nodes[index].Nodes.Add("Unit: " + frm.Unit);
                        node.Nodes[index].Nodes[3].ToolTipText = frm.Unit;
                        node.Nodes[index].Nodes.Add("Type: " + frm.Type);
                        node.Nodes[index].Nodes[4].ToolTipText = frm.Type;
                        node.Nodes[index].Nodes.Add("IgnoreRealtime: " + frm.IgnoreRealtime);
                        node.Nodes[index].Nodes[5].ToolTipText = frm.IgnoreRealtime.ToString();
                        node.Nodes[index].Nodes.Add("IgnoreInLogs: " + frm.IgnoreInLogs);
                        node.Nodes[index].Nodes[6].ToolTipText = frm.IgnoreInLogs.ToString();
                        treeView1.EndUpdate();
                        var di = new DataItem(frm.Address, frm.Format, frm.Description);
                        di.Type = (DataType)Enum.Parse(typeof(DataType), frm.Type);
                        di.IgnoreRealtime = frm.IgnoreRealtime;
                        di.IgnoreInLogs = frm.IgnoreInLogs;
                        group.Items.Add(di);
                        node.Nodes[index].ForeColor = defineColor(di);
                        //node.Nodes[index].Parent.ForeColor = defineColor(group);
                    }
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node != null)
            {
                var lvl = node.Level;
                if (lvl == 3 || lvl == 2)
                {
                    var subitem = (lvl == 3) ? node.Parent : node;
                    if (subitem.Parent.Nodes.Count == 1)
                    {
                        Datas.RemoveDataGroup(subitem.Parent.Text);
                        treeView1.Nodes.Remove(subitem.Parent);
                    }
                    else
                    {
                        var subItPar = subitem.Parent;
                        var it = Datas.GetDataGroup(subItPar.Text);
                        it.Items.RemoveAt(int.Parse(subitem.Text));
                        treeView1.Nodes.Remove(subitem);
                        //rename
                        for (var i = 0; i < subItPar.Nodes.Count; i++)
                        {
                            subItPar.Nodes[i].Text = i.ToString();
                        }
                    }
                }
                else if (lvl == 1)
                {
                    var res = Datas.RemoveDataGroup(node.Text);
                    if (res)
                        treeView1.Nodes.Remove(node);
                    else
                        MessageBox.Show("Impossibile cancellare questo elemento", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            object obj = treeView1.SelectedNode;
            if (obj != null)
                treeView1_NodeMouseDoubleClick(obj, new TreeNodeMouseClickEventArgs(treeView1.SelectedNode, MouseButtons.Left, 2, 1, 1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private Color defineColor(DataItem item)
        {
            if (item.IgnoreInLogs)
                return Color.Red;
            if (item.IgnoreRealtime)
                return Color.Orange;
            return Color.Black;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = treeView1.SelectedNode;
            if(node != null)
            {
                var lvl = node.Level;
                if(lvl == 1)
                    addData.Enabled = true;
                else
                    addData.Enabled = false;

                if (lvl == 1 || lvl == 3)
                    edit.Enabled = true;
                else
                    edit.Enabled = false;

                if (lvl == 1 || lvl == 2 || lvl == 3)
                    delete.Enabled = true;
                else
                    delete.Enabled = false;
            }
        }
    }
}
