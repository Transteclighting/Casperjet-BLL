namespace TEL.SMS.UI.Win
{
    partial class frmSMSMessagesIn
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
            this.addPersonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSMSMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySMSMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colSMSMessage = new System.Windows.Forms.ColumnHeader();
            this.colSMSType = new System.Windows.Forms.ColumnHeader();
            this.lvwSMSMessage = new System.Windows.Forms.ListView();
            this.colRequestDate = new System.Windows.Forms.ColumnHeader();
            this.colSMSStatus = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.colSuccessFail = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSMSMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addPersonsToolStripMenuItem
            // 
            this.addPersonsToolStripMenuItem.Name = "addPersonsToolStripMenuItem";
            this.addPersonsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addPersonsToolStripMenuItem.Text = "Add persons";
            // 
            // deleteSMSMessageToolStripMenuItem
            // 
            this.deleteSMSMessageToolStripMenuItem.Name = "deleteSMSMessageToolStripMenuItem";
            this.deleteSMSMessageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.deleteSMSMessageToolStripMenuItem.Text = "Delete SMS Group";
            // 
            // modifySMSMessageToolStripMenuItem
            // 
            this.modifySMSMessageToolStripMenuItem.Name = "modifySMSMessageToolStripMenuItem";
            this.modifySMSMessageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.modifySMSMessageToolStripMenuItem.Text = "Modify SMS Group";
            // 
            // colSMSMessage
            // 
            this.colSMSMessage.Text = "Message";
            this.colSMSMessage.Width = 506;
            // 
            // colSMSType
            // 
            this.colSMSType.Text = "SMS Type";
            this.colSMSType.Width = 75;
            // 
            // lvwSMSMessage
            // 
            this.lvwSMSMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSMSMessage.CheckBoxes = true;
            this.lvwSMSMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRequestDate,
            this.colSMSMessage,
            this.colSMSType,
            this.colSMSStatus,
            this.colUserName,
            this.colSuccessFail});
            this.lvwSMSMessage.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwSMSMessage.FullRowSelect = true;
            this.lvwSMSMessage.GridLines = true;
            this.lvwSMSMessage.HideSelection = false;
            this.lvwSMSMessage.Location = new System.Drawing.Point(12, 38);
            this.lvwSMSMessage.Name = "lvwSMSMessage";
            this.lvwSMSMessage.Size = new System.Drawing.Size(899, 398);
            this.lvwSMSMessage.TabIndex = 31;
            this.lvwSMSMessage.UseCompatibleStateImageBehavior = false;
            this.lvwSMSMessage.View = System.Windows.Forms.View.Details;
            // 
            // colRequestDate
            // 
            this.colRequestDate.Text = "Request Date";
            this.colRequestDate.Width = 145;
            // 
            // colSMSStatus
            // 
            this.colSMSStatus.Text = "Status";
            this.colSMSStatus.Width = 74;
            // 
            // colUserName
            // 
            this.colUserName.Text = "Submitted By";
            this.colUserName.Width = 150;
            // 
            // colSuccessFail
            // 
            this.colSuccessFail.Text = "Success / Fail";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSMSMessageToolStripMenuItem,
            this.modifySMSMessageToolStripMenuItem,
            this.deleteSMSMessageToolStripMenuItem,
            this.addPersonsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 92);
            // 
            // addNewSMSMessageToolStripMenuItem
            // 
            this.addNewSMSMessageToolStripMenuItem.Name = "addNewSMSMessageToolStripMenuItem";
            this.addNewSMSMessageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addNewSMSMessageToolStripMenuItem.Text = "Add new SMS Group";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(74, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 38;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(332, 12);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 39;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "From Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "To Date";
            // 
            // frmSMSMessagesIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 442);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.lvwSMSMessage);
            this.Name = "frmSMSMessagesIn";
            this.Text = "frmSMSMessageIn";
            this.Load += new System.EventHandler(this.frmSMSMessagesIn_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem addPersonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSMSMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifySMSMessageToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colSMSMessage;
        private System.Windows.Forms.ColumnHeader colSMSType;
        private System.Windows.Forms.ListView lvwSMSMessage;
        private System.Windows.Forms.ColumnHeader colRequestDate;
        private System.Windows.Forms.ColumnHeader colSMSStatus;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ColumnHeader colSuccessFail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewSMSMessageToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

    }
}