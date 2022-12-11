namespace CJ.Win.HR
{
    partial class frmHROverTimeEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHROverTimeEmployee));
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.txtEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtAddDay = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGetEmployee = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
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
            this.dgvItem.Location = new System.Drawing.Point(12, 112);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.Size = new System.Drawing.Size(720, 237);
            this.dgvItem.TabIndex = 21;
            // 
            // txtEmployeeCode
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtEmployeeCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtEmployeeCode.Frozen = true;
            this.txtEmployeeCode.HeaderText = "Code";
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.ReadOnly = true;
            this.txtEmployeeCode.Width = 60;
            // 
            // txtEmployeeName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtEmployeeName.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtEmployeeName.Frozen = true;
            this.txtEmployeeName.HeaderText = "Employee Name";
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.ReadOnly = true;
            this.txtEmployeeName.Width = 180;
            // 
            // txtEmployeeID
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtEmployeeID.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtEmployeeID.HeaderText = "Employee ID";
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Visible = false;
            this.txtEmployeeID.Width = 60;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(643, 355);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 26);
            this.btnClose.TabIndex = 40;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(550, 355);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 26);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label3.Location = new System.Drawing.Point(32, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 42;
            this.label3.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(110, 8);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(176, 23);
            this.cmbCompany.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 43;
            this.label1.Text = "OverTime Date";
            // 
            // dtAddDay
            // 
            this.dtAddDay.CustomFormat = "dd-MMM-yyyy";
            this.dtAddDay.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtAddDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAddDay.Location = new System.Drawing.Point(110, 37);
            this.dtAddDay.Name = "dtAddDay";
            this.dtAddDay.Size = new System.Drawing.Size(100, 23);
            this.dtAddDay.TabIndex = 44;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtDescription.Location = new System.Drawing.Point(110, 66);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(351, 23);
            this.txtDescription.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label5.Location = new System.Drawing.Point(33, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 47;
            this.label5.Text = "Description";
            // 
            // btnGetEmployee
            // 
            this.btnGetEmployee.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGetEmployee.Location = new System.Drawing.Point(467, 64);
            this.btnGetEmployee.Name = "btnGetEmployee";
            this.btnGetEmployee.Size = new System.Drawing.Size(104, 30);
            this.btnGetEmployee.TabIndex = 48;
            this.btnGetEmployee.Text = "Get Employee";
            this.btnGetEmployee.UseVisualStyleBackColor = true;
            this.btnGetEmployee.Click += new System.EventHandler(this.btnGetEmployee_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(292, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 54;
            this.label6.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(331, 9);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(176, 21);
            this.cmbType.TabIndex = 53;
            // 
            // frmHROverTimeEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 391);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnGetEmployee);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtAddDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHROverTimeEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HR Over TimeEmployee";
            this.Load += new System.EventHandler(this.frmHROverTimeEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtAddDay;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGetEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmployeeID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbType;
    }
}