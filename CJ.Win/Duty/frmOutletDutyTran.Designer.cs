namespace CJ.Win.Duty
{
    partial class frmOutletDutyTran
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutletDutyTran));
            this.label9 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDocNo = new System.Windows.Forms.TextBox();
            this.lvwTranList = new System.Windows.Forms.ListView();
            this.colShowroomCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChallanType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChallanNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colChallanDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoiceDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConsumerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConsumerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoiceAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDutyAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbChallanType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtFromVATChallanNo = new System.Windows.Forms.TextBox();
            this.lbVatNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btVatChallanPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(317, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Warehouse :";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(398, 77);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(198, 23);
            this.cmbWarehouse.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Document No:";
            // 
            // txtDocNo
            // 
            this.txtDocNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDocNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNo.Location = new System.Drawing.Point(143, 76);
            this.txtDocNo.Name = "txtDocNo";
            this.txtDocNo.Size = new System.Drawing.Size(133, 23);
            this.txtDocNo.TabIndex = 2;
            // 
            // lvwTranList
            // 
            this.lvwTranList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTranList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShowroomCode,
            this.colChallanType,
            this.colChallanNo,
            this.colChallanDate,
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colConsumerCode,
            this.colConsumerName,
            this.colInvoiceAmount,
            this.colDutyAmount,
            this.colRemarks});
            this.lvwTranList.FullRowSelect = true;
            this.lvwTranList.GridLines = true;
            this.lvwTranList.HideSelection = false;
            this.lvwTranList.Location = new System.Drawing.Point(15, 167);
            this.lvwTranList.Name = "lvwTranList";
            this.lvwTranList.Size = new System.Drawing.Size(888, 320);
            this.lvwTranList.TabIndex = 11;
            this.lvwTranList.UseCompatibleStateImageBehavior = false;
            this.lvwTranList.View = System.Windows.Forms.View.Details;
            // 
            // colShowroomCode
            // 
            this.colShowroomCode.Text = "Showroom Code";
            this.colShowroomCode.Width = 100;
            // 
            // colChallanType
            // 
            this.colChallanType.Text = "Challan Type";
            this.colChallanType.Width = 100;
            // 
            // colChallanNo
            // 
            this.colChallanNo.Text = "Challan No";
            this.colChallanNo.Width = 100;
            // 
            // colChallanDate
            // 
            this.colChallanDate.Text = "Challan Date";
            this.colChallanDate.Width = 100;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice#";
            this.colInvoiceNo.Width = 96;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Text = "Invoice Date";
            this.colInvoiceDate.Width = 94;
            // 
            // colConsumerCode
            // 
            this.colConsumerCode.Text = "CustomerCode";
            this.colConsumerCode.Width = 100;
            // 
            // colConsumerName
            // 
            this.colConsumerName.Text = "Consumer Name";
            this.colConsumerName.Width = 150;
            // 
            // colInvoiceAmount
            // 
            this.colInvoiceAmount.Text = "Inv. Amount";
            this.colInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInvoiceAmount.Width = 80;
            // 
            // colDutyAmount
            // 
            this.colDutyAmount.Text = "Duty Amount";
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 300;
            // 
            // cmbChallanType
            // 
            this.cmbChallanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChallanType.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChallanType.FormattingEnabled = true;
            this.cmbChallanType.Items.AddRange(new object[] {
            "<ALL>",
            "Mushak 11",
            "Mushak 11(Ka)"});
            this.cmbChallanType.Location = new System.Drawing.Point(398, 106);
            this.cmbChallanType.Name = "cmbChallanType";
            this.cmbChallanType.Size = new System.Drawing.Size(198, 23);
            this.cmbChallanType.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(282, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "VAT Challan Type :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "Customer Name like :";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(143, 134);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(453, 23);
            this.txtCustomerName.TabIndex = 10;
            // 
            // txtFromVATChallanNo
            // 
            this.txtFromVATChallanNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFromVATChallanNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFromVATChallanNo.Location = new System.Drawing.Point(143, 105);
            this.txtFromVATChallanNo.Name = "txtFromVATChallanNo";
            this.txtFromVATChallanNo.Size = new System.Drawing.Size(133, 23);
            this.txtFromVATChallanNo.TabIndex = 6;
            // 
            // lbVatNo
            // 
            this.lbVatNo.AutoSize = true;
            this.lbVatNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVatNo.Location = new System.Drawing.Point(53, 109);
            this.lbVatNo.Name = "lbVatNo";
            this.lbVatNo.Size = new System.Drawing.Size(86, 15);
            this.lbVatNo.TabIndex = 5;
            this.lbVatNo.Text = "VAT Challan #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(197, 24);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(114, 23);
            this.dtToDate.TabIndex = 4;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(45, 24);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(114, 23);
            this.dtFromDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "From";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(8, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(182, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(52, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // btVatChallanPrint
            // 
            this.btVatChallanPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btVatChallanPrint.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btVatChallanPrint.Location = new System.Drawing.Point(909, 167);
            this.btVatChallanPrint.Name = "btVatChallanPrint";
            this.btVatChallanPrint.Size = new System.Drawing.Size(102, 38);
            this.btVatChallanPrint.TabIndex = 12;
            this.btVatChallanPrint.Tag = "M1.18";
            this.btVatChallanPrint.Text = "Print VAT Challan";
            this.btVatChallanPrint.UseVisualStyleBackColor = true;
            this.btVatChallanPrint.Click += new System.EventHandler(this.btVatChallanPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(909, 457);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 30);
            this.btnClose.TabIndex = 13;
            this.btnClose.Tag = "M1.18";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGetData.Location = new System.Drawing.Point(603, 131);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(102, 30);
            this.btnGetData.TabIndex = 14;
            this.btnGetData.Tag = "M1.18";
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // frmOutletDutyTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 501);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btVatChallanPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtFromVATChallanNo);
            this.Controls.Add(this.lbVatNo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.cmbChallanType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvwTranList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDocNo);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOutletDutyTran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOutletDutyTran";
            this.Load += new System.EventHandler(this.frmOutletDutyTran_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDocNo;
        private System.Windows.Forms.ListView lvwTranList;
        private System.Windows.Forms.ColumnHeader colChallanNo;
        private System.Windows.Forms.ColumnHeader colChallanDate;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colChallanType;
        private System.Windows.Forms.ColumnHeader colInvoiceAmount;
        private System.Windows.Forms.ColumnHeader colConsumerCode;
        private System.Windows.Forms.ColumnHeader colConsumerName;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ComboBox cmbChallanType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtFromVATChallanNo;
        private System.Windows.Forms.Label lbVatNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btVatChallanPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colInvoiceDate;
        private System.Windows.Forms.ColumnHeader colDutyAmount;
        private System.Windows.Forms.ColumnHeader colShowroomCode;
        private System.Windows.Forms.Button btnGetData;
    }
}