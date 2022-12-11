namespace CJ.Win
{
    partial class frmHRPayrollEmployeeSettingCopy
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
            this.lblOverWrite = new System.Windows.Forms.Label();
            this.cmbEntryAction = new System.Windows.Forms.ComboBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtCopyYear = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lvwItem = new System.Windows.Forms.ListView();
            this.colEmplCode = new System.Windows.Forms.ColumnHeader();
            this.colEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.colDesignation = new System.Windows.Forms.ColumnHeader();
            this.colDepartment = new System.Windows.Forms.ColumnHeader();
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtSetTo = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOverWrite
            // 
            this.lblOverWrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverWrite.Location = new System.Drawing.Point(36, 49);
            this.lblOverWrite.Name = "lblOverWrite";
            this.lblOverWrite.Size = new System.Drawing.Size(150, 13);
            this.lblOverWrite.TabIndex = 203;
            this.lblOverWrite.Text = "Overwrite to already set Data? ";
            // 
            // cmbEntryAction
            // 
            this.cmbEntryAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntryAction.FormattingEnabled = true;
            this.cmbEntryAction.Location = new System.Drawing.Point(188, 45);
            this.cmbEntryAction.Name = "cmbEntryAction";
            this.cmbEntryAction.Size = new System.Drawing.Size(72, 21);
            this.cmbEntryAction.TabIndex = 202;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(458, 36);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(72, 26);
            this.btnGet.TabIndex = 201;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 199;
            this.label2.Text = "Copy from";
            // 
            // dtCopyYear
            // 
            this.dtCopyYear.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCopyYear.CustomFormat = "yyyy";
            this.dtCopyYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCopyYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCopyYear.Location = new System.Drawing.Point(65, 16);
            this.dtCopyYear.Name = "dtCopyYear";
            this.dtCopyYear.ShowUpDown = true;
            this.dtCopyYear.Size = new System.Drawing.Size(75, 23);
            this.dtCopyYear.TabIndex = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 198;
            this.label1.Text = "Employee";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(173, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 197;
            this.label8.Text = "Department";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(238, 15);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(206, 21);
            this.cmbDepartment.TabIndex = 196;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 194;
            this.label3.Text = "Company";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(68, 16);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(99, 21);
            this.cmbCompany.TabIndex = 193;
            // 
            // lvwItem
            // 
            this.lvwItem.CheckBoxes = true;
            this.lvwItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmplCode,
            this.colEmployeeName,
            this.colDesignation,
            this.colDepartment,
            this.colCompany});
            this.lvwItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwItem.FullRowSelect = true;
            this.lvwItem.GridLines = true;
            this.lvwItem.HideSelection = false;
            this.lvwItem.Location = new System.Drawing.Point(12, 93);
            this.lvwItem.MultiSelect = false;
            this.lvwItem.Name = "lvwItem";
            this.lvwItem.Size = new System.Drawing.Size(537, 235);
            this.lvwItem.TabIndex = 204;
            this.lvwItem.UseCompatibleStateImageBehavior = false;
            this.lvwItem.View = System.Windows.Forms.View.Details;
            // 
            // colEmplCode
            // 
            this.colEmplCode.Text = "Empl Code";
            this.colEmplCode.Width = 70;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Text = "Employee Name";
            this.colEmployeeName.Width = 156;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 120;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Department";
            this.colDepartment.Width = 122;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGet);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbDepartment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbCompany);
            this.groupBox1.Controls.Add(this.ctlEmployee1);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 68);
            this.groupBox1.TabIndex = 205;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(68, 41);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(386, 25);
            this.ctlEmployee1.TabIndex = 195;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(14, 73);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(71, 17);
            this.chkAll.TabIndex = 206;
            this.chkAll.Text = "Check All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 207;
            this.label4.Text = "Set to";
            // 
            // dtSetTo
            // 
            this.dtSetTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSetTo.CustomFormat = "yyyy";
            this.dtSetTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSetTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSetTo.Location = new System.Drawing.Point(188, 16);
            this.dtSetTo.Name = "dtSetTo";
            this.dtSetTo.ShowUpDown = true;
            this.dtSetTo.Size = new System.Drawing.Size(75, 23);
            this.dtSetTo.TabIndex = 208;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtSetTo);
            this.groupBox2.Controls.Add(this.lblOverWrite);
            this.groupBox2.Controls.Add(this.cmbEntryAction);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtCopyYear);
            this.groupBox2.Location = new System.Drawing.Point(12, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 74);
            this.groupBox2.TabIndex = 209;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action Criteria";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(81, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 26);
            this.btnSave.TabIndex = 202;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(157, 39);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 26);
            this.btnClose.TabIndex = 210;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Location = new System.Drawing.Point(306, 338);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 74);
            this.groupBox3.TabIndex = 211;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Action";
            // 
            // frmHRPayrollEmployeeSettingCopy
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 425);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvwItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHRPayrollEmployeeSettingCopy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHRPayrollEmployeeSettingCopy";
            this.Load += new System.EventHandler(this.frmHRPayrollEmployeeSettingCopy_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOverWrite;
        private System.Windows.Forms.ComboBox cmbEntryAction;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtCopyYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ListView lvwItem;
        private System.Windows.Forms.ColumnHeader colEmplCode;
        private System.Windows.Forms.ColumnHeader colEmployeeName;
        private System.Windows.Forms.ColumnHeader colDesignation;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtSetTo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}