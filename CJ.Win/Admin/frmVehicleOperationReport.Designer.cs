namespace CJ.Win.Admin
{
    partial class frmVehicleOperationReport
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
            this.lbtodate = new System.Windows.Forms.Label();
            this.lbfromdate = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Department = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSummaryReport = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbtodate
            // 
            this.lbtodate.AutoSize = true;
            this.lbtodate.Location = new System.Drawing.Point(265, 42);
            this.lbtodate.Name = "lbtodate";
            this.lbtodate.Size = new System.Drawing.Size(53, 16);
            this.lbtodate.TabIndex = 13;
            this.lbtodate.Text = "To Date";
            // 
            // lbfromdate
            // 
            this.lbfromdate.AutoSize = true;
            this.lbfromdate.Location = new System.Drawing.Point(3, 42);
            this.lbfromdate.Name = "lbfromdate";
            this.lbfromdate.Size = new System.Drawing.Size(67, 16);
            this.lbfromdate.TabIndex = 12;
            this.lbfromdate.Text = "From Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(323, 38);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(154, 23);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(73, 37);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(169, 23);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // cmbCompany
            // 
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Items.AddRange(new object[] {
            "1",
            "0"});
            this.cmbCompany.Location = new System.Drawing.Point(73, 7);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(169, 24);
            this.cmbCompany.TabIndex = 18;
            this.cmbCompany.Text = "All";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Company";
            // 
            // Department
            // 
            this.Department.AutoSize = true;
            this.Department.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Department.Location = new System.Drawing.Point(246, 9);
            this.Department.Name = "Department";
            this.Department.Size = new System.Drawing.Size(72, 15);
            this.Department.TabIndex = 21;
            this.Department.Text = "Department";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Items.AddRange(new object[] {
            "1",
            "0"});
            this.cmbDepartment.Location = new System.Drawing.Point(323, 8);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(154, 24);
            this.cmbDepartment.TabIndex = 20;
            this.cmbDepartment.Text = "All";
            // 
            // btnShowReport
            // 
            this.btnShowReport.Location = new System.Drawing.Point(576, 37);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(85, 25);
            this.btnShowReport.TabIndex = 23;
            this.btnShowReport.Text = "Details  Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSummaryReport);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.btnShowReport);
            this.panel1.Controls.Add(this.lbfromdate);
            this.panel1.Controls.Add(this.Department);
            this.panel1.Controls.Add(this.lbtodate);
            this.panel1.Controls.Add(this.cmbDepartment);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbCompany);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 68);
            this.panel1.TabIndex = 25;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSummaryReport
            // 
            this.btnSummaryReport.Location = new System.Drawing.Point(667, 39);
            this.btnSummaryReport.Name = "btnSummaryReport";
            this.btnSummaryReport.Size = new System.Drawing.Size(85, 25);
            this.btnSummaryReport.TabIndex = 26;
            this.btnSummaryReport.Text = "Sumary Report";
            this.btnSummaryReport.UseVisualStyleBackColor = true;
            this.btnSummaryReport.Click += new System.EventHandler(this.btnSummaryReport_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(576, 8);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(152, 23);
            this.txtCode.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Vehicle Code";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.crystalReportViewer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 482);
            this.panel2.TabIndex = 26;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1028, 482);
            this.crystalReportViewer1.TabIndex = 25;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // frmVehicleOperationReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmVehicleOperationReport";
            this.Text = "Vehicle Operation Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVehicleOperationReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbtodate;
        private System.Windows.Forms.Label lbfromdate;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Department;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSummaryReport;
    }
}