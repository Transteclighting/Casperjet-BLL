namespace CJ.Win.HR
{
    partial class frmMobileBillViewReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMobileBillViewReport));
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblBillMonth = new System.Windows.Forms.Label();
            this.dtBillMonth = new System.Windows.Forms.DateTimePicker();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoOverLimit = new System.Windows.Forms.RadioButton();
            this.btnPreview = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdoEmployeeAll = new System.Windows.Forms.RadioButton();
            this.rdoNonEmployee = new System.Windows.Forms.RadioButton();
            this.rdoEmployee = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoEmployeeWise = new System.Windows.Forms.RadioButton();
            this.rdoDepartmentSummary = new System.Windows.Forms.RadioButton();
            this.cmbSpecialUserCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoUnsavd = new System.Windows.Forms.RadioButton();
            this.rdoSaved = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(21, 14);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Company";
            // 
            // lblBillMonth
            // 
            this.lblBillMonth.AutoSize = true;
            this.lblBillMonth.Location = new System.Drawing.Point(203, 70);
            this.lblBillMonth.Name = "lblBillMonth";
            this.lblBillMonth.Size = new System.Drawing.Size(53, 13);
            this.lblBillMonth.TabIndex = 6;
            this.lblBillMonth.Text = "Bill Month";
            // 
            // dtBillMonth
            // 
            this.dtBillMonth.CustomFormat = "MMM-yyyy";
            this.dtBillMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBillMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBillMonth.Location = new System.Drawing.Point(255, 66);
            this.dtBillMonth.Name = "dtBillMonth";
            this.dtBillMonth.ShowUpDown = true;
            this.dtBillMonth.Size = new System.Drawing.Size(108, 23);
            this.dtBillMonth.TabIndex = 7;
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(74, 12);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(289, 21);
            this.cmbCompany.TabIndex = 1;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(74, 39);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(289, 21);
            this.cmbDepartment.TabIndex = 3;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(10, 41);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Department";
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(108, 15);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 1;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoOverLimit
            // 
            this.rdoOverLimit.AutoSize = true;
            this.rdoOverLimit.Location = new System.Drawing.Point(8, 15);
            this.rdoOverLimit.Name = "rdoOverLimit";
            this.rdoOverLimit.Size = new System.Drawing.Size(94, 17);
            this.rdoOverLimit.TabIndex = 0;
            this.rdoOverLimit.TabStop = true;
            this.rdoOverLimit.Text = "Use Over Limit";
            this.rdoOverLimit.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(344, 190);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(86, 29);
            this.btnPreview.TabIndex = 12;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoOverLimit);
            this.groupBox1.Controls.Add(this.rdoAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 41);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Uses Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdoEmployeeAll);
            this.groupBox2.Controls.Add(this.rdoNonEmployee);
            this.groupBox2.Controls.Add(this.rdoEmployee);
            this.groupBox2.Location = new System.Drawing.Point(12, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 41);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Type";
            // 
            // rdoEmployeeAll
            // 
            this.rdoEmployeeAll.AutoSize = true;
            this.rdoEmployeeAll.Location = new System.Drawing.Point(202, 15);
            this.rdoEmployeeAll.Name = "rdoEmployeeAll";
            this.rdoEmployeeAll.Size = new System.Drawing.Size(36, 17);
            this.rdoEmployeeAll.TabIndex = 2;
            this.rdoEmployeeAll.TabStop = true;
            this.rdoEmployeeAll.Text = "All";
            this.rdoEmployeeAll.UseVisualStyleBackColor = true;
            // 
            // rdoNonEmployee
            // 
            this.rdoNonEmployee.AutoSize = true;
            this.rdoNonEmployee.Location = new System.Drawing.Point(102, 15);
            this.rdoNonEmployee.Name = "rdoNonEmployee";
            this.rdoNonEmployee.Size = new System.Drawing.Size(94, 17);
            this.rdoNonEmployee.TabIndex = 1;
            this.rdoNonEmployee.TabStop = true;
            this.rdoNonEmployee.Text = "Non Employee";
            this.rdoNonEmployee.UseVisualStyleBackColor = true;
            // 
            // rdoEmployee
            // 
            this.rdoEmployee.AutoSize = true;
            this.rdoEmployee.Location = new System.Drawing.Point(9, 15);
            this.rdoEmployee.Name = "rdoEmployee";
            this.rdoEmployee.Size = new System.Drawing.Size(71, 17);
            this.rdoEmployee.TabIndex = 0;
            this.rdoEmployee.TabStop = true;
            this.rdoEmployee.Text = "Employee";
            this.rdoEmployee.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoEmployeeWise);
            this.groupBox3.Controls.Add(this.rdoDepartmentSummary);
            this.groupBox3.Location = new System.Drawing.Point(194, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 41);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Report Type";
            // 
            // rdoEmployeeWise
            // 
            this.rdoEmployeeWise.AutoSize = true;
            this.rdoEmployeeWise.Location = new System.Drawing.Point(8, 15);
            this.rdoEmployeeWise.Name = "rdoEmployeeWise";
            this.rdoEmployeeWise.Size = new System.Drawing.Size(98, 17);
            this.rdoEmployeeWise.TabIndex = 0;
            this.rdoEmployeeWise.TabStop = true;
            this.rdoEmployeeWise.Text = "Employee Wise";
            this.rdoEmployeeWise.UseVisualStyleBackColor = true;
            // 
            // rdoDepartmentSummary
            // 
            this.rdoDepartmentSummary.AutoSize = true;
            this.rdoDepartmentSummary.Location = new System.Drawing.Point(108, 15);
            this.rdoDepartmentSummary.Name = "rdoDepartmentSummary";
            this.rdoDepartmentSummary.Size = new System.Drawing.Size(126, 17);
            this.rdoDepartmentSummary.TabIndex = 1;
            this.rdoDepartmentSummary.TabStop = true;
            this.rdoDepartmentSummary.Text = "Department Summary";
            this.rdoDepartmentSummary.UseVisualStyleBackColor = true;
            // 
            // cmbSpecialUserCategory
            // 
            this.cmbSpecialUserCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialUserCategory.FormattingEnabled = true;
            this.cmbSpecialUserCategory.Location = new System.Drawing.Point(74, 66);
            this.cmbSpecialUserCategory.Name = "cmbSpecialUserCategory";
            this.cmbSpecialUserCategory.Size = new System.Drawing.Size(125, 21);
            this.cmbSpecialUserCategory.TabIndex = 5;
            this.cmbSpecialUserCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSpecialUserCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Special Cat.";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdoUnsavd);
            this.groupBox4.Controls.Add(this.rdoSaved);
            this.groupBox4.Location = new System.Drawing.Point(262, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(168, 41);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bill Status";
            // 
            // rdoUnsavd
            // 
            this.rdoUnsavd.AutoSize = true;
            this.rdoUnsavd.Location = new System.Drawing.Point(80, 15);
            this.rdoUnsavd.Name = "rdoUnsavd";
            this.rdoUnsavd.Size = new System.Drawing.Size(68, 17);
            this.rdoUnsavd.TabIndex = 1;
            this.rdoUnsavd.TabStop = true;
            this.rdoUnsavd.Text = "Unsaved";
            this.rdoUnsavd.UseVisualStyleBackColor = true;
            // 
            // rdoSaved
            // 
            this.rdoSaved.AutoSize = true;
            this.rdoSaved.Location = new System.Drawing.Point(9, 15);
            this.rdoSaved.Name = "rdoSaved";
            this.rdoSaved.Size = new System.Drawing.Size(56, 17);
            this.rdoSaved.TabIndex = 0;
            this.rdoSaved.TabStop = true;
            this.rdoSaved.Text = "Saved";
            this.rdoSaved.UseVisualStyleBackColor = true;
            // 
            // frmMobileBillViewReport
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 227);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSpecialUserCategory);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblBillMonth);
            this.Controls.Add(this.dtBillMonth);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMobileBillViewReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobile Bill View Report";
            this.Load += new System.EventHandler(this.frmMobileBillViewReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblBillMonth;
        private System.Windows.Forms.DateTimePicker dtBillMonth;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoOverLimit;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdoEmployeeAll;
        private System.Windows.Forms.RadioButton rdoNonEmployee;
        private System.Windows.Forms.RadioButton rdoEmployee;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoEmployeeWise;
        private System.Windows.Forms.RadioButton rdoDepartmentSummary;
        private System.Windows.Forms.ComboBox cmbSpecialUserCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoUnsavd;
        private System.Windows.Forms.RadioButton rdoSaved;
    }
}