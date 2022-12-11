namespace CJ.Win
{
    partial class frmGiftVoucherTransfer
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.cmbTransferTo = new System.Windows.Forms.ComboBox();
            this.lblTransferTo = new System.Windows.Forms.Label();
            this.lvwItemList = new System.Windows.Forms.ListView();
            this.colSerialNo = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colUnitPrice = new System.Windows.Forms.ColumnHeader();
            this.colCurrentWarehouse = new System.Windows.Forms.ColumnHeader();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtToSL = new System.Windows.Forms.TextBox();
            this.txtFromSL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.ckbSelect = new System.Windows.Forms.CheckBox();
            this.txtDiscountAmt = new System.Windows.Forms.TextBox();
            this.lblDiscountAmt = new System.Windows.Forms.Label();
            this.ctlProduct1 = new CJ.Win.ctlProduct();
            this.colDiscountAmt = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 111;
            this.label9.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(127, 149);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(388, 20);
            this.txtRemarks.TabIndex = 112;
            // 
            // cmbTransferTo
            // 
            this.cmbTransferTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransferTo.FormattingEnabled = true;
            this.cmbTransferTo.Location = new System.Drawing.Point(127, 122);
            this.cmbTransferTo.Name = "cmbTransferTo";
            this.cmbTransferTo.Size = new System.Drawing.Size(242, 21);
            this.cmbTransferTo.TabIndex = 114;
            // 
            // lblTransferTo
            // 
            this.lblTransferTo.AutoSize = true;
            this.lblTransferTo.Location = new System.Drawing.Point(62, 125);
            this.lblTransferTo.Name = "lblTransferTo";
            this.lblTransferTo.Size = new System.Drawing.Size(62, 13);
            this.lblTransferTo.TabIndex = 113;
            this.lblTransferTo.Text = "Transfer To";
            // 
            // lvwItemList
            // 
            this.lvwItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItemList.CheckBoxes = true;
            this.lvwItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSerialNo,
            this.colProductName,
            this.colUnitPrice,
            this.colDiscountAmt,
            this.colCurrentWarehouse});
            this.lvwItemList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwItemList.FullRowSelect = true;
            this.lvwItemList.GridLines = true;
            this.lvwItemList.HideSelection = false;
            this.lvwItemList.Location = new System.Drawing.Point(5, 203);
            this.lvwItemList.MultiSelect = false;
            this.lvwItemList.Name = "lvwItemList";
            this.lvwItemList.Size = new System.Drawing.Size(574, 287);
            this.lvwItemList.TabIndex = 115;
            this.lvwItemList.UseCompatibleStateImageBehavior = false;
            this.lvwItemList.View = System.Windows.Forms.View.Details;
            // 
            // colSerialNo
            // 
            this.colSerialNo.Text = "Serial No.";
            this.colSerialNo.Width = 92;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 161;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.Text = "Unit Price";
            this.colUnitPrice.Width = 80;
            // 
            // colCurrentWarehouse
            // 
            this.colCurrentWarehouse.Text = "Current Warehouse";
            this.colCurrentWarehouse.Width = 223;
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransfer.Location = new System.Drawing.Point(494, 173);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(81, 28);
            this.btnTransfer.TabIndex = 116;
            this.btnTransfer.Text = "&Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 118;
            this.label3.Text = "Product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(225, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 122;
            this.label1.Text = "To";
            // 
            // txtToSL
            // 
            this.txtToSL.Location = new System.Drawing.Point(250, 69);
            this.txtToSL.Name = "txtToSL";
            this.txtToSL.Size = new System.Drawing.Size(131, 20);
            this.txtToSL.TabIndex = 121;
            // 
            // txtFromSL
            // 
            this.txtFromSL.Location = new System.Drawing.Point(90, 69);
            this.txtFromSL.Name = "txtFromSL";
            this.txtFromSL.Size = new System.Drawing.Size(131, 20);
            this.txtFromSL.TabIndex = 120;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 119;
            this.label5.Text = "Serial No";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(90, 42);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(242, 21);
            this.cmbWarehouse.TabIndex = 124;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 123;
            this.label4.Text = "Warehouse";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 97);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(482, 59);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(79, 27);
            this.btnShow.TabIndex = 126;
            this.btnShow.Text = "Get Data";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoSize = true;
            this.ckbSelect.Location = new System.Drawing.Point(6, 182);
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Size = new System.Drawing.Size(70, 17);
            this.ckbSelect.TabIndex = 163;
            this.ckbSelect.Text = "Select All";
            this.ckbSelect.UseVisualStyleBackColor = true;
            this.ckbSelect.CheckedChanged += new System.EventHandler(this.ckbSelect_CheckedChanged);
            // 
            // txtDiscountAmt
            // 
            this.txtDiscountAmt.Location = new System.Drawing.Point(127, 122);
            this.txtDiscountAmt.Name = "txtDiscountAmt";
            this.txtDiscountAmt.Size = new System.Drawing.Size(131, 20);
            this.txtDiscountAmt.TabIndex = 165;
            // 
            // lblDiscountAmt
            // 
            this.lblDiscountAmt.AutoSize = true;
            this.lblDiscountAmt.Location = new System.Drawing.Point(2, 125);
            this.lblDiscountAmt.Name = "lblDiscountAmt";
            this.lblDiscountAmt.Size = new System.Drawing.Size(124, 13);
            this.lblDiscountAmt.TabIndex = 164;
            this.lblDiscountAmt.Text = "Discount Amount @ Unit";
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(86, 12);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(435, 30);
            this.ctlProduct1.TabIndex = 117;
            // 
            // colDiscountAmt
            // 
            this.colDiscountAmt.Text = "Dis. Amt.";
            this.colDiscountAmt.Width = 69;
            // 
            // frmGiftVoucherTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 495);
            this.Controls.Add(this.txtDiscountAmt);
            this.Controls.Add(this.lblDiscountAmt);
            this.Controls.Add(this.ckbSelect);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtToSL);
            this.Controls.Add(this.txtFromSL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.lvwItemList);
            this.Controls.Add(this.cmbTransferTo);
            this.Controls.Add(this.lblTransferTo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGiftVoucherTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gift Voucher Transfer";
            this.Load += new System.EventHandler(this.frmGiftVoucherTransfer_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ComboBox cmbTransferTo;
        private System.Windows.Forms.Label lblTransferTo;
        private System.Windows.Forms.ListView lvwItemList;
        private System.Windows.Forms.ColumnHeader colSerialNo;
        private System.Windows.Forms.ColumnHeader colUnitPrice;
        private System.Windows.Forms.ColumnHeader colCurrentWarehouse;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Label label3;
        private ctlProduct ctlProduct1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtToSL;
        private System.Windows.Forms.TextBox txtFromSL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.CheckBox ckbSelect;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.TextBox txtDiscountAmt;
        private System.Windows.Forms.Label lblDiscountAmt;
        private System.Windows.Forms.ColumnHeader colDiscountAmt;
    }
}