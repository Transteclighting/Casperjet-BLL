namespace CJ.Win
{
    partial class frmCommercialInvoice
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
            this.dtReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.lbReceivedDate = new System.Windows.Forms.Label();
            this.dtPortArrivalDate = new System.Windows.Forms.DateTimePicker();
            this.lbPortArrivalDate = new System.Windows.Forms.Label();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.dtpShipmentDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDutyAmount = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDocValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtDutyDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtDocDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPINo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.btPOSearch = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.cmbApplyStatus = new System.Windows.Forms.ComboBox();
            this.txtInvoiceValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTransactionRefNo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLcQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dtReceivedDate
            // 
            this.dtReceivedDate.Checked = false;
            this.dtReceivedDate.CustomFormat = "dd-MMM-yyyy";
            this.dtReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceivedDate.Location = new System.Drawing.Point(440, 98);
            this.dtReceivedDate.Name = "dtReceivedDate";
            this.dtReceivedDate.ShowCheckBox = true;
            this.dtReceivedDate.Size = new System.Drawing.Size(117, 20);
            this.dtReceivedDate.TabIndex = 23;
            // 
            // lbReceivedDate
            // 
            this.lbReceivedDate.AutoSize = true;
            this.lbReceivedDate.Location = new System.Drawing.Point(358, 102);
            this.lbReceivedDate.Name = "lbReceivedDate";
            this.lbReceivedDate.Size = new System.Drawing.Size(79, 13);
            this.lbReceivedDate.TabIndex = 22;
            this.lbReceivedDate.Text = "Received Date";
            // 
            // dtPortArrivalDate
            // 
            this.dtPortArrivalDate.Checked = false;
            this.dtPortArrivalDate.CustomFormat = "dd-MMM-yyyy";
            this.dtPortArrivalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPortArrivalDate.Location = new System.Drawing.Point(440, 72);
            this.dtPortArrivalDate.Name = "dtPortArrivalDate";
            this.dtPortArrivalDate.ShowCheckBox = true;
            this.dtPortArrivalDate.Size = new System.Drawing.Size(117, 20);
            this.dtPortArrivalDate.TabIndex = 21;
            // 
            // lbPortArrivalDate
            // 
            this.lbPortArrivalDate.AutoSize = true;
            this.lbPortArrivalDate.Location = new System.Drawing.Point(355, 75);
            this.lbPortArrivalDate.Name = "lbPortArrivalDate";
            this.lbPortArrivalDate.Size = new System.Drawing.Size(84, 13);
            this.lbPortArrivalDate.TabIndex = 20;
            this.lbPortArrivalDate.Text = "Port Arrival Date";
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Checked = false;
            this.dtpInvoiceDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(440, 18);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.ShowCheckBox = true;
            this.dtpInvoiceDate.Size = new System.Drawing.Size(117, 20);
            this.dtpInvoiceDate.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Invoice Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "CI No";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(116, 122);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(154, 20);
            this.txtInvoiceNo.TabIndex = 25;
            // 
            // dtpShipmentDate
            // 
            this.dtpShipmentDate.Checked = false;
            this.dtpShipmentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpShipmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShipmentDate.Location = new System.Drawing.Point(440, 46);
            this.dtpShipmentDate.Name = "dtpShipmentDate";
            this.dtpShipmentDate.ShowCheckBox = true;
            this.dtpShipmentDate.Size = new System.Drawing.Size(117, 20);
            this.dtpShipmentDate.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(362, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Shipment Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDutyAmount);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtDocValue);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtDutyDate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dtDocDate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtPINo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtLCNo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPONo);
            this.groupBox2.Controls.Add(this.btPOSearch);
            this.groupBox2.Controls.Add(this.lbStatus);
            this.groupBox2.Controls.Add(this.cmbApplyStatus);
            this.groupBox2.Controls.Add(this.txtInvoiceValue);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblTransactionRefNo);
            this.groupBox2.Controls.Add(this.dtpInvoiceDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpShipmentDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtInvoiceNo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtReceivedDate);
            this.groupBox2.Controls.Add(this.lbPortArrivalDate);
            this.groupBox2.Controls.Add(this.lbReceivedDate);
            this.groupBox2.Controls.Add(this.dtPortArrivalDate);
            this.groupBox2.Location = new System.Drawing.Point(7, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(604, 254);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Basic Information";
            // 
            // txtDutyAmount
            // 
            this.txtDutyAmount.Location = new System.Drawing.Point(115, 202);
            this.txtDutyAmount.Name = "txtDutyAmount";
            this.txtDutyAmount.Size = new System.Drawing.Size(154, 20);
            this.txtDutyAmount.TabIndex = 56;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(115, 228);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(442, 20);
            this.txtRemarks.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Remarks";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 55;
            this.label12.Text = "Duty Amount";
            // 
            // txtDocValue
            // 
            this.txtDocValue.Location = new System.Drawing.Point(115, 175);
            this.txtDocValue.Name = "txtDocValue";
            this.txtDocValue.Size = new System.Drawing.Size(154, 20);
            this.txtDocValue.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Doc Value";
            // 
            // dtDutyDate
            // 
            this.dtDutyDate.Checked = false;
            this.dtDutyDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDutyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDutyDate.Location = new System.Drawing.Point(440, 199);
            this.dtDutyDate.Name = "dtDutyDate";
            this.dtDutyDate.ShowCheckBox = true;
            this.dtDutyDate.Size = new System.Drawing.Size(117, 20);
            this.dtDutyDate.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(357, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 51;
            this.label9.Text = "Duty Req. Date";
            // 
            // dtDocDate
            // 
            this.dtDocDate.Checked = false;
            this.dtDocDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDocDate.Location = new System.Drawing.Point(440, 172);
            this.dtDocDate.Name = "dtDocDate";
            this.dtDocDate.ShowCheckBox = true;
            this.dtDocDate.Size = new System.Drawing.Size(117, 20);
            this.dtDocDate.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(360, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 49;
            this.label11.Text = "Doc Req. Date";
            // 
            // txtPINo
            // 
            this.txtPINo.Location = new System.Drawing.Point(115, 69);
            this.txtPINo.Name = "txtPINo";
            this.txtPINo.Size = new System.Drawing.Size(154, 20);
            this.txtPINo.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "PI No";
            // 
            // txtLCNo
            // 
            this.txtLCNo.Location = new System.Drawing.Point(116, 94);
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.Size = new System.Drawing.Size(154, 20);
            this.txtLCNo.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "LC No";
            // 
            // txtPONo
            // 
            this.txtPONo.Enabled = false;
            this.txtPONo.Location = new System.Drawing.Point(116, 45);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(154, 20);
            this.txtPONo.TabIndex = 41;
            // 
            // btPOSearch
            // 
            this.btPOSearch.Location = new System.Drawing.Point(273, 44);
            this.btPOSearch.Name = "btPOSearch";
            this.btPOSearch.Size = new System.Drawing.Size(34, 21);
            this.btPOSearch.TabIndex = 40;
            this.btPOSearch.Text = "...";
            this.btPOSearch.UseVisualStyleBackColor = true;
            this.btPOSearch.Click += new System.EventHandler(this.btPOSearch_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(20, 21);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(92, 13);
            this.lbStatus.TabIndex = 37;
            this.lbStatus.Text = "Requisition Status";
            // 
            // cmbApplyStatus
            // 
            this.cmbApplyStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplyStatus.FormattingEnabled = true;
            this.cmbApplyStatus.Location = new System.Drawing.Point(115, 18);
            this.cmbApplyStatus.Name = "cmbApplyStatus";
            this.cmbApplyStatus.Size = new System.Drawing.Size(158, 21);
            this.cmbApplyStatus.TabIndex = 38;
            this.cmbApplyStatus.SelectedIndexChanged += new System.EventHandler(this.cmbApplyStatus_SelectedIndexChanged);
            // 
            // txtInvoiceValue
            // 
            this.txtInvoiceValue.Location = new System.Drawing.Point(115, 149);
            this.txtInvoiceValue.Name = "txtInvoiceValue";
            this.txtInvoiceValue.Size = new System.Drawing.Size(154, 20);
            this.txtInvoiceValue.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "CI Value ($)";
            // 
            // lblTransactionRefNo
            // 
            this.lblTransactionRefNo.AutoSize = true;
            this.lblTransactionRefNo.Location = new System.Drawing.Point(75, 48);
            this.lblTransactionRefNo.Name = "lblTransactionRefNo";
            this.lblTransactionRefNo.Size = new System.Drawing.Size(39, 13);
            this.lblTransactionRefNo.TabIndex = 33;
            this.lblTransactionRefNo.Text = "PO No";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLineItem);
            this.groupBox1.Location = new System.Drawing.Point(7, 261);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 305);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Information";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.AllowUserToDeleteRows = false;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.PIValue,
            this.colLcQty,
            this.colInvoiceQty,
            this.colProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(6, 19);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(591, 280);
            this.dgvLineItem.TabIndex = 4;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Frozen = true;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            // 
            // btnFindProduct
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            this.btnFindProduct.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnFindProduct.Frozen = true;
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Text = "...";
            this.btnFindProduct.Width = 35;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDescription.Frozen = true;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 170;
            // 
            // PIValue
            // 
            this.PIValue.HeaderText = "Unit Value";
            this.PIValue.Name = "PIValue";
            this.PIValue.ReadOnly = true;
            this.PIValue.Width = 70;
            // 
            // colLcQty
            // 
            this.colLcQty.HeaderText = "LC Qty";
            this.colLcQty.Name = "colLcQty";
            this.colLcQty.ReadOnly = true;
            this.colLcQty.Width = 70;
            // 
            // colInvoiceQty
            // 
            this.colInvoiceQty.HeaderText = "Invoice Qty";
            this.colInvoiceQty.Name = "colInvoiceQty";
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "Product ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(94, 567);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 41;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(529, 569);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 567);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCommercialInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 594);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmCommercialInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Commercial Invoice";
            this.Load += new System.EventHandler(this.frmCommercialInvoice_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtReceivedDate;
        private System.Windows.Forms.Label lbReceivedDate;
        private System.Windows.Forms.DateTimePicker dtPortArrivalDate;
        private System.Windows.Forms.Label lbPortArrivalDate;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.DateTimePicker dtpShipmentDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTransactionRefNo;
        private System.Windows.Forms.TextBox txtInvoiceValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ComboBox cmbApplyStatus;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLcQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.Button btPOSearch;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPINo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDutyAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDocValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtDutyDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtDocDate;
        private System.Windows.Forms.Label label11;
    }
}