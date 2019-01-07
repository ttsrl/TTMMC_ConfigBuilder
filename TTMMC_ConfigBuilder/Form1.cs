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
        FileConfig file_;

        public Form1()
        {
            InitializeComponent();
        }

        private void NuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fnm = new name();
            fnm.NameTxt = "appsettings";
            if(fnm.ShowDialog() == DialogResult.OK)
            {
                file_ = new FileConfig(fnm.NameTxt);
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
            var frm = new name();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                file_.AddProtocol(frm.NameTxt);
                tsslNProt.Text = (int.Parse(tsslNProt.Text) + 1).ToString();
            }
        }

        private void TipologiaMacchinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new name();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                file_.AddMachineType(frm.NameTxt);
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
                         Image = it.Image
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
            string curItem = listBox1.SelectedItem.ToString();
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
        }


    }
}
