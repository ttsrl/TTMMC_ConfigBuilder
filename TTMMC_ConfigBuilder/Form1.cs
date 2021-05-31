using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TTMMC_ConfigBuilder.Properties;

namespace TTMMC_ConfigBuilder
{
    public partial class Form1 : Form
    {
        public static FileConfig file_;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            includeStandardObjToolStripMenuItem.Checked = Settings.Default.includeStandardOb;
        }

        #region MENU

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnm = new inputTxt();
            fnm.Value = "appsettings";
            fnm.Text = "New File";
            if(fnm.ShowDialog() == DialogResult.OK)
            {
                file_ = new FileConfig(fnm.Value);
                newToolStripMenuItem.Enabled = false;
                addToolStripMenuItem.Enabled = true;
                editToolStripMenuItem.Enabled = true;
                openToolStripMenuItem.Enabled = false;
                saveToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
                listBox1.Enabled = true;
                listBox2.Enabled = true;
                moveUp.Enabled = true;
                moveDown.Enabled = true;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inp = import.ShowDialog();
            if(inp == DialogResult.OK)
            {
                var file = new StreamReader(import.FileName);
                var read = file.ReadToEnd();
                file.Close();
                if (!string.IsNullOrEmpty(read))
                {
                    try
                    {
                        var json = JsonConvert.DeserializeObject<ModelJson>(read);
                        file_ = new FileConfig(import.SafeFileName);
                        foreach (var it in json.ConnectionStrings)
                        {
                            file_.AddDatabase(it.Key, it.Value);
                        }
                        foreach (var m in json.Machines)
                        {
                            file_.AddMachine(m);
                        }
                        file_.Recipes = json.RecipeLayouts;
                        file_.Vpn = json.Vpn;
                        //disegno liste
                        reloadLabel();
                        reloadListBox1();
                        reloadListBox2();
                        //sistemo elementi gui
                        newToolStripMenuItem.Enabled = false;
                        addToolStripMenuItem.Enabled = true;
                        editToolStripMenuItem.Enabled = true;
                        openToolStripMenuItem.Enabled = false;
                        saveToolStripMenuItem.Enabled = true;
                        closeToolStripMenuItem.Enabled = true;
                        listBox1.Enabled = true;
                        listBox2.Enabled = true;
                        moveUp.Enabled = true;
                        moveDown.Enabled = true;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        file_ = null;
                        reloadLabel();
                        reloadListBox1();
                        reloadListBox2();
                        MessageBox.Show("Error loading file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }
                }
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            file_ = null;
            reloadLabel();
            reloadListBox1();
            reloadListBox2();
            newToolStripMenuItem.Enabled = true;
            addToolStripMenuItem.Enabled = false;
            editToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            listBox1.Enabled = false;
            listBox2.Enabled = false;
            machineDetails.Visible = false;
            databaseDetails.Visible = false;
            moveUp.Enabled = false;
            moveDown.Enabled = false;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProtocolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new inputTxt();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                file_.AddProtocol(frm.Value);
                reloadLabel();
            }
        }

        private void GroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new inputTxt();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                file_.AddGroup(frm.Value);
                reloadLabel();
            }
        }

