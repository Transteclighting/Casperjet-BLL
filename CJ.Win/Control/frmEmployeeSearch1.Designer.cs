namespace CJ.Win.Control
{
    partial class frmEmployeeSearch1
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
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.colDesignation = new System.Windows.Forms.ColumnHeader();
            this.colSection = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.colDepartment = new System.Windows.Forms.ColumnHeader();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwEmployees = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 156;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 154;
            // 
            // colSection
            // 
            this.colSection.Text = "Section";
            this.colSection.Width = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 189;
            this.label3.Text = "Company Name";
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Department";
            this.colDepartment.Width = 116;
            // 
            // cboCompany
            // 
            this.cboCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(102, 15);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(236, 21);
            this.cboCompany.TabIndex = 188;
            this.cboCompany.SelectedIndexChanged += new System.EventHandler(this.cboCompany_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(359, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 187;
            this.label8.Text = "Department";
            // 
            // cboDepartment
            // 
            this.cboDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(427, 10);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(207, 21);
            this.cboDepartment.TabIndex = 186;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 191;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmployeeName.Location = new System.Drawing.Point(102, 45);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(236, 20);
            this.txtEmployeeName.TabIndex = 184;
            this.txtEmployeeName.TextChanged += new System.EventHandler(this.txtEmployeeName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 182;
            this.label1.Text = "Employee Name";
            // 
            // lvwEmployees
            // 
            this.lvwEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colSection,
            this.colDesignation,
            this.colDepartment,
            this.colCompany});
            this.lvwEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwEmployees.FullRowSelect = true;
            this.lvwEmployees.GridLines = true;
            this.lvwEmployees.HideSelection = false;
            this.lvwEmployees.Location = new System.Drawing.Point(15, 80);
            this.lvwEmployees.MultiSelect = false;
            this.lvwEmployees.Name = "lvwEmployees";
            this.lvwEmployees.Size = new System.Drawing.Size(684, 360);
            this.lvwEmployees.TabIndex = 181;
            this.lvwEmployees.UseCompatibleStateImageBehavior = false;
            this.lvwEmployees.View = System.Windows.Forms.View.Details;
            this.lvwEmployees.DoubleClick += new System.EventHandler(this.lvwEmployees_DoubleClick);
            this.lvwEmployees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwEmployees_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(378, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 191;
            this.label4.Text = "Section";
            // 
            // cmbSection
            // 
            this.cmbSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(427, 44);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(207, 21);
            this.cmbSection.TabIndex = 190;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.cmbSection_SelectedIndexChanged);
            // 
            // frmEmployeeSearch1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 453);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwEmployees);
            this.Name = "frmEmployeeSearch1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmEmployeeSearch1";
            this.Load += new System.EventHandler(this.frmEmployeeSearch1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colDesignation;
        private System.Windows.Forms.ColumnHeader colSection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwEmployees;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSection;
    }
}