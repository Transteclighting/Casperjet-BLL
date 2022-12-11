namespace CJ.Win
{
    partial class frmISVPartsRequisitionIssue
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
            this.dgvRequisitionItemIssue = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lvwISVPartsRequisitionIssued = new System.Windows.Forms.ListView();
            this.colPartCode = new System.Windows.Forms.ColumnHeader();
            this.colPartName = new System.Windows.Forms.ColumnHeader();
            this.colQty = new System.Windows.Forms.ColumnHeader();
            this.colJobNo = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colIssueFrom = new System.Windows.Forms.ColumnHeader();
            this.colLoanNo = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRequisitionID = new System.Windows.Forms.Label();
            this.lblInterService = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblReportNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReceiveDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPrepareDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSparePartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtJobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboSubStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtLoanCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnJobSearch = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtLoanProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EDD = new RSMS.BaseItems.DateTimePickerColumn();
            this.txtRequisitionItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLoanProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtJobID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSparePartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCostprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisitionItemIssue)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRequisitionItemIssue
            // 
            this.dgvRequisitionItemIssue.AllowUserToAddRows = false;
            this.dgvRequisitionItemIssue.AllowUserToDeleteRows = false;
            this.dgvRequisitionItemIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequisitionItemIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequisitionItemIssue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSparePartCode,
            this.txtSparePartName,
            this.txtSalePrice,
            this.txtQty,
            this.txtStock,
            this.txtJobNo,
            this.txtProductName,
            this.cboSubStatus,
            this.txtLoanCode,
            this.btnJobSearch,
            this.txtLoanProduct,
            this.EDD,
            this.txtRequisitionItemID,
            this.txtLoanProductID,
            this.txtJobID,
            this.txtSparePartID,
            this.txtCostprice});
            this.dgvRequisitionItemIssue.Location = new System.Drawing.Point(12, 81);
            this.dgvRequisitionItemIssue.Name = "dgvRequisitionItemIssue";
            this.dgvRequisitionItemIssue.Size = new System.Drawing.Size(770, 201);
            this.dgvRequisitionItemIssue.TabIndex = 38;
            this.dgvRequisitionItemIssue.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequisitionItemIssue_CellValueChanged);
            this.dgvRequisitionItemIssue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequisitionItemIssue_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(673, 475);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 206;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(562, 475);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 27);
            this.btnSave.TabIndex = 205;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lvwISVPartsRequisitionIssued
            // 
            this.lvwISVPartsRequisitionIssued.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwISVPartsRequisitionIssued.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPartCode,
            this.colPartName,
            this.colQty,
            this.colJobNo,
            this.colProductName,
            this.colIssueFrom,
            this.colLoanNo});
            this.lvwISVPartsRequisitionIssued.FullRowSelect = true;
            this.lvwISVPartsRequisitionIssued.GridLines = true;
            this.lvwISVPartsRequisitionIssued.Location = new System.Drawing.Point(12, 288);
            this.lvwISVPartsRequisitionIssued.MultiSelect = false;
            this.lvwISVPartsRequisitionIssued.Name = "lvwISVPartsRequisitionIssued";
            this.lvwISVPartsRequisitionIssued.Size = new System.Drawing.Size(770, 177);
            this.lvwISVPartsRequisitionIssued.TabIndex = 207;
            this.lvwISVPartsRequisitionIssued.UseCompatibleStateImageBehavior = false;
            this.lvwISVPartsRequisitionIssued.View = System.Windows.Forms.View.Details;
            // 
            // colPartCode
            // 
            this.colPartCode.Text = "Part Code";
            this.colPartCode.Width = 98;
            // 
            // colPartName
            // 
            this.colPartName.Text = "Part Name";
            this.colPartName.Width = 180;
            // 
            // colQty
            // 
            this.colQty.Text = "Qty";
            this.colQty.Width = 38;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 77;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 189;
            // 
            // colIssueFrom
            // 
            this.colIssueFrom.Text = "Issue From";
            this.colIssueFrom.Width = 87;
            // 
            // colLoanNo
            // 
            this.colLoanNo.Text = "Loan Code";
            this.colLoanNo.Width = 93;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 208;
            this.label1.Text = "Requisition ID :";
            // 
            // lblRequisitionID
            // 
            this.lblRequisitionID.AutoSize = true;
            this.lblRequisitionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequisitionID.Location = new System.Drawing.Point(113, 11);
            this.lblRequisitionID.Name = "lblRequisitionID";
            this.lblRequisitionID.Size = new System.Drawing.Size(14, 13);
            this.lblRequisitionID.TabIndex = 209;
            this.lblRequisitionID.Text = "?";
            // 
            // lblInterService
            // 
            this.lblInterService.AutoSize = true;
            this.lblInterService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterService.Location = new System.Drawing.Point(113, 35);
            this.lblInterService.Name = "lblInterService";
            this.lblInterService.Size = new System.Drawing.Size(14, 13);
            this.lblInterService.TabIndex = 211;
            this.lblInterService.Text = "?";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 210;
            this.label3.Text = "Inter Service :";
            // 
            // lblReportNo
            // 
            this.lblReportNo.AutoSize = true;
            this.lblReportNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportNo.Location = new System.Drawing.Point(290, 11);
            this.lblReportNo.Name = "lblReportNo";
            this.lblReportNo.Size = new System.Drawing.Size(14, 13);
            this.lblReportNo.TabIndex = 213;
            this.lblReportNo.Text = "?";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(212, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 212;
            this.label4.Text = "Report No :";
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.AutoSize = true;
            this.lblSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNo.Location = new System.Drawing.Point(461, 11);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(14, 13);
            this.lblSerialNo.TabIndex = 215;
            this.lblSerialNo.Text = "?";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(391, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 214;
            this.label5.Text = "Serial No :";
            // 
            // lblReceiveDate
            // 
            this.lblReceiveDate.AutoSize = true;
            this.lblReceiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiveDate.Location = new System.Drawing.Point(644, 11);
            this.lblReceiveDate.Name = "lblReceiveDate";
            this.lblReceiveDate.Size = new System.Drawing.Size(14, 13);
            this.lblReceiveDate.TabIndex = 217;
            this.lblReceiveDate.Text = "?";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(546, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 216;
            this.label6.Text = "Receive Date :";
            // 
            // lblPrepareDate
            // 
            this.lblPrepareDate.AutoSize = true;
            this.lblPrepareDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrepareDate.Location = new System.Drawing.Point(644, 35);
            this.lblPrepareDate.Name = "lblPrepareDate";
            this.lblPrepareDate.Size = new System.Drawing.Size(14, 13);
            this.lblPrepareDate.TabIndex = 219;
            this.lblPrepareDate.Text = "?";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(546, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 218;
            this.label7.Text = "Prepare Date :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPrepareDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblReceiveDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblSerialNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblReportNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblInterService);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblRequisitionID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 53);
            this.groupBox1.TabIndex = 220;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.BurlyWood;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(173, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 222;
            this.label2.Text = "Issue form Loan Set";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(39, 478);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 17);
            this.label8.TabIndex = 221;
            this.label8.Text = "Issue from Stock";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSparePartCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSparePartCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtSparePartCode.FillWeight = 300F;
            this.txtSparePartCode.Frozen = true;
            this.txtSparePartCode.HeaderText = "Part Code";
            this.txtSparePartCode.Name = "txtSparePartCode";
            this.txtSparePartCode.ReadOnly = true;
            this.txtSparePartCode.Width = 95;
            // 
            // txtSparePartName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSparePartName.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtSparePartName.FillWeight = 300F;
            this.txtSparePartName.Frozen = true;
            this.txtSparePartName.HeaderText = "Spare Part Name";
            this.txtSparePartName.Name = "txtSparePartName";
            this.txtSparePartName.ReadOnly = true;
            this.txtSparePartName.Width = 160;
            // 
            // txtSalePrice
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSalePrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtSalePrice.FillWeight = 300F;
            this.txtSalePrice.Frozen = true;
            this.txtSalePrice.HeaderText = "Unit Price";
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.ReadOnly = true;
            this.txtSalePrice.Width = 50;
            // 
            // txtQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtQty.FillWeight = 300F;
            this.txtQty.Frozen = true;
            this.txtQty.HeaderText = "Claim Qty";
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Width = 50;
            // 
            // txtStock
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtStock.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtStock.FillWeight = 300F;
            this.txtStock.Frozen = true;
            this.txtStock.HeaderText = "Stock";
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Width = 50;
            // 
            // txtJobNo
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtJobNo.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtJobNo.FillWeight = 300F;
            this.txtJobNo.HeaderText = "Job No";
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.ReadOnly = true;
            this.txtJobNo.Width = 75;
            // 
            // txtProductName
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductName.DefaultCellStyle = dataGridViewCellStyle7;
            this.txtProductName.FillWeight = 300F;
            this.txtProductName.HeaderText = "Product Name";
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Width = 150;
            // 
            // cboSubStatus
            // 
            this.cboSubStatus.FillWeight = 300F;
            this.cboSubStatus.HeaderText = "Sub Status";
            this.cboSubStatus.Items.AddRange(new object[] {
            "FromStock",
            "FromLoanSet",
            "LocalPurchase",
            "ForeignOrder",
            "LoanRequisition",
            "Suspend",
            "Rejected"});
            this.cboSubStatus.Name = "cboSubStatus";
            // 
            // txtLoanCode
            // 
            this.txtLoanCode.FillWeight = 300F;
            this.txtLoanCode.HeaderText = "Loan Code";
            this.txtLoanCode.Name = "txtLoanCode";
            // 
            // btnJobSearch
            // 
            this.btnJobSearch.FillWeight = 300F;
            this.btnJobSearch.HeaderText = "?";
            this.btnJobSearch.Name = "btnJobSearch";
            this.btnJobSearch.Width = 35;
            // 
            // txtLoanProduct
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtLoanProduct.DefaultCellStyle = dataGridViewCellStyle8;
            this.txtLoanProduct.FillWeight = 300F;
            this.txtLoanProduct.HeaderText = "Loan Product";
            this.txtLoanProduct.Name = "txtLoanProduct";
            this.txtLoanProduct.ReadOnly = true;
            // 
            // EDD
            // 
            this.EDD.FillWeight = 300F;
            this.EDD.HeaderText = "EDD";
            this.EDD.Name = "EDD";
            // 
            // txtRequisitionItemID
            // 
            this.txtRequisitionItemID.FillWeight = 300F;
            this.txtRequisitionItemID.HeaderText = "Requisition Item ID";
            this.txtRequisitionItemID.Name = "txtRequisitionItemID";
            this.txtRequisitionItemID.Visible = false;
            // 
            // txtLoanProductID
            // 
            this.txtLoanProductID.FillWeight = 300F;
            this.txtLoanProductID.HeaderText = "Loan Product ID";
            this.txtLoanProductID.Name = "txtLoanProductID";
            this.txtLoanProductID.Visible = false;
            // 
            // txtJobID
            // 
            this.txtJobID.FillWeight = 300F;
            this.txtJobID.HeaderText = "Job ID";
            this.txtJobID.Name = "txtJobID";
            this.txtJobID.Visible = false;
            // 
            // txtSparePartID
            // 
            this.txtSparePartID.FillWeight = 300F;
            this.txtSparePartID.HeaderText = "Sprare Part ID";
            this.txtSparePartID.Name = "txtSparePartID";
            this.txtSparePartID.Visible = false;
            // 
            // txtCostprice
            // 
            this.txtCostprice.FillWeight = 300F;
            this.txtCostprice.HeaderText = "Cost price";
            this.txtCostprice.Name = "txtCostprice";
            this.txtCostprice.Visible = false;
            // 
            // frmISVPartsRequisitionIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 510);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwISVPartsRequisitionIssued);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvRequisitionItemIssue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmISVPartsRequisitionIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inter Service Parts Issue Against Requisition";
            this.Load += new System.EventHandler(this.frmISVPartsRequisitionIssue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequisitionItemIssue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRequisitionItemIssue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lvwISVPartsRequisitionIssued;
        private System.Windows.Forms.ColumnHeader colPartCode;
        private System.Windows.Forms.ColumnHeader colPartName;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colIssueFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRequisitionID;
        private System.Windows.Forms.Label lblInterService;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblReportNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReceiveDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPrepareDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ColumnHeader colLoanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtJobNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductName;
        private System.Windows.Forms.DataGridViewComboBoxColumn cboSubStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLoanCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnJobSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLoanProduct;
        private RSMS.BaseItems.DateTimePickerColumn EDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRequisitionItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLoanProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtJobID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCostprice;
    }
}