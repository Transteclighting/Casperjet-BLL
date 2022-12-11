namespace CJ.POS
{
    partial class frmPOSOfficeItemTran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOSOfficeItemTran));
            this.dgvOfficeItem = new System.Windows.Forms.DataGridView();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbTranType = new System.Windows.Forms.ComboBox();
            this.lblTranType = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtArticleDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficeItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOfficeItem
            // 
            this.dgvOfficeItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfficeItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtArticleDetails,
            this.txtQuantity,
            this.ColProductID});
            this.dgvOfficeItem.Location = new System.Drawing.Point(12, 41);
            this.dgvOfficeItem.Name = "dgvOfficeItem";
            this.dgvOfficeItem.Size = new System.Drawing.Size(539, 242);
            this.dgvOfficeItem.TabIndex = 129;
            this.dgvOfficeItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOfficeItem_CellContentClick);
            this.dgvOfficeItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOfficeItem_CellValueChanged);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(73, 289);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(478, 21);
            this.txtRemarks.TabIndex = 130;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 131;
            this.label4.Text = "Remarks";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(369, 316);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 134;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(464, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 135;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbTranType
            // 
            this.cmbTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTranType.FormattingEnabled = true;
            this.cmbTranType.Location = new System.Drawing.Point(76, 9);
            this.cmbTranType.Name = "cmbTranType";
            this.cmbTranType.Size = new System.Drawing.Size(203, 21);
            this.cmbTranType.TabIndex = 137;
            // 
            // lblTranType
            // 
            this.lblTranType.AutoSize = true;
            this.lblTranType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranType.Location = new System.Drawing.Point(9, 12);
            this.lblTranType.Name = "lblTranType";
            this.lblTranType.Size = new System.Drawing.Size(61, 13);
            this.lblTranType.TabIndex = 136;
            this.lblTranType.Text = "TranType";
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Code";
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
            this.txtArticleDetails.HeaderText = "Article Details";
            this.txtArticleDetails.Name = "txtArticleDetails";
            this.txtArticleDetails.ReadOnly = true;
            this.txtArticleDetails.Width = 300;
            // 
            // txtQuantity
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.txtQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtQuantity.HeaderText = "Quantity";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Width = 80;
            // 
            // ColProductID
            // 
            this.ColProductID.HeaderText = "ArticleID";
            this.ColProductID.Name = "ColProductID";
            this.ColProductID.ReadOnly = true;
            this.ColProductID.Visible = false;
            // 
            // frmPOSOfficeItemTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 350);
            this.Controls.Add(this.cmbTranType);
            this.Controls.Add(this.lblTranType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dgvOfficeItem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPOSOfficeItemTran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Office ItemRequisition";
            this.Load += new System.EventHandler(this.frmPOSOfficeItemTran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfficeItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOfficeItem;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbTranType;
        private System.Windows.Forms.Label lblTranType;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArticleDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductID;
    }
}