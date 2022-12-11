namespace CJ.Win.HR
{
    partial class frmPayrollPrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayrollPrint));
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblPayrollNo = new System.Windows.Forms.Label();
            this.lblPayrollMonth = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoEmployeeWise = new System.Windows.Forms.RadioButton();
            this.rdoDepartmentWise = new System.Windows.Forms.RadioButton();
            this.rdoAtaGlance = new System.Windows.Forms.RadioButton();
            this.chkTDStaff = new System.Windows.Forms.CheckBox();
            this.rdoPaySlip = new System.Windows.Forms.RadioButton();
            this.rdoCashPart = new System.Windows.Forms.RadioButton();
            this.rdoPayroll = new System.Windows.Forms.RadioButton();
            this.rbDriver = new System.Windows.Forms.RadioButton();
            this.rbServant = new System.Windows.Forms.RadioButton();
            this.rbCar = new System.Windows.Forms.RadioButton();
            this.rbLunch = new System.Windows.Forms.RadioButton();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.rdoPaySlipFactory = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Employee";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(399, 210);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 28);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblPayrollNo
            // 
            this.lblPayrollNo.AutoSize = true;
            this.lblPayrollNo.Location = new System.Drawing.Point(50, 22);
            this.lblPayrollNo.Name = "lblPayrollNo";
            this.lblPayrollNo.Size = new System.Drawing.Size(55, 13);
            this.lblPayrollNo.TabIndex = 6;
            this.lblPayrollNo.Text = "Payroll No";
            // 
            // lblPayrollMonth
            // 
            this.lblPayrollMonth.AutoSize = true;
            this.lblPayrollMonth.Location = new System.Drawing.Point(319, 22);
            this.lblPayrollMonth.Name = "lblPayrollMonth";
            this.lblPayrollMonth.Size = new System.Drawing.Size(68, 13);
            this.lblPayrollMonth.TabIndex = 7;
            this.lblPayrollMonth.Text = "PayrollMonth";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(202, 22);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(50, 49);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Description";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.lblPayrollMonth);
            this.groupBox1.Controls.Add(this.lblPayrollNo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 70);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdoEmployeeWise);
            this.groupBox3.Controls.Add(this.rdoDepartmentWise);
            this.groupBox3.Location = new System.Drawing.Point(13, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 36);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            // 
            // rdoEmployeeWise
            // 
            this.rdoEmployeeWise.AutoSize = true;
            this.rdoEmployeeWise.Location = new System.Drawing.Point(130, 12);
            this.rdoEmployeeWise.Name = "rdoEmployeeWise";
            this.rdoEmployeeWise.Size = new System.Drawing.Size(98, 17);
            this.rdoEmployeeWise.TabIndex = 15;
            this.rdoEmployeeWise.TabStop = true;
            this.rdoEmployeeWise.Text = "Employee Wise";
            this.rdoEmployeeWise.UseVisualStyleBackColor = true;
            // 
            // rdoDepartmentWise
            // 
            this.rdoDepartmentWise.AutoSize = true;
            this.rdoDepartmentWise.Location = new System.Drawing.Point(6, 12);
            this.rdoDepartmentWise.Name = "rdoDepartmentWise";
            this.rdoDepartmentWise.Size = new System.Drawing.Size(107, 17);
            this.rdoDepartmentWise.TabIndex = 14;
            this.rdoDepartmentWise.TabStop = true;
            this.rdoDepartmentWise.Text = "Department Wise";
            this.rdoDepartmentWise.UseVisualStyleBackColor = true;
            // 
            // rdoAtaGlance
            // 
            this.rdoAtaGlance.AutoSize = true;
            this.rdoAtaGlance.Location = new System.Drawing.Point(264, 91);
            this.rdoAtaGlance.Name = "rdoAtaGlance";
            this.rdoAtaGlance.Size = new System.Drawing.Size(127, 17);
            this.rdoAtaGlance.TabIndex = 11;
            this.rdoAtaGlance.TabStop = true;
            this.rdoAtaGlance.Text = "At a Glance of Officer";
            this.rdoAtaGlance.UseVisualStyleBackColor = true;
            // 
            // chkTDStaff
            // 
            this.chkTDStaff.AutoSize = true;
            this.chkTDStaff.Location = new System.Drawing.Point(408, 91);
            this.chkTDStaff.Name = "chkTDStaff";
            this.chkTDStaff.Size = new System.Drawing.Size(66, 17);
            this.chkTDStaff.TabIndex = 12;
            this.chkTDStaff.Text = "TD Staff";
            this.chkTDStaff.UseVisualStyleBackColor = true;
            // 
            // rdoPaySlip
            // 
            this.rdoPaySlip.AutoSize = true;
            this.rdoPaySlip.Location = new System.Drawing.Point(187, 91);
            this.rdoPaySlip.Name = "rdoPaySlip";
            this.rdoPaySlip.Size = new System.Drawing.Size(63, 17);
            this.rdoPaySlip.TabIndex = 2;
            this.rdoPaySlip.TabStop = true;
            this.rdoPaySlip.Text = "Pay Slip";
            this.rdoPaySlip.UseVisualStyleBackColor = true;
            // 
            // rdoCashPart
            // 
            this.rdoCashPart.AutoSize = true;
            this.rdoCashPart.Location = new System.Drawing.Point(102, 91);
            this.rdoCashPart.Name = "rdoCashPart";
            this.rdoCashPart.Size = new System.Drawing.Size(71, 17);
            this.rdoCashPart.TabIndex = 1;
            this.rdoCashPart.TabStop = true;
            this.rdoCashPart.Text = "Cash Part";
            this.rdoCashPart.UseVisualStyleBackColor = true;
            // 
            // rdoPayroll
            // 
            this.rdoPayroll.AutoSize = true;
            this.rdoPayroll.Location = new System.Drawing.Point(18, 91);
            this.rdoPayroll.Name = "rdoPayroll";
            this.rdoPayroll.Size = new System.Drawing.Size(72, 17);
            this.rdoPayroll.TabIndex = 0;
            this.rdoPayroll.TabStop = true;
            this.rdoPayroll.Text = "Bank Part";
            this.rdoPayroll.UseVisualStyleBackColor = true;
            // 
            // rbDriver
            // 
            this.rbDriver.AutoSize = true;
            this.rbDriver.Location = new System.Drawing.Point(194, 114);
            this.rbDriver.Name = "rbDriver";
            this.rbDriver.Size = new System.Drawing.Size(53, 17);
            this.rbDriver.TabIndex = 22;
            this.rbDriver.TabStop = true;
            this.rbDriver.Text = "Driver";
            this.rbDriver.UseVisualStyleBackColor = true;
            this.rbDriver.Visible = false;
            // 
            // rbServant
            // 
            this.rbServant.AutoSize = true;
            this.rbServant.Location = new System.Drawing.Point(126, 114);
            this.rbServant.Name = "rbServant";
            this.rbServant.Size = new System.Drawing.Size(62, 17);
            this.rbServant.TabIndex = 21;
            this.rbServant.TabStop = true;
            this.rbServant.Text = "Servant";
            this.rbServant.UseVisualStyleBackColor = true;
            this.rbServant.Visible = false;
            // 
            // rbCar
            // 
            this.rbCar.AutoSize = true;
            this.rbCar.Location = new System.Drawing.Point(79, 114);
            this.rbCar.Name = "rbCar";
            this.rbCar.Size = new System.Drawing.Size(41, 17);
            this.rbCar.TabIndex = 20;
            this.rbCar.TabStop = true;
            this.rbCar.Text = "Car";
            this.rbCar.UseVisualStyleBackColor = true;
            this.rbCar.Visible = false;
            // 
            // rbLunch
            // 
            this.rbLunch.AutoSize = true;
            this.rbLunch.Location = new System.Drawing.Point(18, 114);
            this.rbLunch.Name = "rbLunch";
            this.rbLunch.Size = new System.Drawing.Size(55, 17);
            this.rbLunch.TabIndex = 19;
            this.rbLunch.TabStop = true;
            this.rbLunch.Text = "Lunch";
            this.rbLunch.UseVisualStyleBackColor = true;
            this.rbLunch.Visible = false;
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(65, 179);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(415, 25);
            this.ctlEmployee1.TabIndex = 3;
            // 
            // rdoPaySlipFactory
            // 
            this.rdoPaySlipFactory.AutoSize = true;
            this.rdoPaySlipFactory.Location = new System.Drawing.Point(264, 114);
            this.rdoPaySlipFactory.Name = "rdoPaySlipFactory";
            this.rdoPaySlipFactory.Size = new System.Drawing.Size(101, 17);
            this.rdoPaySlipFactory.TabIndex = 23;
            this.rdoPaySlipFactory.TabStop = true;
            this.rdoPaySlipFactory.Text = "Pay Slip Factory";
            this.rdoPaySlipFactory.UseVisualStyleBackColor = true;
            // 
            // frmPayrollPrint
            // 
            this.AcceptButton = this.btnPreview;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 249);
            this.Controls.Add(this.rdoPaySlipFactory);
            this.Controls.Add(this.rbDriver);
            this.Controls.Add(this.rbServant);
            this.Controls.Add(this.rbCar);
            this.Controls.Add(this.rbLunch);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chkTDStaff);
            this.Controls.Add(this.rdoAtaGlance);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.rdoPaySlip);
            this.Controls.Add(this.rdoCashPart);
            this.Controls.Add(this.rdoPayroll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayrollPrint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payroll Print";
            this.Load += new System.EventHandler(this.frmPayrollPrint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblPayrollNo;
        private System.Windows.Forms.Label lblPayrollMonth;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoEmployeeWise;
        private System.Windows.Forms.RadioButton rdoDepartmentWise;
        private System.Windows.Forms.RadioButton rdoAtaGlance;
        private System.Windows.Forms.CheckBox chkTDStaff;
        private System.Windows.Forms.RadioButton rdoPaySlip;
        private System.Windows.Forms.RadioButton rdoCashPart;
        private System.Windows.Forms.RadioButton rdoPayroll;
        private System.Windows.Forms.RadioButton rbDriver;
        private System.Windows.Forms.RadioButton rbServant;
        private System.Windows.Forms.RadioButton rbCar;
        private System.Windows.Forms.RadioButton rbLunch;
        private System.Windows.Forms.RadioButton rdoPaySlipFactory;
    }
}