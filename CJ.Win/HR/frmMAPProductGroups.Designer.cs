namespace CJ.Win.HR
{
    partial class frmMAPProductGroups
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
            this.lvwMAPProductGroup = new System.Windows.Forms.ListView();
            this.colMAPID = new System.Windows.Forms.ColumnHeader();
            this.colEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.colDesignation = new System.Windows.Forms.ColumnHeader();
            this.colMAPEmployeeType = new System.Windows.Forms.ColumnHeader();
            this.colMAPGroupType = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMAPEmployeeType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMAPGroupType = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.colIsActive = new System.Windows.Forms.ColumnHeader();
            this.ctlEmployee = new CJ.Win.ctlEmployee();
            this.SuspendLayout();
            // 
            // lvwMAPProductGroup
            // 
            this.lvwMAPProductGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMAPProductGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMAPID,
            this.colEmployeeName,
            this.colDesignation,
            this.colMAPEmployeeType,
            this.colMAPGroupType,
            this.colIsActive});
            this.lvwMAPProductGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwMAPProductGroup.FullRowSelect = true;
            this.lvwMAPProductGroup.GridLines = true;
            this.lvwMAPProductGroup.HideSelection = false;
            this.lvwMAPProductGroup.Location = new System.Drawing.Point(17, 115);
            this.lvwMAPProductGroup.MultiSelect = false;
            this.lvwMAPProductGroup.Name = "lvwMAPProductGroup";
            this.lvwMAPProductGroup.Size = new System.Drawing.Size(645, 340);
            this.lvwMAPProductGroup.TabIndex = 1;
            this.lvwMAPProductGroup.UseCompatibleStateImageBehavior = false;
            this.lvwMAPProductGroup.View = System.Windows.Forms.View.Details;
            // 
            // colMAPID
            // 
            this.colMAPID.Text = "MAPID";
            this.colMAPID.Width = 87;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Text = "Employee Name";
            this.colEmployeeName.Width = 156;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 100;
            // 
            // colMAPEmployeeType
            // 
            this.colMAPEmployeeType.Text = "MAP Employee Type";
            this.colMAPEmployeeType.Width = 122;
            // 
            // colMAPGroupType
            // 
            this.colMAPGroupType.Text = "MAP Group Type";
            this.colMAPGroupType.Width = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "MAP Employee Type";
            // 
            // cmbMAPEmployeeType
            // 
            this.cmbMAPEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAPEmployeeType.FormattingEnabled = true;
            this.cmbMAPEmployeeType.Location = new System.Drawing.Point(133, 48);
            this.cmbMAPEmployeeType.Name = "cmbMAPEmployeeType";
            this.cmbMAPEmployeeType.Size = new System.Drawing.Size(193, 21);
            this.cmbMAPEmployeeType.TabIndex = 60;
            this.cmbMAPEmployeeType.SelectedIndexChanged += new System.EventHandler(this.cmbMAPEmployeeType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "MAP Group Type";
            // 
            // cmbMAPGroupType
            // 
            this.cmbMAPGroupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAPGroupType.FormattingEnabled = true;
            this.cmbMAPGroupType.Location = new System.Drawing.Point(133, 81);
            this.cmbMAPGroupType.Name = "cmbMAPGroupType";
            this.cmbMAPGroupType.Size = new System.Drawing.Size(193, 21);
            this.cmbMAPGroupType.TabIndex = 62;
            this.cmbMAPGroupType.SelectedIndexChanged += new System.EventHandler(this.cmbMAPGroupType_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(668, 428);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 27);
            this.btnClose.TabIndex = 64;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(668, 115);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 27);
            this.btnAdd.TabIndex = 63;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(21, 18);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(53, 13);
            this.lblEmployee.TabIndex = 128;
            this.lblEmployee.Text = "Employee";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(668, 148);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(86, 27);
            this.btnEdit.TabIndex = 129;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(668, 181);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 27);
            this.btnDelete.TabIndex = 130;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "IsActive";
            // 
            // ctlEmployee
            // 
            this.ctlEmployee.Location = new System.Drawing.Point(80, 12);
            this.ctlEmployee.Name = "ctlEmployee";
            this.ctlEmployee.Size = new System.Drawing.Size(553, 25);
            this.ctlEmployee.TabIndex = 127;
            this.ctlEmployee.Load += new System.EventHandler(this.ctlEmployee_Load);
            this.ctlEmployee.ChangeSelection += new System.EventHandler(this.ctlEmployee_ChangeSelection);
            // 
            // frmMAPProductGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 483);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.ctlEmployee);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMAPGroupType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMAPEmployeeType);
            this.Controls.Add(this.lvwMAPProductGroup);
            this.Name = "frmMAPProductGroups";
            this.Text = "frmMAPProductGroups";
            this.Load += new System.EventHandler(this.frmMAPProductGroups_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwMAPProductGroup;
        private System.Windows.Forms.ColumnHeader colMAPID;
        private System.Windows.Forms.ColumnHeader colEmployeeName;
        private System.Windows.Forms.ColumnHeader colDesignation;
        private System.Windows.Forms.ColumnHeader colMAPEmployeeType;
        private System.Windows.Forms.ColumnHeader colMAPGroupType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMAPEmployeeType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMAPGroupType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblEmployee;
        private ctlEmployee ctlEmployee;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.Button btnDelete;
    }
}