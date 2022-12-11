namespace CJ.Win.HR
{
    partial class frmOverTimes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOverTimes));
            this.dtOverTimeDate = new System.Windows.Forms.DateTimePicker();
            this.lblMonth = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lvwOverTime = new System.Windows.Forms.ListView();
            this.colOverTimeCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmployeeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOverTimeMonth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLessHour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotalHour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnGetSummary = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnBulkApproved = new System.Windows.Forms.Button();
            this.btSelectAll = new System.Windows.Forms.Button();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.chkIsFactoryEmployee = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtOverTimeDate
            // 
            this.dtOverTimeDate.CustomFormat = "MMM-yyyy";
            this.dtOverTimeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOverTimeDate.Location = new System.Drawing.Point(97, 12);
            this.dtOverTimeDate.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtOverTimeDate.Name = "dtOverTimeDate";
            this.dtOverTimeDate.ShowUpDown = true;
            this.dtOverTimeDate.Size = new System.Drawing.Size(101, 20);
            this.dtOverTimeDate.TabIndex = 10;
            this.dtOverTimeDate.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.Location = new System.Drawing.Point(27, 14);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(64, 13);
            this.lblMonth.TabIndex = 9;
            this.lblMonth.Text = "Year/Month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Employee Name";
            // 
            // lvwOverTime
            // 
            this.lvwOverTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOverTime.CheckBoxes = true;
            this.lvwOverTime.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOverTimeCode,
            this.colEmployeeName,
            this.colDepartment,
            this.colCompany,
            this.colOverTimeMonth,
            this.colYear,
            this.colLessHour,
            this.colTotalHour,
            this.colAmount,
            this.colStatus});
            this.lvwOverTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOverTime.FullRowSelect = true;
            this.lvwOverTime.GridLines = true;
            this.lvwOverTime.Location = new System.Drawing.Point(12, 152);
            this.lvwOverTime.MultiSelect = false;
            this.lvwOverTime.Name = "lvwOverTime";
            this.lvwOverTime.Size = new System.Drawing.Size(865, 272);
            this.lvwOverTime.TabIndex = 16;
            this.lvwOverTime.UseCompatibleStateImageBehavior = false;
            this.lvwOverTime.View = System.Windows.Forms.View.Details;
            this.lvwOverTime.DoubleClick += new System.EventHandler(this.lvwOverTime_DoubleClick);
            // 
            // colOverTimeCode
            // 
            this.colOverTimeCode.Text = "OverTime Code";
            this.colOverTimeCode.Width = 90;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Text = "Employee Name";
            this.colEmployeeName.Width = 174;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Department";
            this.colDepartment.Width = 145;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 85;
            // 
            // colOverTimeMonth
            // 
            this.colOverTimeMonth.Text = "Month";
            this.colOverTimeMonth.Width = 112;
            // 
            // colYear
            // 
            this.colYear.Text = "Year";
            this.colYear.Width = 82;
            // 
            // colLessHour
            // 
            this.colLessHour.Text = "Less Hour";
            this.colLessHour.Width = 75;
            // 
            // colTotalHour
            // 
            this.colTotalHour.Text = "Total Hour";
            this.colTotalHour.Width = 73;
            // 
            // colAmount
            // 
            this.colAmount.Text = "Amount";
            this.colAmount.Width = 82;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 78;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(883, 152);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 25);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(883, 181);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 25);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(883, 401);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 25);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(618, 93);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 20;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(461, 69);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(151, 20);
            this.txtCode.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(374, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "OverTime Code";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(461, 95);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(151, 21);
            this.cmbStatus.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(418, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Status";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(883, 210);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 25);
            this.btnDelete.TabIndex = 25;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(883, 239);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 25);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproved.Location = new System.Drawing.Point(883, 268);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(85, 25);
            this.btnApproved.TabIndex = 27;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = true;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnGetSummary
            // 
            this.btnGetSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetSummary.Location = new System.Drawing.Point(883, 330);
            this.btnGetSummary.Name = "btnGetSummary";
            this.btnGetSummary.Size = new System.Drawing.Size(85, 27);
            this.btnGetSummary.TabIndex = 28;
            this.btnGetSummary.Text = "Get Summary";
            this.btnGetSummary.UseVisualStyleBackColor = true;
            this.btnGetSummary.Click += new System.EventHandler(this.btnGetSummary_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 226;
            this.label3.Text = "Department";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 225;
            this.label4.Text = "Company";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(97, 96);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(268, 21);
            this.cmbDepartment.TabIndex = 224;
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(97, 69);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(268, 21);
            this.cmbCompany.TabIndex = 223;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Salmon;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(116, 430);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 13);
            this.label18.TabIndex = 229;
            this.label18.Text = "Reject";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(57, 430);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 228;
            this.label19.Text = "Approved";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Khaki;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(13, 430);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 13);
            this.label20.TabIndex = 227;
            this.label20.Text = "Create";
            // 
            // btnBulkApproved
            // 
            this.btnBulkApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBulkApproved.Location = new System.Drawing.Point(883, 297);
            this.btnBulkApproved.Name = "btnBulkApproved";
            this.btnBulkApproved.Size = new System.Drawing.Size(85, 27);
            this.btnBulkApproved.TabIndex = 230;
            this.btnBulkApproved.Text = "Bulk Approved";
            this.btnBulkApproved.UseVisualStyleBackColor = true;
            this.btnBulkApproved.Click += new System.EventHandler(this.btnBulkApproved_Click);
            // 
            // btSelectAll
            // 
            this.btSelectAll.Location = new System.Drawing.Point(12, 123);
            this.btSelectAll.Name = "btSelectAll";
            this.btSelectAll.Size = new System.Drawing.Size(79, 23);
            this.btSelectAll.TabIndex = 231;
            this.btSelectAll.Text = "Checked All";
            this.btSelectAll.UseVisualStyleBackColor = true;
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(97, 38);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(515, 25);
            this.ctlEmployee1.TabIndex = 14;
            // 
            // chkIsFactoryEmployee
            // 
            this.chkIsFactoryEmployee.AutoSize = true;
            this.chkIsFactoryEmployee.Location = new System.Drawing.Point(226, 12);
            this.chkIsFactoryEmployee.Name = "chkIsFactoryEmployee";
            this.chkIsFactoryEmployee.Size = new System.Drawing.Size(121, 17);
            this.chkIsFactoryEmployee.TabIndex = 232;
            this.chkIsFactoryEmployee.Text = "Is Factory Employee";
            this.chkIsFactoryEmployee.UseVisualStyleBackColor = true;
            // 
            // frmOverTimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 452);
            this.Controls.Add(this.chkIsFactoryEmployee);
            this.Controls.Add(this.btSelectAll);
            this.Controls.Add(this.btnBulkApproved);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.btnGetSummary);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwOverTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.dtOverTimeDate);
            this.Controls.Add(this.lblMonth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOverTimes";
            this.Text = "frmOverTimes";
            this.Load += new System.EventHandler(this.frmOverTimes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtOverTimeDate;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label label5;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.ListView lvwOverTime;
        private System.Windows.Forms.ColumnHeader colEmployeeName;
        private System.Windows.Forms.ColumnHeader colOverTimeMonth;
        private System.Windows.Forms.ColumnHeader colTotalHour;
        private System.Windows.Forms.ColumnHeader colLessHour;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ColumnHeader colOverTimeCode;
        private System.Windows.Forms.ColumnHeader colYear;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.Button btnGetSummary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnBulkApproved;
        private System.Windows.Forms.Button btSelectAll;
        private System.Windows.Forms.CheckBox chkIsFactoryEmployee;
    }
}