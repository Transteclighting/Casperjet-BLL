namespace CJ.Win.CSD.Reception
{
    partial class frmJobs
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
            this.lvwCSDJobs = new System.Windows.Forms.ListView();
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colServiceType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastFeedBackDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreatedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTechType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTechName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colThirdParty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBrand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeliveryLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPrintJobCard = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dtCreateToDate = new System.Windows.Forms.DateTimePicker();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtCreateFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnPrintClaimCard = new System.Windows.Forms.Button();
            this.btnRepairingEstimate = new System.Windows.Forms.Button();
            this.lblJob = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnJobBill = new System.Windows.Forms.Button();
            this.btnJobHistory = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEnableDisableCreateDateRange = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLFDate = new System.Windows.Forms.Label();
            this.chkLFDateRangeChecked = new System.Windows.Forms.CheckBox();
            this.dtLFToDate = new System.Windows.Forms.DateTimePicker();
            this.dtLFFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblLFTo = new System.Windows.Forms.Label();
            this.cmbJobStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSubStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbJobType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.btnCopyJobNo = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTechnician = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBarcodeSL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTechnicianType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnGatePass = new System.Windows.Forms.Button();
            this.btnJobDetails = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.linklblMultiSelectBrands = new System.Windows.Forms.LinkLabel();
            this.btnTechAssesment = new System.Windows.Forms.Button();
            this.btnTechnicalReport = new System.Windows.Forms.Button();
            this.btnMushakPrint = new System.Windows.Forms.Button();
            this.btnAdvance = new System.Windows.Forms.Button();
            this.ctlProducts1 = new CJ.Win.Control.ctlProducts();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwCSDJobs
            // 
            this.lvwCSDJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCSDJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colJobType,
            this.colJobStatus,
            this.colSubStatus,
            this.colServiceType,
            this.colCustomerName,
            this.colCustomerAddress,
            this.colCreateDate,
            this.colLastFeedBackDate,
            this.colCreatedBy,
            this.colTechType,
            this.colTechName,
            this.colThirdParty,
            this.colProductLocation,
            this.colBrand,
            this.colDeliveryLocation});
            this.lvwCSDJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCSDJobs.FullRowSelect = true;
            this.lvwCSDJobs.GridLines = true;
            this.lvwCSDJobs.HideSelection = false;
            this.lvwCSDJobs.Location = new System.Drawing.Point(12, 206);
            this.lvwCSDJobs.MultiSelect = false;
            this.lvwCSDJobs.Name = "lvwCSDJobs";
            this.lvwCSDJobs.Size = new System.Drawing.Size(867, 413);
            this.lvwCSDJobs.TabIndex = 29;
            this.lvwCSDJobs.UseCompatibleStateImageBehavior = false;
            this.lvwCSDJobs.View = System.Windows.Forms.View.Details;
            this.lvwCSDJobs.DoubleClick += new System.EventHandler(this.lvwCSDJobs_DoubleClick);
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job#";
            this.colJobNo.Width = 92;
            // 
            // colJobType
            // 
            this.colJobType.Text = "Job Type";
            this.colJobType.Width = 88;
            // 
            // colJobStatus
            // 
            this.colJobStatus.Text = "Job Status";
            this.colJobStatus.Width = 92;
            // 
            // colSubStatus
            // 
            this.colSubStatus.Text = "Sub Status";
            this.colSubStatus.Width = 74;
            // 
            // colServiceType
            // 
            this.colServiceType.Text = "Service Type";
            this.colServiceType.Width = 94;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 129;
            // 
            // colCustomerAddress
            // 
            this.colCustomerAddress.Text = "Customer Address";
            this.colCustomerAddress.Width = 134;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 89;
            // 
            // colLastFeedBackDate
            // 
            this.colLastFeedBackDate.Text = "L.F. Date";
            this.colLastFeedBackDate.Width = 86;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "Created By";
            this.colCreatedBy.Width = 100;
            // 
            // colTechType
            // 
            this.colTechType.Text = "Tech Type";
            // 
            // colTechName
            // 
            this.colTechName.Text = "Tech Name";
            // 
            // colThirdParty
            // 
            this.colThirdParty.Text = "Third Party";
            // 
            // colProductLocation
            // 
            this.colProductLocation.Text = "Prod. Loc.";
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 100;
            // 
            // colDeliveryLocation
            // 
            this.colDeliveryLocation.Text = "Delivery Location";
            // 
            // btnPrintJobCard
            // 
            this.btnPrintJobCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintJobCard.Enabled = false;
            this.btnPrintJobCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintJobCard.Location = new System.Drawing.Point(885, 261);
            this.btnPrintJobCard.Name = "btnPrintJobCard";
            this.btnPrintJobCard.Size = new System.Drawing.Size(121, 27);
            this.btnPrintJobCard.TabIndex = 32;
            this.btnPrintJobCard.Tag = "";
            this.btnPrintJobCard.Text = "Print Job Card";
            this.btnPrintJobCard.UseVisualStyleBackColor = true;
            this.btnPrintJobCard.Click += new System.EventHandler(this.btnPrintJobCard_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(885, 593);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 27);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(885, 234);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(121, 27);
            this.btnEdit.TabIndex = 31;
            this.btnEdit.Tag = "M1.18";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(885, 206);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(121, 27);
            this.btnAdd.TabIndex = 30;
            this.btnAdd.Text = "Create";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtCreateToDate
            // 
            this.dtCreateToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtCreateToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCreateToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCreateToDate.Location = new System.Drawing.Point(208, 20);
            this.dtCreateToDate.Name = "dtCreateToDate";
            this.dtCreateToDate.Size = new System.Drawing.Size(97, 20);
            this.dtCreateToDate.TabIndex = 4;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDate.Location = new System.Drawing.Point(3, 22);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(77, 13);
            this.lblCreateDate.TabIndex = 1;
            this.lblCreateDate.Text = "Create Date";
            this.lblCreateDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(184, 23);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // dtCreateFromDate
            // 
            this.dtCreateFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtCreateFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCreateFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCreateFromDate.Location = new System.Drawing.Point(83, 20);
            this.dtCreateFromDate.Name = "dtCreateFromDate";
            this.dtCreateFromDate.Size = new System.Drawing.Size(98, 20);
            this.dtCreateFromDate.TabIndex = 2;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(738, 167);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(79, 28);
            this.btnGo.TabIndex = 28;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnPrintClaimCard
            // 
            this.btnPrintClaimCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintClaimCard.Enabled = false;
            this.btnPrintClaimCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintClaimCard.Location = new System.Drawing.Point(885, 288);
            this.btnPrintClaimCard.Name = "btnPrintClaimCard";
            this.btnPrintClaimCard.Size = new System.Drawing.Size(121, 27);
            this.btnPrintClaimCard.TabIndex = 33;
            this.btnPrintClaimCard.Tag = "";
            this.btnPrintClaimCard.Text = "Print Claim Card";
            this.btnPrintClaimCard.UseVisualStyleBackColor = true;
            this.btnPrintClaimCard.Click += new System.EventHandler(this.btnPrintClaimCard_Click);
            // 
            // btnRepairingEstimate
            // 
            this.btnRepairingEstimate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRepairingEstimate.Enabled = false;
            this.btnRepairingEstimate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepairingEstimate.Location = new System.Drawing.Point(885, 315);
            this.btnRepairingEstimate.Name = "btnRepairingEstimate";
            this.btnRepairingEstimate.Size = new System.Drawing.Size(121, 27);
            this.btnRepairingEstimate.TabIndex = 34;
            this.btnRepairingEstimate.Text = "Repairing Estimate";
            this.btnRepairingEstimate.UseVisualStyleBackColor = true;
            this.btnRepairingEstimate.Click += new System.EventHandler(this.btnRepairingEstimate_Click);
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Location = new System.Drawing.Point(48, 61);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(41, 13);
            this.lblJob.TabIndex = 2;
            this.lblJob.Text = "Job No";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(567, 150);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(165, 20);
            this.txtCustomerName.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(503, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Cust. Name";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(92, 103);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(165, 20);
            this.txtContactNo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mobile No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.AcceptsReturn = true;
            this.txtInvoiceNo.AcceptsTab = true;
            this.txtInvoiceNo.Location = new System.Drawing.Point(92, 127);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(165, 20);
            this.txtInvoiceNo.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Barcode SL#";
            // 
            // btnJobBill
            // 
            this.btnJobBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJobBill.Enabled = false;
            this.btnJobBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobBill.Location = new System.Drawing.Point(885, 342);
            this.btnJobBill.Name = "btnJobBill";
            this.btnJobBill.Size = new System.Drawing.Size(121, 27);
            this.btnJobBill.TabIndex = 35;
            this.btnJobBill.Text = "Job Bill";
            this.btnJobBill.UseVisualStyleBackColor = true;
            this.btnJobBill.Click += new System.EventHandler(this.btnJobBill_Click);
            // 
            // btnJobHistory
            // 
            this.btnJobHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJobHistory.Enabled = false;
            this.btnJobHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobHistory.Location = new System.Drawing.Point(885, 426);
            this.btnJobHistory.Name = "btnJobHistory";
            this.btnJobHistory.Size = new System.Drawing.Size(121, 27);
            this.btnJobHistory.TabIndex = 36;
            this.btnJobHistory.Text = "Job History";
            this.btnJobHistory.UseVisualStyleBackColor = true;
            this.btnJobHistory.Click += new System.EventHandler(this.btnJobHistory_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEnableDisableCreateDateRange);
            this.groupBox1.Controls.Add(this.dtCreateToDate);
            this.groupBox1.Controls.Add(this.dtCreateFromDate);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblCreateDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkEnableDisableCreateDateRange
            // 
            this.chkEnableDisableCreateDateRange.AutoSize = true;
            this.chkEnableDisableCreateDateRange.Location = new System.Drawing.Point(14, -1);
            this.chkEnableDisableCreateDateRange.Name = "chkEnableDisableCreateDateRange";
            this.chkEnableDisableCreateDateRange.Size = new System.Drawing.Size(160, 17);
            this.chkEnableDisableCreateDateRange.TabIndex = 0;
            this.chkEnableDisableCreateDateRange.Text = "Enable/Disable Date Range";
            this.chkEnableDisableCreateDateRange.UseVisualStyleBackColor = true;
            this.chkEnableDisableCreateDateRange.CheckedChanged += new System.EventHandler(this.chkEnableDisableDateRange_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLFDate);
            this.groupBox2.Controls.Add(this.chkLFDateRangeChecked);
            this.groupBox2.Controls.Add(this.dtLFToDate);
            this.groupBox2.Controls.Add(this.dtLFFromDate);
            this.groupBox2.Controls.Add(this.lblLFTo);
            this.groupBox2.Location = new System.Drawing.Point(330, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // lblLFDate
            // 
            this.lblLFDate.AutoSize = true;
            this.lblLFDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLFDate.Location = new System.Drawing.Point(4, 23);
            this.lblLFDate.Name = "lblLFDate";
            this.lblLFDate.Size = new System.Drawing.Size(64, 13);
            this.lblLFDate.TabIndex = 1;
            this.lblLFDate.Text = "L. F. Date";
            // 
            // chkLFDateRangeChecked
            // 
            this.chkLFDateRangeChecked.AutoSize = true;
            this.chkLFDateRangeChecked.Location = new System.Drawing.Point(14, -1);
            this.chkLFDateRangeChecked.Name = "chkLFDateRangeChecked";
            this.chkLFDateRangeChecked.Size = new System.Drawing.Size(160, 17);
            this.chkLFDateRangeChecked.TabIndex = 0;
            this.chkLFDateRangeChecked.Text = "Enable/Disable Date Range";
            this.chkLFDateRangeChecked.UseVisualStyleBackColor = true;
            this.chkLFDateRangeChecked.CheckedChanged += new System.EventHandler(this.chkLFDateRangeChecked_CheckedChanged);
            // 
            // dtLFToDate
            // 
            this.dtLFToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtLFToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtLFToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLFToDate.Location = new System.Drawing.Point(193, 20);
            this.dtLFToDate.Name = "dtLFToDate";
            this.dtLFToDate.Size = new System.Drawing.Size(97, 20);
            this.dtLFToDate.TabIndex = 4;
            // 
            // dtLFFromDate
            // 
            this.dtLFFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtLFFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtLFFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLFFromDate.Location = new System.Drawing.Point(69, 20);
            this.dtLFFromDate.Name = "dtLFFromDate";
            this.dtLFFromDate.Size = new System.Drawing.Size(98, 20);
            this.dtLFFromDate.TabIndex = 2;
            // 
            // lblLFTo
            // 
            this.lblLFTo.AutoSize = true;
            this.lblLFTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLFTo.Location = new System.Drawing.Point(170, 23);
            this.lblLFTo.Name = "lblLFTo";
            this.lblLFTo.Size = new System.Drawing.Size(22, 13);
            this.lblLFTo.TabIndex = 3;
            this.lblLFTo.Text = "To";
            // 
            // cmbJobStatus
            // 
            this.cmbJobStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobStatus.FormattingEnabled = true;
            this.cmbJobStatus.Location = new System.Drawing.Point(567, 80);
            this.cmbJobStatus.Name = "cmbJobStatus";
            this.cmbJobStatus.Size = new System.Drawing.Size(165, 21);
            this.cmbJobStatus.TabIndex = 21;
            this.cmbJobStatus.SelectedIndexChanged += new System.EventHandler(this.cmbJobStatus_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(506, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Job Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Sub Status";
            // 
            // cmbSubStatus
            // 
            this.cmbSubStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubStatus.FormattingEnabled = true;
            this.cmbSubStatus.Location = new System.Drawing.Point(567, 103);
            this.cmbSubStatus.Name = "cmbSubStatus";
            this.cmbSubStatus.Size = new System.Drawing.Size(165, 21);
            this.cmbSubStatus.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(277, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Job Type";
            // 
            // cmbJobType
            // 
            this.cmbJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobType.FormattingEnabled = true;
            this.cmbJobType.Location = new System.Drawing.Point(331, 80);
            this.cmbJobType.Name = "cmbJobType";
            this.cmbJobType.Size = new System.Drawing.Size(165, 21);
            this.cmbJobType.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(259, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Service Type";
            // 
            // cmbServiceType
            // 
            this.cmbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServiceType.FormattingEnabled = true;
            this.cmbServiceType.Location = new System.Drawing.Point(331, 103);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(165, 21);
            this.cmbServiceType.TabIndex = 17;
            // 
            // btnCopyJobNo
            // 
            this.btnCopyJobNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyJobNo.Location = new System.Drawing.Point(885, 454);
            this.btnCopyJobNo.Name = "btnCopyJobNo";
            this.btnCopyJobNo.Size = new System.Drawing.Size(121, 27);
            this.btnCopyJobNo.TabIndex = 37;
            this.btnCopyJobNo.Text = "Copy Job No";
            this.btnCopyJobNo.UseVisualStyleBackColor = true;
            this.btnCopyJobNo.Click += new System.EventHandler(this.btnCopyJobNo_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(31, 154);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Third Party";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(505, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Own Tech.";
            // 
            // cmbTechnician
            // 
            this.cmbTechnician.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTechnician.FormattingEnabled = true;
            this.cmbTechnician.Location = new System.Drawing.Point(567, 127);
            this.cmbTechnician.Name = "cmbTechnician";
            this.cmbTechnician.Size = new System.Drawing.Size(165, 21);
            this.cmbTechnician.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Product";
            // 
            // txtBarcodeSL
            // 
            this.txtBarcodeSL.AcceptsReturn = true;
            this.txtBarcodeSL.AcceptsTab = true;
            this.txtBarcodeSL.Location = new System.Drawing.Point(92, 80);
            this.txtBarcodeSL.Name = "txtBarcodeSL";
            this.txtBarcodeSL.Size = new System.Drawing.Size(165, 20);
            this.txtBarcodeSL.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Invoice No";
            // 
            // cmbTechnicianType
            // 
            this.cmbTechnicianType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTechnicianType.FormattingEnabled = true;
            this.cmbTechnicianType.Location = new System.Drawing.Point(332, 127);
            this.cmbTechnicianType.Name = "cmbTechnicianType";
            this.cmbTechnicianType.Size = new System.Drawing.Size(165, 21);
            this.cmbTechnicianType.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(267, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Tech. Type";
            // 
            // btnGatePass
            // 
            this.btnGatePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGatePass.Enabled = false;
            this.btnGatePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGatePass.Location = new System.Drawing.Point(885, 370);
            this.btnGatePass.Name = "btnGatePass";
            this.btnGatePass.Size = new System.Drawing.Size(121, 27);
            this.btnGatePass.TabIndex = 39;
            this.btnGatePass.Text = "Gate Pass";
            this.btnGatePass.UseVisualStyleBackColor = true;
            this.btnGatePass.Click += new System.EventHandler(this.btnGatePass_Click);
            // 
            // btnJobDetails
            // 
            this.btnJobDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJobDetails.Enabled = false;
            this.btnJobDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobDetails.Location = new System.Drawing.Point(885, 398);
            this.btnJobDetails.Name = "btnJobDetails";
            this.btnJobDetails.Size = new System.Drawing.Size(121, 27);
            this.btnJobDetails.TabIndex = 40;
            this.btnJobDetails.Text = "Job Details";
            this.btnJobDetails.UseVisualStyleBackColor = true;
            this.btnJobDetails.Click += new System.EventHandler(this.btnJobDetails_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(735, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 181;
            this.label12.Text = "Brand:";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(779, 80);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(150, 21);
            this.cmbBrand.TabIndex = 180;
            // 
            // linklblMultiSelectBrands
            // 
            this.linklblMultiSelectBrands.AutoSize = true;
            this.linklblMultiSelectBrands.Location = new System.Drawing.Point(776, 109);
            this.linklblMultiSelectBrands.Name = "linklblMultiSelectBrands";
            this.linklblMultiSelectBrands.Size = new System.Drawing.Size(98, 13);
            this.linklblMultiSelectBrands.TabIndex = 179;
            this.linklblMultiSelectBrands.TabStop = true;
            this.linklblMultiSelectBrands.Text = "Multi Select Brands";
            this.linklblMultiSelectBrands.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblMultiSelectBrands_LinkClicked);
            // 
            // btnTechAssesment
            // 
            this.btnTechAssesment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTechAssesment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTechAssesment.Location = new System.Drawing.Point(885, 482);
            this.btnTechAssesment.Name = "btnTechAssesment";
            this.btnTechAssesment.Size = new System.Drawing.Size(121, 27);
            this.btnTechAssesment.TabIndex = 182;
            this.btnTechAssesment.Text = "Tech. Assessment";
            this.btnTechAssesment.UseVisualStyleBackColor = true;
            this.btnTechAssesment.Click += new System.EventHandler(this.btnTechAssesment_Click);
            // 
            // btnTechnicalReport
            // 
            this.btnTechnicalReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTechnicalReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTechnicalReport.Location = new System.Drawing.Point(885, 510);
            this.btnTechnicalReport.Name = "btnTechnicalReport";
            this.btnTechnicalReport.Size = new System.Drawing.Size(121, 27);
            this.btnTechnicalReport.TabIndex = 183;
            this.btnTechnicalReport.Text = "Technical Report";
            this.btnTechnicalReport.UseVisualStyleBackColor = true;
            this.btnTechnicalReport.Click += new System.EventHandler(this.btnTechnicalReport_Click);
            // 
            // btnMushakPrint
            // 
            this.btnMushakPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMushakPrint.Enabled = false;
            this.btnMushakPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMushakPrint.Location = new System.Drawing.Point(885, 539);
            this.btnMushakPrint.Name = "btnMushakPrint";
            this.btnMushakPrint.Size = new System.Drawing.Size(121, 27);
            this.btnMushakPrint.TabIndex = 184;
            this.btnMushakPrint.Text = "Mushak Print";
            this.btnMushakPrint.UseVisualStyleBackColor = true;
            this.btnMushakPrint.Click += new System.EventHandler(this.btnMushakPrint_Click);
            // 
            // btnAdvance
            // 
            this.btnAdvance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvance.Location = new System.Drawing.Point(885, 566);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(121, 27);
            this.btnAdvance.TabIndex = 185;
            this.btnAdvance.Text = "Advance Receive";
            this.btnAdvance.UseVisualStyleBackColor = true;
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            // 
            // ctlProducts1
            // 
            this.ctlProducts1.Location = new System.Drawing.Point(92, 175);
            this.ctlProducts1.Name = "ctlProducts1";
            this.ctlProducts1.Size = new System.Drawing.Size(646, 25);
            this.ctlProducts1.TabIndex = 13;
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(92, 152);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(412, 25);
            this.ctlInterService1.TabIndex = 11;
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(90, 58);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(513, 20);
            this.ctlCSDJob1.TabIndex = 3;
            // 
            // frmJobs
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 635);
            this.Controls.Add(this.btnAdvance);
            this.Controls.Add(this.btnMushakPrint);
            this.Controls.Add(this.btnTechnicalReport);
            this.Controls.Add(this.btnTechAssesment);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.linklblMultiSelectBrands);
            this.Controls.Add(this.btnJobDetails);
            this.Controls.Add(this.btnGatePass);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbTechnicianType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBarcodeSL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctlProducts1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ctlInterService1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTechnician);
            this.Controls.Add(this.btnCopyJobNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbServiceType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbJobType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbSubStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbJobStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ctlCSDJob1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnJobHistory);
            this.Controls.Add(this.btnJobBill);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.btnRepairingEstimate);
            this.Controls.Add(this.btnPrintClaimCard);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnPrintJobCard);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwCSDJobs);
            this.Name = "frmJobs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jobs";
            this.Load += new System.EventHandler(this.frmJobs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwCSDJobs;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.Button btnPrintJobCard;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colServiceType;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colCustomerAddress;
        private System.Windows.Forms.DateTimePicker dtCreateToDate;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtCreateFromDate;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnPrintClaimCard;
        private System.Windows.Forms.Button btnRepairingEstimate;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnJobBill;
        private System.Windows.Forms.Button btnJobHistory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEnableDisableCreateDateRange;
        private System.Windows.Forms.ColumnHeader colJobStatus;
        private System.Windows.Forms.ColumnHeader colJobType;
        private System.Windows.Forms.ColumnHeader colSubStatus;
        private System.Windows.Forms.ColumnHeader colLastFeedBackDate;
        private ctlCSDJob ctlCSDJob1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkLFDateRangeChecked;
        private System.Windows.Forms.DateTimePicker dtLFToDate;
        private System.Windows.Forms.DateTimePicker dtLFFromDate;
        private System.Windows.Forms.Label lblLFTo;
        private System.Windows.Forms.Label lblLFDate;
        private System.Windows.Forms.ComboBox cmbJobStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSubStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbJobType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbServiceType;
        private System.Windows.Forms.Button btnCopyJobNo;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.Label label14;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTechnician;
        private CJ.Win.Control.ctlProducts ctlProducts1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBarcodeSL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTechnicianType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ColumnHeader colTechType;
        private System.Windows.Forms.ColumnHeader colTechName;
        private System.Windows.Forms.ColumnHeader colThirdParty;
        private System.Windows.Forms.ColumnHeader colProductLocation;
        private System.Windows.Forms.Button btnGatePass;
        private System.Windows.Forms.Button btnJobDetails;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.LinkLabel linklblMultiSelectBrands;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.Button btnTechAssesment;
        private System.Windows.Forms.Button btnTechnicalReport;
        private System.Windows.Forms.Button btnMushakPrint;
        private System.Windows.Forms.ColumnHeader colDeliveryLocation;
        private System.Windows.Forms.Button btnAdvance;
    }
}