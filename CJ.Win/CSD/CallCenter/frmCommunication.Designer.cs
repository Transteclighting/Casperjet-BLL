namespace CJ.Win.CSD.CallCenter
{
    partial class frmCommunication
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
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dtNxtFeedbackDate = new System.Windows.Forms.DateTimePicker();
            this.chkRemindMeLater = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNextFollowupDate = new System.Windows.Forms.Label();
            this.chkConversationComplete = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNoResponse = new System.Windows.Forms.CheckBox();
            this.rdoApproved = new System.Windows.Forms.RadioButton();
            this.rdoDenied = new System.Windows.Forms.RadioButton();
            this.gbEstimate = new System.Windows.Forms.GroupBox();
            this.lvwConversationList = new System.Windows.Forms.ListView();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colConversation = new System.Windows.Forms.ColumnHeader();
            this.colContactBy = new System.Windows.Forms.ColumnHeader();
            this.colCallType = new System.Windows.Forms.ColumnHeader();
            this.colMode = new System.Windows.Forms.ColumnHeader();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnChangeFeedbackDate = new System.Windows.Forms.Button();
            this.lvwSMS = new System.Windows.Forms.ListView();
            this.colM_date = new System.Windows.Forms.ColumnHeader();
            this.colText = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colCreateUser = new System.Windows.Forms.ColumnHeader();
            this.colIgnore = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.gbEstimate.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(17, 32);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(560, 55);
            this.txtRemarks.TabIndex = 0;
            // 
            // dtNxtFeedbackDate
            // 
            this.dtNxtFeedbackDate.CustomFormat = "dd-MMM-yyyy";
            this.dtNxtFeedbackDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNxtFeedbackDate.Location = new System.Drawing.Point(270, 99);
            this.dtNxtFeedbackDate.Name = "dtNxtFeedbackDate";
            this.dtNxtFeedbackDate.Size = new System.Drawing.Size(117, 20);
            this.dtNxtFeedbackDate.TabIndex = 1;
            // 
            // chkRemindMeLater
            // 
            this.chkRemindMeLater.AutoSize = true;
            this.chkRemindMeLater.Location = new System.Drawing.Point(19, 99);
            this.chkRemindMeLater.Name = "chkRemindMeLater";
            this.chkRemindMeLater.Size = new System.Drawing.Size(107, 17);
            this.chkRemindMeLater.TabIndex = 2;
            this.chkRemindMeLater.Text = "Remind Me Later";
            this.chkRemindMeLater.UseVisualStyleBackColor = true;
            this.chkRemindMeLater.CheckedChanged += new System.EventHandler(this.chkRemindMeLater_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Conversation Text";
            // 
            // lblNextFollowupDate
            // 
            this.lblNextFollowupDate.AutoSize = true;
            this.lblNextFollowupDate.Location = new System.Drawing.Point(168, 102);
            this.lblNextFollowupDate.Name = "lblNextFollowupDate";
            this.lblNextFollowupDate.Size = new System.Drawing.Size(100, 13);
            this.lblNextFollowupDate.TabIndex = 4;
            this.lblNextFollowupDate.Text = "Next Followup Date";
            // 
            // chkConversationComplete
            // 
            this.chkConversationComplete.AutoSize = true;
            this.chkConversationComplete.Location = new System.Drawing.Point(442, 91);
            this.chkConversationComplete.Name = "chkConversationComplete";
            this.chkConversationComplete.Size = new System.Drawing.Size(135, 17);
            this.chkConversationComplete.TabIndex = 5;
            this.chkConversationComplete.Text = "Conversation Complete";
            this.chkConversationComplete.UseVisualStyleBackColor = true;
            this.chkConversationComplete.CheckedChanged += new System.EventHandler(this.chkConversationComplete_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNoResponse);
            this.groupBox1.Controls.Add(this.chkConversationComplete);
            this.groupBox1.Controls.Add(this.lblNextFollowupDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkRemindMeLater);
            this.groupBox1.Controls.Add(this.dtNxtFeedbackDate);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 128);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Conversation ";
            // 
            // chkNoResponse
            // 
            this.chkNoResponse.AutoSize = true;
            this.chkNoResponse.Location = new System.Drawing.Point(442, 108);
            this.chkNoResponse.Name = "chkNoResponse";
            this.chkNoResponse.Size = new System.Drawing.Size(91, 17);
            this.chkNoResponse.TabIndex = 6;
            this.chkNoResponse.Text = "No Response";
            this.chkNoResponse.UseVisualStyleBackColor = true;
            this.chkNoResponse.CheckedChanged += new System.EventHandler(this.chkNoResponse_CheckedChanged);
            // 
            // rdoApproved
            // 
            this.rdoApproved.AutoSize = true;
            this.rdoApproved.Location = new System.Drawing.Point(39, 14);
            this.rdoApproved.Name = "rdoApproved";
            this.rdoApproved.Size = new System.Drawing.Size(132, 17);
            this.rdoApproved.TabIndex = 7;
            this.rdoApproved.TabStop = true;
            this.rdoApproved.Text = "Approved by Customer";
            this.rdoApproved.UseVisualStyleBackColor = true;
            // 
            // rdoDenied
            // 
            this.rdoDenied.AutoSize = true;
            this.rdoDenied.Location = new System.Drawing.Point(180, 14);
            this.rdoDenied.Name = "rdoDenied";
            this.rdoDenied.Size = new System.Drawing.Size(120, 17);
            this.rdoDenied.TabIndex = 8;
            this.rdoDenied.TabStop = true;
            this.rdoDenied.Text = "Denied by Customer";
            this.rdoDenied.UseVisualStyleBackColor = true;
            // 
            // gbEstimate
            // 
            this.gbEstimate.Controls.Add(this.rdoDenied);
            this.gbEstimate.Controls.Add(this.rdoApproved);
            this.gbEstimate.Location = new System.Drawing.Point(8, 133);
            this.gbEstimate.Name = "gbEstimate";
            this.gbEstimate.Size = new System.Drawing.Size(590, 41);
            this.gbEstimate.TabIndex = 9;
            this.gbEstimate.TabStop = false;
            this.gbEstimate.Text = "Estimate";
            // 
            // lvwConversationList
            // 
            this.lvwConversationList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colConversation,
            this.colContactBy,
            this.colCallType,
            this.colMode});
            this.lvwConversationList.FullRowSelect = true;
            this.lvwConversationList.GridLines = true;
            this.lvwConversationList.HideSelection = false;
            this.lvwConversationList.Location = new System.Drawing.Point(8, 183);
            this.lvwConversationList.MultiSelect = false;
            this.lvwConversationList.Name = "lvwConversationList";
            this.lvwConversationList.Size = new System.Drawing.Size(588, 137);
            this.lvwConversationList.TabIndex = 223;
            this.lvwConversationList.UseCompatibleStateImageBehavior = false;
            this.lvwConversationList.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Communication Date";
            this.colDate.Width = 130;
            // 
            // colConversation
            // 
            this.colConversation.Text = "Conversation";
            this.colConversation.Width = 300;
            // 
            // colContactBy
            // 
            this.colContactBy.Text = "Contact By";
            this.colContactBy.Width = 130;
            // 
            // colCallType
            // 
            this.colCallType.Text = "Call Type";
            this.colCallType.Width = 80;
            // 
            // colMode
            // 
            this.colMode.Text = "Mode";
            this.colMode.Width = 80;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(439, 448);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 25);
            this.btnSave.TabIndex = 225;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(519, 448);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 25);
            this.btnClose.TabIndex = 224;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnChangeFeedbackDate
            // 
            this.btnChangeFeedbackDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeFeedbackDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeFeedbackDate.ForeColor = System.Drawing.Color.Red;
            this.btnChangeFeedbackDate.Location = new System.Drawing.Point(8, 448);
            this.btnChangeFeedbackDate.Name = "btnChangeFeedbackDate";
            this.btnChangeFeedbackDate.Size = new System.Drawing.Size(150, 26);
            this.btnChangeFeedbackDate.TabIndex = 226;
            this.btnChangeFeedbackDate.Text = "Change Feedback Date";
            this.btnChangeFeedbackDate.UseVisualStyleBackColor = true;
            this.btnChangeFeedbackDate.Click += new System.EventHandler(this.btnChangeFeedbackDate_Click);
            // 
            // lvwSMS
            // 
            this.lvwSMS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIgnore,
            this.colM_date,
            this.colText,
            this.colStatus,
            this.colCreateUser});
            this.lvwSMS.FullRowSelect = true;
            this.lvwSMS.GridLines = true;
            this.lvwSMS.HideSelection = false;
            this.lvwSMS.Location = new System.Drawing.Point(8, 329);
            this.lvwSMS.MultiSelect = false;
            this.lvwSMS.Name = "lvwSMS";
            this.lvwSMS.Size = new System.Drawing.Size(588, 110);
            this.lvwSMS.TabIndex = 227;
            this.lvwSMS.UseCompatibleStateImageBehavior = false;
            this.lvwSMS.View = System.Windows.Forms.View.Details;
            // 
            // colM_date
            // 
            this.colM_date.Text = "Date";
            this.colM_date.Width = 130;
            // 
            // colText
            // 
            this.colText.Text = "SMS Text";
            this.colText.Width = 300;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 80;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 130;
            // 
            // colIgnore
            // 
            this.colIgnore.Text = "";
            this.colIgnore.Width = 0;
            // 
            // frmCommunication
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 482);
            this.Controls.Add(this.lvwSMS);
            this.Controls.Add(this.btnChangeFeedbackDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwConversationList);
            this.Controls.Add(this.gbEstimate);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCommunication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Communication";
            this.Load += new System.EventHandler(this.frmCommunication_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbEstimate.ResumeLayout(false);
            this.gbEstimate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.DateTimePicker dtNxtFeedbackDate;
        private System.Windows.Forms.CheckBox chkRemindMeLater;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNextFollowupDate;
        private System.Windows.Forms.CheckBox chkConversationComplete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoApproved;
        private System.Windows.Forms.RadioButton rdoDenied;
        private System.Windows.Forms.GroupBox gbEstimate;
        private System.Windows.Forms.ListView lvwConversationList;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colConversation;
        private System.Windows.Forms.ColumnHeader colContactBy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colCallType;
        private System.Windows.Forms.ColumnHeader colMode;
        private System.Windows.Forms.CheckBox chkNoResponse;
        private System.Windows.Forms.Button btnChangeFeedbackDate;
        private System.Windows.Forms.ListView lvwSMS;
        private System.Windows.Forms.ColumnHeader colM_date;
        private System.Windows.Forms.ColumnHeader colText;
        private System.Windows.Forms.ColumnHeader colCreateUser;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colIgnore;
    }
}