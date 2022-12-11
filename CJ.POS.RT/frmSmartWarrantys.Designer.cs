namespace CJ.POS.RT
{
    partial class frmSmartWarrantys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSmartWarrantys));
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwItem = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIssueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShowroomName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConsumerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMobileNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductSerialNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSmartWarrantyTenure = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoiceDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCertificateNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPaymentMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBankName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCardType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPOSMachineName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtConsumerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductSerialNo = new System.Windows.Forms.TextBox();
            this.cmbPaymentMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCertificateNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSmartWarrantyTenure = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkEnableDisableDateRange = new System.Windows.Forms.CheckBox();
            this.dToDate = new System.Windows.Forms.DateTimePicker();
            this.dFromDate = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCdate = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(975, 192);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 29);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwItem
            // 
            this.lvwItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colIssueDate,
            this.colShowroomName,
            this.colConsumerName,
            this.colMobileNo,
            this.colProductCode,
            this.colProductName,
            this.colProductModel,
            this.colProductSerialNo,
            this.colSmartWarrantyTenure,
            this.colStartDate,
            this.colEndDate,
            this.colAmount,
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colCertificateNo,
            this.colPaymentMode,
            this.colBankName,
            this.colCardType,
            this.colPOSMachineName});
            this.lvwItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwItem.FullRowSelect = true;
            this.lvwItem.GridLines = true;
            this.lvwItem.HideSelection = false;
            this.lvwItem.Location = new System.Drawing.Point(14, 192);
            this.lvwItem.MultiSelect = false;
            this.lvwItem.Name = "lvwItem";
            this.lvwItem.Size = new System.Drawing.Size(955, 347);
            this.lvwItem.TabIndex = 16;
            this.lvwItem.UseCompatibleStateImageBehavior = false;
            this.lvwItem.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 36;
            // 
            // colIssueDate
            // 
            this.colIssueDate.Text = "Issue Date";
            this.colIssueDate.Width = 101;
            // 
            // colShowroomName
            // 
            this.colShowroomName.Text = "Showroom Name";
            this.colShowroomName.Width = 159;
            // 
            // colConsumerName
            // 
            this.colConsumerName.Text = "Consumer Name";
            this.colConsumerName.Width = 144;
            // 
            // colMobileNo
            // 
            this.colMobileNo.Text = "Mobile#";
            this.colMobileNo.Width = 104;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 86;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 175;
            // 
            // colProductModel
            // 
            this.colProductModel.Text = "Product Model";
            this.colProductModel.Width = 114;
            // 
            // colProductSerialNo
            // 
            this.colProductSerialNo.Text = "Product Serial#";
            this.colProductSerialNo.Width = 113;
            // 
            // colSmartWarrantyTenure
            // 
            this.colSmartWarrantyTenure.Text = "Warranty Tenure";
            this.colSmartWarrantyTenure.Width = 106;
            // 
            // colStartDate
            // 
            this.colStartDate.Text = "StartDate";
            this.colStartDate.Width = 91;
            // 
            // colEndDate
            // 
            this.colEndDate.Text = "End Date";
            this.colEndDate.Width = 89;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 78;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice#";
            this.colInvoiceNo.Width = 86;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Text = "Invoice Date";
            this.colInvoiceDate.Width = 86;
            // 
            // colCertificateNo
            // 
            this.colCertificateNo.Text = "Certificate#";
            this.colCertificateNo.Width = 77;
            // 
            // colPaymentMode
            // 
            this.colPaymentMode.Text = "Payment Mode";
            this.colPaymentMode.Width = 97;
            // 
            // colBankName
            // 
            this.colBankName.Text = "Bank Name";
            this.colBankName.Width = 91;
            // 
            // colCardType
            // 
            this.colCardType.Text = "Card Type";
            this.colCardType.Width = 69;
            // 
            // colPOSMachineName
            // 
            this.colPOSMachineName.Text = "POS Machine Name";
            this.colPOSMachineName.Width = 134;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(975, 511);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(574, 157);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(87, 29);
            this.btnGetData.TabIndex = 15;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.Location = new System.Drawing.Point(116, 70);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.Size = new System.Drawing.Size(170, 23);
            this.txtConsumerName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consumer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mobile#";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(391, 70);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(170, 23);
            this.txtMobileNo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Product";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Product Serial#";
            // 
            // txtProductSerialNo
            // 
            this.txtProductSerialNo.Location = new System.Drawing.Point(116, 132);
            this.txtProductSerialNo.Name = "txtProductSerialNo";
            this.txtProductSerialNo.Size = new System.Drawing.Size(170, 23);
            this.txtProductSerialNo.TabIndex = 8;
            // 
            // cmbPaymentMode
            // 
            this.cmbPaymentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMode.FormattingEnabled = true;
            this.cmbPaymentMode.Items.AddRange(new object[] {
            "<All>",
            "Cash",
            "Card"});
            this.cmbPaymentMode.Location = new System.Drawing.Point(116, 161);
            this.cmbPaymentMode.Name = "cmbPaymentMode";
            this.cmbPaymentMode.Size = new System.Drawing.Size(170, 24);
            this.cmbPaymentMode.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Payment Mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Certificate#";
            // 
            // txtCertificateNo
            // 
            this.txtCertificateNo.Location = new System.Drawing.Point(398, 132);
            this.txtCertificateNo.Name = "txtCertificateNo";
            this.txtCertificateNo.Size = new System.Drawing.Size(170, 23);
            this.txtCertificateNo.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Warranty Tenure";
            // 
            // cmbSmartWarrantyTenure
            // 
            this.cmbSmartWarrantyTenure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSmartWarrantyTenure.FormattingEnabled = true;
            this.cmbSmartWarrantyTenure.Items.AddRange(new object[] {
            "<All>",
            "12",
            "24"});
            this.cmbSmartWarrantyTenure.Location = new System.Drawing.Point(398, 161);
            this.cmbSmartWarrantyTenure.Name = "cmbSmartWarrantyTenure";
            this.cmbSmartWarrantyTenure.Size = new System.Drawing.Size(170, 24);
            this.cmbSmartWarrantyTenure.TabIndex = 14;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkEnableDisableDateRange);
            this.groupBox2.Controls.Add(this.dToDate);
            this.groupBox2.Controls.Add(this.dFromDate);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.lblCdate);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(34, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 52);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // chkEnableDisableDateRange
            // 
            this.chkEnableDisableDateRange.AutoSize = true;
            this.chkEnableDisableDateRange.Location = new System.Drawing.Point(14, -1);
            this.chkEnableDisableDateRange.Name = "chkEnableDisableDateRange";
            this.chkEnableDisableDateRange.Size = new System.Drawing.Size(179, 20);
            this.chkEnableDisableDateRange.TabIndex = 0;
            this.chkEnableDisableDateRange.Text = "Enable/Disable Date Range";
            this.chkEnableDisableDateRange.UseVisualStyleBackColor = true;
            this.chkEnableDisableDateRange.CheckedChanged += new System.EventHandler(this.chkEnableDisableDateRange_CheckedChanged);
            // 
            // dToDate
            // 
            this.dToDate.CustomFormat = "dd-MMM-yyyy";
            this.dToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dToDate.Location = new System.Drawing.Point(208, 21);
            this.dToDate.Name = "dToDate";
            this.dToDate.Size = new System.Drawing.Size(97, 21);
            this.dToDate.TabIndex = 4;
            // 
            // dFromDate
            // 
            this.dFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dFromDate.Location = new System.Drawing.Point(83, 21);
            this.dFromDate.Name = "dFromDate";
            this.dFromDate.Size = new System.Drawing.Size(98, 21);
            this.dFromDate.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(184, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 15);
            this.label15.TabIndex = 3;
            this.label15.Text = "To";
            // 
            // lblCdate
            // 
            this.lblCdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCdate.Location = new System.Drawing.Point(3, 23);
            this.lblCdate.Name = "lblCdate";
            this.lblCdate.Size = new System.Drawing.Size(77, 14);
            this.lblCdate.TabIndex = 1;
            this.lblCdate.Text = "Create Date";
            this.lblCdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(975, 227);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 29);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(116, 102);
            this.ctlProduct1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(424, 25);
            this.ctlProduct1.TabIndex = 6;
            // 
            // frmSmartWarrantys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 553);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbSmartWarrantyTenure);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCertificateNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbPaymentMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProductSerialNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConsumerName);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwItem);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSmartWarrantys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSmartWarrantys";
            this.Load += new System.EventHandler(this.frmSmartWarrantys_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwItem;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colIssueDate;
        private System.Windows.Forms.ColumnHeader colShowroomName;
        private System.Windows.Forms.ColumnHeader colConsumerName;
        private System.Windows.Forms.ColumnHeader colMobileNo;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colProductModel;
        private System.Windows.Forms.ColumnHeader colProductSerialNo;
        private System.Windows.Forms.ColumnHeader colSmartWarrantyTenure;
        private System.Windows.Forms.ColumnHeader colStartDate;
        private System.Windows.Forms.ColumnHeader colEndDate;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colInvoiceDate;
        private System.Windows.Forms.ColumnHeader colCertificateNo;
        private System.Windows.Forms.ColumnHeader colPaymentMode;
        private System.Windows.Forms.ColumnHeader colBankName;
        private System.Windows.Forms.ColumnHeader colCardType;
        private System.Windows.Forms.ColumnHeader colPOSMachineName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TextBox txtConsumerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductSerialNo;
        private System.Windows.Forms.ComboBox cmbPaymentMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCertificateNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSmartWarrantyTenure;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkEnableDisableDateRange;
        private System.Windows.Forms.DateTimePicker dToDate;
        private System.Windows.Forms.DateTimePicker dFromDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCdate;
        private System.Windows.Forms.Button btnPrint;
        private Control.ctlProduct ctlProduct1;
    }
}