namespace CJ.Win.Distribution
{
    partial class frmDeliveryInvoices
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
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDelivery = new System.Windows.Forms.Button();
            this.cmbInvoiceStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.colOrderReceivedBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.colInvoiceAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnShow = new System.Windows.Forms.Button();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lvwOrderList = new System.Windows.Forms.ListView();
            this.btPrintVAT = new System.Windows.Forms.Button();
            this.btPrintInvoice = new System.Windows.Forms.Button();
            this.btProcessDelivery = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.btDeliveryNote = new System.Windows.Forms.Button();
            this.btGetData = new System.Windows.Forms.Button();
            this.btMakeInvoice = new System.Windows.Forms.Button();
            this.btViewInvoice = new System.Windows.Forms.Button();
            this.btClaimInvoice = new System.Windows.Forms.Button();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.btnWarrantyCard = new System.Windows.Forms.Button();
            this.btnWarrantyCardAuto = new System.Windows.Forms.Button();
            this.btnCreditNote = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnReturnNote = new System.Windows.Forms.Button();
            this.btnPrintWarrantyCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(833, 574);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 161;
            this.label13.Text = "Other";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(588, 574);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 160;
            this.label12.Text = "Undelivered";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(775, 574);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 159;
            this.label11.Text = "Canceled";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(658, 574);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 158;
            this.label10.Text = "Processing";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(723, 574);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 157;
            this.label9.Text = "Pending";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(530, 574);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 156;
            this.label8.Text = "Delivered";
            // 
            // btnDelivery
            // 
            this.btnDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelivery.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelivery.Enabled = false;
            this.btnDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelivery.Location = new System.Drawing.Point(879, 196);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(112, 36);
            this.btnDelivery.TabIndex = 153;
            this.btnDelivery.Text = "Delivery Invoice && VAT";
            this.btnDelivery.UseVisualStyleBackColor = true;
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // cmbInvoiceStatus
            // 
            this.cmbInvoiceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInvoiceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInvoiceStatus.FormattingEnabled = true;
            this.cmbInvoiceStatus.Location = new System.Drawing.Point(392, 28);
            this.cmbInvoiceStatus.Name = "cmbInvoiceStatus";
            this.cmbInvoiceStatus.Size = new System.Drawing.Size(167, 21);
            this.cmbInvoiceStatus.TabIndex = 152;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(302, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 151;
            this.label6.Text = "Invoice Status : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(279, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 150;
            this.label4.Text = "Customer Name like :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 149;
            this.label3.Text = "Customer Code :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 148;
            this.label5.Text = "Invoice No :";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(392, 53);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(167, 20);
            this.txtCustomerName.TabIndex = 146;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerCode.Location = new System.Drawing.Point(107, 75);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(167, 20);
            this.txtCustomerCode.TabIndex = 145;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(107, 28);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(168, 20);
            this.txtInvoiceNo.TabIndex = 144;
            // 
            // colOrderReceivedBy
            // 
            this.colOrderReceivedBy.Text = "Invoiced By";
            this.colOrderReceivedBy.Width = 92;
            // 
            // colOrderDate
            // 
            this.colOrderDate.Text = "Invoice Date";
            this.colOrderDate.Width = 98;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(880, 543);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 25);
            this.btnClose.TabIndex = 137;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // colInvoiceAmount
            // 
            this.colInvoiceAmount.Text = "Invoice Amount";
            this.colInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInvoiceAmount.Width = 112;
            // 
            // colCustName
            // 
            this.colCustName.Text = "Customer Name";
            this.colCustName.Width = 186;
            // 
            // colOrderID
            // 
            this.colOrderID.Text = "Invoice No";
            this.colOrderID.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Invoice Status";
            this.columnHeader2.Width = 113;
            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer Code";
            this.colCustomer.Width = 100;
            // 
            // btnShow
            // 
            this.btnShow.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(467, 77);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(90, 23);
            this.btnShow.TabIndex = 136;
            this.btnShow.Text = "Filter";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sales Order No";
            this.columnHeader3.Width = 115;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(229, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 135;
            this.label2.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 134;
            this.label1.Text = "From";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Delivered By";
            this.columnHeader1.Width = 99;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(254, 2);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(102, 20);
            this.dtpToDate.TabIndex = 133;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(107, 2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(99, 20);
            this.dtFromDate.TabIndex = 132;
            // 
            // lvwOrderList
            // 
            this.lvwOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOrderList.CausesValidation = false;
            this.lvwOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrderID,
            this.columnHeader3,
            this.colCustomer,
            this.colCustName,
            this.colOrderDate,
            this.colInvoiceAmount,
            this.colOrderReceivedBy,
            this.columnHeader1,
            this.columnHeader2});
            this.lvwOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOrderList.FullRowSelect = true;
            this.lvwOrderList.GridLines = true;
            this.lvwOrderList.HideSelection = false;
            this.lvwOrderList.Location = new System.Drawing.Point(5, 103);
            this.lvwOrderList.MultiSelect = false;
            this.lvwOrderList.Name = "lvwOrderList";
            this.lvwOrderList.Size = new System.Drawing.Size(869, 465);
            this.lvwOrderList.TabIndex = 131;
            this.lvwOrderList.UseCompatibleStateImageBehavior = false;
            this.lvwOrderList.View = System.Windows.Forms.View.Details;
            // 
            // btPrintVAT
            // 
            this.btPrintVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrintVAT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btPrintVAT.Enabled = false;
            this.btPrintVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrintVAT.Location = new System.Drawing.Point(880, 300);
            this.btPrintVAT.Name = "btPrintVAT";
            this.btPrintVAT.Size = new System.Drawing.Size(112, 25);
            this.btPrintVAT.TabIndex = 162;
            this.btPrintVAT.Text = "Reprint Vatchallan";
            this.btPrintVAT.UseVisualStyleBackColor = true;
            this.btPrintVAT.Visible = false;
            this.btPrintVAT.Click += new System.EventHandler(this.btPrintVAT_Click);
            // 
            // btPrintInvoice
            // 
            this.btPrintInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrintInvoice.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btPrintInvoice.Enabled = false;
            this.btPrintInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrintInvoice.Location = new System.Drawing.Point(879, 269);
            this.btPrintInvoice.Name = "btPrintInvoice";
            this.btPrintInvoice.Size = new System.Drawing.Size(112, 25);
            this.btPrintInvoice.TabIndex = 163;
            this.btPrintInvoice.Text = "Reprint Invoice";
            this.btPrintInvoice.UseVisualStyleBackColor = true;
            this.btPrintInvoice.Click += new System.EventHandler(this.btPrintInvoice_Click);
            // 
            // btProcessDelivery
            // 
            this.btProcessDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btProcessDelivery.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btProcessDelivery.Enabled = false;
            this.btProcessDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btProcessDelivery.Location = new System.Drawing.Point(879, 165);
            this.btProcessDelivery.Name = "btProcessDelivery";
            this.btProcessDelivery.Size = new System.Drawing.Size(112, 25);
            this.btProcessDelivery.TabIndex = 164;
            this.btProcessDelivery.Text = "Process Delivery";
            this.btProcessDelivery.UseVisualStyleBackColor = true;
            this.btProcessDelivery.Click += new System.EventHandler(this.btProcessDelivery_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(45, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 166;
            this.label7.Text = "Order No :";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNo.Location = new System.Drawing.Point(107, 51);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(168, 20);
            this.txtOrderNo.TabIndex = 165;
            // 
            // btDeliveryNote
            // 
            this.btDeliveryNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDeliveryNote.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btDeliveryNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDeliveryNote.Location = new System.Drawing.Point(878, 238);
            this.btDeliveryNote.Name = "btDeliveryNote";
            this.btDeliveryNote.Size = new System.Drawing.Size(112, 25);
            this.btDeliveryNote.TabIndex = 167;
            this.btDeliveryNote.Text = "Reprint Delivery Note";
            this.btDeliveryNote.UseVisualStyleBackColor = true;
            this.btDeliveryNote.Click += new System.EventHandler(this.btDeliveryNote_Click);
            // 
            // btGetData
            // 
            this.btGetData.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGetData.Location = new System.Drawing.Point(469, 2);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(90, 23);
            this.btGetData.TabIndex = 168;
            this.btGetData.Text = "Get Data";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // btMakeInvoice
            // 
            this.btMakeInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btMakeInvoice.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btMakeInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMakeInvoice.Location = new System.Drawing.Point(880, 134);
            this.btMakeInvoice.Name = "btMakeInvoice";
            this.btMakeInvoice.Size = new System.Drawing.Size(112, 25);
            this.btMakeInvoice.TabIndex = 170;
            this.btMakeInvoice.Text = "Make Invoice";
            this.btMakeInvoice.UseVisualStyleBackColor = true;
            this.btMakeInvoice.Visible = false;
            this.btMakeInvoice.Click += new System.EventHandler(this.btMakeInvoice_Click);
            // 
            // btViewInvoice
            // 
            this.btViewInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btViewInvoice.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btViewInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btViewInvoice.Location = new System.Drawing.Point(878, 103);
            this.btViewInvoice.Name = "btViewInvoice";
            this.btViewInvoice.Size = new System.Drawing.Size(112, 25);
            this.btViewInvoice.TabIndex = 169;
            this.btViewInvoice.Text = "View Invoice";
            this.btViewInvoice.UseVisualStyleBackColor = true;
            this.btViewInvoice.Visible = false;
            this.btViewInvoice.Click += new System.EventHandler(this.btViewInvoice_Click);
            // 
            // btClaimInvoice
            // 
            this.btClaimInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClaimInvoice.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClaimInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClaimInvoice.Location = new System.Drawing.Point(879, 134);
            this.btClaimInvoice.Name = "btClaimInvoice";
            this.btClaimInvoice.Size = new System.Drawing.Size(112, 25);
            this.btClaimInvoice.TabIndex = 170;
            this.btClaimInvoice.Text = "Make Invoice";
            this.btClaimInvoice.UseVisualStyleBackColor = true;
            this.btClaimInvoice.Visible = false;
            this.btClaimInvoice.Click += new System.EventHandler(this.btClaimInvoice_Click);
            // 
            // btnBarcode
            // 
            this.btnBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBarcode.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarcode.Location = new System.Drawing.Point(880, 331);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(112, 25);
            this.btnBarcode.TabIndex = 171;
            this.btnBarcode.Text = "Barcode";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Visible = false;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // btnWarrantyCard
            // 
            this.btnWarrantyCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWarrantyCard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnWarrantyCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWarrantyCard.Location = new System.Drawing.Point(881, 390);
            this.btnWarrantyCard.Name = "btnWarrantyCard";
            this.btnWarrantyCard.Size = new System.Drawing.Size(112, 35);
            this.btnWarrantyCard.TabIndex = 172;
            this.btnWarrantyCard.Text = "Warranty Card Print (view)";
            this.btnWarrantyCard.UseVisualStyleBackColor = true;
            this.btnWarrantyCard.Visible = false;
            this.btnWarrantyCard.Click += new System.EventHandler(this.btnWarrantyCard_Click);
            // 
            // btnWarrantyCardAuto
            // 
            this.btnWarrantyCardAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWarrantyCardAuto.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnWarrantyCardAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWarrantyCardAuto.Location = new System.Drawing.Point(881, 431);
            this.btnWarrantyCardAuto.Name = "btnWarrantyCardAuto";
            this.btnWarrantyCardAuto.Size = new System.Drawing.Size(112, 35);
            this.btnWarrantyCardAuto.TabIndex = 173;
            this.btnWarrantyCardAuto.Text = "Warranty Card Print (Auto)";
            this.btnWarrantyCardAuto.UseVisualStyleBackColor = true;
            this.btnWarrantyCardAuto.Visible = false;
            this.btnWarrantyCardAuto.Click += new System.EventHandler(this.btnWarrantyCardAuto_Click);
            // 
            // btnCreditNote
            // 
            this.btnCreditNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreditNote.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCreditNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditNote.Location = new System.Drawing.Point(881, 472);
            this.btnCreditNote.Name = "btnCreditNote";
            this.btnCreditNote.Size = new System.Drawing.Size(112, 34);
            this.btnCreditNote.TabIndex = 174;
            this.btnCreditNote.Text = "Generate Credit Note and Print";
            this.btnCreditNote.UseVisualStyleBackColor = true;
            this.btnCreditNote.Visible = false;
            this.btnCreditNote.Click += new System.EventHandler(this.btnCreditNote_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Cornsilk;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(856, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 25);
            this.label14.TabIndex = 175;
            this.label14.Text = "Mushok 6.3";
            // 
            // btnReturnNote
            // 
            this.btnReturnNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturnNote.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReturnNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnNote.Location = new System.Drawing.Point(881, 512);
            this.btnReturnNote.Name = "btnReturnNote";
            this.btnReturnNote.Size = new System.Drawing.Size(112, 25);
            this.btnReturnNote.TabIndex = 176;
            this.btnReturnNote.Text = "Reverse Note Print";
            this.btnReturnNote.UseVisualStyleBackColor = true;
            this.btnReturnNote.Click += new System.EventHandler(this.btnReturnNote_Click);
            // 
            // btnPrintWarrantyCard
            // 
            this.btnPrintWarrantyCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintWarrantyCard.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrintWarrantyCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintWarrantyCard.Location = new System.Drawing.Point(880, 362);
            this.btnPrintWarrantyCard.Name = "btnPrintWarrantyCard";
            this.btnPrintWarrantyCard.Size = new System.Drawing.Size(112, 22);
            this.btnPrintWarrantyCard.TabIndex = 177;
            this.btnPrintWarrantyCard.Text = "Print Warranty Card ";
            this.btnPrintWarrantyCard.UseVisualStyleBackColor = true;
            this.btnPrintWarrantyCard.Click += new System.EventHandler(this.btnPrintWarrantyCard_Click);
            // 
            // frmDeliveryInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 594);
            this.Controls.Add(this.btnPrintWarrantyCard);
            this.Controls.Add(this.btnReturnNote);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnCreditNote);
            this.Controls.Add(this.btnWarrantyCardAuto);
            this.Controls.Add(this.btnWarrantyCard);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.btClaimInvoice);
            this.Controls.Add(this.btViewInvoice);
            this.Controls.Add(this.btMakeInvoice);
            this.Controls.Add(this.btPrintVAT);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.btPrintInvoice);
            this.Controls.Add(this.btProcessDelivery);
            this.Controls.Add(this.btDeliveryNote);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbInvoiceStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtCustomerCode);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.lvwOrderList);
            this.Name = "frmDeliveryInvoices";
            this.Text = "frmDeliveryInvoices";
            this.Load += new System.EventHandler(this.frmDeliveryInvoices_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDelivery;
        private System.Windows.Forms.ComboBox cmbInvoiceStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.ColumnHeader colOrderReceivedBy;
        private System.Windows.Forms.ColumnHeader colOrderDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colInvoiceAmount;
        private System.Windows.Forms.ColumnHeader colCustName;
        private System.Windows.Forms.ColumnHeader colOrderID;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.ListView lvwOrderList;
        private System.Windows.Forms.Button btPrintVAT;
        private System.Windows.Forms.Button btPrintInvoice;
        private System.Windows.Forms.Button btProcessDelivery;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Button btDeliveryNote;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.Button btMakeInvoice;
        private System.Windows.Forms.Button btViewInvoice;
        private System.Windows.Forms.Button btClaimInvoice;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Button btnWarrantyCard;
        private System.Windows.Forms.Button btnWarrantyCardAuto;
        private System.Windows.Forms.Button btnCreditNote;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnReturnNote;
        private System.Windows.Forms.Button btnPrintWarrantyCard;
    }
}