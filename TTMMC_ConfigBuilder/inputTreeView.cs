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
            treeviewLoad();
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
                    var exist = Datas.ContainsDataGroup(_nmEditLbl);
                    if (exist)
                    {
                        var it = Datas.GetDataGroup(_nmEditLbl);
                        it.Name = e.Label;
                        elm.Text = e.Label;
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
                    var it = Datas.GetDataGroup(elm.Text);
                    if (it != null)
                    {
                        var frm = new inputTxt();
                        frm.Value = elm.Text;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            it.Name = frm.Value;
                            elm.Text = frm.Value;
                        }
                    }
                    else
                        MessageBox.Show("Oggetto non trovato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                                elm.Text = "Type: " + item.Type;
                            }
                        }
                        else if (indx == 5)
                        {
                            bool inv = !item.Realtime;
                            item.Realtime = inv;
                            elm.Text = "Realtime: " + item.Realtime.ToString();
                        }
                        else if (indx == 6)
                        {
                            bool inv = !item.Logs;
                            item.Logs = inv;
                            elm.Text = "Logs: " + item.Logs.ToString();
                        }
                    }
                    else
                        MessageBox.Show("Impossibile trovare l' elemento selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node != null)
            {
                var lvl = node.Level;
                if (lvl == 1)
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

                if (lvl == 0 || lvl == 1 || lvl == 2)
                    copy.Enabled = true;
                else
                    copy.Enabled = false;

                if (lvl == 1 || lvl == 2)
                {
                    moveUp.Enabled = true;
                    moveDown.Enabled = true;
                }
                else
                {
                    moveUp.Enabled = false;
                    moveDown.Enabled = false;
                }
            }
            else
            {
                edit.Enabled = false;
                delete.Enabled = false;
                copy.Enabled = false;
                moveUp.Enabled = false;
                moveDown.Enabled = false;
            }
        }

        private void treeView1_KeyUp(object sender, KeyEventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node != null)
            {
                if (e.KeyCode == Keys.Delete)
                    delete_Click(sender, new EventArgs());
            }
        }

        private void addGroup_Click(object sender, EventArgs e)
        {
            TreeNode modeNode = null;
            if (treeView1.SelectedNode != null)
            {
                modeNode = treeView1.SelectedNode;
                while (modeNode.Level > 0)
                {
                    modeNode = modeNode.Parent;
                }
            }
            treeView1.SelectedNode = null;
            var frm = new inputGroup();
            if(modeNode != null)
                frm.Mode = (modeNode.Text == "READ") ? DataGroupMode.Read : ((modeNode.Text == "WRITE") ? DataGroupMode.Write : DataGroupMode.ReadAndWrite);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var nodeM = (frm.Mode == DataGroupMode.Read) ? treeView1.Nodes[0] : ((frm.Mode == DataGroupMode.Write) ? treeView1.Nodes[1] : treeView1.Nodes[2]);
                var node = nodeM.Nodes.Add(frm.GroupName);
                treeView1.SelectedNode = node;
                Datas.Add(new DataGroup { Name = frm.GroupName, Mode = frm.Mode });
                addData_Click(sender, new EventArgs());
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
                    frm.DataMode = group.Mode;
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
                        node.Nodes[index].Nodes.Add("Realtime: " + frm.Realtime);
                        node.Nodes[index].Nodes[5].ToolTipText = frm.Realtime.ToString();
                        node.Nodes[index].Nodes.Add("Logs: " + frm.Logs);
                        node.Nodes[index].Nodes[6].ToolTipText = frm.Logs.ToString();
                        treeView1.EndUpdate();
                        var di = new DataItem(frm.Address, frm.Format, frm.Description);
                        di.Unit = frm.Unit;
                        di.Type = (DataType)Enum.Parse(typeof(DataType), frm.Type);
                        di.Realtime = frm.Realtime;
                        di.Logs = frm.Logs;
                        group.Items.Add(di);
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
                    {
                        var prev = node.GetPreviusNode();
                        treeView1.Nodes.Remove(node);
                        treeView1.SelectedNode = null;
                        Application.DoEvents();
                        treeView1.SelectedNode = prev;
                    }
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

        private void moveGroupUp(DataGroup item)
        {
            if (item == null)
                return;
            var dgsByMode = Datas.Where(g => g.Mode == item.Mode);
            var actTotIndx = Datas.IndexOf(item);
            var befElmtByMode = 0;
            var actIndx = 0;
            foreach(var gr in Datas)
            {
                if(gr.Mode == item.Mode && actIndx < actTotIndx)
                    befElmtByMode = actIndx;
                actIndx ++;
            }
            var saveIt = Datas[actTotIndx];
            Datas.RemoveAt(actTotIndx);
            Datas.Insert(befElmtByMode, saveIt);
        }

        private void moveGroupDown(DataGroup item)
        {
            if (item == null)
                return;
            var dgsByMode = Datas.Where(g => g.Mode == item.Mode);
            var actTotIndx = Datas.IndexOf(item);
            var befElmtByMode = Datas.Count() - 1;
            var actIndx = 0;
            foreach (var gr in Datas)
            {
                if (gr.Mode == item.Mode && actIndx > actTotIndx)
                    befElmtByMode = actIndx;
                actIndx++;
            }
            var saveIt = Datas[actTotIndx];
            Datas.RemoveAt(actTotIndx);
            Datas.Insert(befElmtByMode, saveIt);
        }

        private void moveItemUp(DataGroup group, int index)
        {
            var newIndex = index + 1;
            if (newIndex > group.Items.Count - 1)
                newIndex = group.Items.Count - 1;
            var saveIt = group.Items[index];
            group.Items.RemoveAt(index);
            group.Items.Insert(newIndex, saveIt);
        }

        private void moveItemDown(DataGroup group, int index)
        {
            var newIndex = index - 1;
            if (newIndex < 0)
                newIndex = 0;
            var saveIt = group.Items[index];
            group.Items.RemoveAt(index);
            group.Items.Insert(newIndex, saveIt);
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node is TreeNode)
            {
                var lvl = node.Level;
                if (lvl == 1)
                {
                    var dg = Datas.GetDataGroup(node.Text) ?? null;
                    if(dg is DataGroup)
                    {
                        moveGroupUp(dg);
                        node.MoveUp();
                    }
                }
                else if (lvl == 2)
                {
                    var dg = Datas.GetDataGroup(node.Parent.Text) ?? null;
                    if (dg is DataGroup)
                    {
                        var index = node.Parent.Nodes.IndexOf(node);
                        moveItemUp(dg, index);
                        node.MoveUp();
                        renameItems(node.Parent);
                    }
                }
            }
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node is TreeNode)
            {
                var lvl = node.Level;
                if (lvl == 1)
                {
                    var dg = Datas.GetDataGroup(node.Text) ?? null;
                    if (dg is DataGroup)
                    {
                        moveGroupDown(dg);
                        node.MoveDown();
                    }
                }
                else if (lvl == 2)
                {
                    var dg = Datas.GetDataGroup(node.Parent.Text) ?? null;
                    if (dg is DataGroup)
                    {
                        var index = node.Parent.Nodes.IndexOf(node);
                        moveItemDown(dg, index);
                        node.MoveDown();
                        renameItems(node.Parent);
                    }
                }
            }
        }

        private void renameItems(TreeNode node)
        {
            if (node is TreeNode)
            {
                var items = node.Nodes;
                var c = 0;
                foreach (TreeNode it in items)
                {
                    it.Text = c.ToString();
                    c++;
                }
            }
        }

        private void copy_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if(node != null)
            {
                if (node.Level > 2)
                    return;
                CopyData cn = new CopyData();
                if (node.Level == 0)
                {
                    cn.Level = 0;
                    var mode = (DataGroupMode)Enum.Parse(typeof(DataGroupMode),node.Text.ToLower().FirstCharToUpper());
                    cn.ListDataGroup = Datas.Where(d => d.Mode == mode).ToList();
                }
                else if (node.Level == 1)
                {
                    cn.Level = 1;
                    cn.DataGroup = Datas.GetDataGroup(node.Text);
                }
                else if (node.Level == 2)
                {
                    cn.Level = 2;
                    var dg = Datas.GetDataGroup(node.Parent.Text);
                    cn.DataGroup = dg;
                    cn.DataItem = dg.Items[Convert.ToInt32(node.Text)];
                    var c = 0;
                }
                Clipboard.Clear();
                Clipboard.SetDataObject(cn);
            }
        }

        private void paste_Click(object sender, EventArgs e)
        {
            var clip = Clipboard.GetDataObject();
            if (clip.GetDataPresent(typeof(CopyData)))
            {
                var copy = (CopyData)clip.GetData(typeof(CopyData));
                if(copy != null)
                {
                    if (copy.Level == 0)
                    {
                        var listDgs = (List<DataGroup>)Convert.ChangeType(copy.ListDataGroup, typeof(List<DataGroup>));
                        foreach (var g in listDgs)
                        {
                            var tmpg = Datas.GetDataGroup(g.Name);
                            if (tmpg == null)
                            {
                                Datas.Add(g);
                                continue;
                            }
                            else
                            {
                                foreach(var it in g.Items)
                                {
                                    var indx = g.Items.IndexOf(it);
                                    var exist = indx < tmpg.Items.Count;
                                    if (exist)
                                    {
                                        if(MessageBox.Show("Sovrascrivere elemento: " + g.Name + "[" + indx.ToString() + "]", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                        {
                                            tmpg.Items.RemoveAt(indx);
                                            tmpg.Items.Insert(indx, it);
                                        }
                                    }
                                    else
                                        tmpg.Items.Add(it);
                                }
                            }
                        }
                    }
                    else if (copy.Level == 1)
                    {
                        var dg = (DataGroup)Convert.ChangeType(copy.DataGroup, typeof(DataGroup));
                        var tmpg = Datas.GetDataGroup(dg.Name);
                        if (tmpg == null)
                            Datas.Add(dg);
                        else
                        {
                            foreach (var it in dg.Items)
                            {
                                var indx = dg.Items.IndexOf(it);
                                var exist = indx < tmpg.Items.Count;
                                if (exist)
                                {
                                    if (MessageBox.Show("Sovrascrivere elemento: " + dg.Name + "[" + indx.ToString() + "]", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        tmpg.Items.RemoveAt(indx);
                                        tmpg.Items.Insert(indx, it);
                                    }
                                }
                                else
                                    tmpg.Items.Add(it);
                            }
                        }
                    }
                    else if (copy.Level == 2)
                    {
                        var dg = (DataGroup)Convert.ChangeType(copy.DataGroup, typeof(DataGroup));
                        var di = (DataItem)Convert.ChangeType(copy.DataItem, typeof(DataItem));
                        var tmpg = Datas.GetDataGroup(dg.Name);
                        if (tmpg == null)
                            Datas.Add(new DataGroup() { Mode = dg.Mode, Name = dg.Name, Items = new List<DataItem>() { di } });
                        else
                        {
                            var indx = dg.Items.IndexOf(di);
                            var exist = indx < tmpg.Items.Count;
                            if (exist)
                            {
                                if (MessageBox.Show("Sovrascrivere elemento: " + dg.Name + "[" + indx.ToString() + "]", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    tmpg.Items.RemoveAt(indx);
                                    tmpg.Items.Insert(indx, di);
                                }
                            }
                            else
                                tmpg.Items.Add(di);
                        }
                    }
                    treeviewLoad();
                }
            }
        }

        private void treeviewLoad()
        {
            treeView1.Nodes.Clear();
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
                    subnodes.Add(new TreeNode("Type: " + dataIt.Type));
                    subnodes.Add(new TreeNode("Realtime: " + dataIt.Realtime.ToString()));
                    subnodes.Add(new TreeNode("Logs: " + dataIt.Logs.ToString()));
                    var node = new TreeNode(c.ToString(), subnodes.ToArray());
                    snodes.Add(node);
                    c++;
                }
                var nodeg = new TreeNode(it.Name, snodes.ToArray());
                if (it.Mode == DataGroupMode.Read)
                    nodesR.Add(nodeg);
                else if (it.Mode == DataGroupMode.Write)
                    nodesW.Add(nodeg);
                else
                    nodesRW.Add(nodeg);
            }
            var nodeR = new TreeNode("READ", nodesR.ToArray());
            var nodeW = new TreeNode("WRITE", nodesW.ToArray());
            var nodeRW = new TreeNode("READ/WRITE", nodesRW.ToArray());
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

    }

    [Serializable]
    public class CopyData
    {
        public int Level { get; set; }
        public List<DataGroup> ListDataGroup { get; set; }
        public DataGroup DataGroup { get; set; }
        public DataItem DataItem { get; set; }
    }
}
