namespace CJ.Win
{
    partial class frmAttendReports
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
            this.label3 = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new System.Windows.Forms.Button();
            this.rbEmployeeWise = new System.Windows.Forms.RadioButton();
            this.rbDepartmentWise = new System.Windows.Forms.RadioButton();
            this.rbDateWise = new System.Windows.Forms.RadioButton();
            this.chkIsAttendanceEmployee = new System.Windows.Forms.CheckBox();
            this.rdoNonFactoryEmployee = new System.Windows.Forms.RadioButton();
            this.rdoFactoryEmployee = new System.Windows.Forms.RadioButton();
            this.rdoAllEmployee = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 182;
            this.label3.Text = "Company";
            // 
            // cboCompany
            // 
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(71, 12);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(172, 21);
            this.cboCompany.TabIndex = 181;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 180;
            this.label8.Text = "Department";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(317, 12);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(189, 21);
            this.cboDepartment.TabIndex = 179;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(291, 69);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 177;
            this.lblTo.Text = "To";
            this.lblTo.Click += new System.EventHandler(this.lblTo_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(35, 69);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 175;
            this.lblDate.Text = "From";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(317, 66);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(189, 20);
            this.dtToDate.TabIndex = 178;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(71, 66);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(172, 20);
            this.dtFromDate.TabIndex = 176;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(401, 181);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 27);
            this.btnPrint.TabIndex = 174;
            this.btnPrint.Tag = "";
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // rbEmployeeWise
            // 
            this.rbEmployeeWise.AutoSize = true;
            this.rbEmployeeWise.Checked = true;
            this.rbEmployeeWise.Location = new System.Drawing.Point(2, 18);
            this.rbEmployeeWise.Name = "rbEmployeeWise";
            this.rbEmployeeWise.Size = new System.Drawing.Size(98, 17);
            this.rbEmployeeWise.TabIndex = 183;
            this.rbEmployeeWise.TabStop = true;
            this.rbEmployeeWise.Text = "Employee Wise";
            this.rbEmployeeWise.UseVisualStyleBackColor = true;
            // 
            // rbDepartmentWise
            // 
            this.rbDepartmentWise.AutoSize = true;
            this.rbDepartmentWise.Location = new System.Drawing.Point(106, 18);
            this.rbDepartmentWise.Name = "rbDepartmentWise";
            this.rbDepartmentWise.Size = new System.Drawing.Size(107, 17);
            this.rbDepartmentWise.TabIndex = 184;
            this.rbDepartmentWise.Text = "Department Wise";
            this.rbDepartmentWise.UseVisualStyleBackColor = true;
            // 
            // rbDateWise
            // 
            this.rbDateWise.AutoSize = true;
            this.rbDateWise.Location = new System.Drawing.Point(219, 18);
            this.rbDateWise.Name = "rbDateWise";
            this.rbDateWise.Size = new System.Drawing.Size(75, 17);
            this.rbDateWise.TabIndex = 185;
            this.rbDateWise.Text = "Date Wise";
            this.rbDateWise.UseVisualStyleBackColor = true;
            // 
            // chkIsAttendanceEmployee
            // 
            this.chkIsAttendanceEmployee.AutoSize = true;
            this.chkIsAttendanceEmployee.Checked = true;
            this.chkIsAttendanceEmployee.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsAttendanceEmployee.Location = new System.Drawing.Point(79, 181);
            this.chkIsAttendanceEmployee.Name = "chkIsAttendanceEmployee";
            this.chkIsAttendanceEmployee.Size = new System.Drawing.Size(141, 17);
            this.chkIsAttendanceEmployee.TabIndex = 186;
            this.chkIsAttendanceEmployee.Text = "Is Attendance Employee";
            this.chkIsAttendanceEmployee.UseVisualStyleBackColor = true;
            // 
            // rdoNonFactoryEmployee
            // 
            this.rdoNonFactoryEmployee.AutoSize = true;
            this.rdoNonFactoryEmployee.Location = new System.Drawing.Point(212, 18);
            this.rdoNonFactoryEmployee.Name = "rdoNonFactoryEmployee";
            this.rdoNonFactoryEmployee.Size = new System.Drawing.Size(132, 17);
            this.rdoNonFactoryEmployee.TabIndex = 189;
            this.rdoNonFactoryEmployee.Text = "Non Factory Employee";
            this.rdoNonFactoryEmployee.UseVisualStyleBackColor = true;
            // 
            // rdoFactoryEmployee
            // 
            this.rdoFactoryEmployee.AutoSize = true;
            this.rdoFactoryEmployee.Location = new System.Drawing.Point(97, 18);
            this.rdoFactoryEmployee.Name = "rdoFactoryEmployee";
            this.rdoFactoryEmployee.Size = new System.Drawing.Size(109, 17);
            this.rdoFactoryEmployee.TabIndex = 188;
            this.rdoFactoryEmployee.Text = "Factory Employee";
            this.rdoFactoryEmployee.UseVisualStyleBackColor = true;
            // 
            // rdoAllEmployee
            // 
            this.rdoAllEmployee.AutoSize = true;
            this.rdoAllEmployee.Checked = true;
            this.rdoAllEmployee.Location = new System.Drawing.Point(6, 18);
            this.rdoAllEmployee.Name = "rdoAllEmployee";
            this.rdoAllEmployee.Size = new System.Drawing.Size(85, 17);
            this.rdoAllEmployee.TabIndex = 187;
            this.rdoAllEmployee.TabStop = true;
            this.rdoAllEmployee.Text = "All Employee";
            this.rdoAllEmployee.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 191;
            this.label1.Text = "Location";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(71, 39);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(172, 21);
            this.cmbLocation.TabIndex = 190;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEmployeeWise);
            this.groupBox1.Controls.Add(this.rbDepartmentWise);
            this.groupBox1.Controls.Add(this.rbDateWise);
            this.groupBox1.Location = new System.Drawing.Point(71, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 41);
            this.groupBox1.TabIndex = 192;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoAllEmployee);
            this.groupBox2.Controls.Add(this.rdoFactoryEmployee);
            this.groupBox2.Controls.Add(this.rdoNonFactoryEmployee);
            this.groupBox2.Location = new System.Drawing.Point(73, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 41);
            this.groupBox2.TabIndex = 193;
            this.groupBox2.TabStop = false;
            // 
            // frmAttendReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 215);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.chkIsAttendanceEmployee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnPrint);
            this.Name = "frmAttendReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attend Reports";
            this.Load += new System.EventHandler(this.frmAttendReports_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rbEmployeeWise;
        private System.Windows.Forms.RadioButton rbDepartmentWise;
        private System.Windows.Forms.RadioButton rbDateWise;
        private System.Windows.Forms.CheckBox chkIsAttendanceEmployee;
        private System.Windows.Forms.RadioButton rdoNonFactoryEmployee;
        private System.Windows.Forms.RadioButton rdoFactoryEmployee;
        private System.Windows.Forms.RadioButton rdoAllEmployee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}