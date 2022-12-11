namespace CJ.Win.HR
{
    partial class frmPFReport
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
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblBillMonth = new System.Windows.Forms.Label();
            this.dtMonth = new System.Windows.Forms.DateTimePicker();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.rdoPFSchedule = new System.Windows.Forms.RadioButton();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoDisbursement = new System.Windows.Forms.RadioButton();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblIsEarlyClose = new System.Windows.Forms.Label();
            this.cmbIsEarlyClose = new System.Windows.Forms.ComboBox();
            this.cmbLoanType = new System.Windows.Forms.ComboBox();
            this.cmbSubLoanType = new System.Windows.Forms.ComboBox();
            this.lblSubLoanType = new System.Windows.Forms.Label();
            this.lblLoanType = new System.Windows.Forms.Label();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(357, 183);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(86, 29);
            this.btnPreview.TabIndex = 19;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(18, 160);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(53, 13);
            this.lblEmployee.TabIndex = 17;
            this.lblEmployee.Text = "Employee";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(19, 14);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Company";
            // 
            // lblBillMonth
            // 
            this.lblBillMonth.AutoSize = true;
            this.lblBillMonth.Location = new System.Drawing.Point(33, 104);
            this.lblBillMonth.Name = "lblBillMonth";
            this.lblBillMonth.Size = new System.Drawing.Size(37, 13);
            this.lblBillMonth.TabIndex = 7;
            this.lblBillMonth.Text = "Month";
            // 
            // dtMonth
            // 
            this.dtMonth.CustomFormat = "MMM-yyyy";
            this.dtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMonth.Location = new System.Drawing.Point(72, 100);
            this.dtMonth.Name = "dtMonth";
            this.dtMonth.ShowUpDown = true;
            this.dtMonth.Size = new System.Drawing.Size(84, 23);
            this.dtMonth.TabIndex = 8;
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(72, 12);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(365, 21);
            this.cmbCompany.TabIndex = 1;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(72, 39);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(365, 21);
            this.cmbDepartment.TabIndex = 3;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(9, 42);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Department";
            // 
            // rdoPFSchedule
            // 
            this.rdoPFSchedule.AutoSize = true;
            this.rdoPFSchedule.Checked = true;
            this.rdoPFSchedule.Location = new System.Drawing.Point(72, 70);
            this.rdoPFSchedule.Name = "rdoPFSchedule";
            this.rdoPFSchedule.Size = new System.Drawing.Size(86, 17);
            this.rdoPFSchedule.TabIndex = 4;
            this.rdoPFSchedule.TabStop = true;
            this.rdoPFSchedule.Text = "PF Schedule";
            this.rdoPFSchedule.UseVisualStyleBackColor = true;
            this.rdoPFSchedule.CheckedChanged += new System.EventHandler(this.rdoPFSchedule_CheckedChanged);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(190, 70);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(97, 17);
            this.rdoAll.TabIndex = 5;
            this.rdoAll.Text = "Loan Schedule";
            this.rdoAll.UseVisualStyleBackColor = true;
            this.rdoAll.CheckedChanged += new System.EventHandler(this.rdoAll_CheckedChanged);
            // 
            // rdoDisbursement
            // 
            this.rdoDisbursement.AutoSize = true;
            this.rdoDisbursement.Location = new System.Drawing.Point(317, 70);
            this.rdoDisbursement.Name = "rdoDisbursement";
            this.rdoDisbursement.Size = new System.Drawing.Size(116, 17);
            this.rdoDisbursement.TabIndex = 6;
            this.rdoDisbursement.Text = "Loan Disbursement";
            this.rdoDisbursement.UseVisualStyleBackColor = true;
            this.rdoDisbursement.CheckedChanged += new System.EventHandler(this.rdoDisbursement_CheckedChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(204, 130);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(105, 21);
            this.cmbStatus.TabIndex = 14;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(166, 133);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status";
            // 
            // lblIsEarlyClose
            // 
            this.lblIsEarlyClose.AutoSize = true;
            this.lblIsEarlyClose.Location = new System.Drawing.Point(311, 133);
            this.lblIsEarlyClose.Name = "lblIsEarlyClose";
            this.lblIsEarlyClose.Size = new System.Drawing.Size(70, 13);
            this.lblIsEarlyClose.TabIndex = 15;
            this.lblIsEarlyClose.Text = "Is Early Close";
            // 
            // cmbIsEarlyClose
            // 
            this.cmbIsEarlyClose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsEarlyClose.FormattingEnabled = true;
            this.cmbIsEarlyClose.Location = new System.Drawing.Point(379, 130);
            this.cmbIsEarlyClose.Name = "cmbIsEarlyClose";
            this.cmbIsEarlyClose.Size = new System.Drawing.Size(61, 21);
            this.cmbIsEarlyClose.TabIndex = 16;
            // 
            // cmbLoanType
            // 
            this.cmbLoanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoanType.FormattingEnabled = true;
            this.cmbLoanType.Location = new System.Drawing.Point(281, 101);
            this.cmbLoanType.Name = "cmbLoanType";
            this.cmbLoanType.Size = new System.Drawing.Size(158, 21);
            this.cmbLoanType.TabIndex = 10;
            this.cmbLoanType.SelectedIndexChanged += new System.EventHandler(this.cmbLoanType_SelectedIndexChanged);
            // 
            // cmbSubLoanType
            // 
            this.cmbSubLoanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubLoanType.FormattingEnabled = true;
            this.cmbSubLoanType.Location = new System.Drawing.Point(72, 129);
            this.cmbSubLoanType.Name = "cmbSubLoanType";
            this.cmbSubLoanType.Size = new System.Drawing.Size(84, 21);
            this.cmbSubLoanType.TabIndex = 12;
            // 
            // lblSubLoanType
            // 
            this.lblSubLoanType.AutoSize = true;
            this.lblSubLoanType.Location = new System.Drawing.Point(9, 132);
            this.lblSubLoanType.Name = "lblSubLoanType";
            this.lblSubLoanType.Size = new System.Drawing.Size(63, 13);
            this.lblSubLoanType.TabIndex = 11;
            this.lblSubLoanType.Text = "Article Type";
            // 
            // lblLoanType
            // 
            this.lblLoanType.AutoSize = true;
            this.lblLoanType.Location = new System.Drawing.Point(222, 104);
            this.lblLoanType.Name = "lblLoanType";
            this.lblLoanType.Size = new System.Drawing.Size(58, 13);
            this.lblLoanType.TabIndex = 9;
            this.lblLoanType.Text = "Loan Type";
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(73, 157);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(374, 25);
            this.ctlEmployee1.TabIndex = 18;
            // 
            // frmPFReport
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 221);
            this.Controls.Add(this.cmbLoanType);
            this.Controls.Add(this.cmbSubLoanType);
            this.Controls.Add(this.lblSubLoanType);
            this.Controls.Add(this.lblLoanType);
            this.Controls.Add(this.cmbIsEarlyClose);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.rdoDisbursement);
            this.Controls.Add(this.rdoAll);
            this.Controls.Add(this.rdoPFSchedule);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblIsEarlyClose);
            this.Controls.Add(this.lblBillMonth);
            this.Controls.Add(this.dtMonth);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPFReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loan Report";
            this.Load += new System.EventHandler(this.frmPFReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblBillMonth;
        private System.Windows.Forms.DateTimePicker dtMonth;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.RadioButton rdoPFSchedule;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoDisbursement;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblIsEarlyClose;
        private System.Windows.Forms.ComboBox cmbIsEarlyClose;
        private System.Windows.Forms.ComboBox cmbLoanType;
        private System.Windows.Forms.ComboBox cmbSubLoanType;
        private System.Windows.Forms.Label lblSubLoanType;
        private System.Windows.Forms.Label lblLoanType;
    }
}