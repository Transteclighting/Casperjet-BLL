namespace CJ.Win.Inventory
{
    partial class frmStockTransfer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockTransfer));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackingQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBarcodeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIsBarcodeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbToChannel = new System.Windows.Forms.ComboBox();
            this.dtTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.cmbFromWH = new System.Windows.Forms.ComboBox();
            this.cmbToWH = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFromChannel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblTransactionRefNo = new System.Windows.Forms.Label();
            this.txtTransationNo = new System.Windows.Forms.TextBox();
            this.txtFromChannelCode = new System.Windows.Forms.TextBox();
            this.txtFromWHCode = new System.Windows.Forms.TextBox();
            this.txtToWHCode = new System.Windows.Forms.TextBox();
            this.txtToChannelCode = new System.Windows.Forms.TextBox();
            this.txtIMEIList = new System.Windows.Forms.TextBox();
            this.btIMEIValid = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTransferType = new System.Windows.Forms.ComboBox();
            this.lblTransferType = new System.Windows.Forms.Label();
            this.rdoStockIn = new System.Windows.Forms.RadioButton();
            this.rdoStockOut = new System.Windows.Forms.RadioButton();
            this.lblTransSide = new System.Windows.Forms.Label();
            this.lblLoanRefNo = new System.Windows.Forms.Label();
            this.txtLoanRefNo = new System.Windows.Forms.TextBox();
            this.txtVehicleNumber = new System.Windows.Forms.TextBox();
            this.lblVehicleNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1006, 494);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 30);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(896, 494);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 30);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(461, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "To Channel:";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.txtQuantity,
            this.currentStock,
            this.PackingQty,
            this.ColProductID,
            this.txtBarcodeQty,
            this.txtIsBarcodeItem});
            this.dgvLineItem.Location = new System.Drawing.Point(12, 149);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(835, 343);
            this.dgvLineItem.TabIndex = 21;
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductCode.Frozen = true;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 108;
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.Frozen = true;
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Width = 30;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDescription.Frozen = true;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 270;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Frozen = true;
            this.txtQuantity.HeaderText = "Quantity";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Width = 90;
            // 
            // currentStock
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.currentStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.currentStock.Frozen = true;
            this.currentStock.HeaderText = "CurrentStock";
            this.currentStock.Name = "currentStock";
            this.currentStock.ReadOnly = true;
            this.currentStock.Width = 90;
            // 
            // PackingQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PackingQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.PackingQty.Frozen = true;
            this.PackingQty.HeaderText = "Packing Qty";
            this.PackingQty.Name = "PackingQty";
            this.PackingQty.ReadOnly = true;
            this.PackingQty.Visible = false;
            this.PackingQty.Width = 90;
            // 
            // ColProductID
            // 
            this.ColProductID.HeaderText = "ProductID";
            this.ColProductID.Name = "ColProductID";
            this.ColProductID.ReadOnly = true;
            this.ColProductID.Visible = false;
            // 
            // txtBarcodeQty
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBarcodeQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtBarcodeQty.HeaderText = "Barcode Qty";
            this.txtBarcodeQty.Name = "txtBarcodeQty";
            this.txtBarcodeQty.ReadOnly = true;
            this.txtBarcodeQty.Width = 110;
            // 
            // txtIsBarcodeItem
            // 
            this.txtIsBarcodeItem.HeaderText = "IsBarcodeItem";
            this.txtIsBarcodeItem.Name = "txtIsBarcodeItem";
            this.txtIsBarcodeItem.ReadOnly = true;
            this.txtIsBarcodeItem.Visible = false;
            // 
            // cmbToChannel
            // 
            this.cmbToChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToChannel.FormattingEnabled = true;
            this.cmbToChannel.Location = new System.Drawing.Point(605, 89);
            this.cmbToChannel.Name = "cmbToChannel";
            this.cmbToChannel.Size = new System.Drawing.Size(243, 23);
            this.cmbToChannel.TabIndex = 14;
            this.cmbToChannel.SelectedIndexChanged += new System.EventHandler(this.cmbToChannel_SelectedIndexChanged);
            // 
            // dtTransactionDate
            // 
            this.dtTransactionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtTransactionDate.Enabled = false;
            this.dtTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransactionDate.Location = new System.Drawing.Point(121, 61);
            this.dtTransactionDate.Name = "dtTransactionDate";
            this.dtTransactionDate.Size = new System.Drawing.Size(195, 23);
            this.dtTransactionDate.TabIndex = 6;
            this.dtTransactionDate.Tag = "M1.21";
            // 
            // cmbFromWH
            // 
            this.cmbFromWH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromWH.FormattingEnabled = true;
            this.cmbFromWH.Location = new System.Drawing.Point(188, 120);
            this.cmbFromWH.Name = "cmbFromWH";
            this.cmbFromWH.Size = new System.Drawing.Size(251, 23);
            this.cmbFromWH.TabIndex = 17;
            // 
            // cmbToWH
            // 
            this.cmbToWH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToWH.FormattingEnabled = true;
            this.cmbToWH.Location = new System.Drawing.Point(605, 119);
            this.cmbToWH.Name = "cmbToWH";
            this.cmbToWH.Size = new System.Drawing.Size(243, 23);
            this.cmbToWH.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(442, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "To Warehouse:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "From Channel:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "From Warehouse:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Transaction Date:";
            // 
            // cmbFromChannel
            // 
            this.cmbFromChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromChannel.FormattingEnabled = true;
            this.cmbFromChannel.Location = new System.Drawing.Point(188, 90);
            this.cmbFromChannel.Name = "cmbFromChannel";
            this.cmbFromChannel.Size = new System.Drawing.Size(251, 23);
            this.cmbFromChannel.TabIndex = 11;
            this.cmbFromChannel.SelectedIndexChanged += new System.EventHandler(this.cmbFromChannel_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 501);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(69, 498);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(778, 23);
            this.txtRemarks.TabIndex = 23;
            // 
            // lblTransactionRefNo
            // 
            this.lblTransactionRefNo.AutoSize = true;
            this.lblTransactionRefNo.Location = new System.Drawing.Point(24, 35);
            this.lblTransactionRefNo.Name = "lblTransactionRefNo";
            this.lblTransactionRefNo.Size = new System.Drawing.Size(96, 15);
            this.lblTransactionRefNo.TabIndex = 0;
            this.lblTransactionRefNo.Text = "Transaction No:";
            // 
            // txtTransationNo
            // 
            this.txtTransationNo.Location = new System.Drawing.Point(121, 32);
            this.txtTransationNo.Name = "txtTransationNo";
            this.txtTransationNo.Size = new System.Drawing.Size(195, 23);
            this.txtTransationNo.TabIndex = 1;
            // 
            // txtFromChannelCode
            // 
            this.txtFromChannelCode.Location = new System.Drawing.Point(121, 90);
            this.txtFromChannelCode.Name = "txtFromChannelCode";
            this.txtFromChannelCode.Size = new System.Drawing.Size(64, 23);
            this.txtFromChannelCode.TabIndex = 10;
            this.txtFromChannelCode.TextChanged += new System.EventHandler(this.txtFromChannelCode_TextChanged);
            // 
            // txtFromWHCode
            // 
            this.txtFromWHCode.Enabled = false;
            this.txtFromWHCode.Location = new System.Drawing.Point(121, 120);
            this.txtFromWHCode.Name = "txtFromWHCode";
            this.txtFromWHCode.Size = new System.Drawing.Size(64, 23);
            this.txtFromWHCode.TabIndex = 16;
            this.txtFromWHCode.TextChanged += new System.EventHandler(this.txtFromWHCode_TextChanged);
            // 
            // txtToWHCode
            // 
            this.txtToWHCode.Enabled = false;
            this.txtToWHCode.Location = new System.Drawing.Point(538, 120);
            this.txtToWHCode.Name = "txtToWHCode";
            this.txtToWHCode.Size = new System.Drawing.Size(64, 23);
            this.txtToWHCode.TabIndex = 19;
            this.txtToWHCode.TextChanged += new System.EventHandler(this.txtToWHCode_TextChanged);
            // 
            // txtToChannelCode
            // 
            this.txtToChannelCode.Location = new System.Drawing.Point(538, 90);
            this.txtToChannelCode.Name = "txtToChannelCode";
            this.txtToChannelCode.Size = new System.Drawing.Size(64, 23);
            this.txtToChannelCode.TabIndex = 13;
            this.txtToChannelCode.TextChanged += new System.EventHandler(this.txtToChannelCode_TextChanged);
            // 
            // txtIMEIList
            // 
            this.txtIMEIList.Location = new System.Drawing.Point(903, 31);
            this.txtIMEIList.Multiline = true;
            this.txtIMEIList.Name = "txtIMEIList";
            this.txtIMEIList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIMEIList.Size = new System.Drawing.Size(197, 451);
            this.txtIMEIList.TabIndex = 25;
            // 
            // btIMEIValid
            // 
            this.btIMEIValid.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btIMEIValid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btIMEIValid.Location = new System.Drawing.Point(853, 276);
            this.btIMEIValid.Name = "btIMEIValid";
            this.btIMEIValid.Size = new System.Drawing.Size(38, 36);
            this.btIMEIValid.TabIndex = 30;
            this.btIMEIValid.Text = "<<";
            this.btIMEIValid.UseVisualStyleBackColor = true;
            this.btIMEIValid.Click += new System.EventHandler(this.btIMEIValid_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(897, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 479);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "CurrentStock";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Packing Qty";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Barcode Qty";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 90;
            // 
            // cmbTransferType
            // 
            this.cmbTransferType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransferType.FormattingEnabled = true;
            this.cmbTransferType.Location = new System.Drawing.Point(538, 61);
            this.cmbTransferType.Name = "cmbTransferType";
            this.cmbTransferType.Size = new System.Drawing.Size(310, 23);
            this.cmbTransferType.TabIndex = 8;
            this.cmbTransferType.SelectedIndexChanged += new System.EventHandler(this.cmbTransferType_SelectedIndexChanged);
            // 
            // lblTransferType
            // 
            this.lblTransferType.AutoSize = true;
            this.lblTransferType.Location = new System.Drawing.Point(449, 64);
            this.lblTransferType.Name = "lblTransferType";
            this.lblTransferType.Size = new System.Drawing.Size(83, 15);
            this.lblTransferType.TabIndex = 7;
            this.lblTransferType.Text = "Transfer Type";
            // 
            // rdoStockIn
            // 
            this.rdoStockIn.AutoSize = true;
            this.rdoStockIn.Location = new System.Drawing.Point(538, 34);
            this.rdoStockIn.Name = "rdoStockIn";
            this.rdoStockIn.Size = new System.Drawing.Size(69, 19);
            this.rdoStockIn.TabIndex = 3;
            this.rdoStockIn.Text = "Stock In";
            this.rdoStockIn.UseVisualStyleBackColor = true;
            this.rdoStockIn.CheckedChanged += new System.EventHandler(this.rdoStockIn_CheckedChanged);
            // 
            // rdoStockOut
            // 
            this.rdoStockOut.AutoSize = true;
            this.rdoStockOut.Location = new System.Drawing.Point(715, 34);
            this.rdoStockOut.Name = "rdoStockOut";
            this.rdoStockOut.Size = new System.Drawing.Size(80, 19);
            this.rdoStockOut.TabIndex = 4;
            this.rdoStockOut.Text = "Stock Out";
            this.rdoStockOut.UseVisualStyleBackColor = true;
            this.rdoStockOut.CheckedChanged += new System.EventHandler(this.rdoStockOut_CheckedChanged);
            // 
            // lblTransSide
            // 
            this.lblTransSide.AutoSize = true;
            this.lblTransSide.Location = new System.Drawing.Point(432, 35);
            this.lblTransSide.Name = "lblTransSide";
            this.lblTransSide.Size = new System.Drawing.Size(100, 15);
            this.lblTransSide.TabIndex = 2;
            this.lblTransSide.Text = "Transaction Side";
            // 
            // lblLoanRefNo
            // 
            this.lblLoanRefNo.AutoSize = true;
            this.lblLoanRefNo.Location = new System.Drawing.Point(50, 8);
            this.lblLoanRefNo.Name = "lblLoanRefNo";
            this.lblLoanRefNo.Size = new System.Drawing.Size(65, 15);
            this.lblLoanRefNo.TabIndex = 29;
            this.lblLoanRefNo.Text = "Loan Ref#";
            // 
            // txtLoanRefNo
            // 
            this.txtLoanRefNo.Location = new System.Drawing.Point(121, 5);
            this.txtLoanRefNo.Name = "txtLoanRefNo";
            this.txtLoanRefNo.Size = new System.Drawing.Size(195, 23);
            this.txtLoanRefNo.TabIndex = 30;
            this.txtLoanRefNo.TextChanged += new System.EventHandler(this.txtLoanRefNo_TextChanged);
            // 
            // txtVehicleNumber
            // 
            this.txtVehicleNumber.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleNumber.Location = new System.Drawing.Point(538, 5);
            this.txtVehicleNumber.Name = "txtVehicleNumber";
            this.txtVehicleNumber.Size = new System.Drawing.Size(310, 23);
            this.txtVehicleNumber.TabIndex = 32;
            // 
            // lblVehicleNumber
            // 
            this.lblVehicleNumber.AutoSize = true;
            this.lblVehicleNumber.BackColor = System.Drawing.SystemColors.Control;
            this.lblVehicleNumber.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleNumber.Location = new System.Drawing.Point(437, 8);
            this.lblVehicleNumber.Name = "lblVehicleNumber";
            this.lblVehicleNumber.Size = new System.Drawing.Size(98, 15);
            this.lblVehicleNumber.TabIndex = 31;
            this.lblVehicleNumber.Text = "Vehicle Number";
            // 
            // frmStockTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 533);
            this.Controls.Add(this.txtVehicleNumber);
            this.Controls.Add(this.lblVehicleNumber);
            this.Controls.Add(this.lblLoanRefNo);
            this.Controls.Add(this.txtLoanRefNo);
            this.Controls.Add(this.lblTransSide);
            this.Controls.Add(this.rdoStockOut);
            this.Controls.Add(this.rdoStockIn);
            this.Controls.Add(this.lblTransferType);
            this.Controls.Add(this.cmbTransferType);
            this.Controls.Add(this.txtIMEIList);
            this.Controls.Add(this.btIMEIValid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtToWHCode);
            this.Controls.Add(this.txtToChannelCode);
            this.Controls.Add(this.txtFromWHCode);
            this.Controls.Add(this.txtFromChannelCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.cmbToChannel);
            this.Controls.Add(this.dtTransactionDate);
            this.Controls.Add(this.cmbFromWH);
            this.Controls.Add(this.cmbToWH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFromChannel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblTransactionRefNo);
            this.Controls.Add(this.txtTransationNo);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStockTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Transfer";
            this.Load += new System.EventHandler(this.frmStockTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.ComboBox cmbToChannel;
        private System.Windows.Forms.DateTimePicker dtTransactionDate;
        private System.Windows.Forms.ComboBox cmbFromWH;
        private System.Windows.Forms.ComboBox cmbToWH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFromChannel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblTransactionRefNo;
        private System.Windows.Forms.TextBox txtTransationNo;
        private System.Windows.Forms.TextBox txtFromChannelCode;
        private System.Windows.Forms.TextBox txtFromWHCode;
        private System.Windows.Forms.TextBox txtToWHCode;
        private System.Windows.Forms.TextBox txtToChannelCode;
        private System.Windows.Forms.TextBox txtIMEIList;
        private System.Windows.Forms.Button btIMEIValid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ComboBox cmbTransferType;
        private System.Windows.Forms.Label lblTransferType;
        private System.Windows.Forms.RadioButton rdoStockIn;
        private System.Windows.Forms.RadioButton rdoStockOut;
        private System.Windows.Forms.Label lblTransSide;
        private System.Windows.Forms.Label lblLoanRefNo;
        private System.Windows.Forms.TextBox txtLoanRefNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackingQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBarcodeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIsBarcodeItem;
        private System.Windows.Forms.TextBox txtVehicleNumber;
        private System.Windows.Forms.Label lblVehicleNumber;
    }
}