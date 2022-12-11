namespace TEL.SMS.UI.Win
{
    partial class frmSMSMessageForGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSMSMessageForGroup));
            this.lvwSMSGroup = new System.Windows.Forms.ListView();
            this.colSMSGroupName = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSMSGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySMSGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSMSGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPersonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSMSMessage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpSubmitDate = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwSMSGroup
            // 
            this.lvwSMSGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwSMSGroup.CheckBoxes = true;
            this.lvwSMSGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSMSGroupName});
            this.lvwSMSGroup.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwSMSGroup.FullRowSelect = true;
            this.lvwSMSGroup.GridLines = true;
            this.lvwSMSGroup.HideSelection = false;
            this.lvwSMSGroup.Location = new System.Drawing.Point(15, 192);
            this.lvwSMSGroup.Name = "lvwSMSGroup";
            this.lvwSMSGroup.Size = new System.Drawing.Size(303, 137);
            this.lvwSMSGroup.TabIndex = 2;
            this.lvwSMSGroup.UseCompatibleStateImageBehavior = false;
            this.lvwSMSGroup.View = System.Windows.Forms.View.Details;
            // 
            // colSMSGroupName
            // 
            this.colSMSGroupName.Text = "Name";
            this.colSMSGroupName.Width = 282;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSMSGroupToolStripMenuItem,
            this.modifySMSGroupToolStripMenuItem,
            this.deleteSMSGroupToolStripMenuItem,
            this.addPersonsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 92);
            // 
            // addNewSMSGroupToolStripMenuItem
            // 
            this.addNewSMSGroupToolStripMenuItem.Name = "addNewSMSGroupToolStripMenuItem";
            this.addNewSMSGroupToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addNewSMSGroupToolStripMenuItem.Text = "Add new SMS Group";
            // 
            // modifySMSGroupToolStripMenuItem
            // 
            this.modifySMSGroupToolStripMenuItem.Name = "modifySMSGroupToolStripMenuItem";
            this.modifySMSGroupToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.modifySMSGroupToolStripMenuItem.Text = "Modify SMS Group";
            // 
            // deleteSMSGroupToolStripMenuItem
            // 
            this.deleteSMSGroupToolStripMenuItem.Name = "deleteSMSGroupToolStripMenuItem";
            this.deleteSMSGroupToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.deleteSMSGroupToolStripMenuItem.Text = "Delete SMS Group";
            // 
            // addPersonsToolStripMenuItem
            // 
            this.addPersonsToolStripMenuItem.Name = "addPersonsToolStripMenuItem";
            this.addPersonsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addPersonsToolStripMenuItem.Text = "Add persons";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Message (Max Char. 160)";
            // 
            // txtSMSMessage
            // 
            this.txtSMSMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMSMessage.Location = new System.Drawing.Point(15, 25);
            this.txtSMSMessage.MaxLength = 160;
            this.txtSMSMessage.Multiline = true;
            this.txtSMSMessage.Name = "txtSMSMessage";
            this.txtSMSMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSMSMessage.Size = new System.Drawing.Size(511, 161);
            this.txtSMSMessage.TabIndex = 1;
            this.txtSMSMessage.TextChanged += new System.EventHandler(this.txtSMSMessage_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Submission Date";
            // 
            // dtpSubmitDate
            // 
            this.dtpSubmitDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSubmitDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSubmitDate.Location = new System.Drawing.Point(425, 193);
            this.dtpSubmitDate.Name = "dtpSubmitDate";
            this.dtpSubmitDate.Size = new System.Drawing.Size(101, 20);
            this.dtpSubmitDate.TabIndex = 4;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(451, 306);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmSMSMessageForGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 341);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dtpSubmitDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSMSMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwSMSGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSMSMessageForGroup";
            this.Text = "SMS Message for Groups";
            this.Load += new System.EventHandler(this.frmSMSGroups_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwSMSGroup;
        private System.Windows.Forms.ColumnHeader colSMSGroupName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewSMSGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifySMSGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSMSGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPersonsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSMSMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpSubmitDate;
        private System.Windows.Forms.Button btnSubmit;
    }
}