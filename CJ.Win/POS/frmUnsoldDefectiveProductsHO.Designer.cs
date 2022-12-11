namespace CJ.Win.POS
{
    partial class frmUnsoldDefectiveProductsHO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnsoldDefectiveProductsHO));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAssessedPlan = new System.Windows.Forms.Button();
            this.lvwUnsouldDefectiveProducts = new System.Windows.Forms.ListView();
            this.colDefectiveNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDefectiveType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOutletName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBarcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFault = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsCreateJob = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRefInvNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRefInvDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAssessed = new System.Windows.Forms.Button();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnLogNoted = new System.Windows.Forms.Button();
            this.btnLogReturn = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDefectiveNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShowroom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbIsCreateJob = new System.Windows.Forms.ComboBox();
            this.btnJobNoUpdate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDefectiveType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbPG = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMAG = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.cmbAG = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.linklblMultiSelectBrands = new System.Windows.Forms.LinkLabel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAcknowledge = new System.Windows.Forms.Button();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.dtFromdate);
            this.groupBox1.Controls.Add(this.dtTodate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(426, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(9, 1);
            this.chkAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(187, 20);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(78, 30);
            this.dtFromdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(147, 23);
            this.dtFromdate.TabIndex = 2;
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(264, 30);
            this.dtTodate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(147, 23);
            this.dtTodate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(236, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(31, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "From";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(549, 157);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(46, 16);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status";
            // 
            // cmbstatus
            // 
            this.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstatus.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Location = new System.Drawing.Point(599, 153);
            this.cmbstatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(189, 24);
            this.cmbstatus.TabIndex = 19;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.lblBarcode.Location = new System.Drawing.Point(28, 186);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(57, 16);
            this.lblBarcode.TabIndex = 20;
            this.lblBarcode.Text = "Barcode";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.txtBarcode.Location = new System.Drawing.Point(91, 185);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(147, 23);
            this.txtBarcode.TabIndex = 21;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.lblProduct.Location = new System.Drawing.Point(29, 216);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(56, 16);
            this.lblProduct.TabIndex = 26;
            this.lblProduct.Text = "Product";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Location = new System.Drawing.Point(688, 213);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Go";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAssessedPlan
            // 
            this.btnAssessedPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssessedPlan.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnAssessedPlan.Location = new System.Drawing.Point(867, 249);
            this.btnAssessedPlan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAssessedPlan.Name = "btnAssessedPlan";
            this.btnAssessedPlan.Size = new System.Drawing.Size(100, 30);
            this.btnAssessedPlan.TabIndex = 15;
            this.btnAssessedPlan.Text = "Assess";
            this.btnAssessedPlan.UseVisualStyleBackColor = true;
            this.btnAssessedPlan.Click += new System.EventHandler(this.btnAssessedPlan_Click);
            // 
            // lvwUnsouldDefectiveProducts
            // 
            this.lvwUnsouldDefectiveProducts.AllowColumnReorder = true;
            this.lvwUnsouldDefectiveProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwUnsouldDefectiveProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDefectiveNo,
            this.colDefectiveType,
            this.colOutletName,
            this.colProductCode,
            this.colProductName,
            this.colBarcode,
            this.colFault,
            this.colCreateDate,
            this.colStatus,
            this.colJobNo,
            this.colIsCreateJob,
            this.colRefInvNo,
            this.colRefInvDate});
            this.lvwUnsouldDefectiveProducts.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwUnsouldDefectiveProducts.FullRowSelect = true;
            this.lvwUnsouldDefectiveProducts.GridLines = true;
            this.lvwUnsouldDefectiveProducts.HideSelection = false;
            this.lvwUnsouldDefectiveProducts.Location = new System.Drawing.Point(12, 249);
            this.lvwUnsouldDefectiveProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwUnsouldDefectiveProducts.Name = "lvwUnsouldDefectiveProducts";
            this.lvwUnsouldDefectiveProducts.Size = new System.Drawing.Size(847, 306);
            this.lvwUnsouldDefectiveProducts.TabIndex = 29;
            this.lvwUnsouldDefectiveProducts.UseCompatibleStateImageBehavior = false;
            this.lvwUnsouldDefectiveProducts.View = System.Windows.Forms.View.Details;
//            this.lvwUnsouldDefectiveProducts.SelectedIndexChanged += new System.EventHandler(this.lvwUnsouldDefectiveProducts_SelectedIndexChanged);
            // 
            // colDefectiveNo
            // 
            this.colDefectiveNo.Text = "Defective #";
            this.colDefectiveNo.Width = 78;
            // 
            // colDefectiveType
            // 
            this.colDefectiveType.Text = "Defective Type";
            this.colDefectiveType.Width = 94;
            // 
            // colOutletName
            // 
            this.colOutletName.Text = "Outlet";
            this.colOutletName.Width = 88;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 118;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 102;
            // 
            // colBarcode
            // 
            this.colBarcode.Text = "Product Serial #";
            this.colBarcode.Width = 130;
            // 
            // colFault
            // 
            this.colFault.Text = "Fault";
            this.colFault.Width = 90;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 98;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 96;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job#";
            // 
            // colIsCreateJob
            // 
            this.colIsCreateJob.Text = "Is Create Job";
            // 
            // colRefInvNo
            // 
            this.colRefInvNo.Text = "Ref. Invoice#";
            // 
            // colRefInvDate
            // 
            this.colRefInvDate.Text = "Ref. Invoice Date";
            // 
            // btnAssessed
            // 
            this.btnAssessed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssessed.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnAssessed.Location = new System.Drawing.Point(866, 451);
            this.btnAssessed.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAssessed.Name = "btnAssessed";
            this.btnAssessed.Size = new System.Drawing.Size(100, 30);
            this.btnAssessed.TabIndex = 153;
            this.btnAssessed.Text = "Assessed";
            this.btnAssessed.UseVisualStyleBackColor = true;
            this.btnAssessed.Visible = false;
            this.btnAssessed.Click += new System.EventHandler(this.btnAssessed_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproved.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnApproved.Location = new System.Drawing.Point(867, 363);
            this.btnApproved.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(100, 42);
            this.btnApproved.TabIndex = 31;
            this.btnApproved.Text = "Discount Approve";
            this.btnApproved.UseVisualStyleBackColor = true;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnLogNoted
            // 
            this.btnLogNoted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogNoted.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogNoted.Location = new System.Drawing.Point(866, 451);
            this.btnLogNoted.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogNoted.Name = "btnLogNoted";
            this.btnLogNoted.Size = new System.Drawing.Size(100, 30);
            this.btnLogNoted.TabIndex = 155;
            this.btnLogNoted.Text = "Log Noted";
            this.btnLogNoted.UseVisualStyleBackColor = true;
            this.btnLogNoted.Visible = false;
            this.btnLogNoted.Click += new System.EventHandler(this.btnLogNoted_Click);
            // 
            // btnLogReturn
            // 
            this.btnLogReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogReturn.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogReturn.Location = new System.Drawing.Point(867, 451);
            this.btnLogReturn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogReturn.Name = "btnLogReturn";
            this.btnLogReturn.Size = new System.Drawing.Size(100, 30);
            this.btnLogReturn.TabIndex = 40;
            this.btnLogReturn.Text = "Log Return";
            this.btnLogReturn.UseVisualStyleBackColor = true;
            this.btnLogReturn.Visible = false;
            this.btnLogReturn.Click += new System.EventHandler(this.btnLogReturn_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(867, 325);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Reject";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(867, 525);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 30);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Defective#";
            // 
            // txtDefectiveNo
            // 
            this.txtDefectiveNo.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.txtDefectiveNo.Location = new System.Drawing.Point(91, 92);
            this.txtDefectiveNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDefectiveNo.Name = "txtDefectiveNo";
            this.txtDefectiveNo.Size = new System.Drawing.Size(147, 23);
            this.txtDefectiveNo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(48, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Job#";
            // 
            // txtJobNo
            // 
            this.txtJobNo.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.txtJobNo.Location = new System.Drawing.Point(91, 154);
            this.txtJobNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(147, 23);
            this.txtJobNo.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(9, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Showroom:";
            // 
            // txtShowroom
            // 
            this.txtShowroom.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.txtShowroom.Location = new System.Drawing.Point(91, 123);
            this.txtShowroom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtShowroom.Name = "txtShowroom";
            this.txtShowroom.Size = new System.Drawing.Size(147, 23);
            this.txtShowroom.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(512, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Is Create Job";
            // 
            // cmbIsCreateJob
            // 
            this.cmbIsCreateJob.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsCreateJob.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.cmbIsCreateJob.FormattingEnabled = true;
            this.cmbIsCreateJob.Location = new System.Drawing.Point(599, 123);
            this.cmbIsCreateJob.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbIsCreateJob.Name = "cmbIsCreateJob";
            this.cmbIsCreateJob.Size = new System.Drawing.Size(189, 24);
            this.cmbIsCreateJob.TabIndex = 13;
            // 
            // btnJobNoUpdate
            // 
            this.btnJobNoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJobNoUpdate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnJobNoUpdate.Location = new System.Drawing.Point(867, 249);
            this.btnJobNoUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnJobNoUpdate.Name = "btnJobNoUpdate";
            this.btnJobNoUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnJobNoUpdate.TabIndex = 30;
            this.btnJobNoUpdate.Text = "Job# Update";
            this.btnJobNoUpdate.UseVisualStyleBackColor = true;
            this.btnJobNoUpdate.Click += new System.EventHandler(this.btnJobNoUpdate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(501, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Defective Type";
            // 
            // cmbDefectiveType
            // 
            this.cmbDefectiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefectiveType.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.cmbDefectiveType.FormattingEnabled = true;
            this.cmbDefectiveType.Location = new System.Drawing.Point(599, 184);
            this.cmbDefectiveType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDefectiveType.Name = "cmbDefectiveType";
            this.cmbDefectiveType.Size = new System.Drawing.Size(189, 24);
            this.cmbDefectiveType.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightCyan;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(335, 561);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 38;
            this.label8.Text = "Invoiced";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(279, 561);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 37;
            this.label9.Text = "Reject";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(145, 561);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 16);
            this.label11.TabIndex = 36;
            this.label11.Text = "Discount Approved";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.LightGreen;
            this.label17.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(69, 561);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 16);
            this.label17.TabIndex = 35;
            this.label17.Text = "Assessed";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.MistyRose;
            this.label20.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(10, 561);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 16);
            this.label20.TabIndex = 34;
            this.label20.Text = "Create";
            // 
            // cmbPG
            // 
            this.cmbPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPG.FormattingEnabled = true;
            this.cmbPG.Location = new System.Drawing.Point(306, 94);
            this.cmbPG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPG.Name = "cmbPG";
            this.cmbPG.Size = new System.Drawing.Size(189, 24);
            this.cmbPG.TabIndex = 5;
            this.cmbPG.SelectedIndexChanged += new System.EventHandler(this.cmbPG_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(275, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "PG";
            // 
            // cmbMAG
            // 
            this.cmbMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAG.FormattingEnabled = true;
            this.cmbMAG.Location = new System.Drawing.Point(306, 122);
            this.cmbMAG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMAG.Name = "cmbMAG";
            this.cmbMAG.Size = new System.Drawing.Size(189, 24);
            this.cmbMAG.TabIndex = 11;
            this.cmbMAG.SelectedIndexChanged += new System.EventHandler(this.cmbMAG_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(262, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 16);
            this.label12.TabIndex = 10;
            this.label12.Text = "MAG";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(274, 187);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 16);
            this.label13.TabIndex = 22;
            this.label13.Text = "AG";
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(306, 153);
            this.cmbASG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(189, 24);
            this.cmbASG.TabIndex = 17;
            this.cmbASG.SelectedIndexChanged += new System.EventHandler(this.cmbASG_SelectedIndexChanged);
            // 
            // cmbAG
            // 
            this.cmbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAG.FormattingEnabled = true;
            this.cmbAG.Location = new System.Drawing.Point(306, 183);
            this.cmbAG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbAG.Name = "cmbAG";
            this.cmbAG.Size = new System.Drawing.Size(189, 24);
            this.cmbAG.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(267, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 16);
            this.label14.TabIndex = 16;
            this.label14.Text = "ASG";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(552, 98);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(44, 16);
            this.lblBrand.TabIndex = 6;
            this.lblBrand.Text = "Brand";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(599, 94);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(189, 24);
            this.cmbBrand.TabIndex = 7;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // linklblMultiSelectBrands
            // 
            this.linklblMultiSelectBrands.AutoSize = true;
            this.linklblMultiSelectBrands.Location = new System.Drawing.Point(794, 97);
            this.linklblMultiSelectBrands.Name = "linklblMultiSelectBrands";
            this.linklblMultiSelectBrands.Size = new System.Drawing.Size(122, 16);
            this.linklblMultiSelectBrands.TabIndex = 177;
            this.linklblMultiSelectBrands.TabStop = true;
            this.linklblMultiSelectBrands.Text = "Multi Select Brands";
            this.linklblMultiSelectBrands.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblMultiSelectBrands_LinkClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Location = new System.Drawing.Point(867, 287);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.TabIndex = 178;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAcknowledge
            // 
            this.btnAcknowledge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcknowledge.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.btnAcknowledge.Location = new System.Drawing.Point(867, 413);
            this.btnAcknowledge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAcknowledge.Name = "btnAcknowledge";
            this.btnAcknowledge.Size = new System.Drawing.Size(100, 30);
            this.btnAcknowledge.TabIndex = 179;
            this.btnAcknowledge.Text = "Acknowledge";
            this.btnAcknowledge.UseVisualStyleBackColor = true;
            this.btnAcknowledge.Visible = false;
            this.btnAcknowledge.Click += new System.EventHandler(this.btnAcknowledge_Click);
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(91, 216);
            this.ctlProduct1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(590, 25);
            this.ctlProduct1.TabIndex = 27;
            // 
            // frmUnsoldDefectiveProductsHO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 588);
            this.Controls.Add(this.btnAcknowledge);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.linklblMultiSelectBrands);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.cmbPG);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbMAG);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.cmbAG);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbDefectiveType);
            this.Controls.Add(this.btnJobNoUpdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbIsCreateJob);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtShowroom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDefectiveNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogReturn);
            this.Controls.Add(this.btnLogNoted);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnAssessed);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbstatus);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAssessedPlan);
            this.Controls.Add(this.lvwUnsouldDefectiveProducts);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmUnsoldDefectiveProductsHO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUnsoldDefectiveProductsHO";
            this.Load += new System.EventHandler(this.frmUnsoldDefectiveProductsHO_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAssessedPlan;
        private System.Windows.Forms.ListView lvwUnsouldDefectiveProducts;
        private System.Windows.Forms.ColumnHeader colOutletName;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colBarcode;
        private System.Windows.Forms.ColumnHeader colFault;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnAssessed;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Button btnLogNoted;
        private System.Windows.Forms.Button btnLogReturn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colDefectiveNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDefectiveNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShowroom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbIsCreateJob;
        private System.Windows.Forms.ColumnHeader colIsCreateJob;
        private System.Windows.Forms.ColumnHeader colDefectiveType;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.Button btnJobNoUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDefectiveType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbAG;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbMAG;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPG;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cmbBrand;
        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.ColumnHeader colRefInvNo;
        private System.Windows.Forms.ColumnHeader colRefInvDate;
        private System.Windows.Forms.LinkLabel linklblMultiSelectBrands;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAcknowledge;
    }
}