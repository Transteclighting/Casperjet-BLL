namespace CJ.Win.CSD
{
    partial class frmCSDSMSHistory
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwCSDSMSHistory = new System.Windows.Forms.ListView();
            this.colJobNo = new System.Windows.Forms.ColumnHeader();
            this.colServiceType = new System.Windows.Forms.ColumnHeader();
            this.colSMSModelStatus = new System.Windows.Forms.ColumnHeader();
            this.colSendTo = new System.Windows.Forms.ColumnHeader();
            this.colSmsText = new System.Windows.Forms.ColumnHeader();
            this.colLength = new System.Windows.Forms.ColumnHeader();
            this.colMobileNo = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colCreateUseName = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.colOriginalSMS = new System.Windows.Forms.ColumnHeader();
            this.colUpdateBy = new System.Windows.Forms.ColumnHeader();
            this.colUpdateDate = new System.Windows.Forms.ColumnHeader();
            this.colCancelBy = new System.Windows.Forms.ColumnHeader();
            this.colCancelDate = new System.Windows.Forms.ColumnHeader();
            this.colCancelReason = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.ckbSelect = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblSent = new System.Windows.Forms.Label();
            this.lblUnsend = new System.Windows.Forms.Label();
            this.lblResent = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.lblRegenerate = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbSMSLength = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(869, 98);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 25);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwCSDSMSHistory
            // 
            this.lvwCSDSMSHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCSDSMSHistory.CheckBoxes = true;
            this.lvwCSDSMSHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colServiceType,
            this.colSMSModelStatus,
            this.colSendTo,
            this.colSmsText,
            this.colLength,
            this.colMobileNo,
            this.colStatus,
            this.colCreateUseName,
            this.colCreateDate,
            this.colOriginalSMS,
            this.colUpdateBy,
            this.colUpdateDate,
            this.colCancelBy,
            this.colCancelDate,
            this.colCancelReason});
            this.lvwCSDSMSHistory.FullRowSelect = true;
            this.lvwCSDSMSHistory.GridLines = true;
            this.lvwCSDSMSHistory.Location = new System.Drawing.Point(12, 98);
            this.lvwCSDSMSHistory.Name = "lvwCSDSMSHistory";
            this.lvwCSDSMSHistory.Size = new System.Drawing.Size(849, 350);
            this.lvwCSDSMSHistory.TabIndex = 10;
            this.lvwCSDSMSHistory.UseCompatibleStateImageBehavior = false;
            this.lvwCSDSMSHistory.View = System.Windows.Forms.View.Details;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 88;
            // 
            // colServiceType
            // 
            this.colServiceType.Text = "ServiceType";
            this.colServiceType.Width = 86;
            // 
            // colSMSModelStatus
            // 
            this.colSMSModelStatus.Text = "Model Status";
            this.colSMSModelStatus.Width = 92;
            // 
            // colSendTo
            // 
            this.colSendTo.Text = "Send To";
            this.colSendTo.Width = 198;
            // 
            // colSmsText
            // 
            this.colSmsText.Text = "SMS Text";
            this.colSmsText.Width = 277;
            // 
            // colLength
            // 
            this.colLength.Text = "Length";
            // 
            // colMobileNo
            // 
            this.colMobileNo.Text = "Mobile No";
            this.colMobileNo.Width = 101;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 78;
            // 
            // colCreateUseName
            // 
            this.colCreateUseName.Text = "Create Use Name";
            this.colCreateUseName.Width = 112;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 113;
            // 
            // colOriginalSMS
            // 
            this.colOriginalSMS.Text = "Original SMS";
            // 
            // colUpdateBy
            // 
            this.colUpdateBy.Text = "UpdateBy";
            // 
            // colUpdateDate
            // 
            this.colUpdateDate.Text = "UpdateDate";
            // 
            // colCancelBy
            // 
            this.colCancelBy.Text = "Cancel By";
            // 
            // colCancelDate
            // 
            this.colCancelDate.Text = "Cancel Date";
            // 
            // colCancelReason
            // 
            this.colCancelReason.Text = "Cancel Reason";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(867, 423);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 25);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(869, 124);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(86, 25);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Location = new System.Drawing.Point(487, 67);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(86, 25);
            this.btnGet.TabIndex = 8;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(62, 17);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(175, 20);
            this.txtJobNo.TabIndex = 1;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(62, 41);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(175, 20);
            this.txtMobileNo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "JobNo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mobile No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(303, 17);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(175, 21);
            this.cmbStatus.TabIndex = 5;
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoSize = true;
            this.ckbSelect.Location = new System.Drawing.Point(14, 75);
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Size = new System.Drawing.Size(83, 17);
            this.ckbSelect.TabIndex = 9;
            this.ckbSelect.Text = "Checked All";
            this.ckbSelect.UseVisualStyleBackColor = true;
            this.ckbSelect.CheckedChanged += new System.EventHandler(this.ckbSelect_CheckedChanged);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(869, 167);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(86, 25);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Send/Re-send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblSent
            // 
            this.lblSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSent.AutoSize = true;
            this.lblSent.Location = new System.Drawing.Point(11, 458);
            this.lblSent.Name = "lblSent";
            this.lblSent.Size = new System.Drawing.Size(29, 13);
            this.lblSent.TabIndex = 16;
            this.lblSent.Text = "Sent";
            // 
            // lblUnsend
            // 
            this.lblUnsend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUnsend.AutoSize = true;
            this.lblUnsend.Location = new System.Drawing.Point(155, 458);
            this.lblUnsend.Name = "lblUnsend";
            this.lblUnsend.Size = new System.Drawing.Size(44, 13);
            this.lblUnsend.TabIndex = 19;
            this.lblUnsend.Text = "Unsend";
            // 
            // lblResent
            // 
            this.lblResent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResent.AutoSize = true;
            this.lblResent.Location = new System.Drawing.Point(43, 458);
            this.lblResent.Name = "lblResent";
            this.lblResent.Size = new System.Drawing.Size(41, 13);
            this.lblResent.TabIndex = 17;
            this.lblResent.Text = "Resent";
            // 
            // lblCancel
            // 
            this.lblCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCancel.AutoSize = true;
            this.lblCancel.Location = new System.Drawing.Point(205, 458);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(40, 13);
            this.lblCancel.TabIndex = 20;
            this.lblCancel.Text = "Cancel";
            // 
            // lblRegenerate
            // 
            this.lblRegenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegenerate.AutoSize = true;
            this.lblRegenerate.Location = new System.Drawing.Point(87, 458);
            this.lblRegenerate.Name = "lblRegenerate";
            this.lblRegenerate.Size = new System.Drawing.Size(63, 13);
            this.lblRegenerate.TabIndex = 18;
            this.lblRegenerate.Text = "Regenerate";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(869, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 25);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbSMSLength
            // 
            this.cmbSMSLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSMSLength.FormattingEnabled = true;
            this.cmbSMSLength.Location = new System.Drawing.Point(303, 42);
            this.cmbSMSLength.Name = "cmbSMSLength";
            this.cmbSMSLength.Size = new System.Drawing.Size(175, 21);
            this.cmbSMSLength.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "SMS Length";
            // 
            // frmCSDSMSHistory
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(965, 482);
            this.Controls.Add(this.cmbSMSLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblRegenerate);
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.lblResent);
            this.Controls.Add(this.lblUnsend);
            this.Controls.Add(this.lblSent);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.ckbSelect);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwCSDSMSHistory);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCSDSMSHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSD SMS History";
            this.Load += new System.EventHandler(this.frmCSDSMSHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwCSDSMSHistory;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colSmsText;
        private System.Windows.Forms.ColumnHeader colMobileNo;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colCreateUseName;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colServiceType;
        private System.Windows.Forms.ColumnHeader colSMSModelStatus;
        private System.Windows.Forms.ColumnHeader colSendTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.CheckBox ckbSelect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblSent;
        private System.Windows.Forms.Label lblUnsend;
        private System.Windows.Forms.Label lblResent;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Label lblRegenerate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colOriginalSMS;
        private System.Windows.Forms.ColumnHeader colLength;
        private System.Windows.Forms.ComboBox cmbSMSLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader colUpdateBy;
        private System.Windows.Forms.ColumnHeader colUpdateDate;
        private System.Windows.Forms.ColumnHeader colCancelBy;
        private System.Windows.Forms.ColumnHeader colCancelDate;
        private System.Windows.Forms.ColumnHeader colCancelReason;
    }
}