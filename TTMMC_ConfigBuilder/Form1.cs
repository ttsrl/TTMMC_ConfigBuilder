using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class Form1 : Form
    {
        public static FileConfig file_;

        public Form1()
        {
            InitializeComponent();
        }

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
                var r = file_.AddMachine(frm.Type, frm.Protocol, frm.MachineName, frm.Description, adrss, frm.Port, frm.Image, frm.DatasAddressToRead);
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


        private void esportaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export.FileName = file_.Name;
            var fs = export.ShowDialog();
            if(fs == DialogResult.OK)
            {
                var db = new Dictionary<string, string>();
                if(file_.DB is FileConfigDB)
                {
                    var cns = "Data Source=" + file_.DB.IP + ";Initial Catalog=" + file_.DB.Database + ";Persist Security Info=" + file_.DB.PersisteSecurityInfo.ToString() + ";User ID=" + file_.DB.Username + ";Password=" + file_.DB.Password;
                    db.Add("DefaultConnection", cns);
                }
                var machines = new List<MachineJSON>();
                foreach (var it in file_.Machines)
                {
                    var nm = new MachineJSON
                    {
                         Id = it.Id,
                         Address = it.Address,
                         Description = it.Description,
                         ReferenceName = it.ReferenceName,
                         Port = it.Port,
                         Protocol = it.Protocol.Name,
                         Type = it.Type.Name, 
                         Image = it.Image,
                         DatasAddressToRead = it.DatasAddressToRead
                    };
                    machines.Add(nm);
                }
                var model = new ModelJson
                {
                    ConnectionStrings = db,
                    Machines = machines
                };
                var json = JsonConvert.SerializeObject(model);
                var stw = new StreamWriter(export.FileName);
                stw.Write(json);
                stw.Close();
            }
        }


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
                        lblAddress.Text = machine.Address;
                        lblPort.Text = machine.Port;
                        lblImg.Text = machine.Image;
                        lblCountDatasRead.Text = machine.DatasAddressToRead.Count.ToString();
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

        private void edit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var nm = ((LinkLabel)sender).Name ?? "";
            var machine = file_.GetMachine(listBox1.SelectedItem?.ToString());
            if (!string.IsNullOrEmpty(nm) && machine is FileConfigMachine)
            {
                var frmInputTxt = new inputTxt();
                var frmSelect = new inputSelect();
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
                else if(nm == "editDesc")
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
                //refresh
                listBox1_SelectedIndexChanged(listBox1.SelectedItem, new EventArgs());
            }
            
        }
    }
}
