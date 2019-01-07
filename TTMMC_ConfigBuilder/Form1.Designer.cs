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
            this.menuStrip1.SuspendLayout();
            this.databaseDetails.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aggiungiToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            this.nuovoToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.nuovoToolStripMenuItem.Text = "Nuovo";
            this.nuovoToolStripMenuItem.Click += new System.EventHandler(this.NuovoToolStripMenuItem_Click);
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            this.apriToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.apriToolStripMenuItem.Text = "Apri";
            this.apriToolStripMenuItem.Click += new System.EventHandler(this.ApriToolStripMenuItem_Click);
            // 
            // chiudiStripMenuItem2
            // 
            this.chiudiStripMenuItem2.Enabled = false;
            this.chiudiStripMenuItem2.Name = "chiudiStripMenuItem2";
            this.chiudiStripMenuItem2.Size = new System.Drawing.Size(113, 22);
            this.chiudiStripMenuItem2.Text = "Chiudi";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // esportaToolStripMenuItem
            // 
            this.esportaToolStripMenuItem.Enabled = false;
            this.esportaToolStripMenuItem.Name = "esportaToolStripMenuItem";
            this.esportaToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.esportaToolStripMenuItem.Text = "Esporta";
            this.esportaToolStripMenuItem.Click += new System.EventHandler(this.esportaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(110, 6);
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
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
            this.aggiungiToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aggiungiToolStripMenuItem.Text = "Aggiungi";
            // 
            // protocolloToolStripMenuItem
            // 
            this.protocolloToolStripMenuItem.Name = "protocolloToolStripMenuItem";
            this.protocolloToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.protocolloToolStripMenuItem.Text = "Protocollo";
            this.protocolloToolStripMenuItem.Click += new System.EventHandler(this.ProtocolloToolStripMenuItem_Click);
            // 
            // tipologiaMacchinaToolStripMenuItem
            // 
            this.tipologiaMacchinaToolStripMenuItem.Name = "tipologiaMacchinaToolStripMenuItem";
            this.tipologiaMacchinaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tipologiaMacchinaToolStripMenuItem.Text = "Tipologia Macchina";
            this.tipologiaMacchinaToolStripMenuItem.Click += new System.EventHandler(this.TipologiaMacchinaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.DatabaseToolStripMenuItem_Click);
            // 
            // macchinaToolStripMenuItem
            // 
            this.macchinaToolStripMenuItem.Name = "macchinaToolStripMenuItem";
            this.macchinaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.listBox1.Size = new System.Drawing.Size(251, 381);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
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
            this.databaseDetails.Size = new System.Drawing.Size(507, 158);
            this.databaseDetails.TabIndex = 3;
            this.databaseDetails.TabStop = false;
            this.databaseDetails.Text = "  Dettagli Database  ";
            this.databaseDetails.Visible = false;
            // 
            // reqinfoLbl
            // 
            this.reqinfoLbl.AutoSize = true;
            this.reqinfoLbl.Location = new System.Drawing.Point(114, 125);
            this.reqinfoLbl.Name = "reqinfoLbl";
            this.reqinfoLbl.Size = new System.Drawing.Size(32, 13);
            this.reqinfoLbl.TabIndex = 9;
            this.reqinfoLbl.Text = "Host:";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.Location = new System.Drawing.Point(114, 101);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(32, 13);
            this.passwordLbl.TabIndex = 8;
            this.passwordLbl.Text = "Host:";
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.Location = new System.Drawing.Point(114, 77);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(32, 13);
            this.usernameLbl.TabIndex = 7;
            this.usernameLbl.Text = "Host:";
            // 
            // dbLbl
            // 
            this.dbLbl.AutoSize = true;
            this.dbLbl.Location = new System.Drawing.Point(114, 53);
            this.dbLbl.Name = "dbLbl";
            this.dbLbl.Size = new System.Drawing.Size(32, 13);
            this.dbLbl.TabIndex = 6;
            this.dbLbl.Text = "Host:";
            // 
            // ipLbl
            // 
            this.ipLbl.AutoSize = true;
            this.ipLbl.Location = new System.Drawing.Point(114, 29);
            this.ipLbl.Name = "ipLbl";
            this.ipLbl.Size = new System.Drawing.Size(32, 13);
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
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslNElem,
            this.toolStripStatusLabel3,
            this.tsslNProt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
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
            // machineDetails
            // 
            this.machineDetails.Location = new System.Drawing.Point(278, 48);
            this.machineDetails.Name = "machineDetails";
            this.machineDetails.Size = new System.Drawing.Size(507, 387);
            this.machineDetails.TabIndex = 5;
            this.machineDetails.TabStop = false;
            this.machineDetails.Text = "  Dettagli Macchina  ";
            this.machineDetails.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.machineDetails);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.databaseDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TTMMC ConfigBuilder";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.databaseDetails.ResumeLayout(false);
            this.databaseDetails.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
    }
}

