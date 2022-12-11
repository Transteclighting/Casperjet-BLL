namespace CJ.Win.BEIL
{
    partial class frmProductionLot
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.cmbWorkType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLotType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtReceiveDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvLotItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtArticleDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.lblRfNo = new System.Windows.Forms.Label();
            this.cmbRfLotNo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotItem)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(455, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ref. No:";
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(62, 11);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(162, 20);
            this.txtRefNo.TabIndex = 2;
            // 
            // cmbWorkType
            // 
            this.cmbWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkType.FormattingEnabled = true;
            this.cmbWorkType.Location = new System.Drawing.Point(380, 37);
            this.cmbWorkType.Name = "cmbWorkType";
            this.cmbWorkType.Size = new System.Drawing.Size(148, 21);
            this.cmbWorkType.TabIndex = 3;
            this.cmbWorkType.SelectedIndexChanged += new System.EventHandler(this.cmbWorkType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Work Type:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Lot Type:";
            // 
            // cmbLotType
            // 
            this.cmbLotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLotType.FormattingEnabled = true;
            this.cmbLotType.Location = new System.Drawing.Point(62, 37);
            this.cmbLotType.Name = "cmbLotType";
            this.cmbLotType.Size = new System.Drawing.Size(162, 21);
            this.cmbLotType.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Receive Date:";
            // 
            // dtReceiveDate
            // 
            this.dtReceiveDate.CustomFormat = "dd-MMM-yyyy";
            this.dtReceiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReceiveDate.Location = new System.Drawing.Point(380, 11);
            this.dtReceiveDate.Name = "dtReceiveDate";
            this.dtReceiveDate.Size = new System.Drawing.Size(148, 20);
            this.dtReceiveDate.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(374, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvLotItem
            // 
            this.dgvLotItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtArticleDetails,
            this.txtQuantity,
            this.ColProductID});
            this.dgvLotItem.Location = new System.Drawing.Point(12, 101);
            this.dgvLotItem.Name = "dgvLotItem";
            this.dgvLotItem.Size = new System.Drawing.Size(518, 167);
            this.dgvLotItem.TabIndex = 10;
            this.dgvLotItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLotItem_CellValueChanged);
            this.dgvLotItem.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLotItem_RowsRemoved);
            this.dgvLotItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLotItem_CellContentClick);
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "ProductCode";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 90;
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Width = 35;
            // 
            // txtArticleDetails
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtArticleDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtArticleDetails.HeaderText = "Product Details";
            this.txtArticleDetails.Name = "txtArticleDetails";
            this.txtArticleDetails.ReadOnly = true;
            this.txtArticleDetails.Width = 270;
            // 
            // txtQuantity
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.txtQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtQuantity.HeaderText = "Receive Qty";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Width = 80;
            // 
            // ColProductID
            // 
            this.ColProductID.HeaderText = "ProductID";
            this.ColProductID.Name = "ColProductID";
            this.ColProductID.ReadOnly = true;
            this.ColProductID.Visible = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(64, 300);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(466, 20);
            this.txtRemarks.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Remarks";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(455, 274);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(75, 20);
            this.txtTotalQty.TabIndex = 16;
            this.txtTotalQty.Text = "0";
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRfNo
            // 
            this.lblRfNo.AutoSize = true;
            this.lblRfNo.Location = new System.Drawing.Point(318, 67);
            this.lblRfNo.Name = "lblRfNo";
            this.lblRfNo.Size = new System.Drawing.Size(56, 13);
            this.lblRfNo.TabIndex = 18;
            this.lblRfNo.Text = "RefLotNo:";
            // 
            // cmbRfLotNo
            // 
            this.cmbRfLotNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRfLotNo.FormattingEnabled = true;
            this.cmbRfLotNo.Location = new System.Drawing.Point(380, 64);
            this.cmbRfLotNo.Name = "cmbRfLotNo";
            this.cmbRfLotNo.Size = new System.Drawing.Size(148, 21);
            this.cmbRfLotNo.TabIndex = 17;
            this.cmbRfLotNo.SelectedIndexChanged += new System.EventHandler(this.cmbRfLotNo_SelectedIndexChanged);
            // 
            // frmProductionLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 359);
            this.Controls.Add(this.lblRfNo);
            this.Controls.Add(this.cmbRfLotNo);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvLotItem);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtReceiveDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLotType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWorkType);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Name = "frmProductionLot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductionLot";
            this.Load += new System.EventHandler(this.frmProductionLot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.ComboBox cmbWorkType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLotType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtReceiveDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvLotItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArticleDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductID;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label lblRfNo;
        private System.Windows.Forms.ComboBox cmbRfLotNo;
    }
}