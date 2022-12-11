namespace CJ.POS
{
    partial class frmRequisitionAuthorize
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequisitionAuthorize));
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FromWH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTransitStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToWH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequisitionQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColYTDSalesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AuthorizeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAuthorizevalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtRequisitionDate = new System.Windows.Forms.DateTimePicker();
            this.cmbToWarehouse = new System.Windows.Forms.ComboBox();
            this.cmbFromWarehouse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btConfirm = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(178, 91);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(579, 20);
            this.txtRemarks.TabIndex = 7;
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.txtProductDescription,
            this.FromWH,
            this.ColTransitStock,
            this.ToWH,
            this.RequisitionQty,
            this.ColRValue,
            this.ColYTDSalesQty,
            this.ProductID,
            this.AuthorizeQty,
            this.ColAuthorizevalue});
            this.dgvLineItem.Location = new System.Drawing.Point(6, 16);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(913, 302);
            this.dgvLineItem.TabIndex = 0;
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Frozen = true;
            this.txtProductCode.HeaderText = "Product Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 80;
            // 
            // txtProductDescription
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.txtProductDescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductDescription.Frozen = true;
            this.txtProductDescription.HeaderText = "Description";
            this.txtProductDescription.Name = "txtProductDescription";
            this.txtProductDescription.ReadOnly = true;
            this.txtProductDescription.Width = 170;
            // 
            // FromWH
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.FromWH.DefaultCellStyle = dataGridViewCellStyle2;
            this.FromWH.HeaderText = "HO/Branch  Stock";
            this.FromWH.Name = "FromWH";
            this.FromWH.ReadOnly = true;
            this.FromWH.Width = 80;
            // 
            // ColTransitStock
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.ColTransitStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColTransitStock.HeaderText = "Outlet/Branch Stock";
            this.ColTransitStock.Name = "ColTransitStock";
            this.ColTransitStock.ReadOnly = true;
            this.ColTransitStock.Width = 80;
            // 
            // ToWH
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.ToWH.DefaultCellStyle = dataGridViewCellStyle4;
            this.ToWH.HeaderText = "Outlet/Branch Transit Stock";
            this.ToWH.Name = "ToWH";
            this.ToWH.ReadOnly = true;
            this.ToWH.Width = 80;
            // 
            // RequisitionQty
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            this.RequisitionQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.RequisitionQty.HeaderText = "Requisition Qty";
            this.RequisitionQty.Name = "RequisitionQty";
            this.RequisitionQty.ReadOnly = true;
            this.RequisitionQty.Width = 70;
            // 
            // ColRValue
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            this.ColRValue.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColRValue.HeaderText = "Req Value";
            this.ColRValue.Name = "ColRValue";
            this.ColRValue.ReadOnly = true;
            this.ColRValue.Width = 70;
            // 
            // ColYTDSalesQty
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            this.ColYTDSalesQty.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColYTDSalesQty.HeaderText = "YTD Sales Qty";
            this.ColYTDSalesQty.Name = "ColYTDSalesQty";
            this.ColYTDSalesQty.ReadOnly = true;
            this.ColYTDSalesQty.Width = 70;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Visible = false;
            // 
            // AuthorizeQty
            // 
            this.AuthorizeQty.HeaderText = "Authorize Qty";
            this.AuthorizeQty.Name = "AuthorizeQty";
            this.AuthorizeQty.Width = 90;
            // 
            // ColAuthorizevalue
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver;
            this.ColAuthorizevalue.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColAuthorizevalue.HeaderText = "Authorize Value";
            this.ColAuthorizevalue.Name = "ColAuthorizevalue";
            this.ColAuthorizevalue.ReadOnly = true;
            this.ColAuthorizevalue.Width = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Remarks";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtRequisitionDate);
            this.groupBox1.Controls.Add(this.cmbToWarehouse);
            this.groupBox1.Controls.Add(this.cmbFromWarehouse);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Information";
            // 
            // dtRequisitionDate
            // 
            this.dtRequisitionDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtRequisitionDate.CustomFormat = "dd-MMM-yyyy";
            this.dtRequisitionDate.Enabled = false;
            this.dtRequisitionDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtRequisitionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRequisitionDate.Location = new System.Drawing.Point(178, 14);
            this.dtRequisitionDate.Name = "dtRequisitionDate";
            this.dtRequisitionDate.Size = new System.Drawing.Size(138, 20);
            this.dtRequisitionDate.TabIndex = 1;
            // 
            // cmbToWarehouse
            // 
            this.cmbToWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbToWarehouse.Enabled = false;
            this.cmbToWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbToWarehouse.FormattingEnabled = true;
            this.cmbToWarehouse.Location = new System.Drawing.Point(178, 65);
            this.cmbToWarehouse.Name = "cmbToWarehouse";
            this.cmbToWarehouse.Size = new System.Drawing.Size(242, 21);
            this.cmbToWarehouse.TabIndex = 5;
            // 
            // cmbFromWarehouse
            // 
            this.cmbFromWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFromWarehouse.Enabled = false;
            this.cmbFromWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromWarehouse.FormattingEnabled = true;
            this.cmbFromWarehouse.Location = new System.Drawing.Point(178, 39);
            this.cmbFromWarehouse.Name = "cmbFromWarehouse";
            this.cmbFromWarehouse.Size = new System.Drawing.Size(242, 21);
            this.cmbFromWarehouse.TabIndex = 3;
            this.cmbFromWarehouse.SelectedIndexChanged += new System.EventHandler(this.cmbFromWarehouse_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Requiest Warehouse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Requisition From Warehouse";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Requisition Date";
            // 
            // btConfirm
            // 
            this.btConfirm.Location = new System.Drawing.Point(757, 462);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(75, 23);
            this.btConfirm.TabIndex = 2;
            this.btConfirm.Text = "&Confirm";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(838, 462);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 3;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvLineItem);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(1, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(924, 330);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Detail";
            // 
            // frmRequisitionAuthorize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRequisitionAuthorize";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Requisition Authorize";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtRequisitionDate;
        private System.Windows.Forms.ComboBox cmbToWarehouse;
        private System.Windows.Forms.ComboBox cmbFromWarehouse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn FromWH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTransitStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ToWH;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequisitionQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColYTDSalesQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorizeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAuthorizevalue;
    }
}