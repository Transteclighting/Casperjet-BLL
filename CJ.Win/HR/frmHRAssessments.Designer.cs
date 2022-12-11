namespace CJ.Win.HR
{
    partial class frmHRAssessments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHRAssessments));
            this.lvwHRAssessment = new System.Windows.Forms.ListView();
            this.colEmpCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmpName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesignation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssessmentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssessmentYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLineManager = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbAssessmentType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.udAssessmentYear = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStatus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.cboDesignation = new System.Windows.Forms.ComboBox();
            this.txtLineManager = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            ((System.ComponentModel.ISupportInitialize)(this.udAssessmentYear)).BeginInit();
            this.SuspendLayout();
            // 
            // lvwHRAssessment
            // 
            this.lvwHRAssessment.AllowColumnReorder = true;
            this.lvwHRAssessment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwHRAssessment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmpCode,
            this.colEmpName,
            this.colDesignation,
            this.colDepartment,
            this.colCompany,
            this.colAssessmentType,
            this.colAssessmentYear,
            this.colLineManager,
            this.colIsActive,
            this.colStatus});
            this.lvwHRAssessment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwHRAssessment.FullRowSelect = true;
            this.lvwHRAssessment.GridLines = true;
            this.lvwHRAssessment.HideSelection = false;
            this.lvwHRAssessment.Location = new System.Drawing.Point(12, 138);
            this.lvwHRAssessment.Name = "lvwHRAssessment";
            this.lvwHRAssessment.Size = new System.Drawing.Size(839, 332);
            this.lvwHRAssessment.TabIndex = 15;
            this.lvwHRAssessment.UseCompatibleStateImageBehavior = false;
            this.lvwHRAssessment.View = System.Windows.Forms.View.Details;
            // 
            // colEmpCode
            // 
            this.colEmpCode.Text = "Emp Code";
            this.colEmpCode.Width = 86;
            // 
            // colEmpName
            // 
            this.colEmpName.Text = "Emp Name";
            this.colEmpName.Width = 132;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 87;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Department";
            this.colDepartment.Width = 98;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 84;
            // 
            // colAssessmentType
            // 
            this.colAssessmentType.Text = "Assessment ype";
            this.colAssessmentType.Width = 102;
            // 
            // colAssessmentYear
            // 
            this.colAssessmentYear.Text = "Assessment Year";
            this.colAssessmentYear.Width = 106;
            // 
            // colLineManager
            // 
            this.colLineManager.Text = "Line Manager";
            this.colLineManager.Width = 93;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "IsActive";
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            // 
            // cmbAssessmentType
            // 
            this.cmbAssessmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssessmentType.FormattingEnabled = true;
            this.cmbAssessmentType.Location = new System.Drawing.Point(116, 43);
            this.cmbAssessmentType.Name = "cmbAssessmentType";
            this.cmbAssessmentType.Size = new System.Drawing.Size(216, 23);
            this.cmbAssessmentType.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(572, 104);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 30);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(857, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 30);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(857, 174);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 30);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(857, 138);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 30);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // udAssessmentYear
            // 
            this.udAssessmentYear.Location = new System.Drawing.Point(448, 107);
            this.udAssessmentYear.Maximum = new decimal(new int[] {
            2200,
            0,
            0,
            0});
            this.udAssessmentYear.Minimum = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.udAssessmentYear.Name = "udAssessmentYear";
            this.udAssessmentYear.Size = new System.Drawing.Size(118, 21);
            this.udAssessmentYear.TabIndex = 13;
            this.udAssessmentYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udAssessmentYear.Value = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Employee:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Assessment Year:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Assessment Type:";
            // 
            // btnStatus
            // 
            this.btnStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.Location = new System.Drawing.Point(857, 210);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(92, 30);
            this.btnStatus.TabIndex = 18;
            this.btnStatus.Text = "&Status Update";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Department:";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(116, 74);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(216, 23);
            this.cboDepartment.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Company:";
            // 
            // cboCompany
            // 
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(448, 75);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(216, 23);
            this.cboCompany.TabIndex = 9;
            // 
            // lblDesignation
            // 
            this.lblDesignation.AutoSize = true;
            this.lblDesignation.Location = new System.Drawing.Point(366, 42);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(76, 15);
            this.lblDesignation.TabIndex = 4;
            this.lblDesignation.Text = "Designation:";
            // 
            // cboDesignation
            // 
            this.cboDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDesignation.FormattingEnabled = true;
            this.cboDesignation.Location = new System.Drawing.Point(448, 42);
            this.cboDesignation.Name = "cboDesignation";
            this.cboDesignation.Size = new System.Drawing.Size(216, 23);
            this.cboDesignation.TabIndex = 5;
            // 
            // txtLineManager
            // 
            this.txtLineManager.Location = new System.Drawing.Point(116, 104);
            this.txtLineManager.Name = "txtLineManager";
            this.txtLineManager.Size = new System.Drawing.Size(216, 21);
            this.txtLineManager.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Line Manager:";
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(116, 14);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(531, 25);
            this.ctlEmployee1.TabIndex = 1;
            // 
            // frmHRAssessments
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 482);
            this.Controls.Add(this.txtLineManager);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDesignation);
            this.Controls.Add(this.cboDesignation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.btnStatus);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.udAssessmentYear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lvwHRAssessment);
            this.Controls.Add(this.cmbAssessmentType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHRAssessments";
            this.Text = "HR Assessments";
            this.Load += new System.EventHandler(this.frmHRAssessments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.udAssessmentYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvwHRAssessment;
        private System.Windows.Forms.ColumnHeader colEmpCode;
        private System.Windows.Forms.ColumnHeader colEmpName;
        private System.Windows.Forms.ComboBox cmbAssessmentType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown udAssessmentYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader colDesignation;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colAssessmentType;
        private System.Windows.Forms.ColumnHeader colAssessmentYear;
        private System.Windows.Forms.ColumnHeader colLineManager;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.ComboBox cboDesignation;
        private System.Windows.Forms.TextBox txtLineManager;
        private System.Windows.Forms.Label label4;
    }
}