namespace CJ.Win.HR
{
    partial class frmEmployeeLeaveEntry
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
            this.rdo2ndHalf = new System.Windows.Forms.RadioButton();
            this.rdo1stHalf = new System.Windows.Forms.RadioButton();
            this.rdoFullday = new System.Windows.Forms.RadioButton();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDayNumb = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbLeaveType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbInCharge = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lvwLeaveBalances = new System.Windows.Forms.ListView();
            this.colLeaveType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotalAllowed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUtilized = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProposed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.SuspendLayout();
            // 
            // rdo2ndHalf
            // 
            this.rdo2ndHalf.AutoSize = true;
            this.rdo2ndHalf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo2ndHalf.Location = new System.Drawing.Point(205, 78);
            this.rdo2ndHalf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo2ndHalf.Name = "rdo2ndHalf";
            this.rdo2ndHalf.Size = new System.Drawing.Size(65, 17);
            this.rdo2ndHalf.TabIndex = 84;
            this.rdo2ndHalf.Text = "2nd Half";
            this.rdo2ndHalf.UseVisualStyleBackColor = true;
            this.rdo2ndHalf.CheckedChanged += new System.EventHandler(this.rdo2ndHalf_CheckedChanged);
            // 
            // rdo1stHalf
            // 
            this.rdo1stHalf.AutoSize = true;
            this.rdo1stHalf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo1stHalf.Location = new System.Drawing.Point(141, 78);
            this.rdo1stHalf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo1stHalf.Name = "rdo1stHalf";
            this.rdo1stHalf.Size = new System.Drawing.Size(61, 17);
            this.rdo1stHalf.TabIndex = 83;
            this.rdo1stHalf.Text = "1st Half";
            this.rdo1stHalf.UseVisualStyleBackColor = true;
            this.rdo1stHalf.CheckedChanged += new System.EventHandler(this.rdo1stHalf_CheckedChanged);
            // 
            // rdoFullday
            // 
            this.rdoFullday.AutoSize = true;
            this.rdoFullday.Checked = true;
            this.rdoFullday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFullday.Location = new System.Drawing.Point(72, 78);
            this.rdoFullday.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoFullday.Name = "rdoFullday";
            this.rdoFullday.Size = new System.Drawing.Size(63, 17);
            this.rdoFullday.TabIndex = 82;
            this.rdoFullday.TabStop = true;
            this.rdoFullday.Text = "Full Day";
            this.rdoFullday.UseVisualStyleBackColor = true;
            this.rdoFullday.CheckedChanged += new System.EventHandler(this.rdoFullday_CheckedChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(71, 134);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(380, 20);
            this.txtAddress.TabIndex = 72;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 71;
            this.label5.Text = "Address";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(280, 163);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.MaxLength = 200;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(171, 20);
            this.txtEmail.TabIndex = 76;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(237, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 75;
            this.label9.Text = "Email";
            // 
            // txtDayNumb
            // 
            this.txtDayNumb.Location = new System.Drawing.Point(381, 48);
            this.txtDayNumb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDayNumb.MaxLength = 200;
            this.txtDayNumb.Name = "txtDayNumb";
            this.txtDayNumb.ReadOnly = true;
            this.txtDayNumb.Size = new System.Drawing.Size(64, 20);
            this.txtDayNumb.TabIndex = 78;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(344, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 79;
            this.label11.Text = "Days";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(70, 162);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhone.MaxLength = 200;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(162, 20);
            this.txtPhone.TabIndex = 74;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 73;
            this.label8.Text = "Mobile No.";
            // 
            // cmbReason
            // 
            this.cmbReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Items.AddRange(new object[] {
            "<All>",
            "Personal",
            "Training",
            "Market Visit",
            "Foreign Tour",
            "Others"});
            this.cmbReason.Location = new System.Drawing.Point(284, 103);
            this.cmbReason.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(167, 21);
            this.cmbReason.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(237, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 65;
            this.label7.Text = "Reason";
            // 
            // cmbLeaveType
            // 
            this.cmbLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeaveType.FormattingEnabled = true;
            this.cmbLeaveType.Location = new System.Drawing.Point(72, 105);
            this.cmbLeaveType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbLeaveType.Name = "cmbLeaveType";
            this.cmbLeaveType.Size = new System.Drawing.Size(160, 21);
            this.cmbLeaveType.TabIndex = 64;
            this.cmbLeaveType.SelectedIndexChanged += new System.EventHandler(this.cmbLeaveType_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Leave Type";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(176, 51);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(52, 13);
            this.lblTo.TabIndex = 69;
            this.lblTo.Text = "End Date";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(11, 51);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(55, 13);
            this.lblDate.TabIndex = 67;
            this.lblDate.Text = "Start Date";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(234, 47);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(104, 20);
            this.dtToDate.TabIndex = 70;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(72, 47);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(93, 20);
            this.dtFromDate.TabIndex = 68;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 86;
            this.label1.Text = "Employee";
            // 
            // cmbInCharge
            // 
            this.cmbInCharge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInCharge.FormattingEnabled = true;
            this.cmbInCharge.Location = new System.Drawing.Point(70, 191);
            this.cmbInCharge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbInCharge.Name = "cmbInCharge";
            this.cmbInCharge.Size = new System.Drawing.Size(381, 21);
            this.cmbInCharge.TabIndex = 88;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 197);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 87;
            this.label15.Text = "InCharge";
            // 
            // lvwLeaveBalances
            // 
            this.lvwLeaveBalances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLeaveType,
            this.colTotalAllowed,
            this.colUtilized,
            this.colProposed,
            this.colTotal});
            this.lvwLeaveBalances.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(4)), true);
            this.lvwLeaveBalances.ForeColor = System.Drawing.Color.Black;
            this.lvwLeaveBalances.FullRowSelect = true;
            this.lvwLeaveBalances.GridLines = true;
            this.lvwLeaveBalances.Location = new System.Drawing.Point(461, 26);
            this.lvwLeaveBalances.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwLeaveBalances.MultiSelect = false;
            this.lvwLeaveBalances.Name = "lvwLeaveBalances";
            this.lvwLeaveBalances.Size = new System.Drawing.Size(370, 186);
            this.lvwLeaveBalances.TabIndex = 90;
            this.lvwLeaveBalances.UseCompatibleStateImageBehavior = false;
            this.lvwLeaveBalances.View = System.Windows.Forms.View.Details;
            // 
            // colLeaveType
            // 
            this.colLeaveType.Text = "Leave Type";
            this.colLeaveType.Width = 71;
            // 
            // colTotalAllowed
            // 
            this.colTotalAllowed.Text = "Allowed";
            this.colTotalAllowed.Width = 59;
            // 
            // colUtilized
            // 
            this.colUtilized.Text = "UtilizedTillDate";
            this.colUtilized.Width = 90;
            // 
            // colProposed
            // 
            this.colProposed.Text = "Proposed";
            this.colProposed.Width = 64;
            // 
            // colTotal
            // 
            this.colTotal.Text = "Total Utilized";
            this.colTotal.Width = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(458, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Employee Leave Balance:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(747, 227);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 26);
            this.btnClose.TabIndex = 93;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(657, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 94;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReject
            // 
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.Red;
            this.btnReject.Location = new System.Drawing.Point(14, 227);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(84, 26);
            this.btnReject.TabIndex = 95;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(71, 12);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(381, 25);
            this.ctlEmployee1.TabIndex = 92;
            this.ctlEmployee1.ChangeSelection += new System.EventHandler(this.ctlEmployee1_ChangeSelection);
            // 
            // frmEmployeeLeaveEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 262);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwLeaveBalances);
            this.Controls.Add(this.cmbLeaveType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbInCharge);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdo2ndHalf);
            this.Controls.Add(this.rdo1stHalf);
            this.Controls.Add(this.rdoFullday);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDayNumb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbReason);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmEmployeeLeaveEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeeLeaveEntry";
            this.Load += new System.EventHandler(this.frmEmployeeLeaveEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdo2ndHalf;
        private System.Windows.Forms.RadioButton rdo1stHalf;
        private System.Windows.Forms.RadioButton rdoFullday;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDayNumb;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbLeaveType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbInCharge;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListView lvwLeaveBalances;
        private System.Windows.Forms.ColumnHeader colLeaveType;
        private System.Windows.Forms.ColumnHeader colTotalAllowed;
        private System.Windows.Forms.ColumnHeader colUtilized;
        private System.Windows.Forms.ColumnHeader colProposed;
        private System.Windows.Forms.ColumnHeader colTotal;
        private System.Windows.Forms.Label label2;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReject;
    }
}