        private void DatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new newDB();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                file_.AddDatabase(frm.ConnName, frm.IP, frm.DB, frm.Username, frm.Password, frm.RequestSecurityInfo);
                reloadListBox1();
                reloadLabel();
            }
        }

        private void MachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new newMachine();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(frm.Machine.ShareEngine))
                {
                    var adrss = frm.Machine.Address;
                    adrss = adrss.Replace("opc.tcp://", "");
                }
                var r = file_.AddMachine(frm.Machine);
                if (r)
                {
                    reloadListBox2();
                    reloadLabel();
                }
                else
                    MessageBox.Show("Cannot add the machine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(((ListBox)sender).Name == "listBox1")
                file_.RemoveDatabase(listBox1.SelectedItem.ToString());
            else
                file_.RemoveMachine(listBox2.SelectedItem.ToString());
            reloadListBox1();
            reloadListBox2();
            reloadLabel();
        }

        private void ProtocolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputList frm = new inputList();
            var oldList = file_.Protocols.Clone().ToList();
            frm.List = oldList;
            frm.Text = "Edit Protocols";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (var act in frm.Actions)
                {
                    if (act.Action == inputList.iLAction.iLActions.Add)
                        file_.AddProtocol(act.NewElement);
                    else if (act.Action == inputList.iLAction.iLActions.Edit)
                        file_.ReplaceProtocol(act.OldElement, act.NewElement);
                    else if (act.Action == inputList.iLAction.iLActions.Delete)
                        file_.RemoveProtocol(act.OldElement);
                }
                reloadLabel();
            }
        }

        private void GroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputList frm = new inputList();
            var oldList = file_.Groups.Clone().ToList();
            frm.List = oldList;
            frm.Text = "Edit Groups";
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (var act in frm.Actions)
                {
                    if (act.Action == inputList.iLAction.iLActions.Add)
                        file_.AddGroup(act.NewElement);
                    else if (act.Action == inputList.iLAction.iLActions.Edit)
                        file_.ReplaceGroup(act.OldElement, act.NewElement);
                    else if (act.Action == inputList.iLAction.iLActions.Delete)
                        file_.RemoveGroup(act.OldElement);
                }
                reloadLabel();
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new info();
            f.ShowDialog();
        }


        private void includeStandardObjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.includeStandardOb = includeStandardObjToolStripMenuItem.Checked;
            Settings.Default.Save();
            Settings.Default.Reload();
        }

        private void recipesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new inputListRecipes();
            frm.Items = file_.Machines.Select(m => m.Name).ToList();
            if (file_.Recipes != null)
                frm.List = file_.Recipes.Clone().ToList();
            if (frm.ShowDialog() == DialogResult.OK)
                file_.Recipes = frm.List;
        }

        private void VPNToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frm = new inputListVPN();
            var objs = new List<string>();
            objs.AddRange(file_.DBs.Select(it => it.Key));
            objs.AddRange(file_.Machines.Where(it => string.IsNullOrEmpty(it.ShareEngine)).Select(it => it.Name));
            frm.Objects = objs;
            if (file_.Vpn != null)
                frm.List = file_.Vpn.Clone().ToList();
            if (frm.ShowDialog() == DialogResult.OK)
                file_.Vpn = frm.List;
        }

        #endregion

        #region LISTS

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem?.ToString();
            if (curItem != null)
            {
                var db = file_.GetDB(curItem);
                if(db is DB)
                {
                    ipLbl.Text = db.IP;
                    dbLbl.Text = db.Database ?? "";
                    usernameLbl.Text = db.Username ?? "";
                    passwordLbl.Text = db.Password ?? "";
                    reqinfoLbl.Text = db.PersistSecurityInfo.ToString();
                    databaseDetails.Visible = true;
                    machineDetails.Visible = false;
                }
            }
            else
            {
                databaseDetails.Visible = false;
                machineDetails.Visible = false;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = listBox2.SelectedItem?.ToString();
            if (curItem != null)
            {
                var machine = file_.GetMachine(curItem);
                if (machine is Machine)
                {
                    lblName.Text = machine.Name;
                    lblLbl.Text = machine.Label;
                    lblDesc.Text = machine.Description;
                    lblType.Text = Enum.GetName(typeof(MachineType), machine.Type);
                    lblProtocol.Text = string.IsNullOrEmpty(machine.Protocol) ? "--" : machine.Protocol;
                    lblGroup.Text = string.IsNullOrEmpty(machine.Group) ? "--" : file_.GetGroup(machine.Group);
                    lblShare.Text = string.IsNullOrEmpty(machine.ShareEngine) ? "--" : file_.GetMachine(machine.ShareEngine).Name;
                    lblAddress.Text = string.IsNullOrEmpty(machine.Address) ? "--" : machine.Address;
                    lblPort.Text = string.IsNullOrEmpty(machine.Port) ? "--" : machine.Port;
                    lblRoot.Text = string.IsNullOrEmpty(machine.RootPath) ? "--" : machine.RootPath;
                    lblOnlineDI.Text = string.IsNullOrEmpty(machine.OnlineDataItem) ? "--" : machine.OnlineDataItem;
                    lblReadMode.Text = Enum.GetName(typeof(ReadMode), machine.ReadMode) == "Null" ? "--" : Enum.GetName(typeof(ReadMode), machine.ReadMode);
                    lblImg.Text = machine.Image;
                    lblIcon.Text = machine.Icon;
                    lblMinRef.Text = machine.CallRealtimeDatasReadInterval.ToString();
                    lblContRead.Text = Enum.GetName(typeof(ReadMode), machine.ReadMode) != "Continuous" ? "--" : machine.ReadingContinuousInterval.ToString();
                    editContRead.Enabled = Enum.GetName(typeof(ReadMode), machine.ReadMode) == "Continuous";
                    lblCountDatas.Text = machine.Datas.Count.ToString();
                    lblRecording.Text = "";
                    databaseDetails.Visible = false;
                    machineDetails.Visible = true;
                    if(string.IsNullOrEmpty(machine.ShareEngine))
                    {
                        editAddress.Enabled = true;
                        editPort.Enabled = true;
                        editProtocol.Enabled = true;
                        editRoot.Enabled = true;
                        editReadMode.Enabled = true;
                    }
                    else
                    {
                        editAddress.Enabled = false;
                        editPort.Enabled = false;
                        editProtocol.Enabled = false;
                        editRoot.Enabled = false;
                        editReadMode.Enabled = false;
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
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                if (e.Button == MouseButtons.Right)
                {
                    listBox1.SelectedIndex = index;
                    listBox1.ContextMenuStrip = menuStripList;
                }
                else if (e.Button == MouseButtons.Left)
                {
                    listBox1.ContextMenuStrip = null;
                    listBox2.SelectedIndex = -1;
                }
                else
                    listBox1.ContextMenuStrip = null;
            }
            else
                listBox1.ContextMenuStrip = null;
        }

        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            int index = this.listBox2.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                if (e.Button == MouseButtons.Right)
                {
                    listBox2.SelectedIndex = index;
                    listBox2.ContextMenuStrip = menuStripList;
                }
                else if (e.Button == MouseButtons.Left) 
                {
                    listBox2.ContextMenuStrip = null;
                    listBox1.SelectedIndex = -1;
                }
                else
                    listBox2.ContextMenuStrip = null;
            }
            else
                listBox2.ContextMenuStrip = null;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, myBrush, new Rectangle(0, e.Bounds.Y + 3, e.Bounds.Width, e.Bounds.Height), StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            e.DrawBackground();
            Brush myBrush = Brushes.Black;
            e.Graphics.DrawString(listBox2.Items[e.Index].ToString(), e.Font, myBrush, new Rectangle(0, e.Bounds.Y + 3, e.Bounds.Width, e.Bounds.Height), StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        #endregion

        private void edit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var nm = ((LinkLabel)sender).Name ?? "";
            if (!string.IsNullOrEmpty(nm))
            {
                var machine = (file_ is FileConfig) ? file_.GetMachine(listBox2.SelectedItem?.ToString()) : null;
                if (machine is Machine)
                {
                    var frmInputTxt = new inputTxt();
                    var frmSelect = new inputSelect();
                    var frmTreview = new inputTreeView();
                    if (nm == "editName")
                    {
                        frmInputTxt.LblTxt = "Name:";
                        frmInputTxt.Value = machine.Name;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                        {
                            machine.Name = frmInputTxt.Value;
                            listBox2.Items[listBox2.SelectedIndex] = frmInputTxt.Value;
                        }
                    }
                    else if (nm == "editLabel")
                    {
                        frmInputTxt.LblTxt = "Label:";
                        frmInputTxt.Value = machine.Label;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                        {
                            machine.Label = frmInputTxt.Value;
                            listBox2.Items[listBox2.SelectedIndex] = frmInputTxt.Value;
                        }
                    }
                    else if (nm == "editDesc")
                    {
                        frmInputTxt.LblTxt = "Description:";
                        frmInputTxt.Value = machine.Description;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                            machine.Description = frmInputTxt.Value;
                    }
                    else if (nm == "editType")
                    {
                        frmSelect.LblTxt = "Type:";
                        frmSelect.List = Enum.GetNames(typeof(MachineType)).ToList();
                        frmSelect.Value = Enum.GetName(typeof(MachineType), machine.Type);
                        if (frmSelect.ShowDialog() == DialogResult.OK)
                            machine.Type = (MachineType)Enum.Parse(typeof(MachineType), frmSelect.Value);
                    }
                    else if (nm == "editGroup")
                    {
                        frmSelect.LblTxt = "Group:";
                        var list = file_.Groups.ToList();
                        list.Insert(0, "--");
                        frmSelect.List = list;
                        frmSelect.Value = string.IsNullOrEmpty(machine.Group) ? "--" : file_.GetGroup(machine.Group);
                        if (frmSelect.ShowDialog() == DialogResult.OK)
                            machine.Group = file_.Groups.Where(g => g == frmSelect.Value).FirstOrDefault();
                    }
                    else if (nm == "editShare")
                    {
                        frmSelect.LblTxt = "ShareEngine:";
                        var l = new List<string>();
                        l.Add("--");
                        l.AddRange(file_.Machines.Where(m => m.Type == machine.Type).Select(m => m.Name).ToList());
                        l.Remove(machine.Name);
                        frmSelect.List = l;
                        frmSelect.Value = string.IsNullOrEmpty(machine.ShareEngine) ? "--" : file_.GetMachine(machine.ShareEngine).Name;
                        if (frmSelect.ShowDialog() == DialogResult.OK)
                        {
                            machine.ShareEngine = (frmSelect.Value == "--") ? null : file_.GetMachine(frmSelect.Value).Name;
                            machine.Protocol = "";
                            machine.Address = "";
                            machine.Port = "";
                            machine.RootPath = "";
                            machine.ReadMode = ReadMode.Null;
                        }
                    }
                    else if (nm == "editReadMode")
                    {
                        frmSelect.LblTxt = "ReadMode:";
                        var modes = Enum.GetNames(typeof(ReadMode)).ToList();
                        modes.RemoveAt(0);
                        frmSelect.List = modes;
                        frmSelect.Value = Enum.GetName(typeof(ReadMode), machine.ReadMode);
                        if (frmSelect.ShowDialog() == DialogResult.OK)
                        {
                            machine.ReadMode = (ReadMode)Enum.Parse(typeof(ReadMode), frmSelect.Value);
                            if(machine.ReadMode != ReadMode.Continuous)
                                machine.ReadingContinuousInterval = 1000;
                        }
                    }
                    else if (nm == "editProtocol")
                    {
                        frmSelect.LblTxt = "Protocol:";
                        frmSelect.List = file_.Protocols.ToList();
                        frmSelect.Value = machine.Protocol;
                        if (frmSelect.ShowDialog() == DialogResult.OK)
                            machine.Protocol = file_.GetProtocol(frmSelect.Value);
                    }
                    else if (nm == "editAddress")
                    {
                        frmInputTxt.LblTxt = "Address:";
                        frmInputTxt.Value = machine.Address;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                            machine.Address = frmInputTxt.Value;
                    }
                    else if (nm == "editPort")
                    {
                        frmInputTxt.LblTxt = "Port:";
                        frmInputTxt.Value = machine.Port;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                            machine.Port = frmInputTxt.Value;
                    }
                    else if (nm == "editRoot")
                    {
                        frmInputTxt.LblTxt = "RootPath:";
                        frmInputTxt.Value = machine.RootPath;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                            machine.RootPath = frmInputTxt.Value;
                    }
                    else if (nm == "editOnline")
                    {
                        frmInputTxt.LblTxt = "Online DataItem:";
                        frmInputTxt.Value = machine.OnlineDataItem;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                            machine.OnlineDataItem = frmInputTxt.Value;
                    }
                    else if (nm == "editImg")
                    {
                        frmInputTxt.LblTxt = "Image:";
                        frmInputTxt.Value = machine.Image;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                            machine.Image = frmInputTxt.Value;
                    }
                    else if (nm == "editIcon")
                    {
                        frmInputTxt.LblTxt = "Icon:";
                        frmInputTxt.Value = machine.Icon;
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                            machine.Icon = frmInputTxt.Value;
                    }
                    else if (nm == "editMinRef")
                    {
                        frmInputTxt.LblTxt = "Call Realtime Int.:";
                        frmInputTxt.Value = machine.CallRealtimeDatasReadInterval.ToString();
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                            machine.CallRealtimeDatasReadInterval = Convert.ToInt32(frmInputTxt.Value);
                    }
                    else if (nm == "editContRead")
                    {
                        frmInputTxt.LblTxt = "Continuous Read Int.:";
                        frmInputTxt.Value = machine.ReadingContinuousInterval.ToString();
                        if (frmInputTxt.ShowDialog() == DialogResult.OK)
                            machine.ReadingContinuousInterval = Convert.ToInt32(frmInputTxt.Value);
                    }
                    else if (nm == "editDatas")
                    {
                        var cloneDataRead = machine.Datas.Clone().ToList();
                        frmTreview.Text = "Edit Datas - " + machine.Name;
                        frmTreview.Datas = cloneDataRead;
                        if (frmTreview.ShowDialog() == DialogResult.OK)
                            machine.Datas = frmTreview.Datas;
                    }
                    else if (nm == "editRecording")
                    {
                        var obj = (RecordingDetails)machine.RecordingDetails.Clone();
                        var frmR = new inputRecording();
                        frmR.Recording = obj;
                        frmR.Datas = machine.Datas;
                        if (frmR.ShowDialog() == DialogResult.OK)
                            machine.RecordingDetails = frmR.Recording;
                    }
                    //refresh
                    listBox2_SelectedIndexChanged(listBox2.SelectedItem, new EventArgs());
                }
            }
            
        }

        private void editDatabase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var nm = ((LinkLabel)sender).Name ?? "";
            if (!string.IsNullOrEmpty(nm))
            {
                var db = (file_ is FileConfig) ? file_.GetDB(listBox1.SelectedItem?.ToString()) : null;
                if (db is DB)
                {
                    var frm = new inputTxt();
                    var frmS = new inputSelect();
                    if (nm == "editHost")
                    {
                        frm.LblTxt = "Host:";
                        frm.Value = db.IP;
                        if (frm.ShowDialog() == DialogResult.OK)
                            db.IP = frm.Value;
                    }
                    else if (nm == "editDb")
                    {
                        frm.LblTxt = "Database:";
                        frm.Value = db.Database;
                        if (frm.ShowDialog() == DialogResult.OK)
                            db.Database = frm.Value;
                    }
                    else if (nm == "editUsrn")
                    {
                        frm.LblTxt = "Username:";
                        frm.Value = db.Username;
                        if (frm.ShowDialog() == DialogResult.OK)
                            db.Username = frm.Value;
                    }
                    else if (nm == "editPass")
                    {
                        frm.LblTxt = "Password:";
                        frm.Value = db.Password;
                        if (frm.ShowDialog() == DialogResult.OK)
                            db.Password = frm.Value;
                    }
                    else if (nm == "editSecInfo")
                    {
                        frmS.LblTxt = "Security Info:";
                        frmS.List = new List<string> { "True", "False" };
                        frmS.Value = db.PersistSecurityInfo.ToString();
                        if (frmS.ShowDialog() == DialogResult.OK)
                            db.PersistSecurityInfo = Boolean.Parse(frmS.Value);
                    }
                    //refresh
                    listBox1_SelectedIndexChanged(listBox1.SelectedItem, new EventArgs());
                }
            }
        }

        private void saver_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var dbs = new Dictionary<string, string>();
                foreach (var db in file_.DBs)
                {
                    var cns = "Data Source=" + db.Value.IP + ";Initial Catalog=" + db.Value.Database + ";Persist Security Info=" + db.Value.PersistSecurityInfo.ToString() + ";User ID=" + db.Value.Username + ";Password=" + db.Value.Password;
                    dbs.Add(db.Key, cns);
                }
                var machines = new List<Machine>();
                foreach (var it in file_.Machines)
                {
                    var nm = new Machine
                    {
                        Name = it.Name,
                        Label = it.Label,
                        Description = it.Description,
                        Group = it.Group,
                        Address = it.Address,
                        Port = it.Port,
                        Protocol = it.Protocol,
                        ShareEngine = it.ShareEngine,
                        ReadMode = it.ReadMode,
                        RootPath = it.RootPath,
                        OnlineDataItem = it.OnlineDataItem,
                        Type = it.Type,
                        Image = it.Image,
                        Icon = it.Icon,
                        CallRealtimeDatasReadInterval = it.CallRealtimeDatasReadInterval,
                        ReadingContinuousInterval = it.ReadingContinuousInterval,
                        RecordingDetails = it.RecordingDetails,
                        Datas = it.Datas
                    };
                    machines.Add(nm);
                }
                object model = null;
                if (includeStandardObjToolStripMenuItem.Checked)
                {
                    model = new ModelJsonWithStandardOb
                    {
                        ConnectionStrings = dbs,
                        Machines = machines,
                        Vpn = file_.Vpn,
                        RecipeLayouts = file_.Recipes
                    };
                }
                else
                {
                    model = new ModelJson
                    {
                        ConnectionStrings = dbs,
                        Machines = machines,
                        Vpn = file_.Vpn,
                        RecipeLayouts = file_.Recipes
                    };
                }
                var json = JsonConvert.SerializeObject(model, Formatting.Indented);
                var stw = new StreamWriter(export.FileName);
                var version = new Version(Assembly.GetEntryAssembly().GetName().Version.Major, Assembly.GetEntryAssembly().GetName().Version.Minor);
                stw.Write("//#################################\r\n//##  TTMMC - ConfigurationFile  ##\r\n//##     ConfigBuider v. " + String.Format("{0}.{1}", version.Major, version.Minor) + "     ##\r\n//##      " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "       ##\r\n//#################################");
                stw.Write("\r\n\r\n\r\n");
                stw.Write(json);
                stw.Close();
                e.Result = true;
            }
            catch { e.Result = false; }
        }

        private void saver_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            toolStripStatusLabel4.Visible = false;
            toolStripProgressBar1.Visible = false;
            if((bool)e.Result == true)
                MessageBox.Show("File exported successfully!", "Fine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error during the save procedure!", "Fine", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            string curItem = listBox2.SelectedItem?.ToString();
            if (curItem != null)
            {
                var res = file_.MoveUpMachine(curItem);
                if (res)
                    moveListBoxItem(-1);
            }
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            string curItem = listBox2.SelectedItem?.ToString();
            if (curItem != null)
            {
                var res = file_.MoveDownMachine(curItem);
                if (res)
                    moveListBoxItem(1);
            }
        }

        private void moveListBoxItem(int direction)
        {
            if (listBox2.SelectedItem == null || listBox2.SelectedIndex < 0)
                return;
            int newIndex = listBox2.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= listBox2.Items.Count)
                return;
            object selected = listBox2.SelectedItem;
            listBox2.Items.Remove(selected);
            listBox2.Items.Insert(newIndex, selected);
            listBox2.SetSelected(newIndex, true);
        }

        private void reloadListBox1()
        {
            listBox1.ClearSelected();
            listBox1.Items.Clear();
            if (file_ == null)
                return;
            var list = new List<string>();
            list.AddRange(file_.DBs.Keys);
            listBox1.Items.AddRange(list.ToArray());
        }

        private void reloadListBox2()
        {
            listBox2.ClearSelected();
            listBox2.Items.Clear();
            if (file_ == null)
                return;
            var list = new List<string>();
            list.AddRange(file_.Machines.Select(m => m.Name));
            listBox2.Items.AddRange(list.ToArray());
        }

        private void reloadLabel()
        {
            if (file_ == null)
            {
                tsslNElem.Text = tsslNProt.Text = tsslNGroup.Text = "0";
                return;
            }

            tsslNElem.Text = (file_.Machines.Count + file_.DBs.Count).ToString();
            tsslNProt.Text = file_.Protocols.Count.ToString();
            tsslNGroup.Text = file_.Groups.Count.ToString();
        }
    }
}