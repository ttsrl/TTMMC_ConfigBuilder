namespace TTMMC_ConfigBuilder
{
    partial class inputList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inputList));
            this.btt_ok = new System.Windows.Forms.Button();
            this.btt_edit = new System.Windows.Forms.Button();
            this.btt_delete = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btt_add = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btt_ok
            // 
            this.btt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btt_ok.Location = new System.Drawing.Point(247, 311);
            this.btt_ok.Name = "btt_ok";
            this.btt_ok.Size = new System.Drawing.Size(75, 28);
            this.btt_ok.TabIndex = 8;
            this.btt_ok.Text = "OK";
            this.btt_ok.UseVisualStyleBackColor = true;
            this.btt_ok.Click += new System.EventHandler(this.btt_ok_Click);
            // 
            // btt_edit
            // 
            this.btt_edit.Location = new System.Drawing.Point(236, 80);
            this.btt_edit.Name = "btt_edit";
            this.btt_edit.Size = new System.Drawing.Size(90, 28);
            this.btt_edit.TabIndex = 11;
            this.btt_edit.Text = "Edit";
            this.btt_edit.UseVisualStyleBackColor = true;
            this.btt_edit.Click += new System.EventHandler(this.btt_edit_Click);
            // 
            // btt_delete
            // 
            this.btt_delete.Location = new System.Drawing.Point(236, 126);
            this.btt_delete.Name = "btt_delete";
            this.btt_delete.Size = new System.Drawing.Size(90, 28);
            this.btt_delete.TabIndex = 12;
            this.btt_delete.Text = "Delete";
            this.btt_delete.UseVisualStyleBackColor = true;
            this.btt_delete.Click += new System.EventHandler(this.btt_delete_Click);
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
            this.btt_add.Size = new System.Drawing.Size(90, 28);
            this.btt_add.TabIndex = 14;
            this.btt_add.Text = "Add";
            this.btt_add.UseVisualStyleBackColor = true;
            this.btt_add.Click += new System.EventHandler(this.btt_add_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(8, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 15;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputList
            // 
            this.AcceptButton = this.btt_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btt_add);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btt_delete);
            this.Controls.Add(this.btt_edit);
            this.Controls.Add(this.btt_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inputList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List";
            this.Load += new System.EventHandler(this.editList_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btt_ok;
        private System.Windows.Forms.Button btt_edit;
        private System.Windows.Forms.Button btt_delete;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btt_add;
        private System.Windows.Forms.Button button1;
    }
}