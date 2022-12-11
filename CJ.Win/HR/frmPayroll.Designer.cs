namespace CJ.Win.HR
{
    partial class frmPayroll
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.txtEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGetEmployee = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.chkLFA = new System.Windows.Forms.CheckBox();
            this.chkFestivalBonus = new System.Windows.Forms.CheckBox();
            this.chkArear = new System.Windows.Forms.CheckBox();
            this.chkFullSalary = new System.Windows.Forms.CheckBox();
            this.nudNoOfBonus = new System.Windows.Forms.NumericUpDown();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.lblMonths = new System.Windows.Forms.Label();
            this.lblLast = new System.Windows.Forms.Label();
            this.nudNoOfMonth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.dtSalaryMonth = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGrossSalary = new System.Windows.Forms.Label();
            this.lblDeduction = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblNetSalary = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblExpense = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSubsidy = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalSalary = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAbsentList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfBonus)).BeginInit();
            this.gbSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfMonth)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtEmployeeCode,
            this.txtEmployeeName,
            this.txtEmployeeID});
            this.dgvItem.Location = new System.Drawing.Point(12, 145);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.Size = new System.Drawing.Size(847, 276);
            this.dgvItem.TabIndex = 20;
            this.dgvItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellValueChanged);
            this.dgvItem.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvItem_RowsRemoved);
            // 
            // txtEmployeeCode
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEmployeeCode.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtEmployeeCode.Frozen = true;
            this.txtEmployeeCode.HeaderText = "Code";
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.ReadOnly = true;
            this.txtEmployeeCode.Width = 60;
            // 
            // txtEmployeeName
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEmployeeName.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtEmployeeName.Frozen = true;
            this.txtEmployeeName.HeaderText = "Employee Name";
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Width = 180;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.HeaderText = "Employee ID";
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Visible = false;
            this.txtEmployeeID.Width = 60;
            // 
            // btnGetEmployee
            // 
            this.btnGetEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetEmployee.Location = new System.Drawing.Point(317, 12);
            this.btnGetEmployee.Name = "btnGetEmployee";
            this.btnGetEmployee.Size = new System.Drawing.Size(101, 44);
            this.btnGetEmployee.TabIndex = 21;
            this.btnGetEmployee.Text = "Get Employee";
            this.btnGetEmployee.UseVisualStyleBackColor = true;
            this.btnGetEmployee.Click += new System.EventHandler(this.btnGetEmployee_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(168, 35);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(69, 24);
            this.btnProcess.TabIndex = 23;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // chkLFA
            // 
            this.chkLFA.AutoSize = true;
            this.chkLFA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLFA.Location = new System.Drawing.Point(9, 51);
            this.chkLFA.Name = "chkLFA";
            this.chkLFA.Size = new System.Drawing.Size(47, 19);
            this.chkLFA.TabIndex = 24;
            this.chkLFA.Text = "LFA";
            this.chkLFA.UseVisualStyleBackColor = true;
            this.chkLFA.CheckedChanged += new System.EventHandler(this.chkLFA_CheckedChanged);
            // 
            // chkFestivalBonus
            // 
            this.chkFestivalBonus.AutoSize = true;
            this.chkFestivalBonus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFestivalBonus.Location = new System.Drawing.Point(9, 33);
            this.chkFestivalBonus.Name = "chkFestivalBonus";
            this.chkFestivalBonus.Size = new System.Drawing.Size(61, 19);
            this.chkFestivalBonus.TabIndex = 25;
            this.chkFestivalBonus.Text = "Bonus";
            this.chkFestivalBonus.UseVisualStyleBackColor = true;
            this.chkFestivalBonus.CheckedChanged += new System.EventHandler(this.chkFestivalBonus_CheckedChanged);
            // 
            // chkArear
            // 
            this.chkArear.AutoSize = true;
            this.chkArear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkArear.Location = new System.Drawing.Point(9, 70);
            this.chkArear.Name = "chkArear";
            this.chkArear.Size = new System.Drawing.Size(55, 19);
            this.chkArear.TabIndex = 26;
            this.chkArear.Text = "Arear";
            this.chkArear.UseVisualStyleBackColor = true;
            this.chkArear.CheckedChanged += new System.EventHandler(this.chkArear_CheckedChanged);
            // 
            // chkFullSalary
            // 
            this.chkFullSalary.AutoSize = true;
            this.chkFullSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFullSalary.Location = new System.Drawing.Point(9, 15);
            this.chkFullSalary.Name = "chkFullSalary";
            this.chkFullSalary.Size = new System.Drawing.Size(83, 19);
            this.chkFullSalary.TabIndex = 27;
            this.chkFullSalary.Text = "Full Salary";
            this.chkFullSalary.UseVisualStyleBackColor = true;
            this.chkFullSalary.CheckedChanged += new System.EventHandler(this.chkFullSalary_CheckedChanged);
            // 
            // nudNoOfBonus
            // 
            this.nudNoOfBonus.Location = new System.Drawing.Point(94, 31);
            this.nudNoOfBonus.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNoOfBonus.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoOfBonus.Name = "nudNoOfBonus";
            this.nudNoOfBonus.ReadOnly = true;
            this.nudNoOfBonus.Size = new System.Drawing.Size(41, 21);
            this.nudNoOfBonus.TabIndex = 28;
            this.nudNoOfBonus.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.lblMonths);
            this.gbSettings.Controls.Add(this.lblLast);
            this.gbSettings.Controls.Add(this.nudNoOfMonth);
            this.gbSettings.Controls.Add(this.nudNoOfBonus);
            this.gbSettings.Controls.Add(this.chkFullSalary);
            this.gbSettings.Controls.Add(this.chkArear);
            this.gbSettings.Controls.Add(this.chkFestivalBonus);
            this.gbSettings.Controls.Add(this.chkLFA);
            this.gbSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbSettings.Location = new System.Drawing.Point(445, 6);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(196, 92);
            this.gbSettings.TabIndex = 29;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // lblMonths
            // 
            this.lblMonths.AutoSize = true;
            this.lblMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonths.Location = new System.Drawing.Point(137, 72);
            this.lblMonths.Name = "lblMonths";
            this.lblMonths.Size = new System.Drawing.Size(56, 15);
            this.lblMonths.TabIndex = 42;
            this.lblMonths.Text = "Month(s)";
            // 
            // lblLast
            // 
            this.lblLast.AutoSize = true;
            this.lblLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLast.Location = new System.Drawing.Point(64, 72);
            this.lblLast.Name = "lblLast";
            this.lblLast.Size = new System.Drawing.Size(30, 15);
            this.lblLast.TabIndex = 41;
            this.lblLast.Text = "Last";
            // 
            // nudNoOfMonth
            // 
            this.nudNoOfMonth.Location = new System.Drawing.Point(94, 68);
            this.nudNoOfMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.nudNoOfMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNoOfMonth.Name = "nudNoOfMonth";
            this.nudNoOfMonth.ReadOnly = true;
            this.nudNoOfMonth.Size = new System.Drawing.Size(41, 21);
            this.nudNoOfMonth.TabIndex = 29;
            this.nudNoOfMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(78, 14);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(231, 21);
            this.cmbCompany.TabIndex = 30;
            // 
            // dtSalaryMonth
            // 
            this.dtSalaryMonth.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalaryMonth.CustomFormat = "MMM-yyyy";
            this.dtSalaryMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalaryMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSalaryMonth.Location = new System.Drawing.Point(77, 36);
            this.dtSalaryMonth.Name = "dtSalaryMonth";
            this.dtSalaryMonth.ShowUpDown = true;
            this.dtSalaryMonth.Size = new System.Drawing.Size(83, 23);
            this.dtSalaryMonth.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "Month";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(244, 35);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(69, 24);
            this.btnClear.TabIndex = 36;
            this.btnClear.Text = "Reset";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(785, 426);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 26);
            this.btnClose.TabIndex = 38;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(705, 426);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 26);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbProgress.Location = new System.Drawing.Point(12, 427);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(566, 23);
            this.pbProgress.TabIndex = 39;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(582, 434);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(27, 13);
            this.lblProgress.TabIndex = 40;
            this.lblProgress.Text = "0/0";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(77, 11);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(336, 20);
            this.txtDescription.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 42;
            this.label5.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 52;
            this.label6.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(78, 39);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(125, 21);
            this.cmbType.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 53;
            this.label7.Text = "Gross Amount:";
            // 
            // lblGrossSalary
            // 
            this.lblGrossSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrossSalary.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblGrossSalary.Location = new System.Drawing.Point(93, 16);
            this.lblGrossSalary.Name = "lblGrossSalary";
            this.lblGrossSalary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblGrossSalary.Size = new System.Drawing.Size(107, 13);
            this.lblGrossSalary.TabIndex = 54;
            this.lblGrossSalary.Text = "0.00";
            // 
            // lblDeduction
            // 
            this.lblDeduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeduction.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblDeduction.Location = new System.Drawing.Point(93, 33);
            this.lblDeduction.Name = "lblDeduction";
            this.lblDeduction.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDeduction.Size = new System.Drawing.Size(107, 13);
            this.lblDeduction.TabIndex = 56;
            this.lblDeduction.Text = "0.00";
            this.lblDeduction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 15);
            this.label9.TabIndex = 55;
            this.label9.Text = "Duduction:";
            // 
            // lblNetSalary
            // 
            this.lblNetSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetSalary.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblNetSalary.Location = new System.Drawing.Point(93, 54);
            this.lblNetSalary.Name = "lblNetSalary";
            this.lblNetSalary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNetSalary.Size = new System.Drawing.Size(107, 13);
            this.lblNetSalary.TabIndex = 58;
            this.lblNetSalary.Text = "0.00";
            this.lblNetSalary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 15);
            this.label10.TabIndex = 57;
            this.label10.Text = "Net Salary:";
            // 
            // lblExpense
            // 
            this.lblExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpense.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblExpense.Location = new System.Drawing.Point(93, 73);
            this.lblExpense.Name = "lblExpense";
            this.lblExpense.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblExpense.Size = new System.Drawing.Size(107, 13);
            this.lblExpense.TabIndex = 60;
            this.lblExpense.Text = "0.00";
            this.lblExpense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(11, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 15);
            this.label11.TabIndex = 59;
            this.label11.Text = "Expense:";
            // 
            // lblSubsidy
            // 
            this.lblSubsidy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubsidy.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblSubsidy.Location = new System.Drawing.Point(93, 87);
            this.lblSubsidy.Name = "lblSubsidy";
            this.lblSubsidy.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSubsidy.Size = new System.Drawing.Size(107, 13);
            this.lblSubsidy.TabIndex = 62;
            this.lblSubsidy.Text = "0.00";
            this.lblSubsidy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 15);
            this.label12.TabIndex = 61;
            this.label12.Text = "Subsidy:";
            // 
            // lblTotalSalary
            // 
            this.lblTotalSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalary.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotalSalary.Location = new System.Drawing.Point(93, 105);
            this.lblTotalSalary.Name = "lblTotalSalary";
            this.lblTotalSalary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalSalary.Size = new System.Drawing.Size(107, 13);
            this.lblTotalSalary.TabIndex = 64;
            this.lblTotalSalary.Text = "0.00";
            this.lblTotalSalary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(11, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 15);
            this.label13.TabIndex = 63;
            this.label13.Text = "Total Salary:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTotalSalary);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblSubsidy);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblExpense);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblNetSalary);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblDeduction);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblGrossSalary);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(648, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 132);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 15);
            this.label2.TabIndex = 67;
            this.label2.Text = "Employee Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(104, 13);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(83, 21);
            this.txtCode.TabIndex = 66;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbCompany);
            this.groupBox1.Controls.Add(this.btnGetEmployee);
            this.groupBox1.Location = new System.Drawing.Point(14, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 67);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get Employee";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnProcess);
            this.groupBox3.Controls.Add(this.dtSalaryMonth);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Location = new System.Drawing.Point(13, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 66);
            this.groupBox3.TabIndex = 69;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Action";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCode);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(446, 98);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 40);
            this.groupBox4.TabIndex = 70;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Code";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Employee Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Employee ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // btnAbsentList
            // 
            this.btnAbsentList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbsentList.Location = new System.Drawing.Point(625, 426);
            this.btnAbsentList.Name = "btnAbsentList";
            this.btnAbsentList.Size = new System.Drawing.Size(74, 26);
            this.btnAbsentList.TabIndex = 71;
            this.btnAbsentList.Text = "Absent List";
            this.btnAbsentList.UseVisualStyleBackColor = true;
            this.btnAbsentList.Click += new System.EventHandler(this.btnAbsentList_Click);
            // 
            // frmPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 456);
            this.Controls.Add(this.btnAbsentList);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.dgvItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayroll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPayroll";
            this.Load += new System.EventHandler(this.frmPayroll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfBonus)).EndInit();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNoOfMonth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button btnGetEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.CheckBox chkLFA;
        private System.Windows.Forms.CheckBox chkFestivalBonus;
        private System.Windows.Forms.CheckBox chkArear;
        private System.Windows.Forms.CheckBox chkFullSalary;
        private System.Windows.Forms.NumericUpDown nudNoOfBonus;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.DateTimePicker dtSalaryMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmployeeID;
        private System.Windows.Forms.Label lblMonths;
        private System.Windows.Forms.Label lblLast;
        private System.Windows.Forms.NumericUpDown nudNoOfMonth;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblGrossSalary;
        private System.Windows.Forms.Label lblDeduction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNetSalary;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblExpense;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblSubsidy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalSalary;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAbsentList;
    }
}