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
            this.machineDetails = new System.Windows.Forms.GroupBox();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // nuovoToolStripMenuItem
            // 
            this.nuovoToolStripMenuItem.Name = "nuovoToolStripMenuItem";
            this.nuovoToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.nuovoToolStripMenuItem.Text = "Nuovo";
            this.nuovoToolStripMenuItem.Click += new System.EventHandler(this.NuovoToolStripMenuItem_Click);
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            this.apriToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.apriToolStripMenuItem.Text = "Apri";
            this.apriToolStripMenuItem.Click += new System.EventHandler(this.ApriToolStripMenuItem_Click);
            // 
            // chiudiStripMenuItem2
            // 
            this.chiudiStripMenuItem2.Enabled = false;
            this.chiudiStripMenuItem2.Name = "chiudiStripMenuItem2";
            this.chiudiStripMenuItem2.Size = new System.Drawing.Size(134, 26);
            this.chiudiStripMenuItem2.Text = "Chiudi";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // esportaToolStripMenuItem
            // 
            this.esportaToolStripMenuItem.Enabled = false;
            this.esportaToolStripMenuItem.Name = "esportaToolStripMenuItem";
            this.esportaToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.esportaToolStripMenuItem.Text = "Esporta";
            this.esportaToolStripMenuItem.Click += new System.EventHandler(this.esportaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(131, 6);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.esciToolStripMenuItem.Text = "Esci";
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
            this.aggiungiToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.aggiungiToolStripMenuItem.Text = "Aggiungi";
            // 
            // protocolloToolStripMenuItem
            // 
            this.protocolloToolStripMenuItem.Name = "protocolloToolStripMenuItem";
            this.protocolloToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.protocolloToolStripMenuItem.Text = "Protocollo";
            this.protocolloToolStripMenuItem.Click += new System.EventHandler(this.ProtocolloToolStripMenuItem_Click);
            // 
            // tipologiaMacchinaToolStripMenuItem
            // 
            this.tipologiaMacchinaToolStripMenuItem.Name = "tipologiaMacchinaToolStripMenuItem";
            this.tipologiaMacchinaToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.tipologiaMacchinaToolStripMenuItem.Text = "Tipologia Macchina";
            this.tipologiaMacchinaToolStripMenuItem.Click += new System.EventHandler(this.TipologiaMacchinaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(212, 6);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.DatabaseToolStripMenuItem_Click);
            // 
            // macchinaToolStripMenuItem
            // 
            this.macchinaToolStripMenuItem.Name = "macchinaToolStripMenuItem";
            this.macchinaToolStripMenuItem.Size = new System.Drawing.Size(215, 26);
            this.macchinaToolStripMenuItem.Text = "Macchina";
            this.macchinaToolStripMenuItem.Click += new System.EventHandler(this.MacchinaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 24);
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
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 66);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(333, 468);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Elementi";
            // 
            // databaseDetails
            // 
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
            this.databaseDetails.Location = new System.Drawing.Point(371, 59);
            this.databaseDetails.Margin = new System.Windows.Forms.Padding(4);
            this.databaseDetails.Name = "databaseDetails";
            this.databaseDetails.Padding = new System.Windows.Forms.Padding(4);
            this.databaseDetails.Size = new System.Drawing.Size(676, 194);
            this.databaseDetails.TabIndex = 3;
            this.databaseDetails.TabStop = false;
            this.databaseDetails.Text = "  Dettagli Database  ";
            this.databaseDetails.Visible = false;
            // 
            // reqinfoLbl
            // 
            this.reqinfoLbl.AutoSize = true;
            this.reqinfoLbl.Location = new System.Drawing.Point(152, 154);
            this.reqinfoLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.reqinfoLbl.Name = "reqinfoLbl";
            this.reqinfoLbl.Size = new System.Drawing.Size(41, 17);
            this.reqinfoLbl.TabIndex = 9;
            this.reqinfoLbl.Text = "Host:";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(152, 124);
            this.passwordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(41, 17);
            this.passwordLbl.TabIndex = 8;
            this.passwordLbl.Text = "Host:";
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(152, 95);
            this.usernameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(41, 17);
            this.usernameLbl.TabIndex = 7;
            this.usernameLbl.Text = "Host:";
            // 
            // dbLbl
            // 
            this.dbLbl.AutoSize = true;
            this.dbLbl.Location = new System.Drawing.Point(152, 65);
            this.dbLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dbLbl.Name = "dbLbl";
            this.dbLbl.Size = new System.Drawing.Size(41, 17);
            this.dbLbl.TabIndex = 6;
            this.dbLbl.Text = "Host:";
            // 
            // ipLbl
            // 
            this.ipLbl.AutoSize = true;
            this.ipLbl.Location = new System.Drawing.Point(152, 36);
            this.ipLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(41, 17);
            this.ipLbl.TabIndex = 5;
            this.ipLbl.Text = "Host:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 154);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "RequestSecInfo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 124);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Database:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
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
            this.tsslNProt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 556);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1067, 25);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(70, 20);
            this.toolStripStatusLabel1.Text = "Elementi:";
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
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(76, 20);
            this.toolStripStatusLabel3.Text = "Protocolli:";
            // 
            // tsslNProt
            // 
            this.tsslNProt.Name = "tsslNProt";
            this.tsslNProt.Size = new System.Drawing.Size(17, 20);
            this.tsslNProt.Text = "0";
            // 
            // machineDetails
            // 
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
            this.machineDetails.Location = new System.Drawing.Point(371, 59);
            this.machineDetails.Margin = new System.Windows.Forms.Padding(4);
            this.machineDetails.Name = "machineDetails";
            this.machineDetails.Padding = new System.Windows.Forms.Padding(4);
            this.machineDetails.Size = new System.Drawing.Size(676, 476);
            this.machineDetails.TabIndex = 5;
            this.machineDetails.TabStop = false;
            this.machineDetails.Text = "  Dettagli Macchina  ";
            this.machineDetails.Visible = false;
            // 
            // lblImg
            // 
            this.lblImg.AutoSize = true;
            this.lblImg.Location = new System.Drawing.Point(152, 244);
            this.lblImg.Name = "lblImg";
            this.lblImg.Size = new System.Drawing.Size(49, 17);
            this.lblImg.TabIndex = 15;
            this.lblImg.Text = "Nome:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(36, 244);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 17);
            this.label15.TabIndex = 14;
            this.label15.Text = "Immagine:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(152, 214);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(49, 17);
            this.lblPort.TabIndex = 13;
            this.lblPort.Text = "Nome:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(36, 214);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 17);
            this.label14.TabIndex = 12;
            this.label14.Text = "Porta:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(152, 184);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(49, 17);
            this.lblAddress.TabIndex = 11;
            this.lblAddress.Text = "Nome:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 184);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 17);
            this.label13.TabIndex = 10;
            this.label13.Text = "Indirizzo:";
            // 
            // lblProtocol
            // 
            this.lblProtocol.AutoSize = true;
            this.lblProtocol.Location = new System.Drawing.Point(152, 154);
            this.lblProtocol.Name = "lblProtocol";
            this.lblProtocol.Size = new System.Drawing.Size(49, 17);
            this.lblProtocol.TabIndex = 9;
            this.lblProtocol.Text = "Nome:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 17);
            this.label12.TabIndex = 8;
            this.label12.Text = "Protocollo:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(152, 124);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(49, 17);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Nome:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 6;
            this.label11.Text = "Tipo:";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(152, 95);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(49, 17);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "Nome:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Descrizione:";
            // 
            // lblNm
            // 
            this.lblNm.AutoSize = true;
            this.lblNm.Location = new System.Drawing.Point(152, 65);
            this.lblNm.Name = "lblNm";
            this.lblNm.Size = new System.Drawing.Size(49, 17);
            this.lblNm.TabIndex = 3;
            this.lblNm.Text = "Nome:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Nome:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(152, 36);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(49, 17);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
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
            this.menuStripList.Size = new System.Drawing.Size(138, 58);
            // 
            // modificaToolStripMenuItem
            // 
            this.modificaToolStripMenuItem.Name = "modificaToolStripMenuItem";
            this.modificaToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.modificaToolStripMenuItem.Text = "Modifica";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(207, 6);
            // 
            // eliminaToolStripMenuItem
            // 
            this.eliminaToolStripMenuItem.Name = "eliminaToolStripMenuItem";
            this.eliminaToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.eliminaToolStripMenuItem.Text = "Elimina";
            this.eliminaToolStripMenuItem.Click += new System.EventHandler(this.eliminaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 581);
            this.Controls.Add(this.machineDetails);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.databaseDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}

