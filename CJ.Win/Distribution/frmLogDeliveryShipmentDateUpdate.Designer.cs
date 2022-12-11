namespace CJ.Win.Distribution
{
    partial class frmLogDeliveryShipmentDateUpdate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogDeliveryShipmentDateUpdate));
            this.label3 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDeliveryMode = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbVendor = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.cmbTranType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTerritory = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.cmbThana = new System.Windows.Forms.ComboBox();
            this.lblThanaName = new System.Windows.Forms.Label();
            this.lblTranNo = new System.Windows.Forms.Label();
            this.txtTranNo = new System.Windows.Forms.TextBox();
            this.dgvDeliveryShipment = new System.Windows.Forms.DataGridView();
            this.txtCustomerDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDeliveryMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtParcelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbParcelVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDeliveryDate = new CJ.Win.Control.CalenderControl();
            this.txtDeliveryTime = new CJ.Win.Control.GridTimeControl();
            this.txtTranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtParcelVendorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calenderControl1 = new CJ.Win.Control.CalenderControl();
            this.gridTimeControl1 = new CJ.Win.Control.GridTimeControl();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryShipment)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(73, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "From";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(115, 18);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(126, 23);
            this.dtFromDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(256, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(284, 18);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(128, 23);
            this.dtToDate.TabIndex = 3;
            // 
            // cmbDeliveryMode
            // 
            this.cmbDeliveryMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveryMode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbDeliveryMode.FormattingEnabled = true;
            this.cmbDeliveryMode.Location = new System.Drawing.Point(440, 110);
            this.cmbDeliveryMode.Name = "cmbDeliveryMode";
            this.cmbDeliveryMode.Size = new System.Drawing.Size(220, 23);
            this.cmbDeliveryMode.TabIndex = 19;
            this.cmbDeliveryMode.SelectedIndexChanged += new System.EventHandler(this.cmbDeliveryMode_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(341, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Delivery Mode";
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtVehicleNo.Location = new System.Drawing.Point(115, 81);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.Size = new System.Drawing.Size(220, 23);
            this.txtVehicleNo.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(40, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Vehicle No";
            // 
            // cmbVendor
            // 
            this.cmbVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVendor.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbVendor.FormattingEnabled = true;
            this.cmbVendor.Location = new System.Drawing.Point(440, 140);
            this.cmbVendor.Name = "cmbVendor";
            this.cmbVendor.Size = new System.Drawing.Size(220, 23);
            this.cmbVendor.TabIndex = 25;
            this.cmbVendor.SelectedIndexChanged += new System.EventHandler(this.cmbVendor_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(383, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Vendor";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtCustomer.Location = new System.Drawing.Point(115, 110);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(220, 23);
            this.txtCustomer.TabIndex = 17;
            // 
            // cmbTranType
            // 
            this.cmbTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbTranType.FormattingEnabled = true;
            this.cmbTranType.Location = new System.Drawing.Point(115, 139);
            this.cmbTranType.Name = "cmbTranType";
            this.cmbTranType.Size = new System.Drawing.Size(220, 23);
            this.cmbTranType.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(44, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "Tran Type";
            // 
            // cmbChannel
            // 
            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Location = new System.Drawing.Point(440, 52);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(220, 23);
            this.cmbChannel.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(378, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Channel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(11, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Customer (Like)";
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistrict.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(731, 110);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(220, 23);
            this.cmbDistrict.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(676, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "District";
            // 
            // cmbTerritory
            // 
            this.cmbTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerritory.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbTerritory.FormattingEnabled = true;
            this.cmbTerritory.Location = new System.Drawing.Point(731, 82);
            this.cmbTerritory.Name = "cmbTerritory";
            this.cmbTerritory.Size = new System.Drawing.Size(220, 23);
            this.cmbTerritory.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(666, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Territory";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(731, 52);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(220, 23);
            this.cmbArea.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(690, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Area";
            // 
            // btnGetData
            // 
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetData.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGetData.Location = new System.Drawing.Point(957, 133);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(113, 32);
            this.btnGetData.TabIndex = 29;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // cmbThana
            // 
            this.cmbThana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThana.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbThana.FormattingEnabled = true;
            this.cmbThana.Location = new System.Drawing.Point(731, 140);
            this.cmbThana.Name = "cmbThana";
            this.cmbThana.Size = new System.Drawing.Size(220, 23);
            this.cmbThana.TabIndex = 27;
            // 
            // lblThanaName
            // 
            this.lblThanaName.AutoSize = true;
            this.lblThanaName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThanaName.Location = new System.Drawing.Point(681, 143);
            this.lblThanaName.Name = "lblThanaName";
            this.lblThanaName.Size = new System.Drawing.Size(44, 15);
            this.lblThanaName.TabIndex = 26;
            this.lblThanaName.Text = "Thana";
            // 
            // lblTranNo
            // 
            this.lblTranNo.AutoSize = true;
            this.lblTranNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTranNo.Location = new System.Drawing.Point(55, 55);
            this.lblTranNo.Name = "lblTranNo";
            this.lblTranNo.Size = new System.Drawing.Size(55, 15);
            this.lblTranNo.TabIndex = 4;
            this.lblTranNo.Text = "Tran No";
            // 
            // txtTranNo
            // 
            this.txtTranNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTranNo.Location = new System.Drawing.Point(115, 52);
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.Size = new System.Drawing.Size(220, 23);
            this.txtTranNo.TabIndex = 5;
            // 
            // dgvDeliveryShipment
            // 
            this.dgvDeliveryShipment.AllowUserToAddRows = false;
            this.dgvDeliveryShipment.AllowUserToDeleteRows = false;
            this.dgvDeliveryShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryShipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCustomerDetail,
            this.txtDeliveryMode,
            this.txtParcelType,
            this.txtVendor,
            this.dataGridViewTextBoxColumn1,
            this.txtTranType,
            this.dataGridViewTextBoxColumn2,
            this.txtTranDate,
            this.cmbParcelVendor,
            this.chk,
            this.colDeliveryDate,
            this.txtDeliveryTime,
            this.txtTranID,
            this.txtParcelVendorID,
            this.ShipmentNo});
            this.dgvDeliveryShipment.Location = new System.Drawing.Point(14, 169);
            this.dgvDeliveryShipment.Name = "dgvDeliveryShipment";
            this.dgvDeliveryShipment.Size = new System.Drawing.Size(1113, 337);
            this.dgvDeliveryShipment.TabIndex = 28;
            this.dgvDeliveryShipment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryShipment_CellContentClick);
            // 
            // txtCustomerDetail
            // 
            this.txtCustomerDetail.HeaderText = "Customer Name";
            this.txtCustomerDetail.Name = "txtCustomerDetail";
            // 
            // txtDeliveryMode
            // 
            this.txtDeliveryMode.HeaderText = "Delivery Mode";
            this.txtDeliveryMode.Name = "txtDeliveryMode";
            this.txtDeliveryMode.ReadOnly = true;
            // 
            // txtParcelType
            // 
            this.txtParcelType.HeaderText = "Parcel Type";
            this.txtParcelType.Name = "txtParcelType";
            this.txtParcelType.ReadOnly = true;
            this.txtParcelType.Width = 80;
            // 
            // txtVendor
            // 
            this.txtVendor.HeaderText = "Vendor";
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Vehicle#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // txtTranType
            // 
            this.txtTranType.HeaderText = "Tran Type";
            this.txtTranType.Name = "txtTranType";
            this.txtTranType.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tran#";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 90;
            // 
            // txtTranDate
            // 
            this.txtTranDate.HeaderText = "Tran Date ";
            this.txtTranDate.Name = "txtTranDate";
            this.txtTranDate.ReadOnly = true;
            // 
            // cmbParcelVendor
            // 
            this.cmbParcelVendor.HeaderText = "Parcel Vendor";
            this.cmbParcelVendor.Name = "cmbParcelVendor";
            this.cmbParcelVendor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbParcelVendor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chk
            // 
            this.chk.HeaderText = "??";
            this.chk.Name = "chk";
            this.chk.Width = 30;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.HeaderText = "Receive Date";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDeliveryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colDeliveryDate.Width = 110;
            // 
            // txtDeliveryTime
            // 
            dataGridViewCellStyle1.Format = "t";
            dataGridViewCellStyle1.NullValue = null;
            this.txtDeliveryTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtDeliveryTime.HeaderText = "Receive Time";
            this.txtDeliveryTime.Name = "txtDeliveryTime";
            // 
            // txtTranID
            // 
            this.txtTranID.HeaderText = "TranID";
            this.txtTranID.Name = "txtTranID";
            this.txtTranID.ReadOnly = true;
            this.txtTranID.Visible = false;
            // 
            // txtParcelVendorID
            // 
            this.txtParcelVendorID.HeaderText = "ShipmentID";
            this.txtParcelVendorID.Name = "txtParcelVendorID";
            this.txtParcelVendorID.ReadOnly = true;
            this.txtParcelVendorID.Visible = false;
            // 
            // ShipmentNo
            // 
            this.ShipmentNo.HeaderText = "Shipment#";
            this.ShipmentNo.Name = "ShipmentNo";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(1032, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 27);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(930, 511);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 27);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(440, 82);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(220, 23);
            this.cmbCompany.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(370, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Company";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Vendor";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Vehicle#";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Tran Type";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Tran#";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Tran Date ";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Parcel Vendor";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // calenderControl1
            // 
            this.calenderControl1.HeaderText = "Receive Date";
            this.calenderControl1.Name = "calenderControl1";
            this.calenderControl1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calenderControl1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calenderControl1.Width = 110;
            // 
            // gridTimeControl1
            // 
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.gridTimeControl1.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridTimeControl1.HeaderText = "Receive Time";
            this.gridTimeControl1.Name = "gridTimeControl1";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "TranID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "ShipmentID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // frmLogDeliveryShipmentDateUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 550);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvDeliveryShipment);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDeliveryMode);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtVehicleNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbVendor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtCustomer);
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
            this.Controls.Add(this.cmbThana);
            this.Controls.Add(this.lblThanaName);
            this.Controls.Add(this.lblTranNo);
            this.Controls.Add(this.txtTranNo);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogDeliveryShipmentDateUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log Delivery Shipments";
            this.Load += new System.EventHandler(this.frmLogDeliveryShipmentDateUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryShipment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.ComboBox cmbDeliveryMode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbVendor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.ComboBox cmbTranType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTerritory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ComboBox cmbThana;
        private System.Windows.Forms.Label lblThanaName;
        private System.Windows.Forms.Label lblTranNo;
        private System.Windows.Forms.TextBox txtTranNo;
        private System.Windows.Forms.DataGridView dgvDeliveryShipment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Control.CalenderControl calenderControl1;
        private Control.GridTimeControl gridTimeControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtParcelVendorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranID;
        private Control.GridTimeControl txtDeliveryTime;
        private Control.CalenderControl colDeliveryDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmbParcelVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtParcelType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDeliveryMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCustomerDetail;
    }
}