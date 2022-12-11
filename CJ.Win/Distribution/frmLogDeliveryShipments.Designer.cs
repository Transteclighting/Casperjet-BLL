namespace CJ.Win.Distribution
{
    partial class frmLogDeliveryShipments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogDeliveryShipments));
            this.btnGetData = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.colTranType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.colTranDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.colTranNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwDeliveryShipment = new System.Windows.Forms.ListView();
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeliveryMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParcelType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVendor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVehicleNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVehicleCapacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAreaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTerritoryName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colThanaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDistrictName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChannelDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGatePassNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbThana = new System.Windows.Forms.ComboBox();
            this.lblThanaName = new System.Windows.Forms.Label();
            this.lblTranNo = new System.Windows.Forms.Label();
            this.txtTranNo = new System.Windows.Forms.TextBox();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTerritory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTranType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btSelectAll = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbDeliveryMode = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnReceiveDateUpdate = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGatePassNo = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetData
            // 
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetData.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGetData.Location = new System.Drawing.Point(869, 164);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(97, 28);
            this.btnGetData.TabIndex = 27;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(987, 547);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 27);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(987, 220);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 27);
            this.btnAdd.TabIndex = 29;
            this.btnAdd.Text = "Add Shipment";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // colTranType
            // 
            this.colTranType.Text = "Tran Type";
            this.colTranType.Width = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(164, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "To";
            // 
            // colTranDate
            // 
            this.colTranDate.Text = "TranDate";
            this.colTranDate.Width = 85;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(9, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(186, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // colTranNo
            // 
            this.colTranNo.Text = "Tran#";
            this.colTranNo.Width = 97;
            // 
            // lvwDeliveryShipment
            // 
            this.lvwDeliveryShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDeliveryShipment.CheckBoxes = true;
            this.lvwDeliveryShipment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCompany,
            this.colTranType,
            this.colDeliveryMode,
            this.colParcelType,
            this.colVendor,
            this.colVehicleNo,
            this.colVehicleCapacity,
            this.colTranNo,
            this.colTranDate,
            this.colCustomerCode,
            this.colCustomerName,
            this.colAreaName,
            this.colTerritoryName,
            this.colThanaName,
            this.colDistrictName,
            this.colChannelDescription,
            this.colTranAmount,
            this.colGatePassNo});
            this.lvwDeliveryShipment.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lvwDeliveryShipment.FullRowSelect = true;
            this.lvwDeliveryShipment.GridLines = true;
            this.lvwDeliveryShipment.HideSelection = false;
            this.lvwDeliveryShipment.Location = new System.Drawing.Point(12, 220);
            this.lvwDeliveryShipment.MultiSelect = false;
            this.lvwDeliveryShipment.Name = "lvwDeliveryShipment";
            this.lvwDeliveryShipment.Size = new System.Drawing.Size(965, 354);
            this.lvwDeliveryShipment.TabIndex = 28;
            this.lvwDeliveryShipment.UseCompatibleStateImageBehavior = false;
            this.lvwDeliveryShipment.View = System.Windows.Forms.View.Details;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Parent WH";
            this.colCompany.Width = 70;
            // 
            // colDeliveryMode
            // 
            this.colDeliveryMode.Text = "Delivery Mode";
            this.colDeliveryMode.Width = 106;
            // 
            // colParcelType
            // 
            this.colParcelType.Text = "Parcel Type";
            this.colParcelType.Width = 83;
            // 
            // colVendor
            // 
            this.colVendor.Text = "Vendor";
            this.colVendor.Width = 90;
            // 
            // colVehicleNo
            // 
            this.colVehicleNo.Text = "Vehicle No";
            this.colVehicleNo.Width = 116;
            // 
            // colVehicleCapacity
            // 
            this.colVehicleCapacity.Text = "Vehicle Capacity";
            this.colVehicleCapacity.Width = 110;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Text = "Customer Code";
            this.colCustomerCode.Width = 111;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 166;
            // 
            // colAreaName
            // 
            this.colAreaName.Text = "Area";
            this.colAreaName.Width = 118;
            // 
            // colTerritoryName
            // 
            this.colTerritoryName.Text = "Territory";
            this.colTerritoryName.Width = 133;
            // 
            // colThanaName
            // 
            this.colThanaName.Text = "Thana";
            this.colThanaName.Width = 101;
            // 
            // colDistrictName
            // 
            this.colDistrictName.Text = "District";
            this.colDistrictName.Width = 104;
            // 
            // colChannelDescription
            // 
            this.colChannelDescription.Text = "Channel";
            this.colChannelDescription.Width = 81;
            // 
            // colTranAmount
            // 
            this.colTranAmount.Text = "Tran Amount";
            this.colTranAmount.Width = 74;
            // 
            // colGatePassNo
            // 
            this.colGatePassNo.Text = "Gate Pass#";
            // 
            // cmbThana
            // 
            this.cmbThana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThana.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbThana.FormattingEnabled = true;
            this.cmbThana.Location = new System.Drawing.Point(674, 167);
            this.cmbThana.Name = "cmbThana";
            this.cmbThana.Size = new System.Drawing.Size(189, 23);
            this.cmbThana.TabIndex = 25;
            // 
            // lblThanaName
            // 
            this.lblThanaName.AutoSize = true;
            this.lblThanaName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThanaName.Location = new System.Drawing.Point(626, 171);
            this.lblThanaName.Name = "lblThanaName";
            this.lblThanaName.Size = new System.Drawing.Size(44, 15);
            this.lblThanaName.TabIndex = 24;
            this.lblThanaName.Text = "Thana";
            // 
            // lblTranNo
            // 
            this.lblTranNo.AutoSize = true;
            this.lblTranNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTranNo.Location = new System.Drawing.Point(52, 83);
            this.lblTranNo.Name = "lblTranNo";
            this.lblTranNo.Size = new System.Drawing.Size(55, 15);
            this.lblTranNo.TabIndex = 2;
            this.lblTranNo.Text = "Tran No";
            // 
            // txtTranNo
            // 
            this.txtTranNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTranNo.Location = new System.Drawing.Point(110, 80);
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.Size = new System.Drawing.Size(189, 23);
            this.txtTranNo.TabIndex = 3;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(195, 25);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(110, 23);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(48, 25);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(109, 23);
            this.dtFromDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(20, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(674, 80);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(189, 23);
            this.cmbArea.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(635, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Area";
            // 
            // cmbTerritory
            // 
            this.cmbTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerritory.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbTerritory.FormattingEnabled = true;
            this.cmbTerritory.Location = new System.Drawing.Point(674, 109);
            this.cmbTerritory.Name = "cmbTerritory";
            this.cmbTerritory.Size = new System.Drawing.Size(189, 23);
            this.cmbTerritory.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(611, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Territory";
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistrict.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(674, 138);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(189, 23);
            this.cmbDistrict.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(621, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "District";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(9, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Customer (Like)";
            // 
            // cmbChannel
            // 
            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Location = new System.Drawing.Point(400, 80);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(189, 23);
            this.cmbChannel.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(341, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Channel";
            // 
            // cmbTranType
            // 
            this.cmbTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbTranType.FormattingEnabled = true;
            this.cmbTranType.Location = new System.Drawing.Point(110, 167);
            this.cmbTranType.Name = "cmbTranType";
            this.cmbTranType.Size = new System.Drawing.Size(189, 23);
            this.cmbTranType.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(41, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Tran Type";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(400, 109);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(189, 23);
            this.cmbCompany.TabIndex = 13;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(333, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Company";
            // 
            // btSelectAll
            // 
            this.btSelectAll.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSelectAll.Location = new System.Drawing.Point(13, 196);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(77, 21);
            this.btSelectAll.TabIndex = 26;
            this.btSelectAll.Text = "Checked All";
            this.btSelectAll.UseVisualStyleBackColor = true;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(987, 254);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 27);
            this.btnEdit.TabIndex = 30;
            this.btnEdit.Text = "Edit Shipment";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtCustomer.Location = new System.Drawing.Point(110, 138);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(189, 23);
            this.txtCustomer.TabIndex = 7;
            // 
            // cmbVendor
            // 
            this.cmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendor.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(400, 167);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(189, 23);
            this.cmbVendor.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(346, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "Vendor";
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtVehicleNo.Location = new System.Drawing.Point(110, 109);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.Size = new System.Drawing.Size(189, 23);
            this.txtVehicleNo.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(37, 112);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "Vehicle No";
            // 
            // cmbDeliveryMode
            // 
            this.cmbDeliveryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryMode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbDeliveryMode.FormattingEnabled = true;
            this.cmbDeliveryMode.Location = new System.Drawing.Point(400, 138);
            this.cmbDeliveryMode.Name = "cmbDeliveryMode";
            this.cmbDeliveryMode.Size = new System.Drawing.Size(189, 23);
            this.cmbDeliveryMode.TabIndex = 15;
            this.cmbDeliveryMode.SelectedIndexChanged += new System.EventHandler(this.cmbDeliveryMode_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(304, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 15);
            this.label12.TabIndex = 14;
            this.label12.Text = "Delivery Mode";
            // 
            // btnReceiveDateUpdate
            // 
            this.btnReceiveDateUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReceiveDateUpdate.Location = new System.Drawing.Point(987, 287);
            this.btnReceiveDateUpdate.Name = "btnReceiveDateUpdate";
            this.btnReceiveDateUpdate.Size = new System.Drawing.Size(94, 39);
            this.btnReceiveDateUpdate.TabIndex = 32;
            this.btnReceiveDateUpdate.Text = "Receive Date Update";
            this.btnReceiveDateUpdate.UseVisualStyleBackColor = true;
            this.btnReceiveDateUpdate.Click += new System.EventHandler(this.btnReceiveDateUpdate_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(592, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 15);
            this.label13.TabIndex = 33;
            this.label13.Text = "Gate Pass #";
            // 
            // txtGatePassNo
            // 
            this.txtGatePassNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtGatePassNo.Location = new System.Drawing.Point(674, 48);
            this.txtGatePassNo.Name = "txtGatePassNo";
            this.txtGatePassNo.Size = new System.Drawing.Size(189, 23);
            this.txtGatePassNo.TabIndex = 34;
            // 
            // frmLogDeliveryShipments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 586);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtGatePassNo);
            this.Controls.Add(this.btnReceiveDateUpdate);
            this.Controls.Add(this.cmbDeliveryMode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtVehicleNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbVendor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btSelectAll);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbTranType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbChannel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDistrict);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbTerritory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwDeliveryShipment);
            this.Controls.Add(this.cmbThana);
            this.Controls.Add(this.lblThanaName);
            this.Controls.Add(this.lblTranNo);
            this.Controls.Add(this.txtTranNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogDeliveryShipments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogDeliveryShipments";
            this.Load += new System.EventHandler(this.frmLogDeliveryShipments_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colTranType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colTranDate;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ColumnHeader colTranNo;
        private System.Windows.Forms.ListView lvwDeliveryShipment;
        private System.Windows.Forms.ComboBox cmbThana;
        private System.Windows.Forms.Label lblThanaName;
        private System.Windows.Forms.Label lblTranNo;
        private System.Windows.Forms.TextBox txtTranNo;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colAreaName;
        private System.Windows.Forms.ColumnHeader colTerritoryName;
        private System.Windows.Forms.ColumnHeader colThanaName;
        private System.Windows.Forms.ColumnHeader colDistrictName;
        private System.Windows.Forms.ColumnHeader colChannelDescription;
        private System.Windows.Forms.ColumnHeader colTranAmount;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTerritory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTranType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.Button btSelectAll;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.ComboBox cmbVendor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ColumnHeader colVendor;
        private System.Windows.Forms.ColumnHeader colVehicleNo;
        private System.Windows.Forms.ColumnHeader colDeliveryMode;
        private System.Windows.Forms.ColumnHeader colParcelType;
        private System.Windows.Forms.ComboBox cmbDeliveryMode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnReceiveDateUpdate;
        private System.Windows.Forms.ColumnHeader colGatePassNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGatePassNo;
        private System.Windows.Forms.ColumnHeader colVehicleCapacity;
    }
}