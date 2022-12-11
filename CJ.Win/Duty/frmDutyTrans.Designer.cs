namespace CJ.Win.Duty
{
    partial class frmDutyTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDutyTrans));
            this.btTreasuryChallan = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lvwTranList = new System.Windows.Forms.ListView();
            this.colChallanNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDocNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChallanType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmountDr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btRebate = new System.Windows.Forms.Button();
            this.btCreditNote = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMKaAccNo = new System.Windows.Forms.Label();
            this.lbMKaBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbMBalance = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbMAccNo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbChallanType = new System.Windows.Forms.ComboBox();
            this.cmbTranType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtToVATChallanNo = new System.Windows.Forms.TextBox();
            this.txtFromVATChallanNo = new System.Windows.Forms.TextBox();
            this.lbVatNo = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.rdoGetInvoiceByDateRange = new System.Windows.Forms.RadioButton();
            this.rdoGetInvoiceByVatChallanNo = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btFilter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbInvoiceType = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbInvoiceStatus = new System.Windows.Forms.ComboBox();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSBU = new System.Windows.Forms.ComboBox();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.btVatChallanPrint = new System.Windows.Forms.Button();
            this.btPrintInvoice = new System.Windows.Forms.Button();
            this.btRegister = new System.Windows.Forms.Button();
            this.btViewVatChallan = new System.Windows.Forms.Button();
            this.btViewInvoice = new System.Windows.Forms.Button();
            this.btnVATLedger = new System.Windows.Forms.Button();
            this.btnVatLedgerOutlet = new System.Windows.Forms.Button();
            this.btnNewVATLedger = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btTreasuryChallan
            // 
            this.btTreasuryChallan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTreasuryChallan.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btTreasuryChallan.Location = new System.Drawing.Point(966, 233);
            this.btTreasuryChallan.Name = "btTreasuryChallan";
            this.btTreasuryChallan.Size = new System.Drawing.Size(123, 24);
            this.btTreasuryChallan.TabIndex = 12;
            this.btTreasuryChallan.Tag = "M1.18";
            this.btTreasuryChallan.Text = "Treasury Challan";
            this.btTreasuryChallan.UseVisualStyleBackColor = true;
            this.btTreasuryChallan.Click += new System.EventHandler(this.btTreasuryChallan_Click);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGo.Location = new System.Drawing.Point(966, 203);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(123, 24);
            this.btnGo.TabIndex = 11;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lvwTranList
            // 
            this.lvwTranList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTranList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChallanNo,
            this.colDate,
            this.colDocNo,
            this.colChallanType,
            this.colTranType,
            this.colAmmount,
            this.colAmountDr,
            this.colCustomerCode,
            this.colCustomerName,
            this.colRemarks});
            this.lvwTranList.FullRowSelect = true;
            this.lvwTranList.GridLines = true;
            this.lvwTranList.HideSelection = false;
            this.lvwTranList.Location = new System.Drawing.Point(12, 203);
            this.lvwTranList.Name = "lvwTranList";
            this.lvwTranList.Size = new System.Drawing.Size(948, 460);
            this.lvwTranList.TabIndex = 10;
            this.lvwTranList.UseCompatibleStateImageBehavior = false;
            this.lvwTranList.View = System.Windows.Forms.View.Details;
            // 
            // colChallanNo
            // 
            this.colChallanNo.Text = "Challan No";
            this.colChallanNo.Width = 100;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 100;
            // 
            // colDocNo
            // 
            this.colDocNo.Text = "Document No";
            this.colDocNo.Width = 120;
            // 
            // colChallanType
            // 
            this.colChallanType.Text = "Challan Type";
            this.colChallanType.Width = 100;
            // 
            // colTranType
            // 
            this.colTranType.Text = "Transaction Type";
            this.colTranType.Width = 120;
            // 
            // colAmmount
            // 
            this.colAmmount.Text = "Amount (Cr)";
            this.colAmmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAmmount.Width = 80;
            // 
            // colAmountDr
            // 
            this.colAmountDr.Text = "Amount (Dr)";
            this.colAmountDr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAmountDr.Width = 80;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Text = "CustomerCode";
            this.colCustomerCode.Width = 100;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 150;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 300;
            // 
            // btRebate
            // 
            this.btRebate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRebate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btRebate.Location = new System.Drawing.Point(966, 263);
            this.btRebate.Name = "btRebate";
            this.btRebate.Size = new System.Drawing.Size(123, 24);
            this.btRebate.TabIndex = 13;
            this.btRebate.Tag = "M1.18";
            this.btRebate.Text = "Rebate";
            this.btRebate.UseVisualStyleBackColor = true;
            this.btRebate.Click += new System.EventHandler(this.btRebatePurchase_Click);
            // 
            // btCreditNote
            // 
            this.btCreditNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCreditNote.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btCreditNote.Location = new System.Drawing.Point(966, 293);
            this.btCreditNote.Name = "btCreditNote";
            this.btCreditNote.Size = new System.Drawing.Size(123, 24);
            this.btCreditNote.TabIndex = 14;
            this.btCreditNote.Tag = "M1.18";
            this.btCreditNote.Text = "Credit Note";
            this.btCreditNote.UseVisualStyleBackColor = true;
            this.btCreditNote.Click += new System.EventHandler(this.btCreditNote_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btDelete.Location = new System.Drawing.Point(966, 323);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(123, 24);
            this.btDelete.TabIndex = 15;
            this.btDelete.Tag = "M1.18";
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btClose.Location = new System.Drawing.Point(966, 639);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(123, 24);
            this.btClose.TabIndex = 24;
            this.btClose.Tag = "M1.18";
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(867, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account No:";
            // 
            // lbMKaAccNo
            // 
            this.lbMKaAccNo.AutoSize = true;
            this.lbMKaAccNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMKaAccNo.ForeColor = System.Drawing.Color.Blue;
            this.lbMKaAccNo.Location = new System.Drawing.Point(950, 13);
            this.lbMKaAccNo.Name = "lbMKaAccNo";
            this.lbMKaAccNo.Size = new System.Drawing.Size(77, 15);
            this.lbMKaAccNo.TabIndex = 3;
            this.lbMKaAccNo.Text = "Account No:";
            // 
            // lbMKaBalance
            // 
            this.lbMKaBalance.AutoSize = true;
            this.lbMKaBalance.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMKaBalance.ForeColor = System.Drawing.Color.Blue;
            this.lbMKaBalance.Location = new System.Drawing.Point(950, 34);
            this.lbMKaBalance.Name = "lbMKaBalance";
            this.lbMKaBalance.Size = new System.Drawing.Size(77, 15);
            this.lbMKaBalance.TabIndex = 5;
            this.lbMKaBalance.Text = "Account No:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(890, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Balance:";
            // 
            // lbMBalance
            // 
            this.lbMBalance.AutoSize = true;
            this.lbMBalance.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMBalance.ForeColor = System.Drawing.Color.Blue;
            this.lbMBalance.Location = new System.Drawing.Point(950, 75);
            this.lbMBalance.Name = "lbMBalance";
            this.lbMBalance.Size = new System.Drawing.Size(77, 15);
            this.lbMBalance.TabIndex = 9;
            this.lbMBalance.Text = "Account No:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(891, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Balance:";
            // 
            // lbMAccNo
            // 
            this.lbMAccNo.AutoSize = true;
            this.lbMAccNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMAccNo.ForeColor = System.Drawing.Color.Blue;
            this.lbMAccNo.Location = new System.Drawing.Point(950, 54);
            this.lbMAccNo.Name = "lbMAccNo";
            this.lbMAccNo.Size = new System.Drawing.Size(77, 15);
            this.lbMAccNo.TabIndex = 7;
            this.lbMAccNo.Text = "Account No:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(867, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 15);
            this.label10.TabIndex = 6;
            this.label10.Text = "Account No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(384, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 197;
            this.label3.Text = "Tran Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(338, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 194;
            this.label4.Text = "VAT Challan Type :";
            // 
            // cmbChallanType
            // 
            this.cmbChallanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChallanType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChallanType.FormattingEnabled = true;
            this.cmbChallanType.Items.AddRange(new object[] {
            "<ALL>",
            "Mushak 11",
            "Mushak 11(Ka)"});
            this.cmbChallanType.Location = new System.Drawing.Point(457, 18);
            this.cmbChallanType.Name = "cmbChallanType";
            this.cmbChallanType.Size = new System.Drawing.Size(159, 23);
            this.cmbChallanType.TabIndex = 198;
            // 
            // cmbTranType
            // 
            this.cmbTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTranType.FormattingEnabled = true;
            this.cmbTranType.Location = new System.Drawing.Point(457, 46);
            this.cmbTranType.Name = "cmbTranType";
            this.cmbTranType.Size = new System.Drawing.Size(159, 23);
            this.cmbTranType.TabIndex = 199;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtToVATChallanNo);
            this.groupBox1.Controls.Add(this.txtFromVATChallanNo);
            this.groupBox1.Controls.Add(this.lbVatNo);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.rdoGetInvoiceByDateRange);
            this.groupBox1.Controls.Add(this.rdoGetInvoiceByVatChallanNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 193);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Duty Selection Criteria";
            // 
            // txtToVATChallanNo
            // 
            this.txtToVATChallanNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtToVATChallanNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToVATChallanNo.Location = new System.Drawing.Point(111, 151);
            this.txtToVATChallanNo.Name = "txtToVATChallanNo";
            this.txtToVATChallanNo.Size = new System.Drawing.Size(101, 23);
            this.txtToVATChallanNo.TabIndex = 218;
            this.txtToVATChallanNo.Visible = false;
            // 
            // txtFromVATChallanNo
            // 
            this.txtFromVATChallanNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFromVATChallanNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromVATChallanNo.Location = new System.Drawing.Point(111, 125);
            this.txtFromVATChallanNo.Name = "txtFromVATChallanNo";
            this.txtFromVATChallanNo.Size = new System.Drawing.Size(101, 23);
            this.txtFromVATChallanNo.TabIndex = 217;
            this.txtFromVATChallanNo.Visible = false;
            // 
            // lbVatNo
            // 
            this.lbVatNo.AutoSize = true;
            this.lbVatNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVatNo.Location = new System.Drawing.Point(6, 127);
            this.lbVatNo.Name = "lbVatNo";
            this.lbVatNo.Size = new System.Drawing.Size(102, 15);
            this.lbVatNo.TabIndex = 216;
            this.lbVatNo.Text = "VAT Challan No :";
            this.lbVatNo.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(83, 99);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 15);
            this.lblTo.TabIndex = 215;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(72, 73);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 15);
            this.lblDate.TabIndex = 214;
            this.lblDate.Text = "From";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(110, 96);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(102, 23);
            this.dtToDate.TabIndex = 213;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(111, 69);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(101, 23);
            this.dtFromDate.TabIndex = 212;
            // 
            // rdoGetInvoiceByDateRange
            // 
            this.rdoGetInvoiceByDateRange.AutoSize = true;
            this.rdoGetInvoiceByDateRange.Checked = true;
            this.rdoGetInvoiceByDateRange.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoGetInvoiceByDateRange.Location = new System.Drawing.Point(8, 22);
            this.rdoGetInvoiceByDateRange.Name = "rdoGetInvoiceByDateRange";
            this.rdoGetInvoiceByDateRange.Size = new System.Drawing.Size(160, 19);
            this.rdoGetInvoiceByDateRange.TabIndex = 0;
            this.rdoGetInvoiceByDateRange.TabStop = true;
            this.rdoGetInvoiceByDateRange.Text = "Get Duty By Date Range";
            this.rdoGetInvoiceByDateRange.UseVisualStyleBackColor = true;
            this.rdoGetInvoiceByDateRange.CheckedChanged += new System.EventHandler(this.rdoGetInvoiceByDateRange_CheckedChanged);
            // 
            // rdoGetInvoiceByVatChallanNo
            // 
            this.rdoGetInvoiceByVatChallanNo.AutoSize = true;
            this.rdoGetInvoiceByVatChallanNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoGetInvoiceByVatChallanNo.Location = new System.Drawing.Point(8, 44);
            this.rdoGetInvoiceByVatChallanNo.Name = "rdoGetInvoiceByVatChallanNo";
            this.rdoGetInvoiceByVatChallanNo.Size = new System.Drawing.Size(182, 19);
            this.rdoGetInvoiceByVatChallanNo.TabIndex = 2;
            this.rdoGetInvoiceByVatChallanNo.Text = "Get Duty By VAT Challan No";
            this.rdoGetInvoiceByVatChallanNo.UseVisualStyleBackColor = true;
            this.rdoGetInvoiceByVatChallanNo.CheckedChanged += new System.EventHandler(this.rdoGetInvoiceByVatChallanNo_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btFilter);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbInvoiceType);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.cmbInvoiceStatus);
            this.groupBox2.Controls.Add(this.cmbChannel);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtCustomerCode);
            this.groupBox2.Controls.Add(this.cmbChallanType);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cmbWarehouse);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbTranType);
            this.groupBox2.Controls.Add(this.cmbSBU);
            this.groupBox2.Controls.Add(this.txtDocNo);
            this.groupBox2.Location = new System.Drawing.Point(235, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 190);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Duty Filtering Criteria";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btFilter
            // 
            this.btFilter.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFilter.Location = new System.Drawing.Point(493, 157);
            this.btFilter.Name = "btFilter";
            this.btFilter.Size = new System.Drawing.Size(123, 27);
            this.btFilter.TabIndex = 213;
            this.btFilter.Text = "Filter Data";
            this.btFilter.UseVisualStyleBackColor = true;
            this.btFilter.Click += new System.EventHandler(this.btFilter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(362, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 225;
            this.label5.Text = "Invoice Type : ";
            // 
            // cmbInvoiceType
            // 
            this.cmbInvoiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInvoiceType.FormattingEnabled = true;
            this.cmbInvoiceType.Location = new System.Drawing.Point(457, 76);
            this.cmbInvoiceType.Name = "cmbInvoiceType";
            this.cmbInvoiceType.Size = new System.Drawing.Size(159, 23);
            this.cmbInvoiceType.TabIndex = 222;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(358, 110);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 15);
            this.label14.TabIndex = 224;
            this.label14.Text = "Invoice Status : ";
            // 
            // cmbInvoiceStatus
            // 
            this.cmbInvoiceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceStatus.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInvoiceStatus.FormattingEnabled = true;
            this.cmbInvoiceStatus.Location = new System.Drawing.Point(457, 105);
            this.cmbInvoiceStatus.Name = "cmbInvoiceStatus";
            this.cmbInvoiceStatus.Size = new System.Drawing.Size(159, 23);
            this.cmbInvoiceStatus.TabIndex = 223;
            // 
            // cmbChannel
            // 
            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChannel.FormattingEnabled = true;
            this.cmbChannel.Location = new System.Drawing.Point(138, 46);
            this.cmbChannel.Name = "cmbChannel";
            this.cmbChannel.Size = new System.Drawing.Size(196, 23);
            this.cmbChannel.TabIndex = 215;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(57, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 219;
            this.label9.Text = "Warehouse :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(98, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 15);
            this.label13.TabIndex = 221;
            this.label13.Text = "SBU :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 15);
            this.label7.TabIndex = 216;
            this.label7.Text = "Customer Code :";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(78, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 15);
            this.label11.TabIndex = 218;
            this.label11.Text = "Channel:";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerCode.Location = new System.Drawing.Point(138, 130);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(196, 23);
            this.txtCustomerCode.TabIndex = 212;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 164);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 15);
            this.label12.TabIndex = 217;
            this.label12.Text = "Customer Name like :";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(138, 75);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(196, 23);
            this.cmbWarehouse.TabIndex = 214;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(138, 159);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(196, 23);
            this.txtCustomerName.TabIndex = 213;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 211;
            this.label1.Text = "Document No:";
            // 
            // cmbSBU
            // 
            this.cmbSBU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSBU.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSBU.FormattingEnabled = true;
            this.cmbSBU.Location = new System.Drawing.Point(138, 20);
            this.cmbSBU.Name = "cmbSBU";
            this.cmbSBU.Size = new System.Drawing.Size(196, 23);
            this.cmbSBU.TabIndex = 220;
            // 
            // txtDocNo
            // 
            this.txtDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNo.Location = new System.Drawing.Point(138, 104);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(196, 23);
            this.txtDocNo.TabIndex = 210;
            // 
            // btVatChallanPrint
            // 
            this.btVatChallanPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btVatChallanPrint.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btVatChallanPrint.Location = new System.Drawing.Point(966, 413);
            this.btVatChallanPrint.Name = "btVatChallanPrint";
            this.btVatChallanPrint.Size = new System.Drawing.Size(123, 24);
            this.btVatChallanPrint.TabIndex = 18;
            this.btVatChallanPrint.Tag = "M1.18";
            this.btVatChallanPrint.Text = "Reprint VAT Challan";
            this.btVatChallanPrint.UseVisualStyleBackColor = true;
            this.btVatChallanPrint.Click += new System.EventHandler(this.btVatChallanPrint_Click);
            // 
            // btPrintInvoice
            // 
            this.btPrintInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrintInvoice.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btPrintInvoice.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btPrintInvoice.Location = new System.Drawing.Point(966, 443);
            this.btPrintInvoice.Name = "btPrintInvoice";
            this.btPrintInvoice.Size = new System.Drawing.Size(123, 24);
            this.btPrintInvoice.TabIndex = 19;
            this.btPrintInvoice.Text = "Reprint Invoice";
            this.btPrintInvoice.UseVisualStyleBackColor = true;
            this.btPrintInvoice.Click += new System.EventHandler(this.btPrintInvoice_Click);
            // 
            // btRegister
            // 
            this.btRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRegister.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btRegister.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btRegister.Location = new System.Drawing.Point(966, 473);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(123, 24);
            this.btRegister.TabIndex = 20;
            this.btRegister.Text = "Challan Register";
            this.btRegister.UseVisualStyleBackColor = true;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // btViewVatChallan
            // 
            this.btViewVatChallan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btViewVatChallan.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btViewVatChallan.Location = new System.Drawing.Point(966, 353);
            this.btViewVatChallan.Name = "btViewVatChallan";
            this.btViewVatChallan.Size = new System.Drawing.Size(123, 24);
            this.btViewVatChallan.TabIndex = 16;
            this.btViewVatChallan.Tag = "M1.18";
            this.btViewVatChallan.Text = "View VAT Challan";
            this.btViewVatChallan.UseVisualStyleBackColor = true;
            this.btViewVatChallan.Click += new System.EventHandler(this.btViewVatChallan_Click);
            // 
            // btViewInvoice
            // 
            this.btViewInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btViewInvoice.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btViewInvoice.Location = new System.Drawing.Point(966, 383);
            this.btViewInvoice.Name = "btViewInvoice";
            this.btViewInvoice.Size = new System.Drawing.Size(123, 24);
            this.btViewInvoice.TabIndex = 17;
            this.btViewInvoice.Tag = "M1.18";
            this.btViewInvoice.Text = "View Invoice";
            this.btViewInvoice.UseVisualStyleBackColor = true;
            this.btViewInvoice.Click += new System.EventHandler(this.btViewInvoice_Click);
            // 
            // btnVATLedger
            // 
            this.btnVATLedger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVATLedger.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnVATLedger.Location = new System.Drawing.Point(966, 503);
            this.btnVATLedger.Name = "btnVATLedger";
            this.btnVATLedger.Size = new System.Drawing.Size(123, 24);
            this.btnVATLedger.TabIndex = 21;
            this.btnVATLedger.Text = "Vat Ledger ";
            this.btnVATLedger.UseVisualStyleBackColor = true;
            this.btnVATLedger.Click += new System.EventHandler(this.btnVATLedger_Click);
            // 
            // btnVatLedgerOutlet
            // 
            this.btnVatLedgerOutlet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVatLedgerOutlet.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnVatLedgerOutlet.Location = new System.Drawing.Point(966, 533);
            this.btnVatLedgerOutlet.Name = "btnVatLedgerOutlet";
            this.btnVatLedgerOutlet.Size = new System.Drawing.Size(123, 24);
            this.btnVatLedgerOutlet.TabIndex = 22;
            this.btnVatLedgerOutlet.Text = "Vat Ledger (Outlet)";
            this.btnVatLedgerOutlet.UseVisualStyleBackColor = true;
            this.btnVatLedgerOutlet.Click += new System.EventHandler(this.btnVatLedgerOutlet_Click);
            // 
            // btnNewVATLedger
            // 
            this.btnNewVATLedger.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewVATLedger.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnNewVATLedger.Location = new System.Drawing.Point(966, 563);
            this.btnNewVATLedger.Name = "btnNewVATLedger";
            this.btnNewVATLedger.Size = new System.Drawing.Size(123, 24);
            this.btnNewVATLedger.TabIndex = 23;
            this.btnNewVATLedger.Text = "Vat Ledger (6.2.1)";
            this.btnNewVATLedger.UseVisualStyleBackColor = true;
            this.btnNewVATLedger.Click += new System.EventHandler(this.btnNewVATLedger_Click);
            // 
            // frmDutyTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 677);
            this.Controls.Add(this.btnNewVATLedger);
            this.Controls.Add(this.btnVatLedgerOutlet);
            this.Controls.Add(this.btnVATLedger);
            this.Controls.Add(this.btViewInvoice);
            this.Controls.Add(this.btViewVatChallan);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.btPrintInvoice);
            this.Controls.Add(this.btVatChallanPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbMBalance);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbMAccNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbMKaBalance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbMKaAccNo);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btCreditNote);
            this.Controls.Add(this.btRebate);
            this.Controls.Add(this.btTreasuryChallan);
            this.Controls.Add(this.lvwTranList);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDutyTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.Load += new System.EventHandler(this.frmDutyTrans_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btTreasuryChallan;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ListView lvwTranList;
        private System.Windows.Forms.Button btRebate;
        private System.Windows.Forms.Button btCreditNote;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ColumnHeader colChallanNo;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colDocNo;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMKaAccNo;
        private System.Windows.Forms.Label lbMKaBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbMBalance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbMAccNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader colAmmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbChallanType;
        private System.Windows.Forms.ComboBox cmbTranType;
        private System.Windows.Forms.ColumnHeader colChallanType;
        private System.Windows.Forms.ColumnHeader colTranType;
        private System.Windows.Forms.ColumnHeader colAmountDr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoGetInvoiceByDateRange;
        private System.Windows.Forms.RadioButton rdoGetInvoiceByVatChallanNo;
        private System.Windows.Forms.TextBox txtToVATChallanNo;
        private System.Windows.Forms.TextBox txtFromVATChallanNo;
        private System.Windows.Forms.Label lbVatNo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbSBU;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbInvoiceType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbInvoiceStatus;
        private System.Windows.Forms.Button btFilter;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.Button btVatChallanPrint;
        private System.Windows.Forms.Button btPrintInvoice;
        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.Button btViewVatChallan;
        private System.Windows.Forms.Button btViewInvoice;
        private System.Windows.Forms.Button btnVATLedger;
        private System.Windows.Forms.Button btnVatLedgerOutlet;
        private System.Windows.Forms.Button btnNewVATLedger;
    }
}