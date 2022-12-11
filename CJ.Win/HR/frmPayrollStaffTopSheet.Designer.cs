namespace CJ.Win.HR
{
    partial class frmPayrollStaffTopSheet
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtSalaryMonth = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.rdoSalary = new System.Windows.Forms.RadioButton();
            this.rdoBonus = new System.Windows.Forms.RadioButton();
            this.rdoLFA = new System.Windows.Forms.RadioButton();
            this.rdoArear = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Salary Month";
            // 
            // dtSalaryMonth
            // 
            this.dtSalaryMonth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalaryMonth.CustomFormat = "MMM-yyyy";
            this.dtSalaryMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalaryMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSalaryMonth.Location = new System.Drawing.Point(89, 50);
            this.dtSalaryMonth.Name = "dtSalaryMonth";
            this.dtSalaryMonth.ShowUpDown = true;
            this.dtSalaryMonth.Size = new System.Drawing.Size(95, 23);
            this.dtSalaryMonth.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(89, 23);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(198, 21);
            this.cmbCompany.TabIndex = 7;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(209, 120);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(92, 27);
            this.btnPreview.TabIndex = 18;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // rdoSalary
            // 
            this.rdoSalary.AutoSize = true;
            this.rdoSalary.Checked = true;
            this.rdoSalary.Location = new System.Drawing.Point(13, 81);
            this.rdoSalary.Name = "rdoSalary";
            this.rdoSalary.Size = new System.Drawing.Size(54, 17);
            this.rdoSalary.TabIndex = 19;
            this.rdoSalary.TabStop = true;
            this.rdoSalary.Text = "Salary";
            this.rdoSalary.UseVisualStyleBackColor = true;
            this.rdoSalary.CheckedChanged += new System.EventHandler(this.rdoSalary_CheckedChanged);
            // 
            // rdoBonus
            // 
            this.rdoBonus.AutoSize = true;
            this.rdoBonus.Location = new System.Drawing.Point(70, 81);
            this.rdoBonus.Name = "rdoBonus";
            this.rdoBonus.Size = new System.Drawing.Size(83, 17);
            this.rdoBonus.TabIndex = 20;
            this.rdoBonus.Text = "Bonus (only)";
            this.rdoBonus.UseVisualStyleBackColor = true;
            // 
            // rdoLFA
            // 
            this.rdoLFA.AutoSize = true;
            this.rdoLFA.Location = new System.Drawing.Point(160, 81);
            this.rdoLFA.Name = "rdoLFA";
            this.rdoLFA.Size = new System.Drawing.Size(72, 17);
            this.rdoLFA.TabIndex = 21;
            this.rdoLFA.Text = "LFA (only)";
            this.rdoLFA.UseVisualStyleBackColor = true;
            // 
            // rdoArear
            // 
            this.rdoArear.AutoSize = true;
            this.rdoArear.Location = new System.Drawing.Point(236, 81);
            this.rdoArear.Name = "rdoArear";
            this.rdoArear.Size = new System.Drawing.Size(50, 17);
            this.rdoArear.TabIndex = 22;
            this.rdoArear.Text = "Arear";
            this.rdoArear.UseVisualStyleBackColor = true;
            this.rdoArear.CheckedChanged += new System.EventHandler(this.rdoArear_CheckedChanged);
            // 
            // frmPayrollStaffTopSheet
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 162);
            this.Controls.Add(this.rdoArear);
            this.Controls.Add(this.rdoLFA);
            this.Controls.Add(this.rdoBonus);
            this.Controls.Add(this.rdoSalary);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtSalaryMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayrollStaffTopSheet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payroll Staff Top Sheet Print";
            this.Load += new System.EventHandler(this.frmPayrollStaffTopSheet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtSalaryMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.RadioButton rdoSalary;
        private System.Windows.Forms.RadioButton rdoBonus;
        private System.Windows.Forms.RadioButton rdoLFA;
        private System.Windows.Forms.RadioButton rdoArear;
    }
}