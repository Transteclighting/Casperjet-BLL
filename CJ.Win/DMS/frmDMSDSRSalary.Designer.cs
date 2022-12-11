namespace CJ.Win.DMS
{
    partial class frmDMSDSRSalary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDSRSalary = new System.Windows.Forms.DataGridView();
            this.TranID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSRID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AreaName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSRCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSRName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkingDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FixedSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VariableSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Others = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileBill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deduction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalculatedSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetPayable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayTADA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayAllowance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayOthers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProcess = new System.Windows.Forms.Button();
            this.dtSalaryDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.pbProcess = new System.Windows.Forms.ProgressBar();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoPayable = new System.Windows.Forms.RadioButton();
            this.rdoHeldup = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBasicSalary = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSRSalary)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSRSalary
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgvDSRSalary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSRSalary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSRSalary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSRSalary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSRSalary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TranID,
            this.DSRID,
            this.AreaName,
            this.CustomerName,
            this.DSRCode,
            this.DSRName,
            this.Month,
            this.Year,
            this.PaymentMode,
            this.PaymentType,
            this.WorkingDay,
            this.Ach,
            this.FixedSalary,
            this.VariableSalary,
            this.TADA,
            this.Others,
            this.MobileBill,
            this.Deduction,
            this.CalculatedSalary,
            this.NetPayable,
            this.Status,
            this.Remarks,
            this.DayTADA,
            this.DayAllowance,
            this.DayOthers});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSRSalary.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSRSalary.Location = new System.Drawing.Point(3, 77);
            this.dgvDSRSalary.Name = "dgvDSRSalary";
            this.dgvDSRSalary.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dgvDSRSalary.Size = new System.Drawing.Size(1152, 427);
            this.dgvDSRSalary.TabIndex = 51;
            // 
            // TranID
            // 
            this.TranID.HeaderText = "TranID";
            this.TranID.Name = "TranID";
            this.TranID.Visible = false;
            this.TranID.Width = 40;
            // 
            // DSRID
            // 
            this.DSRID.HeaderText = "DSRID";
            this.DSRID.Name = "DSRID";
            this.DSRID.Visible = false;
            this.DSRID.Width = 40;
            // 
            // AreaName
            // 
            this.AreaName.HeaderText = "Area Name";
            this.AreaName.Name = "AreaName";
            this.AreaName.ReadOnly = true;
            this.AreaName.Width = 59;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CustomerName.Width = 58;
            // 
            // DSRCode
            // 
            this.DSRCode.HeaderText = "DSR Code";
            this.DSRCode.Name = "DSRCode";
            this.DSRCode.ReadOnly = true;
            this.DSRCode.Width = 59;
            // 
            // DSRName
            // 
            this.DSRName.HeaderText = "DSR Name";
            this.DSRName.Name = "DSRName";
            this.DSRName.ReadOnly = true;
            this.DSRName.Width = 59;
            // 
            // Month
            // 
            this.Month.HeaderText = "Month";
            this.Month.Name = "Month";
            this.Month.Visible = false;
            this.Month.Width = 40;
            // 
            // Year
            // 
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            this.Year.Visible = false;
            this.Year.Width = 40;
            // 
            // PaymentMode
            // 
            this.PaymentMode.HeaderText = "Payment Mode";
            this.PaymentMode.Name = "PaymentMode";
            this.PaymentMode.Visible = false;
            this.PaymentMode.Width = 60;
            // 
            // PaymentType
            // 
            this.PaymentType.HeaderText = "Payment Type";
            this.PaymentType.Name = "PaymentType";
            this.PaymentType.Visible = false;
            this.PaymentType.Width = 50;
            // 
            // WorkingDay
            // 
            this.WorkingDay.HeaderText = "Day";
            this.WorkingDay.Name = "WorkingDay";
            this.WorkingDay.Width = 58;
            // 
            // Ach
            // 
            this.Ach.HeaderText = "Ach";
            this.Ach.Name = "Ach";
            this.Ach.ReadOnly = true;
            this.Ach.Width = 59;
            // 
            // FixedSalary
            // 
            this.FixedSalary.HeaderText = "Fixed Salary";
            this.FixedSalary.Name = "FixedSalary";
            this.FixedSalary.ReadOnly = true;
            this.FixedSalary.Width = 59;
            // 
            // VariableSalary
            // 
            this.VariableSalary.HeaderText = "Variable Salary";
            this.VariableSalary.Name = "VariableSalary";
            // 
            // TADA
            // 
            this.TADA.HeaderText = "TA DA";
            this.TADA.Name = "TADA";
            this.TADA.ReadOnly = true;
            this.TADA.Width = 58;
            // 
            // Others
            // 
            this.Others.HeaderText = "Others";
            this.Others.Name = "Others";
            this.Others.Width = 59;
            // 
            // MobileBill
            // 
            this.MobileBill.HeaderText = "Mobile Bill";
            this.MobileBill.Name = "MobileBill";
            this.MobileBill.Width = 59;
            // 
            // Deduction
            // 
            this.Deduction.HeaderText = "Deduction";
            this.Deduction.Name = "Deduction";
            this.Deduction.Width = 58;
            // 
            // CalculatedSalary
            // 
            this.CalculatedSalary.HeaderText = "Calculated Salary";
            this.CalculatedSalary.Name = "CalculatedSalary";
            this.CalculatedSalary.ReadOnly = true;
            this.CalculatedSalary.Width = 59;
            // 
            // NetPayable
            // 
            this.NetPayable.HeaderText = "Net Payable";
            this.NetPayable.Name = "NetPayable";
            this.NetPayable.Width = 59;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 58;
            // 
            // Remarks
            // 
            this.Remarks.HeaderText = "Remarks";
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 59;
            // 
            // DayTADA
            // 
            this.DayTADA.HeaderText = "DayTADA";
            this.DayTADA.Name = "DayTADA";
            this.DayTADA.Width = 59;
            // 
            // DayAllowance
            // 
            this.DayAllowance.HeaderText = "DayAllowance";
            this.DayAllowance.Name = "DayAllowance";
            this.DayAllowance.Width = 58;
            // 
            // DayOthers
            // 
            this.DayOthers.HeaderText = "DayOthers";
            this.DayOthers.Name = "DayOthers";
            this.DayOthers.Width = 59;
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(624, 14);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(141, 35);
            this.btnProcess.TabIndex = 183;
            this.btnProcess.Text = "Process Salary";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click_1);
            // 
            // dtSalaryDate
            // 
            this.dtSalaryDate.CustomFormat = "MMM-yyyy";
            this.dtSalaryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalaryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSalaryDate.Location = new System.Drawing.Point(262, 18);
            this.dtSalaryDate.MinDate = new System.DateTime(2016, 2, 1, 0, 0, 0, 0);
            this.dtSalaryDate.Name = "dtSalaryDate";
            this.dtSalaryDate.ShowUpDown = true;
            this.dtSalaryDate.Size = new System.Drawing.Size(111, 29);
            this.dtSalaryDate.TabIndex = 187;
            this.dtSalaryDate.Value = new System.DateTime(2021, 5, 30, 16, 58, 12, 0);
            this.dtSalaryDate.ValueChanged += new System.EventHandler(this.dtSalaryDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 24);
            this.label1.TabIndex = 188;
            this.label1.Text = "Salary For The Month :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 189;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(256, 45);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(0, 13);
            this.lblYear.TabIndex = 190;
            // 
            // pbProcess
            // 
            this.pbProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProcess.Location = new System.Drawing.Point(12, 499);
            this.pbProcess.Name = "pbProcess";
            this.pbProcess.Size = new System.Drawing.Size(1513, 22);
            this.pbProcess.TabIndex = 191;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(801, 14);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(90, 34);
            this.btnConfirm.TabIndex = 192;
            this.btnConfirm.Text = "Confirm ";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click_1);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(6, 124);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 32);
            this.btnPrint.TabIndex = 193;
            this.btnPrint.Text = "Priview";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(6, 19);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 194;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoPayable
            // 
            this.rdoPayable.AutoSize = true;
            this.rdoPayable.Location = new System.Drawing.Point(6, 53);
            this.rdoPayable.Name = "rdoPayable";
            this.rdoPayable.Size = new System.Drawing.Size(63, 17);
            this.rdoPayable.TabIndex = 195;
            this.rdoPayable.TabStop = true;
            this.rdoPayable.Text = "Payable";
            this.rdoPayable.UseVisualStyleBackColor = true;
            // 
            // rdoHeldup
            // 
            this.rdoHeldup.AutoSize = true;
            this.rdoHeldup.Location = new System.Drawing.Point(7, 88);
            this.rdoHeldup.Name = "rdoHeldup";
            this.rdoHeldup.Size = new System.Drawing.Size(64, 17);
            this.rdoHeldup.TabIndex = 196;
            this.rdoHeldup.TabStop = true;
            this.rdoHeldup.Text = "Held Up";
            this.rdoHeldup.UseVisualStyleBackColor = true;
            this.rdoHeldup.CheckedChanged += new System.EventHandler(this.rdoHeldup_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rdoAll);
            this.groupBox1.Controls.Add(this.rdoHeldup);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.rdoPayable);
            this.groupBox1.Location = new System.Drawing.Point(3, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 261);
            this.groupBox1.TabIndex = 197;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(7, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 62);
            this.button1.TabIndex = 197;
            this.button1.Text = "Lock Salary";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBasicSalary
            // 
            this.btnBasicSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBasicSalary.Location = new System.Drawing.Point(404, 14);
            this.btnBasicSalary.Name = "btnBasicSalary";
            this.btnBasicSalary.Size = new System.Drawing.Size(200, 35);
            this.btnBasicSalary.TabIndex = 198;
            this.btnBasicSalary.Text = "Process Basic Salary";
            this.btnBasicSalary.UseVisualStyleBackColor = true;
            this.btnBasicSalary.Click += new System.EventHandler(this.btnBasicSalary_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1161, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(93, 509);
            this.panel1.TabIndex = 199;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "TranID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "DSRID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Area Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 59;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Customer Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 58;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "DSR Code";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "DSR Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Month";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 40;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Year";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 40;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Payment Mode";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Payment Type";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 50;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Day";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 50;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Ach";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 30;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Fixed Salary";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 45;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "TA DA";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 30;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.HeaderText = "Allowance";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 60;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.HeaderText = "Others";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 50;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.HeaderText = "Mobile Bill";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 40;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.HeaderText = "Deduction";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 60;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.HeaderText = "Calculated Salary";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 60;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.HeaderText = "Net Payable";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 60;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.HeaderText = "Status";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 60;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Width = 240;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.HeaderText = "DayTADA";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.Width = 59;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "DayAllowance";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.Width = 58;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.HeaderText = "DayOthers";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.Width = 59;
            // 
            // frmDMSDSRSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 509);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnBasicSalary);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.pbProcess);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtSalaryDate);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.dgvDSRSalary);
            this.Name = "frmDMSDSRSalary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDMSDSRSalary";
            this.Load += new System.EventHandler(this.frmDMSDSRSalary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSRSalary)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSRSalary;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.DateTimePicker dtSalaryDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ProgressBar pbProcess;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoPayable;
        private System.Windows.Forms.RadioButton rdoHeldup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.Button btnBasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn TranID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSRID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AreaName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSRCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DSRName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkingDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ach;
        private System.Windows.Forms.DataGridViewTextBoxColumn FixedSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn VariableSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn TADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Others;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deduction;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalculatedSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetPayable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayTADA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayAllowance;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayOthers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}