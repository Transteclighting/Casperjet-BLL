namespace CJ.Win.HR
{
    partial class frmOverTime
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOverTime));
            this.dgvOverTime = new System.Windows.Forms.DataGridView();
            this.txtDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDecription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFrom = new CJ.Win.Control.GridTimeControl();
            this.txtTo = new CJ.Win.Control.GridTimeControl();
            this.txtTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbSection = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTimeControl1 = new CJ.Win.Control.GridTimeControl();
            this.gridTimeControl2 = new CJ.Win.Control.GridTimeControl();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTimeControl3 = new CJ.Win.Control.GridTimeControl();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMonth = new System.Windows.Forms.Label();
            this.dtOverTimeMonth = new System.Windows.Forms.DateTimePicker();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.btnPicker = new System.Windows.Forms.Button();
            this.dtAddDay = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddDate = new System.Windows.Forms.Button();
            this.txtGtotalHour = new System.Windows.Forms.TextBox();
            this.txtLessMinutes = new System.Windows.Forms.TextBox();
            this.txtTotalHoure = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtGMin = new System.Windows.Forms.TextBox();
            this.lblAmountInWord = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverTime)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOverTime
            // 
            this.dgvOverTime.AllowUserToAddRows = false;
            this.dgvOverTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtDate,
            this.txtDay,
            this.txtDecription,
            this.txtFrom,
            this.txtTo,
            this.txtTotal,
            this.txtLess,
            this.txtGtotal,
            this.txtAmount,
            this.cmbSection});
            this.dgvOverTime.Location = new System.Drawing.Point(12, 83);
            this.dgvOverTime.Name = "dgvOverTime";
            this.dgvOverTime.Size = new System.Drawing.Size(879, 225);
            this.dgvOverTime.TabIndex = 9;
            this.dgvOverTime.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOverTime_CellContentClick);
            this.dgvOverTime.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOverTime_CellValueChanged);
            this.dgvOverTime.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvOverTime_RowsRemoved);
            // 
            // txtDate
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtDate.HeaderText = "Date";
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Width = 80;
            // 
            // txtDay
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtDay.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtDay.HeaderText = "Day";
            this.txtDay.Name = "txtDay";
            this.txtDay.ReadOnly = true;
            // 
            // txtDecription
            // 
            this.txtDecription.HeaderText = "Decription";
            this.txtDecription.Name = "txtDecription";
            this.txtDecription.Width = 200;
            // 
            // txtFrom
            // 
            dataGridViewCellStyle3.Format = "t";
            this.txtFrom.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtFrom.HeaderText = "From (Hour)";
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.txtFrom.Width = 90;
            // 
            // txtTo
            // 
            dataGridViewCellStyle4.Format = "t";
            this.txtTo.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtTo.HeaderText = "To  (Hour)";
            this.txtTo.Name = "txtTo";
            this.txtTo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.txtTo.Width = 90;
            // 
            // txtTotal
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtTotal.HeaderText = "Total (Hour)";
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Width = 60;
            // 
            // txtLess
            // 
            dataGridViewCellStyle6.NullValue = "0";
            this.txtLess.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtLess.HeaderText = "Less (Minutes)";
            this.txtLess.Name = "txtLess";
            this.txtLess.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtLess.Width = 60;
            // 
            // txtGtotal
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtGtotal.DefaultCellStyle = dataGridViewCellStyle7;
            this.txtGtotal.HeaderText = "GTotal (Hour)";
            this.txtGtotal.Name = "txtGtotal";
            this.txtGtotal.ReadOnly = true;
            this.txtGtotal.Width = 60;
            // 
            // txtAmount
            // 
            this.txtAmount.HeaderText = "Amount";
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            // 
            // cmbSection
            // 
            this.cmbSection.HeaderText = "Section";
            this.cmbSection.Items.AddRange(new object[] {
            "Common",
            "Common (A)",
            "Common (B)",
            "AP-1 (B)",
            "BH-1 (A)",
            "BH-1 (B)",
            "BH-2 (A)",
            "BH-2 (B)",
            "Cement Prep",
            "Chemical ",
            "Flushing (B)",
            "Packing (A)",
            "Packing (B)",
            "SU-1 (A)",
            "Washing (A)"});
            this.cmbSection.Name = "cmbSection";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(816, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(735, 360);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Employee Name";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn2.HeaderText = "Day";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Decription";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // gridTimeControl1
            // 
            dataGridViewCellStyle10.Format = "t";
            this.gridTimeControl1.DefaultCellStyle = dataGridViewCellStyle10;
            this.gridTimeControl1.HeaderText = "From (Hour)";
            this.gridTimeControl1.Name = "gridTimeControl1";
            this.gridTimeControl1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTimeControl1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridTimeControl1.Width = 90;
            // 
            // gridTimeControl2
            // 
            dataGridViewCellStyle11.Format = "t";
            this.gridTimeControl2.DefaultCellStyle = dataGridViewCellStyle11;
            this.gridTimeControl2.HeaderText = "To  (Hour)";
            this.gridTimeControl2.Name = "gridTimeControl2";
            this.gridTimeControl2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTimeControl2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridTimeControl2.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Total (Hour)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // gridTimeControl3
            // 
            this.gridTimeControl3.HeaderText = "Less (Hour)";
            this.gridTimeControl3.Name = "gridTimeControl3";
            this.gridTimeControl3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTimeControl3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.gridTimeControl3.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "GTotal (Hour)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(582, 21);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(37, 13);
            this.lblMonth.TabIndex = 4;
            this.lblMonth.Text = "Month";
            // 
            // dtOverTimeMonth
            // 
            this.dtOverTimeMonth.CustomFormat = "MMM-yyyy";
            this.dtOverTimeMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOverTimeMonth.Location = new System.Drawing.Point(625, 18);
            this.dtOverTimeMonth.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtOverTimeMonth.Name = "dtOverTimeMonth";
            this.dtOverTimeMonth.ShowUpDown = true;
            this.dtOverTimeMonth.Size = new System.Drawing.Size(114, 20);
            this.dtOverTimeMonth.TabIndex = 5;
            this.dtOverTimeMonth.Value = new System.DateTime(2016, 2, 11, 0, 0, 0, 0);
            this.dtOverTimeMonth.ValueChanged += new System.EventHandler(this.dtOverTimeMonth_ValueChanged);
            // 
            // btnApproved
            // 
            this.btnApproved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnApproved.Location = new System.Drawing.Point(654, 360);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(75, 23);
            this.btnApproved.TabIndex = 14;
            this.btnApproved.Text = "Approved";
            this.btnApproved.UseVisualStyleBackColor = true;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnReject
            // 
            this.btnReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.Red;
            this.btnReject.Location = new System.Drawing.Point(12, 360);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 17;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.BackColor = System.Drawing.SystemColors.Control;
            this.txtEmployeeName.Location = new System.Drawing.Point(238, 18);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(312, 20);
            this.txtEmployeeName.TabIndex = 3;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(99, 18);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(109, 20);
            this.txtEmployeeCode.TabIndex = 1;
            this.txtEmployeeCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmployeeCode.TextChanged += new System.EventHandler(this.txtEmployeeCode_TextChanged);
            this.txtEmployeeCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmployeeCode_KeyPress);
            // 
            // btnPicker
            // 
            this.btnPicker.Location = new System.Drawing.Point(210, 18);
            this.btnPicker.Name = "btnPicker";
            this.btnPicker.Size = new System.Drawing.Size(26, 20);
            this.btnPicker.TabIndex = 2;
            this.btnPicker.Text = "...";
            this.btnPicker.UseVisualStyleBackColor = true;
            this.btnPicker.Click += new System.EventHandler(this.btnPicker_Click);
            // 
            // dtAddDay
            // 
            this.dtAddDay.CustomFormat = "dd-MMM-yyyy";
            this.dtAddDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAddDay.Location = new System.Drawing.Point(99, 52);
            this.dtAddDay.Name = "dtAddDay";
            this.dtAddDay.Size = new System.Drawing.Size(109, 20);
            this.dtAddDay.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add Date";
            // 
            // btnAddDate
            // 
            this.btnAddDate.Location = new System.Drawing.Point(214, 51);
            this.btnAddDate.Name = "btnAddDate";
            this.btnAddDate.Size = new System.Drawing.Size(75, 23);
            this.btnAddDate.TabIndex = 8;
            this.btnAddDate.Text = "Add";
            this.btnAddDate.UseVisualStyleBackColor = true;
            this.btnAddDate.Click += new System.EventHandler(this.btnAddDate_Click);
            // 
            // txtGtotalHour
            // 
            this.txtGtotalHour.Location = new System.Drawing.Point(750, 314);
            this.txtGtotalHour.Name = "txtGtotalHour";
            this.txtGtotalHour.ReadOnly = true;
            this.txtGtotalHour.Size = new System.Drawing.Size(55, 20);
            this.txtGtotalHour.TabIndex = 182;
            this.txtGtotalHour.Text = "0";
            this.txtGtotalHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLessMinutes
            // 
            this.txtLessMinutes.Location = new System.Drawing.Point(689, 314);
            this.txtLessMinutes.Name = "txtLessMinutes";
            this.txtLessMinutes.ReadOnly = true;
            this.txtLessMinutes.Size = new System.Drawing.Size(55, 20);
            this.txtLessMinutes.TabIndex = 11;
            this.txtLessMinutes.Text = "0";
            this.txtLessMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalHoure
            // 
            this.txtTotalHoure.Location = new System.Drawing.Point(628, 314);
            this.txtTotalHoure.Name = "txtTotalHoure";
            this.txtTotalHoure.ReadOnly = true;
            this.txtTotalHoure.Size = new System.Drawing.Size(55, 20);
            this.txtTotalHoure.TabIndex = 184;
            this.txtTotalHoure.Text = "0";
            this.txtTotalHoure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(811, 314);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(80, 20);
            this.txtTotalAmount.TabIndex = 13;
            this.txtTotalAmount.Text = "0";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(628, 314);
            this.txtMin.Name = "txtMin";
            this.txtMin.ReadOnly = true;
            this.txtMin.Size = new System.Drawing.Size(55, 20);
            this.txtMin.TabIndex = 10;
            this.txtMin.Text = "0";
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMin.Visible = false;
            // 
            // txtGMin
            // 
            this.txtGMin.Location = new System.Drawing.Point(750, 314);
            this.txtGMin.Name = "txtGMin";
            this.txtGMin.ReadOnly = true;
            this.txtGMin.Size = new System.Drawing.Size(55, 20);
            this.txtGMin.TabIndex = 12;
            this.txtGMin.Text = "0";
            this.txtGMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGMin.Visible = false;
            // 
            // lblAmountInWord
            // 
            this.lblAmountInWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAmountInWord.AutoSize = true;
            this.lblAmountInWord.Location = new System.Drawing.Point(134, 334);
            this.lblAmountInWord.Name = "lblAmountInWord";
            this.lblAmountInWord.Size = new System.Drawing.Size(35, 13);
            this.lblAmountInWord.TabIndex = 189;
            this.lblAmountInWord.Text = "label6";
            this.lblAmountInWord.Visible = false;
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(9, 334);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(119, 13);
            this.label50.TabIndex = 188;
            this.label50.Text = "Net Amount ( In Word) :";
            // 
            // frmOverTime
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 396);
            this.Controls.Add(this.lblAmountInWord);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.txtGMin);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtTotalHoure);
            this.Controls.Add(this.txtLessMinutes);
            this.Controls.Add(this.txtGtotalHour);
            this.Controls.Add(this.btnAddDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtAddDay);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.btnPicker);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApproved);
            this.Controls.Add(this.dtOverTimeMonth);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvOverTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOverTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOverTime";
            this.Load += new System.EventHandler(this.frmOverTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOverTime;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private CJ.Win.Control.GridTimeControl gridTimeControl1;
        private CJ.Win.Control.GridTimeControl gridTimeControl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private CJ.Win.Control.GridTimeControl gridTimeControl3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.DateTimePicker dtOverTimeMonth;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Button btnPicker;
        private System.Windows.Forms.DateTimePicker dtAddDay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddDate;
        private System.Windows.Forms.TextBox txtGtotalHour;
        private System.Windows.Forms.TextBox txtLessMinutes;
        private System.Windows.Forms.TextBox txtTotalHoure;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtGMin;
        private System.Windows.Forms.Label lblAmountInWord;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDecription;
        private Control.GridTimeControl txtFrom;
        private Control.GridTimeControl txtTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtLess;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtGtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAmount;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbSection;
    }
}