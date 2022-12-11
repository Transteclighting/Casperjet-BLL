namespace CJ.Win.CSD.Reception
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
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdvancePaymentNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colConsumerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContactNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPaymentModeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdvanceAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdvanceDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdjustAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdjustDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdvanceStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobNumber = new System.Windows.Forms.TextBox();
            this.btGetData = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdvanceNo = new System.Windows.Forms.TextBox();
            this.chkEnableDisableCreateDateRange = new System.Windows.Forms.CheckBox();
            this.dtCreateToDate = new System.Windows.Forms.DateTimePicker();
            this.dtCreateFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbBrandType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwConsumerBalance
            // 
            this.lvwConsumerBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwConsumerBalance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colJobNo,
            this.colAdvancePaymentNo,
            this.colConsumerName,
            this.colContactNo,
            this.colAddress,
            this.colPaymentModeName,
            this.colAdvanceAmount,
            this.colAdvanceDate,
            this.colAdjustAmount,
            this.colAdjustDate,
            this.colAdvanceStatus});
            this.lvwConsumerBalance.FullRowSelect = true;
            this.lvwConsumerBalance.GridLines = true;
            this.lvwConsumerBalance.Location = new System.Drawing.Point(14, 118);
            this.lvwConsumerBalance.Name = "lvwConsumerBalance";
            this.lvwConsumerBalance.Size = new System.Drawing.Size(691, 228);
            this.lvwConsumerBalance.TabIndex = 7;
            this.lvwConsumerBalance.UseCompatibleStateImageBehavior = false;
            this.lvwConsumerBalance.View = System.Windows.Forms.View.Details;
            this.lvwConsumerBalance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwConsumerBalance_KeyDown);
            this.lvwConsumerBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwConsumerBalance_KeyPress);
            this.lvwConsumerBalance.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwConsumerBalance_KeyUp);
            this.lvwConsumerBalance.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvwConsumerBalance_MouseClick);
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 81;
            // 
            // colAdvancePaymentNo
            // 
            this.colAdvancePaymentNo.Text = "Advance No";
            this.colAdvancePaymentNo.Width = 111;
            // 
            // colConsumerName
            // 
            this.colConsumerName.Text = "Customer Name";
            this.colConsumerName.Width = 137;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 99;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 90;
            // 
            // colPaymentModeName
            // 
            this.colPaymentModeName.Text = "Payment Mode";
            this.colPaymentModeName.Width = 77;
            // 
            // colAdvanceAmount
            // 
            this.colAdvanceAmount.Text = "Advance Amount";
            this.colAdvanceAmount.Width = 73;
            // 
            // colAdvanceDate
            // 
            this.colAdvanceDate.Text = "Advance Date";
            this.colAdvanceDate.Width = 94;
            // 
            // colAdjustAmount
            // 
            this.colAdjustAmount.Text = "Adjust Amount";
            // 
            // colAdjustDate
            // 
            this.colAdjustDate.Text = "Adjust Date";
            // 
            // colAdvanceStatus
            // 
            this.colAdvanceStatus.Text = "Advance Status";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(331, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Contact No";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(413, 36);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(199, 21);
            this.txtContactNo.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(311, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 18);
            this.label11.TabIndex = 4;
            this.label11.Text = "Consumer Name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(413, 91);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(199, 21);
            this.txtCustomerName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(335, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Job No";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtJobNumber
            // 
            this.txtJobNumber.Location = new System.Drawing.Point(413, 63);
            this.txtJobNumber.Name = "txtJobNumber";
            this.txtJobNumber.Size = new System.Drawing.Size(199, 21);
            this.txtJobNumber.TabIndex = 1;
            // 
            // btGetData
            // 
            this.btGetData.Location = new System.Drawing.Point(618, 85);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(87, 29);
            this.btGetData.TabIndex = 6;
            this.btGetData.Text = "Get Data";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(714, 139);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 29);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(711, 104);
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
            this.btnClose.Location = new System.Drawing.Point(714, 317);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 29);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Advance No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAdvanceNo
            // 
            this.txtAdvanceNo.Location = new System.Drawing.Point(104, 62);
            this.txtAdvanceNo.Name = "txtAdvanceNo";
            this.txtAdvanceNo.Size = new System.Drawing.Size(199, 21);
            this.txtAdvanceNo.TabIndex = 16;
            // 
            // chkEnableDisableCreateDateRange
            // 
            this.chkEnableDisableCreateDateRange.AutoSize = true;
            this.chkEnableDisableCreateDateRange.Location = new System.Drawing.Point(14, -1);
            this.chkEnableDisableCreateDateRange.Name = "chkEnableDisableCreateDateRange";
            this.chkEnableDisableCreateDateRange.Size = new System.Drawing.Size(179, 19);
            this.chkEnableDisableCreateDateRange.TabIndex = 0;
            this.chkEnableDisableCreateDateRange.Text = "Enable/Disable Date Range";
            this.chkEnableDisableCreateDateRange.UseVisualStyleBackColor = true;
            this.chkEnableDisableCreateDateRange.CheckedChanged += new System.EventHandler(this.chkEnableDisableCreateDateRange_CheckedChanged);
            // 
            // dtCreateToDate
            // 
            this.dtCreateToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtCreateToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCreateToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCreateToDate.Location = new System.Drawing.Point(208, 20);
            this.dtCreateToDate.Name = "dtCreateToDate";
            this.dtCreateToDate.Size = new System.Drawing.Size(97, 20);
            this.dtCreateToDate.TabIndex = 4;
            // 
            // dtCreateFromDate
            // 
            this.dtCreateFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtCreateFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCreateFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCreateFromDate.Location = new System.Drawing.Point(83, 20);
            this.dtCreateFromDate.Name = "dtCreateFromDate";
            this.dtCreateFromDate.Size = new System.Drawing.Size(98, 20);
            this.dtCreateFromDate.TabIndex = 2;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(184, 23);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDate.Location = new System.Drawing.Point(3, 22);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(77, 13);
            this.lblCreateDate.TabIndex = 1;
            this.lblCreateDate.Text = "Create Date";
            this.lblCreateDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEnableDisableCreateDateRange);
            this.groupBox1.Controls.Add(this.dtCreateToDate);
            this.groupBox1.Controls.Add(this.dtCreateFromDate);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblCreateDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 49);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Brand";
            // 
            // cmbBrandType
            // 
            this.cmbBrandType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrandType.FormattingEnabled = true;
            this.cmbBrandType.Items.AddRange(new object[] {
            "All",
            "Samsung",
            "Other"});
            this.cmbBrandType.Location = new System.Drawing.Point(104, 89);
            this.cmbBrandType.Name = "cmbBrandType";
            this.cmbBrandType.Size = new System.Drawing.Size(199, 23);
            this.cmbBrandType.TabIndex = 19;
            // 
            // frmAdvancePayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 361);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbBrandType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAdvanceNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJobNumber);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwConsumerBalance;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colConsumerName;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtJobNumber;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdvanceNo;
        private System.Windows.Forms.ColumnHeader colAdvancePaymentNo;
        private System.Windows.Forms.ColumnHeader colPaymentModeName;
        private System.Windows.Forms.ColumnHeader colAdvanceDate;
        private System.Windows.Forms.ColumnHeader colAdvanceStatus;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colAdvanceAmount;
        private System.Windows.Forms.ColumnHeader colAdjustAmount;
        private System.Windows.Forms.ColumnHeader colAdjustDate;
        private System.Windows.Forms.CheckBox chkEnableDisableCreateDateRange;
        private System.Windows.Forms.DateTimePicker dtCreateToDate;
        private System.Windows.Forms.DateTimePicker dtCreateFromDate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbBrandType;
    }
}