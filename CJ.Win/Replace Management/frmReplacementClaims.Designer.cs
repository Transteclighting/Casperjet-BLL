namespace CJ.Win.Replace_Management
{
    partial class frmReplacementClaims
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
            this.txtClaimNo = new System.Windows.Forms.TextBox();
            this.btnClaimAssess = new System.Windows.Forms.Button();
            this.btnClaimReceive = new System.Windows.Forms.Button();
            this.btnGenerateClaimNo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btGetData = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.txtSubClaimNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTeamRequired = new System.Windows.Forms.Button();
            this.btnReceiveToBeSend = new System.Windows.Forms.Button();
            this.btnPhysicallyReceive = new System.Windows.Forms.Button();
            this.btnSendToBLL = new System.Windows.Forms.Button();
            this.btnCheckingByAccount = new System.Windows.Forms.Button();
            this.btnWaitingForApproval = new System.Windows.Forms.Button();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnReplaced = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChkAll = new System.Windows.Forms.Button();
            this.lvwItemList = new System.Windows.Forms.ListView();
            this.colClaimNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubClaimNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colClaimDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValidationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubClaimStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEntryDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEntryUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtClaimNo
            // 
            this.txtClaimNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaimNo.Location = new System.Drawing.Point(64, 72);
            this.txtClaimNo.Name = "txtClaimNo";
            this.txtClaimNo.Size = new System.Drawing.Size(171, 20);
            this.txtClaimNo.TabIndex = 4;
            // 
            // btnClaimAssess
            // 
            this.btnClaimAssess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClaimAssess.Location = new System.Drawing.Point(740, 348);
            this.btnClaimAssess.Name = "btnClaimAssess";
            this.btnClaimAssess.Size = new System.Drawing.Size(121, 26);
            this.btnClaimAssess.TabIndex = 20;
            this.btnClaimAssess.Text = "Claim Assess";
            this.btnClaimAssess.UseVisualStyleBackColor = true;
            this.btnClaimAssess.Click += new System.EventHandler(this.btnClaimAssess_Click);
            // 
            // btnClaimReceive
            // 
            this.btnClaimReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClaimReceive.Location = new System.Drawing.Point(740, 188);
            this.btnClaimReceive.Name = "btnClaimReceive";
            this.btnClaimReceive.Size = new System.Drawing.Size(121, 26);
            this.btnClaimReceive.TabIndex = 15;
            this.btnClaimReceive.Text = "Claim Receive";
            this.btnClaimReceive.UseVisualStyleBackColor = true;
            this.btnClaimReceive.Click += new System.EventHandler(this.btnClaimReceive_Click);
            // 
            // btnGenerateClaimNo
            // 
            this.btnGenerateClaimNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateClaimNo.Location = new System.Drawing.Point(740, 156);
            this.btnGenerateClaimNo.Name = "btnGenerateClaimNo";
            this.btnGenerateClaimNo.Size = new System.Drawing.Size(121, 26);
            this.btnGenerateClaimNo.TabIndex = 14;
            this.btnGenerateClaimNo.Text = "Generate Claim No.";
            this.btnGenerateClaimNo.UseVisualStyleBackColor = true;
            this.btnGenerateClaimNo.Click += new System.EventHandler(this.btnGenerateClaimNo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(740, 540);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 26);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btGetData
            // 
            this.btGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGetData.Location = new System.Drawing.Point(495, 130);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(88, 25);
            this.btGetData.TabIndex = 11;
            this.btGetData.Text = "Get Data";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Claim No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(188, 24);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(102, 20);
            this.dtToDate.TabIndex = 2;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(52, 36);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(110, 20);
            this.dtFromDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(8, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // txtSubClaimNo
            // 
            this.txtSubClaimNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubClaimNo.Location = new System.Drawing.Point(318, 72);
            this.txtSubClaimNo.Name = "txtSubClaimNo";
            this.txtSubClaimNo.Size = new System.Drawing.Size(171, 20);
            this.txtSubClaimNo.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(241, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sub-Claim No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Customer:";
            // 
            // btnTeamRequired
            // 
            this.btnTeamRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTeamRequired.Location = new System.Drawing.Point(740, 220);
            this.btnTeamRequired.Name = "btnTeamRequired";
            this.btnTeamRequired.Size = new System.Drawing.Size(121, 26);
            this.btnTeamRequired.TabIndex = 16;
            this.btnTeamRequired.Text = "Team Required";
            this.btnTeamRequired.UseVisualStyleBackColor = true;
            this.btnTeamRequired.Click += new System.EventHandler(this.btnTeamRequired_Click);
            // 
            // btnReceiveToBeSend
            // 
            this.btnReceiveToBeSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceiveToBeSend.Location = new System.Drawing.Point(740, 252);
            this.btnReceiveToBeSend.Name = "btnReceiveToBeSend";
            this.btnReceiveToBeSend.Size = new System.Drawing.Size(121, 26);
            this.btnReceiveToBeSend.TabIndex = 17;
            this.btnReceiveToBeSend.Text = "Receive To Be Send";
            this.btnReceiveToBeSend.UseVisualStyleBackColor = true;
            this.btnReceiveToBeSend.Click += new System.EventHandler(this.btnReceiveToBeSend_Click);
            // 
            // btnPhysicallyReceive
            // 
            this.btnPhysicallyReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhysicallyReceive.Location = new System.Drawing.Point(740, 284);
            this.btnPhysicallyReceive.Name = "btnPhysicallyReceive";
            this.btnPhysicallyReceive.Size = new System.Drawing.Size(121, 26);
            this.btnPhysicallyReceive.TabIndex = 18;
            this.btnPhysicallyReceive.Text = "Physically Receive";
            this.btnPhysicallyReceive.UseVisualStyleBackColor = true;
            this.btnPhysicallyReceive.Click += new System.EventHandler(this.btnPhysicallyReceive_Click);
            // 
            // btnSendToBLL
            // 
            this.btnSendToBLL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendToBLL.Location = new System.Drawing.Point(740, 316);
            this.btnSendToBLL.Name = "btnSendToBLL";
            this.btnSendToBLL.Size = new System.Drawing.Size(121, 26);
            this.btnSendToBLL.TabIndex = 19;
            this.btnSendToBLL.Text = "Send To BLL";
            this.btnSendToBLL.UseVisualStyleBackColor = true;
            this.btnSendToBLL.Click += new System.EventHandler(this.btnSendToBLL_Click);
            // 
            // btnCheckingByAccount
            // 
            this.btnCheckingByAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckingByAccount.Location = new System.Drawing.Point(740, 380);
            this.btnCheckingByAccount.Name = "btnCheckingByAccount";
            this.btnCheckingByAccount.Size = new System.Drawing.Size(121, 26);
            this.btnCheckingByAccount.TabIndex = 21;
            this.btnCheckingByAccount.Text = "Checking By Account\r\n";
            this.btnCheckingByAccount.UseVisualStyleBackColor = true;
            this.btnCheckingByAccount.Click += new System.EventHandler(this.btnCheckingByAccount_Click);
            // 
            // btnWaitingForApproval
            // 
            this.btnWaitingForApproval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWaitingForApproval.Location = new System.Drawing.Point(740, 412);
            this.btnWaitingForApproval.Name = "btnWaitingForApproval";
            this.btnWaitingForApproval.Size = new System.Drawing.Size(121, 26);
            this.btnWaitingForApproval.TabIndex = 22;
            this.btnWaitingForApproval.Text = "Waiting For Approval";
            this.btnWaitingForApproval.UseVisualStyleBackColor = true;
            this.btnWaitingForApproval.Click += new System.EventHandler(this.btnWaitingForApproval_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproved.Location = new System.Drawing.Point(740, 444);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(121, 26);
            this.btnApproved.TabIndex = 23;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = true;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnReplaced
            // 
            this.btnReplaced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplaced.Location = new System.Drawing.Point(740, 476);
            this.btnReplaced.Name = "btnReplaced";
            this.btnReplaced.Size = new System.Drawing.Size(121, 26);
            this.btnReplaced.TabIndex = 24;
            this.btnReplaced.Text = "Replaced";
            this.btnReplaced.UseVisualStyleBackColor = true;
            this.btnReplaced.Click += new System.EventHandler(this.btnReplaced_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(740, 508);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 26);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnChkAll
            // 
            this.btnChkAll.Location = new System.Drawing.Point(14, 160);
            this.btnChkAll.Name = "btnChkAll";
            this.btnChkAll.Size = new System.Drawing.Size(79, 22);
            this.btnChkAll.TabIndex = 12;
            this.btnChkAll.Text = "Checked All";
            this.btnChkAll.UseVisualStyleBackColor = true;
            this.btnChkAll.Click += new System.EventHandler(this.btnChkAll_Click);
            // 
            // lvwItemList
            // 
            this.lvwItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItemList.CheckBoxes = true;
            this.lvwItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colClaimNo,
            this.colSubClaimNo,
            this.colCustomerName,
            this.colClaimDate,
            this.colValidationDate,
            this.colSubClaimStatus,
            this.colEntryDate,
            this.colEntryUser});
            this.lvwItemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwItemList.FullRowSelect = true;
            this.lvwItemList.GridLines = true;
            this.lvwItemList.Location = new System.Drawing.Point(13, 183);
            this.lvwItemList.MultiSelect = false;
            this.lvwItemList.Name = "lvwItemList";
            this.lvwItemList.Size = new System.Drawing.Size(721, 383);
            this.lvwItemList.TabIndex = 13;
            this.lvwItemList.UseCompatibleStateImageBehavior = false;
            this.lvwItemList.View = System.Windows.Forms.View.Details;
            // 
            // colClaimNo
            // 
            this.colClaimNo.Text = "Claim No";
            this.colClaimNo.Width = 77;
            // 
            // colSubClaimNo
            // 
            this.colSubClaimNo.Text = "Sub-Claim No";
            this.colSubClaimNo.Width = 100;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 115;
            // 
            // colClaimDate
            // 
            this.colClaimDate.Text = "Claim Date";
            this.colClaimDate.Width = 95;
            // 
            // colValidationDate
            // 
            this.colValidationDate.Text = "Validation Date";
            this.colValidationDate.Width = 103;
            // 
            // colSubClaimStatus
            // 
            this.colSubClaimStatus.Text = "Sub-Claim Status";
            this.colSubClaimStatus.Width = 199;
            // 
            // colEntryDate
            // 
            this.colEntryDate.Text = "Entry Date";
            this.colEntryDate.Width = 83;
            // 
            // colEntryUser
            // 
            this.colEntryUser.Text = "Entry User";
            this.colEntryUser.Width = 81;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightCyan;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 569);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Claim Receive At Service";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(620, 590);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Claim Cancel";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.AliceBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(530, 590);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Claim Replaced ";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(444, 590);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Claim Approved";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.YellowGreen;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(304, 590);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 13);
            this.label10.TabIndex = 34;
            this.label10.Text = "Claim Waiting For Approval";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Tan;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(155, 590);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Claim Checking By Accounts";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Plum;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 590);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Claim Assessment Complete";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Cyan;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(612, 569);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Claim Send To BLL";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.MistyRose;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(442, 569);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(164, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Claim Product Physically Receive";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.LightSalmon;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(301, 569);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(135, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Claim Receive To Be Send";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Pink;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(144, 569);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(151, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Claim Receive Team Required";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(64, 133);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(425, 21);
            this.cmbStatus.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(19, 136);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 9;
            this.label17.Text = "Status:";
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(58, 98);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(438, 50);
            this.ctlCustomer1.TabIndex = 8;
            // 
            // frmReplacementClaims
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 613);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvwItemList);
            this.Controls.Add(this.btnChkAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReplaced);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnWaitingForApproval);
            this.Controls.Add(this.btnCheckingByAccount);
            this.Controls.Add(this.btnSendToBLL);
            this.Controls.Add(this.btnPhysicallyReceive);
            this.Controls.Add(this.btnReceiveToBeSend);
            this.Controls.Add(this.btnTeamRequired);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.txtSubClaimNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtClaimNo);
            this.Controls.Add(this.btnClaimAssess);
            this.Controls.Add(this.btnClaimReceive);
            this.Controls.Add(this.btnGenerateClaimNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmReplacementClaims";
            this.Text = "frmReplaceClaims";
            this.Load += new System.EventHandler(this.frmReplacementClaims_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClaimNo;
        private System.Windows.Forms.Button btnClaimAssess;
        private System.Windows.Forms.Button btnClaimReceive;
        private System.Windows.Forms.Button btnGenerateClaimNo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.TextBox txtSubClaimNo;
        private System.Windows.Forms.Label label6;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTeamRequired;
        private System.Windows.Forms.Button btnReceiveToBeSend;
        private System.Windows.Forms.Button btnPhysicallyReceive;
        private System.Windows.Forms.Button btnSendToBLL;
        private System.Windows.Forms.Button btnCheckingByAccount;
        private System.Windows.Forms.Button btnWaitingForApproval;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Button btnReplaced;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChkAll;
        private System.Windows.Forms.ListView lvwItemList;
        private System.Windows.Forms.ColumnHeader colClaimNo;
        private System.Windows.Forms.ColumnHeader colSubClaimNo;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colClaimDate;
        private System.Windows.Forms.ColumnHeader colValidationDate;
        private System.Windows.Forms.ColumnHeader colSubClaimStatus;
        private System.Windows.Forms.ColumnHeader colEntryDate;
        private System.Windows.Forms.ColumnHeader colEntryUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label17;
    }
}