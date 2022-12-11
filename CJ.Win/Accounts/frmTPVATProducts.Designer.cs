namespace CJ.Win.Accounts
{
    partial class frmTPVATProducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTPVATProducts));
            this.lblProduct = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnADD = new System.Windows.Forms.Button();
            this.btnStatusUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwTPVATProduct = new System.Windows.Forms.ListView();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colMAGName = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.ctlProducts1 = new CJ.Win.Control.ctlProducts();
            this.SuspendLayout();
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(13, 14);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 13);
            this.lblProduct.TabIndex = 1;
            this.lblProduct.Text = "Product";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(476, 7);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 25);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnADD
            // 
            this.btnADD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnADD.Location = new System.Drawing.Point(557, 39);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(86, 27);
            this.btnADD.TabIndex = 4;
            this.btnADD.Text = "Add";
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // btnStatusUpdate
            // 
            this.btnStatusUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatusUpdate.Location = new System.Drawing.Point(557, 68);
            this.btnStatusUpdate.Name = "btnStatusUpdate";
            this.btnStatusUpdate.Size = new System.Drawing.Size(86, 27);
            this.btnStatusUpdate.TabIndex = 5;
            this.btnStatusUpdate.Text = "Status Update";
            this.btnStatusUpdate.UseVisualStyleBackColor = true;
            this.btnStatusUpdate.Click += new System.EventHandler(this.btnStatusUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(557, 208);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwTPVATProduct
            // 
            this.lvwTPVATProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTPVATProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductCode,
            this.colProductName,
            this.colMAGName,
            this.colStatus});
            this.lvwTPVATProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwTPVATProduct.FullRowSelect = true;
            this.lvwTPVATProduct.GridLines = true;
            this.lvwTPVATProduct.HideSelection = false;
            this.lvwTPVATProduct.Location = new System.Drawing.Point(16, 41);
            this.lvwTPVATProduct.MultiSelect = false;
            this.lvwTPVATProduct.Name = "lvwTPVATProduct";
            this.lvwTPVATProduct.Size = new System.Drawing.Size(535, 194);
            this.lvwTPVATProduct.TabIndex = 7;
            this.lvwTPVATProduct.UseCompatibleStateImageBehavior = false;
            this.lvwTPVATProduct.View = System.Windows.Forms.View.Details;
            this.lvwTPVATProduct.SelectedIndexChanged += new System.EventHandler(this.lvwTPVATProduct_SelectedIndexChanged);
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 80;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 250;
            // 
            // colMAGName
            // 
            this.colMAGName.Text = "MAG";
            this.colMAGName.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 70;
            // 
            // ctlProducts1
            // 
            this.ctlProducts1.Location = new System.Drawing.Point(59, 10);
            this.ctlProducts1.Name = "ctlProducts1";
            this.ctlProducts1.Size = new System.Drawing.Size(414, 25);
            this.ctlProducts1.TabIndex = 8;
            // 
            // frmTPVATProducts
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 247);
            this.Controls.Add(this.ctlProducts1);
            this.Controls.Add(this.lvwTPVATProduct);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStatusUpdate);
            this.Controls.Add(this.btnADD);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lblProduct);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTPVATProducts";
            this.Text = "TPVAT Products";
            this.Load += new System.EventHandler(this.frmTPVATProducts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnADD;
        private System.Windows.Forms.Button btnStatusUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwTPVATProduct;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colMAGName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private CJ.Win.Control.ctlProducts ctlProducts1;
    }
}