namespace CJ.Win
{
    partial class frmPaidJobForInterServices
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
            this.lvwPaidJobForInterServices = new System.Windows.Forms.ListView();
            this.colPaidJobID = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colReceiveDate = new System.Windows.Forms.ColumnHeader();
            this.colCustomerName = new System.Windows.Forms.ColumnHeader();
            this.colContactNo = new System.Windows.Forms.ColumnHeader();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colFault = new System.Windows.Forms.ColumnHeader();
            this.colExpectedDate = new System.Windows.Forms.ColumnHeader();
            this.colExpectedTime = new System.Windows.Forms.ColumnHeader();
            this.colScheduleDate = new System.Windows.Forms.ColumnHeader();
            this.colScheduleTime = new System.Windows.Forms.ColumnHeader();
            this.colEDDIFPending = new System.Windows.Forms.ColumnHeader();
            this.colDeliveryDate = new System.Windows.Forms.ColumnHeader();
            this.colISCode = new System.Windows.Forms.ColumnHeader();
            this.colAssignto = new System.Windows.Forms.ColumnHeader();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.colLocation = new System.Windows.Forms.ColumnHeader();
            this.colReceiveBy = new System.Windows.Forms.ColumnHeader();
            this.colIsCommu = new System.Windows.Forms.ColumnHeader();
            this.colConvertJobNo = new System.Windows.Forms.ColumnHeader();
            this.colReceiveRemarks = new System.Windows.Forms.ColumnHeader();
            this.colScheduleRemarks = new System.Windows.Forms.ColumnHeader();
            this.colCommuRemarks = new System.Windows.Forms.ColumnHeader();
            this.All = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblComplainerName = new System.Windows.Forms.Label();
            this.lblComplainStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblAssignWhom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtPaidJobNo = new System.Windows.Forms.TextBox();
            this.lblPaidJobID = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCommunication = new System.Windows.Forms.ComboBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnServiceProvided = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnWIP = new System.Windows.Forms.Button();
            this.btnCommunication = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSchedulePrint = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwPaidJobForInterServices
            // 
            this.lvwPaidJobForInterServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPaidJobForInterServices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPaidJobID,
            this.colStatus,
            this.colReceiveDate,
            this.colCustomerName,
            this.colContactNo,
            this.colProductCode,
            this.colProductName,
            this.colFault,
            this.colExpectedDate,
            this.colExpectedTime,
            this.colScheduleDate,
            this.colScheduleTime,
            this.colEDDIFPending,
            this.colDeliveryDate,
            this.colISCode,
            this.colAssignto,
            this.colAddress,
            this.colLocation,
            this.colReceiveBy,
            this.colIsCommu,
            this.colConvertJobNo,
            this.colReceiveRemarks,
            this.colScheduleRemarks,
            this.colCommuRemarks});
            this.lvwPaidJobForInterServices.FullRowSelect = true;
            this.lvwPaidJobForInterServices.GridLines = true;
            this.lvwPaidJobForInterServices.Location = new System.Drawing.Point(-3, 150);
            this.lvwPaidJobForInterServices.MultiSelect = false;
            this.lvwPaidJobForInterServices.Name = "lvwPaidJobForInterServices";
            this.lvwPaidJobForInterServices.Size = new System.Drawing.Size(756, 298);
            this.lvwPaidJobForInterServices.TabIndex = 1;
            this.lvwPaidJobForInterServices.UseCompatibleStateImageBehavior = false;
            this.lvwPaidJobForInterServices.View = System.Windows.Forms.View.Details;
            this.lvwPaidJobForInterServices.DoubleClick += new System.EventHandler(this.lvwPaidJobForInterServices_DoubleClick);
            // 
            // colPaidJobID
            // 
            this.colPaidJobID.Text = "Paid Job ID";
            this.colPaidJobID.Width = 73;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 103;
            // 
            // colReceiveDate
            // 
            this.colReceiveDate.Text = "Receive Date-time";
            this.colReceiveDate.Width = 140;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 152;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 100;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Prod. Code";
            this.colProductCode.Width = 75;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 200;
            // 
            // colFault
            // 
            this.colFault.Text = "Fault";
            this.colFault.Width = 120;
            // 
            // colExpectedDate
            // 
            this.colExpectedDate.Text = "Expt. Date";
            this.colExpectedDate.Width = 70;
            // 
            // colExpectedTime
            // 
            this.colExpectedTime.Text = "Expt. Time";
            this.colExpectedTime.Width = 70;
            // 
            // colScheduleDate
            // 
            this.colScheduleDate.Text = "Sche. Date";
            this.colScheduleDate.Width = 70;
            // 
            // colScheduleTime
            // 
            this.colScheduleTime.Text = "Sche. Time";
            this.colScheduleTime.Width = 70;
            // 
            // colEDDIFPending
            // 
            this.colEDDIFPending.Text = "EDD (If Pending)";
            this.colEDDIFPending.Width = 100;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.Text = "Delivery Date";
            this.colDeliveryDate.Width = 80;
            // 
            // colISCode
            // 
            this.colISCode.Text = "Code";
            this.colISCode.Width = 50;
            // 
            // colAssignto
            // 
            this.colAssignto.Text = "Assign To";
            this.colAssignto.Width = 114;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 196;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 126;
            // 
            // colReceiveBy
            // 
            this.colReceiveBy.Text = "Receive By";
            // 
            // colIsCommu
            // 
            this.colIsCommu.Text = "Is Commu.";
            // 
            // colConvertJobNo
            // 
            this.colConvertJobNo.Text = "Convert Job No";
            this.colConvertJobNo.Width = 90;
            // 
            // colReceiveRemarks
            // 
            this.colReceiveRemarks.Text = "Receive Remarks";
            this.colReceiveRemarks.Width = 200;
            // 
            // colScheduleRemarks
            // 
            this.colScheduleRemarks.Text = "Schedule Remarks";
            this.colScheduleRemarks.Width = 200;
            // 
            // colCommuRemarks
            // 
            this.colCommuRemarks.Text = "Communication Remarks";
            this.colCommuRemarks.Width = 200;
            // 
            // All
            // 
            this.All.AutoSize = true;
            this.All.Location = new System.Drawing.Point(341, 20);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(15, 14);
            this.All.TabIndex = 169;
            this.All.UseVisualStyleBackColor = true;
            this.All.CheckedChanged += new System.EventHandler(this.All_CheckedChanged);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(601, 111);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(69, 31);
            this.btnGo.TabIndex = 166;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(99, 91);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(159, 20);
            this.txtContactNo.TabIndex = 165;
            // 
            // lblContactNo
            // 
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(37, 94);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(59, 13);
            this.lblContactNo.TabIndex = 164;
            this.lblContactNo.Text = "Contact#";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(99, 66);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(159, 20);
            this.txtName.TabIndex = 163;
            // 
            // lblComplainerName
            // 
            this.lblComplainerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainerName.Location = new System.Drawing.Point(3, 68);
            this.lblComplainerName.Name = "lblComplainerName";
            this.lblComplainerName.Size = new System.Drawing.Size(100, 13);
            this.lblComplainerName.TabIndex = 162;
            this.lblComplainerName.Text = "Customer Name";
            // 
            // lblComplainStatus
            // 
            this.lblComplainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainStatus.Location = new System.Drawing.Point(375, 18);
            this.lblComplainStatus.Name = "lblComplainStatus";
            this.lblComplainStatus.Size = new System.Drawing.Size(43, 13);
            this.lblComplainStatus.TabIndex = 161;
            this.lblComplainStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(424, 15);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(148, 21);
            this.cmbStatus.TabIndex = 160;
            // 
            // lblAssignWhom
            // 
            this.lblAssignWhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignWhom.Location = new System.Drawing.Point(364, 95);
            this.lblAssignWhom.Name = "lblAssignWhom";
            this.lblAssignWhom.Size = new System.Drawing.Size(56, 13);
            this.lblAssignWhom.TabIndex = 159;
            this.lblAssignWhom.Text = "Location";
            // 
            // lblTo
            // 
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(213, 19);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 158;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(24, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(85, 13);
            this.lblDate.TabIndex = 157;
            this.lblDate.Text = "Receive Date";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(236, 16);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(99, 20);
            this.dtToDate.TabIndex = 156;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(111, 16);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 20);
            this.dtFromDate.TabIndex = 155;
            // 
            // txtPaidJobNo
            // 
            this.txtPaidJobNo.Location = new System.Drawing.Point(99, 41);
            this.txtPaidJobNo.Name = "txtPaidJobNo";
            this.txtPaidJobNo.Size = new System.Drawing.Size(63, 20);
            this.txtPaidJobNo.TabIndex = 154;
            // 
            // lblPaidJobID
            // 
            this.lblPaidJobID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidJobID.Location = new System.Drawing.Point(36, 45);
            this.lblPaidJobID.Name = "lblPaidJobID";
            this.lblPaidJobID.Size = new System.Drawing.Size(73, 13);
            this.lblPaidJobID.TabIndex = 153;
            this.lblPaidJobID.Text = "Paid Job ID";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPaidJobNo);
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtProductCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbCommunication);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.lblComplainerName);
            this.groupBox2.Controls.Add(this.txtContactNo);
            this.groupBox2.Controls.Add(this.lblContactNo);
            this.groupBox2.Controls.Add(this.txtLocation);
            this.groupBox2.Controls.Add(this.lblAssignWhom);
            this.groupBox2.Controls.Add(this.cmbStatus);
            this.groupBox2.Controls.Add(this.lblComplainStatus);
            this.groupBox2.Location = new System.Drawing.Point(12, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(580, 143);
            this.groupBox2.TabIndex = 168;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 190;
            this.label2.Text = "Is Commu?";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(424, 66);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(148, 20);
            this.txtProductName.TabIndex = 185;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 184;
            this.label4.Text = "Product Name";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(424, 42);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(148, 20);
            this.txtProductCode.TabIndex = 183;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(338, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 182;
            this.label3.Text = "Product Code";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 174;
            this.label1.Text = "Assign To";
            // 
            // cmbCommunication
            // 
            this.cmbCommunication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCommunication.FormattingEnabled = true;
            this.cmbCommunication.Location = new System.Drawing.Point(261, 40);
            this.cmbCommunication.Name = "cmbCommunication";
            this.cmbCommunication.Size = new System.Drawing.Size(62, 21);
            this.cmbCommunication.TabIndex = 180;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(424, 91);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(148, 20);
            this.txtLocation.TabIndex = 167;
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(99, 117);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(479, 25);
            this.ctlInterService1.TabIndex = 175;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(771, 457);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 27);
            this.btnClose.TabIndex = 171;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(771, 64);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 27);
            this.btnNew.TabIndex = 170;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(771, 102);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(112, 27);
            this.btnAssign.TabIndex = 172;
            this.btnAssign.Text = "&Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(771, 278);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 27);
            this.btnCancel.TabIndex = 173;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.ForeColor = System.Drawing.Color.Green;
            this.btnHistory.Location = new System.Drawing.Point(771, 377);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(112, 27);
            this.btnHistory.TabIndex = 174;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnServiceProvided
            // 
            this.btnServiceProvided.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServiceProvided.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServiceProvided.Location = new System.Drawing.Point(771, 189);
            this.btnServiceProvided.Name = "btnServiceProvided";
            this.btnServiceProvided.Size = new System.Drawing.Size(112, 27);
            this.btnServiceProvided.TabIndex = 175;
            this.btnServiceProvided.Text = "Service Provided";
            this.btnServiceProvided.UseVisualStyleBackColor = true;
            this.btnServiceProvided.Click += new System.EventHandler(this.btnServiceProvided_Click);
            // 
            // btnPending
            // 
            this.btnPending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPending.Location = new System.Drawing.Point(771, 218);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(112, 27);
            this.btnPending.TabIndex = 176;
            this.btnPending.Text = "Pending";
            this.btnPending.UseVisualStyleBackColor = true;
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Location = new System.Drawing.Point(771, 248);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(112, 27);
            this.btnConvert.TabIndex = 177;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnWIP
            // 
            this.btnWIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWIP.Location = new System.Drawing.Point(771, 160);
            this.btnWIP.Name = "btnWIP";
            this.btnWIP.Size = new System.Drawing.Size(112, 27);
            this.btnWIP.TabIndex = 178;
            this.btnWIP.Text = "WIP";
            this.btnWIP.UseVisualStyleBackColor = true;
            this.btnWIP.Click += new System.EventHandler(this.btnWIP_Click);
            // 
            // btnCommunication
            // 
            this.btnCommunication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommunication.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommunication.Location = new System.Drawing.Point(771, 131);
            this.btnCommunication.Name = "btnCommunication";
            this.btnCommunication.Size = new System.Drawing.Size(112, 27);
            this.btnCommunication.TabIndex = 179;
            this.btnCommunication.Text = "Communication";
            this.btnCommunication.UseVisualStyleBackColor = true;
            this.btnCommunication.Click += new System.EventHandler(this.btnCommunication_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(771, 311);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 27);
            this.btnEdit.TabIndex = 180;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(273, 462);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 189;
            this.label6.Text = "Assign";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(343, 462);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 188;
            this.label7.Text = "WIP";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(201, 462);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 187;
            this.label8.Text = "Receive";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.LightSalmon;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(523, 462);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 186;
            this.label5.Text = "Pending";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(593, 462);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 17);
            this.label12.TabIndex = 185;
            this.label12.Text = "Converted";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.DarkGray;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(672, 462);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 17);
            this.label14.TabIndex = 183;
            this.label14.Text = "Cancel";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BackColor = System.Drawing.Color.DarkKhaki;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(413, 462);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 17);
            this.label15.TabIndex = 182;
            this.label15.Text = "Service Provided";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSchedulePrint
            // 
            this.btnSchedulePrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSchedulePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedulePrint.Location = new System.Drawing.Point(15, 457);
            this.btnSchedulePrint.Name = "btnSchedulePrint";
            this.btnSchedulePrint.Size = new System.Drawing.Size(100, 27);
            this.btnSchedulePrint.TabIndex = 217;
            this.btnSchedulePrint.Text = "Schedule Print";
            this.btnSchedulePrint.UseVisualStyleBackColor = true;
            this.btnSchedulePrint.Click += new System.EventHandler(this.btnSchedulePrint_Click);
            // 
            // frmPaidJobForInterServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 492);
            this.Controls.Add(this.btnSchedulePrint);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnCommunication);
            this.Controls.Add(this.btnWIP);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnPending);
            this.Controls.Add(this.btnServiceProvided);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.All);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lblPaidJobID);
            this.Controls.Add(this.lvwPaidJobForInterServices);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmPaidJobForInterServices";
            this.Text = "Inter Service Paid Jobs";
            this.Load += new System.EventHandler(this.frmPaidJobForInterServices_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwPaidJobForInterServices;
        private System.Windows.Forms.ColumnHeader colPaidJobID;
        private System.Windows.Forms.ColumnHeader colReceiveDate;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colAssignto;
        private System.Windows.Forms.ColumnHeader colReceiveBy;
        private System.Windows.Forms.CheckBox All;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblComplainerName;
        private System.Windows.Forms.Label lblComplainStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblAssignWhom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.TextBox txtPaidJobNo;
        private System.Windows.Forms.Label lblPaidJobID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocation;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnServiceProvided;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnWIP;
        private System.Windows.Forms.Button btnCommunication;
        private System.Windows.Forms.ComboBox cmbCommunication;
        private System.Windows.Forms.ColumnHeader colIsCommu;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colExpectedDate;
        private System.Windows.Forms.ColumnHeader colScheduleDate;
        private System.Windows.Forms.ColumnHeader colConvertJobNo;
        private System.Windows.Forms.ColumnHeader colExpectedTime;
        private System.Windows.Forms.ColumnHeader colScheduleTime;
        private System.Windows.Forms.ColumnHeader colReceiveRemarks;
        private System.Windows.Forms.ColumnHeader colScheduleRemarks;
        private System.Windows.Forms.ColumnHeader colFault;
        private System.Windows.Forms.ColumnHeader colCommuRemarks;
        private System.Windows.Forms.ColumnHeader colISCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ColumnHeader colEDDIFPending;
        private System.Windows.Forms.ColumnHeader colDeliveryDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSchedulePrint;
    }
}