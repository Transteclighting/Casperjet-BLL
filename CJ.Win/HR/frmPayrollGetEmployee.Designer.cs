namespace CJ.Win.HR
{
    partial class frmPayrollGetEmployee
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
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.ckbSelect = new System.Windows.Forms.CheckBox();
            this.lvwEmployee = new System.Windows.Forms.ListView();
            this.colEmployeeNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmployeeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesignation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGet = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbIsFactoryEmployee = new System.Windows.Forms.ComboBox();
            this.linklblMultiSelectDepartments = new System.Windows.Forms.LinkLabel();
            this.lblType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelMultiSelectDesignation = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(16, 15);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(51, 13);
            this.lblCompanyName.TabIndex = 26;
            this.lblCompanyName.Text = "Company";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Department";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(70, 38);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(195, 21);
            this.cmbDepartment.TabIndex = 23;
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoSize = true;
            this.ckbSelect.Location = new System.Drawing.Point(16, 171);
            this.ckbSelect.Name = "ckbSelect";
            this.ckbSelect.Size = new System.Drawing.Size(83, 17);
            this.ckbSelect.TabIndex = 164;
            this.ckbSelect.Text = "Checked All";
            this.ckbSelect.UseVisualStyleBackColor = true;
            this.ckbSelect.CheckedChanged += new System.EventHandler(this.ckbSelect_CheckedChanged);
            // 
            // lvwEmployee
            // 
            this.lvwEmployee.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvwEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwEmployee.CheckBoxes = true;
            this.lvwEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmployeeNo,
            this.colEmployeeName,
            this.colDesignation,
            this.colDepartment});
            this.lvwEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwEmployee.FullRowSelect = true;
            this.lvwEmployee.GridLines = true;
            this.lvwEmployee.HideSelection = false;
            this.lvwEmployee.Location = new System.Drawing.Point(12, 195);
            this.lvwEmployee.MultiSelect = false;
            this.lvwEmployee.Name = "lvwEmployee";
            this.lvwEmployee.Size = new System.Drawing.Size(439, 278);
            this.lvwEmployee.TabIndex = 163;
            this.lvwEmployee.UseCompatibleStateImageBehavior = false;
            this.lvwEmployee.View = System.Windows.Forms.View.Details;
            // 
            // colEmployeeNo
            // 
            this.colEmployeeNo.Text = "Employee ID";
            this.colEmployeeNo.Width = 75;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Text = "Employee Name";
            this.colEmployeeName.Width = 150;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 110;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Department";
            this.colDepartment.Width = 110;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(300, 162);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 26);
            this.btnGet.TabIndex = 165;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(379, 162);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 26);
            this.btnSet.TabIndex = 166;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(376, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 167;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabelMultiSelectDesignation);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbIsFactoryEmployee);
            this.groupBox1.Controls.Add(this.linklblMultiSelectDepartments);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCompanyName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbDepartment);
            this.groupBox1.Controls.Add(this.ctlEmployee1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 153);
            this.groupBox1.TabIndex = 168;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "IsFactory";
            // 
            // cmbIsFactoryEmployee
            // 
            this.cmbIsFactoryEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsFactoryEmployee.FormattingEnabled = true;
            this.cmbIsFactoryEmployee.Location = new System.Drawing.Point(70, 122);
            this.cmbIsFactoryEmployee.Name = "cmbIsFactoryEmployee";
            this.cmbIsFactoryEmployee.Size = new System.Drawing.Size(195, 21);
            this.cmbIsFactoryEmployee.TabIndex = 30;
            // 
            // linklblMultiSelectDepartments
            // 
            this.linklblMultiSelectDepartments.AutoSize = true;
            this.linklblMultiSelectDepartments.Location = new System.Drawing.Point(285, 40);
            this.linklblMultiSelectDepartments.Name = "linklblMultiSelectDepartments";
            this.linklblMultiSelectDepartments.Size = new System.Drawing.Size(125, 13);
            this.linklblMultiSelectDepartments.TabIndex = 29;
            this.linklblMultiSelectDepartments.TabStop = true;
            this.linklblMultiSelectDepartments.Text = "Multi Select Departments";
            this.linklblMultiSelectDepartments.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblMultiSelectDepartments_LinkClicked);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(267, 15);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 28;
            this.lblType.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Employee";
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(70, 94);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(375, 25);
            this.ctlEmployee1.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Designation";
            // 
            // linkLabelMultiSelectDesignation
            // 
            this.linkLabelMultiSelectDesignation.AutoSize = true;
            this.linkLabelMultiSelectDesignation.Location = new System.Drawing.Point(70, 67);
            this.linkLabelMultiSelectDesignation.Name = "linkLabelMultiSelectDesignation";
            this.linkLabelMultiSelectDesignation.Size = new System.Drawing.Size(121, 13);
            this.linkLabelMultiSelectDesignation.TabIndex = 33;
            this.linkLabelMultiSelectDesignation.TabStop = true;
            this.linkLabelMultiSelectDesignation.Text = "Multi Select Designation";
            this.linkLabelMultiSelectDesignation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMultiSelectDesignation_LinkClicked);
            // 
            // frmPayrollGetEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.ckbSelect);
            this.Controls.Add(this.lvwEmployee);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayrollGetEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Get Employee";
            this.Load += new System.EventHandler(this.frmPayrollGetEmployee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.CheckBox ckbSelect;
        private System.Windows.Forms.ListView lvwEmployee;
        private System.Windows.Forms.ColumnHeader colEmployeeNo;
        private System.Windows.Forms.ColumnHeader colEmployeeName;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colDesignation;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.LinkLabel linklblMultiSelectDepartments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbIsFactoryEmployee;
        private System.Windows.Forms.LinkLabel linkLabelMultiSelectDesignation;
        private System.Windows.Forms.Label label3;
    }
}