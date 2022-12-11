namespace CJ.Win.Replace_Management
{
    partial class frmClaimReceive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClaimReceive));
            this.cmbSubClaim = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClaimNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtClaimMonth = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvClaimItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtArticleDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtClaimDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaimItem)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSubClaim
            // 
            this.cmbSubClaim.FormattingEnabled = true;
            this.cmbSubClaim.Location = new System.Drawing.Point(84, 38);
            this.cmbSubClaim.Name = "cmbSubClaim";
            this.cmbSubClaim.Size = new System.Drawing.Size(196, 21);
            this.cmbSubClaim.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Claim No:";
            // 
            // txtClaimNo
            // 
            this.txtClaimNo.Location = new System.Drawing.Point(84, 12);
            this.txtClaimNo.Name = "txtClaimNo";
            this.txtClaimNo.Size = new System.Drawing.Size(196, 20);
            this.txtClaimNo.TabIndex = 1;
            this.txtClaimNo.TextChanged += new System.EventHandler(this.txtClaimNo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sub Claim No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Customer:";
            // 
            // dtClaimMonth
            // 
            this.dtClaimMonth.CustomFormat = "MMM-yyyy";
            this.dtClaimMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtClaimMonth.Location = new System.Drawing.Point(356, 12);
            this.dtClaimMonth.Name = "dtClaimMonth";
            this.dtClaimMonth.Size = new System.Drawing.Size(152, 20);
            this.dtClaimMonth.TabIndex = 3;
            this.dtClaimMonth.Value = new System.DateTime(2017, 10, 16, 13, 54, 31, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Claim Month:";
            // 
            // dgvClaimItem
            // 
            this.dgvClaimItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClaimItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtArticleDetails,
            this.txtPrice,
            this.txtQuantity,
            this.ColProductID});
            this.dgvClaimItem.Location = new System.Drawing.Point(12, 100);
            this.dgvClaimItem.Name = "dgvClaimItem";
            this.dgvClaimItem.Size = new System.Drawing.Size(538, 320);
            this.dgvClaimItem.TabIndex = 10;
            this.dgvClaimItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClaimItem_CellValueChanged);
            this.dgvClaimItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClaimItem_CellContentClick);
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 80;
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Width = 35;
            // 
            // txtArticleDetails
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtArticleDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtArticleDetails.HeaderText = "Product Details";
            this.txtArticleDetails.Name = "txtArticleDetails";
            this.txtArticleDetails.ReadOnly = true;
            this.txtArticleDetails.Width = 240;
            // 
            // txtPrice
            // 
            this.txtPrice.HeaderText = "Price";
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Width = 70;
            // 
            // txtQuantity
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.txtQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtQuantity.HeaderText = "Quantity";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Width = 70;
            // 
            // ColProductID
            // 
            this.ColProductID.HeaderText = "ProductID";
            this.ColProductID.Name = "ColProductID";
            this.ColProductID.ReadOnly = true;
            this.ColProductID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(393, 429);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(77, 65);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(438, 29);
            this.ctlCustomer1.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(475, 429);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 24);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Claim Date:";
            // 
            // dtClaimDate
            // 
            this.dtClaimDate.CustomFormat = "dd-MMM-yyyy";
            this.dtClaimDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtClaimDate.Location = new System.Drawing.Point(356, 38);
            this.dtClaimDate.Name = "dtClaimDate";
            this.dtClaimDate.Size = new System.Drawing.Size(152, 20);
            this.dtClaimDate.TabIndex = 7;
            this.dtClaimDate.Value = new System.DateTime(2017, 10, 16, 13, 54, 31, 0);
            // 
            // frmClaimReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 461);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtClaimDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvClaimItem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtClaimMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtClaimNo);
            this.Controls.Add(this.cmbSubClaim);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClaimReceive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replacement Claim Receive";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClaimItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSubClaim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClaimNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtClaimMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvClaimItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArticleDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductID;
        private System.Windows.Forms.Button btnSave;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtClaimDate;
    }
}