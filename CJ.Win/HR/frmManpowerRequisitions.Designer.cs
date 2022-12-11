namespace CJ.Win.HR
{
    partial class frmManpowerRequisitions
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMRNo = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwHRManpowerRequisitions = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.RequisitionNo = new System.Windows.Forms.ColumnHeader();
            this.colRequisitionDate = new System.Windows.Forms.ColumnHeader();
            this.VacancyType = new System.Windows.Forms.ColumnHeader();
            this.ReplacementDetail = new System.Windows.Forms.ColumnHeader();
            this.Department = new System.Windows.Forms.ColumnHeader();
            this.Designation = new System.Windows.Forms.ColumnHeader();
            this.JobGradeName = new System.Windows.Forms.ColumnHeader();
            this.Reportto = new System.Windows.Forms.ColumnHeader();
            this.NoOfVacancy = new System.Windows.Forms.ColumnHeader();
            this.TypeOfEmployment = new System.Windows.Forms.ColumnHeader();
            this.ContractPeriod = new System.Windows.Forms.ColumnHeader();
            this.EmployeementStatus = new System.Windows.Forms.ColumnHeader();
            this.EducationalQualification = new System.Windows.Forms.ColumnHeader();
            this.EducationMajor = new System.Windows.Forms.ColumnHeader();
            this.Age = new System.Windows.Forms.ColumnHeader();
            this.SalaryRange = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(819, 157);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 121;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(819, 126);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 25);
            this.btnAdd.TabIndex = 120;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(819, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 122;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Location = new System.Drawing.Point(328, 91);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(76, 29);
            this.btnGetData.TabIndex = 119;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 129;
            this.label6.Text = "Requisition No";
            // 
            // txtMRNo
            // 
            this.txtMRNo.Location = new System.Drawing.Point(110, 70);
            this.txtMRNo.Name = "txtMRNo";
            this.txtMRNo.Size = new System.Drawing.Size(211, 20);
            this.txtMRNo.TabIndex = 117;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(8, 1);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 125;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(210, 24);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(108, 20);
            this.dtToDate.TabIndex = 113;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(55, 33);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(116, 20);
            this.dtFromDate.TabIndex = 112;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 124;
            this.label3.Text = "From";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAll);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 55);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    ";
            // 
            // lvwHRManpowerRequisitions
            // 
            this.lvwHRManpowerRequisitions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwHRManpowerRequisitions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RequisitionNo,
            this.colRequisitionDate,
            this.VacancyType,
            this.ReplacementDetail,
            this.Department,
            this.Designation,
            this.NoOfVacancy,
            this.JobGradeName,
            this.TypeOfEmployment,
            this.ContractPeriod,
            this.EmployeementStatus,
            this.EducationalQualification,
            this.EducationMajor,
            this.Age,
            this.SalaryRange,
            this.Reportto});
            this.lvwHRManpowerRequisitions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lvwHRManpowerRequisitions.FullRowSelect = true;
            this.lvwHRManpowerRequisitions.GridLines = true;
            this.lvwHRManpowerRequisitions.HideSelection = false;
            this.lvwHRManpowerRequisitions.Location = new System.Drawing.Point(18, 126);
            this.lvwHRManpowerRequisitions.MultiSelect = false;
            this.lvwHRManpowerRequisitions.Name = "lvwHRManpowerRequisitions";
            this.lvwHRManpowerRequisitions.Size = new System.Drawing.Size(795, 295);
            this.lvwHRManpowerRequisitions.TabIndex = 123;
            this.lvwHRManpowerRequisitions.UseCompatibleStateImageBehavior = false;
            this.lvwHRManpowerRequisitions.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Department";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(110, 96);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(211, 21);
            this.cmbDepartment.TabIndex = 118;
            // 
            // RequisitionNo
            // 
            this.RequisitionNo.Text = "Requisition No";
            this.RequisitionNo.Width = 89;
            // 
            // colRequisitionDate
            // 
            this.colRequisitionDate.Text = "Requisition Date";
            this.colRequisitionDate.Width = 100;
            // 
            // VacancyType
            // 
            this.VacancyType.Text = "Vacancy Type";
            this.VacancyType.Width = 86;
            // 
            // ReplacementDetail
            // 
            this.ReplacementDetail.Text = "Replacement Detail";
            this.ReplacementDetail.Width = 121;
            // 
            // Department
            // 
            this.Department.Text = "Department";
            this.Department.Width = 106;
            // 
            // Designation
            // 
            this.Designation.Text = "Designation";
            this.Designation.Width = 91;
            // 
            // JobGradeName
            // 
            this.JobGradeName.Text = "Job Grade";
            this.JobGradeName.Width = 112;
            // 
            // Reportto
            // 
            this.Reportto.Text = "Report To";
            // 
            // NoOfVacancy
            // 
            this.NoOfVacancy.Text = "No Of Vacancy";
            this.NoOfVacancy.Width = 130;
            // 
            // TypeOfEmployment
            // 
            this.TypeOfEmployment.Text = "Type Of Employment";
            this.TypeOfEmployment.Width = 115;
            // 
            // ContractPeriod
            // 
            this.ContractPeriod.Text = "Contract Period";
            this.ContractPeriod.Width = 103;
            // 
            // EmployeementStatus
            // 
            this.EmployeementStatus.Text = "Employeement Status";
            this.EmployeementStatus.Width = 122;
            // 
            // EducationalQualification
            // 
            this.EducationalQualification.Text = "Educational Qualification";
            this.EducationalQualification.Width = 138;
            // 
            // EducationMajor
            // 
            this.EducationMajor.Text = "Education Major";
            // 
            // Age
            // 
            this.Age.Text = "Age";
            // 
            // SalaryRange
            // 
            this.SalaryRange.Text = "Salary Range";
            // 
            // frmManpowerRequisitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 444);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMRNo);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwHRManpowerRequisitions);
            this.Name = "frmManpowerRequisitions";
            this.Text = "frmManpowerRequisitions";
            this.Load += new System.EventHandler(this.frmManpowerRequisitions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMRNo;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvwHRManpowerRequisitions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ColumnHeader RequisitionNo;
        private System.Windows.Forms.ColumnHeader colRequisitionDate;
        private System.Windows.Forms.ColumnHeader VacancyType;
        private System.Windows.Forms.ColumnHeader ReplacementDetail;
        private System.Windows.Forms.ColumnHeader Department;
        private System.Windows.Forms.ColumnHeader Designation;
        private System.Windows.Forms.ColumnHeader JobGradeName;
        private System.Windows.Forms.ColumnHeader Reportto;
        private System.Windows.Forms.ColumnHeader NoOfVacancy;
        private System.Windows.Forms.ColumnHeader TypeOfEmployment;
        private System.Windows.Forms.ColumnHeader ContractPeriod;
        private System.Windows.Forms.ColumnHeader EmployeementStatus;
        private System.Windows.Forms.ColumnHeader EducationalQualification;
        private System.Windows.Forms.ColumnHeader EducationMajor;
        private System.Windows.Forms.ColumnHeader Age;
        private System.Windows.Forms.ColumnHeader SalaryRange;
    }
}