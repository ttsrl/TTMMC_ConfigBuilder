
namespace TTMMC_ConfigBuilder
{
    partial class inputListRecipes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inputListRecipes));
            this.button1 = new System.Windows.Forms.Button();
            this.btt_add = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btt_delete = new System.Windows.Forms.Button();
            this.btt_edit = new System.Windows.Forms.Button();
            this.btt_ok = new System.Windows.Forms.Button();
            this.moveDown = new System.Windows.Forms.Button();
            this.moveUp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 27;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btt_add
            // 
            this.btt_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btt_add.Location = new System.Drawing.Point(291, 12);
            this.btt_add.Name = "btt_add";
            this.btt_add.Size = new System.Drawing.Size(90, 28);
            this.btt_add.TabIndex = 26;
            this.btt_add.Text = "Add";
            this.btt_add.UseVisualStyleBackColor = true;
            this.btt_add.Click += new System.EventHandler(this.btt_add_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(218, 290);
            this.listBox1.TabIndex = 25;
            // 
            // btt_delete
            // 
            this.btt_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btt_delete.Location = new System.Drawing.Point(290, 103);
            this.btt_delete.Name = "btt_delete";
            this.btt_delete.Size = new System.Drawing.Size(90, 28);
            this.btt_delete.TabIndex = 24;
            this.btt_delete.Text = "Delete";
            this.btt_delete.UseVisualStyleBackColor = true;
            this.btt_delete.Click += new System.EventHandler(this.btt_delete_Click);
            // 
            // btt_edit
            // 
            this.btt_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btt_edit.Location = new System.Drawing.Point(290, 57);
            this.btt_edit.Name = "btt_edit";
            this.btt_edit.Size = new System.Drawing.Size(90, 28);
            this.btt_edit.TabIndex = 23;
            this.btt_edit.Text = "Edit";
            this.btt_edit.UseVisualStyleBackColor = true;
            this.btt_edit.Click += new System.EventHandler(this.btt_edit_Click);
            // 
            // btt_ok
            // 
            this.btt_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btt_ok.Location = new System.Drawing.Point(306, 311);
            this.btt_ok.Name = "btt_ok";
            this.btt_ok.Size = new System.Drawing.Size(75, 28);
            this.btt_ok.TabIndex = 22;
            this.btt_ok.Text = "OK";
            this.btt_ok.UseVisualStyleBackColor = true;
            this.btt_ok.Click += new System.EventHandler(this.btt_ok_Click);
            // 
            // moveDown
            // 
            this.moveDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveDown.BackgroundImage")));
            this.moveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveDown.Location = new System.Drawing.Point(236, 70);
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(30, 28);
            this.moveDown.TabIndex = 29;
            this.moveDown.UseVisualStyleBackColor = true;
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // moveUp
            // 
            this.moveUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("moveUp.BackgroundImage")));
            this.moveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveUp.Location = new System.Drawing.Point(236, 12);
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(30, 28);
            this.moveUp.TabIndex = 28;
            this.moveUp.UseVisualStyleBackColor = true;
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // inputListRecipes
            // 
            this.AcceptButton = this.btt_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 351);
            this.Controls.Add(this.moveDown);
            this.Controls.Add(this.moveUp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btt_add);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btt_delete);
            this.Controls.Add(this.btt_edit);
            this.Controls.Add(this.btt_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "inputListRecipes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Recipes";
            this.Load += new System.EventHandler(this.inputListRecipes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btt_add;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btt_delete;
        private System.Windows.Forms.Button btt_edit;
        private System.Windows.Forms.Button btt_ok;
        private System.Windows.Forms.Button moveDown;
        private System.Windows.Forms.Button moveUp;
    }
}