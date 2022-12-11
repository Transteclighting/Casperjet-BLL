namespace CJ.POS
{
    partial class frmEmployeeAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeAttendance));
            this.dgvEmpAttendancePOS = new System.Windows.Forms.DataGridView();
            this.txtEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtInTime = new CJ.Win.Control.GridTimeControl();
            this.txtOutTime = new CJ.Win.Control.GridTimeControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtAddDay = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpAttendancePOS)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpAttendancePOS
            // 
            this.dgvEmpAttendancePOS.AllowUserToAddRows = false;
            this.dgvEmpAttendancePOS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpAttendancePOS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtEmployeeID,
            this.txtEmployeeName,
            this.txtInTime,
            this.txtOutTime});
            this.dgvEmpAttendancePOS.Location = new System.Drawing.Point(14, 44);
            this.dgvEmpAttendancePOS.Name = "dgvEmpAttendancePOS";
            this.dgvEmpAttendancePOS.Size = new System.Drawing.Size(587, 224);
            this.dgvEmpAttendancePOS.TabIndex = 2;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.HeaderText = "EmployeeID";
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.ReadOnly = true;
            this.txtEmployeeID.Visible = false;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.FillWeight = 140F;
            this.txtEmployeeName.HeaderText = "Employee Name";
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Width = 200;
            // 
            // txtInTime
            // 
            this.txtInTime.HeaderText = "In Time";
            this.txtInTime.Name = "txtInTime";
            this.txtInTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtInTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.txtInTime.Width = 80;
            // 
            // txtOutTime
            // 
            dataGridViewCellStyle1.NullValue = "0";
            this.txtOutTime.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtOutTime.HeaderText = "Out Time";
            this.txtOutTime.Name = "txtOutTime";
            this.txtOutTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtOutTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.txtOutTime.Width = 80;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(419, 274);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(514, 274);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // dtAddDay
            // 
            this.dtAddDay.CustomFormat = "dd-MMM-yyyy";
            this.dtAddDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAddDay.Location = new System.Drawing.Point(56, 14);
            this.dtAddDay.Name = "dtAddDay";
            this.dtAddDay.Size = new System.Drawing.Size(126, 21);
            this.dtAddDay.TabIndex = 1;
            this.dtAddDay.ValueChanged += new System.EventHandler(this.dtAddDay_ValueChanged);
            // 
            // frmEmployeeAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 313);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtAddDay);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvEmpAttendancePOS);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployeeAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeeAttendance";
            this.Load += new System.EventHandler(this.frmEmployeeAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpAttendancePOS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpAttendancePOS;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtAddDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmployeeName;
        private CJ.Win.Control.GridTimeControl txtInTime;
        private CJ.Win.Control.GridTimeControl txtOutTime;
    }
}