using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class Form1 : Form
    {
        public static FileConfig file_;
        public List<string> Modality;

        public enum DataTypes
        {
            INT,
            UINT,
            DINT,
            UDINT,
            REAL,
            DOUBLE,
            STRING
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Modality = new List<string>();
            Modality.Add("Key > 0");
            Modality.Add("Key > Prec.");
            Modality.Add("Key > 0 Ogni X Volte");
            Modality.Add("Key > Prec. Ogni X Volte");
        }


        #region MENU

        private void NuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnm = new inputTxt();
            fnm.Value = "appsettings";
            if(fnm.ShowDialog() == DialogResult.OK)
            {
                file_ = new FileConfig(fnm.Value);
                nuovoToolStripMenuItem.Enabled = false;
                aggiungiToolStripMenuItem.Enabled = true;
                apriToolStripMenuItem.Enabled = false;
                esportaToolStripMenuItem.Enabled = true;
                chiudiStripMenuItem2.Enabled = true;
                listBox1.Enabled = true;
            }
        }

        private void ApriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inp = import.ShowDialog();
            if(inp == DialogResult.OK)
            {
                var file = new StreamReader(import.FileName);
                var read = file.ReadToEnd();
                file.Close();
                if (!string.IsNullOrEmpty(read))
                {
                    var json = JsonConvert.DeserializeObject<ModelJson>(read);
                    file_ = new FileConfig(import.SafeFileName);
                    //load data
                    if (json.ConnectionStrings.ContainsKey("DefaultConnection"))
                    {
                        file_.AddDatabase(json.ConnectionStrings["DefaultConnection"]);
                    }
                    foreach (var m in json.Machines)
                    {
                        var machineType = file_.GetMachineType(m.Value.Type) ?? new FileConfigMachineType { Name = m.Value.Type };
                        var machineProtocol = file_.GetProtocol(m.Value.Protocol) ?? new FileConfigProtocol { Name = m.Value.Protocol };
                        var machineGroup = file_.GetGroup(m.Value.Group) ?? new FileConfigGroup { Name = m.Value.Group };
                        if (machineType is FileConfigMachineType && machineProtocol is FileConfigProtocol)
                        {
                            file_.AddMachineType(m.Value.Type);
                            file_.AddProtocol(m.Value.Protocol);
                            file_.AddGroup(m.Value.Group);
                            var l = m.Value.DatasAddressToRead?.ToDictionary(k => k.Key, v => v.Value.Select(x => x.Value).ToList());
                            var w = m.Value.DatasAddressToWrite?.ToDictionary(k => k.Key, v => v.Value.Select(x => x.Value).ToList());
                            if (w == null || l == null)
                            {
                                MessageBox.Show("Impossibile caricare un elemento", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                file_.AddMachine(machineType, machineProtocol, machineGroup ,m.Value.ReferenceName, m.Value.Description, m.Value.Address, m.Value.Port, m.Value.Image, l, w, m.Value.ModalityLogCheck, m.Value.ValueModalityLogCheck, m.Value.ReferenceKeyRead, m.Value.FinishKeyRead, m.Value.FinishKeyWrite);
                            }
                        }
                    }
                    reloadListBox1();
                    nuovoToolStripMenuItem.Enabled = false;
                    aggiungiToolStripMenuItem.Enabled = true;
                    apriToolStripMenuItem.Enabled = false;
                    esportaToolStripMenuItem.Enabled = true;
                    chiudiStripMenuItem2.Enabled = true;
                    listBox1.Enabled = true;
                    tsslNElem.Text = (file_.Machines.Count + ((file_.DB is FileConfigDB) ? 1 : 0)).ToString();
                    tsslNProt.Text = file_.Protocols.Count.ToString();
                    tsslNTypes.Text = file_.MachineTypes.Count.ToString();
                    tsslNGroup.Text = file_.Groups.Count.ToString();
                }
            }
        }

        private void chiudiStripMenuItem2_Click(object sender, EventArgs e)
        {
            file_ = null;
            tsslNElem.Text = "0";
            tsslNProt.Text = "0";
            tsslNTypes.Text = "0";
            tsslNGroup.Text = "0";
            reloadListBox1();
            nuovoToolStripMenuItem.Enabled = true;
            aggiungiToolStripMenuItem.Enabled = false;
            apriToolStripMenuItem.Enabled = true;
            esportaToolStripMenuItem.Enabled = false;
            chiudiStripMenuItem2.Enabled = false;
            listBox1.Enabled = false;
            machineDetails.Visible = false;
            databaseDetails.Visible = false;
        }

        private void esportaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export.FileName = file_.Name;
            var fs = export.ShowDialog();
            if (fs == DialogResult.OK)
            {
                toolStripStatusLabel4.Visible = true;
                toolStripProgressBar1.Visible = true;
                this.Enabled = false;
                saver.RunWorkerAsync();
            }
        }

        private void esciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProtocolloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new inputTxt();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                file_.AddProtocol(frm.Value);
                tsslNProt.Text = (int.Parse(tsslNProt.Text) + 1).ToString();
            }
        }

        private void TipologiaMacchinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new inputTxt();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                file_.AddMachineType(frm.Value);
                tsslNTypes.Text = (int.Parse(tsslNTypes.Text) + 1).ToString();
            }
        }

        private void gruppoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new inputTxt();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                file_.AddGroup(frm.Value);
                tsslNGroup.Text = (int.Parse(tsslNGroup.Text) + 1).ToString();
            }
        }

        private void DatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new NewDB();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                file_.AddDatabase(frm.IP, frm.DB, frm.Username, frm.Password, frm.RequestSecurityInfo);
                databaseToolStripMenuItem.Enabled = false;
                listBox1.Items.Add("Database");
                tsslNElem.Text = (int.Parse(tsslNElem.Text) + 1).ToString();
            }
        }

        private void MacchinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new NewMachine();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                var adrss = frm.Address;
                adrss = adrss.Replace("opc.tcp://", "");
                var r = file_.AddMachine(frm.Type, frm.Protocol, frm.Group, frm.MachineName, frm.Description, adrss, frm.Port, frm.Image, frm.DatasAddressToRead, frm.DatasAddressToWrite, frm.ModalityLogCheck, frm.ValueModalityLogCheck);
                if (r)
                {
                    listBox1.Items.Add(frm.MachineName);
                    tsslNElem.Text = (int.Parse(tsslNElem.Text) + 1).ToString();
                }
                else
                {
                    MessageBox.Show("Impossibile aggiungere la macchina", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void eliminaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != "Database")
                file_.RemoveMachine(listBox1.SelectedItem.ToString());
            else
            {
                file_.RemoveDatabase();
                databaseToolStripMenuItem.Enabled = true;
            }
            tsslNElem.Text = (int.Parse(tsslNElem.Text) - 1).ToString();
            listBox1.Items.Remove(listBox1.SelectedItem.ToString());
        }

        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem?.ToString();
            if (curItem != null)
            {
                if (curItem == "Database")
                {
                    ipLbl.Text = file_.DB.IP;
                    dbLbl.Text = file_.DB.Database;
                    usernameLbl.Text = file_.DB.Username;
                    passwordLbl.Text = "**********";
                    reqinfoLbl.Text = file_.DB.PersisteSecurityInfo.ToString();
                    databaseDetails.Visible = true;
                    machineDetails.Visible = false;
                }
                else
                {
                    var machine = file_.GetMachine(curItem);
                    if (machine is FileConfigMachine)
                    {
                        lblId.Text = machine.Id.ToString();
                        lblNm.Text = machine.ReferenceName;
                        lblDesc.Text = machine.Description;
                        lblType.Text = machine.Type.Name;
                        lblProtocol.Text = machine.Protocol.Name;
                        lblGroup.Text = machine.Group.Name;
                        lblAddress.Text = machine.Address;
                        lblPort.Text = machine.Port;
                        lblImg.Text = machine.Image;
                        lblCountDatasRead.Text = machine.DatasAddressToRead.Count.ToString();
                        lblCountDatasWrite.Text = machine.DatasAddressToWrite.Count.ToString();
                        lblMod.Text = Modality[machine.ModalityLogCheck];
                        lblXMod.Text = machine.ValueModalityLogCheck.ToString();
                        databaseDetails.Visible = false;
                        machineDetails.Visible = true;
                    }
                }
            }
            else
            {
                databaseDetails.Visible = false;
                machineDetails.Visible = false;
            }
            
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.SelectedIndex = listBox1.IndexFromPoint(e.Location);
            if (listBox1.SelectedIndex != -1)
            {
                if(e.Button == MouseButtons.Right)
                {
                    listBox1.ContextMenuStrip = menuStripList;
                }
                else
                {
                    listBox1.ContextMenuStrip = null;
                }
            }
            else
            {
                listBox1.ContextMenuStrip = null;
            }

        }

        private void edit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var nm = ((LinkLabel)sender).Name ?? "";
            if (!string.IsNullOrEmpty(nm))
            {
                var machine = (file_ is FileConfig) ? file_.GetMachine(listBox1.SelectedItem?.ToString()) : null;
                if (machine is FileConfigMachine)
                {
                    var frmInputTxt = new inputTxt();
                    var frmSelect = new inputSelect();
                    var frmTreview = new inputTreeView();
                    if (nm == "editName")
                    {
                        frmInputTxt.LblTxt = "Nome:";
                        frmInputTxt.Value = machine.ReferenceName;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                        {
                            machine.ReferenceName = frmInputTxt.Value;
                            listBox1.Items[listBox1.SelectedIndex] = frmInputTxt.Value;
                        }
                    }
                    else if (nm == "editDesc")
                    {
                        frmInputTxt.LblTxt = "Descrizione:";
                        frmInputTxt.Value = machine.Description;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                        {
                            machine.Description = frmInputTxt.Value;
                        }
                    }
                    else if (nm == "editType")
                    {
                        frmSelect.LblTxt = "Tipologia:";
                        frmSelect.List = file_.MachineTypes.Select(it => it.Name).ToList();
                        frmSelect.Value = machine.Type.Name;
                        if (frmSelect.ShowDialog() == DialogResult.OK)
                        {
                            machine.Type = file_.GetMachineType(frmSelect.Value);
                        }
                    }
                    else if (nm == "editGroup")
                    {
                        frmSelect.LblTxt = "Gruppo:";
                        frmSelect.List = file_.Groups.Select(it => it.Name).ToList();
                        frmSelect.Value = machine.Group.Name;
                        if (frmSelect.ShowDialog() == DialogResult.OK)
                        {
                            machine.Group = file_.GetGroup(frmSelect.Value);
                        }
                    }
                    else if (nm == "editProtocol")
                    {
                        frmSelect.LblTxt = "Protocollo:";
                        frmSelect.List = file_.Protocols.Select(it => it.Name).ToList();
                        frmSelect.Value = machine.Protocol.Name;
                        if (frmSelect.ShowDialog() == DialogResult.OK)
                        {
                            machine.Protocol = file_.GetProtocol(frmSelect.Value);
                        }
                    }
                    else if (nm == "editAddress")
                    {
                        frmInputTxt.LblTxt = "Indirizzo:";
                        frmInputTxt.Value = machine.Address;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                        {
                            machine.Address = frmInputTxt.Value;
                        }
                    }
                    else if (nm == "editPort")
                    {
                        frmInputTxt.LblTxt = "Porta:";
                        frmInputTxt.Value = machine.Port;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                        {
                            machine.Port = frmInputTxt.Value;
                        }
                    }
                    else if (nm == "editImg")
                    {
                        frmInputTxt.LblTxt = "Porta:";
                        frmInputTxt.Value = machine.Image;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                        {
                            machine.Image = frmInputTxt.Value;
                        }
                    }
                    else if (nm == "editDatasRead")
                    {
                        //copia
                        var newDatasToRead = new Dictionary<string, List<DataAddressItem>>();
                        foreach (var it in machine.DatasAddressToRead)
                        {
                            var list = new List<DataAddressItem>();
                            foreach (var itl in it.Value)
                            {
                                var dr = new DataAddressItem(itl.Address, itl.Description, (DataTypes)(Enum.Parse(typeof(DataTypes), itl.DataType.ToUpper())), itl.Scaling);
                                list.Add(dr);
                            }
                            newDatasToRead.Add(it.Key, list);
                        }
                        frmTreview.Read = true;
                        frmTreview.Machine = machine;
                        frmTreview.datasAddress = newDatasToRead;
                        if (frmTreview.ShowDialog() == DialogResult.OK)
                        {
                            machine.DatasAddressToRead = frmTreview.datasAddress;
                        }
                    }
                    else if (nm == "editDatasWrite")
                    {
                        //copia
                        var newDatasToWrite = new Dictionary<string, List<DataAddressItem>>();
                        foreach (var it in machine.DatasAddressToWrite)
                        {
                            var list = new List<DataAddressItem>();
                            foreach (var itl in it.Value)
                            {
                                var dr = new DataAddressItem(itl.Address, itl.Description, (DataTypes)(Enum.Parse(typeof(DataTypes), itl.DataType.ToUpper())), itl.Scaling);
                                list.Add(dr);
                            }
                            newDatasToWrite.Add(it.Key, list);
                        }
                        frmTreview.Read = false;
                        frmTreview.Machine = machine;
                        frmTreview.datasAddress = newDatasToWrite;
                        if (frmTreview.ShowDialog() == DialogResult.OK)
                        {
                            machine.DatasAddressToWrite = frmTreview.datasAddress;
                        }
                    }
                    else if (nm == "editMod")
                    {
                        frmSelect.LblTxt = "Modalita Record:";
                        frmSelect.List = Modality;
                        frmSelect.Value = Modality[machine.ModalityLogCheck];
                        if (frmSelect.ShowDialog() == DialogResult.OK)
                        {
                            machine.ModalityLogCheck = Modality.IndexOf(frmSelect.Value);
                        }
                    }
                    else if (nm == "editXMod")
                    {
                        frmInputTxt.LblTxt = "Ogni Volte:";
                        frmInputTxt.Value = machine.ValueModalityLogCheck.ToString();
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                        {
                            machine.ValueModalityLogCheck = Convert.ToInt32(frmInputTxt.Value);
                        }
                    }
                    //refresh
                    listBox1_SelectedIndexChanged(listBox1.SelectedItem, new EventArgs());
                }
            }
            
        }

        private void editDatabase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var nm = ((LinkLabel)sender).Name ?? "";
            if (!string.IsNullOrEmpty(nm))
            {
                if (file_ is FileConfig && file_.DB is FileConfigDB)
                {
                    var frm = new inputTxt();
                    var frmS = new inputSelect();
                    if (nm == "editHost")
                    {
                        frm.LblTxt = "Host:";
                        frm.Value = file_.DB.IP;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            file_.DB.IP = frm.Value;
                        }
                    }
                    else if (nm == "editDb")
                    {
                        frm.LblTxt = "Database:";
                        frm.Value = file_.DB.Database;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            file_.DB.Database = frm.Value;
                        }
                    }
                    else if (nm == "editUsrn")
                    {
                        frm.LblTxt = "Username:";
                        frm.Value = file_.DB.Username;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            file_.DB.Username = frm.Value;
                        }
                    }
                    else if (nm == "editPass")
                    {
                        frm.LblTxt = "Password:";
                        frm.Value = file_.DB.Password;
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            file_.DB.Password = frm.Value;
                        }
                    }
                    else if (nm == "editSecInfo")
                    {
                        var l = new List<string>();
                        l.Add("True");
                        l.Add("False");
                        frmS.LblTxt = "Security Info:";
                        frmS.List = l;
                        frmS.Value = file_.DB.PersisteSecurityInfo.ToString();
                        if (frmS.ShowDialog() == DialogResult.OK)
                        {
                            file_.DB.PersisteSecurityInfo = Boolean.Parse(frmS.Value);
                        }
                    }
                    //refresh
                    listBox1_SelectedIndexChanged(listBox1.SelectedItem, new EventArgs());
                }
            }
        }

        private void saver_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var db = new Dictionary<string, string>();
            if (file_.DB is FileConfigDB)
            {
                var cns = "Data Source=" + file_.DB.IP + ";Initial Catalog=" + file_.DB.Database + ";Persist Security Info=" + file_.DB.PersisteSecurityInfo.ToString() + ";User ID=" + file_.DB.Username + ";Password=" + file_.DB.Password;
                db.Add("DefaultConnection", cns);
            }
            var machines = new Dictionary<string, MachineJSON>();
            var c = 0;
            foreach (var it in file_.Machines)
            {
                var nm = new MachineJSON
                {
                    Id = it.Id,
                    Address = it.Address,
                    Description = it.Description,
                    ReferenceName = it.ReferenceName,
                    Group = it.Group.Name,
                    Port = it.Port,
                    Protocol = it.Protocol.Name,
                    Type = it.Type.Name,
                    Image = it.Image,
                    ModalityLogCheck = it.ModalityLogCheck,
                    ValueModalityLogCheck = it.ValueModalityLogCheck,
                    ReferenceKeyRead = it.ReferenceKeyRead,
                    FinishKeyRead = it.FinishKeyRead,
                    FinishKeyWrite = it.FinishKeyWrite,
                    DatasAddressToRead = it.DatasAddressToRead.ToDictionary(k => k.Key, k => k.Value.Select((s, i) => new { s, i }).ToDictionary(x => x.i.ToString(), x => x.s)),
                    DatasAddressToWrite = it.DatasAddressToWrite.ToDictionary(k => k.Key, k => k.Value.Select((s, i) => new { s, i }).ToDictionary(x => x.i.ToString(), x => x.s))
                };
                machines.Add(c.ToString(), nm);
                c++;
            }
            var model = new ModelJson
            {
                ConnectionStrings = db,
                Machines = machines
            };
            var json = JsonConvert.SerializeObject(model, Formatting.Indented);
            var stw = new StreamWriter(export.FileName);
            stw.Write(json);
            stw.Close();
        }

        private void saver_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            toolStripStatusLabel4.Visible = false;
            toolStripProgressBar1.Visible = false;
            MessageBox.Show("File Esportato correttamente!", "Fine", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void reloadListBox1()
        {
            var list = new List<string>();
            if (file_ is FileConfig)
            {
                if (file_.DB is FileConfigDB)
                {
                    list.Add("Database");
                }
                list.AddRange(file_.Machines.Select(x => x.ReferenceName));
            }
            listBox1.ClearSelected();
            listBox1.Items.Clear();
            listBox1.Items.AddRange(list.ToArray());
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem?.ToString();
            if (curItem != null)
            {
                var res = file_.MoveUpMachine(curItem);
                if (res)
                    moveListBoxItem(-1);
            }
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem?.ToString();
            if (curItem != null)
            {
                var res = file_.MoveDownMachine(curItem);
                if (res)
                    moveListBoxItem(1);
            }
        }

        private void moveListBoxItem(int direction)
        {
            if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
                return;
            int newIndex = listBox1.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= listBox1.Items.Count)
                return;
            object selected = listBox1.SelectedItem;
            listBox1.Items.Remove(selected);
            listBox1.Items.Insert(newIndex, selected);
            listBox1.SetSelected(newIndex, true);
        }
    }
}
