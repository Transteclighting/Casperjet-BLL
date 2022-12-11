namespace CJ.Win
{
    partial class frmPurchaseRequisition
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbPOtype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtApprovalDate = new System.Windows.Forms.DateTimePicker();
            this.lbApprovalDate = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.cmbApplyStatus = new System.Windows.Forms.ComboBox();
            this.txtPONo = new System.Windows.Forms.TextBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTransactionRefNo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGoodQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLcQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDutyAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDocValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtPIDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLCValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtDutyDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtDocDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpLCDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.txtPINo = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(26, 628);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(539, 630);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(107, 628);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbPOtype);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtApprovalDate);
            this.groupBox2.Controls.Add(this.lbApprovalDate);
            this.groupBox2.Controls.Add(this.lbStatus);
            this.groupBox2.Controls.Add(this.cmbApplyStatus);
            this.groupBox2.Controls.Add(this.txtPONo);
            this.groupBox2.Controls.Add(this.cmbSupplier);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lblTransactionRefNo);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 155);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Basic Information";
            // 
            // cbPOtype
            // 
            this.cbPOtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPOtype.FormattingEnabled = true;
            this.cbPOtype.Items.AddRange(new object[] {
            "Light",
            "Electronics",
            "Mobile"});
            this.cbPOtype.Location = new System.Drawing.Point(129, 16);
            this.cbPOtype.Name = "cbPOtype";
            this.cbPOtype.Size = new System.Drawing.Size(121, 21);
            this.cbPOtype.TabIndex = 19;
            this.cbPOtype.SelectedIndexChanged += new System.EventHandler(this.cbPOtype_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Choose Your PO Type";
            // 
            // dtApprovalDate
            // 
            this.dtApprovalDate.Checked = false;
            this.dtApprovalDate.CustomFormat = "dd-MMM-yyyy";
            this.dtApprovalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtApprovalDate.Location = new System.Drawing.Point(492, 18);
            this.dtApprovalDate.Name = "dtApprovalDate";
            this.dtApprovalDate.ShowCheckBox = true;
            this.dtApprovalDate.Size = new System.Drawing.Size(117, 20);
            this.dtApprovalDate.TabIndex = 5;
            // 
            // lbApprovalDate
            // 
            this.lbApprovalDate.AutoSize = true;
            this.lbApprovalDate.Location = new System.Drawing.Point(414, 21);
            this.lbApprovalDate.Name = "lbApprovalDate";
            this.lbApprovalDate.Size = new System.Drawing.Size(75, 13);
            this.lbApprovalDate.TabIndex = 4;
            this.lbApprovalDate.Text = "Approval Date";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(35, 46);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(92, 13);
            this.lbStatus.TabIndex = 0;
            this.lbStatus.Text = "Requisition Status";
            // 
            // cmbApplyStatus
            // 
            this.cmbApplyStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplyStatus.FormattingEnabled = true;
            this.cmbApplyStatus.Location = new System.Drawing.Point(129, 43);
            this.cmbApplyStatus.Name = "cmbApplyStatus";
            this.cmbApplyStatus.Size = new System.Drawing.Size(158, 21);
            this.cmbApplyStatus.TabIndex = 1;
            this.cmbApplyStatus.SelectedIndexChanged += new System.EventHandler(this.cmbApplyStatus_SelectedIndexChanged);
            // 
            // txtPONo
            // 
            this.txtPONo.Enabled = false;
            this.txtPONo.Location = new System.Drawing.Point(129, 72);
            this.txtPONo.Name = "txtPONo";
            this.txtPONo.Size = new System.Drawing.Size(154, 20);
            this.txtPONo.TabIndex = 7;
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(129, 99);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(182, 21);
            this.cmbSupplier.TabIndex = 11;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(129, 126);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(389, 20);
            this.txtRemarks.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Remarks";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Supplier Name";
            // 
            // lblTransactionRefNo
            // 
            this.lblTransactionRefNo.AutoSize = true;
            this.lblTransactionRefNo.Location = new System.Drawing.Point(88, 75);
            this.lblTransactionRefNo.Name = "lblTransactionRefNo";
            this.lblTransactionRefNo.Size = new System.Drawing.Size(39, 13);
            this.lblTransactionRefNo.TabIndex = 6;
            this.lblTransactionRefNo.Text = "PO No";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLineItem);
            this.groupBox1.Location = new System.Drawing.Point(7, 330);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 297);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product Information";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.txtGoodQty,
            this.PIValue,
            this.colLcQty,
            this.colProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(15, 19);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(594, 275);
            this.dgvLineItem.TabIndex = 4;
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDescription.Frozen = true;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 170;
            // 
            // txtGoodQty
            // 
            this.txtGoodQty.HeaderText = "Entry / Approved Qty";
            this.txtGoodQty.Name = "txtGoodQty";
            // 
            // PIValue
            // 
            this.PIValue.HeaderText = "Unit Value";
            this.PIValue.Name = "PIValue";
            this.PIValue.Width = 70;
            // 
            // colLcQty
            // 
            this.colLcQty.HeaderText = "LC Qty";
            this.colLcQty.Name = "colLcQty";
            this.colLcQty.Width = 70;
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "Product ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDutyAmount);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txtDocValue);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dtPIDate);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtLCValue);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.dtDutyDate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.dtDocDate);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.dtpLCDate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtLCNo);
            this.groupBox3.Controls.Add(this.txtPINo);
            this.groupBox3.Location = new System.Drawing.Point(7, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(624, 156);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LC Information";
            // 
            // txtDutyAmount
            // 
            this.txtDutyAmount.Location = new System.Drawing.Point(129, 130);
            this.txtDutyAmount.Name = "txtDutyAmount";
            this.txtDutyAmount.Size = new System.Drawing.Size(154, 20);
            this.txtDutyAmount.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(61, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Duty Amount";
            // 
            // txtDocValue
            // 
            this.txtDocValue.Location = new System.Drawing.Point(129, 103);
            this.txtDocValue.Name = "txtDocValue";
            this.txtDocValue.Size = new System.Drawing.Size(154, 20);
            this.txtDocValue.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Doc Value";
            // 
            // dtPIDate
            // 
            this.dtPIDate.Checked = false;
            this.dtPIDate.CustomFormat = "dd-MMM-yyyy";
            this.dtPIDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPIDate.Location = new System.Drawing.Point(492, 19);
            this.dtPIDate.Name = "dtPIDate";
            this.dtPIDate.ShowCheckBox = true;
            this.dtPIDate.Size = new System.Drawing.Size(117, 20);
            this.dtPIDate.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "PI Date";
            // 
            // txtLCValue
            // 
            this.txtLCValue.Location = new System.Drawing.Point(129, 77);
            this.txtLCValue.Name = "txtLCValue";
            this.txtLCValue.Size = new System.Drawing.Size(154, 20);
            this.txtLCValue.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "LC Value ($)";
            // 
            // dtDutyDate
            // 
            this.dtDutyDate.Checked = false;
            this.dtDutyDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDutyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDutyDate.Location = new System.Drawing.Point(492, 126);
            this.dtDutyDate.Name = "dtDutyDate";
            this.dtDutyDate.ShowCheckBox = true;
            this.dtDutyDate.Size = new System.Drawing.Size(117, 20);
            this.dtDutyDate.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(409, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Duty Req. Date";
            // 
            // dtDocDate
            // 
            this.dtDocDate.Checked = false;
            this.dtDocDate.CustomFormat = "dd-MMM-yyyy";
            this.dtDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDocDate.Location = new System.Drawing.Point(492, 99);
            this.dtDocDate.Name = "dtDocDate";
            this.dtDocDate.ShowCheckBox = true;
            this.dtDocDate.Size = new System.Drawing.Size(117, 20);
            this.dtDocDate.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(412, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Doc Req. Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(93, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "PI No";
            // 
            // dtpLCDate
            // 
            this.dtpLCDate.Checked = false;
            this.dtpLCDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpLCDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLCDate.Location = new System.Drawing.Point(492, 48);
            this.dtpLCDate.Name = "dtpLCDate";
            this.dtpLCDate.ShowCheckBox = true;
            this.dtpLCDate.Size = new System.Drawing.Size(117, 20);
            this.dtpLCDate.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "LC Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "LC Number";
            // 
            // txtLCNo
            // 
            this.txtLCNo.Location = new System.Drawing.Point(129, 48);
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.Size = new System.Drawing.Size(154, 20);
            this.txtLCNo.TabIndex = 1;
            // 
            // txtPINo
            // 
            this.txtPINo.Location = new System.Drawing.Point(129, 19);
            this.txtPINo.Name = "txtPINo";
            this.txtPINo.Size = new System.Drawing.Size(154, 20);
            this.txtPINo.TabIndex = 13;
            // 
            // frmPurchaseRequisition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 656);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "frmPurchaseRequisition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Requisition";
            this.Load += new System.EventHandler(this.frmPurchaseRequisition_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPONo;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTransactionRefNo;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ComboBox cmbApplyStatus;
        private System.Windows.Forms.DateTimePicker dtApprovalDate;
        private System.Windows.Forms.Label lbApprovalDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLCValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtDutyDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtDocDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpLCDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.TextBox txtPINo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPOtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtGoodQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLcQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
        private System.Windows.Forms.DateTimePicker dtPIDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDutyAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDocValue;
        private System.Windows.Forms.Label label7;
    }
}