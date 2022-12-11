namespace CJ.Win.HR
{
    partial class frmMAPProductGroup
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
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbEMPType = new System.Windows.Forms.ComboBox();
            this.cmbDatatype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkPGAll = new System.Windows.Forms.CheckBox();
            this.lvwPGType = new System.Windows.Forms.ListView();
            this.colBrandMAG = new System.Windows.Forms.ColumnHeader();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.ctlEmployee = new CJ.Win.ctlEmployee();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(19, 12);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(61, 13);
            this.lblEmployee.TabIndex = 126;
            this.lblEmployee.Text = "Employee";
            // 
            // cmbEMPType
            // 
            this.cmbEMPType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEMPType.FormattingEnabled = true;
            this.cmbEMPType.Location = new System.Drawing.Point(86, 40);
            this.cmbEMPType.Name = "cmbEMPType";
            this.cmbEMPType.Size = new System.Drawing.Size(218, 21);
            this.cmbEMPType.TabIndex = 127;
            // 
            // cmbDatatype
            // 
            this.cmbDatatype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatatype.FormattingEnabled = true;
            this.cmbDatatype.Location = new System.Drawing.Point(86, 67);
            this.cmbDatatype.Name = "cmbDatatype";
            this.cmbDatatype.Size = new System.Drawing.Size(218, 21);
            this.cmbDatatype.TabIndex = 128;
            this.cmbDatatype.SelectedIndexChanged += new System.EventHandler(this.cmbDatatype_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 129;
            this.label1.Text = "Group Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 130;
            this.label2.Text = "Emp Type";
            // 
            // txtSort
            // 
            this.txtSort.Location = new System.Drawing.Point(86, 94);
            this.txtSort.Name = "txtSort";
            this.txtSort.Size = new System.Drawing.Size(107, 20);
            this.txtSort.TabIndex = 132;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 133;
            this.label3.Text = "Sort";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkPGAll);
            this.groupBox6.Controls.Add(this.lvwPGType);
            this.groupBox6.ForeColor = System.Drawing.Color.Black;
            this.groupBox6.Location = new System.Drawing.Point(11, 127);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(418, 152);
            this.groupBox6.TabIndex = 189;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Brand/Product Group";
            // 
            // chkPGAll
            // 
            this.chkPGAll.AutoSize = true;
            this.chkPGAll.Location = new System.Drawing.Point(342, 6);
            this.chkPGAll.Name = "chkPGAll";
            this.chkPGAll.Size = new System.Drawing.Size(70, 17);
            this.chkPGAll.TabIndex = 187;
            this.chkPGAll.Text = "Select All";
            this.chkPGAll.UseVisualStyleBackColor = true;
            this.chkPGAll.CheckedChanged += new System.EventHandler(this.chkPGAll_CheckedChanged);
            // 
            // lvwPGType
            // 
            this.lvwPGType.CheckBoxes = true;
            this.lvwPGType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colBrandMAG});
            this.lvwPGType.FullRowSelect = true;
            this.lvwPGType.GridLines = true;
            this.lvwPGType.HideSelection = false;
            this.lvwPGType.Location = new System.Drawing.Point(6, 29);
            this.lvwPGType.Name = "lvwPGType";
            this.lvwPGType.Size = new System.Drawing.Size(404, 114);
            this.lvwPGType.TabIndex = 187;
            this.lvwPGType.UseCompatibleStateImageBehavior = false;
            this.lvwPGType.View = System.Windows.Forms.View.Details;
            // 
            // colBrandMAG
            // 
            this.colBrandMAG.Text = "Brand/MAG";
            this.colBrandMAG.Width = 394;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(273, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 190;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(354, 314);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 191;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(65, 286);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(364, 20);
            this.txtRemarks.TabIndex = 192;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 193;
            this.label4.Text = "Remarks";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(240, 96);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(64, 17);
            this.chkIsActive.TabIndex = 194;
            this.chkIsActive.Text = "IsActive";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // ctlEmployee
            // 
            this.ctlEmployee.Location = new System.Drawing.Point(86, 9);
            this.ctlEmployee.Name = "ctlEmployee";
            this.ctlEmployee.Size = new System.Drawing.Size(359, 25);
            this.ctlEmployee.TabIndex = 125;
            // 
            // frmMAPProductGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 350);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDatatype);
            this.Controls.Add(this.cmbEMPType);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.ctlEmployee);
            this.Name = "frmMAPProductGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMAPProductGroup";
            this.Load += new System.EventHandler(this.frmMAPProductGroup_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlEmployee ctlEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEMPType;
        private System.Windows.Forms.ComboBox cmbDatatype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkPGAll;
        private System.Windows.Forms.ListView lvwPGType;
        private System.Windows.Forms.ColumnHeader colBrandMAG;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsActive;
    }
}