namespace CJ.Win.CSD
{
    partial class frmProductSearch
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
            this.lvwProductSearch = new System.Windows.Forms.ListView();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colASGName = new System.Windows.Forms.ColumnHeader();
            this.colMAGName = new System.Windows.Forms.ColumnHeader();
            this.colBrand = new System.Windows.Forms.ColumnHeader();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwProductSearch
            // 
            this.lvwProductSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductCode,
            this.colProductName,
            this.colASGName,
            this.colMAGName,
            this.colBrand});
            this.lvwProductSearch.FullRowSelect = true;
            this.lvwProductSearch.GridLines = true;
            this.lvwProductSearch.Location = new System.Drawing.Point(12, 54);
            this.lvwProductSearch.Name = "lvwProductSearch";
            this.lvwProductSearch.Size = new System.Drawing.Size(597, 223);
            this.lvwProductSearch.TabIndex = 1;
            this.lvwProductSearch.UseCompatibleStateImageBehavior = false;
            this.lvwProductSearch.View = System.Windows.Forms.View.Details;
            this.lvwProductSearch.DoubleClick += new System.EventHandler(this.lvwProductSearch_DoubleClick);
            this.lvwProductSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwProductSearch_KeyPress);
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 85;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 234;
            // 
            // colASGName
            // 
            this.colASGName.Text = "ASG Name";
            this.colASGName.Width = 88;
            // 
            // colMAGName
            // 
            this.colMAGName.Text = "MAG Name";
            this.colMAGName.Width = 91;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 83;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(519, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(105, 31);
            this.btnClear.TabIndex = 160;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.Location = new System.Drawing.Point(14, 15);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(84, 13);
            this.lblProductCode.TabIndex = 159;
            this.lblProductCode.Text = "Product Code";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(302, 12);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(196, 20);
            this.txtProductName.TabIndex = 158;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(209, 15);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(87, 13);
            this.lblProductName.TabIndex = 157;
            this.lblProductName.Text = "Product Name";
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(104, 12);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(88, 20);
            this.txtProductCode.TabIndex = 156;
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(519, 286);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 161;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmProductSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 322);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblProductCode);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.txtProductCode);
            this.Controls.Add(this.lvwProductSearch);
            this.Name = "frmProductSearch";
            this.Text = "Product Search";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmProductSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwProductSearch;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colASGName;
        private System.Windows.Forms.ColumnHeader colMAGName;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Button btnClose;
    }
}