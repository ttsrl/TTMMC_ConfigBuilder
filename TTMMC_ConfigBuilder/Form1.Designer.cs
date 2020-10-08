﻿namespace TTMMC_ConfigBuilder
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
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protocolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.protocolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open = new System.Windows.Forms.OpenFileDialog();
            this.export = new System.Windows.Forms.SaveFileDialog();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.menuStripList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslNGroup = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.machineDetails = new System.Windows.Forms.GroupBox();
            this.editMinRef = new System.Windows.Forms.LinkLabel();
            this.lblMinRef = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.editIcon = new System.Windows.Forms.LinkLabel();
            this.lblIcon = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.editGroup = new System.Windows.Forms.LinkLabel();
            this.lblGroup = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.editXMod = new System.Windows.Forms.LinkLabel();
            this.lblXMod = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.editMod = new System.Windows.Forms.LinkLabel();
            this.lblMod = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
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
            this.saver = new System.ComponentModel.BackgroundWorker();
            this.import = new System.Windows.Forms.OpenFileDialog();
            this.moveUp = new System.Windows.Forms.Button();
            this.moveDown = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.menuStripList.SuspendLayout();
            this.databaseDetails.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.machineDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1281, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(125, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.protocolToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.toolStripSeparator3,
            this.databaseToolStripMenuItem,
            this.machineToolStripMenuItem});
            this.addToolStripMenuItem.Enabled = false;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // protocolToolStripMenuItem
            // 
            this.protocolToolStripMenuItem.Name = "protocolToolStripMenuItem";
            this.protocolToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.protocolToolStripMenuItem.Text = "Protocol";
            this.protocolToolStripMenuItem.Click += new System.EventHandler(this.ProtocolToolStripMenuItem_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.groupToolStripMenuItem.Text = "Group";
            this.groupToolStripMenuItem.Click += new System.EventHandler(this.GroupToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(152, 6);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.DatabaseToolStripMenuItem_Click);
            // 
            // machineToolStripMenuItem
            // 
            this.machineToolStripMenuItem.Name = "machineToolStripMenuItem";
            this.machineToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.machineToolStripMenuItem.Text = "Machine";
            this.machineToolStripMenuItem.Click += new System.EventHandler(this.MachineToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.protocolsToolStripMenuItem,
            this.groupsToolStripMenuItem});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // protocolsToolStripMenuItem
            // 
            this.protocolsToolStripMenuItem.Name = "protocolsToolStripMenuItem";
            this.protocolsToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.protocolsToolStripMenuItem.Text = "Protocols";
            this.protocolsToolStripMenuItem.Click += new System.EventHandler(this.ProtocolsToolStripMenuItem_Click);
            // 
            // groupsToolStripMenuItem
            // 
            this.groupsToolStripMenuItem.Name = "groupsToolStripMenuItem";
            this.groupsToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.groupsToolStripMenuItem.Text = "Groups";
            this.groupsToolStripMenuItem.Click += new System.EventHandler(this.GroupsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(30, 24);
            this.toolStripMenuItem1.Text = "?";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(118, 26);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
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
            // listBox2
            // 
            this.listBox2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox2.Enabled = false;
            this.listBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 25;
            this.listBox2.Location = new System.Drawing.Point(329, 66);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(316, 500);
            this.listBox2.TabIndex = 1;
            this.listBox2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox2_DrawItem);
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.listBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox2_MouseDown);
            // 
            // menuStripList
            // 
            this.menuStripList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.menuStripList.Name = "menuStripList";
            this.menuStripList.Size = new System.Drawing.Size(123, 28);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connections DB";
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
            this.databaseDetails.Location = new System.Drawing.Point(703, 59);
            this.databaseDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.databaseDetails.Name = "databaseDetails";
            this.databaseDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.databaseDetails.Size = new System.Drawing.Size(563, 194);
            this.databaseDetails.TabIndex = 3;
            this.databaseDetails.TabStop = false;
            this.databaseDetails.Text = "  Database Details  ";
            this.databaseDetails.Visible = false;
            // 
            // editSecInfo
            // 
            this.editSecInfo.AutoSize = true;
            this.editSecInfo.Location = new System.Drawing.Point(435, 154);
            this.editSecInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editSecInfo.Name = "editSecInfo";
            this.editSecInfo.Size = new System.Drawing.Size(32, 17);
            this.editSecInfo.TabIndex = 22;
            this.editSecInfo.TabStop = true;
            this.editSecInfo.Text = "Edit";
            this.editSecInfo.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editSecInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editDatabase_LinkClicked);
            // 
            // editPass
            // 
            this.editPass.AutoSize = true;
            this.editPass.Location = new System.Drawing.Point(435, 124);
            this.editPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editPass.Name = "editPass";
            this.editPass.Size = new System.Drawing.Size(32, 17);
            this.editPass.TabIndex = 21;
            this.editPass.TabStop = true;
            this.editPass.Text = "Edit";
            this.editPass.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editDatabase_LinkClicked);
            // 
            // editUsrn
            // 
            this.editUsrn.AutoSize = true;
            this.editUsrn.Location = new System.Drawing.Point(435, 95);
            this.editUsrn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editUsrn.Name = "editUsrn";
            this.editUsrn.Size = new System.Drawing.Size(32, 17);
            this.editUsrn.TabIndex = 20;
            this.editUsrn.TabStop = true;
            this.editUsrn.Text = "Edit";
            this.editUsrn.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editUsrn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editDatabase_LinkClicked);
            // 
            // editDb
            // 
            this.editDb.AutoSize = true;
            this.editDb.Location = new System.Drawing.Point(435, 65);
            this.editDb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editDb.Name = "editDb";
            this.editDb.Size = new System.Drawing.Size(32, 17);
            this.editDb.TabIndex = 19;
            this.editDb.TabStop = true;
            this.editDb.Text = "Edit";
            this.editDb.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editDb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editDatabase_LinkClicked);
            // 
            // editHost
            // 
            this.editHost.AutoSize = true;
            this.editHost.Location = new System.Drawing.Point(435, 36);
            this.editHost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editHost.Name = "editHost";
            this.editHost.Size = new System.Drawing.Size(32, 17);
            this.editHost.TabIndex = 18;
            this.editHost.TabStop = true;
            this.editHost.Text = "Edit";
            this.editHost.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editHost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.editDatabase_LinkClicked);
            // 
            // reqinfoLbl
            // 
            this.reqinfoLbl.Location = new System.Drawing.Point(180, 154);
            this.reqinfoLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reqinfoLbl.Name = "reqinfoLbl";
            this.reqinfoLbl.Size = new System.Drawing.Size(240, 16);
            this.reqinfoLbl.TabIndex = 9;
            this.reqinfoLbl.Text = "Host:";
            // 
            // passwordLbl
            // 
            this.passwordLbl.Location = new System.Drawing.Point(180, 124);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(240, 16);
            this.passwordLbl.TabIndex = 8;
            this.passwordLbl.Text = "Host:";
            // 
            // usernameLbl
            // 
            this.usernameLbl.Location = new System.Drawing.Point(180, 95);
            this.usernameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(240, 16);
            this.usernameLbl.TabIndex = 7;
            this.usernameLbl.Text = "Host:";
            // 
            // dbLbl
            // 
            this.dbLbl.Location = new System.Drawing.Point(180, 65);
            this.dbLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dbLbl.Name = "dbLbl";
            this.dbLbl.Size = new System.Drawing.Size(240, 16);
            this.dbLbl.TabIndex = 6;
            this.dbLbl.Text = "Host:";
            // 
            // ipLbl
            // 
            this.ipLbl.Location = new System.Drawing.Point(180, 36);
            this.ipLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(240, 16);
            this.ipLbl.TabIndex = 5;
            this.ipLbl.Text = "Host:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 154);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "RequestSecInfo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 124);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(36, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
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
            this.toolStripStatusLabel5,
            this.tsslNGroup,
            this.toolStripStatusLabel4,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1281, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(72, 20);
            this.toolStripStatusLabel1.Text = "Elements:";
            // 
            // tsslNElem
            // 
            this.tsslNElem.Name = "tsslNElem";
            this.tsslNElem.Size = new System.Drawing.Size(17, 20);
            this.tsslNElem.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(74, 20);
            this.toolStripStatusLabel3.Text = "Protocols:";
            // 
            // tsslNProt
            // 
            this.tsslNProt.Name = "tsslNProt";
            this.tsslNProt.Size = new System.Drawing.Size(17, 20);
            this.tsslNProt.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(59, 20);
            this.toolStripStatusLabel5.Text = "Groups:";
            // 
            // tsslNGroup
            // 
            this.tsslNGroup.Name = "tsslNGroup";
            this.tsslNGroup.Size = new System.Drawing.Size(17, 20);
            this.tsslNGroup.Text = "0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(56, 20);
            this.toolStripStatusLabel4.Text = "Saving:";
            this.toolStripStatusLabel4.Visible = false;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(133, 18);
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // machineDetails
            // 
            this.machineDetails.Controls.Add(this.editMinRef);
            this.machineDetails.Controls.Add(this.lblMinRef);
            this.machineDetails.Controls.Add(this.label22);
            this.machineDetails.Controls.Add(this.editIcon);
            this.machineDetails.Controls.Add(this.lblIcon);
            this.machineDetails.Controls.Add(this.label21);
            this.machineDetails.Controls.Add(this.editGroup);
            this.machineDetails.Controls.Add(this.lblGroup);
            this.machineDetails.Controls.Add(this.label20);
            this.machineDetails.Controls.Add(this.editXMod);
            this.machineDetails.Controls.Add(this.lblXMod);
            this.machineDetails.Controls.Add(this.label19);
            this.machineDetails.Controls.Add(this.editMod);
            this.machineDetails.Controls.Add(this.lblMod);
            this.machineDetails.Controls.Add(this.label18);
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
            this.machineDetails.Location = new System.Drawing.Point(703, 59);
            this.machineDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.machineDetails.Name = "machineDetails";
            this.machineDetails.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.machineDetails.Size = new System.Drawing.Size(563, 508);
            this.machineDetails.TabIndex = 5;
            this.machineDetails.TabStop = false;
            this.machineDetails.Text = "  Machine Details  ";
            this.machineDetails.Visible = false;
            // 
            // editMinRef
            // 
            this.editMinRef.AutoSize = true;
            this.editMinRef.Location = new System.Drawing.Point(480, 332);
            this.editMinRef.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editMinRef.Name = "editMinRef";
            this.editMinRef.Size = new System.Drawing.Size(32, 17);
            this.editMinRef.TabIndex = 44;
            this.editMinRef.TabStop = true;
            this.editMinRef.Text = "Edit";
            this.editMinRef.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editMinRef.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblMinRef
            // 
            this.lblMinRef.Location = new System.Drawing.Point(225, 332);
            this.lblMinRef.Name = "lblMinRef";
            this.lblMinRef.Size = new System.Drawing.Size(240, 16);
            this.lblMinRef.TabIndex = 43;
            this.lblMinRef.Text = "Nome:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(36, 332);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(161, 17);
            this.label22.TabIndex = 42;
            this.label22.Text = "Min. Refr. DataRead:";
            // 
            // editIcon
            // 
            this.editIcon.AutoSize = true;
            this.editIcon.Location = new System.Drawing.Point(480, 303);
            this.editIcon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editIcon.Name = "editIcon";
            this.editIcon.Size = new System.Drawing.Size(32, 17);
            this.editIcon.TabIndex = 41;
            this.editIcon.TabStop = true;
            this.editIcon.Text = "Edit";
            this.editIcon.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editIcon.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblIcon
            // 
            this.lblIcon.Location = new System.Drawing.Point(225, 303);
            this.lblIcon.Name = "lblIcon";
            this.lblIcon.Size = new System.Drawing.Size(240, 16);
            this.lblIcon.TabIndex = 40;
            this.lblIcon.Text = "Nome:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(36, 303);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 17);
            this.label21.TabIndex = 39;
            this.label21.Text = "Icon:";
            // 
            // editGroup
            // 
            this.editGroup.AutoSize = true;
            this.editGroup.Location = new System.Drawing.Point(480, 154);
            this.editGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editGroup.Name = "editGroup";
            this.editGroup.Size = new System.Drawing.Size(32, 17);
            this.editGroup.TabIndex = 38;
            this.editGroup.TabStop = true;
            this.editGroup.Text = "Edit";
            this.editGroup.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editGroup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblGroup
            // 
            this.lblGroup.Location = new System.Drawing.Point(225, 154);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(240, 16);
            this.lblGroup.TabIndex = 37;
            this.lblGroup.Text = "Nome:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(36, 154);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(58, 17);
            this.label20.TabIndex = 36;
            this.label20.Text = "Group:";
            // 
            // editXMod
            // 
            this.editXMod.AutoSize = true;
            this.editXMod.Location = new System.Drawing.Point(480, 391);
            this.editXMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editXMod.Name = "editXMod";
            this.editXMod.Size = new System.Drawing.Size(32, 17);
            this.editXMod.TabIndex = 35;
            this.editXMod.TabStop = true;
            this.editXMod.Text = "Edit";
            this.editXMod.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editXMod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblXMod
            // 
            this.lblXMod.Location = new System.Drawing.Point(225, 391);
            this.lblXMod.Name = "lblXMod";
            this.lblXMod.Size = new System.Drawing.Size(240, 16);
            this.lblXMod.TabIndex = 34;
            this.lblXMod.Text = "Nome:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(36, 391);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(150, 17);
            this.label19.TabIndex = 33;
            this.label19.Text = "X Time Details Log:";
            // 
            // editMod
            // 
            this.editMod.AutoSize = true;
            this.editMod.Location = new System.Drawing.Point(480, 362);
            this.editMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editMod.Name = "editMod";
            this.editMod.Size = new System.Drawing.Size(32, 17);
            this.editMod.TabIndex = 32;
            this.editMod.TabStop = true;
            this.editMod.Text = "Edit";
            this.editMod.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editMod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblMod
            // 
            this.lblMod.Location = new System.Drawing.Point(225, 362);
            this.lblMod.Name = "lblMod";
            this.lblMod.Size = new System.Drawing.Size(240, 16);
            this.lblMod.TabIndex = 31;
            this.lblMod.Text = "Nome:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(36, 362);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 17);
            this.label18.TabIndex = 30;
            this.label18.Text = "Log Modality:";
            // 
            // editDatasWrite
            // 
            this.editDatasWrite.AutoSize = true;
            this.editDatasWrite.Location = new System.Drawing.Point(480, 450);
            this.editDatasWrite.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editDatasWrite.Name = "editDatasWrite";
            this.editDatasWrite.Size = new System.Drawing.Size(32, 17);
            this.editDatasWrite.TabIndex = 29;
            this.editDatasWrite.TabStop = true;
            this.editDatasWrite.Text = "Edit";
            this.editDatasWrite.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editDatasWrite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblCountDatasWrite
            // 
            this.lblCountDatasWrite.Location = new System.Drawing.Point(225, 450);
            this.lblCountDatasWrite.Name = "lblCountDatasWrite";
            this.lblCountDatasWrite.Size = new System.Drawing.Size(240, 16);
            this.lblCountDatasWrite.TabIndex = 28;
            this.lblCountDatasWrite.Text = "Nome:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(36, 450);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 17);
            this.label17.TabIndex = 27;
            this.label17.Text = "Datas Write:";
            // 
            // editDatasRead
            // 
            this.editDatasRead.AutoSize = true;
            this.editDatasRead.Location = new System.Drawing.Point(480, 421);
            this.editDatasRead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editDatasRead.Name = "editDatasRead";
            this.editDatasRead.Size = new System.Drawing.Size(32, 17);
            this.editDatasRead.TabIndex = 26;
            this.editDatasRead.TabStop = true;
            this.editDatasRead.Text = "Edit";
            this.editDatasRead.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editDatasRead.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblCountDatasRead
            // 
            this.lblCountDatasRead.Location = new System.Drawing.Point(225, 421);
            this.lblCountDatasRead.Name = "lblCountDatasRead";
            this.lblCountDatasRead.Size = new System.Drawing.Size(240, 16);
            this.lblCountDatasRead.TabIndex = 25;
            this.lblCountDatasRead.Text = "Nome:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(36, 421);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 17);
            this.label16.TabIndex = 24;
            this.label16.Text = "Datas Read:";
            // 
            // editImg
            // 
            this.editImg.AutoSize = true;
            this.editImg.Location = new System.Drawing.Point(480, 273);
            this.editImg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editImg.Name = "editImg";
            this.editImg.Size = new System.Drawing.Size(32, 17);
            this.editImg.TabIndex = 23;
            this.editImg.TabStop = true;
            this.editImg.Text = "Edit";
            this.editImg.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editImg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editPort
            // 
            this.editPort.AutoSize = true;
            this.editPort.Location = new System.Drawing.Point(480, 244);
            this.editPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editPort.Name = "editPort";
            this.editPort.Size = new System.Drawing.Size(32, 17);
            this.editPort.TabIndex = 22;
            this.editPort.TabStop = true;
            this.editPort.Text = "Edit";
            this.editPort.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editPort.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editAddress
            // 
            this.editAddress.AutoSize = true;
            this.editAddress.Location = new System.Drawing.Point(480, 214);
            this.editAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editAddress.Name = "editAddress";
            this.editAddress.Size = new System.Drawing.Size(32, 17);
            this.editAddress.TabIndex = 21;
            this.editAddress.TabStop = true;
            this.editAddress.Text = "Edit";
            this.editAddress.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editAddress.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editProtocol
            // 
            this.editProtocol.AutoSize = true;
            this.editProtocol.Location = new System.Drawing.Point(480, 183);
            this.editProtocol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editProtocol.Name = "editProtocol";
            this.editProtocol.Size = new System.Drawing.Size(32, 17);
            this.editProtocol.TabIndex = 20;
            this.editProtocol.TabStop = true;
            this.editProtocol.Text = "Edit";
            this.editProtocol.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editProtocol.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editType
            // 
            this.editType.AutoSize = true;
            this.editType.Location = new System.Drawing.Point(480, 124);
            this.editType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editType.Name = "editType";
            this.editType.Size = new System.Drawing.Size(32, 17);
            this.editType.TabIndex = 19;
            this.editType.TabStop = true;
            this.editType.Text = "Edit";
            this.editType.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editType.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editDesc
            // 
            this.editDesc.AutoSize = true;
            this.editDesc.Location = new System.Drawing.Point(480, 95);
            this.editDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editDesc.Name = "editDesc";
            this.editDesc.Size = new System.Drawing.Size(32, 17);
            this.editDesc.TabIndex = 18;
            this.editDesc.TabStop = true;
            this.editDesc.Text = "Edit";
            this.editDesc.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editDesc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // editName
            // 
            this.editName.AutoSize = true;
            this.editName.Location = new System.Drawing.Point(480, 65);
            this.editName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.editName.Name = "editName";
            this.editName.Size = new System.Drawing.Size(32, 17);
            this.editName.TabIndex = 17;
            this.editName.TabStop = true;
            this.editName.Text = "Edit";
            this.editName.VisitedLinkColor = System.Drawing.Color.Blue;
            this.editName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.edit_LinkClicked);
            // 
            // lblImg
            // 
            this.lblImg.Location = new System.Drawing.Point(225, 273);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(240, 16);
            this.lblImg.TabIndex = 15;
            this.lblImg.Text = "Nome:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(36, 273);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 17);
            this.label15.TabIndex = 14;
            this.label15.Text = "Image:";
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(225, 244);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(240, 16);
            this.lblPort.TabIndex = 13;
            this.lblPort.Text = "Nome:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(36, 244);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 17);
            this.label14.TabIndex = 12;
            this.label14.Text = "Port:";
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(225, 214);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(240, 16);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Nome:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(36, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 17);
            this.label13.TabIndex = 10;
            this.label13.Text = "Address:";
            // 
            // lblProtocol
            // 
            this.lblProtocol.Location = new System.Drawing.Point(225, 183);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(240, 16);
            this.lblProtocol.TabIndex = 9;
            this.lblProtocol.Text = "Nome:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(36, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 17);
            this.label12.TabIndex = 8;
            this.label12.Text = "Protocol:";
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(225, 124);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(240, 16);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Nome:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(36, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "Type:";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(225, 95);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(240, 16);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "Nome:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Description:";
            // 
            // lblNm
            // 
            this.lblNm.Location = new System.Drawing.Point(225, 65);
            this.lblNm.Name = "lblNm";
            this.lblNm.Size = new System.Drawing.Size(240, 16);
            this.lblNm.TabIndex = 3;
            this.lblNm.Text = "Nome:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Name:";
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(225, 36);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(240, 16);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Id:";
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
            // moveUp
            // 
            this.moveUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveUp.BackgroundImage")));
            this.moveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveUp.Enabled = false;
            this.moveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveUp.Location = new System.Drawing.Point(655, 81);
            this.moveUp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(40, 34);
            this.moveUp.TabIndex = 6;
            this.moveUp.UseVisualStyleBackColor = true;
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveDown.BackgroundImage")));
            this.moveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveDown.Enabled = false;
            this.moveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveDown.Location = new System.Drawing.Point(655, 153);
            this.moveDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(40, 34);
            this.moveDown.TabIndex = 7;
            this.moveDown.UseVisualStyleBackColor = true;
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // listBox1
            // 
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.Enabled = false;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(16, 66);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(285, 500);
            this.listBox1.TabIndex = 8;
            this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Machines";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 608);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.moveDown);
            this.Controls.Add(this.moveUp);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.machineDetails);
            this.Controls.Add(this.databaseDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TTMMC ConfigBuilder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStripList.ResumeLayout(false);
            this.databaseDetails.ResumeLayout(false);
            this.databaseDetails.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.machineDetails.ResumeLayout(false);
            this.machineDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem machineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog open;
        private System.Windows.Forms.SaveFileDialog export;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox databaseDetails;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem protocolToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
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
        private System.Windows.Forms.LinkLabel editMod;
        private System.Windows.Forms.Label lblMod;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.LinkLabel editXMod;
        private System.Windows.Forms.Label lblXMod;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.LinkLabel editGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.Button moveUp;
        private System.Windows.Forms.Button moveDown;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem protocolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupsToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel tsslNElem;
        public System.Windows.Forms.ToolStripStatusLabel tsslNProt;
        public System.Windows.Forms.ToolStripStatusLabel tsslNGroup;
        private System.Windows.Forms.LinkLabel editIcon;
        private System.Windows.Forms.Label lblIcon;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.LinkLabel editMinRef;
        private System.Windows.Forms.Label lblMinRef;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    }
}

