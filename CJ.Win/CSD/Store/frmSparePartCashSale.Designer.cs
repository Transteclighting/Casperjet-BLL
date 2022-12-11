namespace CJ.Win.CSD.Store
{
    partial class frmSparePartCashSale
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
            this.dgvPartSale = new System.Windows.Forms.DataGridView();
            this.txtSparePartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindParts = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtSparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIssueQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnitSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SparePartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalCharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtNetSalePrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCashMemoNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStore = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOtherCharge = new System.Windows.Forms.TextBox();
            this.lblTotalSPCharge = new System.Windows.Forms.Label();
            this.txtTotalSPCharge = new System.Windows.Forms.TextBox();
            this.lblJob = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctlCSDJob1 = new CJ.Win.ctlCSDJob();
            this.label9 = new System.Windows.Forms.Label();
            this.txtReceiveAmount = new System.Windows.Forms.TextBox();
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartSale)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPartSale
            // 
            this.dgvPartSale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSparePartCode,
            this.btnFindParts,
            this.txtSparePartName,
            this.txtCurrentStock,
            this.txtIssueQty,
            this.txtUnitSP,
            this.txtTotalPrice,
            this.SparePartID,
            this.txtCostPrice,
            this.colTotalCharge,
            this.colTotalDiscount});
            this.dgvPartSale.Location = new System.Drawing.Point(12, 82);
            this.dgvPartSale.Name = "dgvPartSale";
            this.dgvPartSale.Size = new System.Drawing.Size(757, 222);
            this.dgvPartSale.TabIndex = 12;
            this.dgvPartSale.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssuePart_CellContentClick);
            this.dgvPartSale.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIssuePart_CellValueChanged);
            // 
            // txtSparePartCode
            // 
            this.txtSparePartCode.Frozen = true;
            this.txtSparePartCode.HeaderText = "Part Code";
            this.txtSparePartCode.Name = "txtSparePartCode";
            // 
            // btnFindParts
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            this.btnFindParts.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnFindParts.Frozen = true;
            this.btnFindParts.HeaderText = "?";
            this.btnFindParts.Name = "btnFindParts";
            this.btnFindParts.Text = "...";
            this.btnFindParts.Width = 35;
            // 
            // txtSparePartName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSparePartName.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtSparePartName.Frozen = true;
            this.txtSparePartName.HeaderText = "Part Name";
            this.txtSparePartName.Name = "txtSparePartName";
            this.txtSparePartName.ReadOnly = true;
            this.txtSparePartName.Width = 220;
            // 
            // txtCurrentStock
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCurrentStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtCurrentStock.Frozen = true;
            this.txtCurrentStock.HeaderText = "Current Stock";
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.ReadOnly = true;
            this.txtCurrentStock.Width = 70;
            // 
            // txtIssueQty
            // 
            this.txtIssueQty.Frozen = true;
            this.txtIssueQty.HeaderText = "Issue Qty";
            this.txtIssueQty.Name = "txtIssueQty";
            this.txtIssueQty.Width = 80;
            // 
            // txtUnitSP
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUnitSP.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtUnitSP.Frozen = true;
            this.txtUnitSP.HeaderText = "Unit Sale Price";
            this.txtUnitSP.Name = "txtUnitSP";
            this.txtUnitSP.ReadOnly = true;
            this.txtUnitSP.Width = 90;
            // 
            // txtTotalPrice
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtTotalPrice.Frozen = true;
            this.txtTotalPrice.HeaderText = "Total Sale Price";
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            // 
            // SparePartID
            // 
            this.SparePartID.Frozen = true;
            this.SparePartID.HeaderText = "SparePartID";
            this.SparePartID.Name = "SparePartID";
            this.SparePartID.Visible = false;
            // 
            // txtCostPrice
            // 
            this.txtCostPrice.Frozen = true;
            this.txtCostPrice.HeaderText = "CostPrice";
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.ReadOnly = true;
            this.txtCostPrice.Visible = false;
            // 
            // colTotalCharge
            // 
            this.colTotalCharge.HeaderText = "Total Charge";
            this.colTotalCharge.Name = "colTotalCharge";
            this.colTotalCharge.Visible = false;
            // 
            // colTotalDiscount
            // 
            this.colTotalDiscount.HeaderText = "Total Discount";
            this.colTotalDiscount.Name = "colTotalDiscount";
            this.colTotalDiscount.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(68, 436);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(701, 20);
            this.txtRemarks.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(682, 462);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 26);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(589, 462);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 26);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtNetSalePrice
            // 
            this.txtNetSalePrice.Location = new System.Drawing.Point(675, 383);
            this.txtNetSalePrice.Name = "txtNetSalePrice";
            this.txtNetSalePrice.ReadOnly = true;
            this.txtNetSalePrice.Size = new System.Drawing.Size(95, 20);
            this.txtNetSalePrice.TabIndex = 22;
            this.txtNetSalePrice.Text = "0.00";
            this.txtNetSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(557, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Discount Amount(-)";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(675, 359);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(94, 20);
            this.txtDiscount.TabIndex = 20;
            this.txtDiscount.Text = "0.00";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(125, 9);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(378, 20);
            this.txtCustomerName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Customer Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(125, 33);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(378, 20);
            this.txtAddress.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(504, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Cash Meno# ";
            // 
            // txtCashMemoNo
            // 
            this.txtCashMemoNo.Location = new System.Drawing.Point(589, 9);
            this.txtCashMemoNo.Name = "txtCashMemoNo";
            this.txtCashMemoNo.Size = new System.Drawing.Size(179, 20);
            this.txtCashMemoNo.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(598, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Net Amount";
            // 
            // cmbStore
            // 
            this.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStore.FormattingEnabled = true;
            this.cmbStore.Location = new System.Drawing.Point(589, 32);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(179, 21);
            this.cmbStore.TabIndex = 7;
            this.cmbStore.SelectedIndexChanged += new System.EventHandler(this.cmbStore_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(549, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Store";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(575, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Other Charge(+)";
            // 
            // txtOtherCharge
            // 
            this.txtOtherCharge.Location = new System.Drawing.Point(675, 334);
            this.txtOtherCharge.Name = "txtOtherCharge";
            this.txtOtherCharge.Size = new System.Drawing.Size(95, 20);
            this.txtOtherCharge.TabIndex = 18;
            this.txtOtherCharge.Text = "0.00";
            this.txtOtherCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOtherCharge.TextChanged += new System.EventHandler(this.txtOtherCharge_TextChanged);
            this.txtOtherCharge.Leave += new System.EventHandler(this.txtOtherCharge_Leave);
            // 
            // lblTotalSPCharge
            // 
            this.lblTotalSPCharge.AutoSize = true;
            this.lblTotalSPCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSPCharge.Location = new System.Drawing.Point(573, 312);
            this.lblTotalSPCharge.Name = "lblTotalSPCharge";
            this.lblTotalSPCharge.Size = new System.Drawing.Size(99, 13);
            this.lblTotalSPCharge.TabIndex = 15;
            this.lblTotalSPCharge.Text = "Total Sp Charge";
            // 
            // txtTotalSPCharge
            // 
            this.txtTotalSPCharge.Location = new System.Drawing.Point(675, 309);
            this.txtTotalSPCharge.Name = "txtTotalSPCharge";
            this.txtTotalSPCharge.ReadOnly = true;
            this.txtTotalSPCharge.Size = new System.Drawing.Size(95, 20);
            this.txtTotalSPCharge.TabIndex = 17;
            this.txtTotalSPCharge.Text = "0.00";
            this.txtTotalSPCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalSPCharge.TextChanged += new System.EventHandler(this.txtTotalSPCharge_TextChanged);
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJob.Location = new System.Drawing.Point(74, 59);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(47, 13);
            this.lblJob.TabIndex = 8;
            this.lblJob.Text = "Job No";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Part Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Part Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Current Stock";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Issue Qty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "Unit Sale Price";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 90;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn6.Frozen = true;
            this.dataGridViewTextBoxColumn6.HeaderText = "Total Sale Price";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.Frozen = true;
            this.dataGridViewTextBoxColumn7.HeaderText = "SparePartID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.Frozen = true;
            this.dataGridViewTextBoxColumn8.HeaderText = "CostPrice";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // ctlCSDJob1
            // 
            this.ctlCSDJob1.Location = new System.Drawing.Point(125, 56);
            this.ctlCSDJob1.Name = "ctlCSDJob1";
            this.ctlCSDJob1.Size = new System.Drawing.Size(378, 20);
            this.ctlCSDJob1.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(573, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Receive Amount";
            // 
            // txtReceiveAmount
            // 
            this.txtReceiveAmount.Location = new System.Drawing.Point(676, 407);
            this.txtReceiveAmount.Name = "txtReceiveAmount";
            this.txtReceiveAmount.Size = new System.Drawing.Size(95, 20);
            this.txtReceiveAmount.TabIndex = 24;
            this.txtReceiveAmount.Text = "0.00";
            this.txtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.Location = new System.Drawing.Point(589, 56);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.Size = new System.Drawing.Size(179, 20);
            this.txtVehicleNo.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(516, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Vehicle No";
            // 
            // frmSparePartCashSale
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 496);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtReceiveAmount);
            this.Controls.Add(this.ctlCSDJob1);
            this.Controls.Add(this.lblJob);
            this.Controls.Add(this.lblTotalSPCharge);
            this.Controls.Add(this.txtTotalSPCharge);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtOtherCharge);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbStore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtVehicleNo);
            this.Controls.Add(this.txtCashMemoNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtNetSalePrice);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dgvPartSale);
            this.Name = "frmSparePartCashSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spare Part Cash Sale";
            this.Load += new System.EventHandler(this.frmSparePartCashSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartSale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPartSale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtNetSalePrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCashMemoNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOtherCharge;
        private System.Windows.Forms.Label lblTotalSPCharge;
        private System.Windows.Forms.TextBox txtTotalSPCharge;
        private ctlCSDJob ctlCSDJob1;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtReceiveAmount;
        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIssueQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUnitSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SparePartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalDiscount;
    }
}