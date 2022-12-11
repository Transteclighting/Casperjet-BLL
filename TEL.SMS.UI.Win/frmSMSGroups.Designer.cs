namespace TEL.SMS.UI.Win
{
    partial class frmSMSGroups
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSMSGroups));
            this.lvwSMSGroup = new System.Windows.Forms.ListView();
            this.colSMSGroupName = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSMSGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySMSGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSMSGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPersonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwSMSGroup
            // 
            this.lvwSMSGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSMSGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSMSGroupName});
            this.lvwSMSGroup.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwSMSGroup.FullRowSelect = true;
            this.lvwSMSGroup.GridLines = true;
            this.lvwSMSGroup.HideSelection = false;
            this.lvwSMSGroup.Location = new System.Drawing.Point(12, 12);
            this.lvwSMSGroup.Name = "lvwSMSGroup";
            this.lvwSMSGroup.Size = new System.Drawing.Size(514, 317);
            this.lvwSMSGroup.TabIndex = 24;
            this.lvwSMSGroup.UseCompatibleStateImageBehavior = false;
            this.lvwSMSGroup.View = System.Windows.Forms.View.Details;
            this.lvwSMSGroup.DoubleClick += new System.EventHandler(this.lvwSMSGroup_DoubleClick);
            // 
            // colSMSGroupName
            // 
            this.colSMSGroupName.Text = "Name";
            this.colSMSGroupName.Width = 491;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSMSGroupToolStripMenuItem,
            this.modifySMSGroupToolStripMenuItem,
            this.deleteSMSGroupToolStripMenuItem,
            this.addPersonsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 114);
            // 
            // addNewSMSGroupToolStripMenuItem
            // 
            this.addNewSMSGroupToolStripMenuItem.Name = "addNewSMSGroupToolStripMenuItem";
            this.addNewSMSGroupToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addNewSMSGroupToolStripMenuItem.Text = "Add new SMS Group";
            this.addNewSMSGroupToolStripMenuItem.Click += new System.EventHandler(this.addNewSMSGroupToolStripMenuItem_Click);
            // 
            // modifySMSGroupToolStripMenuItem
            // 
            this.modifySMSGroupToolStripMenuItem.Name = "modifySMSGroupToolStripMenuItem";
            this.modifySMSGroupToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.modifySMSGroupToolStripMenuItem.Text = "Modify SMS Group";
            this.modifySMSGroupToolStripMenuItem.Click += new System.EventHandler(this.modifySMSGroupToolStripMenuItem_Click);
            // 
            // deleteSMSGroupToolStripMenuItem
            // 
            this.deleteSMSGroupToolStripMenuItem.Name = "deleteSMSGroupToolStripMenuItem";
            this.deleteSMSGroupToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.deleteSMSGroupToolStripMenuItem.Text = "Delete SMS Group";
            this.deleteSMSGroupToolStripMenuItem.Click += new System.EventHandler(this.deleteSMSGroupToolStripMenuItem_Click);
            // 
            // addPersonsToolStripMenuItem
            // 
            this.addPersonsToolStripMenuItem.Name = "addPersonsToolStripMenuItem";
            this.addPersonsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addPersonsToolStripMenuItem.Text = "Add persons";
            this.addPersonsToolStripMenuItem.Click += new System.EventHandler(this.addPersonsToolStripMenuItem_Click);
            // 
            // frmSMSGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 341);
            this.Controls.Add(this.lvwSMSGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSMSGroups";
            this.Text = "SMS Groups";
            this.Load += new System.EventHandler(this.frmSMSGroups_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwSMSGroup;
        private System.Windows.Forms.ColumnHeader colSMSGroupName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewSMSGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifySMSGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSMSGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPersonsToolStripMenuItem;
    }
}