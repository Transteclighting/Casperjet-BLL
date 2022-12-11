namespace CJ.Win.CAC
{
    partial class frmCACQuotation
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
            this.rdoNewCustomer = new System.Windows.Forms.RadioButton();
            this.rdoOldCustomer = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.dgvCACQuotation = new System.Windows.Forms.DataGridView();
            this.BrandID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.txtTelephoneNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rdoNonExisting = new System.Windows.Forms.RadioButton();
            this.txtAmountValue = new System.Windows.Forms.TextBox();
            this.rdoExisting = new System.Windows.Forms.RadioButton();
            this.txtAmount = new System.Windows.Forms.Label();
            this.txtTonValue = new System.Windows.Forms.TextBox();
            this.txtTon = new System.Windows.Forms.Label();
            this.txtQtyValue = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMag = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.lblPoAmount = new System.Windows.Forms.Label();
            this.txtPOAmount = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCACQuotation)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoNewCustomer
            // 
            this.rdoNewCustomer.AutoSize = true;
            this.rdoNewCustomer.Checked = true;
            this.rdoNewCustomer.Location = new System.Drawing.Point(118, 41);
            this.rdoNewCustomer.Name = "rdoNewCustomer";
            this.rdoNewCustomer.Size = new System.Drawing.Size(97, 17);
            this.rdoNewCustomer.TabIndex = 51;
            this.rdoNewCustomer.TabStop = true;
            this.rdoNewCustomer.Text = "New Customer ";
            this.rdoNewCustomer.UseVisualStyleBackColor = true;
            this.rdoNewCustomer.CheckedChanged += new System.EventHandler(this.rdoNewCustomer_CheckedChanged);
            // 
            // rdoOldCustomer
            // 
            this.rdoOldCustomer.AutoSize = true;
            this.rdoOldCustomer.Location = new System.Drawing.Point(219, 41);
            this.rdoOldCustomer.Name = "rdoOldCustomer";
            this.rdoOldCustomer.Size = new System.Drawing.Size(91, 17);
            this.rdoOldCustomer.TabIndex = 52;
            this.rdoOldCustomer.Text = "Old Customer ";
            this.rdoOldCustomer.UseVisualStyleBackColor = true;
            this.rdoOldCustomer.CheckedChanged += new System.EventHandler(this.rdoOldCustomer_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Choose :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Customer";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(63, 62);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(449, 20);
            this.txtCustomer.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Mobile";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(63, 127);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(119, 20);
            this.txtPhone.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(63, 85);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(451, 39);
            this.txtAddress.TabIndex = 58;
            // 
            // dgvCACQuotation
            // 
            this.dgvCACQuotation.AllowUserToAddRows = false;
            this.dgvCACQuotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCACQuotation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BrandID,
            this.MAGID,
            this.Brand,
            this.MAG,
            this.Model,
            this.Qty,
            this.Ton,
            this.Amount});
            this.dgvCACQuotation.Location = new System.Drawing.Point(12, 306);
            this.dgvCACQuotation.Name = "dgvCACQuotation";
            this.dgvCACQuotation.Size = new System.Drawing.Size(610, 112);
            this.dgvCACQuotation.TabIndex = 61;
            this.dgvCACQuotation.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCACQuotation_CellValueChanged);
            this.dgvCACQuotation.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvCACQuotation_RowsRemoved);
            // 
            // BrandID
            // 
            this.BrandID.HeaderText = "BrandID";
            this.BrandID.Name = "BrandID";
            this.BrandID.ReadOnly = true;
            this.BrandID.Visible = false;
            this.BrandID.Width = 60;
            // 
            // MAGID
            // 
            this.MAGID.HeaderText = "MAGID";
            this.MAGID.Name = "MAGID";
            this.MAGID.ReadOnly = true;
            this.MAGID.Visible = false;
            this.MAGID.Width = 60;
            // 
            // Brand
            // 
            this.Brand.HeaderText = "Brand";
            this.Brand.Name = "Brand";
            this.Brand.Width = 150;
            // 
            // MAG
            // 
            this.MAG.HeaderText = "MAG";
            this.MAG.Name = "MAG";
            // 
            // Model
            // 
            this.Model.HeaderText = "Model";
            this.Model.Name = "Model";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.Width = 60;
            // 
            // Ton
            // 
            this.Ton.HeaderText = "Ton";
            this.Ton.Name = "Ton";
            this.Ton.Width = 60;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 472);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(89, 468);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(533, 20);
            this.txtRemarks.TabIndex = 63;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(467, 491);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 64;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(547, 491);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 65;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Date:";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new System.Drawing.Point(407, 426);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(70, 13);
            this.lblTotalAmount.TabIndex = 68;
            this.lblTotalAmount.Text = "Total Amount";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(486, 422);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(136, 20);
            this.txtTotalAmount.TabIndex = 69;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(353, 39);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(112, 20);
            this.dtDate.TabIndex = 70;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ctlEmployee1);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtReferenceNo);
            this.groupBox3.Controls.Add(this.txtTelephoneNo);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dtDate);
            this.groupBox3.Controls.Add(this.rdoNewCustomer);
            this.groupBox3.Controls.Add(this.rdoOldCustomer);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtCustomer);
            this.groupBox3.Controls.Add(this.txtAddress);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtPhone);
            this.groupBox3.Controls.Add(this.ctlCustomer1);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 153);
            this.groupBox3.TabIndex = 71;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Basic Info";
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(8, 14);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(514, 25);
            this.ctlEmployee1.TabIndex = 80;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(28, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 79;
            this.label13.Text = "Employee Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 78;
            this.label8.Text = "Ref. No.";
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Location = new System.Drawing.Point(398, 127);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(116, 20);
            this.txtReferenceNo.TabIndex = 77;
            // 
            // txtTelephoneNo
            // 
            this.txtTelephoneNo.Location = new System.Drawing.Point(228, 127);
            this.txtTelephoneNo.Name = "txtTelephoneNo";
            this.txtTelephoneNo.Size = new System.Drawing.Size(119, 20);
            this.txtTelephoneNo.TabIndex = 72;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(186, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 71;
            this.label11.Text = "Phone";
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(63, 62);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(449, 25);
            this.ctlCustomer1.TabIndex = 55;
            this.ctlCustomer1.ChangeSelection += new System.EventHandler(this.ctlCustomer1_ChangeSelection);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctlProduct1);
            this.groupBox1.Controls.Add(this.lblProduct);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.rdoNonExisting);
            this.groupBox1.Controls.Add(this.txtAmountValue);
            this.groupBox1.Controls.Add(this.rdoExisting);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtTonValue);
            this.groupBox1.Controls.Add(this.txtTon);
            this.groupBox1.Controls.Add(this.txtQtyValue);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbMag);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbBrand);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(15, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 129);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detail Info";
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(81, 29);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(395, 25);
            this.ctlProduct1.TabIndex = 147;
            this.ctlProduct1.ChangeSelection += new System.EventHandler(this.ctlProduct1_ChangeSelection);
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(6, 32);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(75, 13);
            this.lblProduct.TabIndex = 73;
            this.lblProduct.Text = "Product Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(78, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 75;
            this.label10.Text = "Choose";
            // 
            // rdoNonExisting
            // 
            this.rdoNonExisting.AutoSize = true;
            this.rdoNonExisting.Location = new System.Drawing.Point(127, 11);
            this.rdoNonExisting.Name = "rdoNonExisting";
            this.rdoNonExisting.Size = new System.Drawing.Size(84, 17);
            this.rdoNonExisting.TabIndex = 73;
            this.rdoNonExisting.Text = "Non Existing";
            this.rdoNonExisting.UseVisualStyleBackColor = true;
            this.rdoNonExisting.CheckedChanged += new System.EventHandler(this.rdoNonExisting_CheckedChanged);
            // 
            // txtAmountValue
            // 
            this.txtAmountValue.Location = new System.Drawing.Point(285, 103);
            this.txtAmountValue.Name = "txtAmountValue";
            this.txtAmountValue.Size = new System.Drawing.Size(191, 20);
            this.txtAmountValue.TabIndex = 71;
            // 
            // rdoExisting
            // 
            this.rdoExisting.AutoSize = true;
            this.rdoExisting.Checked = true;
            this.rdoExisting.Location = new System.Drawing.Point(214, 11);
            this.rdoExisting.Name = "rdoExisting";
            this.rdoExisting.Size = new System.Drawing.Size(61, 17);
            this.rdoExisting.TabIndex = 74;
            this.rdoExisting.TabStop = true;
            this.rdoExisting.Text = "Existing";
            this.rdoExisting.UseVisualStyleBackColor = true;
            this.rdoExisting.CheckedChanged += new System.EventHandler(this.rdoExisting_CheckedChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.AutoSize = true;
            this.txtAmount.Location = new System.Drawing.Point(243, 106);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(43, 13);
            this.txtAmount.TabIndex = 70;
            this.txtAmount.Text = "Amount";
            // 
            // txtTonValue
            // 
            this.txtTonValue.Location = new System.Drawing.Point(46, 103);
            this.txtTonValue.Name = "txtTonValue";
            this.txtTonValue.Size = new System.Drawing.Size(191, 20);
            this.txtTonValue.TabIndex = 69;
            // 
            // txtTon
            // 
            this.txtTon.AutoSize = true;
            this.txtTon.Location = new System.Drawing.Point(6, 107);
            this.txtTon.Name = "txtTon";
            this.txtTon.Size = new System.Drawing.Size(26, 13);
            this.txtTon.TabIndex = 68;
            this.txtTon.Text = "Ton";
            // 
            // txtQtyValue
            // 
            this.txtQtyValue.Location = new System.Drawing.Point(283, 80);
            this.txtQtyValue.Name = "txtQtyValue";
            this.txtQtyValue.Size = new System.Drawing.Size(191, 20);
            this.txtQtyValue.TabIndex = 67;
            // 
            // txtQty
            // 
            this.txtQty.AutoSize = true;
            this.txtQty.Location = new System.Drawing.Point(243, 84);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(23, 13);
            this.txtQty.TabIndex = 66;
            this.txtQty.Text = "Qty";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(243, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 65;
            this.label9.Text = "MAG";
            // 
            // cmbMag
            // 
            this.cmbMag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMag.FormattingEnabled = true;
            this.cmbMag.Location = new System.Drawing.Point(284, 54);
            this.cmbMag.Name = "cmbMag";
            this.cmbMag.Size = new System.Drawing.Size(190, 21);
            this.cmbMag.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Brand";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(47, 54);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(190, 21);
            this.cmbBrand.TabIndex = 62;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(46, 79);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(191, 20);
            this.txtModel.TabIndex = 60;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Model";
            // 
            // btnAddToList
            // 
            this.btnAddToList.Location = new System.Drawing.Point(544, 278);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(75, 23);
            this.btnAddToList.TabIndex = 73;
            this.btnAddToList.Text = "AddToList";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // lblPoAmount
            // 
            this.lblPoAmount.AutoSize = true;
            this.lblPoAmount.Location = new System.Drawing.Point(407, 449);
            this.lblPoAmount.Name = "lblPoAmount";
            this.lblPoAmount.Size = new System.Drawing.Size(61, 13);
            this.lblPoAmount.TabIndex = 74;
            this.lblPoAmount.Text = "PO Amount";
            // 
            // txtPOAmount
            // 
            this.txtPOAmount.Location = new System.Drawing.Point(486, 445);
            this.txtPOAmount.Name = "txtPOAmount";
            this.txtPOAmount.ReadOnly = true;
            this.txtPOAmount.Size = new System.Drawing.Size(136, 20);
            this.txtPOAmount.TabIndex = 75;
            this.txtPOAmount.Text = "0.00";
            this.txtPOAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "BrandID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "MAGID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Brand";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "MAG";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Model";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Qty";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Ton";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 60;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // frmCACQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 521);
            this.Controls.Add(this.lblPoAmount);
            this.Controls.Add(this.txtPOAmount);
            this.Controls.Add(this.btnAddToList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dgvCACQuotation);
            this.Name = "frmCACQuotation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Quotation";
            this.Load += new System.EventHandler(this.frmCACQuotation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCACQuotation)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoNewCustomer;
        private System.Windows.Forms.RadioButton rdoOldCustomer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.DataGridView dgvCACQuotation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrandID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAGID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMag;
        private System.Windows.Forms.TextBox txtAmountValue;
        private System.Windows.Forms.Label txtAmount;
        private System.Windows.Forms.TextBox txtTonValue;
        private System.Windows.Forms.Label txtTon;
        private System.Windows.Forms.TextBox txtQtyValue;
        private System.Windows.Forms.Label txtQty;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Label lblPoAmount;
        private System.Windows.Forms.TextBox txtPOAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTelephoneNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rdoNonExisting;
        private System.Windows.Forms.RadioButton rdoExisting;
        private System.Windows.Forms.Label lblProduct;
        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReferenceNo;
        private System.Windows.Forms.Label label13;
        private ctlEmployee ctlEmployee1;
    }
}