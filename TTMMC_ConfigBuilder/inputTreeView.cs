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
        public bool Read { get; set; }
        public Dictionary<string, List<DataAddressItem>> datasAddress = new Dictionary<string, List<DataAddressItem>>();
        public FileConfigMachine Machine { get; set; }

        public inputTreeView()
        {
            InitializeComponent();
        }

        private void editTreeView_Load(object sender, EventArgs e)
        {
            treeView1.BeginUpdate();
            var nodes = new List<TreeNode>();
            foreach (var it in datasAddress)
            {
                var snodes = new List<TreeNode>();
                var c = 0;
                foreach (var dataIt in it.Value)
                {
                    var subnodes = new List<TreeNode>();
                    subnodes.Add(new TreeNode("Address: " + dataIt.Address));
                    subnodes.Add(new TreeNode("Description: " + dataIt.Description));
                    subnodes.Add(new TreeNode("DataType: " + dataIt.DataType.ToUpper()));
                    subnodes.Add(new TreeNode("Scaling: " + dataIt.Scaling.ToString()));
                    var node = new TreeNode(c.ToString(), subnodes.ToArray());
                    snodes.Add(node);
                    c++;
                }
                var isNotMapped = (it.Key.Substring(0, 1) == "[" && it.Key.Substring(it.Key.Length - 1, 1) == "]");
                var nodeg = new TreeNode(it.Key.Replace("[", "").Replace("]", ""), snodes.ToArray());
                nodeg.ForeColor = (isNotMapped) ? Color.Red : defineColor(Machine, it.Key);
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
                    var existOld = datasAddress.ContainsKey(_nmEditLbl);
                    var existOldNM = datasAddress.ContainsKey("[" + _nmEditLbl + "]");
                    if (existOld || existOldNM)
                    {
                        var existk = datasAddress.ContainsKey(e.Label) || datasAddress.ContainsKey("[" + e.Label + "]");
                        var index = treeView1.Nodes.IndexOf(elm);
                        if (!existk || datasAddress.ElementAt(index).Key == e.Label || datasAddress.ElementAt(index).Key == "[" + e.Label + "]")
                        {
                            var it = existOld ? datasAddress[_nmEditLbl] : (existOldNM ? datasAddress["[" + _nmEditLbl + "]"] : null);
                            datasAddress.Remove(_nmEditLbl);
                            datasAddress.Remove("[" + _nmEditLbl + "]");
                            var nmK = existOld ? e.Label : "[" + e.Label + "]";
                            datasAddress.Add(nmK, it);
                            elm.Text = e.Label;
                        }
                        else
                        {
                            MessageBox.Show("Nome elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Oggetto non trovato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
                    var existOld = datasAddress.ContainsKey(elm.Text);
                    var existOldNM = datasAddress.ContainsKey("[" + elm.Text + "]");
                    if (existOld || existOldNM)
                    {
                        var frm = new inputKey();
                        frm.Read = Read;
                        var listAttr = new List<inputKey.KeyAttribute>();
                        if (Read && Machine.ReferenceKeyRead == elm.Text)
                        {
                            listAttr.Add(inputKey.KeyAttribute.ReferenceKey);
                        }
                        if (Machine.FinishKeyRead == elm.Text || Machine.FinishKeyWrite == elm.Text)
                        {
                            listAttr.Add(inputKey.KeyAttribute.FinishKey);
                        }
                        if (existOldNM)
                        {
                            listAttr.Add(inputKey.KeyAttribute.NotMapped);
                        }
                        
                        frm.Attributes = listAttr;
                        frm.Value = elm.Text;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            var it = existOld ? datasAddress[elm.Text] : (existOldNM ? datasAddress["[" + elm.Text + "]"] : null);
                            datasAddress.Remove(elm.Text);
                            datasAddress.Remove("[" + elm.Text + "]");
                            var nmK = (frm.Attributes.Contains(inputKey.KeyAttribute.NotMapped)) ? "[" + frm.Value + "]" : frm.Value;
                            datasAddress.Add(nmK, it);
                            if (Read)
                            {
                                setRefKey(frm.Attributes.Contains(inputKey.KeyAttribute.ReferenceKey), frm.Value);
                                setFinKeyR(frm.Attributes.Contains(inputKey.KeyAttribute.FinishKey), frm.Value);
                            }
                            else
                            {
                                setFinKeyW(frm.Attributes.Contains(inputKey.KeyAttribute.FinishKey), frm.Value);
                            }
                            elm.Text = frm.Value;
                            elm.ForeColor = (frm.Attributes.Contains(inputKey.KeyAttribute.NotMapped)) ? Color.Red : defineColor(Machine, frm.Value);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Impossibile trovare l' elemento selezionato", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (elm.Level == 2)
                {
                    var exist = datasAddress.ContainsKey(elm.Parent.Parent.Text);
                    if (exist)
                    {
                        var item = datasAddress[elm.Parent.Parent.Text][int.Parse(elm.Parent.Text)];
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
                        else if(indx == 2)
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
                        else
                        {
                            var options = new List<string> { "Nessuna", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
                            var frm = new inputSelect();
                            frm.LblTxt = "Scalatura:";
                            frm.Value = (item.Scaling == 0) ? "Nessuna" : item.Scaling.ToString();
                            frm.List = options;
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                item.Scaling = options.IndexOf(frm.Value);
                                elm.Text = "Scaling: " + frm.Value;
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


        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new inputKey();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!frm.Value.Contains("[") && !frm.Value.Contains("]"))
                {
                    var exist = datasAddress.ContainsKey(frm.Value) || datasAddress.ContainsKey("[" + frm.Value + "]");
                    if (!exist)
                    {
                        var node = treeView1.Nodes.Add(frm.Value);
                        treeView1.SelectedNode = node;
                        var nm = (frm.Attributes.Contains(inputKey.KeyAttribute.NotMapped)) ? "[" + frm.Value + "]" : frm.Value;
                        datasAddress.Add(nm, new List<DataAddressItem>());
                        if (Read)
                        {
                            setRefKey(frm.Attributes.Contains(inputKey.KeyAttribute.ReferenceKey), frm.Value);
                            setFinKeyR(frm.Attributes.Contains(inputKey.KeyAttribute.FinishKey), frm.Value);
                        }
                        else
                        {
                            setFinKeyW(frm.Attributes.Contains(inputKey.KeyAttribute.FinishKey), frm.Value);
                        }
                        node.ForeColor = (frm.Attributes.Contains(inputKey.KeyAttribute.NotMapped)) ? Color.Red : defineColor(Machine, frm.Value);
                        button5_Click(sender, new EventArgs());
                    }
                    else
                    {
                        MessageBox.Show("Nome elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Nome della key non valido", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        datasAddress.Remove(subitem.Parent.Text);
                        treeView1.Nodes.Remove(subitem.Parent);
                        if (Read)
                        {
                            Machine.ReferenceKeyRead = (Machine.ReferenceKeyRead == subitem.Parent.Text) ? "" : Machine.ReferenceKeyRead;
                            Machine.FinishKeyRead = (Machine.FinishKeyRead == subitem.Parent.Text) ? "" : Machine.FinishKeyRead;
                        }
                        else
                        {
                            Machine.FinishKeyWrite = (Machine.FinishKeyWrite == subitem.Parent.Text) ? "" : Machine.FinishKeyWrite;
                        }
                    }
                    else
                    {
                        var subItPar = subitem.Parent;
                        var it = datasAddress[subItPar.Text];
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
                    var res = datasAddress.Remove(node.Text);
                    var res1 = datasAddress.Remove("[" + node.Text + "]");
                    if (res || res1)
                    {
                        treeView1.Nodes.Remove(node);
                        if (Read)
                        {
                            Machine.ReferenceKeyRead = (Machine.ReferenceKeyRead == node.Text) ? "" : Machine.ReferenceKeyRead;
                            Machine.FinishKeyRead = (Machine.FinishKeyRead == node.Text) ? "" : Machine.FinishKeyRead;
                        }
                        else
                        {
                            Machine.FinishKeyWrite = (Machine.FinishKeyWrite == node.Text) ? "" : Machine.FinishKeyWrite;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Impossibile cancellare questo elemento", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
                        node.Nodes[index].Nodes.Add("Scaling: " + frm.Scaling);
                        node.Nodes[index].Nodes[3].ToolTipText = frm.Scaling.ToString();

                        treeView1.EndUpdate();
                        var itemList = datasAddress[node.Text];
                        itemList.Add(new DataAddressItem(frm.Address, frm.Description, (DataTypes)(Enum.Parse(typeof(DataTypes), frm.DataType)), frm.Scaling));
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private Color defineColor(FileConfigMachine machine, string key)
        {
            if (machine.ReferenceKeyRead == key && (machine.FinishKeyRead == key || machine.FinishKeyWrite == key))
            {
                return Color.Purple;
            }
            else if (machine.ReferenceKeyRead == key && (machine.FinishKeyRead != key || machine.FinishKeyWrite != key))
            {
               return Color.Blue;
            }
            else if (machine.ReferenceKeyRead != key && (machine.FinishKeyRead == key || machine.FinishKeyWrite == key))
            {
                return Color.Green;
            }
            return Color.Black;
        }

        private void setRefKey(bool contains, string value)
        {
            if (contains && Machine.ReferenceKeyRead != value)
            {
                if (string.IsNullOrEmpty(Machine.ReferenceKeyRead))
                {
                    Machine.ReferenceKeyRead = value;
                }
                else
                {
                    if (MessageBox.Show("Reference key già impostata per un'altra proprietà, si desidera sostituirla con questa?", "Avviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var refOld = treeView1.Nodes[Machine.ReferenceKeyRead];
                        if (refOld != null)
                        {
                            refOld.ForeColor = Color.Black;
                        }
                        Machine.ReferenceKeyRead = value;
                    }
                }
            }
            else if (!contains && Machine.ReferenceKeyRead == value)
            {
                Machine.ReferenceKeyRead = "";
            }
        }

        private void setFinKeyR(bool contains, string value)
        {
            if (contains && Machine.FinishKeyRead != value)
            {
                if (string.IsNullOrEmpty(Machine.FinishKeyRead))
                {
                    Machine.FinishKeyRead = value;
                }
                else
                {
                    if (MessageBox.Show("Reference key già impostata per un'altra proprietà, si desidera sostituirla con questa?", "Avviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var refOld = treeView1.Nodes[Machine.FinishKeyRead];
                        if (refOld != null)
                        {
                            refOld.ForeColor = Color.Black;
                        }
                        Machine.FinishKeyRead = value;
                    }
                }
            }
            else if (!contains && Machine.FinishKeyRead == value)
            {
                Machine.FinishKeyRead = "";
            }
        }
        private void setFinKeyW(bool contains, string value)
        {
            if (contains && Machine.FinishKeyWrite != value)
            {
                if (string.IsNullOrEmpty(Machine.FinishKeyWrite))
                {
                    Machine.FinishKeyWrite = value;
                }
                else
                {
                    if (MessageBox.Show("Reference key già impostata per un'altra proprietà, si desidera sostituirla con questa?", "Avviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var refOld = treeView1.Nodes[Machine.FinishKeyWrite];
                        if (refOld != null)
                        {
                            refOld.ForeColor = Color.Black;
                        }
                        Machine.FinishKeyWrite = value;
                    }
                }
            }
            else if (!contains && Machine.FinishKeyWrite == value)
            {
                Machine.FinishKeyWrite = "";
            }
        }
    }
}
