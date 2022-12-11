namespace CJ.Win.CSD.Reception
{
    partial class frmInstallationItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstallationItems));
            this.colMobileNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.colOutletName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoiceDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.colInvoiceNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwCSDCustomerQuery = new System.Windows.Forms.ListView();
            this.colProductCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colASGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMAGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPGName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProductSerialNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExpInstallationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExpInstallationTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDeliveryMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHDCompletionDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHDCompletionTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsSafelyDelivered = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colActionTaken = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInstallationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInstallationTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsProperlyInstalled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCSDReason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCSDRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMAG = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbPG = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtExpInstallToDate = new System.Windows.Forms.DateTimePicker();
            this.dtExpInstallFromDate = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colMobileNo
            // 
            this.colMobileNo.Text = "Mobile No";
            this.colMobileNo.Width = 69;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(256, 19);
            this.dtToDate.MinDate = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(99, 20);
            this.dtToDate.TabIndex = 4;
            this.dtToDate.Value = new System.DateTime(2016, 3, 19, 11, 6, 3, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Outlet Name:";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(97, 114);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(168, 21);
            this.cmbWarehouse.TabIndex = 27;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(347, 114);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(151, 20);
            this.txtMobile.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "From Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Mobile No:";
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(97, 88);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(401, 20);
            this.txtCustName.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Consumer Name:";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(97, 62);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(168, 20);
            this.txtInvoiceNo.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Invoice No:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtToDate);
            this.groupBox2.Controls.Add(this.dtFromDate);
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 44);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(70, 19);
            this.dtFromDate.MinDate = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(95, 20);
            this.dtFromDate.TabIndex = 2;
            this.dtFromDate.Value = new System.DateTime(2016, 3, 19, 11, 6, 3, 0);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(19, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(227, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range (InvoiceDate)";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(504, 138);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 28;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // colOutletName
            // 
            this.colOutletName.Text = "Outlet";
            this.colOutletName.Width = 68;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Consumer Name";
            this.colCustomerName.Width = 144;
            // 
            // colInvoiceDate
            // 
            this.colInvoiceDate.Text = "Invoice Date";
            this.colInvoiceDate.Width = 83;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(787, 447);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // colInvoiceNo
            // 
            this.colInvoiceNo.Text = "Invoice No#";
            this.colInvoiceNo.Width = 85;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            this.colEmail.Width = 69;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 84;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 80;
            // 
            // lvwCSDCustomerQuery
            // 
            this.lvwCSDCustomerQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCSDCustomerQuery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOutletName,
            this.colInvoiceNo,
            this.colInvoiceDate,
            this.colCustomerName,
            this.colAddress,
            this.colMobileNo,
            this.colEmail,
            this.colProductCode,
            this.colProductName,
            this.colAGName,
            this.colASGName,
            this.colMAGName,
            this.colPGName,
            this.colProductSerialNo,
            this.colExpInstallationDate,
            this.colExpInstallationTime,
            this.colDeliveryMode,
            this.colHDCompletionDate,
            this.colHDCompletionTime,
            this.colIsSafelyDelivered,
            this.colReason,
            this.colActionTaken,
            this.colJobNo,
            this.colInstallationDate,
            this.colInstallationTime,
            this.colIsProperlyInstalled,
            this.colCSDReason,
            this.colCSDRemarks,
            this.colRemarks});
            this.lvwCSDCustomerQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCSDCustomerQuery.FullRowSelect = true;
            this.lvwCSDCustomerQuery.GridLines = true;
            this.lvwCSDCustomerQuery.HideSelection = false;
            this.lvwCSDCustomerQuery.Location = new System.Drawing.Point(9, 168);
            this.lvwCSDCustomerQuery.MultiSelect = false;
            this.lvwCSDCustomerQuery.Name = "lvwCSDCustomerQuery";
            this.lvwCSDCustomerQuery.Size = new System.Drawing.Size(772, 302);
            this.lvwCSDCustomerQuery.TabIndex = 29;
            this.lvwCSDCustomerQuery.UseCompatibleStateImageBehavior = false;
            this.lvwCSDCustomerQuery.View = System.Windows.Forms.View.Details;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 80;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 83;
            // 
            // colAGName
            // 
            this.colAGName.Text = "AG";
            // 
            // colASGName
            // 
            this.colASGName.Text = "ASG";
            // 
            // colMAGName
            // 
            this.colMAGName.Text = "MAG";
            // 
            // colPGName
            // 
            this.colPGName.Text = "PG";
            // 
            // colProductSerialNo
            // 
            this.colProductSerialNo.Text = "Serial No";
            // 
            // colExpInstallationDate
            // 
            this.colExpInstallationDate.Text = "Exp Installation Date";
            // 
            // colExpInstallationTime
            // 
            this.colExpInstallationTime.Text = "Exp Installation Time";
            // 
            // colDeliveryMode
            // 
            this.colDeliveryMode.Text = "Delivery Mode";
            // 
            // colHDCompletionDate
            // 
            this.colHDCompletionDate.Text = "HD Completion Date";
            // 
            // colHDCompletionTime
            // 
            this.colHDCompletionTime.Text = "HD Completion Time";
            // 
            // colIsSafelyDelivered
            // 
            this.colIsSafelyDelivered.Text = "Is Safely Delivered";
            // 
            // colReason
            // 
            this.colReason.Text = "Reason";
            // 
            // colActionTaken
            // 
            this.colActionTaken.Text = "Action Taken";
            // 
            // colInstallationDate
            // 
            this.colInstallationDate.Text = "Installation Date";
            // 
            // colInstallationTime
            // 
            this.colInstallationTime.Text = "Installation Time";
            // 
            // colIsProperlyInstalled
            // 
            this.colIsProperlyInstalled.Text = "Is Properly Installed";
            // 
            // colCSDReason
            // 
            this.colCSDReason.Text = "CSD Reason";
            // 
            // colCSDRemarks
            // 
            this.colCSDRemarks.Text = "CSD Remarks";
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "MAG:";
            // 
            // cmbMAG
            // 
            this.cmbMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAG.FormattingEnabled = true;
            this.cmbMAG.Location = new System.Drawing.Point(97, 141);
            this.cmbMAG.Name = "cmbMAG";
            this.cmbMAG.Size = new System.Drawing.Size(168, 21);
            this.cmbMAG.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(316, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "PG:";
            // 
            // cmbPG
            // 
            this.cmbPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPG.FormattingEnabled = true;
            this.cmbPG.Location = new System.Drawing.Point(347, 140);
            this.cmbPG.Name = "cmbPG";
            this.cmbPG.Size = new System.Drawing.Size(151, 21);
            this.cmbPG.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtExpInstallToDate);
            this.groupBox1.Controls.Add(this.dtExpInstallFromDate);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(401, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 44);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(204, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "To Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "From Date:";
            // 
            // dtExpInstallToDate
            // 
            this.dtExpInstallToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtExpInstallToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpInstallToDate.Location = new System.Drawing.Point(256, 19);
            this.dtExpInstallToDate.MinDate = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            this.dtExpInstallToDate.Name = "dtExpInstallToDate";
            this.dtExpInstallToDate.Size = new System.Drawing.Size(99, 20);
            this.dtExpInstallToDate.TabIndex = 4;
            this.dtExpInstallToDate.Value = new System.DateTime(2016, 3, 19, 11, 6, 3, 0);
            // 
            // dtExpInstallFromDate
            // 
            this.dtExpInstallFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtExpInstallFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpInstallFromDate.Location = new System.Drawing.Point(70, 19);
            this.dtExpInstallFromDate.MinDate = new System.DateTime(2015, 12, 1, 0, 0, 0, 0);
            this.dtExpInstallFromDate.Name = "dtExpInstallFromDate";
            this.dtExpInstallFromDate.Size = new System.Drawing.Size(95, 20);
            this.dtExpInstallFromDate.TabIndex = 2;
            this.dtExpInstallFromDate.Value = new System.DateTime(2016, 3, 19, 11, 6, 3, 0);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkBox1.Location = new System.Drawing.Point(19, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(293, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Enable/Disable Data Range (Expected Installation Data)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmInstallationItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 482);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbPG);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbMAG);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCustName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwCSDCustomerQuery);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInstallationItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Installation Required Invoice List";
            this.Load += new System.EventHandler(this.frmInstallationItems_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colMobileNo;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ColumnHeader colOutletName;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ColumnHeader colInvoiceDate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colInvoiceNo;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ListView lvwCSDCustomerQuery;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colAGName;
        private System.Windows.Forms.ColumnHeader colASGName;
        private System.Windows.Forms.ColumnHeader colMAGName;
        private System.Windows.Forms.ColumnHeader colPGName;
        private System.Windows.Forms.ColumnHeader colProductSerialNo;
        private System.Windows.Forms.ColumnHeader colExpInstallationDate;
        private System.Windows.Forms.ColumnHeader colExpInstallationTime;
        private System.Windows.Forms.ColumnHeader colDeliveryMode;
        private System.Windows.Forms.ColumnHeader colHDCompletionDate;
        private System.Windows.Forms.ColumnHeader colHDCompletionTime;
        private System.Windows.Forms.ColumnHeader colIsSafelyDelivered;
        private System.Windows.Forms.ColumnHeader colReason;
        private System.Windows.Forms.ColumnHeader colActionTaken;
        private System.Windows.Forms.ColumnHeader colInstallationDate;
        private System.Windows.Forms.ColumnHeader colInstallationTime;
        private System.Windows.Forms.ColumnHeader colIsProperlyInstalled;
        private System.Windows.Forms.ColumnHeader colCSDReason;
        private System.Windows.Forms.ColumnHeader colCSDRemarks;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMAG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPG;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtExpInstallToDate;
        private System.Windows.Forms.DateTimePicker dtExpInstallFromDate;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}