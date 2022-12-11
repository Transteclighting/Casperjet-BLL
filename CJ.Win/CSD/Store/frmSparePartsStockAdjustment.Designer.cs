namespace CJ.Win
{
    partial class frmSparePartsStockAdjustment
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
            this.dgvPartAdjustment = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbParentStore = new System.Windows.Forms.ComboBox();
            this.cmbChildStore = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.rdoAddStock = new System.Windows.Forms.RadioButton();
            this.rdoDeductStock = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbChildStoreold = new System.Windows.Forms.ComboBox();
            this.txtChildStore = new System.Windows.Forms.TextBox();
            this.TotalQty = new System.Windows.Forms.TextBox();
            this.TotalCostPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSparePartCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindParts = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtSparePartName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIssueQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnitSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SparePartID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCostPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartAdjustment)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPartAdjustment
            // 
            this.dgvPartAdjustment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPartAdjustment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartAdjustment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtSparePartCode,
            this.btnFindParts,
            this.txtSparePartName,
            this.txtCurrentStock,
            this.txtIssueQty,
            this.txtUnitSP,
            this.txtTotalPrice,
            this.SparePartID,
            this.txtCostPrice});
            this.dgvPartAdjustment.Location = new System.Drawing.Point(8, 78);
            this.dgvPartAdjustment.Name = "dgvPartAdjustment";
            this.dgvPartAdjustment.Size = new System.Drawing.Size(732, 315);
            this.dgvPartAdjustment.TabIndex = 9;
            this.dgvPartAdjustment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartAdjustment_CellContentClick);
            this.dgvPartAdjustment.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartAdjustment_CellValueChanged);
            this.dgvPartAdjustment.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPartAdjustment_RowsRemoved);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(652, 450);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 26);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(557, 450);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 26);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbParentStore
            // 
            this.cmbParentStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentStore.FormattingEnabled = true;
            this.cmbParentStore.Location = new System.Drawing.Point(98, 11);
            this.cmbParentStore.Name = "cmbParentStore";
            this.cmbParentStore.Size = new System.Drawing.Size(150, 21);
            this.cmbParentStore.TabIndex = 1;
            this.cmbParentStore.SelectedIndexChanged += new System.EventHandler(this.cmbParentStore_SelectedIndexChanged);
            // 
            // cmbChildStore
            // 
            this.cmbChildStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChildStore.FormattingEnabled = true;
            this.cmbChildStore.Location = new System.Drawing.Point(329, 11);
            this.cmbChildStore.Name = "cmbChildStore";
            this.cmbChildStore.Size = new System.Drawing.Size(166, 21);
            this.cmbChildStore.TabIndex = 3;
            this.cmbChildStore.SelectedIndexChanged += new System.EventHandler(this.cmbChildStore_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parent Store: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Child Store: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Remarks: ";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(78, 425);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(662, 20);
            this.txtRemarks.TabIndex = 11;
            // 
            // rdoAddStock
            // 
            this.rdoAddStock.AutoSize = true;
            this.rdoAddStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAddStock.Location = new System.Drawing.Point(22, 11);
            this.rdoAddStock.Name = "rdoAddStock";
            this.rdoAddStock.Size = new System.Drawing.Size(84, 17);
            this.rdoAddStock.TabIndex = 0;
            this.rdoAddStock.TabStop = true;
            this.rdoAddStock.Text = "Add Stock";
            this.rdoAddStock.UseVisualStyleBackColor = true;
            // 
            // rdoDeductStock
            // 
            this.rdoDeductStock.AutoSize = true;
            this.rdoDeductStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDeductStock.Location = new System.Drawing.Point(210, 11);
            this.rdoDeductStock.Name = "rdoDeductStock";
            this.rdoDeductStock.Size = new System.Drawing.Size(103, 17);
            this.rdoDeductStock.TabIndex = 1;
            this.rdoDeductStock.TabStop = true;
            this.rdoDeductStock.Text = "Deduct Stock";
            this.rdoDeductStock.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoDeductStock);
            this.groupBox1.Controls.Add(this.rdoAddStock);
            this.groupBox1.Location = new System.Drawing.Point(100, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 33);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Adjustment Type: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Child Store: ";
            this.label5.Visible = false;
            // 
            // cmbChildStoreold
            // 
            this.cmbChildStoreold.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChildStoreold.FormattingEnabled = true;
            this.cmbChildStoreold.Location = new System.Drawing.Point(554, 46);
            this.cmbChildStoreold.Name = "cmbChildStoreold";
            this.cmbChildStoreold.Size = new System.Drawing.Size(180, 21);
            this.cmbChildStoreold.TabIndex = 6;
            this.cmbChildStoreold.Visible = false;
            // 
            // txtChildStore
            // 
            this.txtChildStore.Location = new System.Drawing.Point(497, 46);
            this.txtChildStore.Name = "txtChildStore";
            this.txtChildStore.Size = new System.Drawing.Size(52, 20);
            this.txtChildStore.TabIndex = 5;
            this.txtChildStore.Visible = false;
            this.txtChildStore.TextChanged += new System.EventHandler(this.txtChildStore_TextChanged);
            // 
            // TotalQty
            // 
            this.TotalQty.Location = new System.Drawing.Point(598, 399);
            this.TotalQty.Name = "TotalQty";
            this.TotalQty.ReadOnly = true;
            this.TotalQty.Size = new System.Drawing.Size(59, 20);
            this.TotalQty.TabIndex = 21;
            this.TotalQty.Text = "0";
            this.TotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TotalCostPrice
            // 
            this.TotalCostPrice.Location = new System.Drawing.Point(663, 399);
            this.TotalCostPrice.Name = "TotalCostPrice";
            this.TotalCostPrice.ReadOnly = true;
            this.TotalCostPrice.Size = new System.Drawing.Size(77, 20);
            this.TotalCostPrice.TabIndex = 22;
            this.TotalCostPrice.Text = "0.00";
            this.TotalCostPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(547, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Total =";
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
            this.txtIssueQty.HeaderText = "Qty";
            this.txtIssueQty.Name = "txtIssueQty";
            this.txtIssueQty.Width = 80;
            // 
            // txtUnitSP
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUnitSP.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtUnitSP.Frozen = true;
            this.txtUnitSP.HeaderText = "Unit Cost Price";
            this.txtUnitSP.Name = "txtUnitSP";
            this.txtUnitSP.ReadOnly = true;
            this.txtUnitSP.Width = 90;
            // 
            // txtTotalPrice
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtTotalPrice.Frozen = true;
            this.txtTotalPrice.HeaderText = "Total Cost Price";
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
            this.txtCostPrice.HeaderText = "SalePrice";
            this.txtCostPrice.Name = "txtCostPrice";
            this.txtCostPrice.ReadOnly = true;
            this.txtCostPrice.Visible = false;
            // 
            // frmSparePartsStockAdjustment
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 486);
            this.Controls.Add(this.TotalQty);
            this.Controls.Add(this.TotalCostPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtChildStore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbChildStoreold);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbChildStore);
            this.Controls.Add(this.cmbParentStore);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvPartAdjustment);
            this.Name = "frmSparePartsStockAdjustment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Adjustment";
            this.Load += new System.EventHandler(this.frmSparePartsStockAdjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartAdjustment)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPartAdjustment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbParentStore;
        private System.Windows.Forms.ComboBox cmbChildStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.RadioButton rdoAddStock;
        private System.Windows.Forms.RadioButton rdoDeductStock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbChildStoreold;
        private System.Windows.Forms.TextBox txtChildStore;
        private System.Windows.Forms.TextBox TotalQty;
        private System.Windows.Forms.TextBox TotalCostPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSparePartName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIssueQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUnitSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SparePartID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCostPrice;
    }
}