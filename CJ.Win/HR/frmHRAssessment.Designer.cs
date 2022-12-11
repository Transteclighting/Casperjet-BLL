namespace CJ.Win.HR
{
    partial class frmHRAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHRAssessment));
            this.cmbAssessmentType = new System.Windows.Forms.ComboBox();
            this.btClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.txtGrossSalary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLastIncrementAmount = new System.Windows.Forms.TextBox();
            this.udAssessmentYear = new System.Windows.Forms.NumericUpDown();
            this.udLastPromotion = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtxAcademicQualification = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSalesTarget = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSalesActual = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dtTargetTo = new System.Windows.Forms.DateTimePicker();
            this.dtTargetFrom = new System.Windows.Forms.DateTimePicker();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctlEmployee2 = new CJ.Win.ctlEmployee();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.chkPromotionYear = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.udAssessmentYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLastPromotion)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAssessmentType
            // 
            this.cmbAssessmentType.FormattingEnabled = true;
            this.cmbAssessmentType.Location = new System.Drawing.Point(128, 43);
            this.cmbAssessmentType.Name = "cmbAssessmentType";
            this.cmbAssessmentType.Size = new System.Drawing.Size(125, 21);
            this.cmbAssessmentType.TabIndex = 3;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(462, 327);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 32;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Assessment Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Assessment Year:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(128, 70);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(125, 20);
            this.dtFromDate.TabIndex = 7;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(412, 70);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(125, 20);
            this.dtToDate.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "From Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "To Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Employee:";
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.Location = new System.Drawing.Point(128, 96);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(125, 20);
            this.txtBasicSalary.TabIndex = 11;
            this.txtBasicSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBasicSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBasicSalary_KeyPress);
            // 
            // txtGrossSalary
            // 
            this.txtGrossSalary.Location = new System.Drawing.Point(412, 96);
            this.txtGrossSalary.Name = "txtGrossSalary";
            this.txtGrossSalary.Size = new System.Drawing.Size(125, 20);
            this.txtGrossSalary.TabIndex = 13;
            this.txtGrossSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGrossSalary.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGrossSalary_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Basic Salary:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(337, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Gross Salary:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Last Increment Amount:";
            // 
            // txtLastIncrementAmount
            // 
            this.txtLastIncrementAmount.Location = new System.Drawing.Point(128, 122);
            this.txtLastIncrementAmount.Name = "txtLastIncrementAmount";
            this.txtLastIncrementAmount.Size = new System.Drawing.Size(125, 20);
            this.txtLastIncrementAmount.TabIndex = 15;
            this.txtLastIncrementAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLastIncrementAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastIncrementAmount_KeyPress);
            // 
            // udAssessmentYear
            // 
            this.udAssessmentYear.Location = new System.Drawing.Point(412, 43);
            this.udAssessmentYear.Maximum = new decimal(new int[] {
            2200,
            0,
            0,
            0});
            this.udAssessmentYear.Minimum = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.udAssessmentYear.Name = "udAssessmentYear";
            this.udAssessmentYear.Size = new System.Drawing.Size(125, 20);
            this.udAssessmentYear.TabIndex = 5;
            this.udAssessmentYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udAssessmentYear.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            // 
            // udLastPromotion
            // 
            this.udLastPromotion.Location = new System.Drawing.Point(433, 122);
            this.udLastPromotion.Maximum = new decimal(new int[] {
            2200,
            0,
            0,
            0});
            this.udLastPromotion.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.udLastPromotion.Name = "udLastPromotion";
            this.udLastPromotion.Size = new System.Drawing.Size(104, 20);
            this.udLastPromotion.TabIndex = 17;
            this.udLastPromotion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udLastPromotion.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(289, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Year of Last Promotion:";
            // 
            // txtxAcademicQualification
            // 
            this.txtxAcademicQualification.Location = new System.Drawing.Point(128, 148);
            this.txtxAcademicQualification.Multiline = true;
            this.txtxAcademicQualification.Name = "txtxAcademicQualification";
            this.txtxAcademicQualification.Size = new System.Drawing.Size(409, 74);
            this.txtxAcademicQualification.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Academic Qualification:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Line Manager Name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(57, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Sales Target:";
            // 
            // txtSalesTarget
            // 
            this.txtSalesTarget.Location = new System.Drawing.Point(128, 259);
            this.txtSalesTarget.Name = "txtSalesTarget";
            this.txtSalesTarget.Size = new System.Drawing.Size(125, 20);
            this.txtSalesTarget.TabIndex = 23;
            this.txtSalesTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalesTarget.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesTarget_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(339, 262);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Sales Actual:";
            // 
            // txtSalesActual
            // 
            this.txtSalesActual.Location = new System.Drawing.Point(412, 259);
            this.txtSalesActual.Name = "txtSalesActual";
            this.txtSalesActual.Size = new System.Drawing.Size(125, 20);
            this.txtSalesActual.TabIndex = 24;
            this.txtSalesActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalesActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSalesActual_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(322, 288);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(86, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Sales Target To:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 289);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 13);
            this.label15.TabIndex = 26;
            this.label15.Text = "Sales Target Form:";
            // 
            // dtTargetTo
            // 
            this.dtTargetTo.CustomFormat = "dd-MMM-yyyy";
            this.dtTargetTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTargetTo.Location = new System.Drawing.Point(412, 285);
            this.dtTargetTo.Name = "dtTargetTo";
            this.dtTargetTo.Size = new System.Drawing.Size(125, 20);
            this.dtTargetTo.TabIndex = 29;
            // 
            // dtTargetFrom
            // 
            this.dtTargetFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtTargetFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTargetFrom.Location = new System.Drawing.Point(128, 285);
            this.dtTargetFrom.Name = "dtTargetFrom";
            this.dtTargetFrom.Size = new System.Drawing.Size(125, 20);
            this.dtTargetFrom.TabIndex = 27;
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(128, 311);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(67, 17);
            this.chkIsActive.TabIndex = 30;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(381, 327);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctlEmployee2
            // 
            this.ctlEmployee2.Location = new System.Drawing.Point(128, 230);
            this.ctlEmployee2.Name = "ctlEmployee2";
            this.ctlEmployee2.Size = new System.Drawing.Size(415, 25);
            this.ctlEmployee2.TabIndex = 21;
            //this.ctlEmployee2.ChangeSelection += new System.EventHandler(this.ctlEmployee2_ChangeSelection);
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(128, 12);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(415, 25);
            this.ctlEmployee1.TabIndex = 1;
            this.ctlEmployee1.ChangeSelection += new System.EventHandler(this.ctlEmployee1_ChangeSelection);
            // 
            // chkPromotionYear
            // 
            this.chkPromotionYear.AutoSize = true;
            this.chkPromotionYear.Location = new System.Drawing.Point(412, 125);
            this.chkPromotionYear.Name = "chkPromotionYear";
            this.chkPromotionYear.Size = new System.Drawing.Size(15, 14);
            this.chkPromotionYear.TabIndex = 33;
            this.chkPromotionYear.UseVisualStyleBackColor = true;
            this.chkPromotionYear.CheckedChanged += new System.EventHandler(this.chkPromotionYear_CheckedChanged);
            // 
            // frmHRAssessment
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 357);
            this.Controls.Add(this.chkPromotionYear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtTargetTo);
            this.Controls.Add(this.dtTargetFrom);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSalesActual);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSalesTarget);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ctlEmployee2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtxAcademicQualification);
            this.Controls.Add(this.udLastPromotion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.udAssessmentYear);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtLastIncrementAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGrossSalary);
            this.Controls.Add(this.txtBasicSalary);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.cmbAssessmentType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHRAssessment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHRAssessment";
            this.Load += new System.EventHandler(this.frmHRAssessment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.udAssessmentYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udLastPromotion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAssessmentType;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBasicSalary;
        private System.Windows.Forms.TextBox txtGrossSalary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLastIncrementAmount;
        private System.Windows.Forms.NumericUpDown udAssessmentYear;
        private System.Windows.Forms.NumericUpDown udLastPromotion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtxAcademicQualification;
        private System.Windows.Forms.Label label10;
        private ctlEmployee ctlEmployee2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSalesTarget;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSalesActual;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtTargetTo;
        private System.Windows.Forms.DateTimePicker dtTargetFrom;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkPromotionYear;
    }
}