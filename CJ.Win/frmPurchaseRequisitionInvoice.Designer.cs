namespace CJ.Win
{
    partial class frmPurchaseRequisitionInvoice
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
            this.dtReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.lbReceivedDate = new System.Windows.Forms.Label();
            this.dtPortArrivalDate = new System.Windows.Forms.DateTimePicker();
            this.lbPortArrivalDate = new System.Windows.Forms.Label();
            this.dtpLCInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLCInvoiceNo = new System.Windows.Forms.TextBox();
            this.dtpShipmentDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTransactionRefNo = new System.Windows.Forms.Label();
            this.cbPONo = new System.Windows.Forms.ComboBox();
            this.txtInvoiceValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLcQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dtReceivedDate
            // 
            this.dtReceivedDate.Checked = false;
            this.dtReceivedDate.CustomFormat = "dd-MMM-yyyy";
            this.dtReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceivedDate.Location = new System.Drawing.Point(478, 99);
            this.dtReceivedDate.Name = "dtReceivedDate";
            this.dtReceivedDate.ShowCheckBox = true;
            this.dtReceivedDate.Size = new System.Drawing.Size(117, 20);
            this.dtReceivedDate.TabIndex = 23;
            // 
            // lbReceivedDate
            // 
            this.lbReceivedDate.AutoSize = true;
            this.lbReceivedDate.Location = new System.Drawing.Point(395, 103);
            this.lbReceivedDate.Name = "lbReceivedDate";
            this.lbReceivedDate.Size = new System.Drawing.Size(79, 13);
            this.lbReceivedDate.TabIndex = 22;
            this.lbReceivedDate.Text = "Received Date";
            // 
            // dtPortArrivalDate
            // 
            this.dtPortArrivalDate.Checked = false;
            this.dtPortArrivalDate.CustomFormat = "dd-MMM-yyyy";
            this.dtPortArrivalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPortArrivalDate.Location = new System.Drawing.Point(478, 73);
            this.dtPortArrivalDate.Name = "dtPortArrivalDate";
            this.dtPortArrivalDate.ShowCheckBox = true;
            this.dtPortArrivalDate.Size = new System.Drawing.Size(117, 20);
            this.dtPortArrivalDate.TabIndex = 21;
            // 
            // lbPortArrivalDate
            // 
            this.lbPortArrivalDate.AutoSize = true;
            this.lbPortArrivalDate.Location = new System.Drawing.Point(393, 77);
            this.lbPortArrivalDate.Name = "lbPortArrivalDate";
            this.lbPortArrivalDate.Size = new System.Drawing.Size(84, 13);
            this.lbPortArrivalDate.TabIndex = 20;
            this.lbPortArrivalDate.Text = "Port Arrival Date";
            // 
            // dtpLCInvoiceDate
            // 
            this.dtpLCInvoiceDate.Checked = false;
            this.dtpLCInvoiceDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpLCInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLCInvoiceDate.Location = new System.Drawing.Point(478, 19);
            this.dtpLCInvoiceDate.Name = "dtpLCInvoiceDate";
            this.dtpLCInvoiceDate.ShowCheckBox = true;
            this.dtpLCInvoiceDate.Size = new System.Drawing.Size(140, 20);
            this.dtpLCInvoiceDate.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Invoice Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Invoice No";
            // 
            // txtLCInvoiceNo
            // 
            this.txtLCInvoiceNo.Location = new System.Drawing.Point(99, 61);
            this.txtLCInvoiceNo.Name = "txtLCInvoiceNo";
            this.txtLCInvoiceNo.Size = new System.Drawing.Size(154, 20);
            this.txtLCInvoiceNo.TabIndex = 25;
            // 
            // dtpShipmentDate
            // 
            this.dtpShipmentDate.Checked = false;
            this.dtpShipmentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpShipmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShipmentDate.Location = new System.Drawing.Point(478, 47);
            this.dtpShipmentDate.Name = "dtpShipmentDate";
            this.dtpShipmentDate.ShowCheckBox = true;
            this.dtpShipmentDate.Size = new System.Drawing.Size(140, 20);
            this.dtpShipmentDate.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(398, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Shipment Date";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInvoiceValue);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblTransactionRefNo);
            this.groupBox2.Controls.Add(this.dtpLCInvoiceDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dtpShipmentDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbPONo);
            this.groupBox2.Controls.Add(this.txtLCInvoiceNo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtReceivedDate);
            this.groupBox2.Controls.Add(this.lbPortArrivalDate);
            this.groupBox2.Controls.Add(this.lbReceivedDate);
            this.groupBox2.Controls.Add(this.dtPortArrivalDate);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(715, 135);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Basic Information";
            // 
            // lblTransactionRefNo
            // 
            this.lblTransactionRefNo.AutoSize = true;
            this.lblTransactionRefNo.Location = new System.Drawing.Point(57, 33);
            this.lblTransactionRefNo.Name = "lblTransactionRefNo";
            this.lblTransactionRefNo.Size = new System.Drawing.Size(39, 13);
            this.lblTransactionRefNo.TabIndex = 33;
            this.lblTransactionRefNo.Text = "PO No";
            // 
            // cbPONo
            // 
            this.cbPONo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPONo.FormattingEnabled = true;
            this.cbPONo.Location = new System.Drawing.Point(99, 30);
            this.cbPONo.Name = "cbPONo";
            this.cbPONo.Size = new System.Drawing.Size(121, 21);
            this.cbPONo.TabIndex = 34;
            // 
            // txtInvoiceValue
            // 
            this.txtInvoiceValue.Location = new System.Drawing.Point(99, 87);
            this.txtInvoiceValue.Name = "txtInvoiceValue";
            this.txtInvoiceValue.Size = new System.Drawing.Size(154, 20);
            this.txtInvoiceValue.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Invoice Value ($)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLineItem);
            this.groupBox1.Location = new System.Drawing.Point(12, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 386);
            this.groupBox1.TabIndex = 33;
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
            this.PIValue,
            this.colLcQty,
            this.colInvoiceQty,
            this.colInvoiceValue,
            this.colProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(11, 20);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(689, 347);
            this.dgvLineItem.TabIndex = 4;
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
            // colInvoiceQty
            // 
            this.colInvoiceQty.HeaderText = "Invoice Qty";
            this.colInvoiceQty.Name = "colInvoiceQty";
            // 
            // colInvoiceValue
            // 
            this.colInvoiceValue.HeaderText = "Invoice Value";
            this.colInvoiceValue.Name = "colInvoiceValue";
            // 
            // colProductID
            // 
            this.colProductID.HeaderText = "Product ID";
            this.colProductID.Name = "colProductID";
            this.colProductID.ReadOnly = true;
            this.colProductID.Visible = false;
            // 
            // frmPurchaseRequisitionInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 563);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmPurchaseRequisitionInvoice";
            this.Text = "Purchase Requisition Invoice";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtReceivedDate;
        private System.Windows.Forms.Label lbReceivedDate;
        private System.Windows.Forms.DateTimePicker dtPortArrivalDate;
        private System.Windows.Forms.Label lbPortArrivalDate;
        private System.Windows.Forms.DateTimePicker dtpLCInvoiceDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLCInvoiceNo;
        private System.Windows.Forms.DateTimePicker dtpShipmentDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblTransactionRefNo;
        private System.Windows.Forms.ComboBox cbPONo;
        private System.Windows.Forms.TextBox txtInvoiceValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLcQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductID;
    }
}