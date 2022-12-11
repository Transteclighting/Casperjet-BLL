namespace CJ.Win.Inventory
{
    partial class frmGoodsReceive
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSupplyer = new System.Windows.Forms.TextBox();
            this.txtPINo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCINo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpLCInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpLCDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbToChannel = new System.Windows.Forms.ComboBox();
            this.dtTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.cmbToWarehouse = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblTransactionRefNo = new System.Windows.Forms.Label();
            this.txtTransationRef = new System.Windows.Forms.TextBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.ckbIsOthers = new System.Windows.Forms.CheckBox();
            this.lbOther = new System.Windows.Forms.Label();
            this.txtOther = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RBGRD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiveQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DamagedQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinorDefectiveQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSupplyer);
            this.groupBox1.Controls.Add(this.txtPINo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbCINo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpLCInvoiceDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpLCDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLCNo);
            this.groupBox1.Location = new System.Drawing.Point(5, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(675, 81);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LC Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Supplyer";
            // 
            // txtSupplyer
            // 
            this.txtSupplyer.Enabled = false;
            this.txtSupplyer.Location = new System.Drawing.Point(98, 46);
            this.txtSupplyer.Name = "txtSupplyer";
            this.txtSupplyer.Size = new System.Drawing.Size(183, 20);
            this.txtSupplyer.TabIndex = 37;
            // 
            // txtPINo
            // 
            this.txtPINo.Enabled = false;
            this.txtPINo.Location = new System.Drawing.Point(347, 46);
            this.txtPINo.Name = "txtPINo";
            this.txtPINo.Size = new System.Drawing.Size(133, 20);
            this.txtPINo.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "CI Number";
            // 
            // cmbCINo
            // 
            this.cmbCINo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCINo.FormattingEnabled = true;
            this.cmbCINo.Location = new System.Drawing.Point(98, 18);
            this.cmbCINo.Name = "cmbCINo";
            this.cmbCINo.Size = new System.Drawing.Size(153, 21);
            this.cmbCINo.TabIndex = 9;
            this.cmbCINo.SelectedIndexChanged += new System.EventHandler(this.cmbCINo_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "PI Number";
            // 
            // dtpLCInvoiceDate
            // 
            this.dtpLCInvoiceDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpLCInvoiceDate.Enabled = false;
            this.dtpLCInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLCInvoiceDate.Location = new System.Drawing.Point(545, 48);
            this.dtpLCInvoiceDate.Name = "dtpLCInvoiceDate";
            this.dtpLCInvoiceDate.Size = new System.Drawing.Size(117, 20);
            this.dtpLCInvoiceDate.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(499, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "CI Date";
            // 
            // dtpLCDate
            // 
            this.dtpLCDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpLCDate.Enabled = false;
            this.dtpLCDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLCDate.Location = new System.Drawing.Point(545, 20);
            this.dtpLCDate.Name = "dtpLCDate";
            this.dtpLCDate.Size = new System.Drawing.Size(117, 20);
            this.dtpLCDate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(496, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "LC Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "LC Number";
            // 
            // txtLCNo
            // 
            this.txtLCNo.Enabled = false;
            this.txtLCNo.Location = new System.Drawing.Point(347, 19);
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.Size = new System.Drawing.Size(133, 20);
            this.txtLCNo.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(790, 587);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 35);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(871, 587);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 35);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Channel";
            // 
            // cmbToChannel
            // 
            this.cmbToChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToChannel.FormattingEnabled = true;
            this.cmbToChannel.Location = new System.Drawing.Point(103, 35);
            this.cmbToChannel.Name = "cmbToChannel";
            this.cmbToChannel.Size = new System.Drawing.Size(172, 21);
            this.cmbToChannel.TabIndex = 26;
            this.cmbToChannel.SelectedIndexChanged += new System.EventHandler(this.cmbToChannel_SelectedIndexChanged);
            // 
            // dtTransactionDate
            // 
            this.dtTransactionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtTransactionDate.Enabled = false;
            this.dtTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransactionDate.Location = new System.Drawing.Point(376, 9);
            this.dtTransactionDate.Name = "dtTransactionDate";
            this.dtTransactionDate.Size = new System.Drawing.Size(195, 20);
            this.dtTransactionDate.TabIndex = 22;
            this.dtTransactionDate.Tag = "M1.21";
            // 
            // cmbToWarehouse
            // 
            this.cmbToWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToWarehouse.FormattingEnabled = true;
            this.cmbToWarehouse.Location = new System.Drawing.Point(376, 35);
            this.cmbToWarehouse.Name = "cmbToWarehouse";
            this.cmbToWarehouse.Size = new System.Drawing.Size(195, 21);
            this.cmbToWarehouse.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Warehouse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Transaction Date";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(709, 587);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 35);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(103, 62);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(577, 20);
            this.txtRemarks.TabIndex = 27;
            // 
            // lblTransactionRefNo
            // 
            this.lblTransactionRefNo.AutoSize = true;
            this.lblTransactionRefNo.Location = new System.Drawing.Point(7, 10);
            this.lblTransactionRefNo.Name = "lblTransactionRefNo";
            this.lblTransactionRefNo.Size = new System.Drawing.Size(93, 13);
            this.lblTransactionRefNo.TabIndex = 23;
            this.lblTransactionRefNo.Text = "Transaction Ref #";
            // 
            // txtTransationRef
            // 
            this.txtTransationRef.Location = new System.Drawing.Point(103, 7);
            this.txtTransationRef.Name = "txtTransationRef";
            this.txtTransationRef.Size = new System.Drawing.Size(172, 20);
            this.txtTransationRef.TabIndex = 21;
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.txtCostPrice,
            this.CIQty,
            this.RBGRD,
            this.ReceiveQty,
            this.ShortQty,
            this.DamagedQty,
            this.MinorDefectiveQty,
            this.Remarks,
            this.ProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(5, 196);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(950, 385);
            this.dgvLineItem.TabIndex = 36;
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
            // 
            // ckbIsOthers
            // 
            this.ckbIsOthers.AutoSize = true;
            this.ckbIsOthers.Location = new System.Drawing.Point(103, 88);
            this.ckbIsOthers.Name = "ckbIsOthers";
            this.ckbIsOthers.Size = new System.Drawing.Size(116, 17);
            this.ckbIsOthers.TabIndex = 37;
            this.ckbIsOthers.Text = "Without CI Number";
            this.ckbIsOthers.UseVisualStyleBackColor = true;
            this.ckbIsOthers.CheckedChanged += new System.EventHandler(this.ckbIsOthers_CheckedChanged);
            // 
            // lbOther
            // 
            this.lbOther.AutoSize = true;
            this.lbOther.Location = new System.Drawing.Point(313, 89);
            this.lbOther.Name = "lbOther";
            this.lbOther.Size = new System.Drawing.Size(60, 13);
            this.lbOther.TabIndex = 40;
            this.lbOther.Text = "LC Number";
            // 
            // txtOther
            // 
            this.txtOther.Location = new System.Drawing.Point(376, 86);
            this.txtOther.Name = "txtOther";
            this.txtOther.Size = new System.Drawing.Size(195, 20);
            this.txtOther.TabIndex = 39;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Frozen = true;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDescription.Frozen = true;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 170;
            // 
            // txtCostPrice
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.txtCostPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtCostPrice.Frozen = true;
            this.txtCostPrice.HeaderText = "Unit Price";
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.ReadOnly = true;
            // 
            // CIQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.CIQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.CIQty.HeaderText = "CI Qty";
            this.CIQty.Name = "CIQty";
            this.CIQty.ReadOnly = true;
            // 
            // RBGRD
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            this.RBGRD.DefaultCellStyle = dataGridViewCellStyle5;
            this.RBGRD.HeaderText = "Receive Before This GRD";
            this.RBGRD.Name = "RBGRD";
            this.RBGRD.ReadOnly = true;
            // 
            // ReceiveQty
            // 
            this.ReceiveQty.HeaderText = "Receive Qty";
            this.ReceiveQty.Name = "ReceiveQty";
            // 
            // ShortQty
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.ShortQty.DefaultCellStyle = dataGridViewCellStyle6;
            this.ShortQty.HeaderText = "Short Qty";
            this.ShortQty.Name = "ShortQty";
            // 
            // DamagedQty
            // 
            this.DamagedQty.HeaderText = "Damaged Qty";
            this.DamagedQty.Name = "DamagedQty";
            // 
            // MinorDefectiveQty
            // 
            this.MinorDefectiveQty.HeaderText = "Minor Defective Qty";
            this.MinorDefectiveQty.Name = "MinorDefectiveQty";
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "Product ID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // frmGoodsReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 634);
            this.Controls.Add(this.lbOther);
            this.Controls.Add(this.ckbIsOthers);
            this.Controls.Add(this.txtOther);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbToChannel);
            this.Controls.Add(this.dtTransactionDate);
            this.Controls.Add(this.cmbToWarehouse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblTransactionRefNo);
            this.Controls.Add(this.txtTransationRef);
            this.Name = "frmGoodsReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Goods Receive (GRD)";
            this.Load += new System.EventHandler(this.frmGoodsReceive_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCINo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpLCInvoiceDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpLCDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbToChannel;
        private System.Windows.Forms.DateTimePicker dtTransactionDate;
        private System.Windows.Forms.ComboBox cmbToWarehouse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblTransactionRefNo;
        private System.Windows.Forms.TextBox txtTransationRef;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPINo;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSupplyer;
        private System.Windows.Forms.CheckBox ckbIsOthers;
        private System.Windows.Forms.Label lbOther;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCostPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn RBGRD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiveQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DamagedQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinorDefectiveQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
    }
}