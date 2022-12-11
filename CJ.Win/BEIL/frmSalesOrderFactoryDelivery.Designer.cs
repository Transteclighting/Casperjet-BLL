namespace CJ.Win.BEIL
{
    partial class frmSalesOrderFactoryDelivery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesOrderFactoryDelivery));
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.dgvSalesOrderDelivery = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdeliveredTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOrdertotal = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtdeliveredQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDeliveryQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesOrderDelivery)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Enabled = false;
            this.label11.Location = new System.Drawing.Point(14, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Order No#:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.Location = new System.Drawing.Point(20, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Customer:";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Enabled = false;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(80, 12);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(387, 21);
            this.cmbCustomer.TabIndex = 1;
            // 
            // dgvSalesOrderDelivery
            // 
            this.dgvSalesOrderDelivery.AllowUserToAddRows = false;
            this.dgvSalesOrderDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesOrderDelivery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductName,
            this.txtOrderQty,
            this.txtdeliveredQty,
            this.txtDeliveryQty,
            this.ProductID,
            this.ID});
            this.dgvSalesOrderDelivery.Location = new System.Drawing.Point(12, 65);
            this.dgvSalesOrderDelivery.Name = "dgvSalesOrderDelivery";
            this.dgvSalesOrderDelivery.Size = new System.Drawing.Size(535, 207);
            this.dgvSalesOrderDelivery.TabIndex = 4;
            this.dgvSalesOrderDelivery.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSalesOrderDelivery_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 212;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Order Qty";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Delivered Qty";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Delivery Qty";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Enabled = false;
            this.txtOrderNo.Location = new System.Drawing.Point(80, 39);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(172, 20);
            this.txtOrderNo.TabIndex = 3;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(17, 281);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(52, 13);
            this.lblRemarks.TabIndex = 5;
            this.lblRemarks.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(75, 278);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(472, 20);
            this.txtRemarks.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(392, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(472, 305);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Delivered Total";
            this.label1.Visible = false;
            // 
            // txtdeliveredTotal
            // 
            this.txtdeliveredTotal.Location = new System.Drawing.Point(302, 306);
            this.txtdeliveredTotal.Name = "txtdeliveredTotal";
            this.txtdeliveredTotal.ReadOnly = true;
            this.txtdeliveredTotal.Size = new System.Drawing.Size(84, 20);
            this.txtdeliveredTotal.TabIndex = 10;
            this.txtdeliveredTotal.Text = "0.00";
            this.txtdeliveredTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtdeliveredTotal.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(61, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Order Total";
            this.label10.Visible = false;
            // 
            // txtOrdertotal
            // 
            this.txtOrdertotal.Location = new System.Drawing.Point(127, 308);
            this.txtOrdertotal.Name = "txtOrdertotal";
            this.txtOrdertotal.ReadOnly = true;
            this.txtOrdertotal.Size = new System.Drawing.Size(84, 20);
            this.txtOrdertotal.TabIndex = 8;
            this.txtOrdertotal.Text = "0.00";
            this.txtOrdertotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOrdertotal.Visible = false;
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            // 
            // txtProductName
            // 
            this.txtProductName.HeaderText = "Product Name";
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Width = 212;
            // 
            // txtOrderQty
            // 
            this.txtOrderQty.HeaderText = "Order Qty";
            this.txtOrderQty.Name = "txtOrderQty";
            this.txtOrderQty.ReadOnly = true;
            this.txtOrderQty.Width = 60;
            // 
            // txtdeliveredQty
            // 
            this.txtdeliveredQty.HeaderText = "Delivered Qty";
            this.txtdeliveredQty.Name = "txtdeliveredQty";
            this.txtdeliveredQty.ReadOnly = true;
            this.txtdeliveredQty.Width = 60;
            // 
            // txtDeliveryQty
            // 
            this.txtDeliveryQty.HeaderText = "Delivery Qty";
            this.txtDeliveryQty.Name = "txtDeliveryQty";
            this.txtDeliveryQty.Width = 60;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // frmSalesOrderFactoryDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 340);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdeliveredTotal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtOrdertotal);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.dgvSalesOrderDelivery);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtOrderNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalesOrderFactoryDelivery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Order Factory Delivery";
            this.Load += new System.EventHandler(this.frmSalesOrderFactoryDelivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesOrderDelivery)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.DataGridView dgvSalesOrderDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdeliveredTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtOrdertotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtdeliveredQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDeliveryQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}