namespace CJ.POS
{
    partial class frmAdvancePayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdvancePayments));
            this.lvwConsumerBalance = new System.Windows.Forms.ListView();
            this.colConsumerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConsumerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContactNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBalance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btGetData = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwConsumerTran = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAPNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranSide = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPaymentMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label18 = new System.Windows.Forms.Label();
            this.cmbBalance = new System.Windows.Forms.ComboBox();
            this.btnPrintThermal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwConsumerBalance
            // 
            this.lvwConsumerBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwConsumerBalance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colConsumerCode,
            this.colConsumerName,
            this.colContactNo,
            this.colBalance,
            this.colAddress});
            this.lvwConsumerBalance.FullRowSelect = true;
            this.lvwConsumerBalance.GridLines = true;
            this.lvwConsumerBalance.Location = new System.Drawing.Point(14, 104);
            this.lvwConsumerBalance.Name = "lvwConsumerBalance";
            this.lvwConsumerBalance.Size = new System.Drawing.Size(691, 250);
            this.lvwConsumerBalance.TabIndex = 7;
            this.lvwConsumerBalance.UseCompatibleStateImageBehavior = false;
            this.lvwConsumerBalance.View = System.Windows.Forms.View.Details;
            this.lvwConsumerBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwConsumerBalance_KeyDown);
            this.lvwConsumerBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwConsumerBalance_KeyPress);
            this.lvwConsumerBalance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwConsumerBalance_KeyUp);
            this.lvwConsumerBalance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvwConsumerBalance_MouseClick);
            // 
            // colConsumerCode
            // 
            this.colConsumerCode.Text = "Consumer Code";
            this.colConsumerCode.Width = 104;
            // 
            // colConsumerName
            // 
            this.colConsumerName.Text = "Consumer Name";
            this.colConsumerName.Width = 160;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 99;
            // 
            // colBalance
            // 
            this.colBalance.Text = "Balance";
            this.colBalance.Width = 80;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 275;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(332, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Contact No";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(413, 7);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(150, 21);
            this.txtContactNo.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(2, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 18);
            this.label11.TabIndex = 4;
            this.label11.Text = "Consumer Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(104, 35);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(199, 21);
            this.txtCustomerName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Consumer Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(104, 7);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(199, 21);
            this.txtCode.TabIndex = 1;
            // 
            // btGetData
            // 
            this.btGetData.Location = new System.Drawing.Point(569, 31);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(87, 29);
            this.btGetData.TabIndex = 6;
            this.btGetData.Text = "Get Data";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(714, 362);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 29);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(714, 397);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 29);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(714, 104);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 29);
            this.btnPreview.TabIndex = 11;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(714, 441);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwConsumerTran
            // 
            this.lvwConsumerTran.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwConsumerTran.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colTranType,
            this.colAPNo,
            this.colInvoiceNo,
            this.colAmount,
            this.colTranSide,
            this.colPaymentMode,
            this.colProduct});
            this.lvwConsumerTran.FullRowSelect = true;
            this.lvwConsumerTran.GridLines = true;
            this.lvwConsumerTran.Location = new System.Drawing.Point(14, 362);
            this.lvwConsumerTran.Name = "lvwConsumerTran";
            this.lvwConsumerTran.Size = new System.Drawing.Size(691, 108);
            this.lvwConsumerTran.TabIndex = 8;
            this.lvwConsumerTran.UseCompatibleStateImageBehavior = false;
            this.lvwConsumerTran.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 82;
            // 
            // colTranType
            // 
            this.colTranType.Text = "Tran Type";
            this.colTranType.Width = 70;
            // 
            // colAPNo
            // 
            this.colAPNo.Text = "AP No";
            this.colAPNo.Width = 67;
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No";
            this.colInvoiceNo.Width = 73;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            // 
            // colTranSide
            // 
            this.colTranSide.Text = "Tran Side";
            this.colTranSide.Width = 68;
            // 
            // colPaymentMode
            // 
            this.colPaymentMode.Text = "Payment Mode";
            this.colPaymentMode.Width = 92;
            // 
            // colProduct
            // 
            this.colProduct.Text = "Product";
            this.colProduct.Width = 177;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(336, 36);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 18);
            this.label18.TabIndex = 13;
            this.label18.Text = "Balance";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBalance
            // 
            this.cmbBalance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBalance.FormattingEnabled = true;
            this.cmbBalance.Location = new System.Drawing.Point(413, 35);
            this.cmbBalance.Name = "cmbBalance";
            this.cmbBalance.Size = new System.Drawing.Size(150, 23);
            this.cmbBalance.TabIndex = 14;
            // 
            // btnPrintThermal
            // 
            this.btnPrintThermal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintThermal.Location = new System.Drawing.Point(714, 139);
            this.btnPrintThermal.Name = "btnPrintThermal";
            this.btnPrintThermal.Size = new System.Drawing.Size(87, 38);
            this.btnPrintThermal.TabIndex = 16;
            this.btnPrintThermal.Text = "Print Thermal";
            this.btnPrintThermal.UseVisualStyleBackColor = true;
            this.btnPrintThermal.Click += new System.EventHandler(this.btnPrintThermal_Click);
            // 
            // frmAdvancePayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 485);
            this.Controls.Add(this.btnPrintThermal);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cmbBalance);
            this.Controls.Add(this.lvwConsumerTran);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.lvwConsumerBalance);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdvancePayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advance Payments (AP)";
            this.Load += new System.EventHandler(this.frmAdvancePayments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwConsumerBalance;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colBalance;
        private System.Windows.Forms.ColumnHeader colConsumerName;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colConsumerCode;
        private System.Windows.Forms.ListView lvwConsumerTran;
        private System.Windows.Forms.ColumnHeader colAPNo;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colProduct;
        private System.Windows.Forms.ColumnHeader colTranType;
        private System.Windows.Forms.ColumnHeader colTranSide;
        private System.Windows.Forms.ColumnHeader colPaymentMode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbBalance;
        private System.Windows.Forms.Button btnPrintThermal;
    }
}