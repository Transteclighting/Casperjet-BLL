namespace CJ.Win.EPS
{
    partial class frmEPSCollection
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.lvwItemList = new System.Windows.Forms.ListView();
            this.colInvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInstallmentNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmountRce = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInterestRec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsDue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsPartial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbxInstrument = new System.Windows.Forms.GroupBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCAmount = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CheckInsStatus = new System.Windows.Forms.CheckBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtInsNo = new System.Windows.Forms.TextBox();
            this.dtInsdate = new System.Windows.Forms.DateTimePicker();
            this.cmbBranch = new System.Windows.Forms.ComboBox();
            this.cmbBank = new System.Windows.Forms.ComboBox();
            this.cmbInstrumentType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblInsDate = new System.Windows.Forms.Label();
            this.lblInsNo = new System.Windows.Forms.Label();
            this.lblInsType = new System.Windows.Forms.Label();
            this.dtTranDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btSelectAll = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.ColGInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGInstallmentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReceivablePrincipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReceivableInterest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGIsDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrincipalReceive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInterestReceive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkIsAdjustment = new System.Windows.Forms.CheckBox();
            this.lblPartial = new System.Windows.Forms.Label();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.btnGetTotal = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gbxInstrument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 81;
            this.label1.Text = "Company";
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(408, 32);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(79, 23);
            this.btnShow.TabIndex = 80;
            this.btnShow.Text = "Get Data";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lvwItemList
            // 
            this.lvwItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItemList.CheckBoxes = true;
            this.lvwItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInvoiceNo,
            this.colCustomerName,
            this.colInstallmentNo,
            this.colAmountRce,
            this.colInterestRec,
            this.colIsDue,
            this.colIsPartial});
            this.lvwItemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwItemList.FullRowSelect = true;
            this.lvwItemList.GridLines = true;
            this.lvwItemList.HideSelection = false;
            this.lvwItemList.Location = new System.Drawing.Point(4, 267);
            this.lvwItemList.MultiSelect = false;
            this.lvwItemList.Name = "lvwItemList";
            this.lvwItemList.Size = new System.Drawing.Size(772, 222);
            this.lvwItemList.TabIndex = 83;
            this.lvwItemList.UseCompatibleStateImageBehavior = false;
            this.lvwItemList.View = System.Windows.Forms.View.Details;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No.";
            this.colInvoiceNo.Width = 115;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Employee Name";
            this.colCustomerName.Width = 150;
            // 
            // colInstallmentNo
            // 
            this.colInstallmentNo.Text = "Installment No";
            this.colInstallmentNo.Width = 100;
            // 
            // colAmountRce
            // 
            this.colAmountRce.Text = "Amount Received";
            this.colAmountRce.Width = 120;
            // 
            // colInterestRec
            // 
            this.colInterestRec.Text = "Interest Received";
            this.colInterestRec.Width = 120;
            // 
            // colIsDue
            // 
            this.colIsDue.Text = "Is Due";
            // 
            // colIsPartial
            // 
            this.colIsPartial.Text = "IsPartial";
            // 
            // gbxInstrument
            // 
            this.gbxInstrument.Controls.Add(this.txtRemarks);
            this.gbxInstrument.Controls.Add(this.label3);
            this.gbxInstrument.Controls.Add(this.txtCAmount);
            this.gbxInstrument.Controls.Add(this.txtAmount);
            this.gbxInstrument.Controls.Add(this.txtBranchName);
            this.gbxInstrument.Controls.Add(this.label5);
            this.gbxInstrument.Controls.Add(this.CheckInsStatus);
            this.gbxInstrument.Controls.Add(this.lblAmount);
            this.gbxInstrument.Controls.Add(this.txtInsNo);
            this.gbxInstrument.Controls.Add(this.dtInsdate);
            this.gbxInstrument.Controls.Add(this.cmbBranch);
            this.gbxInstrument.Controls.Add(this.cmbBank);
            this.gbxInstrument.Controls.Add(this.cmbInstrumentType);
            this.gbxInstrument.Controls.Add(this.label11);
            this.gbxInstrument.Controls.Add(this.label10);
            this.gbxInstrument.Controls.Add(this.lblInsDate);
            this.gbxInstrument.Controls.Add(this.lblInsNo);
            this.gbxInstrument.Controls.Add(this.lblInsType);
            this.gbxInstrument.ForeColor = System.Drawing.Color.Black;
            this.gbxInstrument.Location = new System.Drawing.Point(7, 60);
            this.gbxInstrument.Name = "gbxInstrument";
            this.gbxInstrument.Size = new System.Drawing.Size(484, 171);
            this.gbxInstrument.TabIndex = 84;
            this.gbxInstrument.TabStop = false;
            this.gbxInstrument.Text = "Instrument";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(52, 146);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(385, 20);
            this.txtRemarks.TabIndex = 94;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "Remarks";
            // 
            // txtCAmount
            // 
            this.txtCAmount.Location = new System.Drawing.Point(279, 20);
            this.txtCAmount.Name = "txtCAmount";
            this.txtCAmount.Size = new System.Drawing.Size(133, 20);
            this.txtCAmount.TabIndex = 92;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(54, 19);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(133, 20);
            this.txtAmount.TabIndex = 91;
            // 
            // txtBranchName
            // 
            this.txtBranchName.Location = new System.Drawing.Point(279, 98);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(158, 20);
            this.txtBranchName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 90;
            this.label5.Text = "Confirm Amount";
            // 
            // CheckInsStatus
            // 
            this.CheckInsStatus.AutoSize = true;
            this.CheckInsStatus.Location = new System.Drawing.Point(55, 127);
            this.CheckInsStatus.Name = "CheckInsStatus";
            this.CheckInsStatus.Size = new System.Drawing.Size(72, 17);
            this.CheckInsStatus.TabIndex = 6;
            this.CheckInsStatus.Text = "Approved";
            this.CheckInsStatus.UseVisualStyleBackColor = true;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(8, 22);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 89;
            this.lblAmount.Text = "Amount";
            // 
            // txtInsNo
            // 
            this.txtInsNo.Location = new System.Drawing.Point(279, 48);
            this.txtInsNo.Name = "txtInsNo";
            this.txtInsNo.Size = new System.Drawing.Size(158, 20);
            this.txtInsNo.TabIndex = 1;
            // 
            // dtInsdate
            // 
            this.dtInsdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInsdate.Location = new System.Drawing.Point(53, 101);
            this.dtInsdate.Name = "dtInsdate";
            this.dtInsdate.Size = new System.Drawing.Size(171, 20);
            this.dtInsdate.TabIndex = 4;
            // 
            // cmbBranch
            // 
            this.cmbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranch.FormattingEnabled = true;
            this.cmbBranch.Location = new System.Drawing.Point(279, 73);
            this.cmbBranch.Name = "cmbBranch";
            this.cmbBranch.Size = new System.Drawing.Size(158, 21);
            this.cmbBranch.TabIndex = 3;
            // 
            // cmbBank
            // 
            this.cmbBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBank.FormattingEnabled = true;
            this.cmbBank.Location = new System.Drawing.Point(54, 75);
            this.cmbBank.Name = "cmbBank";
            this.cmbBank.Size = new System.Drawing.Size(171, 21);
            this.cmbBank.TabIndex = 2;
            this.cmbBank.SelectedIndexChanged += new System.EventHandler(this.cmbBank_SelectedIndexChanged);
            // 
            // cmbInstrumentType
            // 
            this.cmbInstrumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrumentType.FormattingEnabled = true;
            this.cmbInstrumentType.Location = new System.Drawing.Point(54, 48);
            this.cmbInstrumentType.Name = "cmbInstrumentType";
            this.cmbInstrumentType.Size = new System.Drawing.Size(171, 21);
            this.cmbInstrumentType.TabIndex = 0;
            this.cmbInstrumentType.SelectedIndexChanged += new System.EventHandler(this.cmbInstrumentType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(235, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Branch";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 79);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Bank";
            // 
            // lblInsDate
            // 
            this.lblInsDate.AutoSize = true;
            this.lblInsDate.Location = new System.Drawing.Point(22, 105);
            this.lblInsDate.Name = "lblInsDate";
            this.lblInsDate.Size = new System.Drawing.Size(30, 13);
            this.lblInsDate.TabIndex = 2;
            this.lblInsDate.Text = "Date";
            // 
            // lblInsNo
            // 
            this.lblInsNo.AutoSize = true;
            this.lblInsNo.Location = new System.Drawing.Point(252, 53);
            this.lblInsNo.Name = "lblInsNo";
            this.lblInsNo.Size = new System.Drawing.Size(24, 13);
            this.lblInsNo.TabIndex = 1;
            this.lblInsNo.Text = "No.";
            // 
            // lblInsType
            // 
            this.lblInsType.AutoSize = true;
            this.lblInsType.Location = new System.Drawing.Point(20, 51);
            this.lblInsType.Name = "lblInsType";
            this.lblInsType.Size = new System.Drawing.Size(31, 13);
            this.lblInsType.TabIndex = 0;
            this.lblInsType.Text = "Type";
            // 
            // dtTranDate
            // 
            this.dtTranDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTranDate.Location = new System.Drawing.Point(61, 238);
            this.dtTranDate.Name = "dtTranDate";
            this.dtTranDate.Size = new System.Drawing.Size(132, 20);
            this.dtTranDate.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tran Date";
            // 
            // btSelectAll
            // 
            this.btSelectAll.Location = new System.Drawing.Point(317, 237);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btSelectAll.TabIndex = 85;
            this.btSelectAll.Text = "Select All";
            this.btSelectAll.UseVisualStyleBackColor = true;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(415, 237);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 86;
            this.btOk.Text = "Submit";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(211, 37);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 90;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(21, 37);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 89;
            this.lblDate.Text = "From";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(237, 33);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(144, 20);
            this.dtToDate.TabIndex = 88;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(59, 33);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(144, 20);
            this.dtFromDate.TabIndex = 87;
            // 
            // dgvItemList
            // 
            this.dgvItemList.AllowUserToAddRows = false;
            this.dgvItemList.AllowUserToDeleteRows = false;
            this.dgvItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColGInvoiceNo,
            this.ColGEmployeeName,
            this.ColGInstallmentNo,
            this.ColReceivablePrincipal,
            this.ColReceivableInterest,
            this.ColGIsDue,
            this.ColPrincipalReceive,
            this.ColInterestReceive});
            this.dgvItemList.Location = new System.Drawing.Point(4, 276);
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.Size = new System.Drawing.Size(772, 213);
            this.dgvItemList.TabIndex = 91;
            // 
            // ColGInvoiceNo
            // 
            this.ColGInvoiceNo.HeaderText = "Invoice No";
            this.ColGInvoiceNo.Name = "ColGInvoiceNo";
            this.ColGInvoiceNo.ReadOnly = true;
            // 
            // ColGEmployeeName
            // 
            this.ColGEmployeeName.HeaderText = "Employee Name";
            this.ColGEmployeeName.Name = "ColGEmployeeName";
            this.ColGEmployeeName.ReadOnly = true;
            this.ColGEmployeeName.Width = 220;
            // 
            // ColGInstallmentNo
            // 
            this.ColGInstallmentNo.HeaderText = "Installment No";
            this.ColGInstallmentNo.Name = "ColGInstallmentNo";
            this.ColGInstallmentNo.ReadOnly = true;
            this.ColGInstallmentNo.Width = 60;
            // 
            // ColReceivablePrincipal
            // 
            this.ColReceivablePrincipal.HeaderText = "Receivable Principal";
            this.ColReceivablePrincipal.Name = "ColReceivablePrincipal";
            this.ColReceivablePrincipal.ReadOnly = true;
            this.ColReceivablePrincipal.Width = 75;
            // 
            // ColReceivableInterest
            // 
            this.ColReceivableInterest.HeaderText = "Receivable Interest";
            this.ColReceivableInterest.Name = "ColReceivableInterest";
            this.ColReceivableInterest.ReadOnly = true;
            this.ColReceivableInterest.Width = 75;
            // 
            // ColGIsDue
            // 
            this.ColGIsDue.HeaderText = "Is Due";
            this.ColGIsDue.Name = "ColGIsDue";
            this.ColGIsDue.ReadOnly = true;
            this.ColGIsDue.Width = 50;
            // 
            // ColPrincipalReceive
            // 
            this.ColPrincipalReceive.HeaderText = "Principal Receive";
            this.ColPrincipalReceive.Name = "ColPrincipalReceive";
            this.ColPrincipalReceive.Width = 75;
            // 
            // ColInterestReceive
            // 
            this.ColInterestReceive.HeaderText = "Interest Receive";
            this.ColInterestReceive.Name = "ColInterestReceive";
            this.ColInterestReceive.Width = 75;
            // 
            // chkIsAdjustment
            // 
            this.chkIsAdjustment.AutoSize = true;
            this.chkIsAdjustment.Location = new System.Drawing.Point(211, 241);
            this.chkIsAdjustment.Name = "chkIsAdjustment";
            this.chkIsAdjustment.Size = new System.Drawing.Size(89, 17);
            this.chkIsAdjustment.TabIndex = 95;
            this.chkIsAdjustment.Text = "Is Adjustment";
            this.chkIsAdjustment.UseVisualStyleBackColor = true;
            // 
            // lblPartial
            // 
            this.lblPartial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPartial.AutoSize = true;
            this.lblPartial.BackColor = System.Drawing.Color.BurlyWood;
            this.lblPartial.Location = new System.Drawing.Point(5, 492);
            this.lblPartial.Name = "lblPartial";
            this.lblPartial.Size = new System.Drawing.Size(36, 13);
            this.lblPartial.TabIndex = 95;
            this.lblPartial.Text = "Partial";
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(59, 8);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(437, 25);
            this.ctlCustomer1.TabIndex = 82;
            // 
            // btnGetTotal
            // 
            this.btnGetTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetTotal.Location = new System.Drawing.Point(550, 235);
            this.btnGetTotal.Name = "btnGetTotal";
            this.btnGetTotal.Size = new System.Drawing.Size(79, 23);
            this.btnGetTotal.TabIndex = 96;
            this.btnGetTotal.Text = "Get Total";
            this.btnGetTotal.UseVisualStyleBackColor = true;
            this.btnGetTotal.Click += new System.EventHandler(this.btnGetTotal_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(635, 238);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(26, 17);
            this.lblTotal.TabIndex = 97;
            this.lblTotal.Text = "??";
            // 
            // frmEPSCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 510);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnGetTotal);
            this.Controls.Add(this.lblPartial);
            this.Controls.Add(this.chkIsAdjustment);
            this.Controls.Add(this.dgvItemList);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btSelectAll);
            this.Controls.Add(this.dtTranDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbxInstrument);
            this.Controls.Add(this.lvwItemList);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShow);
            this.Name = "frmEPSCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPS Collection";
            this.Load += new System.EventHandler(this.frmEPSCollection_Load);
            this.gbxInstrument.ResumeLayout(false);
            this.gbxInstrument.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ListView lvwItemList;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colInstallmentNo;
        private System.Windows.Forms.ColumnHeader colAmountRce;
        private System.Windows.Forms.ColumnHeader colInterestRec;
        private System.Windows.Forms.GroupBox gbxInstrument;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.CheckBox CheckInsStatus;
        private System.Windows.Forms.TextBox txtInsNo;
        private System.Windows.Forms.DateTimePicker dtInsdate;
        private System.Windows.Forms.ComboBox cmbBranch;
        private System.Windows.Forms.ComboBox cmbBank;
        private System.Windows.Forms.ComboBox cmbInstrumentType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblInsDate;
        private System.Windows.Forms.Label lblInsNo;
        private System.Windows.Forms.Label lblInsType;
        private System.Windows.Forms.DateTimePicker dtTranDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSelectAll;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.TextBox txtCAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ColumnHeader colIsDue;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGInstallmentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReceivablePrincipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReceivableInterest;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGIsDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrincipalReceive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInterestReceive;
        private System.Windows.Forms.CheckBox chkIsAdjustment;
        private System.Windows.Forms.Label lblPartial;
        private System.Windows.Forms.ColumnHeader colIsPartial;
        private System.Windows.Forms.Button btnGetTotal;
        private System.Windows.Forms.Label lblTotal;
    }
}