namespace CJ.Win
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
            this.lvwSMSMessage = new System.Windows.Forms.ListView();
            this.colSMSID = new System.Windows.Forms.ColumnHeader();
            this.colSMSCode = new System.Windows.Forms.ColumnHeader();
            this.colJobNo = new System.Windows.Forms.ColumnHeader();
            this.colMobileNo = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colServerStatus = new System.Windows.Forms.ColumnHeader();
            this.colSMSType = new System.Windows.Forms.ColumnHeader();
            this.colCharCnt = new System.Windows.Forms.ColumnHeader();
            this.colSMSTEXT = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.colSentBy = new System.Windows.Forms.ColumnHeader();
            this.colSentDate = new System.Windows.Forms.ColumnHeader();
            this.colReSentBy = new System.Windows.Forms.ColumnHeader();
            this.colReSentDate = new System.Windows.Forms.ColumnHeader();
            this.colEditedBy = new System.Windows.Forms.ColumnHeader();
            this.colReGenReqBy = new System.Windows.Forms.ColumnHeader();
            this.colReGenReqDate = new System.Windows.Forms.ColumnHeader();
            this.colReGenReqReason = new System.Windows.Forms.ColumnHeader();
            this.colCancelledBy = new System.Windows.Forms.ColumnHeader();
            this.colCancelDate = new System.Windows.Forms.ColumnHeader();
            this.colCancelReason = new System.Windows.Forms.ColumnHeader();
            this.btnReSent = new System.Windows.Forms.Button();
            this.btnSent = new System.Windows.Forms.Button();
            this.btnGenerateSMS = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbSMSType = new System.Windows.Forms.ComboBox();
            this.txtSMSCode = new System.Windows.Forms.TextBox();
            this.lblSMSCode = new System.Windows.Forms.Label();
            this.All = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.ckbSelect = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSMSLenth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSvrStatus = new System.Windows.Forms.ComboBox();
            this.btnReqReGen = new System.Windows.Forms.Button();
            this.txtSMSID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pbtGenerate = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwSMSMessage
            // 
            this.lvwSMSMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSMSMessage.CheckBoxes = true;
            this.lvwSMSMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSMSID,
            this.colSMSCode,
            this.colJobNo,
            this.colMobileNo,
            this.colStatus,
            this.colServerStatus,
            this.colSMSType,
            this.colCharCnt,
            this.colSMSTEXT,
            this.colCreateDate,
            this.colSentBy,
            this.colSentDate,
            this.colReSentBy,
            this.colReSentDate,
            this.colEditedBy,
            this.colReGenReqBy,
            this.colReGenReqDate,
            this.colReGenReqReason,
            this.colCancelledBy,
            this.colCancelDate,
            this.colCancelReason});
            this.lvwSMSMessage.FullRowSelect = true;
            this.lvwSMSMessage.GridLines = true;
            this.lvwSMSMessage.Location = new System.Drawing.Point(0, 159);
            this.lvwSMSMessage.MultiSelect = false;
            this.lvwSMSMessage.Name = "lvwSMSMessage";
            this.lvwSMSMessage.Size = new System.Drawing.Size(692, 292);
            this.lvwSMSMessage.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwSMSMessage.TabIndex = 1;
            this.lvwSMSMessage.UseCompatibleStateImageBehavior = false;
            this.lvwSMSMessage.View = System.Windows.Forms.View.Details;
            this.lvwSMSMessage.DoubleClick += new System.EventHandler(this.lvwSMSMessage_DoubleClick);
            // 
            // colSMSID
            // 
            this.colSMSID.Text = "SMS ID";
            this.colSMSID.Width = 80;
            // 
            // colSMSCode
            // 
            this.colSMSCode.Text = "SMS Code";
            this.colSMSCode.Width = 130;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job Number";
            this.colJobNo.Width = 75;
            // 
            // colMobileNo
            // 
            this.colMobileNo.Text = "Mobile No";
            this.colMobileNo.Width = 100;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Local Status";
            this.colStatus.Width = 80;
            // 
            // colServerStatus
            // 
            this.colServerStatus.Text = "Server Status";
            this.colServerStatus.Width = 80;
            // 
            // colSMSType
            // 
            this.colSMSType.Text = "SMS Type";
            this.colSMSType.Width = 140;
            // 
            // colCharCnt
            // 
            this.colCharCnt.Text = "Length";
            // 
            // colSMSTEXT
            // 
            this.colSMSTEXT.Text = "SMS Text";
            this.colSMSTEXT.Width = 250;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 140;
            // 
            // colSentBy
            // 
            this.colSentBy.Text = "SentBy";
            this.colSentBy.Width = 100;
            // 
            // colSentDate
            // 
            this.colSentDate.Text = "Sent Date";
            this.colSentDate.Width = 100;
            // 
            // colReSentBy
            // 
            this.colReSentBy.Text = "Re-Sent By";
            this.colReSentBy.Width = 100;
            // 
            // colReSentDate
            // 
            this.colReSentDate.Text = "Re-Sent Date";
            this.colReSentDate.Width = 100;
            // 
            // colEditedBy
            // 
            this.colEditedBy.Text = "Edited By";
            this.colEditedBy.Width = 100;
            // 
            // colReGenReqBy
            // 
            this.colReGenReqBy.Text = "ReGenReq By";
            this.colReGenReqBy.Width = 100;
            // 
            // colReGenReqDate
            // 
            this.colReGenReqDate.Text = "ReGenReq Date";
            this.colReGenReqDate.Width = 100;
            // 
            // colReGenReqReason
            // 
            this.colReGenReqReason.Text = "ReGenReq Reason";
            this.colReGenReqReason.Width = 200;
            // 
            // colCancelledBy
            // 
            this.colCancelledBy.Text = "Cancelled By";
            this.colCancelledBy.Width = 100;
            // 
            // colCancelDate
            // 
            this.colCancelDate.Text = "Cancel Date";
            this.colCancelDate.Width = 100;
            // 
            // colCancelReason
            // 
            this.colCancelReason.Text = "Cancel Reason";
            this.colCancelReason.Width = 200;
            // 
            // btnReSent
            // 
            this.btnReSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReSent.Location = new System.Drawing.Point(700, 202);
            this.btnReSent.Name = "btnReSent";
            this.btnReSent.Size = new System.Drawing.Size(105, 27);
            this.btnReSent.TabIndex = 145;
            this.btnReSent.Tag = "M1.20";
            this.btnReSent.Text = "Re Send";
            this.btnReSent.UseVisualStyleBackColor = true;
            this.btnReSent.Click += new System.EventHandler(this.btnReSent_Click);
            // 
            // btnSent
            // 
            this.btnSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSent.BackColor = System.Drawing.SystemColors.Control;
            this.btnSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSent.Location = new System.Drawing.Point(700, 168);
            this.btnSent.Name = "btnSent";
            this.btnSent.Size = new System.Drawing.Size(105, 27);
            this.btnSent.TabIndex = 144;
            this.btnSent.Tag = "M1.18";
            this.btnSent.Text = "Send";
            this.btnSent.UseVisualStyleBackColor = false;
            this.btnSent.Click += new System.EventHandler(this.btnSentToServer_Click);
            // 
            // btnGenerateSMS
            // 
            this.btnGenerateSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateSMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateSMS.ForeColor = System.Drawing.Color.Green;
            this.btnGenerateSMS.Location = new System.Drawing.Point(700, 103);
            this.btnGenerateSMS.Name = "btnGenerateSMS";
            this.btnGenerateSMS.Size = new System.Drawing.Size(105, 42);
            this.btnGenerateSMS.TabIndex = 143;
            this.btnGenerateSMS.Text = "Generate SMS";
            this.btnGenerateSMS.UseVisualStyleBackColor = true;
            this.btnGenerateSMS.Click += new System.EventHandler(this.btnGenerateSMS_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(700, 379);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 27);
            this.btnCancel.TabIndex = 150;
            this.btnCancel.Tag = "";
            this.btnCancel.Text = "Cance&l";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(700, 316);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(105, 27);
            this.btnEdit.TabIndex = 148;
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(700, 453);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 149;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(229, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 192;
            this.label12.Text = "SMS Type";
            // 
            // cmbSMSType
            // 
            this.cmbSMSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSMSType.FormattingEnabled = true;
            this.cmbSMSType.Location = new System.Drawing.Point(296, 105);
            this.cmbSMSType.Name = "cmbSMSType";
            this.cmbSMSType.Size = new System.Drawing.Size(220, 21);
            this.cmbSMSType.TabIndex = 187;
            // 
            // txtSMSCode
            // 
            this.txtSMSCode.Location = new System.Drawing.Point(82, 58);
            this.txtSMSCode.Name = "txtSMSCode";
            this.txtSMSCode.Size = new System.Drawing.Size(134, 20);
            this.txtSMSCode.TabIndex = 186;
            // 
            // lblSMSCode
            // 
            this.lblSMSCode.AutoSize = true;
            this.lblSMSCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSMSCode.Location = new System.Drawing.Point(19, 61);
            this.lblSMSCode.Name = "lblSMSCode";
            this.lblSMSCode.Size = new System.Drawing.Size(62, 13);
            this.lblSMSCode.TabIndex = 191;
            this.lblSMSCode.Text = "SMSCode";
            // 
            // All
            // 
            this.All.AutoSize = true;
            this.All.Location = new System.Drawing.Point(314, 15);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(15, 14);
            this.All.TabIndex = 184;
            this.All.UseVisualStyleBackColor = true;
            this.All.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(332, 34);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 13);
            this.lblStatus.TabIndex = 190;
            this.lblStatus.Text = "Local Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(412, 31);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(103, 21);
            this.cmbStatus.TabIndex = 185;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(185, 15);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 189;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(3, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(75, 13);
            this.lblDate.TabIndex = 188;
            this.lblDate.Text = "Create Date";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(210, 12);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(99, 20);
            this.dtToDate.TabIndex = 183;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(82, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 182;
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoSize = true;
            this.ckbSelect.Location = new System.Drawing.Point(6, 136);
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Size = new System.Drawing.Size(83, 17);
            this.ckbSelect.TabIndex = 194;
            this.ckbSelect.Text = "Checked All";
            this.ckbSelect.UseVisualStyleBackColor = true;
            this.ckbSelect.CheckedChanged += new System.EventHandler(this.ckbSelect_CheckedChanged);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(460, 132);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(81, 24);
            this.btnGo.TabIndex = 193;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(361, 461);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 197;
            this.label6.Text = "Sent";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(436, 461);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 196;
            this.label7.Text = "Re-Sent";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(284, 461);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 195;
            this.label8.Text = "Un Send";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(603, 461);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 198;
            this.label2.Text = "Cancel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(82, 82);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(134, 20);
            this.txtMobileNo.TabIndex = 199;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 200;
            this.label1.Text = "Mobile No";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(82, 105);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(134, 20);
            this.txtJobNo.TabIndex = 201;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 202;
            this.label3.Text = "Job No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(333, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 205;
            this.label4.Text = "SMS Length";
            // 
            // cmbSMSLenth
            // 
            this.cmbSMSLenth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSMSLenth.FormattingEnabled = true;
            this.cmbSMSLenth.Location = new System.Drawing.Point(412, 80);
            this.cmbSMSLenth.Name = "cmbSMSLenth";
            this.cmbSMSLenth.Size = new System.Drawing.Size(104, 21);
            this.cmbSMSLenth.TabIndex = 204;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(326, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 207;
            this.label5.Text = "Server Status";
            // 
            // cmbSvrStatus
            // 
            this.cmbSvrStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSvrStatus.FormattingEnabled = true;
            this.cmbSvrStatus.Location = new System.Drawing.Point(412, 55);
            this.cmbSvrStatus.Name = "cmbSvrStatus";
            this.cmbSvrStatus.Size = new System.Drawing.Size(103, 21);
            this.cmbSvrStatus.TabIndex = 206;
            // 
            // btnReqReGen
            // 
            this.btnReqReGen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReqReGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReqReGen.Location = new System.Drawing.Point(700, 234);
            this.btnReqReGen.Name = "btnReqReGen";
            this.btnReqReGen.Size = new System.Drawing.Size(105, 39);
            this.btnReqReGen.TabIndex = 208;
            this.btnReqReGen.Tag = "M1.20";
            this.btnReqReGen.Text = "Request For Re-Generate";
            this.btnReqReGen.UseVisualStyleBackColor = true;
            this.btnReqReGen.Click += new System.EventHandler(this.btnReqReGen_Click);
            // 
            // txtSMSID
            // 
            this.txtSMSID.Location = new System.Drawing.Point(82, 35);
            this.txtSMSID.Name = "txtSMSID";
            this.txtSMSID.Size = new System.Drawing.Size(89, 20);
            this.txtSMSID.TabIndex = 209;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(29, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 210;
            this.label9.Text = "SMS ID";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSMSID);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbSvrStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbSMSLenth);
            this.groupBox1.Controls.Add(this.txtJobNo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMobileNo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbSMSType);
            this.groupBox1.Controls.Add(this.txtSMSCode);
            this.groupBox1.Controls.Add(this.lblSMSCode);
            this.groupBox1.Controls.Add(this.All);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Location = new System.Drawing.Point(12, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 131);
            this.groupBox1.TabIndex = 211;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.Thistle;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(511, 461);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 212;
            this.label10.Text = "Re Generate";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbtGenerate
            // 
            this.pbtGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbtGenerate.Location = new System.Drawing.Point(12, 457);
            this.pbtGenerate.Name = "pbtGenerate";
            this.pbtGenerate.Size = new System.Drawing.Size(252, 23);
            this.pbtGenerate.TabIndex = 213;
            this.pbtGenerate.Visible = false;
            // 
            // frmSMSMessages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 490);
            this.Controls.Add(this.pbtGenerate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReqReGen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ckbSelect);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReSent);
            this.Controls.Add(this.btnSent);
            this.Controls.Add(this.btnGenerateSMS);
            this.Controls.Add(this.lvwSMSMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSMSMessages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CSD Messages";
            this.Load += new System.EventHandler(this.frmSMSMessages_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwSMSMessage;
        private System.Windows.Forms.ColumnHeader colSMSCode;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colSMSTEXT;
        private System.Windows.Forms.ColumnHeader colMobileNo;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colSMSType;
        private System.Windows.Forms.Button btnReSent;
        private System.Windows.Forms.Button btnSent;
        private System.Windows.Forms.Button btnGenerateSMS;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbSMSType;
        private System.Windows.Forms.TextBox txtSMSCode;
        private System.Windows.Forms.Label lblSMSCode;
        private System.Windows.Forms.CheckBox All;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.CheckBox ckbSelect;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colCharCnt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSMSLenth;
        private System.Windows.Forms.ColumnHeader colSMSID;
        private System.Windows.Forms.ColumnHeader colSentBy;
        private System.Windows.Forms.ColumnHeader colSentDate;
        private System.Windows.Forms.ColumnHeader colReSentBy;
        private System.Windows.Forms.ColumnHeader colReSentDate;
        private System.Windows.Forms.ColumnHeader colEditedBy;
        private System.Windows.Forms.ColumnHeader colReGenReqBy;
        private System.Windows.Forms.ColumnHeader colReGenReqDate;
        private System.Windows.Forms.ColumnHeader colReGenReqReason;
        private System.Windows.Forms.ColumnHeader colCancelledBy;
        private System.Windows.Forms.ColumnHeader colCancelDate;
        private System.Windows.Forms.ColumnHeader colCancelReason;
        private System.Windows.Forms.ColumnHeader colServerStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSvrStatus;
        private System.Windows.Forms.Button btnReqReGen;
        private System.Windows.Forms.TextBox txtSMSID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ProgressBar pbtGenerate;
    }
}