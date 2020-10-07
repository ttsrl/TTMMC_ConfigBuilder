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
        public bool DataRead { get; set; }
        public List<DataGroup> datas = new List<DataGroup>();

        public inputTreeView()
        {
            InitializeComponent();
        }

        private void editTreeView_Load(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            var nodes = new List<TreeNode>();
            foreach (var it in datas)
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
                    subnodes.Add(new TreeNode("IsReferenceKey: " + dataIt.IsReferenceKey.ToString()));
                    subnodes.Add(new TreeNode("IsFinishKey: " + dataIt.IsFinishKey.ToString()));
                    subnodes.Add(new TreeNode("Ignore: " + dataIt.Ignore.ToString()));
                    var node = new TreeNode(c.ToString(), subnodes.ToArray());
                    node.ForeColor = defineColor(dataIt);
                    snodes.Add(node);
                    c++;
                }
                var nodeg = new TreeNode(it.Name, snodes.ToArray());
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

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            e.CancelEdit = true;
            var elm = e.Node;
            if (elm is TreeNode && !string.IsNullOrEmpty(e.Label))
            {
                if (elm.Level == 0)
                {
                    var existOld = datas.ContainsDataGroup(_nmEditLbl);
                    if (existOld)
                    {
                        var existk = datas.ContainsDataGroup(e.Label);
                        var index = treeView1.Nodes.IndexOf(elm);
                        if (!existk || datas.ElementAt(index).Name == e.Label)
                        {
                            var it = existOld ? datas.GetDataGroup(_nmEditLbl) : null;
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
                if (elm.Level == 0)
                {
                    var existOld = datas.ContainsDataGroup(elm.Text);
                    if (existOld)
                    {
                        var frm = new inputTxt();
                        frm.Value = elm.Text;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            var it = existOld ? datas.GetDataGroup(elm.Text) : null;
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
                else if (elm.Level == 2)
                {
                    var exist = datas.ContainsDataGroup(elm.Parent.Parent.Text);
                    if (exist)
                    {
                        var item = datas.GetDataGroup(elm.Parent.Parent.Text).Items[int.Parse(elm.Parent.Text)];
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
                            bool inv = !item.IsReferenceKey;
                            item.IsReferenceKey = inv;
                            elm.Text = "IsReferenceKey: " + item.IsReferenceKey.ToString();
                        }
                        else if (indx == 5)
                        {
                            bool inv = !item.IsFinishKey;
                            item.IsFinishKey = inv;
                            elm.Text = "IsKeyFinish: " + item.IsFinishKey.ToString();
                        }
                        else if (indx == 6)
                        {
                            bool inv = !item.Ignore;
                            item.Ignore = inv;
                            elm.Text = "Ignore: " + item.Ignore.ToString();
                        }
                        elm.Parent.ForeColor = defineColor(item);
                    }
                    else
                        MessageBox.Show("Impossibile trovare l' elemento selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void addGroup_Click(object sender, EventArgs e)
        {
            var frm = new inputTxt();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var exist = datas.ContainsDataGroup(frm.Value);
                if (!exist)
                {
                    var node = treeView1.Nodes.Add(frm.Value);
                    treeView1.SelectedNode = node;
                    datas.Add(new DataGroup { Name = frm.Value });
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
                if (node.Level == 0)
                {
                    var frm = new inputDataItem();
                    frm.DataRead = this.DataRead;
                    frm.ReferenceKeyAlreadyPresent = datas.GetReferenceKey() != null;
                    frm.FinishKeyAlreadyPresent = datas.GetFinishKey() != null;
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
                        node.Nodes[index].Nodes.Add("IsReferenceKey: " + frm.IsReferenceKey);
                        node.Nodes[index].Nodes[4].ToolTipText = frm.IsReferenceKey.ToString();
                        node.Nodes[index].Nodes.Add("IsFinishKey: " + frm.IsFinishKey);
                        node.Nodes[index].Nodes[5].ToolTipText = frm.IsFinishKey.ToString();
                        node.Nodes[index].Nodes.Add("Ignore: " + frm.Ignore);
                        node.Nodes[index].Nodes[6].ToolTipText = frm.Ignore.ToString();
                        treeView1.EndUpdate();
                        var itemList = datas.GetDataGroup(node.Text);
                        var di = new DataItem(frm.Address, frm.Format, frm.Description);
                        di.Ignore = frm.Ignore;
                        if (frm.IsReferenceKey)
                        {
                            datas.ClearReferenceKey();
                            di.IsFinishKey = frm.IsReferenceKey;
                        }
                        if (frm.IsFinishKey)
                        {
                            datas.ClearFinishKey();
                            di.IsFinishKey = frm.IsFinishKey;
                        }
                        itemList.Items.Add(di);
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
                if (lvl == 2 | lvl == 1)
                {
                    var subitem = (lvl == 2) ? node.Parent : node;
                    if (subitem.Parent.Nodes.Count == 1)
                    {
                        datas.RemoveDataGroup(subitem.Parent.Text);
                        treeView1.Nodes.Remove(subitem.Parent);
                    }
                    else
                    {
                        var subItPar = subitem.Parent;
                        var it = datas.GetDataGroup(subItPar.Text);
                        it.Items.RemoveAt(int.Parse(subitem.Text));
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
                    var res = datas.RemoveDataGroup(node.Text);
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
            if (item.Ignore)
                return Color.Red;
            if (item.IsReferenceKey)
                return Color.Blue;
            if (item.IsFinishKey)
                return Color.Green;
            return Color.Black;
        }

    }
}
