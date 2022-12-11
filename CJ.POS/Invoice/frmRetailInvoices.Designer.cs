namespace CJ.POS.Invoice
{
    partial class frmRetailInvoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRetailInvoices));
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.colInvoiceDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.colInvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lvwInvoice = new System.Windows.Forms.ListView();
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConsumer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMobileNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSalestype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colstatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btClose = new System.Windows.Forms.Button();
            this.btInvoicePrint = new System.Windows.Forms.Button();
            this.btWarrantyPrint = new System.Windows.Forms.Button();
            this.btVATPrint = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnReverseInvoice = new System.Windows.Forms.Button();
            this.btnVAT11Ka = new System.Windows.Forms.Button();
            this.btnGenerateWC = new System.Windows.Forms.Button();
            this.btnVat63Print = new System.Windows.Forms.Button();
            this.btnSendeMail = new System.Windows.Forms.Button();
            this.cmbSalesType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.btnVat67Print = new System.Windows.Forms.Button();
            this.btnPrintDeliveryChallan = new System.Windows.Forms.Button();
            this.btnGatePass = new System.Windows.Forms.Button();
            this.btnWarrantyCardThermal = new System.Windows.Forms.Button();
            this.btnMushak63Thermal = new System.Windows.Forms.Button();
            this.btnDirectPrint = new System.Windows.Forms.Button();
            this.btnThermalPrint = new System.Windows.Forms.Button();
            this.btnDeliveryChalanThermal = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(112, 66);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(192, 23);
            this.txtInvoiceNo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Invoice #:";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(606, 154);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(121, 28);
            this.btnGo.TabIndex = 14;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(249, 22);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 15);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(12, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 15);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Invoice Date: ";
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Text = "Invoice Date";
            this.colInvoiceDate.Width = 96;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(290, 27);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(133, 23);
            this.dtToDate.TabIndex = 1;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No";
            this.colInvoiceNo.Width = 100;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(96, 19);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(133, 21);
            this.dtFromDate.TabIndex = 2;
            // 
            // lvwInvoice
            // 
            this.lvwInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colAmount,
            this.colConsumer,
            this.colMobileNo,
            this.colSalestype,
            this.colstatus,
            this.colInvoStatus});
            this.lvwInvoice.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwInvoice.FullRowSelect = true;
            this.lvwInvoice.GridLines = true;
            this.lvwInvoice.HideSelection = false;
            this.lvwInvoice.Location = new System.Drawing.Point(16, 192);
            this.lvwInvoice.MultiSelect = false;
            this.lvwInvoice.Name = "lvwInvoice";
            this.lvwInvoice.Size = new System.Drawing.Size(711, 400);
            this.lvwInvoice.TabIndex = 15;
            this.lvwInvoice.UseCompatibleStateImageBehavior = false;
            this.lvwInvoice.View = System.Windows.Forms.View.Details;
            this.lvwInvoice.Click += new System.EventHandler(this.lvwInvoice_Click);
            this.lvwInvoice.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwInvoice_KeyUp);
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 89;
            // 
            // colConsumer
            // 
            this.colConsumer.Text = "Consumer";
            this.colConsumer.Width = 200;
            // 
            // colMobileNo
            // 
            this.colMobileNo.Text = "Mobile #";
            this.colMobileNo.Width = 109;
            // 
            // colSalestype
            // 
            this.colSalestype.Text = "Sales Type";
            this.colSalestype.Width = 77;
            // 
            // colstatus
            // 
            this.colstatus.Text = "Invoice Type";
            this.colstatus.Width = 120;
            // 
            // colInvoStatus
            // 
            this.colInvoStatus.Text = "Invoice Status";
            this.colInvoStatus.Width = 100;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(6, 380);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(141, 27);
            this.btClose.TabIndex = 26;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btInvoicePrint
            // 
            this.btInvoicePrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInvoicePrint.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInvoicePrint.Location = new System.Drawing.Point(6, 22);
            this.btInvoicePrint.Name = "btInvoicePrint";
            this.btInvoicePrint.Size = new System.Drawing.Size(141, 27);
            this.btInvoicePrint.TabIndex = 15;
            this.btInvoicePrint.Text = " Invoice Print ";
            this.btInvoicePrint.UseVisualStyleBackColor = true;
            this.btInvoicePrint.Click += new System.EventHandler(this.btInvoicePrint_Click);
            // 
            // btWarrantyPrint
            // 
            this.btWarrantyPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btWarrantyPrint.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btWarrantyPrint.Location = new System.Drawing.Point(6, 51);
            this.btWarrantyPrint.Name = "btWarrantyPrint";
            this.btWarrantyPrint.Size = new System.Drawing.Size(141, 27);
            this.btWarrantyPrint.TabIndex = 17;
            this.btWarrantyPrint.Text = "Warranty Card Print ";
            this.btWarrantyPrint.UseVisualStyleBackColor = true;
            this.btWarrantyPrint.Click += new System.EventHandler(this.btWarrantyPrint_Click);
            // 
            // btVATPrint
            // 
            this.btVATPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btVATPrint.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVATPrint.Location = new System.Drawing.Point(6, 215);
            this.btVATPrint.Name = "btVATPrint";
            this.btVATPrint.Size = new System.Drawing.Size(141, 27);
            this.btVATPrint.TabIndex = 22;
            this.btVATPrint.Text = " VAT Print Mushak-11";
            this.btVATPrint.UseVisualStyleBackColor = true;
            this.btVATPrint.Click += new System.EventHandler(this.btVATPrint_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(112, 95);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(192, 23);
            this.txtCustomerName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Custome Name: ";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(419, 124);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(181, 23);
            this.txtMobileNo.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(349, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mobile # :";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(112, 154);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(488, 23);
            this.txtAddress.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Address: ";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(419, 95);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(181, 23);
            this.txtCustomerID.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(313, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Consumer Code:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(12, -1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(183, 20);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnReverseInvoice
            // 
            this.btnReverseInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReverseInvoice.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReverseInvoice.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnReverseInvoice.Location = new System.Drawing.Point(6, 22);
            this.btnReverseInvoice.Name = "btnReverseInvoice";
            this.btnReverseInvoice.Size = new System.Drawing.Size(141, 27);
            this.btnReverseInvoice.TabIndex = 16;
            this.btnReverseInvoice.Text = "Reverse Invoice ";
            this.btnReverseInvoice.UseVisualStyleBackColor = true;
            this.btnReverseInvoice.Click += new System.EventHandler(this.btnReverseInvoice_Click);
            // 
            // btnVAT11Ka
            // 
            this.btnVAT11Ka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVAT11Ka.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVAT11Ka.Location = new System.Drawing.Point(6, 249);
            this.btnVAT11Ka.Name = "btnVAT11Ka";
            this.btnVAT11Ka.Size = new System.Drawing.Size(141, 27);
            this.btnVAT11Ka.TabIndex = 23;
            this.btnVAT11Ka.Text = " VAT Print Mushak-11 (Ka)";
            this.btnVAT11Ka.UseVisualStyleBackColor = true;
            this.btnVAT11Ka.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGenerateWC
            // 
            this.btnGenerateWC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateWC.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateWC.Location = new System.Drawing.Point(6, 84);
            this.btnGenerateWC.Name = "btnGenerateWC";
            this.btnGenerateWC.Size = new System.Drawing.Size(141, 27);
            this.btnGenerateWC.TabIndex = 18;
            this.btnGenerateWC.Text = "Generate Warranty Card";
            this.btnGenerateWC.UseVisualStyleBackColor = true;
            this.btnGenerateWC.Click += new System.EventHandler(this.btnGenerateWC_Click);
            // 
            // btnVat63Print
            // 
            this.btnVat63Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVat63Print.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVat63Print.Location = new System.Drawing.Point(6, 150);
            this.btnVat63Print.Name = "btnVat63Print";
            this.btnVat63Print.Size = new System.Drawing.Size(141, 27);
            this.btnVat63Print.TabIndex = 20;
            this.btnVat63Print.Text = " VAT Print Mushak-6.3";
            this.btnVat63Print.UseVisualStyleBackColor = true;
            this.btnVat63Print.Click += new System.EventHandler(this.btnVat63Print_Click);
            // 
            // btnSendeMail
            // 
            this.btnSendeMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendeMail.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendeMail.Location = new System.Drawing.Point(6, 313);
            this.btnSendeMail.Name = "btnSendeMail";
            this.btnSendeMail.Size = new System.Drawing.Size(141, 27);
            this.btnSendeMail.TabIndex = 25;
            this.btnSendeMail.Text = "Send eMail";
            this.btnSendeMail.UseVisualStyleBackColor = true;
            this.btnSendeMail.Visible = false;
            this.btnSendeMail.Click += new System.EventHandler(this.btnSendeMail_Click);
            // 
            // cmbSalesType
            // 
            this.cmbSalesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesType.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSalesType.FormattingEnabled = true;
            this.cmbSalesType.Location = new System.Drawing.Point(112, 124);
            this.cmbSalesType.Name = "cmbSalesType";
            this.cmbSalesType.Size = new System.Drawing.Size(192, 24);
            this.cmbSalesType.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Sales Type:";
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendSMS.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSMS.Location = new System.Drawing.Point(6, 282);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(141, 27);
            this.btnSendSMS.TabIndex = 24;
            this.btnSendSMS.Text = "Send SMS";
            this.btnSendSMS.UseVisualStyleBackColor = true;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // btnVat67Print
            // 
            this.btnVat67Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVat67Print.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVat67Print.Location = new System.Drawing.Point(6, 182);
            this.btnVat67Print.Name = "btnVat67Print";
            this.btnVat67Print.Size = new System.Drawing.Size(141, 27);
            this.btnVat67Print.TabIndex = 21;
            this.btnVat67Print.Text = " VAT Print Mushak-6.7";
            this.btnVat67Print.UseVisualStyleBackColor = true;
            this.btnVat67Print.Click += new System.EventHandler(this.btnVat67Print_Click);
            // 
            // btnPrintDeliveryChallan
            // 
            this.btnPrintDeliveryChallan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintDeliveryChallan.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintDeliveryChallan.Location = new System.Drawing.Point(6, 117);
            this.btnPrintDeliveryChallan.Name = "btnPrintDeliveryChallan";
            this.btnPrintDeliveryChallan.Size = new System.Drawing.Size(141, 27);
            this.btnPrintDeliveryChallan.TabIndex = 19;
            this.btnPrintDeliveryChallan.Text = "Print Delivery Challan";
            this.btnPrintDeliveryChallan.UseVisualStyleBackColor = true;
            this.btnPrintDeliveryChallan.Click += new System.EventHandler(this.btnPrintDeliveryChallan_Click);
            // 
            // btnGatePass
            // 
            this.btnGatePass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGatePass.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGatePass.Location = new System.Drawing.Point(6, 347);
            this.btnGatePass.Name = "btnGatePass";
            this.btnGatePass.Size = new System.Drawing.Size(141, 27);
            this.btnGatePass.TabIndex = 27;
            this.btnGatePass.Text = "Print Gate Pass";
            this.btnGatePass.UseVisualStyleBackColor = true;
            this.btnGatePass.Click += new System.EventHandler(this.btnGatePass_Click);
            // 
            // btnWarrantyCardThermal
            // 
            this.btnWarrantyCardThermal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWarrantyCardThermal.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWarrantyCardThermal.Location = new System.Drawing.Point(6, 116);
            this.btnWarrantyCardThermal.Name = "btnWarrantyCardThermal";
            this.btnWarrantyCardThermal.Size = new System.Drawing.Size(141, 25);
            this.btnWarrantyCardThermal.TabIndex = 30;
            this.btnWarrantyCardThermal.Text = "Warranty Card Thermal";
            this.btnWarrantyCardThermal.UseVisualStyleBackColor = true;
            this.btnWarrantyCardThermal.Click += new System.EventHandler(this.btnWarrantyCardThermal_Click);
            // 
            // btnMushak63Thermal
            // 
            this.btnMushak63Thermal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMushak63Thermal.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMushak63Thermal.Location = new System.Drawing.Point(6, 147);
            this.btnMushak63Thermal.Name = "btnMushak63Thermal";
            this.btnMushak63Thermal.Size = new System.Drawing.Size(141, 27);
            this.btnMushak63Thermal.TabIndex = 29;
            this.btnMushak63Thermal.Text = "Mushak-6.3 (Thermal)";
            this.btnMushak63Thermal.UseVisualStyleBackColor = true;
            this.btnMushak63Thermal.Click += new System.EventHandler(this.btnMushak63Thermal_Click);
            // 
            // btnDirectPrint
            // 
            this.btnDirectPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirectPrint.Location = new System.Drawing.Point(6, 87);
            this.btnDirectPrint.Name = "btnDirectPrint";
            this.btnDirectPrint.Size = new System.Drawing.Size(141, 24);
            this.btnDirectPrint.TabIndex = 164;
            this.btnDirectPrint.Text = "Direct Invoice Thermal";
            this.btnDirectPrint.UseVisualStyleBackColor = true;
            this.btnDirectPrint.Click += new System.EventHandler(this.btnDirectPrint_Click);
            // 
            // btnThermalPrint
            // 
            this.btnThermalPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThermalPrint.Location = new System.Drawing.Point(6, 61);
            this.btnThermalPrint.Name = "btnThermalPrint";
            this.btnThermalPrint.Size = new System.Drawing.Size(141, 23);
            this.btnThermalPrint.TabIndex = 163;
            this.btnThermalPrint.Text = "Invoice Thermal";
            this.btnThermalPrint.UseVisualStyleBackColor = true;
            this.btnThermalPrint.Click += new System.EventHandler(this.btnThermalPrint_Click);
            // 
            // btnDeliveryChalanThermal
            // 
            this.btnDeliveryChalanThermal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeliveryChalanThermal.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeliveryChalanThermal.Location = new System.Drawing.Point(6, 17);
            this.btnDeliveryChalanThermal.Name = "btnDeliveryChalanThermal";
            this.btnDeliveryChalanThermal.Size = new System.Drawing.Size(141, 42);
            this.btnDeliveryChalanThermal.TabIndex = 165;
            this.btnDeliveryChalanThermal.Text = "Delivery Challan Thermal";
            this.btnDeliveryChalanThermal.UseVisualStyleBackColor = true;
            this.btnDeliveryChalanThermal.Click += new System.EventHandler(this.btnDeliveryChalanThermal_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDeliveryChalanThermal);
            this.groupBox2.Controls.Add(this.btnMushak63Thermal);
            this.groupBox2.Controls.Add(this.btnDirectPrint);
            this.groupBox2.Controls.Add(this.btnWarrantyCardThermal);
            this.groupBox2.Controls.Add(this.btnThermalPrint);
            this.groupBox2.Location = new System.Drawing.Point(741, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 180);
            this.groupBox2.TabIndex = 166;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thermal";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnReverseInvoice);
            this.groupBox3.Controls.Add(this.btClose);
            this.groupBox3.Controls.Add(this.btnGatePass);
            this.groupBox3.Controls.Add(this.btInvoicePrint);
            this.groupBox3.Controls.Add(this.btnPrintDeliveryChallan);
            this.groupBox3.Controls.Add(this.btWarrantyPrint);
            this.groupBox3.Controls.Add(this.btnVat67Print);
            this.groupBox3.Controls.Add(this.btVATPrint);
            this.groupBox3.Controls.Add(this.btnSendSMS);
            this.groupBox3.Controls.Add(this.btnVAT11Ka);
            this.groupBox3.Controls.Add(this.btnGenerateWC);
            this.groupBox3.Controls.Add(this.btnVat63Print);
            this.groupBox3.Controls.Add(this.btnSendeMail);
            this.groupBox3.Location = new System.Drawing.Point(741, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 413);
            this.groupBox3.TabIndex = 167;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General";
            // 
            // frmRetailInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 613);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSalesType);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.lvwInvoice);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRetailInvoices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retail Invoices";
            this.Load += new System.EventHandler(this.frmRetailInvoices_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ColumnHeader colInvoiceDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.ListView lvwInvoice;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colConsumer;
        private System.Windows.Forms.ColumnHeader colstatus;
        private System.Windows.Forms.Button btInvoicePrint;
        private System.Windows.Forms.Button btWarrantyPrint;
        private System.Windows.Forms.Button btVATPrint;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnReverseInvoice;
        private System.Windows.Forms.ColumnHeader colInvoStatus;
        private System.Windows.Forms.Button btnVAT11Ka;
        private System.Windows.Forms.Button btnGenerateWC;
        private System.Windows.Forms.Button btnVat63Print;
        private System.Windows.Forms.Button btnSendeMail;
        private System.Windows.Forms.ColumnHeader colMobileNo;
        private System.Windows.Forms.ComboBox cmbSalesType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader colSalestype;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.Button btnVat67Print;
        private System.Windows.Forms.Button btnPrintDeliveryChallan;
        private System.Windows.Forms.Button btnGatePass;
        private System.Windows.Forms.Button btnWarrantyCardThermal;
        private System.Windows.Forms.Button btnMushak63Thermal;
        private System.Windows.Forms.Button btnDirectPrint;
        private System.Windows.Forms.Button btnThermalPrint;
        private System.Windows.Forms.Button btnDeliveryChalanThermal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}