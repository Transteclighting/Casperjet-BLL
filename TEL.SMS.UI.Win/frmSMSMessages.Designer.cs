namespace TEL.SMS.UI.Win
{
    partial class frmSMSMessages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSMSMessages));
            this.lvwSMSMessage = new System.Windows.Forms.ListView();
            this.colRequestDate = new System.Windows.Forms.ColumnHeader();
            this.colSMSMessage = new System.Windows.Forms.ColumnHeader();
            this.colSMSType = new System.Windows.Forms.ColumnHeader();
            this.colSMSStatus = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.colSuccessFail = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewSMSMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifySMSMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSMSMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPersonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboMessageStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnCancelled = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.tmrSMSMessages = new System.Windows.Forms.Timer(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.lvwSMSMessage.Location = new System.Drawing.Point(32, 68);
            this.lvwSMSMessage.Name = "lvwSMSMessage";
            this.lvwSMSMessage.Size = new System.Drawing.Size(863, 369);
            this.lvwSMSMessage.TabIndex = 24;
            this.lvwSMSMessage.UseCompatibleStateImageBehavior = false;
            this.lvwSMSMessage.View = System.Windows.Forms.View.Details;
            // 
            // colRequestDate
            // 
            this.colRequestDate.Text = "Request Date";
            this.colRequestDate.Width = 145;
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
            // modifySMSMessageToolStripMenuItem
            // 
            this.modifySMSMessageToolStripMenuItem.Name = "modifySMSMessageToolStripMenuItem";
            this.modifySMSMessageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.modifySMSMessageToolStripMenuItem.Text = "Modify SMS Group";
            // 
            // deleteSMSMessageToolStripMenuItem
            // 
            this.deleteSMSMessageToolStripMenuItem.Name = "deleteSMSMessageToolStripMenuItem";
            this.deleteSMSMessageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.deleteSMSMessageToolStripMenuItem.Text = "Delete SMS Group";
            // 
            // addPersonsToolStripMenuItem
            // 
            this.addPersonsToolStripMenuItem.Name = "addPersonsToolStripMenuItem";
            this.addPersonsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addPersonsToolStripMenuItem.Text = "Add persons";
            // 
            // cboMessageStatus
            // 
            this.cboMessageStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessageStatus.FormattingEnabled = true;
            this.cboMessageStatus.Location = new System.Drawing.Point(111, 39);
            this.cboMessageStatus.Name = "cboMessageStatus";
            this.cboMessageStatus.Size = new System.Drawing.Size(146, 21);
            this.cboMessageStatus.TabIndex = 25;
            this.cboMessageStatus.SelectedIndexChanged += new System.EventHandler(this.cboMessageStatus_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Status";
            // 
            // btnApproved
            // 
            this.btnApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproved.Location = new System.Drawing.Point(739, 8);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(75, 23);
            this.btnApproved.TabIndex = 27;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = true;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnCancelled
            // 
            this.btnCancelled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelled.Location = new System.Drawing.Point(820, 8);
            this.btnCancelled.Name = "btnCancelled";
            this.btnCancelled.Size = new System.Drawing.Size(75, 23);
            this.btnCancelled.TabIndex = 28;
            this.btnCancelled.Text = "Cancelled";
            this.btnCancelled.UseVisualStyleBackColor = true;
            this.btnCancelled.Click += new System.EventHandler(this.btnCancelled_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(423, 39);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 29;
            this.btnChange.Text = "Show";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // tmrSMSMessages
            // 
            this.tmrSMSMessages.Enabled = true;
            this.tmrSMSMessages.Interval = 600000;
            this.tmrSMSMessages.Tick += new System.EventHandler(this.tmrSMSMessages_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(342, 39);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(146, 20);
            this.dateTimePicker1.TabIndex = 31;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(352, 11);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(146, 20);
            this.dateTimePicker2.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "From Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "To Date";
            // 
            // frmSMSMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 456);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.btnCancelled);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.cboMessageStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwSMSMessage);
            this.Controls.Add(this.btnRefresh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSMSMessages";
            this.Text = "List of SMS Messagess";
            this.Load += new System.EventHandler(this.frmSMSMessages_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwSMSMessage;
        private System.Windows.Forms.ColumnHeader colSMSMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewSMSMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifySMSMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSMSMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPersonsToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colRequestDate;
        private System.Windows.Forms.ColumnHeader colSMSType;
        private System.Windows.Forms.ColumnHeader colSMSStatus;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ComboBox cboMessageStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Button btnCancelled;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Timer tmrSMSMessages;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ColumnHeader colSuccessFail;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}