namespace CJ.Win.CAC
{
    partial class frmCACItemSarch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACItemSarch));
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.lvwProducts = new System.Windows.Forms.ListView();
            this.colCode = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colModel = new System.Windows.Forms.ColumnHeader();
            this.colCurrentstock = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.colAG = new System.Windows.Forms.ColumnHeader();
            this.colASG = new System.Windows.Forms.ColumnHeader();
            this.colMAG = new System.Windows.Forms.ColumnHeader();
            this.colPG = new System.Windows.Forms.ColumnHeader();
            this.colBrand = new System.Windows.Forms.ColumnHeader();
            this.colCost = new System.Windows.Forms.ColumnHeader();
            this.colRSP = new System.Windows.Forms.ColumnHeader();
            this.colIsActive = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(119, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(413, 20);
            this.txtName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(119, 14);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(171, 20);
            this.txtCode.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(104, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Product Name (Like)";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(41, 18);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(72, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Product Code";
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(538, 38);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(80, 24);
            this.btnGetData.TabIndex = 6;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(296, 17);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(35, 13);
            this.lblBrand.TabIndex = 2;
            this.lblBrand.Text = "Brand";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(337, 14);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(195, 21);
            this.cmbBrand.TabIndex = 3;
            // 
            // lvwProducts
            // 
            this.lvwProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colName,
            this.colModel,
            this.colCurrentstock,
            this.colDescription,
            this.colAG,
            this.colASG,
            this.colMAG,
            this.colPG,
            this.colBrand,
            this.colCost,
            this.colRSP,
            this.colIsActive});
            this.lvwProducts.FullRowSelect = true;
            this.lvwProducts.GridLines = true;
            this.lvwProducts.Location = new System.Drawing.Point(12, 68);
            this.lvwProducts.Name = "lvwProducts";
            this.lvwProducts.Size = new System.Drawing.Size(606, 261);
            this.lvwProducts.TabIndex = 7;
            this.lvwProducts.UseCompatibleStateImageBehavior = false;
            this.lvwProducts.View = System.Windows.Forms.View.Details;
            this.lvwProducts.DoubleClick += new System.EventHandler(this.lvwProducts_DoubleClick);
            this.lvwProducts.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwProducts_ColumnClick);
            this.lvwProducts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwProducts_KeyPress);
            // 
            // colCode
            // 
            this.colCode.Text = "Product Code";
            this.colCode.Width = 78;
            // 
            // colName
            // 
            this.colName.Text = "Product Name";
            this.colName.Width = 222;
            // 
            // colModel
            // 
            this.colModel.Text = "Model";
            this.colModel.Width = 140;
            // 
            // colCurrentstock
            // 
            this.colCurrentstock.Text = "Current Stock";
            this.colCurrentstock.Width = 78;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 186;
            // 
            // colAG
            // 
            this.colAG.Text = "AG";
            // 
            // colASG
            // 
            this.colASG.Text = "ASG";
            this.colASG.Width = 63;
            // 
            // colMAG
            // 
            this.colMAG.Text = "MAG";
            this.colMAG.Width = 64;
            // 
            // colPG
            // 
            this.colPG.Text = "PG";
            this.colPG.Width = 59;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 80;
            // 
            // colCost
            // 
            this.colCost.Text = "CP";
            // 
            // colRSP
            // 
            this.colRSP.Text = "RSP";
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Is Active";
            this.colIsActive.Width = 57;
            // 
            // frmCACItemSarch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 341);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.lvwProducts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACItemSarch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCACItemSarch";
            this.Load += new System.EventHandler(this.frmCACItemSarch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.ListView lvwProducts;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colModel;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colAG;
        private System.Windows.Forms.ColumnHeader colASG;
        private System.Windows.Forms.ColumnHeader colMAG;
        private System.Windows.Forms.ColumnHeader colPG;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ColumnHeader colCost;
        private System.Windows.Forms.ColumnHeader colRSP;
        private System.Windows.Forms.ColumnHeader colCurrentstock;
    }
}