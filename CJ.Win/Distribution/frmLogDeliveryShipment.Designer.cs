namespace CJ.Win.Distribution
{
    partial class frmLogDeliveryShipment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogDeliveryShipment));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblShipmentDate = new System.Windows.Forms.Label();
            this.dtShipmentDate = new System.Windows.Forms.DateTimePicker();
            this.txtGatePassNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvDeliveryShipment = new System.Windows.Forms.DataGridView();
            this.txtCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDeliveryMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtParcelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStockPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFreightCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtParcelCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbParcelVendor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtLocalDeliveryCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDeliveryDate = new CJ.Win.Control.CalenderControl();
            this.txtDeliveryTime = new CJ.Win.Control.GridTimeControl();
            this.txtRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVendorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDeliveryModeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtParcelTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtParcelVendorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVehicalCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStockAmount = new System.Windows.Forms.TextBox();
            this.txtFreightAmount = new System.Windows.Forms.TextBox();
            this.txtLocalDeliveryAmount = new System.Windows.Forms.TextBox();
            this.txtFreghtAmount = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTimeControl1 = new CJ.Win.Control.GridTimeControl();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPaecelAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryShipment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1150, 457);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 30);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1045, 457);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 30);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblShipmentDate
            // 
            this.lblShipmentDate.AutoSize = true;
            this.lblShipmentDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShipmentDate.Location = new System.Drawing.Point(10, 18);
            this.lblShipmentDate.Name = "lblShipmentDate";
            this.lblShipmentDate.Size = new System.Drawing.Size(95, 15);
            this.lblShipmentDate.TabIndex = 0;
            this.lblShipmentDate.Text = "Shipment Date";
            // 
            // dtShipmentDate
            // 
            this.dtShipmentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtShipmentDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtShipmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShipmentDate.Location = new System.Drawing.Point(111, 12);
            this.dtShipmentDate.Name = "dtShipmentDate";
            this.dtShipmentDate.Size = new System.Drawing.Size(156, 23);
            this.dtShipmentDate.TabIndex = 1;
            // 
            // txtGatePassNo
            // 
            this.txtGatePassNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGatePassNo.Location = new System.Drawing.Point(111, 41);
            this.txtGatePassNo.Name = "txtGatePassNo";
            this.txtGatePassNo.Size = new System.Drawing.Size(156, 23);
            this.txtGatePassNo.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Gate Pass No.";
            // 
            // dgvDeliveryShipment
            // 
            this.dgvDeliveryShipment.AllowUserToAddRows = false;
            this.dgvDeliveryShipment.AllowUserToDeleteRows = false;
            this.dgvDeliveryShipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryShipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtCompany,
            this.txtDeliveryMode,
            this.txtParcelType,
            this.txtVendor,
            this.txtVehicleNo,
            this.txtTranType,
            this.txtTranNo,
            this.txtTranDate,
            this.txtStockPrice,
            this.txtFreightCost,
            this.txtParcelCost,
            this.cmbParcelVendor,
            this.txtLocalDeliveryCost,
            this.chk,
            this.colDeliveryDate,
            this.txtDeliveryTime,
            this.txtRemarks,
            this.txtTranID,
            this.txtVendorID,
            this.txtVehicleID,
            this.txtDeliveryModeID,
            this.txtParcelTypeID,
            this.txtParcelVendorID,
            this.txtVehicalCapacity});
            this.dgvDeliveryShipment.Location = new System.Drawing.Point(14, 70);
            this.dgvDeliveryShipment.Name = "dgvDeliveryShipment";
            this.dgvDeliveryShipment.Size = new System.Drawing.Size(1232, 381);
            this.dgvDeliveryShipment.TabIndex = 6;
            this.dgvDeliveryShipment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryShipment_CellContentClick);
            this.dgvDeliveryShipment.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeliveryShipment_CellValueChanged);
            // 
            // txtCompany
            // 
            this.txtCompany.HeaderText = "Company";
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Visible = false;
            this.txtCompany.Width = 80;
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
            // 
            // txtVendor
            // 
            this.txtVendor.HeaderText = "Vendor";
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.ReadOnly = true;
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.HeaderText = "Vehicle#";
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.ReadOnly = true;
            this.txtVehicleNo.Width = 80;
            // 
            // txtTranType
            // 
            this.txtTranType.HeaderText = "Tran Type";
            this.txtTranType.Name = "txtTranType";
            this.txtTranType.ReadOnly = true;
            this.txtTranType.Width = 50;
            // 
            // txtTranNo
            // 
            this.txtTranNo.HeaderText = "Tran#";
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.ReadOnly = true;
            // 
            // txtTranDate
            // 
            this.txtTranDate.HeaderText = "Tran Date ";
            this.txtTranDate.Name = "txtTranDate";
            this.txtTranDate.ReadOnly = true;
            this.txtTranDate.Width = 85;
            // 
            // txtStockPrice
            // 
            this.txtStockPrice.HeaderText = "Stock Price";
            this.txtStockPrice.Name = "txtStockPrice";
            this.txtStockPrice.ReadOnly = true;
            this.txtStockPrice.Width = 80;
            // 
            // txtFreightCost
            // 
            this.txtFreightCost.HeaderText = "Freight Cost";
            this.txtFreightCost.Name = "txtFreightCost";
            this.txtFreightCost.Width = 55;
            // 
            // txtParcelCost
            // 
            this.txtParcelCost.HeaderText = "Parcel Cost";
            this.txtParcelCost.Name = "txtParcelCost";
            this.txtParcelCost.Width = 55;
            // 
            // cmbParcelVendor
            // 
            this.cmbParcelVendor.HeaderText = "Parcel Vendor";
            this.cmbParcelVendor.Name = "cmbParcelVendor";
            // 
            // txtLocalDeliveryCost
            // 
            this.txtLocalDeliveryCost.HeaderText = "Local Delivery Cost";
            this.txtLocalDeliveryCost.Name = "txtLocalDeliveryCost";
            this.txtLocalDeliveryCost.Width = 60;
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
            // 
            // txtDeliveryTime
            // 
            dataGridViewCellStyle1.Format = "t";
            dataGridViewCellStyle1.NullValue = null;
            this.txtDeliveryTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtDeliveryTime.HeaderText = "Receive Time";
            this.txtDeliveryTime.Name = "txtDeliveryTime";
            // 
            // txtRemarks
            // 
            this.txtRemarks.HeaderText = "Remarks";
            this.txtRemarks.Name = "txtRemarks";
            // 
            // txtTranID
            // 
            this.txtTranID.HeaderText = "TranID";
            this.txtTranID.Name = "txtTranID";
            this.txtTranID.ReadOnly = true;
            this.txtTranID.Visible = false;
            // 
            // txtVendorID
            // 
            this.txtVendorID.HeaderText = "VehicleVendorID";
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.ReadOnly = true;
            this.txtVendorID.Visible = false;
            // 
            // txtVehicleID
            // 
            this.txtVehicleID.HeaderText = "VehicleID";
            this.txtVehicleID.Name = "txtVehicleID";
            this.txtVehicleID.ReadOnly = true;
            this.txtVehicleID.Visible = false;
            // 
            // txtDeliveryModeID
            // 
            this.txtDeliveryModeID.HeaderText = "DeliveryModeID";
            this.txtDeliveryModeID.Name = "txtDeliveryModeID";
            this.txtDeliveryModeID.ReadOnly = true;
            this.txtDeliveryModeID.Visible = false;
            // 
            // txtParcelTypeID
            // 
            this.txtParcelTypeID.HeaderText = "ParcelType";
            this.txtParcelTypeID.Name = "txtParcelTypeID";
            this.txtParcelTypeID.ReadOnly = true;
            this.txtParcelTypeID.Visible = false;
            // 
            // txtParcelVendorID
            // 
            this.txtParcelVendorID.HeaderText = "ParcelVendorID";
            this.txtParcelVendorID.Name = "txtParcelVendorID";
            this.txtParcelVendorID.ReadOnly = true;
            this.txtParcelVendorID.Visible = false;
            // 
            // txtVehicalCapacity
            // 
            this.txtVehicalCapacity.HeaderText = "VehicalCapacity";
            this.txtVehicalCapacity.Name = "txtVehicalCapacity";
            this.txtVehicalCapacity.ReadOnly = true;
            this.txtVehicalCapacity.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(277, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Freight Cost";
            // 
            // txtStockAmount
            // 
            this.txtStockAmount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockAmount.Location = new System.Drawing.Point(87, 461);
            this.txtStockAmount.Name = "txtStockAmount";
            this.txtStockAmount.ReadOnly = true;
            this.txtStockAmount.Size = new System.Drawing.Size(111, 23);
            this.txtStockAmount.TabIndex = 7;
            this.txtStockAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFreightAmount
            // 
            this.txtFreightAmount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFreightAmount.Location = new System.Drawing.Point(286, 461);
            this.txtFreightAmount.Name = "txtFreightAmount";
            this.txtFreightAmount.ReadOnly = true;
            this.txtFreightAmount.Size = new System.Drawing.Size(111, 23);
            this.txtFreightAmount.TabIndex = 8;
            this.txtFreightAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLocalDeliveryAmount
            // 
            this.txtLocalDeliveryAmount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalDeliveryAmount.Location = new System.Drawing.Point(721, 461);
            this.txtLocalDeliveryAmount.Name = "txtLocalDeliveryAmount";
            this.txtLocalDeliveryAmount.ReadOnly = true;
            this.txtLocalDeliveryAmount.Size = new System.Drawing.Size(111, 23);
            this.txtLocalDeliveryAmount.TabIndex = 9;
            this.txtLocalDeliveryAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFreghtAmount
            // 
            this.txtFreghtAmount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFreghtAmount.Location = new System.Drawing.Point(362, 41);
            this.txtFreghtAmount.Name = "txtFreghtAmount";
            this.txtFreghtAmount.Size = new System.Drawing.Size(135, 23);
            this.txtFreghtAmount.TabIndex = 5;
            //this.txtFreghtAmount.TextChanged += new System.EventHandler(this.txtFreghtAmount_TextChanged);
            this.txtFreghtAmount.Leave += new System.EventHandler(this.txtFreghtAmount_Leave);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Company";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tran No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tran Date ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Stock Price";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Freight Cost";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Local Delivery Cost";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "TranID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 70;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Freight Cost";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Local Delivery Cost";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "TranID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "VehicleVendorID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "VehicleID";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Parcel Cost";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // gridTimeControl1
            // 
            dataGridViewCellStyle2.Format = "t";
            dataGridViewCellStyle2.NullValue = null;
            this.gridTimeControl1.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridTimeControl1.HeaderText = "Actual DeliveryTime";
            this.gridTimeControl1.Name = "gridTimeControl1";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // txtPaecelAmount
            // 
            this.txtPaecelAmount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaecelAmount.Location = new System.Drawing.Point(478, 461);
            this.txtPaecelAmount.Name = "txtPaecelAmount";
            this.txtPaecelAmount.ReadOnly = true;
            this.txtPaecelAmount.Size = new System.Drawing.Size(111, 23);
            this.txtPaecelAmount.TabIndex = 12;
            this.txtPaecelAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Stock Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(204, 465);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Freight Cost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(599, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Local Delivery Cost";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(402, 465);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Parcel Cost";
            // 
            // frmLogDeliveryShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 497);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPaecelAmount);
            this.Controls.Add(this.txtLocalDeliveryAmount);
            this.Controls.Add(this.txtFreightAmount);
            this.Controls.Add(this.txtStockAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFreghtAmount);
            this.Controls.Add(this.dgvDeliveryShipment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGatePassNo);
            this.Controls.Add(this.lblShipmentDate);
            this.Controls.Add(this.dtShipmentDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogDeliveryShipment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogDeliveryShipment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryShipment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblShipmentDate;
        private System.Windows.Forms.DateTimePicker dtShipmentDate;
        private System.Windows.Forms.TextBox txtGatePassNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvDeliveryShipment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TextBox txtStockAmount;
        private System.Windows.Forms.TextBox txtFreightAmount;
        private System.Windows.Forms.TextBox txtLocalDeliveryAmount;
        private System.Windows.Forms.TextBox txtFreghtAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private Control.GridTimeControl gridTimeControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.TextBox txtPaecelAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDeliveryMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtParcelType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVehicleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStockPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtFreightCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtParcelCost;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbParcelVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLocalDeliveryCost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chk;
        private Control.CalenderControl colDeliveryDate;
        private Control.GridTimeControl txtDeliveryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTranID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVendorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVehicleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDeliveryModeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtParcelTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtParcelVendorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtVehicalCapacity;
    }
}