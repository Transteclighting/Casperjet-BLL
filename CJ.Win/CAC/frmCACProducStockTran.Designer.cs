namespace CJ.Win.CAC
{
    partial class frmCACProducStockTran
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACProducStockTran));
            this.dgvCACItem = new System.Windows.Forms.DataGridView();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblTransactionRefNo = new System.Windows.Forms.Label();
            this.txtTransationRef = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLCNo = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtArticleDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCACItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCACItem
            // 
            this.dgvCACItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCACItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtArticleDetails,
            this.txtCP,
            this.txtQuantity,
            this.txtRemark,
            this.ColProductID});
            this.dgvCACItem.Location = new System.Drawing.Point(11, 67);
            this.dgvCACItem.Name = "dgvCACItem";
            this.dgvCACItem.Size = new System.Drawing.Size(720, 220);
            this.dgvCACItem.TabIndex = 2;
            this.dgvCACItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCACItem_CellContentClick);
            this.dgvCACItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCACItem_CellValueChanged);
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Width = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(63, 293);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(668, 20);
            this.txtRemarks.TabIndex = 4;
            // 
            // lblTransactionRefNo
            // 
            this.lblTransactionRefNo.AutoSize = true;
            this.lblTransactionRefNo.Location = new System.Drawing.Point(11, 42);
            this.lblTransactionRefNo.Name = "lblTransactionRefNo";
            this.lblTransactionRefNo.Size = new System.Drawing.Size(56, 13);
            this.lblTransactionRefNo.TabIndex = 0;
            this.lblTransactionRefNo.Text = "Tran No #";
            // 
            // txtTransationRef
            // 
            this.txtTransationRef.Location = new System.Drawing.Point(73, 38);
            this.txtTransationRef.Name = "txtTransationRef";
            this.txtTransationRef.Size = new System.Drawing.Size(184, 20);
            this.txtTransationRef.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(656, 319);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(575, 319);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "L/C No #";
            // 
            // txtLCNo
            // 
            this.txtLCNo.Location = new System.Drawing.Point(73, 12);
            this.txtLCNo.Name = "txtLCNo";
            this.txtLCNo.Size = new System.Drawing.Size(184, 20);
            this.txtLCNo.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Details";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "CP";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 240;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "ProductID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 80;
            // 
            // txtArticleDetails
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtArticleDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtArticleDetails.HeaderText = "Product Details";
            this.txtArticleDetails.Name = "txtArticleDetails";
            this.txtArticleDetails.ReadOnly = true;
            this.txtArticleDetails.Width = 200;
            // 
            // txtCP
            // 
            this.txtCP.HeaderText = "CP";
            this.txtCP.Name = "txtCP";
            this.txtCP.ReadOnly = true;
            this.txtCP.Width = 60;
            // 
            // txtQuantity
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.txtQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtQuantity.HeaderText = "Quantity";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Width = 60;
            // 
            // txtRemark
            // 
            this.txtRemark.HeaderText = "Remarks";
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Width = 240;
            // 
            // ColProductID
            // 
            this.ColProductID.HeaderText = "ProductID";
            this.ColProductID.Name = "ColProductID";
            this.ColProductID.ReadOnly = true;
            this.ColProductID.Visible = false;
            // 
            // frmCACProducStockTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 352);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLCNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTransactionRefNo);
            this.Controls.Add(this.txtTransationRef);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dgvCACItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACProducStockTran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCACProducStockTran";
            this.Load += new System.EventHandler(this.frmCACProducStockTran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCACItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCACItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblTransactionRefNo;
        private System.Windows.Forms.TextBox txtTransationRef;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArticleDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCP;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLCNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}