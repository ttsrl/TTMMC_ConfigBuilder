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
        public Dictionary<string, List<DataAddressItem>> datasAddress = new Dictionary<string, List<DataAddressItem>>();
        public bool DatasRead = false;

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
                var isNotmapped = (it.Key.Substring(0, 1) == "[" && it.Key.Substring(it.Key.Length - 1, 1) == "]");
                var isReferenceKey = (it.Key.Substring(0, 1) == "{" && it.Key.Substring(it.Key.Length - 1, 1) == "}");
                var nodeg = new TreeNode(it.Key, snodes.ToArray());
                nodeg.ForeColor = (isNotmapped) ? Color.Red : ((isReferenceKey) ? Color.Blue : Color.Black);
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
                    var exist = datasAddress.ContainsKey(_nmEditLbl);
                    if (exist)
                    {
                        var existk = datasAddress.ContainsKey(e.Label) || datasAddress.ContainsKey("[" + e.Label + "]") || datasAddress.ContainsKey("{" + e.Label + "}");
                        var index = treeView1.Nodes.IndexOf(elm);
                        if (!existk || (datasAddress.ElementAt(index).Key == e.Label || datasAddress.ElementAt(index).Key == "[" + e.Label + "]" || datasAddress.ElementAt(index).Key == "{" + e.Label + "}"))
                        {
                            var isNotmapped = (e.Label.Substring(0, 1) == "[" && e.Label.Substring(e.Label.Length - 1, 1) == "]");
                            var isReferenceKey = (e.Label.Substring(0, 1) == "{" && e.Label.Substring(e.Label.Length - 1, 1) == "}");
                            var val = (!isNotmapped && !isReferenceKey) ? e.Label.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "") : e.Label;
                            var existRef = (isReferenceKey) ? ((datasAddress.Keys.Where(k => k.Contains("{")).Count() > 0) ? true : false) : false;
                            if (!existRef)
                            {
                                elm.ForeColor = (isNotmapped) ? Color.Red : ((isReferenceKey) ? Color.Blue : Color.Black);
                                var it = datasAddress[_nmEditLbl];
                                datasAddress.Remove(_nmEditLbl);
                                datasAddress.Add(val, it);
                                elm.Text = val;
                            }
                            else
                            {
                                MessageBox.Show("Un'altra ReferenceKey è già presente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
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
                    var exist = datasAddress.ContainsKey(elm.Text);
                    if (exist)
                    {
                        var frm = new inputTxt();
                        frm.LblTxt = "Nome:";
                        frm.Value = elm.Text;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {

                            var existk = datasAddress.ContainsKey(frm.Value) || datasAddress.ContainsKey("[" + frm.Value + "]") || datasAddress.ContainsKey("{" + frm.Value + "}");
                            if (!existk && frm.Value != elm.Text)
                            {
                                var isNotmapped = (frm.Value.Substring(0, 1) == "[" && frm.Value.Substring(frm.Value.Length - 1, 1) == "]");
                                var isReferenceKey = (frm.Value.Substring(0, 1) == "{" && frm.Value.Substring(frm.Value.Length - 1, 1) == "}");
                                var val = (!isNotmapped && !isReferenceKey) ? frm.Value.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "") : frm.Value;
                                var existRef = (isReferenceKey) ? ((datasAddress.Keys.Where(k => k.Contains("{")).Count() > 0) ? true : false) : false;
                                if (!existRef)
                                {
                                    elm.ForeColor = (isNotmapped) ? Color.Red : ((isReferenceKey) ? Color.Blue : Color.Black);
                                    var it = datasAddress[elm.Text];
                                    datasAddress.Remove(elm.Text);
                                    datasAddress.Add(frm.Value, it);
                                    elm.Text = val;
                                }
                                else
                                {
                                    MessageBox.Show("Un'altra ReferenceKey è già presente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else if (existk && frm.Value != elm.Text)
                            {
                                MessageBox.Show("Nome elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
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
                if (!frm.Value.Contains("[") && !frm.Value.Contains("]") && !frm.Value.Contains("{") && !frm.Value.Contains("}"))
                {
                    var exist = datasAddress.ContainsKey(frm.Value) || datasAddress.ContainsKey("[" + frm.Value + "]") || datasAddress.ContainsKey("{" + frm.Value + "}");
                    if (!exist)
                    {
                        var key = (frm.KeyModality == inputKey.Modality.NotMapped) ? "[" + frm.Value + "]" : ((frm.KeyModality == inputKey.Modality.ReferenceKey) ? "{" + frm.Value + "}" : frm.Value);
                        var existRef = (frm.KeyModality == inputKey.Modality.ReferenceKey) ? ((datasAddress.Keys.Where(k => k.Contains("{")).Count() > 0) ? true : false) : false;
                        if (!existRef)
                        {
                            var node = treeView1.Nodes.Add(key);
                            node.ForeColor = (frm.KeyModality == inputKey.Modality.NotMapped) ? Color.Red : ((frm.KeyModality == inputKey.Modality.ReferenceKey) ? Color.Blue : Color.Black);
                            treeView1.SelectedNode = node;
                            datasAddress.Add(key, new List<DataAddressItem>());
                            button5_Click(sender, new EventArgs());
                        }
                        else
                        {
                            MessageBox.Show("Un'altra ReferenceKey è già presente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
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
                    if (res)
                    {
                        treeView1.Nodes.Remove(node);
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
    }
}
