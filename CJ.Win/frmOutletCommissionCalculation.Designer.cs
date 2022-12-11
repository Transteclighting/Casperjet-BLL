namespace CJ.Win
{
    partial class frmOutletCommissionCalculation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutletCommissionCalculation));
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnAdjustment = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwOutletCommission = new System.Windows.Forms.ListView();
            this.colMonthNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colYearNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmployeeType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colApprovedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotalAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtGetCommitionDate = new System.Windows.Forms.DateTimePicker();
            this.lblYearMonth = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.cmbEmpType = new System.Windows.Forms.ComboBox();
            this.lblEmployeeType = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblApproved = new System.Windows.Forms.Label();
            this.lblCreate = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProcess.Location = new System.Drawing.Point(727, 45);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(94, 28);
            this.btnProcess.TabIndex = 8;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApproved.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnApproved.Location = new System.Drawing.Point(727, 117);
            this.btnApproved.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(94, 28);
            this.btnApproved.TabIndex = 10;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = true;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnAdjustment
            // 
            this.btnAdjustment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdjustment.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjustment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdjustment.Location = new System.Drawing.Point(727, 153);
            this.btnAdjustment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdjustment.Name = "btnAdjustment";
            this.btnAdjustment.Size = new System.Drawing.Size(94, 28);
            this.btnAdjustment.TabIndex = 11;
            this.btnAdjustment.Text = "Adjustment";
            this.btnAdjustment.UseVisualStyleBackColor = true;
            this.btnAdjustment.Click += new System.EventHandler(this.btnAdjustment_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Location = new System.Drawing.Point(727, 189);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 28);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrint.Location = new System.Drawing.Point(727, 225);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 28);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(727, 464);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 28);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwOutletCommission
            // 
            this.lvwOutletCommission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOutletCommission.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMonthNo,
            this.colYearNo,
            this.colEmployeeType,
            this.colApprovedDate,
            this.colTotalAmount,
            this.colRemarks,
            this.colStatus});
            this.lvwOutletCommission.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOutletCommission.FullRowSelect = true;
            this.lvwOutletCommission.GridLines = true;
            this.lvwOutletCommission.Location = new System.Drawing.Point(15, 45);
            this.lvwOutletCommission.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwOutletCommission.Name = "lvwOutletCommission";
            this.lvwOutletCommission.Size = new System.Drawing.Size(702, 447);
            this.lvwOutletCommission.TabIndex = 7;
            this.lvwOutletCommission.UseCompatibleStateImageBehavior = false;
            this.lvwOutletCommission.View = System.Windows.Forms.View.Details;
            // 
            // colMonthNo
            // 
            this.colMonthNo.Text = "MonthNo";
            this.colMonthNo.Width = 68;
            // 
            // colYearNo
            // 
            this.colYearNo.Text = "YearNo";
            this.colYearNo.Width = 71;
            // 
            // colEmployeeType
            // 
            this.colEmployeeType.Text = "Outlet Employee Type";
            this.colEmployeeType.Width = 142;
            // 
            // colApprovedDate
            // 
            this.colApprovedDate.Text = "Approved Date";
            this.colApprovedDate.Width = 97;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.Text = "Total Amount";
            this.colTotalAmount.Width = 88;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 186;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 78;
            // 
            // dtGetCommitionDate
            // 
            this.dtGetCommitionDate.CustomFormat = "MMM-yyyy";
            this.dtGetCommitionDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtGetCommitionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtGetCommitionDate.Location = new System.Drawing.Point(473, 10);
            this.dtGetCommitionDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtGetCommitionDate.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtGetCommitionDate.Name = "dtGetCommitionDate";
            this.dtGetCommitionDate.ShowUpDown = true;
            this.dtGetCommitionDate.Size = new System.Drawing.Size(110, 23);
            this.dtGetCommitionDate.TabIndex = 5;
            this.dtGetCommitionDate.Value = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            // 
            // lblYearMonth
            // 
            this.lblYearMonth.AutoSize = true;
            this.lblYearMonth.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearMonth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblYearMonth.Location = new System.Drawing.Point(391, 15);
            this.lblYearMonth.Name = "lblYearMonth";
            this.lblYearMonth.Size = new System.Drawing.Size(76, 16);
            this.lblYearMonth.TabIndex = 4;
            this.lblYearMonth.Text = "Month/Year";
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGetData.Location = new System.Drawing.Point(589, 8);
            this.btnGetData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(82, 28);
            this.btnGetData.TabIndex = 6;
            this.btnGetData.Text = "GetData";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // cmbEmpType
            // 
            this.cmbEmpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpType.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpType.FormattingEnabled = true;
            this.cmbEmpType.Location = new System.Drawing.Point(83, 12);
            this.cmbEmpType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbEmpType.Name = "cmbEmpType";
            this.cmbEmpType.Size = new System.Drawing.Size(124, 24);
            this.cmbEmpType.TabIndex = 1;
            // 
            // lblEmployeeType
            // 
            this.lblEmployeeType.AutoSize = true;
            this.lblEmployeeType.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEmployeeType.Location = new System.Drawing.Point(12, 15);
            this.lblEmployeeType.Name = "lblEmployeeType";
            this.lblEmployeeType.Size = new System.Drawing.Size(65, 16);
            this.lblEmployeeType.TabIndex = 0;
            this.lblEmployeeType.Text = "Emp Type";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStatus.Location = new System.Drawing.Point(213, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 16);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(261, 12);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(124, 24);
            this.cmbStatus.TabIndex = 3;
            // 
            // lblApproved
            // 
            this.lblApproved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblApproved.AutoSize = true;
            this.lblApproved.BackColor = System.Drawing.Color.LightGreen;
            this.lblApproved.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApproved.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblApproved.Location = new System.Drawing.Point(101, 505);
            this.lblApproved.Name = "lblApproved";
            this.lblApproved.Size = new System.Drawing.Size(65, 16);
            this.lblApproved.TabIndex = 16;
            this.lblApproved.Text = "Approved";
            // 
            // lblCreate
            // 
            this.lblCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCreate.AutoSize = true;
            this.lblCreate.BackColor = System.Drawing.SystemColors.HighlightText;
            this.lblCreate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreate.Location = new System.Drawing.Point(24, 505);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(45, 16);
            this.lblCreate.TabIndex = 15;
            this.lblCreate.Text = "Create";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(727, 81);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Process New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmOutletCommissionCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 542);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.lblApproved);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblEmployeeType);
            this.Controls.Add(this.cmbEmpType);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.dtGetCommitionDate);
            this.Controls.Add(this.lblYearMonth);
            this.Controls.Add(this.lvwOutletCommission);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdjustment);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.btnProcess);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmOutletCommissionCalculation";
            this.Text = "Outlet Commission Calculation";
            this.Load += new System.EventHandler(this.frmOutletCommissionCalculation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Button btnAdjustment;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwOutletCommission;
        private System.Windows.Forms.ColumnHeader colMonthNo;
        private System.Windows.Forms.ColumnHeader colYearNo;
        private System.Windows.Forms.ColumnHeader colApprovedDate;
        private System.Windows.Forms.ColumnHeader colTotalAmount;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.DateTimePicker dtGetCommitionDate;
        private System.Windows.Forms.Label lblYearMonth;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ComboBox cmbEmpType;
        private System.Windows.Forms.Label lblEmployeeType;
        private System.Windows.Forms.ColumnHeader colEmployeeType;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label lblApproved;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Button button1;
    }
}