namespace CJ.Win.Accounts
{
    partial class frmCustomerTransactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerTransactions));
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInstrumentNo = new System.Windows.Forms.TextBox();
            this.txtTransactionNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbInstrumnetStatus = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbCustomerTranType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbMainGroup = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lvwCustomerTransactions = new System.Windows.Forms.ListView();
            this.colTranNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colParentCustomer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranTypeGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTranType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInstrumentNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInstrumentStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRowStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btnCancelTran = new System.Windows.Forms.Button();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.ctlCustomer2 = new CJ.Win.Control.ctlCustomer();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCollection = new System.Windows.Forms.Button();
            this.btnAdjustment = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(10, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(256, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range (Order Date)";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(67, 36);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(123, 23);
            this.dtFromDate.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(27, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(205, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(236, 24);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(123, 23);
            this.dtToDate.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(376, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Instrumnet No";
            // 
            // txtInstrumentNo
            // 
            this.txtInstrumentNo.Location = new System.Drawing.Point(125, 73);
            this.txtInstrumentNo.Name = "txtInstrumentNo";
            this.txtInstrumentNo.Size = new System.Drawing.Size(263, 20);
            this.txtInstrumentNo.TabIndex = 4;
            // 
            // txtTransactionNo
            // 
            this.txtTransactionNo.Location = new System.Drawing.Point(125, 99);
            this.txtTransactionNo.Name = "txtTransactionNo";
            this.txtTransactionNo.Size = new System.Drawing.Size(263, 20);
            this.txtTransactionNo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Transaction No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Customer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label6.Location = new System.Drawing.Point(12, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Parent Customer";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label7.Location = new System.Drawing.Point(599, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Instrument Status";
            // 
            // cmbInstrumnetStatus
            // 
            this.cmbInstrumnetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInstrumnetStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrumnetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInstrumnetStatus.FormattingEnabled = true;
            this.cmbInstrumnetStatus.Location = new System.Drawing.Point(720, 66);
            this.cmbInstrumnetStatus.Name = "cmbInstrumnetStatus";
            this.cmbInstrumnetStatus.Size = new System.Drawing.Size(206, 23);
            this.cmbInstrumnetStatus.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cmbCustomerTranType);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cmbMainGroup);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.groupBox2.Location = new System.Drawing.Point(602, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 79);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    Transaction Type";
            // 
            // cmbCustomerTranType
            // 
            this.cmbCustomerTranType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomerTranType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomerTranType.FormattingEnabled = true;
            this.cmbCustomerTranType.Location = new System.Drawing.Point(118, 43);
            this.cmbCustomerTranType.Name = "cmbCustomerTranType";
            this.cmbCustomerTranType.Size = new System.Drawing.Size(206, 23);
            this.cmbCustomerTranType.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Tran Type";
            // 
            // cmbMainGroup
            // 
            this.cmbMainGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMainGroup.FormattingEnabled = true;
            this.cmbMainGroup.Location = new System.Drawing.Point(118, 14);
            this.cmbMainGroup.Name = "cmbMainGroup";
            this.cmbMainGroup.Size = new System.Drawing.Size(206, 23);
            this.cmbMainGroup.TabIndex = 1;
            this.cmbMainGroup.SelectedIndexChanged += new System.EventHandler(this.cmbMainGroup_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Main Group";
            // 
            // lvwCustomerTransactions
            // 
            this.lvwCustomerTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCustomerTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranNo,
            this.colTranDate,
            this.colCustomer,
            this.colParentCustomer,
            this.colTranTypeGroup,
            this.colTranType,
            this.colAmount,
            this.colInstrumentNo,
            this.colInstrumentStatus,
            this.colRowStatus});
            this.lvwCustomerTransactions.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lvwCustomerTransactions.FullRowSelect = true;
            this.lvwCustomerTransactions.GridLines = true;
            this.lvwCustomerTransactions.HideSelection = false;
            this.lvwCustomerTransactions.Location = new System.Drawing.Point(15, 185);
            this.lvwCustomerTransactions.MultiSelect = false;
            this.lvwCustomerTransactions.Name = "lvwCustomerTransactions";
            this.lvwCustomerTransactions.Size = new System.Drawing.Size(1039, 418);
            this.lvwCustomerTransactions.TabIndex = 19;
            this.lvwCustomerTransactions.UseCompatibleStateImageBehavior = false;
            this.lvwCustomerTransactions.View = System.Windows.Forms.View.Details;
            // 
            // colTranNo
            // 
            this.colTranNo.Text = "Transaction No";
            this.colTranNo.Width = 100;
            // 
            // colTranDate
            // 
            this.colTranDate.Text = "Transaction Date";
            this.colTranDate.Width = 108;
            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer";
            this.colCustomer.Width = 120;
            // 
            // colParentCustomer
            // 
            this.colParentCustomer.DisplayIndex = 5;
            this.colParentCustomer.Text = "Parent Customer";
            this.colParentCustomer.Width = 124;
            // 
            // colTranTypeGroup
            // 
            this.colTranTypeGroup.DisplayIndex = 3;
            this.colTranTypeGroup.Text = "Tran Type Group";
            this.colTranTypeGroup.Width = 107;
            // 
            // colTranType
            // 
            this.colTranType.DisplayIndex = 4;
            this.colTranType.Text = "Transaction Type";
            this.colTranType.Width = 111;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAmount.Width = 82;
            // 
            // colInstrumentNo
            // 
            this.colInstrumentNo.Text = "Instrument#";
            this.colInstrumentNo.Width = 86;
            // 
            // colInstrumentStatus
            // 
            this.colInstrumentStatus.Text = "Instrument Status";
            this.colInstrumentStatus.Width = 119;
            // 
            // colRowStatus
            // 
            this.colRowStatus.Text = "RowStatus";
            this.colRowStatus.Width = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnEdit.Location = new System.Drawing.Point(1060, 257);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(101, 30);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReprint.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnReprint.Location = new System.Drawing.Point(1060, 293);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(101, 30);
            this.btnReprint.TabIndex = 16;
            this.btnReprint.Text = "Reprint";
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnCancelTran
            // 
            this.btnCancelTran.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelTran.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnCancelTran.Location = new System.Drawing.Point(1060, 329);
            this.btnCancelTran.Name = "btnCancelTran";
            this.btnCancelTran.Size = new System.Drawing.Size(101, 44);
            this.btnCancelTran.TabIndex = 17;
            this.btnCancelTran.Text = "Cancel Transaction";
            this.btnCancelTran.UseVisualStyleBackColor = true;
            this.btnCancelTran.Click += new System.EventHandler(this.btnCancelTran_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproved.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnApproved.Location = new System.Drawing.Point(1060, 379);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(101, 30);
            this.btnApproved.TabIndex = 18;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = true;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGet.Location = new System.Drawing.Point(953, 145);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(101, 30);
            this.btnGet.TabIndex = 14;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // ctlCustomer2
            // 
            this.ctlCustomer2.Location = new System.Drawing.Point(125, 154);
            this.ctlCustomer2.Name = "ctlCustomer2";
            this.ctlCustomer2.Size = new System.Drawing.Size(426, 20);
            this.ctlCustomer2.TabIndex = 13;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(125, 126);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(426, 20);
            this.ctlCustomer1.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.LightCoral;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(19, 606);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 203;
            this.label10.Text = "Cancelled";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCollection
            // 
            this.btnCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollection.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnCollection.Location = new System.Drawing.Point(1060, 185);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(101, 30);
            this.btnCollection.TabIndex = 204;
            this.btnCollection.Text = "Collection";
            this.btnCollection.UseVisualStyleBackColor = true;
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // btnAdjustment
            // 
            this.btnAdjustment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdjustment.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnAdjustment.Location = new System.Drawing.Point(1060, 221);
            this.btnAdjustment.Name = "btnAdjustment";
            this.btnAdjustment.Size = new System.Drawing.Size(101, 30);
            this.btnAdjustment.TabIndex = 205;
            this.btnAdjustment.Text = "Adjustment";
            this.btnAdjustment.UseVisualStyleBackColor = true;
            this.btnAdjustment.Click += new System.EventHandler(this.btnAdjustment_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.LightGreen;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(87, 606);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 15);
            this.label11.TabIndex = 206;
            this.label11.Text = "None";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCustomerTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 636);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAdjustment);
            this.Controls.Add(this.btnCollection);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnCancelTran);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lvwCustomerTransactions);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmbInstrumnetStatus);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ctlCustomer2);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTransactionNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInstrumentNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomerTransactions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Transactions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCustomerTransactions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInstrumentNo;
        private System.Windows.Forms.TextBox txtTransactionNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Control.ctlCustomer ctlCustomer1;
        private Control.ctlCustomer ctlCustomer2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbInstrumnetStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbCustomerTranType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbMainGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvwCustomerTransactions;
        private System.Windows.Forms.ColumnHeader colTranNo;
        private System.Windows.Forms.ColumnHeader colTranDate;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.ColumnHeader colParentCustomer;
        private System.Windows.Forms.ColumnHeader colTranTypeGroup;
        private System.Windows.Forms.ColumnHeader colTranType;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colInstrumentNo;
        private System.Windows.Forms.ColumnHeader colInstrumentStatus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Button btnCancelTran;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.ColumnHeader colRowStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCollection;
        private System.Windows.Forms.Button btnAdjustment;
        private System.Windows.Forms.Label label11;
    }
}