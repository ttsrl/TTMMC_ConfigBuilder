namespace TTMMC_ConfigBuilder
{
    partial class inputTreeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inputTreeView));
            this.edit = new System.Windows.Forms.Button();
            this.addData = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.delete = new System.Windows.Forms.Button();
            this.addGroup = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // edit
            // 
            this.edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edit.Enabled = false;
            this.edit.Location = new System.Drawing.Point(449, 172);
            this.edit.Margin = new System.Windows.Forms.Padding(2);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(90, 28);
            this.edit.TabIndex = 33;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // addData
            // 
            this.addData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addData.Enabled = false;
            this.addData.Location = new System.Drawing.Point(449, 94);
            this.addData.Margin = new System.Windows.Forms.Padding(2);
            this.addData.Name = "addData";
            this.addData.Size = new System.Drawing.Size(90, 28);
            this.addData.TabIndex = 32;
            this.addData.Text = "Add Data";
            this.addData.UseVisualStyleBackColor = true;
            this.addData.Click += new System.EventHandler(this.addData_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.LabelEdit = true;
            this.treeView1.Location = new System.Drawing.Point(12, 34);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(422, 433);
            this.treeView1.TabIndex = 31;
            this.treeView1.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_BeforeLabelEdit);
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // delete
            // 
            this.delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delete.Enabled = false;
            this.delete.Location = new System.Drawing.Point(449, 254);
            this.delete.Margin = new System.Windows.Forms.Padding(2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(90, 28);
            this.delete.TabIndex = 30;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // addGroup
            // 
            this.addGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addGroup.Location = new System.Drawing.Point(449, 57);
            this.addGroup.Margin = new System.Windows.Forms.Padding(2);
            this.addGroup.Name = "addGroup";
            this.addGroup.Size = new System.Drawing.Size(90, 28);
            this.addGroup.TabIndex = 29;
            this.addGroup.Text = "Add Group";
            this.addGroup.UseVisualStyleBackColor = true;
            this.addGroup.Click += new System.EventHandler(this.addGroup_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Datas:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(12, 475);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 28);
            this.button2.TabIndex = 27;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(449, 475);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 28);
            this.button1.TabIndex = 26;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // inputTreeView
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 511);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.addData);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.addGroup);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inputTreeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Datas";
            this.Load += new System.EventHandler(this.editTreeView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button addData;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button addGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}