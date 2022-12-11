namespace CJ.Win.ERP
{
    partial class frmUnMappedList
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
            this.lvwCustomer = new System.Windows.Forms.ListView();
            this.colCustomerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwProduct = new System.Windows.Forms.ListView();
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lvwWarehouse = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwCustomer
            // 
            this.lvwCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCustomerCode});
            this.lvwCustomer.GridLines = true;
            this.lvwCustomer.Location = new System.Drawing.Point(12, 64);
            this.lvwCustomer.Name = "lvwCustomer";
            this.lvwCustomer.Size = new System.Drawing.Size(200, 268);
            this.lvwCustomer.TabIndex = 0;
            this.lvwCustomer.UseCompatibleStateImageBehavior = false;
            this.lvwCustomer.View = System.Windows.Forms.View.Details;
            this.lvwCustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwCustomer_KeyUp);
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Text = "Customer Code";
            this.colCustomerCode.Width = 195;
            // 
            // lvwProduct
            // 
            this.lvwProduct.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductCode});
            this.lvwProduct.GridLines = true;
            this.lvwProduct.Location = new System.Drawing.Point(218, 64);
            this.lvwProduct.Name = "lvwProduct";
            this.lvwProduct.Size = new System.Drawing.Size(200, 269);
            this.lvwProduct.TabIndex = 1;
            this.lvwProduct.UseCompatibleStateImageBehavior = false;
            this.lvwProduct.View = System.Windows.Forms.View.Details;
            this.lvwProduct.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwProduct_KeyUp);
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 190;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Product Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Customer Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(504, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Below Customers/Products/Locations are not Mapped in ERP. Please Mapped First";
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(550, 339);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(422, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Warehouse";
            // 
            // lvwWarehouse
            // 
            this.lvwWarehouse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwWarehouse.GridLines = true;
            this.lvwWarehouse.Location = new System.Drawing.Point(425, 63);
            this.lvwWarehouse.Name = "lvwWarehouse";
            this.lvwWarehouse.Size = new System.Drawing.Size(200, 269);
            this.lvwWarehouse.TabIndex = 6;
            this.lvwWarehouse.UseCompatibleStateImageBehavior = false;
            this.lvwWarehouse.View = System.Windows.Forms.View.Details;
            this.lvwWarehouse.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwWarehouse_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Warehouse Code";
            this.columnHeader1.Width = 190;
            // 
            // frmUnMappedList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 374);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvwWarehouse);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwProduct);
            this.Controls.Add(this.lvwCustomer);
            this.Name = "frmUnMappedList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUnMappedList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwCustomer;
        private System.Windows.Forms.ListView lvwProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvwWarehouse;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}