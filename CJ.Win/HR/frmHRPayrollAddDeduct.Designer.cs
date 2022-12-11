namespace CJ.Win.HR
{
    partial class frmHRPayrollAddDeduct
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
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoAddition = new System.Windows.Forms.RadioButton();
            this.rdoDeduction = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dtMonth = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkLWPCalculator = new System.Windows.Forms.CheckBox();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.gbLWPCalculate = new System.Windows.Forms.GroupBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.rdoNightShift = new System.Windows.Forms.RadioButton();
            this.rdoOthers = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.gbLWPCalculate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(69, 121);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(132, 20);
            this.txtAmount.TabIndex = 8;
            this.txtAmount.Text = "0";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Amount";
            // 
            // rdoAddition
            // 
            this.rdoAddition.AutoSize = true;
            this.rdoAddition.Location = new System.Drawing.Point(71, 68);
            this.rdoAddition.Name = "rdoAddition";
            this.rdoAddition.Size = new System.Drawing.Size(63, 17);
            this.rdoAddition.TabIndex = 4;
            this.rdoAddition.TabStop = true;
            this.rdoAddition.Text = "Addition";
            this.rdoAddition.UseVisualStyleBackColor = true;
            this.rdoAddition.CheckedChanged += new System.EventHandler(this.rdoAddition_CheckedChanged);
            // 
            // rdoDeduction
            // 
            this.rdoDeduction.AutoSize = true;
            this.rdoDeduction.Location = new System.Drawing.Point(141, 68);
            this.rdoDeduction.Name = "rdoDeduction";
            this.rdoDeduction.Size = new System.Drawing.Size(74, 17);
            this.rdoDeduction.TabIndex = 5;
            this.rdoDeduction.TabStop = true;
            this.rdoDeduction.Text = "Deduction";
            this.rdoDeduction.UseVisualStyleBackColor = true;
            this.rdoDeduction.CheckedChanged += new System.EventHandler(this.rdoDeduction_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Employee";
            // 
            // dtMonth
            // 
            this.dtMonth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtMonth.CustomFormat = "MMM-yyyy";
            this.dtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMonth.Location = new System.Drawing.Point(70, 14);
            this.dtMonth.Name = "dtMonth";
            this.dtMonth.ShowUpDown = true;
            this.dtMonth.Size = new System.Drawing.Size(83, 23);
            this.dtMonth.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Month";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(318, 178);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 27);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(390, 178);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 27);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(69, 152);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(391, 20);
            this.txtReason.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Reason";
            // 
            // chkLWPCalculator
            // 
            this.chkLWPCalculator.AutoSize = true;
            this.chkLWPCalculator.Location = new System.Drawing.Point(245, 69);
            this.chkLWPCalculator.Name = "chkLWPCalculator";
            this.chkLWPCalculator.Size = new System.Drawing.Size(100, 17);
            this.chkLWPCalculator.TabIndex = 6;
            this.chkLWPCalculator.Text = "LWP Calculator";
            this.chkLWPCalculator.UseVisualStyleBackColor = true;
            this.chkLWPCalculator.CheckedChanged += new System.EventHandler(this.chkLWPCalculator_CheckedChanged);
            // 
            // txtHours
            // 
            this.txtHours.Location = new System.Drawing.Point(44, 10);
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(41, 20);
            this.txtHours.TabIndex = 1;
            this.txtHours.Text = "0";
            this.txtHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hours";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Minute";
            // 
            // txtMinute
            // 
            this.txtMinute.Location = new System.Drawing.Point(128, 10);
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.Size = new System.Drawing.Size(41, 20);
            this.txtMinute.TabIndex = 3;
            this.txtMinute.Text = "0";
            this.txtMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(175, 9);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(59, 23);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // gbLWPCalculate
            // 
            this.gbLWPCalculate.Controls.Add(this.btnCalculate);
            this.gbLWPCalculate.Controls.Add(this.label6);
            this.gbLWPCalculate.Controls.Add(this.txtMinute);
            this.gbLWPCalculate.Controls.Add(this.label5);
            this.gbLWPCalculate.Controls.Add(this.txtHours);
            this.gbLWPCalculate.Location = new System.Drawing.Point(219, 111);
            this.gbLWPCalculate.Name = "gbLWPCalculate";
            this.gbLWPCalculate.Size = new System.Drawing.Size(241, 35);
            this.gbLWPCalculate.TabIndex = 9;
            this.gbLWPCalculate.TabStop = false;
            this.gbLWPCalculate.Visible = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.ForeColor = System.Drawing.Color.Blue;
            this.lblNote.Location = new System.Drawing.Point(347, 70);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(109, 13);
            this.lblNote.TabIndex = 14;
            this.lblNote.Text = "Note: 8 hours = 1 day";
            this.lblNote.Visible = false;
            // 
            // rdoNightShift
            // 
            this.rdoNightShift.AutoSize = true;
            this.rdoNightShift.Location = new System.Drawing.Point(5, 10);
            this.rdoNightShift.Name = "rdoNightShift";
            this.rdoNightShift.Size = new System.Drawing.Size(126, 17);
            this.rdoNightShift.TabIndex = 15;
            this.rdoNightShift.TabStop = true;
            this.rdoNightShift.Text = "Night Shift Allowance";
            this.rdoNightShift.UseVisualStyleBackColor = true;
            // 
            // rdoOthers
            // 
            this.rdoOthers.AutoSize = true;
            this.rdoOthers.Location = new System.Drawing.Point(179, 9);
            this.rdoOthers.Name = "rdoOthers";
            this.rdoOthers.Size = new System.Drawing.Size(56, 17);
            this.rdoOthers.TabIndex = 16;
            this.rdoOthers.TabStop = true;
            this.rdoOthers.Text = "Others";
            this.rdoOthers.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoOthers);
            this.groupBox1.Controls.Add(this.rdoNightShift);
            this.groupBox1.Location = new System.Drawing.Point(66, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 33);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(69, 43);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(395, 25);
            this.ctlEmployee1.TabIndex = 3;
            // 
            // frmHRPayrollAddDeduct
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 212);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.gbLWPCalculate);
            this.Controls.Add(this.chkLWPCalculator);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtMonth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdoDeduction);
            this.Controls.Add(this.rdoAddition);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlEmployee1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHRPayrollAddDeduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHRPayrollAddDeduct";
            this.Load += new System.EventHandler(this.frmHRPayrollAddDeduct_Load);
            this.gbLWPCalculate.ResumeLayout(false);
            this.gbLWPCalculate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoAddition;
        private System.Windows.Forms.RadioButton rdoDeduction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkLWPCalculator;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMinute;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox gbLWPCalculate;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.RadioButton rdoNightShift;
        private System.Windows.Forms.RadioButton rdoOthers;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}