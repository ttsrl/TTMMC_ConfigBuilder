namespace TTMMC_ConfigBuilder
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiudiStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.esportaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggiungiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protocolloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipologiaMacchinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macchinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.export = new System.Windows.Forms.SaveFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.databaseDetails = new System.Windows.Forms.GroupBox();
            this.editSecInfo = new System.Windows.Forms.LinkLabel();
            this.editPass = new System.Windows.Forms.LinkLabel();
            this.editUsrn = new System.Windows.Forms.LinkLabel();
            this.editDb = new System.Windows.Forms.LinkLabel();
            this.editHost = new System.Windows.Forms.LinkLabel();
            this.reqinfoLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.dbLbl = new System.Windows.Forms.Label();
            this.ipLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNElem = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNProt = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNTypes = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.machineDetails = new System.Windows.Forms.GroupBox();
            this.editDatasWrite = new System.Windows.Forms.LinkLabel();
            this.lblCountDatasWrite = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.editDatasRead = new System.Windows.Forms.LinkLabel();
            this.lblCountDatasRead = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.editImg = new System.Windows.Forms.LinkLabel();
            this.editPort = new System.Windows.Forms.LinkLabel();
            this.editAddress = new System.Windows.Forms.LinkLabel();
            this.editProtocol = new System.Windows.Forms.LinkLabel();
            this.editType = new System.Windows.Forms.LinkLabel();
            this.editDesc = new System.Windows.Forms.LinkLabel();
            this.editName = new System.Windows.Forms.LinkLabel();
            this.lblImg = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblProtocol = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblNm = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStripList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.eliminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saver = new System.ComponentModel.BackgroundWorker();
            this.import = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.databaseDetails.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.machineDetails.SuspendLayout();
            this.menuStripList.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aggiungiToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovoToolStripMenuItem,
            this.apriToolStripMenuItem,
            this.chiudiStripMenuItem2,
            this.toolStripSeparator1,
            this.esportaToolStripMenuItem,
            this.toolStripSeparator2,
            this.esciToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // nuovoToolStripMenuItem
            // 
            this.nuovoToolStripMenuItem.Name = "nuovoToolStripMenuItem";
            this.nuovoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuovoToolStripMenuItem.Text = "Nuovo";
            this.nuovoToolStripMenuItem.Click += new System.EventHandler(this.NuovoToolStripMenuItem_Click);
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            this.apriToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.apriToolStripMenuItem.Text = "Apri";
            this.apriToolStripMenuItem.Click += new System.EventHandler(this.ApriToolStripMenuItem_Click);
            // 
            // chiudiStripMenuItem2
            // 
            this.chiudiStripMenuItem2.Enabled = false;
            this.chiudiStripMenuItem2.Name = "chiudiStripMenuItem2";
            this.chiudiStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.chiudiStripMenuItem2.Text = "Chiudi";
            this.chiudiStripMenuItem2.Click += new System.EventHandler(this.chiudiStripMenuItem2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // esportaToolStripMenuItem
            // 
            this.esportaToolStripMenuItem.Enabled = false;
            this.esportaToolStripMenuItem.Name = "esportaToolStripMenuItem";
            this.esportaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.esportaToolStripMenuItem.Text = "Esporta";
            this.esportaToolStripMenuItem.Click += new System.EventHandler(this.esportaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // aggiungiToolStripMenuItem
            // 
            this.aggiungiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.protocolloToolStripMenuItem,
            this.tipologiaMacchinaToolStripMenuItem,
            this.toolStripSeparator3,
            this.databaseToolStripMenuItem,
            this.macchinaToolStripMenuItem});
            this.aggiungiToolStripMenuItem.Enabled = false;
            this.aggiungiToolStripMenuItem.Name = "aggiungiToolStripMenuItem";
            this.aggiungiToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aggiungiToolStripMenuItem.Text = "Aggiungi";
            // 
            // protocolloToolStripMenuItem
            // 
            this.protocolloToolStripMenuItem.Name = "protocolloToolStripMenuItem";
            this.protocolloToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.protocolloToolStripMenuItem.Text = "Protocollo";
            this.protocolloToolStripMenuItem.Click += new System.EventHandler(this.ProtocolloToolStripMenuItem_Click);
            // 
            // tipologiaMacchinaToolStripMenuItem
            // 
            this.tipologiaMacchinaToolStripMenuItem.Name = "tipologiaMacchinaToolStripMenuItem";
            this.tipologiaMacchinaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.tipologiaMacchinaToolStripMenuItem.Text = "Tipologia Macchina";
            this.tipologiaMacchinaToolStripMenuItem.Click += new System.EventHandler(this.TipologiaMacchinaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(176, 6);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.DatabaseToolStripMenuItem_Click);
            // 
            // macchinaToolStripMenuItem
            // 
            this.macchinaToolStripMenuItem.Name = "macchinaToolStripMenuItem";
            this.macchinaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.macchinaToolStripMenuItem.Text = "Macchina";
            this.macchinaToolStripMenuItem.Click += new System.EventHandler(this.MacchinaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // open
            // 
            this.open.FileName = "openFileDialog1";
            // 
            // export
            // 
            this.export.AddExtension = false;
            this.export.DefaultExt = "json";
            this.export.Filter = "|*.json";
            this.export.Title = "Esporta ConfigFile";
            // 
            // listBox1
            // 
            this.listBox1.Enabled = false;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(251, 329);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Elementi";
            // 
            // databaseDetails
            // 
            this.databaseDetails.Controls.Add(this.editSecInfo);
            this.databaseDetails.Controls.Add(this.editPass);
            this.databaseDetails.Controls.Add(this.editUsrn);
            this.databaseDetails.Controls.Add(this.editDb);
            this.databaseDetails.Controls.Add(this.editHost);
            this.databaseDetails.Controls.Add(this.reqinfoLbl);
            this.databaseDetails.Controls.Add(this.passwordLbl);
            this.databaseDetails.Controls.Add(this.usernameLbl);
            this.databaseDetails.Controls.Add(this.dbLbl);
            this.databaseDetails.Controls.Add(this.ipLbl);
            this.databaseDetails.Controls.Add(this.label8);
            this.databaseDetails.Controls.Add(this.label7);
            this.databaseDetails.Controls.Add(this.label6);
            this.databaseDetails.Controls.Add(this.label5);
            this.databaseDetails.Controls.Add(this.label4);
            this.databaseDetails.Location = new System.Drawing.Point(278, 48);
            this.databaseDetails.Name = "databaseDetails";
            this.databaseDetails.Size = new System.Drawing.Size(395, 158);
            this.databaseDetails.TabIndex = 3;
            this.databaseDetails.TabStop = false;
            this.databaseDetails.Text = "  Dettagli Database  ";
            this.databaseDetails.Visible = false;
            // 
            // editSecInfo
            // 
            this.editSecInfo.AutoSize = true;
            this.editSecInfo.Location = new System.Drawing.Point(299, 125);
            this.editSecInfo.Name = "editSecInfo";
            this.editSecInfo.Size = new System.Drawing.Size(47, 13);
            this.editSecInfo.TabIndex = 22;
            this.editSecInfo.TabStop = true;
            this.editSecInfo.Text = "Modifica";
            this.editSecInfo.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editSecInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editDatabase_LinkClicked);
            // 
            // editPass
            // 
            this.editPass.AutoSize = true;
            this.editPass.Location = new System.Drawing.Point(299, 101);
            this.editPass.Name = "editPass";
            this.editPass.Size = new System.Drawing.Size(47, 13);
            this.editPass.TabIndex = 21;
            this.editPass.TabStop = true;
            this.editPass.Text = "Modifica";
            this.editPass.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editDatabase_LinkClicked);
            // 
            // editUsrn
            // 
            this.editUsrn.AutoSize = true;
            this.editUsrn.Location = new System.Drawing.Point(299, 77);
            this.editUsrn.Name = "editUsrn";
            this.editUsrn.Size = new System.Drawing.Size(47, 13);
            this.editUsrn.TabIndex = 20;
            this.editUsrn.TabStop = true;
            this.editUsrn.Text = "Modifica";
            this.editUsrn.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editUsrn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editDatabase_LinkClicked);
            // 
            // editDb
            // 
            this.editDb.AutoSize = true;
            this.editDb.Location = new System.Drawing.Point(299, 53);
            this.editDb.Name = "editDb";
            this.editDb.Size = new System.Drawing.Size(47, 13);
            this.editDb.TabIndex = 19;
            this.editDb.TabStop = true;
            this.editDb.Text = "Modifica";
            this.editDb.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editDb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editDatabase_LinkClicked);
            // 
            // editHost
            // 
            this.editHost.AutoSize = true;
            this.editHost.Location = new System.Drawing.Point(299, 29);
            this.editHost.Name = "editHost";
            this.editHost.Size = new System.Drawing.Size(47, 13);
            this.editHost.TabIndex = 18;
            this.editHost.TabStop = true;
            this.editHost.Text = "Modifica";
            this.editHost.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editHost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editDatabase_LinkClicked);
            // 
            // reqinfoLbl
            // 
            this.reqinfoLbl.Location = new System.Drawing.Point(114, 125);
            this.reqinfoLbl.Name = "reqinfoLbl";
            this.reqinfoLbl.Size = new System.Drawing.Size(180, 13);
            this.reqinfoLbl.TabIndex = 9;
            this.reqinfoLbl.Text = "Host:";
            // 
            // passwordLbl
            // 
            this.passwordLbl.Location = new System.Drawing.Point(114, 101);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(180, 13);
            this.passwordLbl.TabIndex = 8;
            this.passwordLbl.Text = "Host:";
            // 
            // usernameLbl
            // 
            this.usernameLbl.Location = new System.Drawing.Point(114, 77);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(180, 13);
            this.usernameLbl.TabIndex = 7;
            this.usernameLbl.Text = "Host:";
            // 
            // dbLbl
            // 
            this.dbLbl.Location = new System.Drawing.Point(114, 53);
            this.dbLbl.Name = "dbLbl";
            this.dbLbl.Size = new System.Drawing.Size(180, 13);
            this.dbLbl.TabIndex = 6;
            this.dbLbl.Text = "Host:";
            // 
            // ipLbl
            // 
            this.ipLbl.Location = new System.Drawing.Point(114, 29);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(180, 13);
            this.ipLbl.TabIndex = 5;
            this.ipLbl.Text = "Host:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "RequestSecInfo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Host:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslNElem,
            this.toolStripStatusLabel3,
            this.tsslNProt,
            this.toolStripStatusLabel2,
            this.tsslNTypes,
            this.toolStripStatusLabel4,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 396);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(686, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "Elementi:";
            // 
            // tsslNElem
            // 
            this.tsslNElem.Name = "tsslNElem";
            this.tsslNElem.Size = new System.Drawing.Size(13, 17);
            this.tsslNElem.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel3.Text = "Protocolli:";
            // 
            // tsslNProt
            // 
            this.tsslNProt.Name = "tsslNProt";
            this.tsslNProt.Size = new System.Drawing.Size(13, 17);
            this.tsslNProt.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(63, 17);
            this.toolStripStatusLabel2.Text = "Topologie:";
            // 
            // tsslNTypes
            // 
            this.tsslNTypes.Name = "tsslNTypes";
            this.tsslNTypes.Size = new System.Drawing.Size(13, 17);
            this.tsslNTypes.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(71, 17);
            this.toolStripStatusLabel4.Text = "Salvataggio:";
            this.toolStripStatusLabel4.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // machineDetails
            // 
            this.machineDetails.Controls.Add(this.editDatasWrite);
            this.machineDetails.Controls.Add(this.lblCountDatasWrite);
            this.machineDetails.Controls.Add(this.label17);
            this.machineDetails.Controls.Add(this.editDatasRead);
            this.machineDetails.Controls.Add(this.lblCountDatasRead);
            this.machineDetails.Controls.Add(this.label16);
            this.machineDetails.Controls.Add(this.editImg);
            this.machineDetails.Controls.Add(this.editPort);
            this.machineDetails.Controls.Add(this.editAddress);
            this.machineDetails.Controls.Add(this.editProtocol);
            this.machineDetails.Controls.Add(this.editType);
            this.machineDetails.Controls.Add(this.editDesc);
            this.machineDetails.Controls.Add(this.editName);
            this.machineDetails.Controls.Add(this.lblImg);
            this.machineDetails.Controls.Add(this.label15);
            this.machineDetails.Controls.Add(this.lblPort);
            this.machineDetails.Controls.Add(this.label14);
            this.machineDetails.Controls.Add(this.lblAddress);
            this.machineDetails.Controls.Add(this.label13);
            this.machineDetails.Controls.Add(this.lblProtocol);
            this.machineDetails.Controls.Add(this.label12);
            this.machineDetails.Controls.Add(this.lblType);
            this.machineDetails.Controls.Add(this.label11);
            this.machineDetails.Controls.Add(this.lblDesc);
            this.machineDetails.Controls.Add(this.label10);
            this.machineDetails.Controls.Add(this.lblNm);
            this.machineDetails.Controls.Add(this.label9);
            this.machineDetails.Controls.Add(this.lblId);
            this.machineDetails.Controls.Add(this.label2);
            this.machineDetails.Location = new System.Drawing.Point(278, 48);
            this.machineDetails.Name = "machineDetails";
            this.machineDetails.Size = new System.Drawing.Size(395, 336);
            this.machineDetails.TabIndex = 5;
            this.machineDetails.TabStop = false;
            this.machineDetails.Text = "  Dettagli Macchina  ";
            this.machineDetails.Visible = false;
            // 
            // editDatasWrite
            // 
            this.editDatasWrite.AutoSize = true;
            this.editDatasWrite.Location = new System.Drawing.Point(299, 246);
            this.editDatasWrite.Name = "editDatasWrite";
            this.editDatasWrite.Size = new System.Drawing.Size(47, 13);
            this.editDatasWrite.TabIndex = 29;
            this.editDatasWrite.TabStop = true;
            this.editDatasWrite.Text = "Modifica";
            this.editDatasWrite.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editDatasWrite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblCountDatasWrite
            // 
            this.lblCountDatasWrite.Location = new System.Drawing.Point(114, 246);
            this.lblCountDatasWrite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCountDatasWrite.Name = "lblCountDatasWrite";
            this.lblCountDatasWrite.Size = new System.Drawing.Size(180, 13);
            this.lblCountDatasWrite.TabIndex = 28;
            this.lblCountDatasWrite.Text = "Nome:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(27, 246);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Dati Scrittura:";
            // 
            // editDatasRead
            // 
            this.editDatasRead.AutoSize = true;
            this.editDatasRead.Location = new System.Drawing.Point(299, 222);
            this.editDatasRead.Name = "editDatasRead";
            this.editDatasRead.Size = new System.Drawing.Size(47, 13);
            this.editDatasRead.TabIndex = 26;
            this.editDatasRead.TabStop = true;
            this.editDatasRead.Text = "Modifica";
            this.editDatasRead.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editDatasRead.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblCountDatasRead
            // 
            this.lblCountDatasRead.Location = new System.Drawing.Point(114, 222);
            this.lblCountDatasRead.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCountDatasRead.Name = "lblCountDatasRead";
            this.lblCountDatasRead.Size = new System.Drawing.Size(180, 13);
            this.lblCountDatasRead.TabIndex = 25;
            this.lblCountDatasRead.Text = "Nome:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(27, 222);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Dati Lettura:";
            // 
            // editImg
            // 
            this.editImg.AutoSize = true;
            this.editImg.Location = new System.Drawing.Point(299, 198);
            this.editImg.Name = "editImg";
            this.editImg.Size = new System.Drawing.Size(47, 13);
            this.editImg.TabIndex = 23;
            this.editImg.TabStop = true;
            this.editImg.Text = "Modifica";
            this.editImg.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editImg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editPort
            // 
            this.editPort.AutoSize = true;
            this.editPort.Location = new System.Drawing.Point(299, 174);
            this.editPort.Name = "editPort";
            this.editPort.Size = new System.Drawing.Size(47, 13);
            this.editPort.TabIndex = 22;
            this.editPort.TabStop = true;
            this.editPort.Text = "Modifica";
            this.editPort.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editPort.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editAddress
            // 
            this.editAddress.AutoSize = true;
            this.editAddress.Location = new System.Drawing.Point(299, 150);
            this.editAddress.Name = "editAddress";
            this.editAddress.Size = new System.Drawing.Size(47, 13);
            this.editAddress.TabIndex = 21;
            this.editAddress.TabStop = true;
            this.editAddress.Text = "Modifica";
            this.editAddress.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editAddress.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editProtocol
            // 
            this.editProtocol.AutoSize = true;
            this.editProtocol.Location = new System.Drawing.Point(299, 125);
            this.editProtocol.Name = "editProtocol";
            this.editProtocol.Size = new System.Drawing.Size(47, 13);
            this.editProtocol.TabIndex = 20;
            this.editProtocol.TabStop = true;
            this.editProtocol.Text = "Modifica";
            this.editProtocol.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editProtocol.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editType
            // 
            this.editType.AutoSize = true;
            this.editType.Location = new System.Drawing.Point(299, 101);
            this.editType.Name = "editType";
            this.editType.Size = new System.Drawing.Size(47, 13);
            this.editType.TabIndex = 19;
            this.editType.TabStop = true;
            this.editType.Text = "Modifica";
            this.editType.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editDesc
            // 
            this.editDesc.AutoSize = true;
            this.editDesc.Location = new System.Drawing.Point(299, 77);
            this.editDesc.Name = "editDesc";
            this.editDesc.Size = new System.Drawing.Size(47, 13);
            this.editDesc.TabIndex = 18;
            this.editDesc.TabStop = true;
            this.editDesc.Text = "Modifica";
            this.editDesc.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editDesc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editName
            // 
            this.editName.AutoSize = true;
            this.editName.Location = new System.Drawing.Point(299, 53);
            this.editName.Name = "editName";
            this.editName.Size = new System.Drawing.Size(47, 13);
            this.editName.TabIndex = 17;
            this.editName.TabStop = true;
            this.editName.Text = "Modifica";
            this.editName.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblImg
            // 
            this.lblImg.Location = new System.Drawing.Point(114, 198);
            this.lblImg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(180, 13);
            this.lblImg.TabIndex = 15;
            this.lblImg.Text = "Nome:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 198);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Immagine:";
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(114, 174);
            this.lblPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(180, 13);
            this.lblPort.TabIndex = 13;
            this.lblPort.Text = "Nome:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(27, 174);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Porta:";
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(114, 150);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(180, 13);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Nome:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(27, 150);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Indirizzo:";
            // 
            // lblProtocol
            // 
            this.lblProtocol.Location = new System.Drawing.Point(114, 125);
            this.lblProtocol.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(180, 13);
            this.lblProtocol.TabIndex = 9;
            this.lblProtocol.Text = "Nome:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 125);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Protocollo:";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(114, 101);
            this.lblType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(180, 13);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Nome:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 101);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Tipo:";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(114, 77);
            this.lblDesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(180, 13);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "Nome:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 77);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Descrizione:";
            // 
            // lblNm
            // 
            this.lblNm.Location = new System.Drawing.Point(114, 53);
            this.lblNm.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNm.Name = "lblNm";
            this.lblNm.Size = new System.Drawing.Size(180, 13);
            this.lblNm.TabIndex = 3;
            this.lblNm.Text = "Nome:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 53);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Nome:";
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(114, 29);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(180, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Id:";
            // 
            // menuStripList
            // 
            this.menuStripList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificaToolStripMenuItem,
            this.toolStripSeparator4,
            this.eliminaToolStripMenuItem});
            this.menuStripList.Name = "menuStripList";
            this.menuStripList.Size = new System.Drawing.Size(122, 54);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.modificaToolStripMenuItem.Text = "Modifica";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(118, 6);
            // 
            // eliminaToolStripMenuItem
            // 
            this.eliminaToolStripMenuItem.Name = "eliminaToolStripMenuItem";
            this.eliminaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.eliminaToolStripMenuItem.Text = "Elimina";
            this.eliminaToolStripMenuItem.Click += new System.EventHandler(this.eliminaToolStripMenuItem_Click);
            // 
            // saver
            // 
            this.saver.WorkerReportsProgress = true;
            this.saver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.saver_DoWork);
            this.saver.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.saver_RunWorkerCompleted);
            // 
            // import
            // 
            this.import.AddExtension = false;
            this.import.DefaultExt = "json";
            this.import.FileName = "appsettings.json";
            this.import.Filter = "|*.json";
            this.import.Title = "Seleziona il file config";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 418);
            this.Controls.Add(this.machineDetails);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.databaseDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TTMMC ConfigBuilder";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.databaseDetails.ResumeLayout(false);
            this.databaseDetails.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.machineDetails.ResumeLayout(false);
            this.machineDetails.PerformLayout();
            this.menuStripList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apriToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem esportaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aggiungiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem macchinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.SaveFileDialog export;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox databaseDetails;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslNElem;
        private System.Windows.Forms.ToolStripMenuItem chiudiStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem protocolloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipologiaMacchinaToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ipLbl;
        private System.Windows.Forms.Label reqinfoLbl;
        private System.Windows.Forms.Label passwordLbl;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Label dbLbl;
        private System.Windows.Forms.GroupBox machineDetails;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslNProt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblNm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblProtocol;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblImg;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ContextMenuStrip menuStripList;
        private System.Windows.Forms.ToolStripMenuItem modificaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem eliminaToolStripMenuItem;
        private System.Windows.Forms.LinkLabel editImg;
        private System.Windows.Forms.LinkLabel editPort;
        private System.Windows.Forms.LinkLabel editAddress;
        private System.Windows.Forms.LinkLabel editProtocol;
        private System.Windows.Forms.LinkLabel editType;
        private System.Windows.Forms.LinkLabel editDesc;
        private System.Windows.Forms.LinkLabel editName;
        private System.Windows.Forms.LinkLabel editDatasRead;
        private System.Windows.Forms.Label lblCountDatasRead;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslNTypes;
        private System.ComponentModel.BackgroundWorker saver;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.OpenFileDialog import;
        private System.Windows.Forms.LinkLabel editSecInfo;
        private System.Windows.Forms.LinkLabel editPass;
        private System.Windows.Forms.LinkLabel editUsrn;
        private System.Windows.Forms.LinkLabel editDb;
        private System.Windows.Forms.LinkLabel editHost;
        private System.Windows.Forms.LinkLabel editDatasWrite;
        private System.Windows.Forms.Label lblCountDatasWrite;
        private System.Windows.Forms.Label label17;
    }
}

