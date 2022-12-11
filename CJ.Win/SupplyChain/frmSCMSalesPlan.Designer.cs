namespace CJ.Win.SupplyChain
{
    partial class frmSCMSalesPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtPlanMonth = new System.Windows.Forms.DateTimePicker();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequisitionQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPlanMonth
            // 
            this.dtPlanMonth.CustomFormat = "MMM-yyyy";
            this.dtPlanMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPlanMonth.Location = new System.Drawing.Point(84, 12);
            this.dtPlanMonth.Name = "dtPlanMonth";
            this.dtPlanMonth.Size = new System.Drawing.Size(87, 20);
            this.dtPlanMonth.TabIndex = 0;
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(211, 11);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(121, 21);
            this.cmbASG.TabIndex = 1;
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(382, 11);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(121, 21);
            this.cmbBrand.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Plan Month:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ASG:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Brand:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(528, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 26);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.AllowUserToAddRows = false;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductDescription,
            this.colUnitPrice,
            this.RequisitionQty,
            this.CValue,
            this.ProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(9, 44);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(599, 325);
            this.dgvLineItem.TabIndex = 31;
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            this.dgvLineItem.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLineItem_RowsRemoved);
            // 
            // txtProductCode
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            this.txtProductCode.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.ReadOnly = true;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 200;
            // 
            // colUnitPrice
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            this.colUnitPrice.DefaultCellStyle = dataGridViewCellStyle7;
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            this.colUnitPrice.Width = 90;
            // 
            // RequisitionQty
            // 
            this.RequisitionQty.HeaderText = "Plan Qty";
            this.RequisitionQty.Name = "RequisitionQty";
            this.RequisitionQty.Width = 70;
            // 
            // CValue
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            this.CValue.DefaultCellStyle = dataGridViewCellStyle8;
            this.CValue.HeaderText = "Total Value";
            this.CValue.Name = "CValue";
            this.CValue.Width = 95;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(446, 404);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 26);
            this.btnSave.TabIndex = 32;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(528, 404);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 26);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(438, 375);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(72, 20);
            this.txtTotal.TabIndex = 34;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Total:";
            // 
            // frmSCMSalesPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 431);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.dtPlanMonth);
            this.Name = "frmSCMSalesPlan";
            this.Text = "frmSCMSalesPlan";
            this.Load += new System.EventHandler(this.frmSCMSalesPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPlanMonth;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequisitionQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn CValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label4;
    }
}