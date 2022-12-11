namespace CJ.Win.Inventory
{
    partial class frmStockAdjustments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockAdjustments));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoNP = new System.Windows.Forms.RadioButton();
            this.rdoRSP = new System.Windows.Forms.RadioButton();
            this.rdoNSP = new System.Windows.Forms.RadioButton();
            this.rdoCP = new System.Windows.Forms.RadioButton();
            this.btnPrintTransaction = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colToWHID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbFromWarehouse = new System.Windows.Forms.ComboBox();
            this.colFromWHID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTranNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbAdjustmentType = new System.Windows.Forms.ComboBox();
            this.colTranDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGo = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.colTranNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwStockList = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdoNP);
            this.groupBox1.Controls.Add(this.rdoRSP);
            this.groupBox1.Controls.Add(this.rdoNSP);
            this.groupBox1.Controls.Add(this.rdoCP);
            this.groupBox1.Location = new System.Drawing.Point(763, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 131);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Price Option";
            // 
            // rdoNP
            // 
            this.rdoNP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoNP.AutoSize = true;
            this.rdoNP.Location = new System.Drawing.Point(15, 102);
            this.rdoNP.Name = "rdoNP";
            this.rdoNP.Size = new System.Drawing.Size(66, 17);
            this.rdoNP.TabIndex = 3;
            this.rdoNP.Text = "No Price";
            this.rdoNP.UseVisualStyleBackColor = true;
            this.rdoNP.CheckedChanged += new System.EventHandler(this.rdoNP_CheckedChanged);
            // 
            // rdoRSP
            // 
            this.rdoRSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoRSP.AutoSize = true;
            this.rdoRSP.Location = new System.Drawing.Point(16, 79);
            this.rdoRSP.Name = "rdoRSP";
            this.rdoRSP.Size = new System.Drawing.Size(47, 17);
            this.rdoRSP.TabIndex = 2;
            this.rdoRSP.Text = "RSP";
            this.rdoRSP.UseVisualStyleBackColor = true;
            this.rdoRSP.CheckedChanged += new System.EventHandler(this.rdoRSP_CheckedChanged);
            // 
            // rdoNSP
            // 
            this.rdoNSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoNSP.AutoSize = true;
            this.rdoNSP.Location = new System.Drawing.Point(15, 56);
            this.rdoNSP.Name = "rdoNSP";
            this.rdoNSP.Size = new System.Drawing.Size(47, 17);
            this.rdoNSP.TabIndex = 1;
            this.rdoNSP.Text = "NSP";
            this.rdoNSP.UseVisualStyleBackColor = true;
            this.rdoNSP.CheckedChanged += new System.EventHandler(this.rdoNSP_CheckedChanged);
            // 
            // rdoCP
            // 
            this.rdoCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoCP.AutoSize = true;
            this.rdoCP.Checked = true;
            this.rdoCP.Location = new System.Drawing.Point(15, 33);
            this.rdoCP.Name = "rdoCP";
            this.rdoCP.Size = new System.Drawing.Size(73, 17);
            this.rdoCP.TabIndex = 0;
            this.rdoCP.TabStop = true;
            this.rdoCP.Text = "Cost Price";
            this.rdoCP.UseVisualStyleBackColor = true;
            this.rdoCP.CheckedChanged += new System.EventHandler(this.rdoCP_CheckedChanged);
            // 
            // btnPrintTransaction
            // 
            this.btnPrintTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintTransaction.Location = new System.Drawing.Point(764, 253);
            this.btnPrintTransaction.Name = "btnPrintTransaction";
            this.btnPrintTransaction.Size = new System.Drawing.Size(111, 27);
            this.btnPrintTransaction.TabIndex = 17;
            this.btnPrintTransaction.Text = "Print Transaction";
            this.btnPrintTransaction.UseVisualStyleBackColor = true;
            this.btnPrintTransaction.Click += new System.EventHandler(this.btnPrintTransaction_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(365, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Adjusted From:";
            // 
            // colToWHID
            // 
            this.colToWHID.Text = "Remarks";
            this.colToWHID.Width = 250;
            // 
            // cmbFromWarehouse
            // 
            this.cmbFromWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFromWarehouse.FormattingEnabled = true;
            this.cmbFromWarehouse.Location = new System.Drawing.Point(462, 49);
            this.cmbFromWarehouse.Name = "cmbFromWarehouse";
            this.cmbFromWarehouse.Size = new System.Drawing.Size(204, 21);
            this.cmbFromWarehouse.TabIndex = 8;
            // 
            // colFromWHID
            // 
            this.colFromWHID.Text = "Adjusted Warehouse";
            this.colFromWHID.Width = 200;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(764, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 27);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Tag = "M1.19";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(463, 73);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(109, 27);
            this.btnFilter.TabIndex = 11;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Transaction Ref No :";
            // 
            // txtTranNo
            // 
            this.txtTranNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTranNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTranNo.Location = new System.Drawing.Point(149, 49);
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.Size = new System.Drawing.Size(210, 20);
            this.txtTranNo.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Adjustment Type:";
            // 
            // cmbAdjustmentType
            // 
            this.cmbAdjustmentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAdjustmentType.FormattingEnabled = true;
            this.cmbAdjustmentType.Location = new System.Drawing.Point(149, 73);
            this.cmbAdjustmentType.Name = "cmbAdjustmentType";
            this.cmbAdjustmentType.Size = new System.Drawing.Size(210, 21);
            this.cmbAdjustmentType.TabIndex = 10;
            // 
            // colTranDate
            // 
            this.colTranDate.Text = "Transaction Date";
            this.colTranDate.Width = 172;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(329, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(70, 27);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(182, 19);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(12, 19);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "From";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(210, 16);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(113, 20);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(72, 15);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(104, 20);
            this.dtFromDate.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(763, 468);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 27);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // colTranNo
            // 
            this.colTranNo.Text = "Transaction No";
            this.colTranNo.Width = 120;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(764, 220);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 27);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Tag = "M1.20";
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(764, 154);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(111, 27);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Tag = "M1.18";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(764, 121);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(111, 27);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwStockList
            // 
            this.lvwStockList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwStockList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranNo,
            this.colTranDate,
            this.colFromWHID,
            this.colToWHID});
            this.lvwStockList.FullRowSelect = true;
            this.lvwStockList.GridLines = true;
            this.lvwStockList.HideSelection = false;
            this.lvwStockList.Location = new System.Drawing.Point(15, 121);
            this.lvwStockList.MultiSelect = false;
            this.lvwStockList.Name = "lvwStockList";
            this.lvwStockList.Size = new System.Drawing.Size(722, 374);
            this.lvwStockList.TabIndex = 12;
            this.lvwStockList.UseCompatibleStateImageBehavior = false;
            this.lvwStockList.View = System.Windows.Forms.View.Details;
            this.lvwStockList.SelectedIndexChanged += new System.EventHandler(this.lvwStockList_SelectedIndexChanged);
            // 
            // frmStockAdjustments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 522);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrintTransaction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFromWarehouse);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTranNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbAdjustmentType);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwStockList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStockAdjustments";
            this.Text = "Stock Adjustments";
            this.Load += new System.EventHandler(this.frmStockAdjustments_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoNP;
        private System.Windows.Forms.RadioButton rdoRSP;
        private System.Windows.Forms.RadioButton rdoNSP;
        private System.Windows.Forms.RadioButton rdoCP;
        private System.Windows.Forms.Button btnPrintTransaction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colToWHID;
        private System.Windows.Forms.ComboBox cmbFromWarehouse;
        private System.Windows.Forms.ColumnHeader colFromWHID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTranNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbAdjustmentType;
        private System.Windows.Forms.ColumnHeader colTranDate;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colTranNo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwStockList;
    }
}