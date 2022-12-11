namespace CJ.Win.Claim
{
    partial class frmReengineeredStockTran
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
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackingQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtTransactionDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTransactionRefNo = new System.Windows.Forms.Label();
            this.txtTransationNo = new System.Windows.Forms.TextBox();
            this.rdbPLS = new System.Windows.Forms.RadioButton();
            this.rdbRSL = new System.Windows.Forms.RadioButton();
            this.btClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBatchNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(553, 292);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Add";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDescription,
            this.txtQuantity,
            this.currentStock,
            this.PackingQty,
            this.ColProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(5, 79);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(704, 211);
            this.dgvLineItem.TabIndex = 25;
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductCode.Frozen = true;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.Frozen = true;
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Width = 35;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDescription.Frozen = true;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 250;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Frozen = true;
            this.txtQuantity.HeaderText = "Quantity";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Width = 75;
            // 
            // currentStock
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.currentStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.currentStock.Frozen = true;
            this.currentStock.HeaderText = "CurrentStock";
            this.currentStock.Name = "currentStock";
            this.currentStock.ReadOnly = true;
            // 
            // PackingQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PackingQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.PackingQty.Frozen = true;
            this.PackingQty.HeaderText = "Packing Qty";
            this.PackingQty.Name = "PackingQty";
            this.PackingQty.ReadOnly = true;
            // 
            // ColProductID
            // 
            this.ColProductID.HeaderText = "ProductID";
            this.ColProductID.Name = "ColProductID";
            this.ColProductID.ReadOnly = true;
            this.ColProductID.Visible = false;
            // 
            // dtTransactionDate
            // 
            this.dtTransactionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtTransactionDate.Enabled = false;
            this.dtTransactionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTransactionDate.Location = new System.Drawing.Point(95, 29);
            this.dtTransactionDate.Name = "dtTransactionDate";
            this.dtTransactionDate.Size = new System.Drawing.Size(92, 20);
            this.dtTransactionDate.TabIndex = 24;
            this.dtTransactionDate.Tag = "M1.21";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Transaction Date:";
            // 
            // lblTransactionRefNo
            // 
            this.lblTransactionRefNo.AutoSize = true;
            this.lblTransactionRefNo.Location = new System.Drawing.Point(11, 6);
            this.lblTransactionRefNo.Name = "lblTransactionRefNo";
            this.lblTransactionRefNo.Size = new System.Drawing.Size(83, 13);
            this.lblTransactionRefNo.TabIndex = 21;
            this.lblTransactionRefNo.Text = "Transaction No:";
            // 
            // txtTransationNo
            // 
            this.txtTransationNo.Location = new System.Drawing.Point(95, 3);
            this.txtTransationNo.Name = "txtTransationNo";
            this.txtTransationNo.Size = new System.Drawing.Size(122, 20);
            this.txtTransationNo.TabIndex = 22;
            // 
            // rdbPLS
            // 
            this.rdbPLS.AutoSize = true;
            this.rdbPLS.Checked = true;
            this.rdbPLS.Location = new System.Drawing.Point(377, 33);
            this.rdbPLS.Name = "rdbPLS";
            this.rdbPLS.Size = new System.Drawing.Size(88, 17);
            this.rdbPLS.TabIndex = 28;
            this.rdbPLS.TabStop = true;
            this.rdbPLS.Text = "PSL Receive";
            this.rdbPLS.UseVisualStyleBackColor = true;
            this.rdbPLS.CheckedChanged += new System.EventHandler(this.rdbTransfer_CheckedChanged);
            // 
            // rdbRSL
            // 
            this.rdbRSL.AutoSize = true;
            this.rdbRSL.Location = new System.Drawing.Point(478, 33);
            this.rdbRSL.Name = "rdbRSL";
            this.rdbRSL.Size = new System.Drawing.Size(89, 17);
            this.rdbRSL.TabIndex = 29;
            this.rdbRSL.Text = "RSL Receive";
            this.rdbRSL.UseVisualStyleBackColor = true;
            this.rdbRSL.CheckedChanged += new System.EventHandler(this.rdbDeduct_CheckedChanged);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(634, 292);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 148;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(319, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 149;
            this.label1.Text = "Batch No:";
            // 
            // txtBatchNo
            // 
            this.txtBatchNo.Location = new System.Drawing.Point(377, 3);
            this.txtBatchNo.Name = "txtBatchNo";
            this.txtBatchNo.Size = new System.Drawing.Size(122, 20);
            this.txtBatchNo.TabIndex = 150;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 151;
            this.label3.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(95, 55);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(614, 20);
            this.txtRemarks.TabIndex = 152;
            // 
            // frmReengineeredStockTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 318);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBatchNo);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.rdbRSL);
            this.Controls.Add(this.rdbPLS);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.dtTransactionDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTransactionRefNo);
            this.Controls.Add(this.txtTransationNo);
            this.Name = "frmReengineeredStockTran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Receive (PSL & RSL)";
            this.Load += new System.EventHandler(this.frmReengineeredStockTran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackingQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductID;
        private System.Windows.Forms.DateTimePicker dtTransactionDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTransactionRefNo;
        private System.Windows.Forms.TextBox txtTransationNo;
        private System.Windows.Forms.RadioButton rdbPLS;
        private System.Windows.Forms.RadioButton rdbRSL;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBatchNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemarks;
    }
}