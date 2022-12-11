namespace CJ.Win.SupplyChain
{
    partial class frmShipment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShipment));
            this.dtShipmentDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtInvAmt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtInvNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtForwarderName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFEDate = new System.Windows.Forms.Label();
            this.dtFEDdate = new System.Windows.Forms.DateTimePicker();
            this.dtSDocRcvbyBankDate = new System.Windows.Forms.DateTimePicker();
            this.dtInvDate = new System.Windows.Forms.DateTimePicker();
            this.dtBLDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBLNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoOfCarton = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMeasurementCBM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGrossWeightKG = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNetWeightKG = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContainerNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvShipmentQty = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBOMList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLCQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPreShipmentQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtShipmentQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBOMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblLCNO = new System.Windows.Forms.Label();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipmentQty)).BeginInit();
            this.SuspendLayout();
            // 
            // dtShipmentDate
            // 
            this.dtShipmentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtShipmentDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtShipmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShipmentDate.Location = new System.Drawing.Point(131, 45);
            this.dtShipmentDate.Name = "dtShipmentDate";
            this.dtShipmentDate.Size = new System.Drawing.Size(224, 23);
            this.dtShipmentDate.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label12.Location = new System.Drawing.Point(30, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(94, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Shipment Date:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label11.Location = new System.Drawing.Point(415, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "InvoiceDate:";
            // 
            // txtInvAmt
            // 
            this.txtInvAmt.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtInvAmt.Location = new System.Drawing.Point(501, 105);
            this.txtInvAmt.Name = "txtInvAmt";
            this.txtInvAmt.Size = new System.Drawing.Size(224, 23);
            this.txtInvAmt.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label10.Location = new System.Drawing.Point(403, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "InvoiceAmt ($):";
            // 
            // txtInvNo
            // 
            this.txtInvNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtInvNo.Location = new System.Drawing.Point(501, 45);
            this.txtInvNo.Name = "txtInvNo";
            this.txtInvNo.Size = new System.Drawing.Size(224, 23);
            this.txtInvNo.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label9.Location = new System.Drawing.Point(425, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "InvoiceNo:";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblCurrency.Location = new System.Drawing.Point(433, 139);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(59, 15);
            this.lblCurrency.TabIndex = 14;
            this.lblCurrency.Text = "Currency:";
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.Location = new System.Drawing.Point(501, 135);
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(224, 23);
            this.cmbCurrency.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label7.Location = new System.Drawing.Point(359, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "SDocRcvbyBankDate:";
            // 
            // txtForwarderName
            // 
            this.txtForwarderName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtForwarderName.Location = new System.Drawing.Point(131, 75);
            this.txtForwarderName.Name = "txtForwarderName";
            this.txtForwarderName.Size = new System.Drawing.Size(224, 23);
            this.txtForwarderName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label5.Location = new System.Drawing.Point(21, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Forwarder Name:";
            // 
            // lblFEDate
            // 
            this.lblFEDate.AutoSize = true;
            this.lblFEDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblFEDate.Location = new System.Drawing.Point(15, 112);
            this.lblFEDate.Name = "lblFEDate";
            this.lblFEDate.Size = new System.Drawing.Size(108, 15);
            this.lblFEDate.TabIndex = 8;
            this.lblFEDate.Text = "ForwardEng Date:";
            // 
            // dtFEDdate
            // 
            this.dtFEDdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFEDdate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtFEDdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFEDdate.Location = new System.Drawing.Point(131, 105);
            this.dtFEDdate.Name = "dtFEDdate";
            this.dtFEDdate.Size = new System.Drawing.Size(224, 23);
            this.dtFEDdate.TabIndex = 9;
            // 
            // dtSDocRcvbyBankDate
            // 
            this.dtSDocRcvbyBankDate.CustomFormat = "dd-MMM-yyyy";
            this.dtSDocRcvbyBankDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtSDocRcvbyBankDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSDocRcvbyBankDate.Location = new System.Drawing.Point(501, 166);
            this.dtSDocRcvbyBankDate.Name = "dtSDocRcvbyBankDate";
            this.dtSDocRcvbyBankDate.Size = new System.Drawing.Size(224, 23);
            this.dtSDocRcvbyBankDate.TabIndex = 19;
            // 
            // dtInvDate
            // 
            this.dtInvDate.CustomFormat = "dd-MMM-yyyy";
            this.dtInvDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtInvDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvDate.Location = new System.Drawing.Point(501, 73);
            this.dtInvDate.Name = "dtInvDate";
            this.dtInvDate.Size = new System.Drawing.Size(224, 23);
            this.dtInvDate.TabIndex = 7;
            // 
            // dtBLDate
            // 
            this.dtBLDate.CustomFormat = "dd-MMM-yyyy";
            this.dtBLDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtBLDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBLDate.Location = new System.Drawing.Point(131, 163);
            this.dtBLDate.Name = "dtBLDate";
            this.dtBLDate.Size = new System.Drawing.Size(224, 23);
            this.dtBLDate.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(70, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "BLDate:";
            // 
            // txtBLNo
            // 
            this.txtBLNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtBLNo.Location = new System.Drawing.Point(131, 135);
            this.txtBLNo.Name = "txtBLNo";
            this.txtBLNo.Size = new System.Drawing.Size(224, 23);
            this.txtBLNo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(80, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "BLNo:";
            // 
            // txtNoOfCarton
            // 
            this.txtNoOfCarton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtNoOfCarton.Location = new System.Drawing.Point(131, 253);
            this.txtNoOfCarton.Name = "txtNoOfCarton";
            this.txtNoOfCarton.Size = new System.Drawing.Size(224, 23);
            this.txtNoOfCarton.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(43, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "NoOfCarton:";
            // 
            // txtMeasurementCBM
            // 
            this.txtMeasurementCBM.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtMeasurementCBM.Location = new System.Drawing.Point(131, 223);
            this.txtMeasurementCBM.Name = "txtMeasurementCBM";
            this.txtMeasurementCBM.Size = new System.Drawing.Size(224, 23);
            this.txtMeasurementCBM.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label4.Location = new System.Drawing.Point(10, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "MeasurementCBM:";
            // 
            // txtGrossWeightKG
            // 
            this.txtGrossWeightKG.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtGrossWeightKG.Location = new System.Drawing.Point(501, 226);
            this.txtGrossWeightKG.Name = "txtGrossWeightKG";
            this.txtGrossWeightKG.Size = new System.Drawing.Size(224, 23);
            this.txtGrossWeightKG.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label6.Location = new System.Drawing.Point(394, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 15);
            this.label6.TabIndex = 26;
            this.label6.Text = "GrossWeightKG:";
            // 
            // txtNetWeightKG
            // 
            this.txtNetWeightKG.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtNetWeightKG.Location = new System.Drawing.Point(501, 196);
            this.txtNetWeightKG.Name = "txtNetWeightKG";
            this.txtNetWeightKG.Size = new System.Drawing.Size(224, 23);
            this.txtNetWeightKG.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label8.Location = new System.Drawing.Point(405, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "NetWeightKG:";
            // 
            // txtContainerNo
            // 
            this.txtContainerNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtContainerNo.Location = new System.Drawing.Point(131, 193);
            this.txtContainerNo.Name = "txtContainerNo";
            this.txtContainerNo.Size = new System.Drawing.Size(224, 23);
            this.txtContainerNo.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label13.Location = new System.Drawing.Point(43, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "ContainerNo:";
            // 
            // dgvShipmentQty
            // 
            this.dgvShipmentQty.AllowUserToAddRows = false;
            this.dgvShipmentQty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShipmentQty.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductDetails,
            this.txtBOMList,
            this.txtLCQty,
            this.txtPreShipmentQty,
            this.txtShipmentQty,
            this.TxtProductID,
            this.txtBOMID});
            this.dgvShipmentQty.Location = new System.Drawing.Point(20, 286);
            this.dgvShipmentQty.Name = "dgvShipmentQty";
            this.dgvShipmentQty.Size = new System.Drawing.Size(705, 220);
            this.dgvShipmentQty.TabIndex = 30;
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            this.txtProductCode.Width = 70;
            // 
            // txtProductDetails
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDetails.HeaderText = "Product Details";
            this.txtProductDetails.Name = "txtProductDetails";
            this.txtProductDetails.ReadOnly = true;
            this.txtProductDetails.Width = 170;
            // 
            // txtBOMList
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBOMList.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtBOMList.HeaderText = "BOM List";
            this.txtBOMList.Name = "txtBOMList";
            this.txtBOMList.ReadOnly = true;
            this.txtBOMList.Width = 140;
            // 
            // txtLCQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtLCQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtLCQty.HeaderText = "LC Qty";
            this.txtLCQty.Name = "txtLCQty";
            this.txtLCQty.ReadOnly = true;
            this.txtLCQty.Width = 70;
            // 
            // txtPreShipmentQty
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPreShipmentQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtPreShipmentQty.HeaderText = "PreShipment Qty";
            this.txtPreShipmentQty.Name = "txtPreShipmentQty";
            this.txtPreShipmentQty.ReadOnly = true;
            this.txtPreShipmentQty.Width = 70;
            // 
            // txtShipmentQty
            // 
            this.txtShipmentQty.HeaderText = "Shipment Qty";
            this.txtShipmentQty.Name = "txtShipmentQty";
            this.txtShipmentQty.Width = 70;
            // 
            // TxtProductID
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TxtProductID.DefaultCellStyle = dataGridViewCellStyle6;
            this.TxtProductID.HeaderText = "ProductID";
            this.TxtProductID.Name = "TxtProductID";
            this.TxtProductID.ReadOnly = true;
            this.TxtProductID.Visible = false;
            // 
            // txtBOMID
            // 
            this.txtBOMID.HeaderText = "BOMID";
            this.txtBOMID.Name = "txtBOMID";
            this.txtBOMID.ReadOnly = true;
            this.txtBOMID.Visible = false;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblRemarks.Location = new System.Drawing.Point(30, 517);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(55, 15);
            this.lblRemarks.TabIndex = 31;
            this.lblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(97, 513);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(628, 23);
            this.txtRemarks.TabIndex = 32;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(543, 543);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 29);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(638, 543);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label14.Location = new System.Drawing.Point(544, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 15);
            this.label14.TabIndex = 39;
            this.label14.Text = "OrderNo:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label15.Location = new System.Drawing.Point(284, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 15);
            this.label15.TabIndex = 37;
            this.label15.Text = "LCNo:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label16.Location = new System.Drawing.Point(16, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 15);
            this.label16.TabIndex = 35;
            this.label16.Text = "Company:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblCompany.Location = new System.Drawing.Point(86, 10);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(13, 15);
            this.lblCompany.TabIndex = 36;
            this.lblCompany.Text = "?";
            // 
            // lblLCNO
            // 
            this.lblLCNO.AutoSize = true;
            this.lblLCNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblLCNO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLCNO.Location = new System.Drawing.Point(334, 9);
            this.lblLCNO.Name = "lblLCNO";
            this.lblLCNO.Size = new System.Drawing.Size(13, 13);
            this.lblLCNO.TabIndex = 38;
            this.lblLCNO.Text = "?";
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblOrderNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblOrderNo.Location = new System.Drawing.Point(607, 8);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(13, 15);
            this.lblOrderNo.TabIndex = 40;
            this.lblOrderNo.Text = "?";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Details";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 170;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn3.HeaderText = "BOM List";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn4.HeaderText = "LC Qty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn5.HeaderText = "PreShipment Qty";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Shipment Qty";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn7.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "BOMID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // frmShipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 584);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.lblLCNO);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvShipmentQty);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtContainerNo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtNetWeightKG);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtGrossWeightKG);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMeasurementCBM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNoOfCarton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtBLDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBLNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtInvDate);
            this.Controls.Add(this.dtSDocRcvbyBankDate);
            this.Controls.Add(this.dtShipmentDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtInvAmt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtInvNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtForwarderName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFEDate);
            this.Controls.Add(this.dtFEDdate);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmShipment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipment";
            this.Load += new System.EventHandler(this.frmShipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipmentQty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtShipmentDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtInvAmt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtInvNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.ComboBox cmbCurrency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtForwarderName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFEDate;
        private System.Windows.Forms.DateTimePicker dtFEDdate;
        private System.Windows.Forms.DateTimePicker dtSDocRcvbyBankDate;
        private System.Windows.Forms.DateTimePicker dtInvDate;
        private System.Windows.Forms.DateTimePicker dtBLDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBLNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoOfCarton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMeasurementCBM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGrossWeightKG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNetWeightKG;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtContainerNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvShipmentQty;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblLCNO;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBOMList;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLCQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPreShipmentQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtShipmentQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TxtProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBOMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}