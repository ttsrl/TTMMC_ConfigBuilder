namespace TTMMC_ConfigBuilder
{
    partial class editList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btt_ok = new System.Windows.Forms.Button();
            this.btt_rename = new System.Windows.Forms.Button();
            this.btt_remove = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btt_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btt_ok
            // 
            this.btt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btt_ok.Location = new System.Drawing.Point(251, 309);
            this.btt_ok.Name = "btt_ok";
            this.btt_ok.Size = new System.Drawing.Size(75, 23);
            this.btt_ok.TabIndex = 8;
            this.btt_ok.Text = "OK";
            this.btt_ok.UseVisualStyleBackColor = true;
            this.btt_ok.Click += new System.EventHandler(this.btt_ok_Click);
            // 
            // btt_rename
            // 
            this.btt_rename.Location = new System.Drawing.Point(236, 80);
            this.btt_rename.Name = "btt_rename";
            this.btt_rename.Size = new System.Drawing.Size(90, 23);
            this.btt_rename.TabIndex = 11;
            this.btt_rename.Text = "Rinomina";
            this.btt_rename.UseVisualStyleBackColor = true;
            this.btt_rename.Click += new System.EventHandler(this.btt_rename_Click);
            // 
            // btt_remove
            // 
            this.btt_remove.Location = new System.Drawing.Point(236, 126);
            this.btt_remove.Name = "btt_remove";
            this.btt_remove.Size = new System.Drawing.Size(90, 23);
            this.btt_remove.TabIndex = 12;
            this.btt_remove.Text = "Elimina";
            this.btt_remove.UseVisualStyleBackColor = true;
            this.btt_remove.Click += new System.EventHandler(this.btt_remove_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(218, 290);
            this.listBox1.TabIndex = 13;
            // 
            // btt_add
            // 
            this.btt_add.Location = new System.Drawing.Point(237, 35);
            this.btt_add.Name = "btt_add";
            this.btt_add.Size = new System.Drawing.Size(90, 23);
            this.btt_add.TabIndex = 14;
            this.btt_add.Text = "Aggiungi";
            this.btt_add.UseVisualStyleBackColor = true;
            this.btt_add.Click += new System.EventHandler(this.btt_add_Click);
            // 
            // editList
            // 
            this.AcceptButton = this.btt_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 344);
            this.Controls.Add(this.btt_add);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btt_remove);
            this.Controls.Add(this.btt_rename);
            this.Controls.Add(this.btt_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "editList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifica";
            this.Load += new System.EventHandler(this.editList_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btt_ok;
        private System.Windows.Forms.Button btt_rename;
        private System.Windows.Forms.Button btt_remove;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btt_add;
    }
}