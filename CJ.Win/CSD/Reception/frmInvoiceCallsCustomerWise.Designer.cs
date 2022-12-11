namespace CJ.Win.CSD.Reception
{
    partial class frmInvoiceCallsCustomerWise
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceCallsCustomerWise));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dsvCustomerQuery = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMAGName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBrandDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductSerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuestioner = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMAGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblInvAmount = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblInvoiceDate = new System.Windows.Forms.Label();
            this.lblConsumerName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblShowroom = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoSwitchedOff = new System.Windows.Forms.RadioButton();
            this.rdoNumBusy = new System.Windows.Forms.RadioButton();
            this.rdoCallBack = new System.Windows.Forms.RadioButton();
            this.chkBanForever = new System.Windows.Forms.CheckBox();
            this.rdoNoResponse = new System.Windows.Forms.RadioButton();
            this.rdoSatisfy = new System.Windows.Forms.RadioButton();
            this.rdoDissatisfy = new System.Windows.Forms.RadioButton();
            this.rdoModerate = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblInstallationRequired = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblIsExchangeOffer = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lvwPayment = new System.Windows.Forms.ListView();
            this.colPaymentMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsEMI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNoOfInstallment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwDiscount = new System.Windows.Forms.ListView();
            this.colDiscountType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiscount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwCharge = new System.Windows.Forms.ListView();
            this.colChargeType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCharge = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvFreeQty = new System.Windows.Forms.ListView();
            this.colFreeProduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFreeQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsvCustomerQuery)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(753, 537);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(847, 537);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dsvCustomerQuery
            // 
            this.dsvCustomerQuery.AllowUserToAddRows = false;
            this.dsvCustomerQuery.AllowUserToDeleteRows = false;
            this.dsvCustomerQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dsvCustomerQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsvCustomerQuery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductName,
            this.txtMAGName,
            this.txtBrandDesc,
            this.txtProductSerialNo,
            this.txtMarks,
            this.btnQuestioner,
            this.txtProductID,
            this.txtMAGID});
            this.dsvCustomerQuery.Location = new System.Drawing.Point(12, 204);
            this.dsvCustomerQuery.Name = "dsvCustomerQuery";
            this.dsvCustomerQuery.Size = new System.Drawing.Size(928, 195);
            this.dsvCustomerQuery.TabIndex = 22;
            this.dsvCustomerQuery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dsvCustomerQuery_CellContentClick);
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            // 
            // txtProductName
            // 
            this.txtProductName.FillWeight = 180F;
            this.txtProductName.HeaderText = "Product Name";
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Width = 190;
            // 
            // txtMAGName
            // 
            this.txtMAGName.HeaderText = "MAG";
            this.txtMAGName.Name = "txtMAGName";
            this.txtMAGName.Width = 90;
            // 
            // txtBrandDesc
            // 
            this.txtBrandDesc.HeaderText = "Brand";
            this.txtBrandDesc.Name = "txtBrandDesc";
            // 
            // txtProductSerialNo
            // 
            this.txtProductSerialNo.HeaderText = "Barcode";
            this.txtProductSerialNo.Name = "txtProductSerialNo";
            this.txtProductSerialNo.Width = 110;
            // 
            // txtMarks
            // 
            this.txtMarks.HeaderText = "Marks";
            this.txtMarks.Name = "txtMarks";
            this.txtMarks.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtMarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txtMarks.Width = 250;
            // 
            // btnQuestioner
            // 
            this.btnQuestioner.HeaderText = "......";
            this.btnQuestioner.Name = "btnQuestioner";
            this.btnQuestioner.Text = "";
            this.btnQuestioner.Width = 45;
            // 
            // txtProductID
            // 
            this.txtProductID.HeaderText = "ProductID";
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Visible = false;
            // 
            // txtMAGID
            // 
            this.txtMAGID.HeaderText = "MAGID";
            this.txtMAGID.Name = "txtMAGID";
            this.txtMAGID.Visible = false;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(610, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 15);
            this.label14.TabIndex = 2;
            this.label14.Text = "Invoice Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Consumer Name";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(629, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mobile No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Invoice No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Invoice Amount:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(636, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Discount";
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.Location = new System.Drawing.Point(119, 10);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(13, 15);
            this.lblInvoiceNo.TabIndex = 1;
            this.lblInvoiceNo.Text = "?";
            // 
            // lblInvAmount
            // 
            this.lblInvAmount.AutoSize = true;
            this.lblInvAmount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvAmount.Location = new System.Drawing.Point(119, 37);
            this.lblInvAmount.Name = "lblInvAmount";
            this.lblInvAmount.Size = new System.Drawing.Size(13, 15);
            this.lblInvAmount.TabIndex = 5;
            this.lblInvAmount.Text = "?";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.Location = new System.Drawing.Point(700, 36);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(13, 15);
            this.lblDiscount.TabIndex = 7;
            this.lblDiscount.Text = "?";
            // 
            // lblInvoiceDate
            // 
            this.lblInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInvoiceDate.AutoSize = true;
            this.lblInvoiceDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceDate.Location = new System.Drawing.Point(700, 10);
            this.lblInvoiceDate.Name = "lblInvoiceDate";
            this.lblInvoiceDate.Size = new System.Drawing.Size(13, 15);
            this.lblInvoiceDate.TabIndex = 3;
            this.lblInvoiceDate.Text = "?";
            // 
            // lblConsumerName
            // 
            this.lblConsumerName.AutoSize = true;
            this.lblConsumerName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumerName.Location = new System.Drawing.Point(119, 89);
            this.lblConsumerName.Name = "lblConsumerName";
            this.lblConsumerName.Size = new System.Drawing.Size(13, 15);
            this.lblConsumerName.TabIndex = 13;
            this.lblConsumerName.Text = "?";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(119, 117);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(13, 15);
            this.lblAddress.TabIndex = 17;
            this.lblAddress.Text = "?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(59, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Address";
            // 
            // lblShowroom
            // 
            this.lblShowroom.AutoSize = true;
            this.lblShowroom.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowroom.Location = new System.Drawing.Point(119, 62);
            this.lblShowroom.Name = "lblShowroom";
            this.lblShowroom.Size = new System.Drawing.Size(13, 15);
            this.lblShowroom.TabIndex = 9;
            this.lblShowroom.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Showroom";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobileNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(704, 85);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(170, 23);
            this.txtMobileNo.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoSwitchedOff);
            this.groupBox1.Controls.Add(this.rdoNumBusy);
            this.groupBox1.Controls.Add(this.rdoCallBack);
            this.groupBox1.Controls.Add(this.chkBanForever);
            this.groupBox1.Controls.Add(this.rdoNoResponse);
            this.groupBox1.Controls.Add(this.rdoSatisfy);
            this.groupBox1.Controls.Add(this.rdoDissatisfy);
            this.groupBox1.Controls.Add(this.rdoModerate);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 50);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Happy Call Status";
            // 
            // rdoSwitchedOff
            // 
            this.rdoSwitchedOff.AutoSize = true;
            this.rdoSwitchedOff.Location = new System.Drawing.Point(550, 21);
            this.rdoSwitchedOff.Name = "rdoSwitchedOff";
            this.rdoSwitchedOff.Size = new System.Drawing.Size(100, 19);
            this.rdoSwitchedOff.TabIndex = 7;
            this.rdoSwitchedOff.Text = "Switched Off";
            this.rdoSwitchedOff.UseVisualStyleBackColor = true;
            // 
            // rdoNumBusy
            // 
            this.rdoNumBusy.AutoSize = true;
            this.rdoNumBusy.Location = new System.Drawing.Point(269, 22);
            this.rdoNumBusy.Name = "rdoNumBusy";
            this.rdoNumBusy.Size = new System.Drawing.Size(86, 19);
            this.rdoNumBusy.TabIndex = 3;
            this.rdoNumBusy.Text = "Num Busy";
            this.rdoNumBusy.UseVisualStyleBackColor = true;
            // 
            // rdoCallBack
            // 
            this.rdoCallBack.AutoSize = true;
            this.rdoCallBack.Location = new System.Drawing.Point(470, 22);
            this.rdoCallBack.Name = "rdoCallBack";
            this.rdoCallBack.Size = new System.Drawing.Size(74, 19);
            this.rdoCallBack.TabIndex = 5;
            this.rdoCallBack.Text = "CallBack";
            this.rdoCallBack.UseVisualStyleBackColor = true;
            this.rdoCallBack.CheckedChanged += new System.EventHandler(this.rdoCallBack_CheckedChanged);
            // 
            // chkBanForever
            // 
            this.chkBanForever.AutoSize = true;
            this.chkBanForever.Location = new System.Drawing.Point(656, 21);
            this.chkBanForever.Name = "chkBanForever";
            this.chkBanForever.Size = new System.Drawing.Size(100, 19);
            this.chkBanForever.TabIndex = 6;
            this.chkBanForever.Text = "Ban Forever ";
            this.chkBanForever.UseVisualStyleBackColor = true;
            // 
            // rdoNoResponse
            // 
            this.rdoNoResponse.AutoSize = true;
            this.rdoNoResponse.Location = new System.Drawing.Point(363, 22);
            this.rdoNoResponse.Name = "rdoNoResponse";
            this.rdoNoResponse.Size = new System.Drawing.Size(104, 19);
            this.rdoNoResponse.TabIndex = 4;
            this.rdoNoResponse.Text = "No Response";
            this.rdoNoResponse.UseVisualStyleBackColor = true;
            this.rdoNoResponse.CheckedChanged += new System.EventHandler(this.rdoNoResponse_CheckedChanged);
            // 
            // rdoSatisfy
            // 
            this.rdoSatisfy.AutoSize = true;
            this.rdoSatisfy.Checked = true;
            this.rdoSatisfy.Location = new System.Drawing.Point(7, 22);
            this.rdoSatisfy.Name = "rdoSatisfy";
            this.rdoSatisfy.Size = new System.Drawing.Size(64, 19);
            this.rdoSatisfy.TabIndex = 0;
            this.rdoSatisfy.TabStop = true;
            this.rdoSatisfy.Text = "Satisfy";
            this.rdoSatisfy.UseVisualStyleBackColor = true;
            // 
            // rdoDissatisfy
            // 
            this.rdoDissatisfy.AutoSize = true;
            this.rdoDissatisfy.Location = new System.Drawing.Point(179, 22);
            this.rdoDissatisfy.Name = "rdoDissatisfy";
            this.rdoDissatisfy.Size = new System.Drawing.Size(81, 19);
            this.rdoDissatisfy.TabIndex = 2;
            this.rdoDissatisfy.Text = "Dissatisfy";
            this.rdoDissatisfy.UseVisualStyleBackColor = true;
            // 
            // rdoModerate
            // 
            this.rdoModerate.AutoSize = true;
            this.rdoModerate.Location = new System.Drawing.Point(82, 22);
            this.rdoModerate.Name = "rdoModerate";
            this.rdoModerate.Size = new System.Drawing.Size(84, 19);
            this.rdoModerate.TabIndex = 1;
            this.rdoModerate.Text = "Moderate";
            this.rdoModerate.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 596);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Remarks ";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(69, 592);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(866, 21);
            this.txtRemarks.TabIndex = 26;
            // 
            // lblInstallationRequired
            // 
            this.lblInstallationRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstallationRequired.AutoSize = true;
            this.lblInstallationRequired.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstallationRequired.Location = new System.Drawing.Point(700, 62);
            this.lblInstallationRequired.Name = "lblInstallationRequired";
            this.lblInstallationRequired.Size = new System.Drawing.Size(13, 15);
            this.lblInstallationRequired.TabIndex = 11;
            this.lblInstallationRequired.Text = "?";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(573, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Installation Required";
            // 
            // lblIsExchangeOffer
            // 
            this.lblIsExchangeOffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIsExchangeOffer.AutoSize = true;
            this.lblIsExchangeOffer.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsExchangeOffer.Location = new System.Drawing.Point(700, 117);
            this.lblIsExchangeOffer.Name = "lblIsExchangeOffer";
            this.lblIsExchangeOffer.Size = new System.Drawing.Size(13, 15);
            this.lblIsExchangeOffer.TabIndex = 19;
            this.lblIsExchangeOffer.Text = "?";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(589, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "IsExchange Offer";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 402);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "Free Item";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 186);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "Invoice Item";
            // 
            // lvwPayment
            // 
            this.lvwPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPayment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPaymentMode,
            this.colAmount,
            this.colIsEMI,
            this.colNoOfInstallment});
            this.lvwPayment.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwPayment.FullRowSelect = true;
            this.lvwPayment.GridLines = true;
            this.lvwPayment.HideSelection = false;
            this.lvwPayment.Location = new System.Drawing.Point(250, 423);
            this.lvwPayment.MultiSelect = false;
            this.lvwPayment.Name = "lvwPayment";
            this.lvwPayment.Size = new System.Drawing.Size(271, 107);
            this.lvwPayment.TabIndex = 29;
            this.lvwPayment.UseCompatibleStateImageBehavior = false;
            this.lvwPayment.View = System.Windows.Forms.View.Details;
            // 
            // colPaymentMode
            // 
            this.colPaymentMode.Text = "Payment Mode";
            this.colPaymentMode.Width = 101;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 57;
            // 
            // colIsEMI
            // 
            this.colIsEMI.Text = "Is EMI";
            this.colIsEMI.Width = 48;
            // 
            // colNoOfInstallment
            // 
            this.colNoOfInstallment.Text = "# of Installment";
            // 
            // lvwDiscount
            // 
            this.lvwDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDiscount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDiscountType,
            this.colDiscount});
            this.lvwDiscount.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwDiscount.FullRowSelect = true;
            this.lvwDiscount.GridLines = true;
            this.lvwDiscount.HideSelection = false;
            this.lvwDiscount.Location = new System.Drawing.Point(527, 423);
            this.lvwDiscount.MultiSelect = false;
            this.lvwDiscount.Name = "lvwDiscount";
            this.lvwDiscount.Size = new System.Drawing.Size(200, 107);
            this.lvwDiscount.TabIndex = 30;
            this.lvwDiscount.UseCompatibleStateImageBehavior = false;
            this.lvwDiscount.View = System.Windows.Forms.View.Details;
            // 
            // colDiscountType
            // 
            this.colDiscountType.Text = "Discount Type";
            this.colDiscountType.Width = 112;
            // 
            // colDiscount
            // 
            this.colDiscount.Text = "Discount";
            this.colDiscount.Width = 68;
            // 
            // lvwCharge
            // 
            this.lvwCharge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCharge.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChargeType,
            this.colCharge});
            this.lvwCharge.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCharge.FullRowSelect = true;
            this.lvwCharge.GridLines = true;
            this.lvwCharge.HideSelection = false;
            this.lvwCharge.Location = new System.Drawing.Point(735, 423);
            this.lvwCharge.MultiSelect = false;
            this.lvwCharge.Name = "lvwCharge";
            this.lvwCharge.Size = new System.Drawing.Size(200, 107);
            this.lvwCharge.TabIndex = 31;
            this.lvwCharge.UseCompatibleStateImageBehavior = false;
            this.lvwCharge.View = System.Windows.Forms.View.Details;
            // 
            // colChargeType
            // 
            this.colChargeType.Text = "Charge Type";
            this.colChargeType.Width = 111;
            // 
            // colCharge
            // 
            this.colCharge.Text = "Charge";
            this.colCharge.Width = 68;
            // 
            // dgvFreeQty
            // 
            this.dgvFreeQty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFreeQty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFreeProduct,
            this.colFreeQty});
            this.dgvFreeQty.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFreeQty.FullRowSelect = true;
            this.dgvFreeQty.GridLines = true;
            this.dgvFreeQty.HideSelection = false;
            this.dgvFreeQty.Location = new System.Drawing.Point(7, 423);
            this.dgvFreeQty.MultiSelect = false;
            this.dgvFreeQty.Name = "dgvFreeQty";
            this.dgvFreeQty.Size = new System.Drawing.Size(237, 107);
            this.dgvFreeQty.TabIndex = 32;
            this.dgvFreeQty.UseCompatibleStateImageBehavior = false;
            this.dgvFreeQty.View = System.Windows.Forms.View.Details;
            // 
            // colFreeProduct
            // 
            this.colFreeProduct.Text = "Free Product";
            this.colFreeProduct.Width = 169;
            // 
            // colFreeQty
            // 
            this.colFreeQty.Text = "Free Qty";
            this.colFreeQty.Width = 68;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(247, 402);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 15);
            this.label13.TabIndex = 33;
            this.label13.Text = "Payment Detail";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(524, 402);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 15);
            this.label15.TabIndex = 34;
            this.label15.Text = "Discount Detail";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(732, 402);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(87, 15);
            this.label16.TabIndex = 35;
            this.label16.Text = "Charge Detail";
            // 
            // frmInvoiceCallsCustomerWise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 576);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dgvFreeQty);
            this.Controls.Add(this.lvwCharge);
            this.Controls.Add(this.lvwDiscount);
            this.Controls.Add(this.lvwPayment);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblIsExchangeOffer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblInstallationRequired);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.lblShowroom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblConsumerName);
            this.Controls.Add(this.lblInvoiceDate);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblInvAmount);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dsvCustomerQuery);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInvoiceCallsCustomerWise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Satisfaction (By Invoice)";
            this.Load += new System.EventHandler(this.frmInvoiceCallsCustomerWise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsvCustomerQuery)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dsvCustomerQuery;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblInvAmount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblInvoiceDate;
        private System.Windows.Forms.Label lblConsumerName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblShowroom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBanForever;
        private System.Windows.Forms.RadioButton rdoNoResponse;
        private System.Windows.Forms.RadioButton rdoSatisfy;
        private System.Windows.Forms.RadioButton rdoDissatisfy;
        private System.Windows.Forms.RadioButton rdoModerate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblInstallationRequired;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdoCallBack;
        private System.Windows.Forms.RadioButton rdoNumBusy;
        private System.Windows.Forms.Label lblIsExchangeOffer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMAGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductID;
        private System.Windows.Forms.DataGridViewButtonColumn btnQuestioner;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductSerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBrandDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtMAGName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.RadioButton rdoSwitchedOff;
        private System.Windows.Forms.ListView lvwPayment;
        private System.Windows.Forms.ColumnHeader colPaymentMode;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colIsEMI;
        private System.Windows.Forms.ColumnHeader colNoOfInstallment;
        private System.Windows.Forms.ListView lvwDiscount;
        private System.Windows.Forms.ColumnHeader colDiscountType;
        private System.Windows.Forms.ColumnHeader colDiscount;
        private System.Windows.Forms.ListView lvwCharge;
        private System.Windows.Forms.ColumnHeader colChargeType;
        private System.Windows.Forms.ColumnHeader colCharge;
        private System.Windows.Forms.ColumnHeader colFreeProduct;
        private System.Windows.Forms.ColumnHeader colFreeQty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListView dgvFreeQty;
    }
}