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
    public partial class NewMachine : Form
    {
        private string _nmEditLbl;
        private string _nmEditLbl1;

        public string MachineName;
        public string Description;
        public FileConfigMachineType Type;
        public FileConfigProtocol Protocol;
        public string Address;
        public string Port;
        public string Image;
        public Dictionary<string, List<DataAddressItem>> DatasAddressToRead;
        public Dictionary<string, List<DataAddressItem>> DatasAddressToWrite;

        public NewMachine()
        {
            InitializeComponent();
        }

        private void NewMachine_Load(object sender, EventArgs e)
        {
            if (file_ is FileConfig)
            {
                foreach (var t in Form1.file_.MachineTypes)
                {
                    comboBox1.Items.Add(t.Name);
                }

                foreach (var p in Form1.file_.Protocols)
                {
                    comboBox2.Items.Add(p.Name);
                }

                lblId.Text = (file_.Machines.Count + 1).ToString();

                DatasAddressToRead = new Dictionary<string, List<DataAddressItem>>();
            }
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
            var frm = new inputKey();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if(!frm.Value.Contains("[") && !frm.Value.Contains("]") && !frm.Value.Contains("{") && !frm.Value.Contains("}"))
                {
                    var exist = DatasAddressToRead.ContainsKey(frm.Value) || DatasAddressToRead.ContainsKey("[" + frm.Value + "]") || DatasAddressToRead.ContainsKey("{" + frm.Value + "}");
                    if (!exist)
                    {
                        var key = (frm.KeyModality == inputKey.Modality.NotMapped) ? "[" + frm.Value + "]" : ((frm.KeyModality == inputKey.Modality.ReferenceKey) ? "{" + frm.Value + "}" : frm.Value);
                        var existRef = (frm.KeyModality == inputKey.Modality.ReferenceKey) ? ((DatasAddressToRead.Keys.Where(k => k.Contains("{")).Count() > 0) ? true : false) : false;
                        if (!existRef)
                        {
                            var node = treeView1.Nodes.Add(key);
                            node.ForeColor = (frm.KeyModality == inputKey.Modality.NotMapped) ? Color.Red : ((frm.KeyModality == inputKey.Modality.ReferenceKey) ? Color.Blue : Color.Black);
                            treeView1.SelectedNode = node;
                            DatasAddressToRead.Add(key, new List<DataAddressItem>());
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
                        var itemList = DatasAddressToRead[node.Text];
                        itemList.Add(new DataAddressItem(frm.Address, frm.Description, (DataTypes)(Enum.Parse(typeof(DataTypes), frm.DataType))));
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
                   var res = DatasAddressToRead.Remove(node.Text);
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

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var elm = ((TreeView)sender).SelectedNode;
            if (elm is TreeNode)
            {
                if (elm.Level == 1 || elm.Level == 2)
                {
                    e.CancelEdit = true;
                }else if (elm.Level == 0)
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
                if(elm.Level == 0)
                {
                    var exist = DatasAddressToRead.ContainsKey(_nmEditLbl);
                    if(exist)
                    {
                        var existk = DatasAddressToRead.ContainsKey(e.Label) || DatasAddressToRead.ContainsKey("[" + e.Label + "]") || DatasAddressToRead.ContainsKey("{" + e.Label + "}");
                        if (!existk)
                        {
                            var isNotmapped = (e.Label.Substring(0, 1) == "[" && e.Label.Substring(e.Label.Length - 1, 1) == "]");
                            var isReferenceKey = (e.Label.Substring(0, 1) == "{" && e.Label.Substring(e.Label.Length - 1, 1) == "}");
                            var val = (!isNotmapped && !isReferenceKey) ? e.Label.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "") : e.Label;
                            var existRef = (isReferenceKey) ? ((DatasAddressToRead.Keys.Where(k => k.Contains("{")).Count() > 0) ? true : false) : false;
                            if (!existRef)
                            {
                                elm.ForeColor = (isNotmapped) ? Color.Red : ((isReferenceKey) ? Color.Blue : Color.Black);
                                var it = DatasAddressToRead[_nmEditLbl];
                                DatasAddressToRead.Remove(_nmEditLbl);
                                DatasAddressToRead.Add(val, it);
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
                    var exist = DatasAddressToRead.ContainsKey(elm.Text);
                    if (exist)
                    {
                        var frm = new inputTxt();
                        frm.LblTxt = "Nome:";
                        frm.Value = elm.Text;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {

                            var existk = DatasAddressToRead.ContainsKey(frm.Value) || DatasAddressToRead.ContainsKey("[" + frm.Value + "]") || DatasAddressToRead.ContainsKey("{" + frm.Value + "}");
                            if (!existk && frm.Value != elm.Text)
                            {
                                var isNotmapped = (frm.Value.Substring(0, 1) == "[" && frm.Value.Substring(frm.Value.Length - 1, 1) == "]");
                                var isReferenceKey = (frm.Value.Substring(0, 1) == "{" && frm.Value.Substring(frm.Value.Length - 1, 1) == "}");
                                var val = (!isNotmapped && !isReferenceKey) ? frm.Value.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "") : frm.Value;
                                var existRef = (isReferenceKey) ? ((DatasAddressToRead.Keys.Where(k => k.Contains("{")).Count() > 0) ? true : false) : false;
                                if (!existRef)
                                {
                                    elm.ForeColor = (isNotmapped) ? Color.Red : ((isReferenceKey) ? Color.Blue : Color.Black);
                                    var it = DatasAddressToRead[elm.Text];
                                    DatasAddressToRead.Remove(elm.Text);
                                    DatasAddressToRead.Add(frm.Value, it);
                                    elm.Text = val;
                                }
                                else
                                {
                                    MessageBox.Show("Un'altra ReferenceKey è già presente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else if(existk && frm.Value != elm.Text)
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
                    var exist = DatasAddressToRead.ContainsKey(elm.Parent.Parent.Text);
                    if (exist)
                    {
                        var item = DatasAddressToRead[elm.Parent.Parent.Text][int.Parse(elm.Parent.Text)];
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
                            if(frm.ShowDialog() == DialogResult.OK)
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

        private void button6_Click(object sender, EventArgs e)
        {
            object obj = treeView1.SelectedNode;
            if (obj != null)
            {
                treeView1_NodeMouseDoubleClick(obj, new TreeNodeMouseClickEventArgs(treeView1.SelectedNode, MouseButtons.Left,2,1,1));
            }
        }

        //treeview2

        private void button8_Click(object sender, EventArgs e)
        {
            var node = treeView2.SelectedNode;
            if (node != null)
            {
                if (node.Level == 0)
                {
                    var frm = new NewMachineDataItem();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        treeView2.BeginUpdate();
                        var index = node.Nodes.Count;
                        node.Nodes.Add(index.ToString());
                        node.Nodes[index].Nodes.Add("Address: " + frm.Address);
                        node.Nodes[index].Nodes[0].ToolTipText = frm.Address;
                        node.Nodes[index].Nodes.Add("Description: " + frm.Description);
                        node.Nodes[index].Nodes[1].ToolTipText = frm.Description;
                        node.Nodes[index].Nodes.Add("DataType: " + frm.DataType);
                        node.Nodes[index].Nodes[2].ToolTipText = frm.DataType;
                        treeView2.EndUpdate();
                        var itemList = DatasAddressToWrite[node.Text];
                        itemList.Add(new DataAddressItem(frm.Address, frm.Description, (DataTypes)(Enum.Parse(typeof(DataTypes), frm.DataType))));
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var frm = new inputTxt();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var nm = frm.Value;
                var exist = DatasAddressToWrite.ContainsKey(nm);
                if (!exist)
                {
                    var node = treeView2.Nodes.Add(frm.Value);
                    treeView2.SelectedNode = node;
                    DatasAddressToWrite.Add(nm, new List<DataAddressItem>());
                    button8_Click(sender, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Nome elemento già presente nella lista", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            object obj = treeView2.SelectedNode;
            if (obj != null)
            {
                treeView2_NodeMouseDoubleClick(obj, new TreeNodeMouseClickEventArgs(treeView2.SelectedNode, MouseButtons.Left, 2, 1, 1));
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var node = treeView2.SelectedNode;
            if (node != null)
            {
                var lvl = node.Level;
                if (lvl == 2 | lvl == 1)
                {
                    var subitem = (lvl == 2) ? node.Parent : node;
                    if (subitem.Parent.Nodes.Count == 1)
                    {
                        DatasAddressToWrite.Remove(subitem.Parent.Text);
                        treeView2.Nodes.Remove(subitem.Parent);
                    }
                    else
                    {
                        var subItPar = subitem.Parent;
                        var it = DatasAddressToWrite[subItPar.Text];
                        it.RemoveAt(int.Parse(subitem.Text));
                        treeView2.Nodes.Remove(subitem);
                        //rename
                        for (var i = 0; i < subItPar.Nodes.Count; i++)
                        {
                            subItPar.Nodes[i].Text = i.ToString();
                        }
                    }
                }
                else //lvl 0
                {
                    DatasAddressToWrite.Remove(node.Text);
                    treeView2.Nodes.Remove(node);
                }
            }
        }

        private void treeView2_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            var elm = e.Node;
            if (elm is TreeNode && !string.IsNullOrEmpty(e.Label))
            {
                if (elm.Level == 0)
                {
                    var exist = DatasAddressToWrite.ContainsKey(_nmEditLbl1);
                    if (exist)
                    {
                        var it = DatasAddressToWrite[_nmEditLbl1];
                        DatasAddressToWrite.Remove(_nmEditLbl1);
                        DatasAddressToWrite.Add(e.Label, it);
                    }
                    else
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("Impossibile rinominare l' elemento", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void treeView2_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
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
                    _nmEditLbl1 = elm.Text;
                }
            }
        }

        private void treeView2_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var elm = e.Node;
            if (elm is TreeNode)
            {
                if (elm.Level == 0)
                {
                    var exist = DatasAddressToWrite.ContainsKey(elm.Text);
                    if (exist)
                    {
                        var frm = new inputTxt();
                        frm.LblTxt = "Nome:";
                        frm.Value = elm.Text;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            var it = DatasAddressToWrite[elm.Text];
                            DatasAddressToWrite.Remove(elm.Text);
                            DatasAddressToWrite.Add(frm.Value, it);
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
                    var exist = DatasAddressToWrite.ContainsKey(elm.Parent.Parent.Text);
                    if (exist)
                    {
                        var item = DatasAddressToWrite[elm.Parent.Parent.Text][int.Parse(elm.Parent.Text)];
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
    }
}
