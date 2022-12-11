namespace CJ.Win.Retail
{
    partial class frmOutletDisplayPositions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutletDisplayPositions));
            this.btnADD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblChallanNo = new System.Windows.Forms.Label();
            this.txtPositionCode = new System.Windows.Forms.TextBox();
            this.lvwOutletDisplayPositions = new System.Windows.Forms.ListView();
            this.colShowroomCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAreaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTerritoryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colThanaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDistrictName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPositionCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPositionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRackName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colASGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMAGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBrandDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductSerialNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssignProductDetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpenForAll = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbMAG = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPositionName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTerritory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbThana = new System.Windows.Forms.ComboBox();
            this.lblThanaName = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.cmbPG = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.cmbAG = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductModel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRackName = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.cbOpenForAll = new System.Windows.Forms.CheckBox();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnADD
            // 
            this.btnADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnADD.Location = new System.Drawing.Point(945, 251);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(87, 27);
            this.btnADD.TabIndex = 35;
            this.btnADD.Text = "Add";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(63, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Status:";
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGetData.Location = new System.Drawing.Point(836, 210);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(90, 31);
            this.btnGetData.TabIndex = 33;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(114, 162);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(189, 23);
            this.cmbStatus.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.dtFromdate);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(14, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 51);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(14, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(186, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(100, 21);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(119, 23);
            this.dtFromdate.TabIndex = 2;
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(340, 21);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(119, 23);
            this.dtTodate.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(314, 24);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 15);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFrom.Location = new System.Drawing.Point(60, 24);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(37, 15);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // lblChallanNo
            // 
            this.lblChallanNo.AutoSize = true;
            this.lblChallanNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChallanNo.Location = new System.Drawing.Point(17, 72);
            this.lblChallanNo.Name = "lblChallanNo";
            this.lblChallanNo.Size = new System.Drawing.Size(93, 15);
            this.lblChallanNo.TabIndex = 1;
            this.lblChallanNo.Text = "Position Code:";
            // 
            // txtPositionCode
            // 
            this.txtPositionCode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtPositionCode.Location = new System.Drawing.Point(114, 69);
            this.txtPositionCode.Name = "txtPositionCode";
            this.txtPositionCode.Size = new System.Drawing.Size(189, 23);
            this.txtPositionCode.TabIndex = 2;
            // 
            // lvwOutletDisplayPositions
            // 
            this.lvwOutletDisplayPositions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOutletDisplayPositions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShowroomCode,
            this.colAreaName,
            this.colTerritoryName,
            this.colThanaName,
            this.colDistrictName,
            this.colPositionCode,
            this.colPositionName,
            this.colCreateDate,
            this.colRackName,
            this.colProductCode,
            this.colProductName,
            this.colProductModel,
            this.colAGName,
            this.colASGName,
            this.colMAGName,
            this.colPGName,
            this.colBrandDesc,
            this.colProductSerialNo,
            this.colStatus,
            this.colIsActive,
            this.colAssignProductDetail,
            this.colOpenForAll});
            this.lvwOutletDisplayPositions.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lvwOutletDisplayPositions.FullRowSelect = true;
            this.lvwOutletDisplayPositions.GridLines = true;
            this.lvwOutletDisplayPositions.HideSelection = false;
            this.lvwOutletDisplayPositions.Location = new System.Drawing.Point(14, 251);
            this.lvwOutletDisplayPositions.MultiSelect = false;
            this.lvwOutletDisplayPositions.Name = "lvwOutletDisplayPositions";
            this.lvwOutletDisplayPositions.Size = new System.Drawing.Size(925, 299);
            this.lvwOutletDisplayPositions.TabIndex = 34;
            this.lvwOutletDisplayPositions.UseCompatibleStateImageBehavior = false;
            this.lvwOutletDisplayPositions.View = System.Windows.Forms.View.Details;
            // 
            // colShowroomCode
            // 
            this.colShowroomCode.Text = "Showroom Code";
            this.colShowroomCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colShowroomCode.Width = 93;
            // 
            // colAreaName
            // 
            this.colAreaName.Text = "Area Name";
            this.colAreaName.Width = 96;
            // 
            // colTerritoryName
            // 
            this.colTerritoryName.Text = "Territory Name";
            this.colTerritoryName.Width = 132;
            // 
            // colThanaName
            // 
            this.colThanaName.Text = "Thana Name";
            this.colThanaName.Width = 87;
            // 
            // colDistrictName
            // 
            this.colDistrictName.Text = "District Name";
            this.colDistrictName.Width = 94;
            // 
            // colPositionCode
            // 
            this.colPositionCode.Text = "Position Code";
            this.colPositionCode.Width = 101;
            // 
            // colPositionName
            // 
            this.colPositionName.Text = "Position Name";
            this.colPositionName.Width = 107;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 92;
            // 
            // colRackName
            // 
            this.colRackName.Text = "Rack Name";
            this.colRackName.Width = 93;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 94;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 186;
            // 
            // colProductModel
            // 
            this.colProductModel.Text = "Product Model";
            this.colProductModel.Width = 101;
            // 
            // colAGName
            // 
            this.colAGName.Text = "AG Name";
            this.colAGName.Width = 70;
            // 
            // colASGName
            // 
            this.colASGName.Text = "ASG Name";
            this.colASGName.Width = 78;
            // 
            // colMAGName
            // 
            this.colMAGName.Text = "MAG Name";
            this.colMAGName.Width = 83;
            // 
            // colPGName
            // 
            this.colPGName.Text = "PG Name";
            this.colPGName.Width = 80;
            // 
            // colBrandDesc
            // 
            this.colBrandDesc.Text = "Brand Desc";
            this.colBrandDesc.Width = 81;
            // 
            // colProductSerialNo
            // 
            this.colProductSerialNo.Text = "Product Serial No";
            this.colProductSerialNo.Width = 96;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "IsActive";
            // 
            // colAssignProductDetail
            // 
            this.colAssignProductDetail.Text = "Assign Product Detail";
            // 
            // colOpenForAll
            // 
            this.colOpenForAll.Text = "Open For All";
            this.colOpenForAll.Width = 100;
            // 
            // cmbMAG
            // 
            this.cmbMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAG.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbMAG.FormattingEnabled = true;
            this.cmbMAG.Location = new System.Drawing.Point(358, 130);
            this.cmbMAG.Name = "cmbMAG";
            this.cmbMAG.Size = new System.Drawing.Size(189, 23);
            this.cmbMAG.TabIndex = 16;
            this.cmbMAG.SelectedIndexChanged += new System.EventHandler(this.cmbMAG_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(589, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "Outlet:";
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutlet.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(640, 185);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(189, 23);
            this.cmbOutlet.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(54, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "IsActive:";
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Location = new System.Drawing.Point(114, 129);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(189, 23);
            this.cmbIsActive.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(14, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Position Name:";
            // 
            // txtPositionName
            // 
            this.txtPositionName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtPositionName.Location = new System.Drawing.Point(114, 99);
            this.txtPositionName.Name = "txtPositionName";
            this.txtPositionName.Size = new System.Drawing.Size(189, 23);
            this.txtPositionName.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(945, 523);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(945, 285);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 27);
            this.btnEdit.TabIndex = 36;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.LightSalmon;
            this.label17.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(45, 555);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 15);
            this.label17.TabIndex = 39;
            this.label17.Text = "Blank";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(14, 555);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(22, 15);
            this.label20.TabIndex = 38;
            this.label20.Text = "Fill";
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistrict.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(640, 127);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(189, 23);
            this.cmbDistrict.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(588, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "District";
            // 
            // cmbTerritory
            // 
            this.cmbTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerritory.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbTerritory.FormattingEnabled = true;
            this.cmbTerritory.Location = new System.Drawing.Point(640, 98);
            this.cmbTerritory.Name = "cmbTerritory";
            this.cmbTerritory.Size = new System.Drawing.Size(189, 23);
            this.cmbTerritory.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(578, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Territory";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(640, 69);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(189, 23);
            this.cmbArea.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(602, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Area";
            // 
            // cmbThana
            // 
            this.cmbThana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThana.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbThana.FormattingEnabled = true;
            this.cmbThana.Location = new System.Drawing.Point(640, 156);
            this.cmbThana.Name = "cmbThana";
            this.cmbThana.Size = new System.Drawing.Size(189, 23);
            this.cmbThana.TabIndex = 24;
            // 
            // lblThanaName
            // 
            this.lblThanaName.AutoSize = true;
            this.lblThanaName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThanaName.Location = new System.Drawing.Point(593, 160);
            this.lblThanaName.Name = "lblThanaName";
            this.lblThanaName.Size = new System.Drawing.Size(44, 15);
            this.lblThanaName.TabIndex = 23;
            this.lblThanaName.Text = "Thana";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(358, 69);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(189, 23);
            this.cmbBrand.TabIndex = 4;
            // 
            // cmbPG
            // 
            this.cmbPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPG.FormattingEnabled = true;
            this.cmbPG.Location = new System.Drawing.Point(358, 100);
            this.cmbPG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPG.Name = "cmbPG";
            this.cmbPG.Size = new System.Drawing.Size(189, 23);
            this.cmbPG.TabIndex = 10;
            this.cmbPG.SelectedIndexChanged += new System.EventHandler(this.cmbPG_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(330, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "PG";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(317, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 15;
            this.label12.Text = "MAG";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(329, 195);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 15);
            this.label13.TabIndex = 27;
            this.label13.Text = "AG";
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(358, 160);
            this.cmbASG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(189, 23);
            this.cmbASG.TabIndex = 22;
            this.cmbASG.SelectedIndexChanged += new System.EventHandler(this.cmbASG_SelectedIndexChanged);
            // 
            // cmbAG
            // 
            this.cmbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAG.FormattingEnabled = true;
            this.cmbAG.Location = new System.Drawing.Point(358, 191);
            this.cmbAG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbAG.Name = "cmbAG";
            this.cmbAG.Size = new System.Drawing.Size(189, 23);
            this.cmbAG.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(322, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 15);
            this.label14.TabIndex = 21;
            this.label14.Text = "ASG";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold);
            this.lblProduct.Location = new System.Drawing.Point(52, 225);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(59, 16);
            this.lblProduct.TabIndex = 31;
            this.lblProduct.Text = "Product:";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(311, 72);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(43, 15);
            this.lblBrand.TabIndex = 3;
            this.lblBrand.Text = "Brand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Product Model:";
            // 
            // txtProductModel
            // 
            this.txtProductModel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtProductModel.Location = new System.Drawing.Point(114, 191);
            this.txtProductModel.Name = "txtProductModel";
            this.txtProductModel.Size = new System.Drawing.Size(189, 23);
            this.txtProductModel.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(560, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 40;
            this.label9.Text = "Rack Name:";
            // 
            // cmbRackName
            // 
            this.cmbRackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRackName.FormattingEnabled = true;
            this.cmbRackName.Location = new System.Drawing.Point(640, 214);
            this.cmbRackName.Name = "cmbRackName";
            this.cmbRackName.Size = new System.Drawing.Size(189, 23);
            this.cmbRackName.TabIndex = 41;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(945, 318);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(87, 27);
            this.btnView.TabIndex = 42;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cbOpenForAll
            // 
            this.cbOpenForAll.AutoSize = true;
            this.cbOpenForAll.Location = new System.Drawing.Point(640, 44);
            this.cbOpenForAll.Name = "cbOpenForAll";
            this.cbOpenForAll.Size = new System.Drawing.Size(142, 19);
            this.cbOpenForAll.TabIndex = 43;
            this.cbOpenForAll.Text = "Open for all Models";
            this.cbOpenForAll.UseVisualStyleBackColor = true;
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(114, 220);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(440, 25);
            this.ctlProduct1.TabIndex = 32;
            // 
            // frmOutletDisplayPositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 581);
            this.Controls.Add(this.cbOpenForAll);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbRackName);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProductModel);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.cmbPG);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.cmbAG);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cmbDistrict);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTerritory);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbThana);
            this.Controls.Add(this.lblThanaName);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPositionName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.cmbMAG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOutlet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblChallanNo);
            this.Controls.Add(this.txtPositionCode);
            this.Controls.Add(this.lvwOutletDisplayPositions);
            this.Controls.Add(this.btnADD);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOutletDisplayPositions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOutletDisplayPositions";
            this.Load += new System.EventHandler(this.frmOutletDisplayPositions_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblChallanNo;
        private System.Windows.Forms.TextBox txtPositionCode;
        private System.Windows.Forms.ListView lvwOutletDisplayPositions;
        private System.Windows.Forms.ColumnHeader colPositionCode;
        private System.Windows.Forms.ColumnHeader colPositionName;
        private System.Windows.Forms.ColumnHeader colShowroomCode;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductSerialNo;
        private System.Windows.Forms.ComboBox cmbMAG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPositionName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTerritory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbThana;
        private System.Windows.Forms.Label lblThanaName;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.ComboBox cmbPG;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.ComboBox cmbAG;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtProductModel;
        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colAreaName;
        private System.Windows.Forms.ColumnHeader colTerritoryName;
        private System.Windows.Forms.ColumnHeader colThanaName;
        private System.Windows.Forms.ColumnHeader colDistrictName;
        private System.Windows.Forms.ColumnHeader colProductModel;
        private System.Windows.Forms.ColumnHeader colAGName;
        private System.Windows.Forms.ColumnHeader colASGName;
        private System.Windows.Forms.ColumnHeader colMAGName;
        private System.Windows.Forms.ColumnHeader colPGName;
        private System.Windows.Forms.ColumnHeader colBrandDesc;
        private System.Windows.Forms.ColumnHeader colAssignProductDetail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbRackName;
        private System.Windows.Forms.ColumnHeader colRackName;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ColumnHeader colOpenForAll;
        private System.Windows.Forms.CheckBox cbOpenForAll;
    }
}